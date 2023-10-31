import React, { useState, useEffect } from 'react';
import { DataScroller } from 'primereact/datascroller';
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';
import { Button } from 'primereact/button';
import { useNavigate } from 'react-router-dom';

export default function ListExercise() {
    const [exercises, setExercises] = useState([]);
    const navigate = useNavigate();

    const handleCreateExercise = () => {
        navigate("/WorkerExercise");
    };

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
                    setExercises(responseData);
                } else {
                    alert('Error while fetching exercises');
                }
            } catch (error) {
                console.error('Error:', error);
                alert('Server is not started');
            }
        }

        fetchData();
    }, []);

    const handleUpdateExercise = (data) => {
        navigate("/UpdateExercise", { state: { exerciseData: data } });
    };

    return (
        <div className="card">
            <Button label="Create Exercise" onClick={handleCreateExercise} />
            <DataTable value={exercises} tableStyle={{ minWidth: '60rem' }}>
                <Column field="exerciseName" header="Exercise Name" />
                <Column field="exerciseDescription" header="Exercise Description" />
                <Column field="muscleGroup.nameMuscleGroup" header="Muscle Group" />
                <Column field="typeOfTrening.typeOfTreningValue" header="Type of Training" />
                <Column body={(data) => (<Button label="Change Info" onClick={() => handleUpdateExercise(data)} />)}/>
                
            </DataTable>
        </div>
    );
}
