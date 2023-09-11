import React, { useContext } from 'react';
import { PlanDataContext } from '../../../State/PlanDataState';
import { DataScroller } from 'primereact/datascroller';
import itemTemplate from '../CardItem/CardItemDiet';
//import { ProductService } from './service/ProductService';

export default function ScrollCards() {

    const { planData } = useContext(PlanDataContext);

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
                }
                allDietProducts.push(diet);
            })
        });
        return allDietProducts;
    }
    console.log(dietProducts );

    return (
        <div className="card">
            
            <DataScroller value={dietProducts} itemTemplate={itemTemplate} rows={dietProducts.length} inline scrollHeight="160px"/>
        </div>
    )
}