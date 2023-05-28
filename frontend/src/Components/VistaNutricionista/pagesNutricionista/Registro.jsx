import React,{useState} from 'react'
import axios from 'axios'
import {useForm} from 'react-hook-form'
import '../../../styleCss/Nutricionista/Registro.css'
import BarraNav from '../../Barra'
    
 
function VistaRegistro(){
    const {
        register,
        errors,
        handleSubmit,
      } = useForm();
    const sendRegister= async (event)=>{
        event.preventDefault();
      
        await axios.put("http://localhost:2000/datosForm",{
            Cedula:datos.cedula,
            Nombre:datos.nombre,
            Apellido1:datos.apellido1,
            Apellido2:datos.apellido2,
            CodeNutri:datos.codeNutri,
            Edad:datos.edad,
            Fecha:datos.fecha,
            Peso:datos.peso, 
            IMC:datos.imc,
            Direccion:datos.direccion,
            Foto:datos.foto,
            Numero:datos.numero,
            TarjetaC:datos.tarejetaC,
            TipoCobro:datos.tipoCobro,
            Correo:datos.correo,
            Password:datos.password})
    }
    const dataInit={
            cedula:"",
            nombre:"",
            apellido1:"",
            apellido2:"",
            codeNutri:"",
            edad:"",
            fecha:"",
            peso:"",
            imc:"",
            direccion:"",
            foto:"",
            numero:"",
            tarejetaC:"",
            tipoCobro:"",
            correo:"",
            password:""
        };
        const [datos,setDatos]=useState(dataInit);
        const handlerData=(event)=>{
             setDatos({...datos,[event.target.name] : event.target.value})  

        }
        
    const envio=(data)=>{
        console.log(data)
    }

    return(
        
        <div className='contenedor-registro-nutri'>
            <BarraNav/>
            <h2 className='titulo-registro'>Registro</h2>
            <form onSubmit={handleSubmit(envio)} className='form-registro-Nutri'>
                    <label>cedula</label>
                    <input {...register('cedula',{required:true,message:"todo bien" })} type="text" name='cedula' className="cedula-input"  onChange={handlerData}/>
        
                
                    <label>nombre</label>
                    <input type="text" name='nombre' className="cedula-input"  onChange={handlerData} required/>
                
              
                    <label>apellido1</label>
                    <input type="text" name='apellido1' className="apellido1-input" onChange={handlerData} required/>
               
              
                <label>apellido2</label>
                    <input type="text"  name='apellido2' className="apellido2-input" onChange={handlerData} required/>
               
                
                <label>Codigo-nutritec</label>
                    <input type="text" name='codeNutri' className="code-nutri-input" onChange={handlerData}/>
                
               
                <label>Edad</label>
                    <input type="text" name='edad' className="edad-input" onChange={handlerData}/>
            
               
                <label>fecha</label>
                    <input type="date" name='fecha'  className="fecha-input" onChange={handlerData}/>
             
                
                <label>Peso</label>
                    <input type="text" name='peso' className="cedula-input" onChange={handlerData}/>
               
             
                <label>IMC</label>
                    <input type="text" name='imc' className="IMC-input" onChange={handlerData}/>
               
                <label>Direccion</label>
                    <input type="text" name='dirreccion'  className="direccion-input" onChange={handlerData}/>
                
                <label>Foto</label>
                    <input type="file" name='foto' className="cedula-input" />
               
              
                <label>Numero de tarjeta</label>
                    <input type="number" name='numero' className="cedula-input" onChange={handlerData}/>
              
                
                <label>apellido2</label>
                    <input type="text" name='tarjetaC' className="cedula-input" onChange={handlerData}/>
             
                <label>apellido2</label>
                    <input type="select" name='tipoCobro' className="cedula-input" onChange={handlerData}/>
                
              
                <label>apellido2</label>
                    <input type="gmail" name='correo' className="cedula-input"  onchange={handlerData}/>
              
                <label>Password</label>
                    <input type="password" name='password' className="cedula-input"  onChange={handlerData}/>

                <div>
                    <button onClick={sendRegister}>Registrar datos</button>
                </div>
                
        

            </form>
           
        </div>
    )
}
export default VistaRegistro