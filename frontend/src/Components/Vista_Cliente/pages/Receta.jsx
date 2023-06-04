import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Button } from 'react-bootstrap';
import Table from 'react-bootstrap/Table';
const RecipeManagement = () => {
  const [recipeName, setRecipeName] = useState('');
  const [recipeIngredients, setRecipeIngredients] = useState([]);
  const [product,setProducts]=useState([])
  const [recipeTotalCalories, setRecipeTotalCalories] = useState(0);
  // Agrega más estados para las otras propiedades de la receta (carbohidratos, azúcares, vitaminas, etc)

  const handleRecipeNameChange = (event) => {
    setRecipeName(event.target.value);
  };

  /*const handleIngredientChange = (event, index) => {
    const updatedIngredients = [...recipeIngredients];
    updatedIngredients[index] = event.target.value;
    setRecipeIngredients(updatedIngredients);
  };*/

  const handleAddIngredient = () => {
    setRecipeIngredients([...recipeIngredients, '']);
  };

  const handleRemoveIngredient = (index) => {
    const updatedIngredients = [...recipeIngredients];
    updatedIngredients.splice(index, 1);
    setRecipeIngredients(updatedIngredients);
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
    
    // Aquí puedes realizar la lógica para calcular las propiedades totales de la receta (calorías, carbohidratos, azúcares, vitaminas, etc)
    let totalCalories = 0;
    // Realiza los cálculos necesarios utilizando los ingredientes y sus porciones
    // Actualiza los estados correspondientes, por ejemplo:
    setRecipeTotalCalories(totalCalories);
    //url to send information
    const url=''
    //send post request 
    const response=await axios.put(url,{
        nombre:"hola"
    })
    console.log(response)
    // Aquí puedes realizar la lógica para guardar la receta en la base de datos o en algún otro lugar adecuado

    // Reinicia los estados o realiza alguna otra acción necesaria después de guardar la receta
    setRecipeName('');
    setRecipeIngredients([]);
    setRecipeTotalCalories(0);
  };

  const request=async()=>{

    const url="http://localhost:2000/alimento"
    try{
      const response=await axios.get(url)
      const data=response.data
      setRecipeIngredients(data)
     
    }
    catch(error){
      console.log(error)
    }}
 
  useEffect(
    ()=>{
        request()
    },[]

  )
  return (
    <div>
      <h2>Create Recipe</h2>
      <form onSubmit={handleRecipeSubmit}>
        <label>
          Recipe Name:
          <input type="text" value={recipeName} onChange={handleRecipeNameChange} />
        </label>
        <br />
        <label>Ingredients:</label>
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
               <Button bsStyle="success">Eliminar</Button>
               
               </td>             
             </tr>)
        

            
        })
        }


      </tbody>
    </Table>
        <br />
      </form>
      <div className='table-products'>
                  
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
               <Button bsStyle="success">Agregar</Button>
               
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
