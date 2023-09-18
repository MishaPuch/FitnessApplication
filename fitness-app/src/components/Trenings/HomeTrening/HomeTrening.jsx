import React ,{useContext, useEffect, useState} from 'react';

import TaskBar from '../../TaskBar/TaskBar';
import Header from '../../Header/Header';

import { Card } from 'primereact/card';
import { DataScroller } from 'primereact/datascroller';
import { Button } from 'primereact/button';
import itemTemplateTrening from '../../CardItem/CardItemTrening';
import { PlanDataContext } from '../../../State/PlanDataState';
import '../../UserInfoPage/UserAccount.css'
//import DataScroller from '../../ScrollCards/ScrollCards'
import '../GymTrening/GymTrening.css'
import DescribeTrening from '../TreningDescription/DescriptionTrebing';
import { useNavigate } from 'react-router-dom';

const HomePage=()=>{

    const {planData }=useContext(PlanDataContext);
    let treningObj={};
    if(planData[0].trening[0]>0){
        treningObj = {
            times: planData[0].trening[0].times,
            exerciseName: planData[0].trening[0].exerciseName,
            exerciseDescription: planData[0].trening[0].exerciseDescription,
            exerciseVideo: planData[0].trening[0].exerciseVideo,
            //nameMuscleGroup: planData[0].trening[0].muscleGroup.nameMuscleGroup,
            //typeOfTrening: planData[0].trening[0].typeOfTrening.typeOfTreningValue,
        };
    }
   
    const [treningItem , setTreningItem]=useState(treningObj)
    
    const navigate = useNavigate();
 
    useEffect(() => {
        if (planData.length === 0) {
            navigate('/');
        }
    }, []);
    const updateData=(value)=>{
        setTreningItem(value);
    }
    const trenings = GetfullTrening();

    function GetfullTrening() {
        const allTrening = [];

        planData.forEach(item => {
            const trening = item.trening;

            trening.forEach(treningItem => {
                const exercise = treningItem.exercise;

                const treningObj = {
                    times: exercise.times,
                    exerciseName: exercise.exerciseName,
                    exerciseDescription: exercise.exerciseDescription,
                    exerciseVideo: exercise.exerciseVideo,
                    nameMuscleGroup: exercise.muscleGroup.nameMuscleGroup,
                    typeOfTrening: exercise.typeOfTrening.typeOfTreningValue,
                };
                if(treningObj.typeOfTrening==="Home"){
                    allTrening.push(treningObj);
                }
                else if(treningObj.typeOfTrening === "Gym"){
                }
            })
        });

        return allTrening;
    }

    if (planData.length === 0) {
        return <div>Loading...</div>;
    }
    return(
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
                        <Card style={{ width: '600px' , height : '500px'  }}>
                            <Card>
                                <div className="card">
                                <DataScroller 
                                    value={trenings} 
                                    itemTemplate={(data)=>itemTemplateTrening({data , updateData})} 
                                    rows={trenings.length} 
                                    inline 
                                    scrollHeight="330px"
                                />
                                    <Button
                                    icon="pi pi-arrow-circle-right"
                                    style={{ marginTop :'20px' , marginBottom : '-20px ' }}
                                />                                    
                                </div>
                            </Card> 
                        </Card>
                    </div>
                </div>
                <div className="calendar">
                    <DescribeTrening treningItem={treningItem}/>

                    
                </div>
            </div>
        </div> 
    );
}
export default HomePage;