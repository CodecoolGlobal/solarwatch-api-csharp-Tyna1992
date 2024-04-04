import { useState, useEffect } from 'react'
import { Outlet, Link,useLocation } from "react-router-dom";
import './App.css'
import LogoutButton from './Components/LogoutButton';

function App() {
const [user, setUser] = useState(null);
const location = useLocation();

useEffect(() => {
  const whoAmI = async ()=> {
    try {
      const response = await fetch("/api/Auth/WhoAmI", {
        method: "GET",
        credentials: "include",
        headers: {
          "Content-Type": "application/json"
        }
      });
      const data = await response.json();
      if (data) {
        setUser(data.userName);
      }
      console.log(data);

    } catch (error) {
      console.log(error);
    }
  }
    whoAmI();
}, [location.pathname]);

  return (
    <div className = "app">
        
      <nav className='navbar'>
        {user === null ? (
            <>
              <ul>
                <Link to="/">
                  <button className='button' type='button'>Home</button>
                </Link>
                <Link to="/register">
                  <button className='button' type='button'>Register</button>
                </Link>
                <Link to="/login">
                  <button className='button' type='button'>Login</button>
                </Link>
                <Link to="/solarwatch">
                  <button className='button' type='button'>Get solar data</button>
                </Link>
                <Link to="/all">
                  <button className='button' type='button'>All the available solar data</button>
                </Link>
              </ul>
            </>
        ): user === "admin" ? (
            <>
              <ul>
                <Link to="/">
                  <button className='button' type='button'>Home</button>
                </Link>
                <Link to="/solarwatch">
                  <button className='button' type='button'>Get solar data</button>
                </Link>
                <Link to="/all">
                  <button className='button' type='button'>All the available solar data</button>
                </Link>
                <LogoutButton/>
              </ul>
            </>
        ): user !== "admin" ? (
            <>
              <ul>
                <Link to="/">
                  <button className='button' type='button'>Home</button>
                </Link>
                <Link to="/register">
                  <button className='button' type='button'>Register</button>
                </Link>
                <Link to="/solarwatch">
                  <button className='button' type='button'>Get solar data</button>
                </Link>
                <LogoutButton/>
              </ul>
            </>
        ):""}

      </nav>
      <Outlet/>
    </div>
  )
}

export default App
