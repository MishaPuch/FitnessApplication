import React, { useContext , useEffect, useState } from "react";
import { PlanDataContext } from "../../../State/PlanDataState";
import ScrollCardsTrening from "../../ScrollCards/ScrollCards";
import { DataScroller } from 'primereact/datascroller';
import itemTemplateTrening from "../../CardItem/CardItemTrening";
import itemTemplateDiet from "../../CardItem/CardItemDiet";
import { Card } from "primereact/card";
const SelectedDate = (props) =>{

    const {planData , setPlanData}=useContext(PlanDataContext);


    const userId=planData[0].user.id;
    const day = props.day;

    const [fullDay, setFullDay] = useState();

    const  GetData= async() =>{
    try {
            const response = await fetch(`https://localhost:7060/api/TreningPlan/GetUserTodaysPlan/${userId}`, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
            },
            });
        
            if (response.ok) {

                const responseData = await response.json();
                setFullDay(responseData);
                console.log(fullDay);
            } 
            else {
                alert('Error while fetching users');
            }
    }
    catch (error) {
        console.error('Error:', error);
    }
    
    };
    useEffect(()=>{
        GetData();
    },[fullDay]) 
    return(
        <div>          
            <p style={{ marginTop:'-20px' ,marginBottom:'-90px', padding:'20px'}} >
                selected day {props.day}
            </p>
            <Card style={{ marginTop:'-70px' ,marginBottom:'-90px', padding:'20px'}}     
>
                <p style={{margin:'30px'}}>Trening</p>
                <div className="card">
                    <DataScroller value={fullDay} itemTemplate={itemTemplateTrening} rows={9} inline scrollHeight="330px"/>
                </div>
            </Card>
            <Card style={{ marginTop:'-60px' ,marginBottom:'-90px', padding:'10px'}} >
                <p style={{margin:'30px'}}>Diet</p>
                <div className="card">
                    <DataScroller value={fullDay} itemTemplate={itemTemplateDiet} rows={9} inline scrollHeight="330px"/>
                </div>
            </Card>
        </div>
    );
}
export default SelectedDate