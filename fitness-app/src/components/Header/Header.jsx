import React, { useContext } from "react";
import { Avatar } from 'primereact/avatar';
import { UserContext } from "../../State/UserState";

import './Header.css'

const Header =()=>{

    const {user} =useContext(UserContext);

    return(
        <div className="header">           
            <div className="header-text">    
                {user.userName}
            </div>
            <div>
                <Avatar image="https://encrypted-tbn0.gstatic.com/
                    images?q=tbn:ANd9GcRavIqQYivR75p5gMVUiR_tZqoGzmqIVGbXRw&usqp=CAU" 
                    size="small" 
                    className="m-1" 
                    shape="circle" />
            </div>
            
        </div>
    );
}
export default Header