import React from 'react';

const itemTemplate = (data) => {
    return (
        <div className="col-15">
            <div className="flex flex-column xl:flex-row xl:align-items-start p-1 gap-3">
                <img className="w-9 sm:w-16rem xl:w-8rem shadow-4 block xl:block mx-auto border-round" src={data.exerciseVideo} alt={data.name} /> 
                <div className="flex flex-column lg:flex-row justify-content-between align-items-center xl:align-items-start lg:flex-1 gap-4">
                    <div className="flex flex-column align-items-center lg:align-items-start gap-3">
                        <div className="flex flex-column gap-1">
                            <div className="text-2xl font-bold text-900">{data.exerciseName}</div>
                            
                            <div className="text-700">{data.exerciseDescription}</div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default itemTemplate;
