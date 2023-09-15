import React from 'react';

const itemTemplateDiet = ({ data, updateData }) => {
    
    const handleClick=()=>{
        updateData(data)
    }
    return (
        <div className="col-15" onClick={handleClick}>
            <div className="flex flex-column xl:flex-row xl:align-items-start p-1 gap-3">
                <img className="w-9 sm:w-16rem xl:w-10rem shadow-4 block xl:block mx-auto border-round" 
                    src={`https://hips.hearstapps.com/hmg-prod/images/steak-grain-bowl-1-1654094751.jpeg?crop=0.784xw:0.587xh;0.136xw,0.188xh&resize=1200:*`} alt={data.name} /> 
                <div className="flex flex-column lg:flex-row justify-content-between align-items-center xl:align-items-start lg:flex-1 gap-4">
                    <div className="flex flex-column align-items-center lg:align-items-start gap-3">
                        <div className="flex flex-column gap-1">
                            <div className="text-2xl font-bold text-900">{data.foodName}</div>
                            <div className="text-700">{data.foodInstructions}</div>
                        </div>
                        <div className="flex flex-column gap-2">
                            <span className="flex align-items-center gap-2">
                                <i className="pi pi-tag product-category-icon"></i>
                                <span className="font-semibold">{data.foodIngredients}</span>
                            </span>
                        </div>
                    </div>
                    <div className="flex flex-row lg:flex-column align-items-center lg:align-items-end gap-4 lg:gap-2">
                        <span className="text-2xl font-semibold">${data.typeOfMeal}</span>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default itemTemplateDiet;
