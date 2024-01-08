import React, { useState, useEffect } from 'react';
import { DataScroller } from 'primereact/datascroller';
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';
import { Button } from 'primereact/button';
import { useNavigate } from 'react-router-dom';

function WorkerMain() {
  const [users, setUsers] = useState([]);
  const navigate = useNavigate();

  useEffect(() => {
    async function fetchData() {
      try {
        const response = await fetch('https://localhost:7060/api/Account', {
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

  const handleChangeUser = (data) => {
    navigate('/WorkerSettings', { state: { userData: data } });
  };

  const itemTemplate = (data) => {
    const formatCurrency = (value) => {
      return value.toLocaleString('en-US', { style: 'currency', currency: 'USD' });
    };

    const imageBodyTemplate = (data) => {
      if (data.avatar !== "") {
        return (
          <img
            src={`https://fitnessapp.blob.core.windows.net/avatars/${data.avatar}`}
            alt={data.image}
            className="w-6rem shadow-2 border-round"
          />
        );
      } else {
        return (
          <img
            src={`https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRavIqQYivR75p5gMVUiR_tZqoGzmqIVGbXRw&usqp=CAU`}
            alt={data.image}
            className="w-6rem shadow-2 border-round"
          />
        );
      }
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

    return (
      <div className="card p-mb-3 p-p-3">
        <DataTable value={[data]} tableStyle={{ minWidth: '60rem' }}>
          <Column header="Role" body={(rowData) => (
            <div className={`role-badge p-mb-2`} style={{
              backgroundColor:
                rowData.roleId === 1 ? 'var(--green-400)' :
                  (rowData.roleId === 2 ? 'var(--bluegray-400)' : 'var(--primary-400)'
                )
            }}>
              {rowData.roleId === 1 ? 'U' : (rowData.roleId === 2 ? 'W' : 'A')}
            </div>
          )}></Column>
          <Column field="userName" header="Name" body={nameBodyTemplate}></Column>
          <Column header="Image" body={imageBodyTemplate}></Column>
          <Column field="calorificValue" header="Price" body={emailBodyTemplate}></Column>
          <Column field="treningPlanId" header="Plan"></Column>
          <Column field="dateOFLastPayment" header="Days Left" body={dateOFLastPaymentBodyTemplate}></Column>
          <Column body={(rowData) => (
            <Button label="Change Info" onClick={() => handleChangeUser(rowData)} className="p-button-primary p-mr-2" />
          )}></Column>
        </DataTable>
      </div>
    );
  };

  return (
    <div className="p-m-3">
      <DataScroller value={users} itemTemplate={itemTemplate} rows={users.length} inline scrollHeight="500px" header="Scroll Down to Load More" />
    </div>
  );
}

export default WorkerMain;
