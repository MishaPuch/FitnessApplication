import React from 'react';

const itemTemplateTrening = (data) => {
    
    return (
        <div className="col-15">
            <div className="flex flex-column xl:flex-row xl:align-items-start p-1 gap-3">
                <img className="w-9 sm:w-16rem xl:w-10rem shadow-4 block xl:block mx-auto border-round" src={`https://donsport.ru/upload/iblock/2bd/h3rar0myqfv3pw6rty7r02cawhk3erwq.jpg`} alt={data.name} /> 
                <div className="flex flex-column lg:flex-row justify-content-between align-items-center xl:align-items-start lg:flex-1 gap-4">
                    <div className="flex flex-column align-items-center lg:align-items-start gap-3">
                        <div className="flex flex-column gap-1">
                            <div className="text-2xl font-bold text-900">{data.exerciseName}</div>
                            <div className="text-700">{data.exerciseDescription}</div>
                        </div>
                        <div className="flex flex-column gap-2">
                            <span className="flex align-items-center gap-2">
                                <i className="pi pi-tag product-category-icon"></i>
                                <span className="font-semibold">{data.nameMuscleGroup}</span>
                            </span>
                        </div>
                    </div>
                    <div className="flex flex-row lg:flex-column align-items-center lg:align-items-end gap-4 lg:gap-2">
                        <span className="text-2xl font-semibold">{data.times}</span>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default itemTemplateTrening;
