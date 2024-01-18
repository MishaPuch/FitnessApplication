import React, { useState } from 'react';
import { InputText } from 'primereact/inputtext';
import { Card } from 'primereact/card';
import { Button } from 'primereact/button';
import { useLocation, useNavigate } from 'react-router-dom';

import './Settings.css';
import useChangeUserApi from '../../../hooks/useChangeUserApi';

export default function WorkerSettings() {
  const changeUser = useChangeUserApi();
  const navigate = useNavigate();
  const location = useLocation();
  const userData = location.state.userData;

  const [id, setId] = useState(userData.id);
  const [name, setName] = useState(userData.userName);
  const [email, setEmail] = useState(userData.userEmail);
  const [sex, setSex] = useState(userData.sex);
  const [age, setAge] = useState(userData.age);
  const [calory, setCalory] = useState(userData.calorificValue);
  const [restTime, setRestTime] = useState(userData.restTime);
  const [password, setPassword] = useState(userData.password);
  const [treningPlanId, setTreningPlanId] = useState(userData.treningPlanId);
  const [roleId, setRoleId] = useState(userData.roleId); 
  const isEmailConfirmed=userData.isEmailConfirmed;

  const handle = () => {
    navigate("/WorkerPage");
  };

  const handleSave = async () => {
    const userData = {
      id: id,
      userName: name,
      userEmail: email,
      sex: sex,
      age: age,
      password: password,
      isEmailConfirmed:isEmailConfirmed,
      restTime: restTime,
      calorificValue: calory,
      treningPlanId: treningPlanId,
      roleId: roleId,
    };

    try {
      await changeUser(userData);
      console.log(userData);
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
  const handleCalorySelect = (value) => {
    console.log("calory value: " + value);
    setCalory(value);
  };
  const handleRestTimeChange = (value) => {
    if (!isNaN(value) && value >= 0) {
      setRestTime(value);
    }
  };
  const handleEmailChange = (value) => {
    setEmail(value);
  };
  const handleSexChange = (value) => {
    setSex(value);
  };

  return (
    <div className="container">
      <Button onClick={handle}>back to the list</Button>
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
                <InputText id="useremail" value={email} onChange={(e) => handleEmailChange(e.target.value)}  />
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
                <InputText id="sex" value={sex} onChange={(e) => handleSexChange(e.target.value)} />
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
