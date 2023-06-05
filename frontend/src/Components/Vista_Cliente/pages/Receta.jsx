import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Button } from 'react-bootstrap';
import Table from 'react-bootstrap/Table';
const RecipeManagement = () => {
  const [recipeName, setRecipeName] = useState('');
  const [recipeIngredients, setRecipeIngredients] = useState([]);
  const [product,setProducts]=useState([])
 
  const handleRecipeNameChange = (event) => {
    setRecipeName(event.target.value);
  };

  /*const handleIngredientChange = (event, index) => {
    const updatedIngredients = [...recipeIngredients];
    updatedIngredients[index] = event.target.value;
    setRecipeIngredients(updatedIngredients);
  };*/
  
  const handleAddIngredient = (product) => {
    setRecipeIngredients(prevProductos => [...prevProductos, product]);

  };

  const handleRemoveIngredient = (product) => {
    setRecipeIngredients(prevProductos =>
      prevProductos.filter(p => p.id !== product.id)
    );
  };


//function request
const getProduct=async()=>{
    const url=''
    const response=await axios.get(url)
    const data=response.data
    setProducts(data)
}

//Function request
  const handleRecipeSubmit = async(event) => {
    event.preventDefault();
    const url=''
    //send post request 
    const response=await axios.put(url,{
        
    })
    console.log(response)
    // Aquí puedes realizar la lógica para guardar la receta en la base de datos o en algún otro lugar adecuado

    // Reinicia los estados o realiza alguna otra acción necesaria después de guardar la receta
    setRecipeName('');
    setRecipeIngredients([]);
  
  };

  
 
  /*useEffect(
    ()=>{
        getProduct()
    },[]

  )*/
  return (
    <div>
      <h2>Crea tu Receta</h2>
      <form onSubmit={handleRecipeSubmit}>
        <label>
          colocale un nombre a tu receta
          <input type="text" value={recipeName} onChange={handleRecipeNameChange} />
        </label>
        <br />
        <label>Ingredientes Agregados:</label>
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
          <th>Eliminar</th> 
          
        </tr>
      </thead>
      <tbody>
        {
  
    
        recipeIngredients.map(index=>{
          
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
               <Button bsStyle="success" onClick={index=>handleRemoveIngredient(index)}>Eliminar</Button>
               
               </td>             
             </tr>)
        

            
        })
        }


      </tbody>
    </Table>
        <br />
      </form>
      <div className='table-products'>
      <label>Selecciona algunos de estos Ingredientes para crea tu Receta:</label>     
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
  
    
        product.map(index=>{
          
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
               <Button bsStyle="success" onClick={index=>{handleAddIngredient(index)}}>Agregar</Button>
               
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

export default RecipeManagement;
