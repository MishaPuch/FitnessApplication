import React, { useState, useEffect, useContext } from 'react';
import { DataScroller } from 'primereact/datascroller';
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';
import { Button } from 'primereact/button';
import useChangeUserApi from '../../../hooks/useChangeUserApi';
import { PlanDataContext } from '../../../State/PlanDataState';
import '../AdminMain.css'; 

export default function AdminMain() {
    const { planData } = useContext(PlanDataContext);
    const [users, setUsers] = useState([]);
    const changeData = useChangeUserApi();

    useEffect(() => {
        async function fetchData() {
            try {
                const response = await fetch(`https://localhost:7060/api/Account`, {
                    method: 'GET',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                });

                if (response.ok) {
                    const responseData = await response.json();
                    if (responseData.length > 0) {
                        setUsers(responseData);
                    }
                } else {
                    alert('Error while fetching users');
                }
            } catch (error) {
                console.error('Error:', error);
                alert('Server is not started');
            }
        }

        fetchData();
    }, []);

    const deleteUser = async (user) => {
        try {
            console.log(user);
            const response = await fetch(`https://localhost:7060/api/Account/DeleteUser/${user.id}`, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                },
            });

            if (response.ok) {
                const updatedUsers = users.filter((currentUser) => currentUser.userId !== user.userId);
                setUsers(updatedUsers);
                alert('User deleted successfully');
            } else {
                alert('Error while deleting user');
            }
        } catch (error) {
            console.error('Error:', error);
            alert('Server is not started');
        }
    };

    const grantRole = (data, roleId) => {
        data.roleId = roleId;
        changeData(data);
    };

    const renderButtons = (rowData) => (
        <div className="button-container">
            <Button label="Grant Worker" className="p-button-secondary" onClick={() => grantRole(rowData, 2)} raised />
            <Button label="Grant Admin" className="p-button" onClick={() => grantRole(rowData, 3)} />
            <Button label="Grant User" className="p-button-success" onClick={() => grantRole(rowData, 1)} raised />
            <Button label="Delete User" className="p-button-danger" onClick={() => deleteUser(rowData)} raised />
        </div>
    );

    const renderDisabledButtons = () => (
        <div className="button-container">
            <Button label="Grant Worker" className="p-button-secondary" text raised disabled />
            <Button label="Grant Admin" className="p-button" disabled />
            <Button label="Grant User" className="p-button-success" raised disabled />
        </div>
    );

    const renderRoleBadge = (roleId) => (
        <div className={`role-badge ${roleId === 1 ? 'user' : (roleId === 2 ? 'worker' : 'admin')}`}>
            {roleId === 1 ? 'U' : (roleId === 2 ? 'W' : 'A')}
        </div>
    );

    return (
        <div className="container">
            <DataScroller value={users} itemTemplate={(data) => (
                <div className="user-card">
                    <DataTable value={[data]} tableStyle={{ width: '60rem', height:'5rem' }}>
                        {renderRoleBadge(data.roleId)}
                        <Column key="userName" field="userName" header="Name" style={{ width: '20%' }} body={(rowData) => rowData.userName} />
                        <Column field="image" header="Image" style={{ width: '10%' }} body={(rowData) => (
                            <img src={`https://fitnessapp.blob.core.windows.net/avatars/${rowData.avatar}`} alt={rowData.avatar} className="user-avatar" />
                        )} />
                        <Column field="calorificValue" header="Price" style={{ width: '10%' }} body={(rowData) => rowData.calorificValue.toLocaleString('en-US', { style: 'currency', currency: 'USD' })} />
                        <Column field="treningPlanId" header="Plan" style={{ width: '10%' }} />
                        <Column field="dateOFLastPayment" header="Days Left" style={{ width: '40%' }} body={() => (
                            planData[0].user.userEmail !== data.userEmail ? renderButtons(data) : renderDisabledButtons()
                        )} />
                    </DataTable>
                </div>
            )} rows={users.length} inline scrollHeight="100vh" header="Scroll Down to Load More" />
        </div>
    );
}
