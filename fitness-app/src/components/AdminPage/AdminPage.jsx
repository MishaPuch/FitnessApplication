// WorkerPage.js
import React from 'react';
import { TabView, TabPanel } from 'primereact/tabview';
import AdminMain from './AdminMain/AdminMain';
import { Button } from 'primereact/button';
import { useNavigate } from 'react-router-dom';

export default function AdminPage() {
    const navigate = useNavigate();

    const handleLogout=()=>{
    navigate("/")
        
    }
    return (
        <div className="card">
            <TabView>
                <TabPanel header="Header I">
                    <p className="m-0">
                        <AdminMain/>
                    </p>
                </TabPanel>
                <TabPanel header="Header II">
                    <p className="m-0">
                        Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, 
                        eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo
                        enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui 
                        ratione voluptatem sequi nesciunt. Consectetur, adipisci velit, sed quia non numquam eius modi.
                    </p>
                </TabPanel>
                <TabPanel header="Header III">
                    <p className="m-0">
                        <Button onClick={handleLogout}>logout</Button>
                    </p>
                </TabPanel>
            </TabView>
        </div>
    )
}