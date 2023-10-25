// WorkerPage.js
import React from 'react';
import { TabView, TabPanel } from 'primereact/tabview';
import WorkerMain from './WorkerMain/WorkerMain';
import { Button } from 'primereact/button';
import { useNavigate } from 'react-router-dom';
import ListMeal from './WorkingMeal/ListMeal'; 
import ListExercise from './WorkingExercise/WorkingExercise/ListExercise';

export default function WorkerPage() {
    const navigate = useNavigate();

    const handleLogout=()=>{
    navigate("/")
        
    }
    return (
        <div className="card">
            <TabView>
                <TabPanel header="Header I">
                    <p className="m-0">
                        <WorkerMain/>
                    </p>
                </TabPanel>
                <TabPanel header="Header II">
                    <p className="m-0">
                        <ListMeal/>
                    </p>
                </TabPanel>
                <TabPanel header="Header III">
                    <p className="m-0">
                        <ListExercise/>
                    </p>
                </TabPanel>
                <TabPanel header="Header VI">
                    <p className="m-0">

                        <Button onClick={handleLogout}>logout</Button>
                    </p>
                </TabPanel>
            </TabView>
        </div>
    )
}