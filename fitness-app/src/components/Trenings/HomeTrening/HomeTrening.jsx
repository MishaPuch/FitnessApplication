import React from 'react';

import TaskBar from '../../TaskBar/TaskBar';
import Header from '../../Header/Header';

import { Card } from 'primereact/card';
import { Image } from 'primereact/image';
import { Button } from 'primereact/button';


import '../../UserInfoPage/UserAccount.css'
import DataScroller from '../../ScrollCards/ScrollCards'
import '../GymTrening/GymTrening.css'


const HomePage=()=>{

    return(
        <div className="container">
            <div className="avatar">
                <Header />    
            </div>
            <div className="container">
                <div className="">
                    <TaskBar />
                </div>
                <div className="card-conteiner">
                    <div className="">
                        
                        <Card style={{ width: '600px' , height : '500px'  }}>
                            <Card>
                                <div>
                                    <DataScroller/>
                                    
                                </div>
                            </Card> 
                        </Card>
                    </div>
                </div>
                <div className="calendar">
                    <Card style={{ width: '596px' , height : '500px'  }}>
                    <div>
                    <Image src="https://media.tenor.com/Kae4sxhslT4AAAAS/work-out-gym.gif" indicatorIcon={'pi pi-check'} alt="Image" preview width="400" />
                    </div>            
                    </Card>
                    
                </div>
            </div>
        </div> 
    );
}
export default HomePage;