import {BrowserRouter , Routes , Route} from 'react-router-dom'

import './App.css';

import Statistic from './components/StatisticPage/Statistic';
import CalendarPage from './components/CalendarPage/CalendarPage'
import LoginForm from './components/Login/Login'; 
import UserAccount from './components/UserInfoPage/UserAccount'
import Registration from './components/Registration/Registration';
import { PlanDataProvider } from './State/PlanDataState';
import Settings from './components/SettingsPage/Settings';
import HomePage from './components/Trenings/HomeTrening/HomeTrening';
import GymPage from './components/Trenings/GymTrening/GymTrening';
import Diet from './components/DietPage/Diet';
import WorkerPage from './components/WorkerPage/WorkerPage';
import WorkerSettings from './components/WorkerSettings/WorkerSettings'

function App() {
  return (
     <div className="App">
      <header className="App-header">
      <PlanDataProvider>
        <BrowserRouter>
          <Routes>
            
              <Route path="/" element={<LoginForm />} />
              <Route path="/account" element={<UserAccount />} />
              <Route path="/registration" element={<Registration />} />
              <Route path="/calendar" element={<CalendarPage/>}/>
              <Route path="/statistic" element={<Statistic/>}/>
              <Route path="/settings" element={<Settings/>}/>
              <Route path="/gym-trening" element={<GymPage/>}/>
              <Route path="/home-trening" element={<HomePage/>}/>
              <Route path="/diet" element={<Diet/>}/>
              <Route path="/WorkerPage" element={<WorkerPage/>}/>
              <Route path="/WorkerSettings" element={<WorkerSettings/>}/>

              
          </Routes>
        </BrowserRouter>
      </PlanDataProvider>

      </header>
    </div>
  );
}

export default App;
