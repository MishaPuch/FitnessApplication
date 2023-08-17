import React, { Fragment  , useContext, useState} from "react";
import { UserContext } from '../../State/UserState';
import { useNavigate } from 'react-router-dom';

import { Link } from 'react-router-dom';

import { InputText } from 'primereact/inputtext';
import { Button } from 'primereact/button';
import { Card } from 'primereact/card';
// import { Dropdown } from 'primereact/dropdown';


function Registration(){

const { setUser } = useContext(UserContext);
const navigate = useNavigate();
const [isRegistrated , setIsRegistrated] = useState(false);

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

try {
  const response = await fetch("https://localhost:7060/api/Account/create-user", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(userData),
  });

  if (response.ok) {
    console.log("User registration successful!");
    setUser(userData);
    setIsRegistrated(true)
    navigate('/account');

  } else {
    alert("Error while registering user");
  }

  if(isRegistrated){
    navigate('/account')
  }
} catch (error) {
  console.error("Error:", error);
}
};    


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

return(
  <div>
    <Card className='m-2 p-3 pt-0 '>
      <Fragment>

        <h1>Registration</h1>
        <InputText type="text" id="txtName" className="p-inputtext-sm m-2 ml-5 mr-5"  placeholder="How i can call you" onChange={(e)=> handleNameChange(e.target.value)}/> <br/>
        <InputText type="text" id="txtEmail" className="p-inputtext-sm m-2 ml-5 mr-5"  placeholder="Your Email" onChange={(e)=> handleEmailChange(e.target.value)}/> <br/>
        <InputText type="text" id="txtAge" className="p-inputtext-sm m-2 ml-5 mr-5"  placeholder="Your Age" onChange={(e)=> handleAgeChange(e.target.value)}/> <br/>
        
        
        <div className="p-2" style={{ color: 'var(--surface-600)' }}>
            <label> Your Sex </label>
            <select id="selectCalory" onChange={(e) => handleSexSelect(e.target.selectedOptions[0].value)}>
                <option value={"man"}>man</option>
                <option value={"woman"}>woman</option>
            </select> <br/>
        </div>

        <div className="p-2" style={{ color: 'var(--surface-600)' }}>
            <label> Calory per Day </label>
            <select id="selectSex" onChange={(e) => handleCalorySelect(e.target.selectedOptions[0].value)}>
                <option value={1500}>1500</option>
                <option value={1800}>1800</option>
                <option value={2000}>2000</option>
                <option value={2200}>2200</option>
            </select> <br/>
        </div>          
        <InputText type="password" id="txtPassword" className="p-inputtext-sm m-2 ml-5 mr-5"  placeholder="Create a Password" onChange={(e)=> handlePasswordChange(e.target.value)}/> <br/>
        
        <Button label='Sign up' className="m-3" onClick={handleSave}/> <br/>

        <Link to="/">
          <Button label='Login' link/>
        </Link>
          
      </Fragment>
    </Card>  
  </div>
)
};


export default Registration