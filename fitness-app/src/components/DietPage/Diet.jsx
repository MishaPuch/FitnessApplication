import {React , useContext, useEffect, useState} from 'react';

import Header from '../Header/Header';
import TaskBar from '../TaskBar/TaskBar';

import '../UserInfoPage/UserAccount.css'
import { Card } from 'primereact/card';
import { DataScroller } from 'primereact/datascroller';
import { Button } from 'primereact/button';
import { PlanDataContext } from '../../State/PlanDataState';
import itemTemplateDiet from '../CardItem/CardItemDiet'
import DescribeComponent from './DescribeDietComponent/DescribeDiet';
import { useNavigate } from 'react-router-dom';

export default function Diet() {
    
    const {planData}=useContext(PlanDataContext);
    const navigate = useNavigate();
 
    useEffect(() => {
        if (planData.length === 0) {
            navigate('/');
        }
    }, []);
    const updateData = (value) => {
        setMeal(value);
    }
    console.log(planData[0].diet[0]);

    const diet={
        foodName : planData[0].diet[0].meal.foodName,
        foodInstructions : planData[0].diet[0].meal.foodInstructions,
        foto : planData[0].diet[0].meal.foto,
        typeOfMeal : planData[0].diet[0].nameFoodType,
        calorificOfMeal:planData[0].diet[0].meal.calorificOfMeal,
        carbon:planData[0].diet[0].meal.carbon,
        fat:planData[0].diet[0].meal.fat,
        foodIngredients:planData[0].diet[0].meal.foodIngredients,
        protein:planData[0].diet[0].meal.protein
    }

    const [meal ,setMeal]= useState(diet);

    const dietProducts = GetfullDiet();

    function GetfullDiet(){
        const allDietProducts = [];
        planData.forEach(item => {
                
            const diets =item.diet;
            diets.forEach(dietItem=>{
                    
                const typeOfMeal =dietItem.meal.typeOfMeal;
                    
                const diet={
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
        return allDietProducts;
    }

    if (planData.length === 0) {
        return <div>Loading...</div>;
    }
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
                <Card style={{ width: '600px' , height : '500px'  }}>
                
                    <Card>
                    <div className="card">
                    <DataScroller 
                        value={dietProducts} 
                        itemTemplate={(data) => itemTemplateDiet({ data, updateData })} 
                        rows={dietProducts.length}  
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

            <DescribeComponent meal={meal}/>
        </div>
    </div>
</div> 
    )
}
         