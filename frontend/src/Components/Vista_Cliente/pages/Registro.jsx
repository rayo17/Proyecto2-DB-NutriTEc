import React, { useState } from 'react'
import axios from 'axios'
import '../../../styleCss/Cliente/RegistroC.css'
import BarraNav from '../../Barra'
function RegistroClient(){

    const dataInit={
        nombre:"",
        apellido1:"",
        apellido2:"",
        edad:"",
        fecha:"",
        peso:"",
        imc:"",
        pais:"",
        cuello:"",
        cadera:"",
        musculo:"",
        grasa:"",
        calorias:"",
        pesoActual:"",
        correo:"",
        password:""
    }
    const sendInformation=async()=>{
        const url=""
        const response=await axios.put(url,{
            Nombre:data.nombre,
            Apellido1:data.apellido1,
            Apellido2:data.apellido2,
            Edada:data.edad,
            Fecha:data.fecha,
            Peso:data.peso,
            Imc:data.imc,
            Pais:data.pais,
            Cuello:data.cuello,
            Cadera:data.cadera,
            Musculo:data.musculo,
            Grasa:data.grasa,
            Calorias:data.calorias,
            PesoActual:data.pesoActual,
            Correo:data.correo,
            Password:data.password
    
        })
        console.log(response)
    }
    const [data,setData]=useState(dataInit)
    const handlerData=(event)=>{
        setData({...data, [event.target.name]: event.target.value})
    }
    return(
        <div >
            <BarraNav/>
                <div className='registro-cliente'>           
                <form className='form-registro-cliente'>
                    
                    <label htmlFor="nombre" className="label-nombre">Nombre</label>
                    <input type='text' name='nombre' onChange={handlerData}/>
            
                    <label htmlFor="" className="label-apellido1">Apellido1</label>
                    <input type="text" name="apellido1" onChange={handlerData}/>
         
                    <label htmlFor="" className="label-apellido2">Apellido2</label>
                    <input name='apellido2' onChange={handlerData}/>
                   
                    <label htmlFor="" className="label-edad">Edad</label>
                    <input type="text" name='edad' onChange={handlerData}/>
                
                    <label htmlFor="" className="label-fecha">fecha</label>
                    <input type="date" name='fecha' onChange={handlerData}/>
                    
                    <label htmlFor="" className="label-peso">Peso</label>
                    <input type="text" name='peso' onChange={handlerData}/>
                    
                    <label htmlFor="" className="label-imc">IMC</label>
                    <input name='imc' onChange={handlerData}/>
                        
                    <label htmlFor="" className="label-imc">Pais de Residencia</label>
                    <input name='pais'  onChange={handlerData}/>
                
                    <label htmlFor="" className="label-pesoActual">Peso Actual</label>                      
                    <input type='text' name='pesoActual' onChange={handlerData}/>
                    
                    <label htmlFor="" className="label-cuello">Medida de Cuello</label>
                    <input type="text" name='cuello' onChange={handlerData}/>
                     
                    <label htmlFor="" className="">Medida de Cadera</label>
                    <input type="text" name='cadera' onChange={handlerData}/>
                        
                    <label htmlFor="" className="label-grasa">%Grasa</label>
                    <input type="text" name='grasa'onChange={handlerData}/>

                    <label htmlFor="" className="label-grasa">%Musculo</label>
                    <input type="text" name='musculo'onChange={handlerData}/>
                        
                    <label htmlFor="" className="label-consum-diario">Consumo de Calorias</label>
                    <input type="text" name='calorias' onChange={handlerData}/>
                    
                    <label>Gmail</label>                    
                    <input type="gmail" name='correo' onChange={handlerData}/>
    
                    <label>password</label>      
                    <input type="password" name='password' onChange={handlerData}/>
    
                    <button onClick={sendInformation} className='button-registro-cliente'>Enviar</button>

                </form>

            </div>
        </div>
    
    )
}

export default RegistroClient;