import React, { useState } from 'react';
import { InputText } from 'primereact/inputtext';
import { Card } from 'primereact/card';
import { Button } from 'primereact/button';
import { useNavigate } from 'react-router-dom';

export default function WorkingExercise() {
    const navigate = useNavigate();

    const [exerciseData, setExerciseData] = useState({
        id: 0,
        exerciseName: '',
        exerciseDescription: '',
        exerciseVideo: '',
        muscleGroupId: 0,
        typeOfTreningId: 0
    });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setExerciseData({
            ...exerciseData,
            [name]: value
        });
    };

    const handleSave = () => {
        // В этой функции вы можете отправить `exerciseData` на сервер или выполнить другие действия
        // для сохранения данных.
        // В данном примере это просто вывод данных в консоль.
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
                                <p>Exercise Video</p>
                                <InputText id="exerciseVideo" name="exerciseVideo" value={exerciseData.exerciseVideo} onChange={handleChange} />
                            </span>
                        </div>
                        <div className="grid-item">
                            <span className="p-float-label grid-item">
                                <p>Muscle Group ID</p>
                                <InputText id="muscleGroupId" name="muscleGroupId" type="number" value={exerciseData.muscleGroupId} onChange={handleChange} />
                            </span>
                            <span className="p-float-label grid-item">
                                <p>Type of Training ID</p>
                                <InputText id="typeOfTreningId" name="typeOfTreningId" type="number" value={exerciseData.typeOfTreningId} onChange={handleChange} />
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
