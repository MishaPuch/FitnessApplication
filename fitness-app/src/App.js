import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import './App.css';

import Statistic from './components/StatisticPage/Statistic';
import CalendarPage from './components/CalendarPage/CalendarPage';
import LoginForm from './components/Login/Login';
import UserAccount from './components/UserInfoPage/UserAccount';
import Registration from './components/Registration/Registration';
import { PlanDataProvider } from './State/PlanDataState';
import Settings from './components/SettingsPage/Settings';
import HomePage from './components/Trenings/HomeTrening/HomeTrening';
import GymPage from './components/Trenings/GymTrening/GymTrening';
import Diet from './components/DietPage/Diet';
import WorkerPage from './components/WorkerPage/WorkerPage';
import WorkerSettings from './components/WorkerPage/WorkerSettings/WorkerSettings';
import AdminPage from './components/AdminPage/AdminPage';
import CreateMeal from './components/WorkerPage/WorkingMeal/CreateMeal';
import CreateExercise from './components/WorkerPage/WorkingExercise/WorkingExercise/CreateExercise';
import UpdateMeal from './components/WorkerPage/WorkingMeal/UpdateMeal';
import UpdateExercise from './components/WorkerPage/WorkingExercise/WorkingExercise/UpdateExercise';
import NotVerifiedUser from './components/AlertPages/NotVerifiedUser';
import ForgetPassword from './ForgetPassword/ForgetPassword';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <PlanDataProvider>
          <Router>
            <Routes>
              <Route path="/" element={<LoginForm />} />
              <Route path="/account" element={<UserAccount />} />
              <Route path="/registration" element={<Registration />} />
              <Route path="/calendar" element={<CalendarPage />} />
              <Route path="/statistic" element={<Statistic />} />
              <Route path="/settings" element={<Settings />} />
              <Route path="/gym-trening" element={<GymPage />} />
              <Route path="/home-trening" element={<HomePage />} />
              <Route path="/diet" element={<Diet />} />
              <Route path="/WorkerPage" element={<WorkerPage />} />
              <Route path="/WorkerSettings" element={<WorkerSettings />} />
              <Route path="/AdminPage" element={<AdminPage />} />
              <Route path="/WorkerMeal" element={<CreateMeal />} />
              <Route path="/WorkerExercise" element={<CreateExercise />} />
              <Route path="/UpdateMeal" element={<UpdateMeal />} />
              <Route path="/UpdateExercise" element={<UpdateExercise />} />
              <Route path="/VerifyUser/:email" element={<NotVerifiedUser />} />
              <Route path='/ForgetPassword' element={<ForgetPassword/>}/>


            </Routes>
          </Router>
        </PlanDataProvider>
      </header>
    </div>
  );
}

export default App;
