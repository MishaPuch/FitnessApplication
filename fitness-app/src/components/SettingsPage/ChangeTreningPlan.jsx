import React, { useContext, useEffect, useState } from 'react';
import { PlanDataContext } from '../../State/PlanDataState';
import { Card } from 'primereact/card';
import { Button } from 'primereact/button';
import Header from '../Header/Header';
import TaskBar from '../TaskBar/TaskBar';
import './Settings.css'
import '../UserInfoPage/UserAccount.css'
import { useNavigate } from 'react-router-dom';
import useChangeUserApi from '../../hooks/useChangeUserApi';
import { Dropdown } from 'primereact/dropdown';
import { RadioButton } from 'primereact/radiobutton';


export default function ChangingTreningPlan() {
    const { planData } = useContext(PlanDataContext);
    const changeUser=useChangeUserApi();

    const [selectedPlan, setSelectedPlan] = useState(null);
    const [name, setName] = useState(planData[0]?.user?.userName || "");
    const [password, setPassword] = useState(planData[0]?.user?.password || "");
    const plans = ["Push Pull Legs", "Upper  Lower"]
    const navigate = useNavigate();
 
    useEffect(() => {
        if (planData.length === 0) {
            navigate('/');
        }
    }, []);

    
    const handleSave = async () => {
        const userData = {
            userName: name,
            password: password,
       
        };
        try {
            changeUser(userData);
        } catch (error) {
        console.error("Error:", error);
        }
    }

    const handleNameChange = (value) => {
        setName(value);
    }

    const handlePasswordChange = (value) => {
        setPassword(value);
    }    
    
    return (
        <div className="container">
            <div className="avatar">
                <Header />
            </div>
            <div className="container">
                <div className="taskbar">
                    <TaskBar />
                </div>
            </div>
            <div className="setting-card">
                <Card style={{ width: '1240px', height: '500px' }}>
                    <div className="">
                        <br/>
                        <br/>
                        <Dropdown value={selectedPlan} onChange={(e) => setSelectedPlan(e.value)} options={plans} optionLabel="name" 
                                editable placeholder="Select a City" className="w-full md:w-14rem" />
                        <span>
                        <br/> 
                        <br/> 

                            <div >
                                <Button label='Change trening plan' severity="help" style={{ width: '207px' }} />
                            </div>                                
                        </span>
                    </div>
                </Card>
            </div>
        </div>
    );
}
