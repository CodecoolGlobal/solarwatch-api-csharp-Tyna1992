import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import { Outlet, Link } from "react-router-dom";
import './App.css'

function App() {
  const [count, setCount] = useState(0)

  return (
    <div className = "navbar">
      <nav>
        <ul>
          <Link to = "/">
            <button type='button'>Home</button>
          </Link>
          <Link to = "/register">
            <button type='button'>Register</button>
          </Link>
          <Link to = "/login">
            <button type='button'>Login</button>
          </Link>
          <Link to = "/">
            <button type='button'>Logout</button>
          </Link>
          <Link to = "/solarwatch">
            <button type='button'>Get solar data</button>
          </Link>
        </ul>
      </nav>
      <Outlet />
    </div>
  )
}

export default App
