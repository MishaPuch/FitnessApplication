import { createContext, useState } from "react";

const PlanDataContext = createContext(); 
    
const PlanDataProvider=({children})=>{
    
    const [planData , setPlanData]=useState([]);
    console.log(planData);
    return(
        <PlanDataContext.Provider value={{planData,setPlanData}}>
            {children}
        </PlanDataContext.Provider>
    )
}

export {PlanDataContext , PlanDataProvider};