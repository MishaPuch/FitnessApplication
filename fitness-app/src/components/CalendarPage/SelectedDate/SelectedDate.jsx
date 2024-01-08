import React, { useContext , useEffect, useState } from "react";
import { PlanDataContext } from "../../../State/PlanDataState";
import { DataScroller } from 'primereact/datascroller';
import itemTemplateTrening from "../../CardItem/CardItemTrening";
import itemTemplateDiet from "../../CardItem/CardItemDiet";
import { Card } from "primereact/card";
const SelectedDate = (props) => {
    const { planData } = useContext(PlanDataContext);
    const userId = planData[0].user.id;
    const dayToJSON= props.dayToJSON;
    const [fullDay, setFullDay] = useState([]);
    
    useEffect(() => {
        GetData();
    }, [dayToJSON]);

    const GetData = async () => {
        try {
            console.log(dayToJSON);
            const response = await fetch(`https://localhost:7060/api/TreningPlan/GetDalyPlan/${userId}/${dayToJSON}`, {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json',
                },
            });

            if (response.ok) {
                const responseData = await response.json();
                setFullDay(responseData);
                console.log(responseData);

            } else {
                alert('Error while fetching users');
            }
        } catch (error) {
            console.error('Error:', error);
        }
    };

    const updateData=(value)=>{
        console.log(value);
    }

    const trenings = GetfullTrening();

    function GetfullTrening() {
        const allTrening = [];
        
        if (fullDay) {
            fullDay.forEach(item => {
                const trening = item.trening;

                trening.forEach(treningItem => {
                    const exercise = treningItem.exercise;

                    const treningObj = {
                        times: treningItem.times,
                        exerciseName: exercise.exerciseName,
                        exerciseDescription: exercise.exerciseDescription,
                        exerciseVideo: exercise.exerciseVideo,
                        nameMuscleGroup: exercise.muscleGroup.nameMuscleGroup,
                        typeOfTrening: exercise.typeOfTrening.typeOfTreningValue,
                    };
                    allTrening.push(treningObj);
                    
                })
            });
        }

        return allTrening;
    }

    const dietProducts = GetfullDiet();

    function GetfullDiet() {
        const allDietProducts = [];

        if (fullDay) {
            fullDay.forEach(item => {
                const diets = item.diet;
                diets.forEach(dietItem => {
                    const typeOfMeal = dietItem.meal.typeOfMeal;
                    const diet = {
                        foodName : dietItem.meal.foodName,
                        foodInstructions : dietItem.meal.foodInstructions,
                        foto : dietItem.meal.foto,
                        typeOfMeal : typeOfMeal.nameFoodType,
                        calorificOfMeal:dietItem.meal.calorificOfMeal,
                        carbon:dietItem.meal.carbon,
                        fat:dietItem.meal.fat,
                        foodIngredients:dietItem.meal.foodIngredients,
                        protein:dietItem.meal.protein
                    }
                    allDietProducts.push(diet);
                })
            });
        }
      
        return allDietProducts;
    }
    
    return(
        <div>          
            <p style={{ marginTop:'-20px' ,marginBottom:'-90px', padding:'20px'}} >
                selected day {props.day}
            </p>
            <Card style={{ marginTop:'-70px' ,marginBottom:'-90px', padding:'20px'}}     
>
                <p style={{margin:'30px'}}>Trening</p>
                <div className="card">
                <DataScroller value={trenings} itemTemplate={(data)=>itemTemplateTrening({data , updateData})}  rows={trenings.length} inline scrollHeight="330px"/>
                </div>
            </Card>
            <Card style={{ marginTop:'-60px' ,marginBottom:'-90px', padding:'10px'}} >
                <p style={{margin:'30px'}}>Diet</p>
                <div className="card">
                <DataScroller value={dietProducts} itemTemplate={(data)=>itemTemplateDiet({data , updateData})}  rows={dietProducts.length} inline scrollHeight="330px"/>
                </div>
            </Card>
        </div>
    );
}
export default SelectedDate