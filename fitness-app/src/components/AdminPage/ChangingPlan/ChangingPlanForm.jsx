import React, { useState, useEffect, useContext } from 'react';
import { DataScroller } from 'primereact/datascroller';
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';
import { Button } from 'primereact/button';
import { PlanDataContext } from '../../../State/PlanDataState';
import '../AdminMain.css'; 

async function ChangingPlanResponse(chanigingPlanId, decision) {
    try {
        const response = await fetch(`https://localhost:7060/api/TreningPlan/ChangeTreningPlanAsync/${chanigingPlanId}/${decision}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
        });

        if (response.ok) {
            alert('Plan was successfully changed');
        } else {
            alert('Plan was not changed');
        }
    } catch (error) {
        console.error('Error:', error);
        alert('Server is not started');
    }
}

export default function ChangingPlanForm() {
    const { planData } = useContext(PlanDataContext);
    const [changingPlan, setChangingPlan] = useState([]);

    useEffect(() => {
        async function fetchData() {
            try {
                const response = await fetch(`https://localhost:7060/api/TreningPlan/GetAllChangingTreningPlanRequestAsync`, {
                    method: 'GET',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                });

                if (response.ok) {
                    const responseData = await response.json();
                    setChangingPlan(responseData);
                    console.log(changingPlan);
                    
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

    const approvedChangingPlans = changingPlan.filter(plan => plan.isApproved === null);

    return (
        <div className="container">
            <DataScroller value={approvedChangingPlans} rows={approvedChangingPlans.length} inline scrollHeight="100vh" header="Scroll Down to Load More" itemTemplate={(data) => (
        <div className="user-card">
            <DataTable value={[data]} tableStyle={{ width: '60rem', height:'5rem' }}>
                <Column key="userName" field="userName" header="Name" style={{ width: '20%' }} body={(rowData) => rowData.user.userEmail    } />
                <Column field="actualUserTreningPlan" header="actualUserTreningPlan" style={{ width: '10%' }} body={(rowData) =>rowData.actualUserTreningPlan} />
                <Column field="disiredTreningPlan" header="disiredTreningPlan" style={{ width: '10%' }} />
                <Column style={{ width: '10%' }} body={() => (
                    <div className="button-container">
                        <Button label="Allow" className="p-button-success" onClick={() => ChangingPlanResponse(data.id, true)} raised />
                        <Button label="Deny" className="p-button-danger" onClick={() => ChangingPlanResponse(data.id, false)} raised />
                </div>
                
                )} />                
            </DataTable>
        </div>
    )} />
</div>

    );
}
