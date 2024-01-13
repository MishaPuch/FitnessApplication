import React from 'react';
import { useNavigate } from 'react-router-dom';
import { Link } from 'react-router-dom';

import { InputText } from 'primereact/inputtext';
import { Button } from 'primereact/button';
import { Card } from 'primereact/card';

const ForgetPassword = () => {
    
    
    const emailRef = React.createRef();
    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();
        const email = emailRef.current.value;

        try {
            const response = await fetch(`https://localhost:7060/api/Account/sendPasswordToEmail/${email}`, {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json',
                },
            });
        
            if (response.ok) {
                console.log("email were sent");
            } else {
                throw new Error('Error while fetching users');  
            }          
        } catch (error) {
            console.error('Error:', error);
            alert("maby u pass wrong email");
        }
    };

    return (
        <div>
            <Card className='m-2 p-3 pt-0 '>
                <form onSubmit={handleSubmit}>
                    <h1>Forget Password</h1>
                    <InputText type="text" className="p-inputtext-sm m-2 ml-5 mr-5" placeholder="Email" ref={emailRef} /> <br />
                    <Button label='Send email' className="m-2" /> <br />
                </form>
                <Link to="/">
                    <Button label='Login' link />
                </Link>

            </Card>
        </div>
    );
};

export default ForgetPassword;
