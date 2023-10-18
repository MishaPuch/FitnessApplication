import React, { useState } from 'react';

export default function WorkingExercise() {
    const [exerciseItem, setExerciseItem] = useState({
        Id: 0,
        FoodName: '',
        FoodIngredients: '',
        FoodInstructions: '',
        Foto: '',
        Protein: 0,
        Fat: 0,
        Carbon: 0,
        CalorificOfMeal: 0,
        TypeOfMealId: 0,
    });
    async function fetchData(foodItem) {
        try {
            const response = await fetch(`https://localhost:7060/api/Meal/createMealAsync`, {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(foodItem)
            });

            if (response.ok) {
                const responseData = await response.json();
                if (responseData.length > 0) {
                    setExerciseItem(responseData);
                }
            } else {
                alert('Error while fetching users');
            }
        } catch (error) {
            console.error('Error:', error);
            alert('Server is not started');
        }
    }

    const handleChange = (e) => {
        const { name, value } = e.target;
        setExerciseItem({
            ...exerciseItem,
            [name]: value,
        });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        fetchData(exerciseItem)
    };

    return (
        <div className="food-item-page">
            <h1>Food Item Details</h1>
            <form onSubmit={handleSubmit}>
                <div>
                    <label htmlFor="FoodName">Food Name:</label>
                    <input
                        type="text"
                        id="FoodName"
                        name="FoodName"
                        value={exerciseItem.FoodName}
                        onChange={handleChange}
                    />
                </div>
                <div>
                    <label htmlFor="FoodIngredients">Food Ingredients:</label>
                    <input
                        type="text"
                        id="FoodIngredients"
                        name="FoodIngredients"
                        value={exerciseItem.FoodIngredients}
                        onChange={handleChange}
                    />
                </div>
                <div>
                    <label htmlFor="FoodInstructions">Food Instructions:</label>
                    <textarea
                        id="FoodInstructions"
                        name="FoodInstructions"
                        value={exerciseItem.FoodInstructions}
                        onChange={handleChange}
                    />
                </div>  
                <div>
                    <label htmlFor="Foto">Foto:</label>
                    <input
                        type="text"
                        id="Foto"
                        name="Foto"
                        value={exerciseItem.Foto}
                        onChange={handleChange}
                    />
                </div>
                <div>
                    <label htmlFor="Protein">Protein:</label>
                    <input
                        type="number"
                        id="Protein"
                        name="Protein"
                        value={exerciseItem.Protein}
                        onChange={handleChange}
                    />
                </div>
                <div>
                    <label htmlFor="Fat">Fat:</label>
                    <input
                        type="number"
                        id="Fat"
                        name="Fat"
                        value={exerciseItem.Fat}
                        onChange={handleChange}
                    />
                </div>
                <div>
                    <label htmlFor="Carbon">Carbon:</label>
                    <input
                        type="number"
                        id="Carbon"
                        name="Carbon"
                        value={exerciseItem.Carbon}
                        onChange={handleChange}
                    />
                </div>
                <div>
                    <label htmlFor="CalorificOfMeal">Calorific Of Meal:</label>
                    <input
                        type="number"
                        id="CalorificOfMeal"
                        name="CalorificOfMeal"
                        value={exerciseItem.CalorificOfMeal}
                        onChange={handleChange}
                    />
                </div>
                <div>
                    <label htmlFor="TypeOfMealId">Type Of Meal ID:</label>
                    <input
                        type="number"
                        id="TypeOfMealId"
                        name="TypeOfMealId"
                        value={exerciseItem.TypeOfMealId}
                        onChange={handleChange}
                    />
                </div>
                <button type="submit">Submit</button>
            </form>
        </div>
    );
}
