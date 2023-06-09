import React, { useState, useEffect } from 'react';
import axios from 'axios';

const GestionPlan = () => {
  const [planNombre, setPlanNombre] = useState('');
  const [nutricionista, setNutricionista] = useState('');
  const [productos, setProductos] = useState([]);
 
  const [tiemposComida, setTiemposComida] = useState({
    Desayuno: [],
    MeriendaManana: [],
    Almuerzo: [],
    MeriendaTarde: [],
    Cena: []
  });
   
  // Simulación de llamada a la API para obtener los productos
  const fetchProductos = async () => {
    const url='https://apinutritecbd.azurewebsites.net/Externos/VisualizarProductosDisponibles'
    try{const response= await axios.get(url)

    setProductos(response.data);}
    catch(error){
      console.error(error)
    }
  };

  // Realizar la petición a la API para obtener los productos
  useEffect(() => {
    fetchProductos();
  }, []);

  const agregarProducto = (producto, tiempoComida) => {
    setTiemposComida(prevState => ({
      ...prevState,
      [tiempoComida]: [...prevState[tiempoComida], producto]
    }));
  };

  const enviarDatos = () => {
    if (!nutricionista || !planNombre) {
      alert('Por favor, complete todos los campos.');
      return;
    }
  
    const datos = {
      planNombre,
      nutricionista:localStorage.getItem('cedula'),
      tiemposComida
    };
    console.log(datos)

    axios
      .post('https://apinutritecbd.azurewebsites.net/Nutricionista/CrearPlanAlimentacion', datos)
      .then(response => {
        // Aquí puedes manejar la respuesta de la API
        alert('Los datos han sido enviados correctamente.');
      })
      .catch(error => {
        // Aquí puedes manejar los errores de la API
        console.error('Error al enviar los datos:', error);
      });
  };

  return (
    <div className="container">
      <h2 className="my-4">Gestión de Plan de Alimentación</h2>
      <div className="mb-3">
        <label htmlFor="planNombre" className="form-label">
          Nombre del plan:
        </label>
        <input
          type="text"
          className="form-control"
          id="planNombre"
          value={planNombre}
          onChange={e => setPlanNombre(e.target.value)}
        />
      </div>
      <div className="mb-3">
        <label htmlFor="nutricionista" className="form-label">
          Nutricionista:
        </label>
        <input
          type="text"
          className="form-control"
          id="nutricionista"
          value={nutricionista}
          onChange={e => setNutricionista(e.target.value)}
        />
      </div>

      <h3 className="my-4">Productos disponibles</h3>
      <table className="table">
        <thead>
          <tr>
            <th>Nombre</th>
            <th>Código de Barras</th>
            <th>Descripción</th>
            <th>Tamaño de Porción (g/ml)</th>
            <th>Energía (Kcal)</th>
            <th>Grasa (g)</th>
            <th>Sodio (mg)</th>
            <th>Carbohidratos (g)</th>
            <th>Proteína (g)</th>
            <th>Vitaminas</th>
            <th>Calcio (mg)</th>
            <th>Hierro (mg)</th>
            <th></th>
            <th></th>
            <th></th>
            <th></th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {productos.map(producto => (
            <tr key={producto.codigobarra}>
              <td>{producto.nombre}</td>
              <td>{producto.codigoBarras}</td>
              <td>{producto.descripcion}</td>
              <td>{producto.taman_porcion}</td>
              <td>{producto.energia}</td>
              <td>{producto.grasa}</td>
              <td>{producto.sodio}</td>
              <td>{producto.carbohidratos}</td>
              <td>{producto.proteina}</td>
              <td>{producto.vitaminas}</td>
              <td>{producto.calcio}</td>
              <td>{producto.hierro}</td>
              <td>
                <button
                  className="btn btn-primary"
                  onClick={() => agregarProducto(producto, 'Desayuno')}
                >
                  Agregar a Desayuno
                </button>
              </td>
              <td>
                <button
                  className="btn btn-primary"
                  onClick={() => agregarProducto(producto, 'MeriendaManana')}
                >
                  Agregar a Merienda Mañana
                </button>
              </td>
              <td>
                <button
                  className="btn btn-primary"
                  onClick={() => agregarProducto(producto, 'Almuerzo')}
                >
                  Agregar a Almuerzo
                </button>
              </td>
              <td>
                <button
                  className="btn btn-primary"
                  onClick={() => agregarProducto(producto, 'MeriendaTarde')}
                >
                  Agregar a Merienda Tarde
                </button>
              </td>
              <td>
                <button
                  className="btn btn-primary"
                  onClick={() => agregarProducto(producto, 'Cena')}
                >
                  Agregar a Cena
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>

      <h3 className="my-4">Plan de Alimentación</h3>
      <p>Nombre del plan: {planNombre}</p>
      <p>Nutricionista: {nutricionista}</p>
      <h4>Desayuno</h4>
      <ul>
        {tiemposComida.Desayuno.map(producto => (
          <li key={producto.codigobarra}>{producto.nombre}</li>
        ))}
      </ul>
      <h4>Merienda Mañana</h4>
      <ul>
        {tiemposComida.MeriendaManana.map(producto => (
          <li key={producto.codigobarra}>{producto.nombre}</li>
        ))}
      </ul>
      <h4>Almuerzo</h4>
      <ul>
        {tiemposComida.Almuerzo.map(producto => (
          <li key={producto.codigobarra}>{producto.nombre}</li>
        ))}
      </ul>
      <h4>Merienda Tarde</h4>
      <ul>
        {tiemposComida.MeriendaTarde.map(producto => (
          <li key={producto.codigobarra}>{producto.nombre}</li>
        ))}
      </ul>
      <h4>Cena</h4>
      <ul>
        {tiemposComida.Cena.map(producto => (
          <li key={producto.codigobarra}>{producto.nombre}</li>
        ))}
      </ul>

      <button className="btn btn-primary" onClick={enviarDatos}>
        Enviar Datos
      </button>
    </div>
  );
};

export default GestionPlan;
