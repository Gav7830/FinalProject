import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import Utilities from './Utilities';


var carNames = Utilities.getAllCarNames();
var carModels = Utilities.getAllCarModels();

const UpdateFormForVehicle = ({ mode, args }) => {
    let buttons, title, startState, onSubmit;
    //create localStorage
    var addCar = (e) => {
        e.preventDefault();
        const saved = localStorage.getItem("rentalCarApp");
        let cars = JSON.parse(saved);
        cars.push(inputs);
        localStorage.setItem("rentalCarApp", JSON.stringify(cars));
        setInputs({})
    }

    if (mode === "add") { //add mode
        const navigateTo = useNavigate();
        const home = () => {
            navigateTo("/AllVehicles")
        }
        title = <h1>ADD NEW VEHICLE</h1>;
        buttons = <div><input type="submit" id="addButton" value="+" /><button type="button" id="closeButton" onClick={home}><b>&times;</b></button></div>;
        startState = {};
        onSubmit = addCar;
    } else {  //edit mode
        title = <h1>Edit Vehicle Card</h1>;
        let { allVehicles, editIndex, onClose } = args;
        var onDelete = () => {
            const saved = localStorage.getItem("rentalCarApp");
            let cars = JSON.parse(saved);
            cars = cars.filter((car, i) => i != editIndex)
            localStorage.setItem("rentalCarApp", JSON.stringify(cars));
            onClose();
        }
        buttons =
            <div>
                <input type="image" id="saveButton" src={Utilities.ImagesUrl + 'save.png'} alt="Submit" />
                <img src={Utilities.ImagesUrl + 'delete.png'} id="deleteButton" onClick={onDelete}></img>
                <img src={Utilities.ImagesUrl + 'cancel.png'} id="cancelButton" onClick={onClose}></img>
            </div>
        startState = allVehicles[editIndex];
        onSubmit = (e) => {
            e.preventDefault();
            const saved = localStorage.getItem("rentalCarApp");
            let cars = JSON.parse(saved);
            cars[editIndex] = inputs;
            localStorage.setItem("rentalCarApp", JSON.stringify(cars));
            onClose();
        }
    }

    const [inputs, setInputs] = useState(startState);
    const handleChange = (event) => {
        const name = event.target.name;
        const value = event.target.value;
        setInputs(values => ({ ...values, [name]: value }))

    }

    return (
        <div>
            {title}
            <form onSubmit={onSubmit}>
                <table id="updateFormTable">
                    <tbody>
                        <tr>
                            <td><label>Vehicle Make </label></td>
                            <td>
                                <select
                                    name="carName"
                                    required
                                    value={inputs.carName || ""}
                                    onChange={handleChange}>
                                    {carNames.map((carName, i) => <option value={carName} key={i}>{carName}</option>)}
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td><label>Model </label></td>
                            <td>
                                <select
                                    name="model"
                                    required
                                    value={inputs.model || ""}
                                    onChange={handleChange}>
                                    {carModels.map((carModel, i) => <option value={carModel} key={i}>{carModel}</option>)}
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td><label>Year </label></td>
                            <td>
                                <input
                                    type="number"
                                    min="2018"
                                    max="2022"
                                    name="year"
                                    required
                                    value={inputs.year || ""}
                                    onChange={handleChange}
                                />
                            </td>
                        </tr>
                        <tr>
                            <td><label>Number of doors </label></td>
                            <td>
                                <select
                                    name="numberOfdoors"
                                    required
                                    value={inputs.numberOfdoors || ""}
                                    onChange={handleChange}>
                                    <option value=""></option>
                                    <option value="2">2</option>
                                    <option value="3">3</option>
                                    <option value="4">4</option>
                                    <option value="5">5</option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td><label>Transmission And Drive </label></td>
                            <td>
                                <select
                                    name="transmissionAndDrive"
                                    required
                                    value={inputs.transmissionAndDrive || ""}
                                    onChange={handleChange}>
                                    <option value=""></option>
                                    <option value="Manual, 2WD">Manual, 2WD</option>
                                    <option value="Auto, 2WD">Auto, 2WD</option>
                                    <option value="Auto, 4WD">Auto, 4WD</option>
                                    <option value="Auto, AWD">Auto, AWD</option>
                                    <option value="Manual, 4WD">Manual, 4WD</option>
                                    <option value="Manual, AWD">Manual, AWD</option>
                                </select>

                            </td>
                        </tr>
                        <tr>
                            <td><label>Fuel And AC </label></td>
                            <td>
                                <select
                                    name="fuelAndAC"
                                    required
                                    value={inputs.fuelAndAC || ""}
                                    onChange={handleChange}>
                                    <option value=""></option>
                                    <option value="Ethanol, no A/C">Ethanol, no A/C</option>
                                    <option value="Ethanol, A/C">Ethanol, A/C</option>
                                    <option value="Electric, A/C">Electric, A/C</option>
                                    <option value="Electric, no A/C">Electric, no A/C</option>
                                    <option value="Diesel, no A/C">Diesel, no A/C</option>
                                    <option value="Diesel, A/C">Diesel, A/C</option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td><label>Image </label></td>
                            <td>
                                <select
                                    name="vehicleImageSrc"
                                    required
                                    value={inputs.vehicleImageSrc || ""}
                                    onChange={handleChange}>
                                    <option value=""></option>

                                    <option value={Utilities.ImagesUrl + 'Audi.jpg'}>BMW</option>
                                    <option value={Utilities.ImagesUrl + 'Mazda.jpg'}>Audi</option>
                                    <option value={Utilities.ImagesUrl + 'Porsche.jpg'}>Porsche</option>
                                    <option value={Utilities.ImagesUrl + 'Toyota.jpg'}>Toyota</option>
                                    <option value={Utilities.ImagesUrl + 'Tesla.jpg'}>Tesla</option>
                                    <option value={Utilities.ImagesUrl + 'Mercedes.jpg'}>Mercedes</option>



                                </select>
                            </td>
                        </tr>
                    </tbody>
                </table>

                {buttons}

            </form>


        </div>

    );
}

export default UpdateFormForVehicle