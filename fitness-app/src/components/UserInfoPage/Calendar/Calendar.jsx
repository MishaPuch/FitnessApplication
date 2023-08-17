import React, { useState } from 'react';
import { Calendar } from 'primereact/calendar';


const FullCalendar=()=>{
    const [date, setDate] = useState(new Date())

    return(
      
      <Calendar value={date} onChange={(e) => setDate(e.value)}  style={{/*   */}} inline showWeek/>
    );
}
export default FullCalendar;