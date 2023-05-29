import React from "react";
import Card from "react-bootstrap/Card";
import Button from "react-bootstrap/Button";
import ListGroup from "react-bootstrap/ListGroup";
function Client({nombre, apellido1, apellido2})
{

  return (
    <Card style={{ width: '18rem' }}>
       <Card.Body>
        <ListGroup variant="flush">
        <ListGroup.Item>Nombre:{nombre}</ListGroup.Item>
        <ListGroup.Item>Apellido1:{apellido1}</ListGroup.Item>
        <ListGroup.Item>Apellido2:{apellido2}</ListGroup.Item>
      </ListGroup>
    <Button variant="primary">Agregar</Button>
    </Card.Body>
  </Card>
  )  
}

export default Client