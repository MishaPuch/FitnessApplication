import React, { useState } from 'react';
import { InputText } from 'primereact/inputtext';
import { Card } from 'primereact/card';
import { Button } from 'primereact/button';
import { Dropdown } from 'primereact/dropdown';
import { useNavigate, useLocation } from 'react-router-dom';

export default function UpdateMeal() {
    const navigate = useNavigate();
    const location = useLocation();
    const mealData = location.state.mealData;

    const typeOfMealOptions = [
        { label: 'Breakfast', value: 1 },
        { label: 'Lunch', value: 2 },
        { label: 'Dinner', value: 3 },
        { label: 'Snack', value: 4 }
    ];

    const [foodItem, setFoodItem] = useState({
        Id: mealData.id,
        FoodName: mealData.foodName,
        FoodIngredients: mealData.foodIngredients,
        FoodInstructions: mealData.foodInstructions,
        Foto: mealData.foto,
        Protein: mealData.protein,
        Fat: mealData.fat,
        Carbon: mealData.carbon,
        CalorificOfMeal: mealData.calorificOfMeal,
        TypeOfMealId: mealData.typeOfMeal.id
    });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFoodItem({
            ...foodItem,
            [name]: value
        });
    };

    async function handleSave() {
        console.log(foodItem);
        try {
            const response = await fetch("https://localhost:7060/api/Meal/updateMealAsync", {
                method: "PUT",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(foodItem),
            });

            if (response.ok) {
                alert("Meal registration successful!");
            } else {
                console.log(await response.json()); 
                alert("Error while registering meal");
            }
        } catch (error) {
            console.error("Error:", error);
        }
    }

    const handleBack = () => {
        navigate('/WorkerPage');
    };

    return (
        <div className="container">
            <Button onClick={handleBack}>Back to the list</Button>
            <div className="setting-card">
                <Card style={{ width: '1240px', height: '500px' }}>
                    <div className="grid-container">
                        <div className="">
                            <span className="p-float-label grid-item">
                                <p>Food Name</p>
                                <InputText id="FoodName" name="FoodName" value={foodItem.FoodName} onChange={handleChange} />
                            </span>
                            <span className="p-float-label grid-item">
                                <p>Food Ingredients</p>
                                <InputText id="FoodIngredients" name="FoodIngredients" value={foodItem.FoodIngredients} onChange={handleChange} />
                            </span>
                            <span className="p-float-label grid-item">
                                <p>Food Instructions</p>
                                <InputText id="FoodInstructions" name="FoodInstructions" value={foodItem.FoodInstructions} onChange={handleChange} />
                            </span>
                            <span className="p-float-label grid-item">
                                <p>Foto</p>
                                <InputText id="Foto" name="Foto" value={foodItem.Foto} onChange={handleChange} />
                            </span>
                        </div>
                        <div className="grid-item">
                            <span className="p-float-label grid-item">
                                <p>Protein</p>
                                <InputText id="Protein" name="Protein" value={foodItem.Protein} onChange={handleChange} />
                            </span>
                            <span className="p-float-label grid-item">
                                <p>Fat</p>
                                <InputText id="Fat" name="Fat" value={foodItem.Fat} onChange={handleChange} />
                            </span>
                            <span className="p-float-label grid-item">
                                <p>Carbon</p>
                                <InputText id="Carbon" name="Carbon" value={foodItem.Carbon} onChange={handleChange} />
                            </span>
                            <span className="p-float-label grid-item">
                                <p>Calorific Of Meal</p>
                                <InputText id="CalorificOfMeal" name="CalorificOfMeal" value={foodItem.CalorificOfMeal} onChange={handleChange} />
                            </span>
                            <span className="p-float-label grid-item">
                                <p>Type Of Meal ID</p>
                                <Dropdown
                                    id="TypeOfMealId"
                                    name="TypeOfMealId"
                                    optionLabel="label"
                                    optionValue="value"
                                    value={foodItem.TypeOfMealId}
                                    options={typeOfMealOptions}
                                    onChange={(e) => setFoodItem({ ...foodItem, TypeOfMealId: e.value })}
                                />
                            </span>
                            <br />
                            <br />
                            <span>
                                <div className="p-float-label grid-item">
                                    <Button label="Save" onClick={handleSave} style={{ width: '207px' }} />
                                </div>
                            </span>
                        </div>
                    </div>
                </Card>
            </div>
        </div>
    );
}
