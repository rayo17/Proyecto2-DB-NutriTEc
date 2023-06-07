import React, { useState,useEffect } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import axios from 'axios';
import '../../../styleCss/Cliente/RegistroDC.css'

function RegistroDiarioDeConsumo() {
  const [desayuno, setDesayuno] = useState([]);
  const [meriendaManana, setMeriendaManana] = useState([]);
  const [almuerzo, setAlmuerzo] = useState([]);
  const [meriendaTarde, setMeriendaTarde] = useState([]);
  const [cena, setCena] = useState([]);
  const [busqueda, setBusqueda] = useState('');
  const [filtro, setFiltro] = useState('nombre');
  const [alimentosEncontrados, setAlimentosEncontrados] = useState([]);
  const [productos,setProductos]=useState([])
  const [fechaRegistro, setFechaRegistro] = useState('');

  const buscarAlimento = () => {
    try{
    const alimentosEncontrados = filtro === 'nombre'
      ? productos.filter(alimento => alimento.nombre.toLowerCase().includes(busqueda.toLowerCase()))
      : productos.filter(alimento => alimento.codigo === busqueda);
  
    setAlimentosEncontrados(alimentosEncontrados);}
    catch(error){
      console.log(error)
    }
  };

   //Esta funcion trae todos los productos para poder realizar el consumo diario
  const requestProduct=async()=>{
     //se realiza la peticion para cargar los productos 
    const url="https://apinutritecbd.azurewebsites.net/Externos/VisualizarProductosDisponibles"
    try{
      const response=await axios.get(url)
    setProductos(response.data)
     }
     catch(error){
        console.log(error)
     }

     
  }
  useEffect(()=>{
    requestProduct()
  },[])

  const agregarAlimento = (alimento, tiempoComida) => {
    if (fechaRegistro) {
      const registro = { alimento, tiempoComida, fecha: fechaRegistro };

      switch (tiempoComida) {
        case 'desayuno':
          setDesayuno([...desayuno, registro]);
          break;
        case 'meriendaManana':
          setMeriendaManana([...meriendaManana, registro]);
          break;
        case 'almuerzo':
          setAlmuerzo([...almuerzo, registro]);
          break;
        case 'meriendaTarde':
          setMeriendaTarde([...meriendaTarde, registro]);
          break;
        case 'cena':
          setCena([...cena, registro]);
          break;
        default:
          break;
      }
    } else {
      alert('Selecciona una fecha para agregar alimentos.');
    }
  };

  const guardarRegistro = () => {
    const registroDiario = { desayuno, meriendaManana, almuerzo, meriendaTarde, cena };

    // Envio del registro del consumo diario al backend
     axios.post('/api/registro-diario', registroDiario)
     .then(response => {
         console.log('Registro guardado exitosamente');
       })
       .catch(error => {
         console.error('Error al guardar el registro', error);
      });
    console.log(registroDiario);
  };

  return (
    <div className="container mt-4 registro-container">
      <h2>Registro Diario de Consumo</h2>
      <div className="row">
        <div className="col-md-4">
          <div className="mb-3">
            <label htmlFor="fechaRegistro" className="form-label">Fecha de Registro</label>
            <input type="date" className="form-control" id="fechaRegistro" value={fechaRegistro} onChange={e => setFechaRegistro(e.target.value)} />
          </div>
          <div className="mb-3">
            <label htmlFor="busqueda" className="form-label">Buscar Alimento</label>
            <div className="input-group">
              <input type="text" className="form-control" id="busqueda" value={busqueda} onChange={e => setBusqueda(e.target.value)} />
              <select className="form-select" onChange={e => setFiltro(e.target.value)}>
                <option value="nombre">Nombre</option>
                <option value="codigo">Código de Barras</option>
              </select>
              <button className="btn btn-primary" onClick={buscarAlimento}>Buscar</button>
            </div>
          </div>
        </div>
        <div className="col-md-8">
          {alimentosEncontrados.length > 0 && (
            <div className="mt-4">
              <h4>Alimentos encontrados:</h4>
              <table className="table">
                <thead>
                  <tr>
                    <th>Nombre</th>
                    <th>Código de Barras</th>
                    <th>Descripción</th>
                    <th>Tamaño porción</th>
                    <th>Energía</th>
                    <th>Grasa</th>
                    <th>Sodio</th>
                    <th>Carbohidratos</th>
                    <th>Proteína</th>
                    <th>Vitaminas</th>
                    <th>Calcio</th>
                    <th>Hierro</th>
                    <th>Acciones</th>
                  </tr>
                </thead>
                <tbody>
                  {alimentosEncontrados.map((alimento, index) => (
                    <tr key={index}>
                      <td>{alimento.nombre}</td>
                      <td>{alimento.codigo}</td>
                      <td>{alimento.descripcion}</td>
                      <td>{alimento.tamanoPorcion}</td>
                      <td>{alimento.energia}</td>
                      <td>{alimento.grasa}</td>
                      <td>{alimento.sodio}</td>
                      <td>{alimento.carbohidratos}</td>
                      <td>{alimento.proteina}</td>
                      <td>{alimento.vitaminas}</td>
                      <td>{alimento.calcio}</td>
                      <td>{alimento.hierro}</td>
                      <td>
                        <button className="btn btn-sm btn-success" onClick={() => agregarAlimento(alimento, 'desayuno')}>Desayuno</button>
                        <button className="btn btn-sm btn-success" onClick={() => agregarAlimento(alimento, 'meriendaManana')}>Merienda Mañana</button>
                        <button className="btn btn-sm btn-success" onClick={() => agregarAlimento(alimento, 'almuerzo')}>Almuerzo</button>
                        <button className="btn btn-sm btn-success" onClick={() => agregarAlimento(alimento, 'meriendaTarde')}>Merienda Tarde</button>
                        <button className="btn btn-sm btn-success" onClick={() => agregarAlimento(alimento, 'cena')}>Cena</button>
                      </td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
          )}
          <div className="mt-4">
            <h4>Registro Diario de Consumo</h4>
            {desayuno.length > 0 && (
              <div>
                <h5>Desayuno</h5>
                <table className="table">
                  <thead>
                    <tr>
                      <th>Nombre</th>
                      <th>Código de Barras</th>
                      <th>Descripción</th>
                      <th>Tamaño porción</th>
                      <th>Energía</th>
                      <th>Grasa</th>
                      <th>Sodio</th>
                      <th>Carbohidratos</th>
                      <th>Proteína</th>
                      <th>Vitaminas</th>
                      <th>Calcio</th>
                      <th>Hierro</th>
                    </tr>
                  </thead>
                  <tbody>
                    {desayuno.map((alimento, index) => (
                      <tr key={index}>
                        <td>{alimento.alimento.nombre}</td>
                        <td>{alimento.alimento.codigo}</td>
                        <td>{alimento.alimento.descripcion}</td>
                        <td>{alimento.alimento.tamanoPorcion}</td>
                        <td>{alimento.alimento.energia}</td>
                        <td>{alimento.alimento.grasa}</td>
                        <td>{alimento.alimento.sodio}</td>
                        <td>{alimento.alimento.carbohidratos}</td>
                        <td>{alimento.alimento.proteina}</td>
                        <td>{alimento.alimento.vitaminas}</td>
                        <td>{alimento.alimento.calcio}</td>
                        <td>{alimento.alimento.hierro}</td>
                      </tr>
                    ))}
                  </tbody>
                </table>
              </div>
            )}
            {meriendaManana.length > 0 && (
              <div>
                <h5>Merienda Mañana</h5>
                <table className="table">
                  <thead>
                    <tr>
                      <th>Nombre</th>
                      <th>Código de Barras</th>
                      <th>Descripción</th>
                      <th>Tamaño porción</th>
                      <th>Energía</th>
                      <th>Grasa</th>
                      <th>Sodio</th>
                      <th>Carbohidratos</th>
                      <th>Proteína</th>
                      <th>Vitaminas</th>
                      <th>Calcio</th>
                      <th>Hierro</th>
                    </tr>
                  </thead>
                  <tbody>
                    {meriendaManana.map((alimento, index) => (
                      <tr key={index}>
                        <td>{alimento.alimento.nombre}</td>
                        <td>{alimento.alimento.codigo}</td>
                        <td>{alimento.alimento.descripcion}</td>
                        <td>{alimento.alimento.tamanoPorcion}</td>
                        <td>{alimento.alimento.energia}</td>
                        <td>{alimento.alimento.grasa}</td>
                        <td>{alimento.alimento.sodio}</td>
                        <td>{alimento.alimento.carbohidratos}</td>
                        <td>{alimento.alimento.proteina}</td>
                        <td>{alimento.alimento.vitaminas}</td>
                        <td>{alimento.alimento.calcio}</td>
                        <td>{alimento.alimento.hierro}</td>
                      </tr>
                    ))}
                  </tbody>
                </table>
              </div>
            )}
            {almuerzo.length > 0 && (
              <div>
                <h5>Almuerzo</h5>
                <table className="table">
                  <thead>
                    <tr>
                      <th>Nombre</th>
                      <th>Código de Barras</th>
                      <th>Descripción</th>
                      <th>Tamaño porción</th>
                      <th>Energía</th>
                      <th>Grasa</th>
                      <th>Sodio</th>
                      <th>Carbohidratos</th>
                      <th>Proteína</th>
                      <th>Vitaminas</th>
                      <th>Calcio</th>
                      <th>Hierro</th>
                    </tr>
                  </thead>
                  <tbody>
                    {almuerzo.map((alimento, index) => (
                      <tr key={index}>
                        <td>{alimento.alimento.nombre}</td>
                        <td>{alimento.alimento.codigo}</td>
                        <td>{alimento.alimento.descripcion}</td>
                        <td>{alimento.alimento.tamanoPorcion}</td>
                        <td>{alimento.alimento.energia}</td>
                        <td>{alimento.alimento.grasa}</td>
                        <td>{alimento.alimento.sodio}</td>
                        <td>{alimento.alimento.carbohidratos}</td>
                        <td>{alimento.alimento.proteina}</td>
                        <td>{alimento.alimento.vitaminas}</td>
                        <td>{alimento.alimento.calcio}</td>
                        <td>{alimento.alimento.hierro}</td>
                      </tr>
                    ))}
                  </tbody>
                </table>
              </div>
            )}
            {meriendaTarde.length > 0 && (
              <div>
                <h5>Merienda Tarde</h5>
                <table className="table">
                  <thead>
                    <tr>
                      <th>Nombre</th>
                      <th>Código de Barras</th>
                      <th>Descripción</th>
                      <th>Tamaño porción</th>
                      <th>Energía</th>
                      <th>Grasa</th>
                      <th>Sodio</th>
                      <th>Carbohidratos</th>
                      <th>Proteína</th>
                      <th>Vitaminas</th>
                      <th>Calcio</th>
                      <th>Hierro</th>
                    </tr>
                  </thead>
                  <tbody>
                    {meriendaTarde.map((alimento, index) => (
                      <tr key={index}>
                        <td>{alimento.alimento.nombre}</td>
                        <td>{alimento.alimento.codigo}</td>
                        <td>{alimento.alimento.descripcion}</td>
                        <td>{alimento.alimento.tamanoPorcion}</td>
                        <td>{alimento.alimento.energia}</td>
                        <td>{alimento.alimento.grasa}</td>
                        <td>{alimento.alimento.sodio}</td>
                        <td>{alimento.alimento.carbohidratos}</td>
                        <td>{alimento.alimento.proteina}</td>
                        <td>{alimento.alimento.vitaminas}</td>
                        <td>{alimento.alimento.calcio}</td>
                        <td>{alimento.alimento.hierro}</td>
                      </tr>
                    ))}
                  </tbody>
                </table>
              </div>
            )}
            {cena.length > 0 && (
              <div>
                <h5>Cena</h5>
                <table className="table">
                  <thead>
                    <tr>
                      <th>Nombre</th>
                      <th>Código de Barras</th>
                      <th>Descripción</th>
                      <th>Tamaño porción</th>
                      <th>Energía</th>
                      <th>Grasa</th>
                      <th>Sodio</th>
                      <th>Carbohidratos</th>
                      <th>Proteína</th>
                      <th>Vitaminas</th>
                      <th>Calcio</th>
                      <th>Hierro</th>
                    </tr>
                  </thead>
                  <tbody>
                    {cena.map((alimento, index) => (
                      <tr key={index}>
                        <td>{alimento.alimento.nombre}</td>
                        <td>{alimento.alimento.codigo}</td>
                        <td>{alimento.alimento.descripcion}</td>
                        <td>{alimento.alimento.tamanoPorcion}</td>
                        <td>{alimento.alimento.energia}</td>
                        <td>{alimento.alimento.grasa}</td>
                        <td>{alimento.alimento.sodio}</td>
                        <td>{alimento.alimento.carbohidratos}</td>
                        <td>{alimento.alimento.proteina}</td>
                        <td>{alimento.alimento.vitaminas}</td>
                        <td>{alimento.alimento.calcio}</td>
                        <td>{alimento.alimento.hierro}</td>
                      </tr>
                    ))}
                  </tbody>
                </table>
              </div>
            )}
          </div>
          {fechaRegistro && (
            <div className="mt-4">
              <button className="btn btn-primary " onClick={guardarRegistro}>Guardar Registro</button>
            </div>
          )}
        </div>
      </div>
    </div>
  );
}

export default RegistroDiarioDeConsumo;
