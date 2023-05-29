import React,{useState} from 'react'
function RegistroMedidas(){
    const dataInit={
        fecha:"",
        cintura:"",
        cadera:"",
        musculo:"",
        grasa:"",
        cuello:""
    }
    const[data,setData]=useState(dataInit)
    const handlerData=(event)=>{
        setData({...data,[event.target.name]:event.target.value})
    }
    return (
        <div>
            <form>
                <label>fecha</label>
                <input name='fecha'/>
                <h1>Agrege las Medidas</h1>
                <div className='medidas'>
                    <label htmlFor="">Cintura</label>
                    <input type="text" name='cintura' onChange={handlerData}/>
                    <label htmlFor="">Cuello</label>
                    <input type="text" name='cuello' onChange={handlerData} />
                    <label htmlFor="">Cadera</label>
                    <input type="text" name='cadera' onChange={handlerData}/>
                    <label htmlFor="">% de Musculo</label>
                    <input type="text" name='musculo' onChange={handlerData}/>
                    <label htmlFor="">% de Grasa</label>
                    <input type="text" name='grasa' onChange={handlerData}/>
                </div>
            </form>
        </div>
    )
}

export default RegistroMedidas