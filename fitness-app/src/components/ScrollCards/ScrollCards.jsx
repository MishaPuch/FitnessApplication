
import React, { useState, useEffect } from 'react';
import { Button } from 'primereact/button';
import { DataScroller } from 'primereact/datascroller';
import itemTemplate from '../CardItem/CardItem'
import { Rating } from 'primereact/rating';
import { Tag } from 'primereact/tag';

import './ScrollCards.css'
//import { ProductService } from './service/ProductService';

export default function ScrollCards() {
    const [products, setProducts] = useState(["some","some","some","some","some","some" ,"some"]);

    useEffect(() => {
       // ProductService.getProducts().then((data) => setProducts(data));
    }, []); // eslint-disable-line react-hooks/exhaustive-deps

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
        