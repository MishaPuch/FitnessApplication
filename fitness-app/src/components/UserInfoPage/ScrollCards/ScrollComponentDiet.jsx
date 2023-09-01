import React, { useState, useEffect, useContext } from 'react';
import { PlanDataContext } from '../../../State/PlanDataState';
import { DataScroller } from 'primereact/datascroller';
import itemTemplate from '../CardItem/CardItemDiet';
//import { ProductService } from './service/ProductService';

export default function ScrollCards() {

    const { planData } = useContext(PlanDataContext);

    const dietProducts = [];

    const GetfullDiet=()=>{
        planData.forEach(item => {
                
            const meal =item.diet.meal;
            const typeOfMeal =item.diet.meal.typeOfMeal;
    
            const diet={
                foodName : meal.foodName,
                foodInstructions :meal.foodInstructions,
                foto : meal.foto,
                typeOfMeal : typeOfMeal.nameFoodType,
            }
            
            dietProducts.push(diet);
        });
        return dietProducts;
    }

     useEffect(() => {
        // ProductService.getProducts().then((data) => setProducts(data));
     }, []); // eslint-disable-line react-hooks/exhaustive-deps

    return (
        <div className="card">
            <DataScroller value={GetfullDiet()} itemTemplate={itemTemplate} rows={6} inline scrollHeight="160px"/>
        </div>
    )
}