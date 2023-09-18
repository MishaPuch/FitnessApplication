import React, { useContext, useEffect, useState } from 'react';
import { PlanDataContext } from '../../State/PlanDataState';
import { InputText } from 'primereact/inputtext';
import { Card } from 'primereact/card';
import { Button } from 'primereact/button';

import Header from '../Header/Header';
import TaskBar from '../TaskBar/TaskBar';

import './Settings.css'
import '../UserInfoPage/UserAccount.css'
import { useNavigate } from 'react-router-dom';

export default function Settings() {
    const { planData } = useContext(PlanDataContext);

    const [name, setName] = useState(planData[0]?.user?.userName || "");
    const [email] = useState(planData[0]?.user?.userEmail || "");
    const [sex] = useState(planData[0]?.user?.sex || "");
    const [age, setAge] = useState(planData[0]?.user?.age || "");
    const [password, setPassword] = useState(planData[0]?.user?.password || "");
    const [calory, setCalory] = useState(planData[0]?.user?.calorificValue || "");
    const [restTime, setRestTime] = useState(planData[0]?.user?.restTime || 0);
    const navigate = useNavigate();
 
    useEffect(() => {
        if (planData.length === 0) {
            navigate('/');
        }
    }, []);

    const handleSave = async () => {
        const userData = {
            userName: name,
            userEmail: email,
            sex: sex,
            age: age,
            password: password,
            restTime: restTime,
            calorificValue: calory,
        };
        console.log(userData);
        try {
            const response = await fetch("https://localhost:7060/api/Account/changeData", {
              method: "PUT",
              headers: {
                "Content-Type": "application/json",
              },
              body: JSON.stringify(userData),
            });
          
            if (response.ok) {
              console.log("Users data changed successful");
              alert("To see your changes , you have to login👍");
              
            } else {
              console.log(response);
              alert("Error while changing data");
            }
          
        } catch (error) {
        console.error("Error:", error);
        }
    }

    const handleNameChange = (value) => {
        setName(value);
    }

    // const handleEmailChange = (value) => {
    //     setEmail(value);
    // }

    const handleAgeChange = (value) => {
        // Ensure that the input is a positive number
        if (!isNaN(value) && value >= 0) {
            setAge(value);
        }
    }

    const handlePasswordChange = (value) => {
        setPassword(value);
    }

    const handleCalorySelect = (value) => {
        console.log("calory value: " + value);
        setCalory(value);
    }

    // const handleSexSelect = (value) => {
    //     console.log("Sex is " + value);
    //     setSex(value);
    // }

    const handleRestTimeChange = (value) => {
        // Ensure that the input is a positive number
        if (!isNaN(value) && value >= 0) {
            setRestTime(value);
        }
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
                    <div className="grid-container">
                        <div className="">
                            <span className="p-float-label grid-item">
                                <p>Name</p>
                                <InputText id="username" value={name} onChange={(e) => handleNameChange(e.target.value)} />
                            </span>
                            <span className="p-float-label grid-item">
                                <p>Email</p>
                                <InputText id="useremail" value={email} className="p-invalid" />
                            </span>
                            <span className="p-float-label grid-item">
                                <p>Password</p>
                                <InputText id="password" defaultValue={password} onChange={(e) => handlePasswordChange(e.target.value)} />
                            </span>
                            <span className="p-float-label grid-item">
                                <div className="p-2" >
                                    <p> Calory per Day </p>
                                    <select id="selectCalory" value={calory} onChange={(e) => handleCalorySelect(e.target.value)}>
                                        <option value={1500}>1500</option>
                                        <option value={1800}>1800</option>
                                        <option value={2000}>2000</option>
                                        <option value={2200}>2200</option>
                                    </select> <br />
                                </div>
                            </span>
                        </div>
                        <div className="grid-item">
                            <span className="p-float-label grid-item">
                                <p>Gender</p>
                                <InputText id="sex" value={sex} className="p-invalid" />
                            </span>
                            <span className="p-float-label grid-item">
                                <p>Age</p>
                                <InputText id="age" type="number" value={age} onChange={(e) => handleAgeChange(e.target.value)} />
                            </span>
                            <span className="p-float-label grid-item">
                                <p>Rest Time (sec.)</p>
                                <InputText id="restTime" type="number" value={restTime} onChange={(e) => handleRestTimeChange(e.target.value)} />
                            </span>
                            <br />
                            <br />
                            <span>
                                <div className="p-float-label grid-item">
                                    <Button label='Submit' onClick={handleSave} style={{ width: '207px' }} />
                                </div>
                            </span>
                        </div>
                    </div>
                </Card>
            </div>
        </div>
    );
}
