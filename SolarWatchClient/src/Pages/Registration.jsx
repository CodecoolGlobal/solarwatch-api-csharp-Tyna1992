import { useState } from "react";
import "../App.css"


function Registration() {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [email, setEmail] = useState('');

    const register = async () => {
        try {
            const response = await fetch("/api/Auth/register", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({ username, password, email })

            })
            if (!response.ok) {
                throw new Error("An error occurred while registering")
            }
            const data = await response.json();
            setUsername('');
            setPassword('');
            setEmail('');
            alert("User registered successfully")
        }
        catch (error) {
            console.error(error);
        }
    }

    const handleClear = () => {
        setUsername('');
        setPassword('');
        setEmail('');
    }

    return (
        <div className="register">
            <label>
                Username:
            </label>
            <input type="text" value={username} onChange={(e) => setUsername(e.target.value)} />
            <label>
                Password:
            </label>
            <input type="password" value={password} onChange={(e) => setPassword(e.target.value)}></input>
            <label>
                Email:
            </label>
            <input type="email" value={email} onChange={(e) => setEmail(e.target.value)} />
            <button className="button" onClick={register}>Register</button>
            <button className="button" onClick={handleClear}>Clear</button>
        </div>
    )
}

export default Registration;