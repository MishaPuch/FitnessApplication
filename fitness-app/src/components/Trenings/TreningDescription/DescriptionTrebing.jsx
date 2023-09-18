import React from "react";
import { Card } from "primereact/card";
import { Image } from "primereact/image";

const DescribeTrening =(props)=>{
    console.log(props);
    if(props.length>0){
        return(
            <div>
                <Card style={{ width: '596px' , height : '500px'  }}>
                    <div>
                        <Image src="https://media.tenor.com/Kae4sxhslT4AAAAS/work-out-gym.gif" indicatorIcon={'pi pi-check'} alt="Image" preview width="400" />
                    </div>            
                    <div>
                        {props.treningItem.exerciseName}
                    </div>
                    </Card>
            </div>
        )
    }
    else{
        return(
            <div>
                <Card style={{ width: '596px' , height : '500px'  }}>
                    <h1>today is a rest </h1>
                </Card>
            </div>
        )
    }
}
export default DescribeTrening;