import React, { Fragment, useContext, useState } from "react";
import { PlanDataContext } from '../../State/PlanDataState';
import { useNavigate } from 'react-router-dom';
import { FileUpload } from 'primereact/fileupload';
import { Link } from 'react-router-dom';
import { InputText } from 'primereact/inputtext';
import { Button } from 'primereact/button';
import { Card } from 'primereact/card';
import { set } from "date-fns";

function Registration() {
    const { planData, setPlanData } = useContext(PlanDataContext);
    const navigate = useNavigate();
    const [isRegistrated, setIsRegistrated] = useState(false);
    const [selectedImage, setSelectedImage] = useState(null);
    const [name, setName] = useState("");
    const [email, setEmail] = useState("");
    const [sex, setSex] = useState("man");
    const [age, setAge] = useState("");
    const [password, setPassword] = useState("");
    const [calory, setCalory] = useState(1500);
    const [treningPlanId , setTreningPlanId]=useState(1);
    //const [imagePreview, setImagePreview] = useState(null); // Define imagePreview state

    const handleSave = async () => {
        const userData = {
            userName: name,
            userEmail: email,
            password: password,
            sex: sex,
            age: age,
            restTime: 30,
            calorificValue: calory,
            treningPlanId:treningPlanId,
            roleId:1
        };
       
        console.log(JSON.stringify(userData));
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
                const responseData = await response.json()
                setPlanData(responseData);
                console.log(planData);
                setIsRegistrated(true)
                navigate('/account');

            } else {
                console.log(response.json());
                alert("Error while registering user");
            }

            if (isRegistrated) {
                navigate('/account')
            }
        } catch (error) {
            console.error("Error:", error);
        }
    };

    // Function to handle image selection
    // const handleImageChange = (e) => {
    //     const file = e.target.files[0];
    //     setSelectedImage(file);
    //     // Create a preview for the selected image
    //     const reader = new FileReader();
    //     reader.onload = (e) => {
    //         setImagePreview(e.target.result);
    //     };
    //     reader.readAsDataURL(file);
    // };
    const handleTreningPlan=(value)=>{
        setTreningPlanId(value)
    }
    const handleNameChange = (value) => {
        setName(value)
    }
    const handleEmailChange = (value) => {
        setEmail(value)
    }
    const handleAgeChange = (value) => {
        setAge(value)
    }
    const handlePasswordChange = (value) => {
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
        <div>
            <Card className='m-2 p-3 pt-0 '>
                <Fragment>

                    <h1>Registration</h1>

                    <InputText type="text" id="txtName" className="p-inputtext-sm m-2 ml-5 mr-5" placeholder="Your Name" onChange={(e) => handleNameChange(e.target.value)} /> <br />
                    <InputText type="text" id="txtEmail" className="p-inputtext-sm m-2 ml-5 mr-5" placeholder="Your Email" onChange={(e) => handleEmailChange(e.target.value)} /> <br />


                    <InputText type="text" id="txtAge" className="p-inputtext-sm m-2 ml-5 mr-5" placeholder="Your Age" onChange={(e) => handleAgeChange(e.target.value)} /> <br />

                    <div className="p-2" style={{ color: 'var(--surface-600)' }}>
                        <label> Your Sex </label>
                        <select id="selectCalory" onChange={(e) => handleSexSelect(e.target.selectedOptions[0].value)}>
                            <option value={"man"}>man</option>
                            <option value={"woman"}>woman</option>
                        </select> <br />
                    </div>
                    <div className="p-2" style={{ color: 'var(--surface-600)' }}>
                        <label> How Many trenings do you want per week </label>
                        <select id="selectSex" onChange={(e) => handleTreningPlan(e.target.selectedOptions[0].value)}>
                            <option value={1}>3</option>e71fa5c189f3e3c3b05fcb0137d11ea9df0f1c84d7f3af3741d1160ceb0c74f0
                            <option value={2}>4</option>
                           
                        </select> <br />
                    </div>
                    <div className="p-2" style={{ color: 'var(--surface-600)' }}>
                        <label> Calory per Day </label>
                        <select id="selectSex" onChange={(e) => handleCalorySelect(e.target.selectedOptions[0].value)}>
                            <option value={1500}>1500</option>
                            <option value={1800}>1800</option>
                            <option value={2000}>2000</option>
                            <option value={2200}>2200</option>
                        </select> <br />
                    </div>
                    <InputText type="password" id="txtPassword" className="p-inputtext-sm m-2 ml-5 mr-5" placeholder="Create a Password" onChange={(e) => handlePasswordChange(e.target.value)} /> <br />

                    <Button label='Sign up' className="m-3" onClick={handleSave} /> <br />

                    <Link to="/">
                        <Button label='Login' link />
                    </Link>

                </Fragment>
            </Card>
        </div>
    )
};

export default Registration;
