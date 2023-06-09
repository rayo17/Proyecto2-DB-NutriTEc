import React, { useState, useEffect } from 'react';
import { View, Text, TextInput, Button, FlatList } from 'react-native';
import axios from 'axios';

const Receta = () => {
  const [productos, setProductos] = useState([]);
  const [receta, setReceta] = useState([]);
  const [nombreReceta, setNombreReceta] = useState('');
  const [puedeEnviarReceta, setPuedeEnviarReceta] = useState(false);

  useEffect(() => {
    ObtenerProductos();
  }, []);

  // Función para simular la obtención de los productos desde la API
  const ObtenerProductos = async () => {
    try {
      const response = await axios.get('https://apinutritecbd.azurewebsites.net/Externos/VisualizarProductosDisponibles');
      setProductos(response.data);
    } catch (error) {
      console.error(error);
    }
  };

  // Función para agregar un producto a la receta
  const agregarProductoReceta = (producto) => {
    setReceta([...receta, producto]);
    setPuedeEnviarReceta(true);
  };

  // Función para manejar el cambio en el nombre de la receta
  const handleNombreRecetaChange = (value) => {
    setNombreReceta(value);
    setPuedeEnviarReceta(false);
  };

  // Función para enviar la receta a la API
  const enviarReceta = () => {
    if (nombreReceta !== '' && receta.length > 0) {
      const recetaData = {
        nombre: nombreReceta,
        productos: receta
      };
      console.log(recetaData);

      axios
        .post('https://apinutritecbd.azurewebsites.net/Externos/crearreceta', recetaData)
        .then((response) => {
          // Manejar la respuesta de la API si es necesario
          alert('Su receta fue registrada correctamente');
        })
        .catch((error) => {
          alert('Su receta no se ha podido registrar');
          console.error(error);
        });
    }
  };

  const eliminarElemento = (elemento) => {
    const nuevaLista = receta.filter((item) => item.codigobarra !== elemento.codigobarra);
    setReceta(nuevaLista);
  };

  return (
    <View style={{ flex: 1, marginTop: 16 }}>
      <Text>Receta</Text>

      {/* Formulario para el nombre de la receta */}
      <View>
        <Text>Nombre de la Receta:</Text>
        <TextInput
          style={{ borderWidth: 1, borderColor: 'gray', padding: 8 }}
          value={nombreReceta}
          onChangeText={handleNombreRecetaChange}
        />
      </View>

      {/* Lista de productos */}
      <Text>Productos:</Text>
      <FlatList
        data={productos}
        keyExtractor={(item) => item.codigobarra}
        renderItem={({ item }) => (
          <View>
            <Text>Nombre: {item.nombre}</Text>
            <Text>Código de barras único: {item.codigobarra}</Text>
            {/* Resto de campos del producto */}
            <Button title="Agregar a la receta" onPress={() => agregarProductoReceta(item)} />
          </View>
        )}
      />

      {/* Lista de la receta */}
      <Text>Lista de Receta: {nombreReceta}</Text>
      <FlatList
        data={receta}
        keyExtractor={(item) => item.id.toString()}
        renderItem={({ item }) => (
          <View>
            <Text>Nombre: {item.nombre}</Text>
            <Text>Código de barras único: {item.codigoBarras}</Text>
            {/* Resto de campos del producto */}
            <Button title="Eliminar" onPress={() => eliminarElemento(item)} />
          </View>
        )}
      />

      {/* Botón para enviar la receta */}
      <Button
        title="Enviar Receta"
        onPress={enviarReceta}
        disabled={!puedeEnviarReceta}
      />
    </View>
  );
};

export default Receta;
