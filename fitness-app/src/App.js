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
import WorkingMeal from './components/WorkerPage/WorkingMeal/WorkingMeal';
import WorkingExercise from './components/WorkerPage/WorkingExercise/WorkingExercise/WorkingExercise';

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
              <Route path="/WorkerMeal" element={<WorkingMeal />} />
              <Route path="/WorkerExercise" element={<WorkingExercise />} />
            </Routes>
          </Router>
        </PlanDataProvider>
      </header>
    </div>
  );
}

export default App;
