// WorkerPage.js
import React from 'react';
import { TabView, TabPanel } from 'primereact/tabview';
import { Button } from 'primereact/button';
import { useNavigate } from 'react-router-dom';

export default function NotVerifiedUser() {
    const navigate = useNavigate();

    const handleLogout=()=>{
    navigate("/")
        
    }
    return (
        <div className="card">
            <h1>Verify your email</h1>
        </div>
    )
}