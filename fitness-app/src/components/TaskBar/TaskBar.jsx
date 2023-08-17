    import React, { useState } from "react";

    import { Button } from 'primereact/button';                             
    import { Card } from 'primereact/card';

    import 'primeicons/primeicons.css';
    import './TaskBar.css';
    import '../UserInfoPage/UserAccount.css'

    import { useNavigate } from 'react-router-dom';



    const TaskBar = () => {

        const navigate = useNavigate();


        const [selectedTrening, setSelectedTrening] = useState();
        const [showTooltip, setShowTooltip]=useState(false)

        function handleLogout(){
            navigate('/');
        }
        function redirectHome(){
            navigate('/account');
        }
        function redirectCalendar(){
            navigate('/calendar');
        }
        function redirectStatistic(){
            navigate('/statistic');
        }
        function redirectSettings(){
            navigate('/settings');
        }


        return (
            <div className="taskbar">
                <ul className="ul-style progress-bar">
                    <li>
                        <div className="card">               

                            <Card className="w-4rem m-1 h-15rem" style={{ display: 'flex', justifyContent: 'center', alignItems: 'center', background: 'var(--bluegray-800)'}}>
                                <div>
                                    <ul className="ul-style">
                                        <li>      
                                            <Button icon="pi pi-home" onClick={redirectHome} style={{ fontSize: '1rem' , background: 'var(--bluegray-800)'}} />
                                        </li>
                                        <li>                                
                                            <Button icon='pi pi-calendar' onClick={redirectCalendar} className="mb-1 mt-1" style={{  background: 'var(--bluegray-800)'}} />
                                        </li>
                                        <li>                                
                                            <Button icon='pi pi-chart-bar' onClick={redirectStatistic} className="mb-1" style={{ fontSize: '1rem' , background: 'var(--bluegray-800)'}} />
                                        </li>
                                        <li>                                
                                            <Button icon='pi pi-cog' onClick={redirectSettings} className="mb-1" style={{ fontSize: '1rem' , background: 'var(--bluegray-800)'}}/>
                                        </li>
                                    </ul>
                                </div>
                            </Card>

                        </div>
                    </li>
                    <li>
                        <div className="card-2 m-1 h-12rem">
                            <Card className="w-4rem progress-bar custom-card" style={{ background: 'var(--bluegray-800)' }}  >
                                <ul className="ul-style">
                                    <li>
                                        <div className="tooltip-container" onMouseMove={() => setShowTooltip(true)} 
                                           >
                                            <Button
                                                className="tooltip-button m-1"
                                                type="button"
                                                icon="pi pi-apple"
                                                style={{ fontSize: '1rem', background: 'var(--bluegray-800)' }}
                                            />
                                            {showTooltip && (
                                                <div className="tooltip-content"  onMouseLeave={() =>{setTimeout(() => {setShowTooltip(false)}, 500)}}>
                                                    <div className="tooltip-buttons">
                                                        <Button
                                                            type="button"
                                                            label="home"
                                                            style={{ fontSize: '11px', background: 'var(--bluegray-800)' }}
                                                            onClick={(e) => {
                                                                setSelectedTrening('home')
                                                                navigate("/home-trening")
                                                            }}
                                                            className="p-button p-button ml-2"
                                                        />
                                                        <Button
                                                         onMouseLeave={() =>{setTimeout(() => {setShowTooltip(false)}, 500)}}
                                                            type="button"
                                                            label="gym"
                                                            style={{ fontSize: '11px', background: 'var(--bluegray-800)' }}
                                                            onClick={(e) =>{
                                                                setSelectedTrening('gym')
                                                                navigate("/gym-trening")
                                                            }
                                                        }
                                                            className="p-button p-button ml-2"
                                                        />
                                                    </div>
                                                </div>
                                            )}
                                        </div>
                                    </li>
                                    <li>
                                        <Button icon="pi pi-chart-bar"   onClick={(e) => {
                                                                setSelectedTrening('home')
                                                                navigate("/diet")
                                                            }} style={{ fontSize: '1rem' , background: 'var(--bluegray-800)'}}/>
                                    </li>
                                </ul>
                                </Card>
                        </div>
                    </li>
                    <li>
                        <div className="card-3 progress-bar  ">
                            <Card className="w-4rem h-9 rem" style={{ display: 'flex', justifyContent: 'center', alignItems: 'center' ,background: 'var(--bluegray-800)'}}>
                                <ul className="ul-style">
                                    <li>
                                        <Button  icon='pi pi-sign-out' severity="danger" className="m-1" onClick={handleLogout} style={{ fontSize: '1rem' , background: 'var(--bluegray-800)'}}/>
                                    </li>
                                </ul>
                            </Card>
                        </div>
                    </li>
                </ul>
            </div>
        );   
    }

    export default TaskBar;
