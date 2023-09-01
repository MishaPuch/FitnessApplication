import React, { useEffect ,useContext } from 'react';
import { DataScroller } from 'primereact/datascroller';
import itemTemplate from '../CardItem/CardItemTrening'
import { PlanDataContext } from '../../../State/PlanDataState';
//import { ProductService } from './service/ProductService';

export default function ScrollCards() {

    const { planData } = useContext(PlanDataContext);

    const treningExercise = [];

    const GetfullTrening=()=>{
        planData.forEach(item => {
                
            const exercise =item.trening.exercise;
            const muscleGroup =item.trening.muscleGroup.nameMuscleGroup;
    
    
            const trening={
                exerciseName :exercise.exerciseName,
                exerciseDescription : exercise.exerciseDescription,
                exerciseVideo : exercise.exerciseVideo,
                //muscleGroup : muscleGroup,
            }
            
            treningExercise.push(trening);

        });
        return treningExercise;
    }
    useEffect(() => {
       // ProductService.getProducts().then((data) => setProducts(data));
    }, []); // eslint-disable-line react-hooks/exhaustive-deps

    return (
        <div className="card">
            <DataScroller value={GetfullTrening()} itemTemplate={itemTemplate} rows={6} inline scrollHeight="160px"/>
        </div>
    )
}