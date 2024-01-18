import React, { useContext, useEffect, useState } from 'react';
import { PlanDataContext } from '../../State/PlanDataState';
import { InputText } from 'primereact/inputtext';
import { Card } from 'primereact/card';
import { Button } from 'primereact/button';
import { RadioButton } from 'primereact/radiobutton';
import Header from '../Header/Header';
import TaskBar from '../TaskBar/TaskBar';
import { useNavigate } from 'react-router-dom';
import useChangeUserApi from '../../hooks/useChangeUserApi';
import './Settings.css';
import '../UserInfoPage/UserAccount.css';

export default function Settings() {
    const { planData } = useContext(PlanDataContext);
    const changeUser = useChangeUserApi();

    const [selectedFile, setSelectedFile] = useState(null);

    const [name, setName] = useState(planData[0]?.user?.userName || "");
    const [email] = useState(planData[0]?.user?.userEmail || "");
    const [sex] = useState(planData[0]?.user?.sex || "");
    const [age, setAge] = useState(planData[0]?.user?.age || "");
    const [password, setPassword] = useState(planData[0]?.user?.password || "");
    const [calory, setCalory] = useState(planData[0]?.user?.calorificValue || "");
    const [restTime, setRestTime] = useState(planData[0]?.user?.restTime || 0);
    const [treningPlan, setTreningPlan] = useState(planData[0]?.user?.treningPlan.treningPlanValue || null);
    const navigate = useNavigate();

    useEffect(() => {
        if (planData.length === 0) {
            navigate('/');
        }
    }, [planData, navigate]);
    

    const handleSave = async () => {
        const userData = {
            userName: name,
            userEmail: email,
            sex: sex,
            age: age,
            password: password,
            restTime: restTime,
            calorificValue: calory,
            treningPlanId: treningPlan,
        };
        try {
            changeUser(userData);
        } catch (error) {
            console.error("Error:", error);
        }
    };

    const handleNameChange = (value) => {
        setName(value);
    };

    const handleAgeChange = (value) => {
        if (!isNaN(value) && value >= 0) {
            setAge(value);
        }
    };

    const handlePasswordChange = (value) => {
        setPassword(value);
    };

    const handleCalorySelect = (value) => {
        setCalory(value);
    };

    const handleRestTimeChange = (value) => {
        if (!isNaN(value) && value >= 0) {
            setRestTime(value);
        }
    };

    const handleFileChange = (event) => {
        const file = event.target.files[0];
        setSelectedFile(file);

        if (file) {
            const formData = new FormData();
            formData.append('file', file);

            try {
                fetch(`https://localhost:7060/api/Images/PostTheAvatarFoto/${planData[0].user.id}`, {
                    method: 'POST',
                    body: formData,
                })
                    .then((response) => response.arrayBuffer())
                    .then((data) => {})
                    .catch((error) => {
                        console.error('Ошибка:', error);
                    });
            } catch (error) {
                console.error('Ошибка:', error);
            }
        } else {
            console.error("Файл не выбран.");
        }
    };

    useEffect(() => {
        console.log(treningPlan);
    }, [treningPlan]);  
    
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
                                <div>
                                <input type="file" accept="image/*" onChange={handleFileChange} />
                                {selectedFile && (
                                    <div>
                                    <p>Selected file: {selectedFile.name}</p>
                                    <img src={URL.createObjectURL(selectedFile)} alt="Selected" />
                                    </div>
                                )}
                                </div>          
                            </span>
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
                                <div className="flex flex-wrap gap-3">
                                    <div className="flex align-items-center">
                                        <RadioButton
                                            inputId="ingredient1"
                                            name="treningPlan"
                                            value="PushPullLegs"
                                            onChange={() => setTreningPlan(1)}
                                            checked={treningPlan === "PushPullLegs"}
                                        />
                                        <label htmlFor="ingredient1" className="ml-2">
                                            PushPullLegs
                                        </label>
                                    </div>
                                    <div className="flex align-items-center">
                                        <RadioButton
                                            inputId="ingredient2"
                                            name="treningPlan"
                                            value="UpperLower"
                                            onChange={() => setTreningPlan(2)}
                                            checked={treningPlan === "UpperLower"}
                                        />
                                        <label htmlFor="ingredient2" className="ml-2">
                                            UpperLower
                                        </label>
                                    </div>
                                    <Button label="Submit" onClick={handleSave} style={{ width: '207px' }} />
                                </div>
                            </span>     
                        </div>
                    </div>
                </Card>
            </div>
        </div>
    );
}
