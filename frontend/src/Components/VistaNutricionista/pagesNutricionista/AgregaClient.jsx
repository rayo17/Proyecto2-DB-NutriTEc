import React,{useState,useEffect} from 'react'
import { Table } from 'react-bootstrap'
import axios from 'axios'

function AgregaClient(){
  //Se crean los state hook necesarios para actualizar los datos
   const[cliente,setcliente]=useState("")
   const[clientes,setClientes]=useState([])

   useEffect(()=>{
    handlerClients()
   },[]) 
    const handlerClients=async ()=>{
        const url='http://localhost:2000/clientes'
        const response= await axios.get(url)
        const data=response.data
        setClientes(data)
    }
    const buscadorchange=(event)=>{
        setcliente(event.target.value)
    }
    //filtro
    let result =[]
    if(!cliente){
        result=clientes
    }else{
        result=clientes.filter((dato)=>
              dato.nombre.toLowerCase().includes(cliente.toLocaleLowerCase())
        )
    }

    // funciones


    //add patients
    const Add=async(cliente)=>{
      const url=''
      try{ 
        const response=await axios.post(url,{
          nombreNutricionista:localStorage.getItem("nutricionista"),
          paciente:cliente
        })
      }
      catch(error){
      console.error(error)
    }
      
    }
    return(
        <div>
           <nav class="navbar navbar-light bg-light">
            <div class="container-fluid">
                <a class="navbar-brand" href='·'>Nutritec</a>
            <form class="d-flex" role="search">
            <input class="form-control me-2" type="search" placeholder="Buscar" aria-label="Buscar" value={cliente} onChange={buscadorchange}/>
             <button class="btn btn-outline-success" type="submit">Buscar</button>
           </form>
           </div>
           </nav>
           <Table striped bordered hover size="sm">
      <thead>
        <tr>
          <th>#</th>
          <th>Nombre</th>
          <th>Apellido1</th>
          <th>Apellido2</th>
          <th>Pais</th>
          <th>Peso</th>
          <th>correo</th>  
        </tr>
      </thead>
      <tbody>
        {
  

        result.map(index=>{
         
             return( <tr>
               <td>{index.nombre}</td>
               <td>{index.apellido1}</td>
               <td>{index.apellido2}</td>
               <td>{index.pais}</td>
               <td>{index.peso}</td>
               <td>{index.correoelectronico}</td>
               
               <td>
                <button type="button" class="btn btn-warning" onClick={()=> Add(index.clienteid)}>Agregar</button>
                 </td>             
             </tr>)
        

            
        })
        }


      </tbody>
    </Table>
    
        </div>
    )   
}

export default AgregaClient