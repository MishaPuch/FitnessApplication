import {React, useContext } from 'react';

import TaskBar from '../../TaskBar/TaskBar';
import Header from '../../Header/Header';

import { Card } from 'primereact/card';
import { Image } from 'primereact/image';
//import DataScroller from '../../ScrollCards/ScrollCards'
import { DataScroller } from 'primereact/datascroller';
import { Button } from 'primereact/button';
import itemTemplateTrening from '../../CardItem/CardItemTrening';
import { PlanDataContext } from '../../../State/PlanDataState';
import '../../UserInfoPage/UserAccount.css'
import './GymTrening.css'

const GymPage=()=>{
    const {planData  }=useContext(PlanDataContext);
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
                        <DataScroller value={trenings} itemTemplate={itemTemplateTrening} rows={trenings.length} inline scrollHeight="330px"/>
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
                <Card style={{ width: '596px' , height : '500px'  }}>
                <div>
                    <Image src="https://media.tenor.com/Kae4sxhslT4AAAAS/work-out-gym.gif" indicatorIcon={'pi pi-check'} alt="Image" preview width="400" />
                </div>            
                <div>
                    Some Food
                </div>
                </Card>
                
            </div>
        </div>
    </div> 
    );
}
export default GymPage;