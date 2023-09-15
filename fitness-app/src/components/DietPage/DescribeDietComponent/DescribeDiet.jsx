import React from "react";
import { Card } from "primereact/card";
import { Image } from "primereact/image";

const DescribeComponent = (props) => {
    return(
        <div>
            <Card style={{ width: '596px' , height : '500px'  }}>
                <div>
                    <Image src="https://hips.hearstapps.com/hmg-prod/images/steak-grain-bowl-1-1654094751.jpeg?crop=0.784xw:0.587xh;0.136xw,0.188xh&resize=1200:*" indicatorIcon={'pi pi-check'}  preview width="500" />
                </div>            
                <div>
                    name of meal : {props.meal.foodName} <br/>
                    ingridients : {props.meal.foodIngredients} <br/>
                    foto: {props.meal.foto} <br/>
                    instructions to cook : {props.meal.foodInstructions}<br/>
                    colorify of meal : {props.meal.calorificOfMeal} <br/>
                    protein/carbon of meal : {props.meal.fat}/{props.meal.carbon} <br/>

                </div>
            </Card>
        </div>
    )
}
export default DescribeComponent;

