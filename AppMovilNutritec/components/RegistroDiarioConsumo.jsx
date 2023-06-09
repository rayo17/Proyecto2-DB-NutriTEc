import React, { useState } from 'react';
import { View, Text, TextInput, Button, FlatList } from 'react-native';

const RegistroDiarioDeConsumo = () => {
  const [searchTerm, setSearchTerm] = useState('');
  const [foodData, setFoodData] = useState([]);

  const searchFood = () => {
    // Realizar aquí la lógica de búsqueda de alimentos y actualizar el estado de foodData con los resultados obtenidos
    // Por simplicidad, en este ejemplo simplemente se establece un conjunto fijo de datos

    const data = [
      { codigo: '001', nombre: 'Manzana', descripcion: 'Fruta fresca', tamanoPorcion: '1 unidad', energia: 52, grasa: 0.2, sodio: 0, carbohidratos: 14, proteina: 0.3, vitaminas: 'Vitamina C', calcio: 6, hierro: 0.1 },
      { codigo: '002', nombre: 'Plátano', descripcion: 'Fruta fresca', tamanoPorcion: '1 unidad', energia: 96, grasa: 0.2, sodio: 1, carbohidratos: 25, proteina: 1.2, vitaminas: 'Vitamina C, Vitamina B6', calcio: 6, hierro: 0.3 },
      { codigo: '003', nombre: 'Yogur', descripcion: 'Producto lácteo', tamanoPorcion: '1 envase', energia: 150, grasa: 3.5, sodio: 70, carbohidratos: 27, proteina: 5, vitaminas: 'Vitamina D, Vitamina B12', calcio: 200, hierro: 0.2 },
      // Agrega más alimentos según tus necesidades
    ];

    // Filtrar los alimentos según el término de búsqueda
    const filteredData = data.filter(item =>
      item.nombre.toLowerCase().includes(searchTerm.toLowerCase())
    );

    setFoodData(filteredData);
  };

  return (
    <View>
      <Text>Registro Diario de Consumo</Text>

      <TextInput
        placeholder="Buscar alimentos..."
        value={searchTerm}
        onChangeText={text => setSearchTerm(text)}
      />
      <Button title="Buscar" onPress={searchFood} />

      {foodData.length > 0 && (
        <View>
          <Text>Resultados de búsqueda:</Text>
          <FlatList
            data={foodData}
            keyExtractor={(item, index) => index.toString()}
            renderItem={({ item }) => (
              <View style={{ marginBottom: 8 }}>
                <Text>Código: {item.codigo}</Text>
                <Text>Nombre: {item.nombre}</Text>
                <Text>Descripción: {item.descripcion}</Text>
                <Text>Tamaño de porción: {item.tamanoPorcion}</Text>
                <Text>Energía: {item.energia} kcal</Text>
                <Text>Grasa: {item.grasa} g</Text>
                <Text>Sodio: {item.sodio} mg</Text>
                <Text>Carbohidratos: {item.carbohidratos} g</Text>
                <Text>Proteína: {item.proteina} g</Text>
                <Text>Vitaminas: {item.vitaminas}</Text>
                <Text>Calcio: {item.calcio} mg</Text>
                <Text>Hierro: {item.hierro} mg</Text>
              </View>
            )}
          />
        </View>
      )}
    </View>
  );
};

export default RegistroDiarioDeConsumo;
