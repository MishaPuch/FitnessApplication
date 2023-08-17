
import React, { useState, useEffect } from 'react';
import { DataScroller } from 'primereact/datascroller';
import itemTemplate from '../CardItem/CardItem'
//import { ProductService } from './service/ProductService';

export default function ScrollCards() {
    const [products] = useState(["some","some","some","some","some","some" ,"some"]);

    useEffect(() => {
       // ProductService.getProducts().then((data) => setProducts(data));
    }, []); // eslint-disable-line react-hooks/exhaustive-deps

    return (
        <div className="card">
            <DataScroller value={products} itemTemplate={itemTemplate} rows={6} inline scrollHeight="160px"/>
        </div>
    )
}