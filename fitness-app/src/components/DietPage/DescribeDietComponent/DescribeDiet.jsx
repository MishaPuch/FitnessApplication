import React from "react";
import { Card } from "primereact/card";
import { Image } from "primereact/image";

const DescribeComponent = (props) => {
    return (
        <div>
            <Card style={{ width: '596px', height: '500px' }}>
                <div style={{ width: '100%', height: '60%', overflow: 'hidden' }}>
                    <Image
                        src={props.meal.foto}
                        indicatorIcon={'pi pi-check'}
                        preview
                        width="100%"
                        style={{ objectFit: 'cover', objectPosition: '60% 100%' }}
                    />
                </div>
                <div>
                    name of meal : {props.meal.foodName} <br />
                    ingridients : {props.meal.foodIngredients} <br />
                    instructions to cook : {props.meal.foodInstructions}<br />
                    colorify of meal : {props.meal.calorificOfMeal} <br />
                    protein/carbon of meal : {props.meal.fat}/{props.meal.carbon} <br />
                </div>
            </Card>
        </div>
    );
};

export default DescribeComponent;
