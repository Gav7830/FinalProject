import { Outlet, Link } from "react-router-dom";
import Utilities from "./Utilities";

const Layout = () => {
    return (
        <>
            <div className="topContainer">
                <div className="logo">
                <img src={Utilities.ImagesUrl + 'logo.png'}/>
           
             
                    <h1>I&G Rental Car</h1>
                </div>
            </div>
            <div className="topnav">
                <Link to="/AllVehicles">All Vehicles</Link>
                <Link to="/AddVehicle">Add Vehicle</Link>
                <Link to="/AboutUs">About Us</Link>
                <Link to="/Login" className="loginButton">Log in</Link>

            </div>

            <Outlet />
        </>
    )
};

export default Layout;