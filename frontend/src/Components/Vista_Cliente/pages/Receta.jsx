import React, { useState, useEffect } from 'react';
import axios from 'axios';

const Receta = () => {
  const [productos, setProductos] = useState([]);
  const [receta, setReceta] = useState([]);
  const [nombreReceta, setNombreReceta] = useState('');
  const [puedeEnviarReceta, setPuedeEnviarReceta] = useState(false);

  useEffect(() => {
    simularObtenerProductos();
  }, []);

  // Función para simular la obtención de los productos desde la API
  const simularObtenerProductos = () => {
    // Datos estáticos de ejemplo
    const datosProductos = [
      {
        id: 1,
        nombre: 'Producto 1',
        codigoBarras: '1234567890',
        descripcion: 'Descripción del producto 1',
        tamPorcion: '100g',
        energia: '200 Kcal',
        grasa: '10g',
        sodio: '100mg',
        carbohidratos: '20g',
        proteina: '5g',
        vitaminas: 'Vitamina A, Vitamina C',
        calcio: '50mg',
        hierro: '2mg'
      },
      {
        id: 2,
        nombre: 'Producto 2',
        codigoBarras: '0987654321',
        descripcion: 'Descripción del producto 2',
        tamPorcion: '50g',
        energia: '150 Kcal',
        grasa: '8g',
        sodio: '80mg',
        carbohidratos: '15g',
        proteina: '3g',
        vitaminas: 'Vitamina B, Vitamina D',
        calcio: '30mg',
        hierro: '1mg'
      }
    ];

    setProductos(datosProductos);
  };

  // Función para agregar un producto a la receta
  const agregarProductoReceta = (producto) => {
    setReceta([...receta, producto]);
    setPuedeEnviarReceta(true);
  };

  // Función para manejar el cambio en el nombre de la receta
  const handleNombreRecetaChange = (e) => {
    setNombreReceta(e.target.value);
    setPuedeEnviarReceta(false);
  };

  // Función para enviar la receta a la API
  const enviarReceta = () => {
    if (nombreReceta !== '' && receta.length > 0) {
      const recetaData = {
        nombre: nombreReceta,
        productos: receta
      };

      axios.post('http://localhost:8000/Cliente/registrarcliente', recetaData)
        .then((response) => {
          // Manejar la respuesta de la API si es necesario
          console.log(response.data);
        })
        .catch((error) => {
          // Manejar el error si ocurre
          console.error(error);
        });
    }
  };

  return (
    <div className="container mt-4">
      <h1>Receta</h1>

      {/* Formulario para el nombre de la receta */}
      <form>
        <div className="mb-3">
          <label htmlFor="nombreReceta" className="form-label">Nombre de la Receta:</label>
          <input
            type="text"
            className="form-control"
            id="nombreReceta"
            value={nombreReceta}
            onChange={handleNombreRecetaChange}
          />
        </div>
      </form>

      {/* Tabla de productos */}
      <h2>Productos:</h2>
      <table className="table">
        <thead>
          <tr>
            <th>Nombre</th>
            <th>Código de barras único</th>
            <th>Descripción</th>
            <th>Tamaño de la porción (g/ml)</th>
            <th>Energía (Kcal)</th>
            <th>Grasa (g)</th>
            <th>Sodio (mg)</th>
            <th>Carbohidratos (g)</th>
            <th>Proteína (g)</th>
            <th>Vitaminas</th>
            <th>Calcio (mg)</th>
            <th>Hierro (mg)</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {productos.map((producto) => (
            <tr key={producto.id}>
              <td>{producto.nombre}</td>
              <td>{producto.codigoBarras}</td>
              <td>{producto.descripcion}</td>
              <td>{producto.tamPorcion}</td>
              <td>{producto.energia}</td>
              <td>{producto.grasa}</td>
              <td>{producto.sodio}</td>
              <td>{producto.carbohidratos}</td>
              <td>{producto.proteina}</td>
              <td>{producto.vitaminas}</td>
              <td>{producto.calcio}</td>
              <td>{producto.hierro}</td>
              <td>
                <button className="btn btn-primary" onClick={() => agregarProductoReceta(producto)}>
                  Agregar a la receta
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>

      {/* Tabla de la lista de receta */}
      <h2>Lista de Receta: {nombreReceta}</h2>
      <table className="table">
        <thead>
          <tr>
            <th>Nombre</th>
            <th>Código de barras único</th>
            <th>Descripción</th>
            <th>Tamaño de la porción (g/ml)</th>
            <th>Energía (Kcal)</th>
            <th>Grasa (g)</th>
            <th>Sodio (mg)</th>
            <th>Carbohidratos (g)</th>
            <th>Proteína (g)</th>
            <th>Vitaminas</th>
            <th>Calcio (mg)</th>
            <th>Hierro (mg)</th>
          </tr>
        </thead>
        <tbody>
          {receta.map((producto) => (
            <tr key={producto.id}>
              <td>{producto.nombre}</td>
              <td>{producto.codigoBarras}</td>
              <td>{producto.descripcion}</td>
              <td>{producto.tamPorcion}</td>
              <td>{producto.energia}</td>
              <td>{producto.grasa}</td>
              <td>{producto.sodio}</td>
              <td>{producto.carbohidratos}</td>
              <td>{producto.proteina}</td>
              <td>{producto.vitaminas}</td>
              <td>{producto.calcio}</td>
              <td>{producto.hierro}</td>
            </tr>
          ))}
        </tbody>
      </table>

      {/* Botón para enviar la receta */}
      <button
        className="btn btn-primary"
        onClick={enviarReceta}
        disabled={!puedeEnviarReceta}
      >
        Enviar Receta
      </button>
    </div>
  );
};

export default Receta;
