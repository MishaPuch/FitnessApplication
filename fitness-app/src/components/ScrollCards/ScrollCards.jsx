
import React, { useState, useEffect , useContext} from 'react';
import { Button } from 'primereact/button';
import { DataScroller } from 'primereact/datascroller';
import itemTemplate from '../CardItem/CardItemTrening'
import { Rating } from 'primereact/rating';
import { Tag } from 'primereact/tag';
import { PlanDataContext } from '../../State/PlanDataState';

import './ScrollCards.css'
//import { ProductService } from './service/ProductService';

export default function ScrollCardsTrening() {

    const {planData , setPlanData }=useContext(PlanDataContext);
    const [products, setProducts] = useState(planData);
    
    
  
    return (
        <div className="card">
            <DataScroller value={products} itemTemplate={itemTemplate} rows={9} inline scrollHeight="330px"/>
            <Button
                icon="pi pi-arrow-circle-right"
                style={{ marginTop :'20px' , marginBottom : '-20px ' }}
            />
        </div>
    )
}
        