import '../App.css'
import React from 'react';

import { useState, useEffect } from "react";
import EditVehicle from './EditVehicle'
import Utilities from './Utilities'

var divStyle = {
  background: "#eee",
  display: "inline-block"

};

var h2Style = {
  textAlign: "center",
  marginTop: "-2vmin"
};

var carNames = Utilities.getAllCarNames();
var carModels = Utilities.getAllCarModels();
//Get local Storage
var getVehicles = () => {
  let saved = localStorage.getItem("rentalCarApp");
  if (saved == null) {
    localStorage.setItem("rentalCarApp", "[]");
    saved = "[]"
  }
  return JSON.parse(saved);
};

const AllVehicles = () => {
  const [editIndex, setEditIndex] = useState(-1)
  const [inputs, setInputs] = useState({});

  const allVehicles = getVehicles()

  var vehiclesToShow = allVehicles.filter((v) => (!inputs.carName || v.carName === inputs.carName)
    && (!inputs.model || v.model === inputs.model))

  const handleChange = (event) => {
    const name = event.target.name;
    const value = event.target.value;
    setInputs(values => ({ ...values, [name]: value }))
  }

  return <>
    <div className="filterContainer">
      <form>
        <table>
          <tbody>
            <tr>
              <th><p>Filter By:</p></th>
              <td><label> &nbsp; Vehicle Make </label></td>
              <td>
                <select
                  name="carName"
                  value={inputs.carName || ""}
                  onChange={handleChange} >
                  {carNames.map((carName, i) => <option value={carName} key={i}>{carName}</option>)}
                </select>
              </td>
              <td><label>  &nbsp;Model</label></td>
              <td>
                <select
                  name="model"
                  value={inputs.model || ""}
                  onChange={handleChange} >
                  {carModels.map((carModel, i) => <option value={carModel} key={i}>{carModel}</option>)}
                </select>
              </td>
              <td> &nbsp;
                <button onClick={() => setInputs({})}>Clear</button>
              </td>
            </tr>
          </tbody>
        </table>
      </form>
    </div>
    <div className="cardsContainer">
      {vehiclesToShow.map((car, i) => (
        <div className="card" key={i} onClick={() => setEditIndex(i)}>

          <div className="container">
            <h2 style={h2Style}>{car.carName} </h2>
            <h3 style={h2Style}>{car.model} </h3>
            <img src={car.vehicleImageSrc} alt={car.altImage}></img>

          </div>
        </div>))}

      <EditVehicle allVehicles={allVehicles} editIndex={editIndex} onClose={() => setEditIndex(-1)} />
    </div>;
  </>


};

export default AllVehicles


