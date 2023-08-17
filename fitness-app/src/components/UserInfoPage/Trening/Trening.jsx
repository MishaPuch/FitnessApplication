import React from "react";
import { DataScroller } from 'primereact/datascroller';

import { useState } from "react";
import { Card } from "primereact/card";




const Trening=()=>{
    const [ products ] =useState(["popa2","popa3","popa4","popa5","popa6","popa7","popa8"]);
    const [ itemTemplate ] =useState();

    products.map(product => <Card>{product}</Card>)
    return(
        <div>
            
            <DataScroller value={products} itemTemplate={itemTemplate} className="p-datascroller-list" rows={5} 
            inline scrollHeight="500px" header="Trening" />
        </div>
    );
}
export default Trening