import React, { useState, useEffect } from 'react';

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
    // Simulación de tiempo de espera para obtener los productos
    await new Promise(resolve => setTimeout(resolve, 1000));

    const productosData = [
      {
        codigoBarras: '123456789',
        nombre: 'Producto 1',
        descripcion: 'Descripción del producto 1',
        tamanoPorcion: '100g',
        energia: 200,
        grasa: 10,
        sodio: 100,
        carbohidratos: 20,
        proteina: 5,
        vitaminas: 'Vitamina A, Vitamina C',
        calcio: 50,
        hierro: 2
      },
      // ... Otros productos
    ];

    setProductos(productosData);
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

    // Aquí iría la lógica para enviar los datos al backend
    // ...
    alert('Los datos han sido enviados correctamente.');
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
            <tr key={producto.codigoBarras}>
              <td>{producto.nombre}</td>
              <td>{producto.codigoBarras}</td>
              <td>{producto.descripcion}</td>
              <td>{producto.tamanoPorcion}</td>
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
          <li key={producto.codigoBarras}>{producto.nombre}</li>
        ))}
      </ul>
      <h4>Merienda Mañana</h4>
      <ul>
        {tiemposComida.MeriendaManana.map(producto => (
          <li key={producto.codigoBarras}>{producto.nombre}</li>
        ))}
      </ul>
      <h4>Almuerzo</h4>
      <ul>
        {tiemposComida.Almuerzo.map(producto => (
          <li key={producto.codigoBarras}>{producto.nombre}</li>
        ))}
      </ul>
      <h4>Merienda Tarde</h4>
      <ul>
        {tiemposComida.MeriendaTarde.map(producto => (
          <li key={producto.codigoBarras}>{producto.nombre}</li>
        ))}
      </ul>
      <h4>Cena</h4>
      <ul>
        {tiemposComida.Cena.map(producto => (
          <li key={producto.codigoBarras}>{producto.nombre}</li>
        ))}
      </ul>

      <button className="btn btn-primary" onClick={enviarDatos}>
        Enviar Datos
      </button>
    </div>
  );
};

export default GestionPlan;
