import {React , useState} from 'react';

import Header from '../Header/Header';
import TaskBar from '../TaskBar/TaskBar';

import '../UserInfoPage/UserAccount.css'
import { Card } from 'primereact/card';
import { Image } from 'primereact/image';
import { DataScroller } from 'primereact/datascroller';
import { Button } from 'primereact/button';

import itemTemplate from '../CardItem/CardItem'


export default function Diet() {
    
    const [products, setProducts] = useState(["some","some","some","some","some","some" ,"some","some","some" ,"some"]);


    return (
    <div className="container">
    <div className="avatar">
        <Header />    
    </div>
    <div className="container">
        <div className="">
            <TaskBar />
        </div>
        <div className="card-conteiner">
            <div className="">
                <Card style={{ width: '600px' , height : '500px'  }}>
                
                    <Card>
                    <div className="card">
                        <DataScroller value={products} itemTemplate={itemTemplate} rows={9} inline scrollHeight="330px"/>
                        <Button
                            icon="pi pi-arrow-circle-right"
                            style={{ marginTop :'20px' , marginBottom : '-20px ' }}
                        />
                    </div>
                    </Card> 
                </Card>
            </div>
        </div>
        <div className="calendar">
            <Card style={{ width: '596px' , height : '500px'  }}>
            <div>
                <Image src="https://media.tenor.com/Kae4sxhslT4AAAAS/work-out-gym.gif" indicatorIcon={'pi pi-check'}  preview width="400" />
            </div>            
            <div>
                Some Food
            </div>
            </Card>
            
        </div>
    </div>
</div> 
    )
}
         