import React, { useContext, useEffect, useState } from 'react';
import TaskBar from '../../TaskBar/TaskBar';
import Header from '../../Header/Header';
import { useNavigate } from 'react-router-dom';
import { Card } from 'primereact/card';
import { DataScroller } from 'primereact/datascroller';
import { Button } from 'primereact/button';
import itemTemplateTrening from '../../CardItem/CardItemTrening';
import { PlanDataContext } from '../../../State/PlanDataState';
import '../../UserInfoPage/UserAccount.css';
import './GymTrening.css';
import DescribeTrening from '../TreningDescription/DescriptionTrebing';

const HomePage = () => {
    const { planData } = useContext(PlanDataContext);
    const navigate = useNavigate();

    const [treningItem, setTreningItem] = useState({});

    useEffect(() => {
        if (!planData || !planData[0] || !planData[0].trening) {
            navigate('/');
            return;
        }

        const allTrening = GetfullTrening();

        if (allTrening.length > 0) {
            setTreningItem(allTrening[0]);
            console.log(treningItem);
        }            
    }, [planData, navigate]);

    function GetfullTrening() {
        const allTrening = [];

        planData.forEach((item) => {
            const trening = item.trening;

            trening.forEach((treningItem) => {
                const exercise = treningItem.exercise;

                const treningObj = {
                    times: exercise.times,
                    exerciseName: exercise.exerciseName,
                    exerciseDescription: exercise.exerciseDescription,
                    exerciseVideo: exercise.exerciseVideo,
                    nameMuscleGroup: exercise.muscleGroup.nameMuscleGroup,
                    typeOfTrening: exercise.typeOfTrening.typeOfTreningValue,
                };

                if (treningObj.typeOfTrening === 'Gym') {
                    allTrening.push(treningObj);
                }
            });
        });

        return allTrening;
    }

    const trenings = GetfullTrening();

    if (planData.length === 0) {
        return <div>Loading...</div>;
    }

    const updateData = (value) => {
        setTreningItem(value);
    };

    return (
        <div className="container">
            <div className="avatar">
                <Header />
            </div>
            <div className="container">
                <div className="">
                    <TaskBar />
                </div>
                <div className="card-conteiner">
                    <div className="">
                        <Card style={{ width: '600px', height: '500px' }}>
                            <Card>
                                <div className="card">
                                    <DataScroller
                                        value={trenings}
                                        itemTemplate={(data) => itemTemplateTrening({ data, updateData })}
                                        rows={trenings.length}
                                        inline
                                        scrollHeight="330px"
                                    />
                                    <Button icon="pi pi-arrow-circle-right" style={{ marginTop: '20px', marginBottom: '-20px ' }} />
                                </div>
                            </Card>
                        </Card>
                    </div>
                </div>
                <div className="calendar">
                    <DescribeTrening treningItem={treningItem} />
                </div>
            </div>
        </div>
    );
};

export default HomePage;
