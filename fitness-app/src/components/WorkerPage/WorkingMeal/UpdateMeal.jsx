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
        alert("Meal update successful!");
      } else {
        console.log(await response.json());
        alert("Error while updating meal");
      }
    } catch (error) {
      console.error("Error:", error);
    }
  }

  const handleBack = () => {
    navigate('/WorkerPage');
  };

  return (
    <div className="p-grid p-dir-md-row" style={{ justifyContent: 'space-around' }}>

      <div className="p-col-12 p-md-5">
        <Card style={{ width: '100%', height: '100%' }}>    
        <Button onClick={handleBack} icon="pi pi-arrow-left" className="p-button-secondary p-mb-3" />
     
         <div className="p-fluid">
            <div className="p-field">
              <label htmlFor="FoodName">Food Name</label>
              <InputText id="FoodName" name="FoodName" value={foodItem.FoodName} onChange={handleChange} />
            </div>
            <div className="p-field">
              <label htmlFor="FoodIngredients">Food Ingredients</label>
              <InputText id="FoodIngredients" name="FoodIngredients" value={foodItem.FoodIngredients} onChange={handleChange} />
            </div>
            <div className="p-field">
              <label htmlFor="FoodInstructions">Food Instructions</label>
              <InputText id="FoodInstructions" name="FoodInstructions" value={foodItem.FoodInstructions} onChange={handleChange} />
            </div>
            <div className="p-field">
              <label htmlFor="Foto">Foto</label>
              <InputText id="Foto" name="Foto" value={foodItem.Foto} onChange={handleChange} />
            </div>
          </div>
          
          <div className="p-fluid">
            <div className="p-field">
              <label htmlFor="Protein">Protein</label>
              <InputText id="Protein" name="Protein" value={foodItem.Protein} onChange={handleChange} />
            </div>
            <div className="p-field">
              <label htmlFor="Fat">Fat</label>
              <InputText id="Fat" name="Fat" value={foodItem.Fat} onChange={handleChange} />
            </div>
            <div className="p-field">
              <label htmlFor="Carbon">Carbon</label>
              <InputText id="Carbon" name="Carbon" value={foodItem.Carbon} onChange={handleChange} />
            </div>
            <div className="p-field">
              <label htmlFor="CalorificOfMeal">Calorific Of Meal</label>
              <InputText id="CalorificOfMeal" name="CalorificOfMeal" value={foodItem.CalorificOfMeal} onChange={handleChange} />
            </div>
            <div className="p-field">
              <label htmlFor="TypeOfMealId">Type Of Meal ID</label>
              <Dropdown
                id="TypeOfMealId"
                name="TypeOfMealId"
                optionLabel="label"
                optionValue="value"
                value={foodItem.TypeOfMealId}
                options={typeOfMealOptions}
                onChange={(e) => setFoodItem({ ...foodItem, TypeOfMealId: e.value })}
              />
            </div>
            <div className="p-col-12">
              <br/>
        <div className="p-grid p-justify-between">
          <Button label="Save" onClick={handleSave} icon="pi pi-check" className="p-button-success p-mb-3" />
        </div>
      </div>
          </div>
          </Card>
      </div>
     
    </div>
  );
}

        
        
          
       
  