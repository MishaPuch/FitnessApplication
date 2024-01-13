import React, { useState, useEffect, useContext } from 'react';
import { DataScroller } from 'primereact/datascroller';
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';
import { Button } from 'primereact/button';
import useChangeUserApi from '../../../hooks/useChangeUserApi';
import { PlanDataContext } from '../../../State/PlanDataState';
import '../AdminMain.css'; 

export default function ChangingPlanForm() {
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

    const renderRoleBadge = (roleId) => (
        <div className={`role-badge ${roleId === 1 ? 'user' : (roleId === 2 ? 'worker' : 'admin')}`}>
            {roleId === 1 ? 'U' : (roleId === 2 ? 'W' : 'A')}
        </div>
    );

    return (
        <div className="container">
    <DataScroller value={users} rows={users.length} inline scrollHeight="100vh" header="Scroll Down to Load More" itemTemplate={(data) => (
        <div className="user-card">
            <DataTable value={[data]} tableStyle={{ width: '60rem', height:'5rem' }}>
                {renderRoleBadge(data.roleId)}
                <Column key="userName" field="userName" header="Name" style={{ width: '20%' }} body={(rowData) => rowData.userName} />
                <Column field="image" header="Image" style={{ width: '10%' }} body={(rowData) => (
                    <img src={`https://fitnessapp.blob.core.windows.net/avatars/${rowData.avatar}`} alt={rowData.avatar} className="user-avatar" />
                )} />
                <Column field="Email" header="Email" style={{ width: '10%' }} body={(rowData) =>rowData.userEmail} />
                <Column field="treningPlanId" header="Plan" style={{ width: '10%' }} />
                <Column style={{ width: '10%' }} body={() => (
                    <div className="button-container">
                        <Button label="Allow" className="p-button-success" onClick={() => grantRole(data, 1)} raised />
                        <Button label="Deny" className="p-button-danger" onClick={() => deleteUser(data)} raised />
                    </div>
                )} />                
            </DataTable>
        </div>
    )} />
</div>

    );
}
