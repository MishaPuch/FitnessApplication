import React, { useState } from 'react';

import './Calendar.css';
import '../UserInfoPage/UserAccount.css'

import { Calendar } from 'primereact/calendar';
import { Card } from 'primereact/card';
import { Sidebar } from 'primereact/sidebar';

import TaskBar from '../TaskBar/TaskBar';
import Header from '../Header/Header';

const CalendarPage = () => {

    const [date, setDate] = useState(new Date());
    const [visible , setVisible]=useState();

    const handleData = (e) => {
        setDate(e.value);
        setVisible(true);
    }

    return (
        <div className="container">
            <div className="avatar">

                <Header />
            </div>
            <div className="container">
                <div className="taskbar">
                    <TaskBar />
                </div>
            </div>
            <div className="app">
                <div >
                    <Card className="calendar-container custom-calendar"  >                         
                        <div >
                            <Calendar
                                value={date}
                                onChange={(e) => handleData(e)}
                                inline
                                showWeek
                                style={{ width: '1200px' , height : '420px'  }}     
                            />
                        </div>
                    </Card>
                    <div className="card  justify-content-center justify-item-center">
                        <Sidebar visible={visible} onHide={() => setVisible(false)}  style={{ width: '1300px', height: '600px', margin: '100px' , borderRadius:'5px' ,boxShadow : '5px 4px 10px' }}>
                            <div>
                                <h2>your selected day is :</h2>
                            </div>
                            <div>
                                <Card>
                                <p>
                                     {date.toDateString()}
                                </p>
                                </Card>
                            </div>
                        </Sidebar>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default CalendarPage;
