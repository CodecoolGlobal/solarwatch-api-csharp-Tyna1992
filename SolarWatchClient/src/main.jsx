import React from 'react'
import ReactDOM from 'react-dom/client'
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import App from './App.jsx'
import Home from './Pages/Home.jsx'
import Registration from './Pages/Registration.jsx'
import Login from './Pages/Login.jsx'
import SolarWatch from './Pages/SolarData.jsx'
import AllData from './Pages/All.jsx';
import './index.css'



const router = createBrowserRouter([
  {
    path: "/",
    element: <App/>,
    children:[
      {
        path: "/",
        element: <Home/>
      },
      {
        path: "/register",
        element: <Registration/>
      },
      {
        path: "/login",
        element: <Login/>
      },
      {
        path: "/solarwatch",
        element: <SolarWatch/>
      },
      {
        path: "/all",
        element: <AllData/>
      
      }


    ]
  }
]);

ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <RouterProvider router = {router}/>
  </React.StrictMode>,
)
