import { useEffect, useState} from "react";
import "../App.css";
import { useNavigate } from "react-router-dom";

function AllData()
{
    const [data, setData] = useState([]);
    const navigate = useNavigate();

    useEffect(() =>{
        const fetchData = async() =>{
            try 
            {
                const response = await fetch("/api/Solar/SunriseSunset/all", {
                    method: "GET",
                    headers:{
                        "Content-Type": "application/json",
                        Authorization: `Bearer ${sessionStorage.getItem("token")}`
                    }
                });
                console.log(response);
                if(response.status === 403){
                    alert("Unauthorized access. Please login to access the data.")
                    sessionStorage.removeItem("token");
                    navigate("/login");
                    throw new Error("Unauthorized access. Please login to access the data.")
                }
                const data = await response.json();
                setData(data);
                console.log(data);
            } 
            catch (error) {
                console.error(error);
            }
        }
        fetchData();
    },[])

    return(
        <div className="alldata">
            <h2>All the available solar data</h2>
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
                    {data.map((item, index) => {
                        return(
                            <tr key={index}>
                                <td>{item.date.split("T")[0]}</td>
                                <td>{item.city}</td>
                                <td>{item.sunrise.split("T")[1].split("+")[0]}</td>
                                <td>{item.sunset.split("T")[1].split("+")[0]}</td>
                            </tr>
                        )
                    })}
                </tbody>
            </table>
        </div>
    )

}

export default AllData;