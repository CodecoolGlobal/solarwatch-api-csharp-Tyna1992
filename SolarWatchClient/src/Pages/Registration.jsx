import { useState } from "react";
import "../App.css"


function Registration() {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [email, setEmail] = useState('');

    const register = async (e) => {
        e.preventDefault();
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
            <form onSubmit={register}>
            <label>
                Username:
            </label>
            <br />
            <input type="text" value={username} onChange={(e) => setUsername(e.target.value)} />
            <label>
                Password:
            </label>
            <br />
            <input type="password" value={password} onChange={(e) => setPassword(e.target.value)}></input>
            <label>
                Email:
            </label>
            <br />
            <input type="email" value={email} onChange={(e) => setEmail(e.target.value)} />
            <br />
            <button className="button" type="submit">Register</button>
            <br />
            <button className="button" onClick={handleClear}>Clear</button>
            </form>
        </div>
    )
}

export default Registration;