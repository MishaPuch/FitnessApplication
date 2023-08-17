import React, { useContext , useState} from 'react';

import Header from '../Header/Header';
import TaskBar from '../TaskBar/TaskBar';

import { UserContext } from '../../State/UserState';
import { InputText } from 'primereact/inputtext';

import './Settings.css'
import '../UserInfoPage/UserAccount.css'
import { Card } from 'primereact/card';

export default function Settings() {

    const {user ,setValue}=useContext(UserContext)
        
    const [name, setName] = useState("");
    const [email, setEmail] = useState("");
    const [sex, setSex] = useState("man");
    const [age, setAge] = useState("");
    const [password, setPassword] = useState("");
    const [calory, setCalory] = useState(1500 );

    const handleSave = async () => {
    const userData = {
    userName: name,
    userEmail: email,
    sex: sex,
    age: age,
    password: password,
    restTime: 30,
    calorificValue: calory  
    }; 
} 
    const handleNameChange =(value) =>{
        setName(value)
    }
    const handleEmailChange =(value) =>{
        setEmail(value)
    }      
    const handleAgeChange =(value) =>{
        setAge(value)
    }
    const handlePasswordChange =(value) =>{
        setPassword(value)
    }
    const handleCalorySelect = (value) => {
        console.log("calory value: " + value);
        setCalory(value);
    }     
    const handleSexSelect = (value) => {
    console.log("Sex is " + value);
    setSex(value)
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
            <Card style={{ width: '1200px' , height : '520px'  }}>
                <div className="grid-container">
                    <div className="grid-item">
                        <span className="p-float-label grid-item">
                            <p>Name</p>
                            <InputText id="username" value={user.userName} onChange={(e) => setValue(e.target.value)} />
                        </span>
                        <span className="p-float-label grid-item">
                            <p>Email</p>
                            <InputText id="useremail" value={user.userEmail} onChange={(e) => setValue(e.target.value)} />
                        </span>
                        <span className="p-float-label grid-item">
                            <p>Password</p>
                            <InputText id="password" value={user.password} onChange={(e) => setValue(e.target.value)} />
                        </span>
                    </div>
                    <div className="grid-item">
                        <span className="p-float-label grid-item">
                            <p>Gender</p>
                            <InputText id="sex" value={user.sex} onChange={(e) => setValue(e.target.value)} />
                        </span>
                        <span className="p-float-label grid-item">
                            <p>Age</p>
                            <InputText id="age" value={user.age} onChange={(e) => setValue(e.target.value)} />
                        </span>
                        <span className="p-float-label grid-item">
                            <p>Rest Time</p>
                            <InputText id="restTime" value={user.restTime} onChange={(e) => setValue(e.target.value)} />
                        </span>
                        <span className="p-float-label grid-item">
                            <p>Calory per day</p>
                            <InputText id="calorificValue" value={user.calorificValue} onChange={(e) => setValue(e.target.value)} />
                        </span>   
                    </div>
                </div>
            </Card>
        </div>


    </div>
    )

}