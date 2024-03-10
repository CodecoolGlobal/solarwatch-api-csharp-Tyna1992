import { useState } from "react";
import { useNavigate } from "react-router-dom";
import "../App.css";


function Login() {
    const navigate = useNavigate();

    const handleSubmit = async (event) => {
        event.preventDefault();
        const email = event.target.email.value;
        const password = event.target.password.value;
        try {
            const response = await fetch("/api/Auth/login", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({
                    email,
                    password
                })
            });
            if(!response.ok){
                throw new Error("Login failed");
            }
            const data = await response.json();
            alert("Login successful");
            console.log(data)
            sessionStorage.setItem("token", data.token);
            navigate("/");
        } catch (error) {
            alert(error);
            console.error("Error:", error);
        }
    }

    return (
        <div className="login">
            <h2>Login</h2>
            <form onSubmit={handleSubmit}> 
                <label>Email:</label>
                <br />
                <input type="email" name="email" />
                <br />
                <label>Password:</label>
                <br />
                <input type="password" name="password" />
                <br />
                <br />
                <button className="button" type="submit">Login</button>
                
            </form>
            

        </div>
    )
}

export default Login;