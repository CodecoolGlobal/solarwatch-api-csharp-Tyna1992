import { useState } from 'react'
import { Outlet, Link } from "react-router-dom";
import './App.css'

function App() {

  return (
    <div className = "app">
        
      <nav className='navbar'> 
        <ul>
          <Link to = "/">
            <button className='button' type='button'>Home</button>
          </Link>
          <Link to = "/register">
            <button className='button' type='button'>Register</button>
          </Link>
          <Link to = "/login">
            <button className='button' type='button'>Login</button>
          </Link>
          <Link to = "/">
            <button className='button' type='button'>Logout</button>
          </Link>
          <Link to = "/solarwatch">
            <button className='button' type='button'>Get solar data</button>
          </Link>
        </ul>
      </nav>
      <Outlet />
    </div>
  )
}

export default App
