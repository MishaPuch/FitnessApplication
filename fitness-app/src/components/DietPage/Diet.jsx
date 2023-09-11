import {React , useContext} from 'react';

import Header from '../Header/Header';
import TaskBar from '../TaskBar/TaskBar';

import '../UserInfoPage/UserAccount.css'
import { Card } from 'primereact/card';
import { Image } from 'primereact/image';
import { DataScroller } from 'primereact/datascroller';
import { Button } from 'primereact/button';
import { PlanDataContext } from '../../State/PlanDataState';
import CardItemDiet from '../CardItem/CardItemDiet'


export default function Diet() {
    
    const {planData  }=useContext(PlanDataContext);

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
                        <DataScroller value={dietProducts} itemTemplate={CardItemDiet} rows={dietProducts.length} inline scrollHeight="330px"/>
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
                <Image src="https://hips.hearstapps.com/hmg-prod/images/steak-grain-bowl-1-1654094751.jpeg?crop=0.784xw:0.587xh;0.136xw,0.188xh&resize=1200:*" indicatorIcon={'pi pi-check'}  preview width="500" />
            </div>            
            <div>
                name of meal <br/>
                ingridients of meal <br/>
                instructions to cook <br/>
                colorify of meal <br/>
                protein/carbon of meal <br/>

            </div>
            </Card>
            
        </div>
    </div>
</div> 
    )
}
         