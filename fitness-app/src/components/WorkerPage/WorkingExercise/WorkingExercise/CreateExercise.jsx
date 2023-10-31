import React, { useState } from 'react';
import { InputText } from 'primereact/inputtext';
import { Card } from 'primereact/card';
import { Button } from 'primereact/button';
import { Dropdown } from 'primereact/dropdown';
import { useNavigate } from 'react-router-dom';

export default function WorkingExercise() {
    const navigate = useNavigate();
    const [selectedFile, setSelectedFile] = useState(null);

    const muscleGroupOptions = [
        { label: 'Triceps', value: 1 },
        { label: 'Legs', value: 2 },
        { label: 'Press', value: 3 },
        { label: 'Back', value: 4 },
        { label: 'Shoulders', value: 5 },
        { label: 'Biceps', value: 6 },
        { label: 'Buttocks', value: 7 },
        { label: 'Breast', value: 9 }
    ];

    const typeOfTrainingOptions = [
        { label: 'Home', value: 1 },
        { label: 'Gym', value: 2 }
    ];

    const [exerciseData, setExerciseData] = useState({
        id: 0,
        exerciseName: '',
        exerciseDescription: '',
        exerciseVideo: '',
        muscleGroupId: null,
        typeOfTreningId: null
    });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setExerciseData({
            ...exerciseData,
            [name]: value
        });
    };
    const handleFileChange = (event, Id) => {
        const file = event.target.files[0];
        setSelectedFile(file);
    
        if (file) {
            const formData = new FormData();
            formData.append('file', file); 
    
            try {
                fetch(`https://localhost:7060/api/Images/PostTheExercise/${Id}`, {
                    method: 'POST',
                    body: formData,
                })
                .then((response) => response.arrayBuffer()) 
                .then((data) => {
                })
                .catch((error) => {
                    console.error('Ошибка:', error);
                });
            } catch (error) {
                console.error('Ошибка:', error);
            }
        } else {
            console.error("Файл не выбран.");
        }
    };

    async function handleSave ()
    {
        try {
            const response = await fetch("https://localhost:7060/api/Exercise/createExercise", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },

                body: JSON.stringify(exerciseData),
            });

            
            if (response.ok) {
                alert("Exercise registration successful!");
                const responseData = await response.json()
               

            } else {
                console.log(response.json());
                alert("Error while registering exercise");
            }

        } catch (error) {
            console.error("Error:", error);
        }
    
        console.log(exerciseData);
    };

    const handleBack = () => {
        navigate('/WorkerPage');
    };

    return (
        <div className="container">
            <Button onClick={handleBack}>Back to the list</Button>
            <div className="setting-card">
                <Card style={{ width: '1240px', height: '500px' }}>
                    <div className="grid-container">
                        <div className="">
                            <span className="p-float-label grid-item">
                                <p>Exercise Name</p>
                                <InputText id="exerciseName" name="exerciseName" value={exerciseData.exerciseName} onChange={handleChange} />
                            </span>
                            <span className="p-float-label grid-item">
                                <p>Exercise Description</p>
                                <InputText id="exerciseDescription" name="exerciseDescription" value={exerciseData.exerciseDescription} onChange={handleChange} />
                            </span>
                            <span className="p-float-label grid-item">  
                            <div>
                            <input type="file" accept="image/*" onChange={(event) => handleFileChange(event, exerciseData.id)} />
                                {selectedFile && (
                                    <div>
                                    <p>Selected file: {selectedFile.name}</p>
                                    <img src={URL.createObjectURL(selectedFile)} alt="Selected" />
                                    </div>
                                )}
                                </div>          
                            </span>
                        </div>
                        <div className="grid-item">
                            <span className="p-float-label grid-item">
                                <p>Muscle Group ID</p>
                                <Dropdown
                                    id="muscleGroupId"
                                    name="muscleGroupId"
                                    optionLabel="label"
                                    optionValue="value"
                                    value={exerciseData.muscleGroupId}
                                    options={muscleGroupOptions}
                                    onChange={(e) => setExerciseData({ ...exerciseData, muscleGroupId: e.value })}
                                />
                            </span>
                            <span className="p-float-label grid-item">
                                <p>Type of Training ID</p>
                                <Dropdown
                                    id="typeOfTrainingId"
                                    name="typeOfTrainingId"
                                    optionLabel="label"
                                    optionValue="value"
                                    value={exerciseData.typeOfTreningId}
                                    options={typeOfTrainingOptions}
                                    onChange={(e) => setExerciseData({ ...exerciseData, typeOfTreningId: e.value })}
                                />
                            </span>
                            <br />
                            <br />
                            <span>
                                <div className="p-float-label grid-item">
                                    <Button label="Save" onClick={handleSave} style={{ width: '207px' }} />
                                </div>
                            </span>
                        </div>
                    </div>
                </Card>
            </div>
        </div>
    );
}
