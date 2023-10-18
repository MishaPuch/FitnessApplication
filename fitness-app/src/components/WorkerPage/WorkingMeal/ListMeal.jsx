import React, { useState, useEffect } from 'react';
import { DataScroller } from 'primereact/datascroller';
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';
import { Button } from 'primereact/button';
import { useNavigate } from 'react-router-dom';
import WorkingMeal from './WorkingMeal';

export default function ListMeal(){
    const [meal, setMeal] = useState([]);
    const navigate = useNavigate();

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
        
        console.log(meal);
        const nameBodyTemplate = (data) => {
            return data.foodName.toString();
        };
       
        
        const ingredientsBodyTemplate = (data) => {
            return data.foodIngredients.toString();
        };
        const instructionsBodyTemplate = (data) => {
            return data.foodInstructions.toString();
        };
        const PCFBodyTemplate = (data) => {
            return `${data.protein.toString()}/${data.carbon.toString()}/${data.fat.toString()}`
        };

        const calorificValueBodyTemplate = (data) => {
            return data.calorificOfMeal.toString();
        };

        const typeOfMealBodyTemplate = (data) => {
            return data.typeOfMeal.nameFoodType.toString();
        };

        const handleChangeMeal = (data) => {
            navigate("/WorkerMeal")
        };

        return (
            <div className="card">
                 
                        
                <DataTable value={[data]} tableStyle={{ minWidth: '60rem' }}>
                    <Column field="Food" header="Food" body={nameBodyTemplate}></Column>
                    <Column field="Ingredients" header="Ingredients" body={ingredientsBodyTemplate}></Column>
                    <Column field="Instructions" header="Instructions" body={instructionsBodyTemplate}></Column>
                    <Column field="P/C/F" header="P/C/F" body={PCFBodyTemplate}></Column>
                    <Column field="CalorificValue" header="CalorificValue" body={calorificValueBodyTemplate}></Column>
                    <Column field="TypeOfMeal" header="TypeOfMealId" body={typeOfMealBodyTemplate}></Column>
                    <Column body={<Button label="Change Info" onClick={() => handleChangeMeal(data)} />}></Column>

                </DataTable>
            </div>
        );
    };

    return (
        <div className="card">
            <DataScroller value={meal} itemTemplate={itemTemplate} rows={meal.length} inline scrollHeight="500px" header="Scroll Down to Load More" />
        </div>
    );
}