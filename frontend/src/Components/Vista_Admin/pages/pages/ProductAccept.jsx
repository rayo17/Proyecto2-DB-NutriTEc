import React, { useState } from 'react';
import axios from 'axios';
import { Button } from 'react-bootstrap';
import Table from 'react-bootstrap/Table';

const ProductApproval = () => {
  const [products, setProducts] = useState([]);

  const handleProductApproval = (index) => {
    const updatedProducts = [...products];
    updatedProducts[index].estado = true;
    setProducts(updatedProducts);
  };
  //function to aprovate a products
  const handleProductReject = (index) => {
    const updatedProducts = [...products];
    updatedProducts[index].estado = false;
    setProducts(updatedProducts);
  };

  const handleProductSubmit = (event) => {
    event.preventDefault();

    
    // Aquí puedes realizar la lógica para guardar el producto aprobado en la base de datos o en algún otro lugar adecuado

    // Reinicia los estados o realiza alguna otra acción necesaria después de guardar el producto
    setProducts([]);
  };

  const handleProductChange = (event, index) => {
    const updatedProducts = [...products];
    updatedProducts[index].name = event.target.value;
    setProducts(updatedProducts);
  };

  const handleAddProduct = () => {
    setProducts([...products, { name: '', approved: false }]);
  };

  const handleRemoveProduct = (index) => {
    const updatedProducts = [...products];
    updatedProducts.splice(index, 1);
    setProducts(updatedProducts);
  };

  

  return (
    <div>
      <div>

      <Table striped bordered hover size="sm">
      <thead>
        <tr>
          <th>#</th>
          <th>Codigo de Barra</th>
          <th>Descripcion</th>
          <th>Tamaño Porcion</th>
          <th>Energia</th>
          <th>Grasa</th>
          <th>Sodio</th>
          <th>Carbohidratos</th>
          <th>Proteina</th>
          <th>Vitaminas</th>
          <th>Calcio</th>
          <th>Hierro</th>
          <th>Agregar</th>
          
       
          
        </tr>
      </thead>
      <tbody>
        {
  
    
        products.map(index=>{
          
             return( <tr>
               <td>2</td>
               <td>{index.codigo}</td>
               <td>{index.des}</td>
               <td>{index.tam}</td>
               <td>{index.energia}</td>
               <td>{index.grasa}</td>
               <td>{index.sodio}</td>
               <td>{index.carbohidratos}</td>
               <td>{index.prote}</td>
               <td>{index.vitaminas}</td>
               <td>{index.calcio}</td>
               <td>{index.hierro}</td>
               <td>
               <Button bsStyle="success">Aprobar</Button>
               <Button bsStyle="danger" >rechazar</Button>
               </td>             
             </tr>)
        

            
        })
        }


      </tbody>
    </Table>
      </div>
    </div>
  );
};

export default ProductApproval;