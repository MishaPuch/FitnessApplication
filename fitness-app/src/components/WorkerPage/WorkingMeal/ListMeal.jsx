import React, { useState, useEffect } from 'react';
import { DataScroller } from 'primereact/datascroller';
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';
import { Button } from 'primereact/button';
import { useNavigate } from 'react-router-dom';

import './ListMeal.css'; // Import your custom CSS file for additional styling

export default function ListMeal() {
  const [meal, setMeal] = useState([]);
  const navigate = useNavigate();

  const handleCreateMeal = () => {
    navigate('/WorkerMeal');
  };

  useEffect(() => {
    async function fetchData() {
      try {
        const response = await fetch(`https://localhost:7060/api/Meal/getAllMealAsync`, {
          method: 'GET',
          headers: {
            'Content-Type': 'application/json',
          },
        });

        if (response.ok) {
          const responseData = await response.json();
          if (responseData.length > 0) {
            setMeal(responseData);
          }
        } else {
          alert('Error while fetching meals');
        }
      } catch (error) {
        console.error('Error:', error);
        alert('Server is not started');
      }
    }

    fetchData();
  }, []);

  const itemTemplate = (data) => {
    const nameBodyTemplate = (data) => {
      return <span className="meal-data">{data.foodName}</span>;
    };
    const ingredientsBodyTemplate = (data) => {
      return <span className="meal-data">{data.foodIngredients}</span>;
    };
    const instructionsBodyTemplate = (data) => {
      return <span className="meal-data">{data.foodInstructions}</span>;
    };
    const PCFBodyTemplate = (data) => {
      return <span className="meal-data">{`${data.protein}/${data.carbon}/${data.fat}`}</span>;
    };
    const calorificValueBodyTemplate = (data) => {
      return <span className="meal-data">{data.calorificOfMeal}</span>;
    };
    const typeOfMealBodyTemplate = (data) => {
      return <span className="meal-data">{data.typeOfMeal.nameFoodType}</span>;
    };

    const handleChangeMeal = (data) => {
      navigate('/UpdateMeal', { state: { mealData: data } });
    };

    return (
      <div className="p-card meal-card p-mb-3">
        <DataTable value={meal} tableStyle={{ minWidth: '60rem' }} className="p-datatable-smooth">
          <Column field="Food" header="Food" body={nameBodyTemplate}></Column>
          <Column field="Ingredients" header="Ingredients" body={ingredientsBodyTemplate}></Column>
          <Column field="Instructions" header="Instructions" body={instructionsBodyTemplate}></Column>
          <Column field="P/C/F" header="P/C/F" body={PCFBodyTemplate}></Column>
          <Column field="CalorificValue" header="CalorificValue" body={calorificValueBodyTemplate}></Column>
          <Column field="TypeOfMeal" header="TypeOfMealId" body={typeOfMealBodyTemplate}></Column>
          <Column
  body={(rowData) => (
    <Button
      label="Change Info"
      className="p-button-primary p-mr-2"      onClick={() => handleChangeMeal(rowData)}
      style={{ width: '50%' }}
    />
  )}
/>
        </DataTable>
      </div>
    );
  };

  return (
    <div className="p-card p-m-3">
      <Button label="Create Meal" onClick={handleCreateMeal} className="p-mb-3" />
      <DataScroller value={meal} itemTemplate={itemTemplate} rows={1} inline scrollHeight="500px" header="Scroll Down to Load More" />
    </div>
  );
}
