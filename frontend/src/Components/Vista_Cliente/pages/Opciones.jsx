import React, { useEffect, useState } from 'react'
import axios from 'axios'
import Tabla from '../../VistaNutricionista/Tabla'
function Opciones({timeName}){
    const [alimentos,setAlimentos]=useState([])
    const [search,setSearch]=useState('')

    //option of filter

    let result =[]
    
    const opcion=(event)=>{
        if(event.target.value==="nombre"){
            if(!search){
                result=alimentos
            }else{
                result=alimentos.filter((dato)=>
                      dato.Nombre.toLowerCase().includes(search.toLocaleLowerCase())
                )
            }
            
        }
        else if (event.target.value==="codigo"){
            if(!search){
                result=alimentos
            }else{
                result=alimentos.filter((dato)=>
                      dato.Codigo.toLowerCase().includes(search.toLocaleLowerCase())
                )
            }
            
        }
        }     
    
    

    useEffect(()=>{
        const url="http://localhost:2000/alimentos"
        axios.get(url).then(
            info=> {setAlimentos(info) 
                console.log(info)
        }
        ).catch(error=>console.log(error))},[])

    const addAlimento=()=>{

    }
    const deleteAlimento=(idproducto)=>{
        
    }

    const sendInformation=async()=>{
        const url=''
        const response=axios.post(url,{

            timeName:timeName 
        })
    }
    return(
        <div>
            <nav class="navbar navbar-light bg-light">
            <div class="container-fluid">
                <a class="navbar-brand" href='·'>Nutritec</a>
            <form class="d-flex" role="search">
            <input class="form-control me-2" type="search" placeholder="Buscar" aria-label="Buscar"/>
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
        <div>
            <h1>Registro Diario</h1>
            
        </div>

        </div>
    )
}

export default Opciones