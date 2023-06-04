import React,{useEffect, useState} from 'react'
import { Button } from 'react-bootstrap'
import Table from 'react-bootstrap/Table'
import axios from 'axios'

function GestionProducto(){

   //Declaracion de los useState para actulizar la informacion
    const [listaProducto,setListaProducto]=useState([])
    const [search,setSearch]=useState('')

    let result =[]
    
    const opcion=(event)=>{
        if(event.target.value==="nombre"){
            if(!search){
                result=listaProducto
            }else{
                result=listaProducto.filter((dato)=>
                      dato.Nombre.toLowerCase().includes(search.toLocaleLowerCase())
                )
            }
            
        }
        else if (event.target.value==="codigo"){
            if(!search){
                result=listaProducto
            }else{
                result=listaProducto.filter((dato)=>
                      dato.Codigo.toLowerCase().includes(search.toLocaleLowerCase())
                )
            }
            
        }
        }     

    const request=async()=>{

        const url="http://localhost:2000/alimento"
        try{
          const response=await axios.get(url)
          const data=response.data
          setListaProducto(data)
        }
        catch(error){
          console.log(error)
        }}

    const findProduct=(event)=>{
      setSearch(event.target.value)
    }

        
    
    useEffect(()=>{
        request()
        
    },[])//colocar listaProducto como prop en lista
    
    return(
      <div>
           
           <div>
            <nav class="navbar navbar-light bg-light">
            <div class="container-fluid">
                <a class="navbar-brand" href='·'>Nutritec</a>
            <form class="d-flex" role="search">
            <input class="form-control me-2" type="search" placeholder="Buscar" aria-label="Buscar" onChange={findProduct}/>
             <button class="btn btn-outline-success" type="submit">Buscar</button>
           </form>
           </div>
           </nav>
           <div>
            <select name="" id="" onChange={opcion}>
                <label for="cars">Filtro:</label>
                <option value="volvo">Seleccione</option>
                <option value="nombre">Nombre</option>
                <option value="codigo">Codigo de Barra</option>
            </select>
        </div>
        </div>
        



            
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
  
    
        result.map(index=>{
          
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
    )
    }

export default GestionProducto