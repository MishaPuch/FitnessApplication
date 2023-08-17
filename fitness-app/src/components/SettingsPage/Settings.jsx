import React, { useContext , useState} from 'react';

import Header from '../Header/Header';
import TaskBar from '../TaskBar/TaskBar';

import { UserContext } from '../../State/UserState';
import { InputText } from 'primereact/inputtext';

import './Settings.css'
import '../UserInfoPage/UserAccount.css'
import { Card } from 'primereact/card';
import { Button } from 'primereact/button';

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
    console.log(userData);
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
            <Card style={{ width: '1240px' , height : '500px'  }}>
                <div className="grid-container">
                    <div className="">
                        <span className="p-float-label grid-item">
                            <p>Name</p>
                            <InputText id="username" value={user.userName} onChange={(e) => handleNameChange(e.target.value)} />
                        </span>
                        <span className="p-float-label grid-item">
                            <p>Email</p>
                            <InputText id="useremail" value={user.userEmail} onChange={(e) => handleEmailChange(e.target.value)} />
                        </span>
                        <span className="p-float-label grid-item">
                            <p>Password</p>
                            <InputText id="password" value={user.password} onChange={(e) => handlePasswordChange(e.target.value)} />
                        </span>
                        <span className="p-float-label grid-item">
                        <div className="p-2" >
                            <p> Calory per Day </p>
                            <select id="selectSex" onChange={(e) => handleCalorySelect(e.target.selectedOptions[0].value)}>
                                <option value={1500}>1500</option>
                                <option value={1800}>1800</option>
                                <option value={2000}>2000</option>
                                <option value={2200}>2200</option>
                            </select> <br/>
                        </div>
                        </span>
                        
                    </div>
                    <div className="grid-item">
                        <span className="p-float-label grid-item">
                            <p>Gender</p>
                            <InputText id="age" value={user.sex} onChange={(e) =>handleSexSelect(e.target.value)} />
                        </span>
                        <span className="p-float-label grid-item">
                            <p>Age</p>
                            <InputText id="age" value={user.age} onChange={(e) => handleAgeChange(e.target.value)} />
                        </span>
                        <span className="p-float-label grid-item">
                            <p>Rest Time (sec.)</p>
                            <InputText id="restTime" value={user.restTime} onChange={(e) => setTimeout(e.target.value)} />
                        </span>
                        <br/>
                        <br/>
                        <span>
                        <div className="p-float-label grid-item">
                            <Button label='submit' onClick={handleSave}  style={{ width: '207px'}}/>
                        </div>
                        </span>
                       
                    </div>
                    
                </div>
            </Card>
        </div>


    </div>
    )

}