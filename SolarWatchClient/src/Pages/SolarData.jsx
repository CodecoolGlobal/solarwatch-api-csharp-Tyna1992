import { useState} from "react";
import { useNavigate } from "react-router-dom";

function SolarWatch(){
const navigate = useNavigate();
const [solarData, SetSolarData] = useState({});
const [hideResult, setHideResult] = useState(true);
const [location, setLocation] = useState("");
const [date, setDate] = useState(new Date().toISOString().slice(0, 10));
const [sunrise, setSunrise] = useState("");
const [sunset, setSunset] = useState("");
const [loading, setLoading] = useState(true);

const handleSubmit = async (event) => {
    event.preventDefault();
    setLoading(false);
    try {
        const response = await fetch(`/api/Solar/SunriseSunset/${location}/${date}`, {
            method: "GET",
            headers:{
                "Content-Type": "application/json",
                Authorization: `Bearer ${sessionStorage.getItem("token")}`
            }
            });        
        
        if(!response.status === 401){
            sessionStorage.removeItem("token");
            alert("Session expired. Please login again.");
            navigate("/login");
        }
        const data = await response.json();
        console.log("data", data);
        SetSolarData(data);
        setSunrise(data.sunrise.split("T")[1].split("+")[0]);
        setSunset(data.sunset.split("T")[1].split("+")[0]);
        setLoading(true);
        event.target.date.value="";
        event.target.location.value="";
        setHideResult(false);

    } catch (error) {
        alert("Error: " + error);
        console.error("Error:", error);
    }
}

    return(
        <div className="solarwatch">
            <form onSubmit={handleSubmit}>
                <label>Date:</label>
                <br />
                <input onChange={(e) =>setDate(e.target.value)} type="date" name="date" />
                <br />
                <label>Location:</label>
                <br />
                <input onChange={(e) =>setLocation(e.target.value)} type="text" name="location" />
                <br />
                <button className="button"  type="submit">Submit</button>
            </form>
            <div hidden={loading}>
                <h2>Loading data, please wait....</h2>
            </div>
            <div className="result" hidden={hideResult}>
            <table>
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Location</th>
                        <th>Sunrise<img className="sunrise" src="https://cdn-icons-png.flaticon.com/512/1163/1163765.png" alt="sunrise"/> </th>
                        <th>Sunset<img className="sunset" src="https://static-00.iconduck.com/assets.00/sunset-icon-2048x1715-x56lkbet.png" alt="sunset"/></th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>{date}</td>
                        <td>{location}</td>
                        <td>{sunrise} </td>
                        <td>{sunset}</td>
                    </tr>
                </tbody>
            </table>
            </div>
        </div>
    )
}

export default SolarWatch;