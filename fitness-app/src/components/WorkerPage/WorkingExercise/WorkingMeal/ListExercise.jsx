import React, { useState, useEffect } from 'react';
import { DataScroller } from 'primereact/datascroller';
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';
import { Button } from 'primereact/button';
import { useNavigate } from 'react-router-dom';

export default function ListExercise(){
    const [exercise, setExercise] = useState([]);
    const navigate = useNavigate();

    useEffect(() => {
        async function fetchData() {
            try {
                const response = await fetch(`https://localhost:7060/api/Exercise/getAllExercises`, {
                    method: 'GET',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                });

                if (response.ok) {
                    const responseData = await response.json();
                    if (responseData.length > 0) {
                        setExercise(responseData);
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
        
        console.log(exercise);
        const nameBodyTemplate = (data) => {
            return data.exerciseName.toString();
        };
       
        
        const ingredientsBodyTemplate = (data) => {
            return data.exerciseDescription.toString();
        };
        const instructionsBodyTemplate = (data) => {
            return data.muscleGroup.nameMuscleGroup.toString();
        };
        

        const calorificValueBodyTemplate = (data) => {
            return data.typeOfTrening.typeOfTreningValue.toString();
        };

        
        const handleChangeMeal = (data) => {
            navigate("/WorkerExercise")
        };
        

        return (
            <div className="card">     
                <DataTable value={[data]} tableStyle={{ minWidth: '60rem' }}>
                    
                    <Column field="Food" header="Food" body={nameBodyTemplate}></Column>
                    <Column field="Ingredients" header="Ingredients" body={ingredientsBodyTemplate}></Column>
                    <Column field="Instructions" header="Instructions" body={instructionsBodyTemplate}></Column>
                    <Column field="CalorificValue" header="CalorificValue" body={calorificValueBodyTemplate}></Column>
                    <Column body={<Button label="Change Info" onClick={() => handleChangeMeal(data)} />}></Column>

                </DataTable>
            </div>
        );
    };

    return (
        <div className="card">
            <DataScroller value={exercise} itemTemplate={itemTemplate} rows={exercise.length} inline scrollHeight="500px" header="Scroll Down to Load More" />
        </div>
    );
}