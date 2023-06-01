import React from 'react'
import ReactDom from 'react-dom'
import { useState } from "react";
import UpdateFormForVehicle from "./UpdateFormForVehicle";

const MODAL_STYLES = {
    position: 'fixed',
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    backgroundColor: '#FFF',
    padding: '5vmin',
    borderRadius: '2vmin',
    fontSize: '2.5vmin',
    zIndex: 1000
}

const OVERLAY_STYLES = {
    position: 'fixed',
    top: 0,
    left: 0,
    right: 0,
    bottom: 0,
    backgroundColor: 'rgba(0, 0, 0, .7)',
    zIndex: 1000
}

export default function EditVehicle({ allVehicles, editIndex, onClose }) {
    if (editIndex == -1) return null

    const [inputs, setInputs] = useState(allVehicles[editIndex]);
    const [file, setFile] = useState();



    return ReactDom.createPortal(
        <>
            <div style={OVERLAY_STYLES} />
            <div style={MODAL_STYLES}>
                <div style={{ marginBottom: '1vmin' }}>
                    <UpdateFormForVehicle mode={"edit"} args={{ allVehicles, editIndex, onClose }} />
                </div>
            </div>
        </>,
        document.getElementById('portal')
    )
}