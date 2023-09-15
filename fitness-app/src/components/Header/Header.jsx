import React, { useContext } from "react";
import { Avatar } from 'primereact/avatar';
import { PlanDataContext } from "../../State/PlanDataState";

import './Header.css';

const Header = () => {
    const { planData } = useContext(PlanDataContext);

    if (planData.length === 0) {
        return <div>Loading...</div>;
    }

    return (
        <div className="header">           
            <div className="header-text">    
                 {
                    planData[0].user.userName
                 }
            </div>
            <div>
                <Avatar 
                    image="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRavIqQYivR75p5gMVUiR_tZqoGzmqIVGbXRw&usqp=CAU" 
                    size="small" 
                    className="m-1" 
                    shape="circle" 
                />
            </div>
        </div>
    );
}

export default Header;
