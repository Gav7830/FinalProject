import { useContext, useState, useEffect } from "react";
import AuthContext from "../contexts/LoginContext/AuthContext";
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";
import { RentalCarWebAPI_URL } from "../utils/settings";
import axios from "axios";
import '../App.css'
import React from 'react';

function Login() {
    let [errorMessage, setErrorMessage] = useState("");
    let [enteredPassword, setEnteredPassword] = useState("");
    let [enteredUserName, setEnteredUserName] = useState("");
    let { isLoggedIn, login, logout } = useContext(AuthContext);

    function onLogin() {
        if (enteredUserName) {
            console.log(RentalCarWebAPI_URL + "/users/login")

            // let config = {
            //     headers: {
            //       header: Access-Control-Allow-Origin: *,
            //     }
            //   }
            // let config = {
            //     headers: {
            //       'Access-Control-Allow-Origin': *,
            //     }
            //   }
          axios
            .post(RentalCarWebAPI_URL + "/users/login", {
              userName: enteredUserName,
              password: enteredPassword,
            })
            .then((response) => {
              if (response.data) {
                console.log("Hi")
                console.log(response.data);
                login(response.data);
                navigate("/");
              } else throw Error("No response.data");
            })
            .catch((error) => {
              setErrorMessage("Error while trying to login ," + error.message);
            });
        }else{
          setErrorMessage('User name is mandatory');
        }
      }

    return (
        <Form className="loginForm">
          <Form.Group className="mb-3" controlId="formBasicEmail">
            <Form.Control
              type="text"
              placeholder="User Name"
              value={enteredUserName}
              onChange={(e) => setEnteredUserName(e.target.value)}
            />
          </Form.Group>
    
          <Form.Group className="mb-3" controlId="formBasicPassword">
            <Form.Control
              type="password"
              placeholder="Password"
              value={enteredPassword}
              onChange={(e) => setEnteredPassword(e.target.value)}
            />
          </Form.Group>
          {errorMessage ? (
            <div className="alert alert-danger">{errorMessage}</div>
          ) : (
            ""
          )}
          <Button variant="primary" type="button" onClick={onLogin}>
            Continue
          </Button>
        </Form>
      );
}

export default Login;