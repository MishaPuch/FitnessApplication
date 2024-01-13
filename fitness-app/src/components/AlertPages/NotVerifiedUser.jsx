// NotVerifiedUser.js
import React, { useRef } from 'react';
import { Button } from 'primereact/button';
import { useNavigate, useParams } from 'react-router-dom';
import { InputText } from 'primereact/inputtext';

const NotVerifiedUser = () => {
    const { email } = useParams(); 

    const navigate = useNavigate();
    const verificationCodeRef = useRef();

    const handleLogout = () => {
        navigate('/');
    };

    async function handleVerifyClick() {
        const verificationCode = verificationCodeRef.current.value;
        debugger;
        try {
            const response = await fetch(`https://localhost:7060/api/Account/confirmationEmail/${email}/${verificationCode}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
            },
        });

        if (response.ok) {
            try {
                const responseData = await response.json();
                navigate('/');
            } catch (jsonError) {
                console.error('JSON parsing error:', jsonError);
                navigate('/');

            }
        } else {
            throw new Error('Error while fetching users');
        }
        } catch (error) {
            console.error('Error:', error);
            alert("maby u forgot to up the server")
        }
    };

    return (
        <div className="card">
            <h1>Verify Your Email</h1>
            <InputText
                type="text"
                className="p-inputtext-sm m-2 ml-5 mr-5"
                placeholder="Verification Code"
                ref={verificationCodeRef}
            />
            <Button label="Verify" onClick={handleVerifyClick} className="m-2" />
            <Button label="Logout" onClick={handleLogout} className="m-2" />
        </div>
    );
};

export default NotVerifiedUser;
