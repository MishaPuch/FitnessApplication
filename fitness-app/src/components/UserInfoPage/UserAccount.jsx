import { useState  } from "react";
import TaskBar from "../TaskBar/TaskBar.jsx";
import Header from "../Header/Header";
import DataScroller from './ScrollCards/ScrollComponentTrening'
import DataScrollerDiet from './ScrollCards/ScrollComponentDiet.jsx'

import './UserAccount.css'

import { Calendar } from 'primereact/calendar';
import { Card } from 'primereact/card';


export default function UserPage(props){

    const [date , setDate]=useState(new Date());
    const [hoveredTreningCard, setHoveredTreningCard] = useState(null);
    const [hoveredDietCard, setHoveredDietCard] = useState(null);

    return(
    <div className="container">
        <div className="avatar">
            <Header />    
        </div>
        <div className="container">
            <div>
                <TaskBar />
            </div>
            <div className="card-conteiner">
                <div className="diet">
                    <Card 
                        onMouseEnter={() => setHoveredDietCard('diet')}
                        onMouseLeave={() => setHoveredDietCard(null)}
                        style={{ width: '550px' , height : '239px'  }}     
                    >
                        <DataScrollerDiet/>
                        {hoveredDietCard === 'diet' && <div className="card-overlay">Diet</div>}
                    </Card>

                </div>
                <div className="trening">
                    <Card
                        onMouseEnter={() => setHoveredTreningCard('diet')}
                        onMouseLeave={() => setHoveredTreningCard(null)}
                        style={{ width: '550px' , height : '239px'  }}     
                    >
                        <DataScroller />
                        {hoveredTreningCard === 'diet' && <div className="card-overlay">Trening</div>}

                    </Card>
                </div>
            </div>
            <div className="calendar">
                <Card >
                    <Calendar
                        value={date}
                        onChange={(e) => setDate(e.value)}
                        inline
                        showWeek
                        style={{ width: '606px' , height : '420px'  }}     
                    />                
                </Card>
                
            </div>
        </div>
    </div>

    );
};

