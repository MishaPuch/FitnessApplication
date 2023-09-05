import React, { useContext, useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { PlanDataContext } from '../../State/PlanDataState';
import { Link } from 'react-router-dom';


import { InputText } from 'primereact/inputtext';
import { Button } from 'primereact/button';
import { Card } from 'primereact/card';



const LoginForm = () => {
    const {planData , setPlanData } = useContext(PlanDataContext);

    const [isLogged, setIsLogged] = useState(false);

    const emailRef = React.createRef();
    const passwordRef = React.createRef();

        const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();

        const email = emailRef.current.value;
        const password = passwordRef.current.value;

        try {
            const response = await fetch(`https://localhost:7060/api/Account/user/${email}/${password}`, {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json',
                },
            });
                
            if (response.ok) {
                const responseData = await response.json();
                setPlanData(responseData);
                console.log(planData);
                setIsLogged(true);
            } else {
                alert('Error while fetching users');
            }
        } catch (error) {
            console.error('Error:', error);
        }
    };
useEffect(()=>{
    if (isLogged) {
    navigate('/account');
}},[isLogged]);
    

    return (
        <div>  
            <Card className='m-2 p-3 pt-0 '>          
                <form onSubmit={handleSubmit}>
                    <h1>Login Please</h1>
                    <InputText type="text" className="p-inputtext-sm m-2 ml-5 mr-5"  placeholder="Email" ref={emailRef}/> <br/>
                    <InputText type="password" className="p-inputtext-sm m-2" placeholder="Password" ref={passwordRef}/> <br/>
                    <Button label='Sign in' className="m-2" /> <br/>
                </form>
                <Link to="/registration">
                    <Button label='Registration' link/>
                </Link>
                
            </Card>
        </div>
    );
};

export default LoginForm;
    