import React, { useContext } from 'react';
import { DataScroller } from 'primereact/datascroller';
import itemTemplate from '../CardItem/CardItemTrening';
import { PlanDataContext } from '../../../State/PlanDataState';

export default function ScrollCards() {
    const {planData } = useContext(PlanDataContext);
    const trenings = GetfullTrening(); 
    
    
    function GetfullTrening() {
        const allTrening = [];

        planData.forEach(item => {
            const trening = item.trening;

            trening.forEach(treningItem => {
                const exercise = treningItem.exercise;

                const treningObj = {
                    times: treningItem.times,
                    exerciseName: exercise.exerciseName,
                    exerciseDescription: exercise.exerciseDescription,
                    exerciseVideo: exercise.exerciseVideo,
                    nameMuscleGroup: exercise.muscleGroup.nameMuscleGroup,
                };
                allTrening.push(treningObj);
            })
        });
        return allTrening;
    }
    console.log(trenings);
    
    if (planData.length === 0) {
        return <div>Loading...</div>;
    }
    
    return (
        <div className="card">
            <DataScroller value={trenings} itemTemplate={itemTemplate} rows={trenings.length} inline scrollHeight="160px" />
        </div>
    );
}
