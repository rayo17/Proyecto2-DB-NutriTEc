import Table from 'react-bootstrap/Table';
import React, { useEffect, useState } from 'react'
import Button from 'react-bootstrap/Button';
import axios from 'axios';
import 'bootstrap/dist/css/bootstrap.css'
function ListaPaciente() {
   const [clientes,setclientes]=useState([])
   
   
   
    useEffect(()=>{
      getInfoClient()
   },[]) 
   
   const getInfoClient=async()=>{
      const url='http://localhost:2000/clientes'
        try{const response= await axios.get(url)
        const data=response.data
        setclientes(data)}
        catch(error){
          console.log(error)
        }
    }
  
    
    
    
    const deletePatient=async(id)=>{
       const url='http://localhost:2000/clientes'
      try{ await axios.delete(`${url}${id}`)
       getInfoClient()
       }
       catch(error){
        console.log(error)
       }

    }

    
    return (
      <Table striped bordered hover size="sm">
        <thead>
          <tr>
            <th>#</th>
            <th>Nombre</th>
            <th>Apellido1</th>
            <th>Apellido2</th>
            <th>Edad</th>
            <th>Fecha Nacimiento</th>
            <th>Peso</th>
            <th>IMC</th>
            <th>Pais de residencia</th>
            <th>Peso Actual</th>
            <th>Medida de Cintura</th>
            <th>Medida de cuello</th>
            <th>Medida de cadera</th>
            <th>Medida de Musculo</th>
            <th>Medida de grasa</th>
            <th>Calorias</th>
            <th>Correo</th>
          
            
          </tr>
        </thead>
        <tbody>
          {
             clientes.map(index=>{
         
              return( <tr>
                <td>{index.id}</td>
                <td>{index.nombre}</td>
                <td>{index.apellido1}</td>
                <td>{index.apellido2}</td>
                <td>{index.pais}</td>
                <td>{index.peso}</td>
                <td>{index.correo}</td>
                <td>{index.fecha}</td>
                <td>{index.pais}</td>
                <td>{index.pesoActual}</td>
                <td>{index.cuello}</td>
                <td>{index.cintura}</td>
                <td>{index.cadera}</td>
                <td>{index.musculo}</td>
                <td>{index.grasa}</td>
                <td>{index.calorias}</td>
                <td>{index.edad}</td>
                <td>
                  <button onClick={()=>{deletePatient(index.id)}}>Eliminar</button>
                
                  </td>             
              </tr>)
         
 
             
         })
         }
        </tbody>
      </Table>
    );
  }
  
  export default ListaPaciente;