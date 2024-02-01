import React, { useState, useEffect } from 'react';
import { InputText } from 'primereact/inputtext';
import { Card } from 'primereact/card';
import { Button } from 'primereact/button';
import { Dropdown } from 'primereact/dropdown';
import { useNavigate, useLocation } from 'react-router-dom';

export default function UpdateExercise() {
    const navigate = useNavigate();
    const location = useLocation();
    const initialExerciseData = location.state.exerciseData;
    const muscleGroupOptions = [
        { label: 'Triceps', value: 1 },
        { label: 'Legs', value: 2 },
        { label: 'Press', value: 3 },
        { label: 'Back', value: 4 },
        { label: 'Shoulders', value: 5 },
        { label: 'Biceps', value: 6 },
        { label: 'Buttocks', value: 7 },
        { label: 'Breast', value: 9 },
    ];

    const typeOfTrainingOptions = [
        { label: 'Home', value: 1 },
        { label: 'Gym', value: 2 },
    ];
    const [exerciseData, setExerciseData] = useState({
        id: initialExerciseData.id,
        exerciseName: initialExerciseData.exerciseName,
        exerciseDescription: initialExerciseData.exerciseDescription,
        exerciseVideo: initialExerciseData.exerciseVideo,
        muscleGroupId: initialExerciseData.muscleGroup.id,
        typeOfTreningId: initialExerciseData.typeOfTrening.id,
        statistic: initialExerciseData.statistic
    });
    const handleChange = (e) => {
        const { name, value } = e.target;
        setExerciseData({
            ...exerciseData,
            [name]: value,
        });
    };

    async function handleSave() {
        
        try {
            const response = await fetch("https://localhost:7060/api/Exercise/update-exercise", {
                method: "PUT",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(exerciseData),
            });

            if (response.ok) {
                alert("Exercise update successful!");
            } else {
                console.log(await response.json());
                alert("Error while updating exercise");
            }
        } catch (error) {
            console.error("Error:", error);
        }
    }

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
                                <InputText
                                    id="exerciseName"
                                    name="exerciseName"
                                    value={exerciseData.exerciseName}
                                    onChange={handleChange}
                                />
                            </span>
                            <span className="p-float-label grid-item">
                                <p>Exercise Description</p>
                                <InputText
                                    id="exerciseDescription"
                                    name="exerciseDescription"
                                    value={exerciseData.exerciseDescription}
                                    onChange={handleChange}
                                />
                            </span>
                            <span className="p-float-label grid-item">
                                <p>Exercise Video</p>
                                <InputText
                                    id="exerciseVideo"
                                    name="exerciseVideo"
                                    value={exerciseData.exerciseVideo}
                                    onChange={handleChange}
                                />
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
