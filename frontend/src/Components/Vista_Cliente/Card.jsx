import React from 'react';
import Card from 'react-bootstrap/Card';

function CardP({imagen}){
    
    return(
        <div>
        
                <Card.Body>
                   <Card.Img variant="top" src={imagen} />
                </Card.Body>
    

        </div>
    )
}

export default CardP;