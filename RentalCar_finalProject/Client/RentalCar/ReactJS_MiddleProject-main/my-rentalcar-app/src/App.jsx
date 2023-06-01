import { useState } from 'react'
import ReactDOM from "react-dom/client";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import AllVehicles from "./components/AllVehicles";
import AboutUs from "./components/AboutUs";
import AddVehicle from "./components/AddVehicle";
import Login from "./components/Login";
import Layout from "./components/Layout";
import './App.css'

function App() {
  return (
    <div className="App">

     <BrowserRouter>
        <Routes>
           <Route path="/" element={<Layout />}>
            <Route index element={<AllVehicles />} />
            <Route path="AllVehicles" element={<AllVehicles />} />
            <Route path="AboutUs" element={<AboutUs />} />
            <Route path="AddVehicle" element={<AddVehicle />} />
            <Route path="Login" element={<Login />} />
            <Route path="*" element={<div>No Page</div>} />
          </Route>
        </Routes>
      </BrowserRouter> 

    </div>

  )

}

export default App
