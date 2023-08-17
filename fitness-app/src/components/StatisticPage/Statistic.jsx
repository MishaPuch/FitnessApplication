// import React from 'react';

// import Header from '../Header/Header';
// import TaskBar from '../TaskBar/TaskBar';

// import '../UserInfoPage/UserAccount.css'
// import { Card } from 'primereact/card';

// export default function Statistic() {
  
//     return (
//         <div className="container">
//         <div className="avatar">
//             <Header />    
//         </div>
//         <div className="container">
//             <div className="taskbar">
//                 <TaskBar />
//             </div>
//         </div>

//         <div className="app"> 
//             <Card>
//                 statistic 
//             </Card>   
           
//         </div>

//     </div>
//     )
// }

import React from 'react';
import { Card } from 'primereact/card';
import { Chart } from 'primereact/chart';

import Header from '../Header/Header';
import TaskBar from '../TaskBar/TaskBar';

import '../UserInfoPage/UserAccount.css'
import './Statistic.css'


const StatisticsPage = () => {
  const data = {
    labels: ['January', 'February', 'March', 'April', 'May' ,'lol' , 'aboba' ,'kobra' ],
    datasets: [
      {
        label: 'Sales',
        backgroundColor: '#42A5F5',
        data: [65, 59, 80, 81, 56 , 78 , 85 , 65],
      },
      {
        label: 'Expenses',
        backgroundColor: '#FFA726',
        data: [28, 48, 40, 19, 86 , 30 , 20 , 8],
      },
      {
        label: 'Expenses',
        backgroundColor: '#FFA726',
        data: [12, 5, 70, 54, 87 , 37 , 98 , 4  ],
      },
    ],
  };

  const options = {
    responsive: true,
    maintainAspectRatio: false,
  };

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
        <div className='statistic'>            
            <Card >
                <Chart type="line" data={data} options={options} style={{ width: '1200px' , height : '420px' }}/>
            </Card>
        </div>
    </div>
  );
};

export default StatisticsPage;

         