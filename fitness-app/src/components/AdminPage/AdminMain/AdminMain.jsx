import React, { useState, useEffect, useContext } from 'react';
import { DataScroller } from 'primereact/datascroller';
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';
import { Button } from 'primereact/button';
import useChangeUserApi from '../../../hooks/useChangeUserApi';
import { PlanDataContext } from '../../../State/PlanDataState';

export default function AdminMain() {
    const { planData, setPlanData } = useContext(PlanDataContext);
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
            data.roleId = 1;
            changeData(data);
        };
        const handleChangeWorker = (data) => {
            data.roleId = 2;
            changeData(data);
        };
        const handleChangeAdmin = (data) => {
            data.roleId = 3;
            changeData(data);
        };
        if(planData[0].user.userEmail!==data.userEmail){

            return (
                <div className="card">
                    <DataTable value={[data]} tableStyle={{ minWidth: '60rem' }}>
                        {data.roleId === 1 && (
                            <div style={{ backgroundColor: 'var(--green-400)' }}>U</div>
                        )}
                        {data.roleId === 2 && (
                            <div style={{ backgroundColor: 'var(--bluegray-400)' }}>W</div>
                        )}
                        {data.roleId === 3 && (
                            <div style={{ backgroundColor: 'var(--primary-400)' }}>A</div>
                        )}
                        <Column field="userName" header="Name" body={nameBodyTemplate} />
                        <Column field="image" header="Image" body={imageBodyTemplate} />
                        <Column field="calorificValue" header="Price" body={emailBodyTemplate} />
                        <Column field="treningPlanId" header="Plan" />
                        <Column field="dateOFLastPayment" header="Days Left" body={(rowData) => (
                            <div>
                                <Button label="Grant Worker" onClick={() => handleChangeWorker(rowData)} severity="secondary" text raised  />
                                <Button label="Grant Admin" onClick={() => handleChangeAdmin(rowData)}  />
                                <Button label="Grant User" severity="success" onClick={() => handleChangeUser(rowData)} raised  />
                            </div>
                        )} />
                    </DataTable>
                </div>
            );
        }
        else{
            return (
                <div className="card">
                    <DataTable value={[data]} tableStyle={{ minWidth: '60rem' }}>
                        <div style={{ backgroundColor: 'var(--primary-400)' }}></div>
                        
                        <Column field="userName" header="Name" body={nameBodyTemplate} />
                        <Column field="image" header="Image" body={imageBodyTemplate} />
                        <Column field="calorificValue" header="Price" body={emailBodyTemplate} />
                        <Column field="treningPlanId" header="Plan" />
                        <Column field="dateOFLastPayment" header="Days Left" body={(rowData) => (
                            <div>
                                <Button label="Grant Worker" onClick={() => handleChangeWorker(rowData)} severity="secondary" text raised disabled />
                                <Button label="Grant Admin" onClick={() => handleChangeAdmin(rowData)} disabled />
                                <Button label="Grant User" severity="success" onClick={() => handleChangeUser(rowData)} raised disabled />
                            </div>
                        )} />
                    </DataTable>
                </div>
            );
        }

}

    return (
        <div className="card">
            <DataScroller value={users} itemTemplate={itemTemplate} rows={users.length} inline scrollHeight="500px" header="Scroll Down to Load More" />
        </div>
    );
}

