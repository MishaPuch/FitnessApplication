import React, { useState, useEffect } from 'react';
import { format } from 'date-fns';

import './Calendar.css';
import '../UserInfoPage/UserAccount.css'

import { Calendar } from 'primereact/calendar';
import { Card } from 'primereact/card';
import { Sidebar } from 'primereact/sidebar';

import TaskBar from '../TaskBar/TaskBar';
import Header from '../Header/Header';
import SelectedDate from './SelectedDate/SelectedDate';

const CalendarPage = () => {
    const [date, setDate] = useState(new Date());
    const [dateToJson, setDateToJson] = useState(new Date());
    const [visible, setVisible] = useState();

   
const handleData = (e) => {
    const selectedDate = e.value;
    setDate(selectedDate);
    setDateToJson(selectedDate);
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
                    <Card
                        className="calendar-container custom-calendar"
                        style={{ marginLeft: '20px', marginBottom: '20px' }}
                    >
                        <div >
                            <Calendar
                                value={date}
                                onChange={(e) => handleData(e)}
                                inline
                                showWeek
                                style={{ width: '1200px', height: '420px' }}
                            />
                        </div>
                    </Card>
                    <div className="card  justify-content-center justify-item-center">
                        <Sidebar visible={visible} onHide={() => setVisible(false)}
                            style={{ width: '1300px', height: '600px', margin: '100px', borderRadius: '5px', boxShadow: '5px 4px 10px' }}>
                            <div>
                                <SelectedDate day={date.toDateString()} dayToJSON={dateToJson.toJSON()} />
                            </div>
                        </Sidebar>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default CalendarPage;
