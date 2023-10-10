import React, { useState, useEffect } from 'react';
import { DataScroller } from 'primereact/datascroller';
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';
import { Button } from 'primereact/button';
import { useNavigate } from 'react-router-dom';
import useChangeUserApi from '../../../hooks/useChangeUserApi';

export default function AdminMain(){
    
    const [users, setUsers] = useState([]);
    const navigate = useNavigate();
    const changeData=useChangeUserApi()

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

    const itemTemplate = (data) => {
        const formatCurrency = (value) => {
            return value.toLocaleString('en-US', { style: 'currency', currency: 'USD' });
        };

        const imageBodyTemplate = (data) => {
            return <img src={`https://primefaces.org/cdn/primereact/images/product/${data.image}`} alt={data.image} className="w-6rem shadow-2 border-round" />;
        };

        const nameBodyTemplate = (data) => {
            return formatCurrency(data.userName);
        };

        const emailBodyTemplate = (data) => {
            return data.userEmail.toString();
        };

        const dateOFLastPaymentBodyTemplate = (data) => {
            return data.dateOFLastPayment.toString();
        };

        const handleChangeUser = (data) => {
            data.roleId=1;
            changeData(data);
        };
        const handleChangeWorker = (data) => {
            data.roleId=2;
            changeData(data);
        }; 
        const handleChangeAdmin = (data) => {
            data.roleId=3;
            changeData(data)
        };

        return (
            <div className="card">
                <DataTable value={[data]} tableStyle={{ minWidth: '60rem' }}>
                    <Column field="userName" header="Name" body={nameBodyTemplate}></Column>
                    <Column header="Image" body={imageBodyTemplate}></Column>
                    <Column field="calorificValue" header="Price" body={emailBodyTemplate}></Column>
                    <Column field="treningPlanId" header="Plan"></Column>
                    <Column field="dateOFLastPayment" header="Days Left" body={dateOFLastPaymentBodyTemplate}></Column>
                    <Column body={(rowData) => (
                        <div>
                            <Button label="Revoke" onClick={() => handleChangeUser(rowData)} />
                            <Button label="Grant Worker" onClick={() => handleChangeWorker(rowData)} />
                            <Button label="Grant Admin" onClick={() => handleChangeAdmin(rowData)} />
                        </div>
                        )}>
                        </Column>

                </DataTable>
            </div>
        );
    };

    return (
        <div className="card">
            <DataScroller value={users} itemTemplate={itemTemplate} rows={users.length} inline scrollHeight="500px" header="Scroll Down to Load More" />
        </div>
    );
}