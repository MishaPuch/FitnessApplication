// WorkerPage.js
import React from 'react';
import { TabView, TabPanel } from 'primereact/tabview';
import AdminMain from './AdminMain/AdminMain';
import { Button } from 'primereact/button';
import { useNavigate } from 'react-router-dom';

export default function AdminPage() {
    const navigate = useNavigate();

    const handleLogout=()=>{
    navigate("/")
        
    }
    return (
        <div className="card">
            <TabView>
                <TabPanel header="Header I">
                    <p className="m-0">
                        <AdminMain/>
                    </p>
                </TabPanel>
               
                <TabPanel header="Header III">
                    <p className="m-0">
                        <Button onClick={handleLogout}>logout</Button>
                    </p>
                </TabPanel>
            </TabView>
        </div>
    )
}