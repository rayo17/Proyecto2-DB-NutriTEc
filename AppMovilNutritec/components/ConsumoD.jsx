import React, { useState } from 'react';
import { View, Text, TextInput, Button, FlatList, StyleSheet } from 'react-native';
import axios from 'axios';

const RegistroDiarioConsumo = () => {
  const [alimentos, setAlimentos] = useState([]);
  const [consumoDiario, setConsumoDiario] = useState({
    desayuno: [],
    mediaManana: [],
    almuerzo: [],
    merienda: [],
    cena: []
  });
  const [busqueda, setBusqueda] = useState('');

  const buscarAlimentos = async () => {
    try {
      const response = await axios.get(`https://api.example.com/buscar?query=${busqueda}`);
      const alimentosEncontrados = response.data;
      setAlimentos(alimentosEncontrados);
    } catch (error) {
      console.error(error);
    }
  };

  const agregarAlimento = (alimento, tiempoComida) => {
    const nuevoConsumoDiario = { ...consumoDiario };
    nuevoConsumoDiario[tiempoComida] = [...nuevoConsumoDiario[tiempoComida], alimento];
    setConsumoDiario(nuevoConsumoDiario);
  };

  return (
    <View style={styles.container}>
      <Text style={styles.title}>Registro Diario de Consumo</Text>

      <View style={styles.searchContainer}>
        <Text style={styles.searchLabel}>Buscar Alimentos</Text>
        <View style={styles.searchInputContainer}>
          <TextInput
            style={styles.searchInput}
            value={busqueda}
            onChangeText={(text) => setBusqueda(text)}
            placeholder="Escribe el nombre del alimento"
            placeholderTextColor="#666"
          />
          <Button
            title="Buscar"
            onPress={buscarAlimentos}
            color="#2196F3"
          />
        </View>

        {/* Renderizar los resultados de búsqueda de alimentos aquí */}
        <FlatList
          style={styles.resultsList}
          data={alimentos}
          keyExtractor={(item, index) => index.toString()}
          renderItem={({ item }) => (
            <View style={styles.resultItem}>
              <Text style={styles.resultText}>{item.nombre}</Text>
              <Button
                title="Agregar"
                onPress={() => agregarAlimento(item.nombre, 'desayuno')}
                color="#2196F3"
              />
            </View>
          )}
        />
      </View>

      {/* Renderizar las secciones de tiempo de comida */}
      {Object.keys(consumoDiario).map((tiempoComida) => (
        <View style={styles.mealContainer} key={tiempoComida}>
          <Text style={styles.mealTitle}>{tiempoComida}</Text>
          <FlatList
            style={styles.mealList}
            data={consumoDiario[tiempoComida]}
            keyExtractor={(item, index) => index.toString()}
            renderItem={({ item }) => <Text style={styles.mealItem}>{item}</Text>}
          />
        </View>
      ))}
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding: 20,
    backgroundColor: '#F9F9F9',
  },
  title: {
    fontSize: 24,
    fontWeight: 'bold',
    marginBottom: 20,
    textAlign: 'center',
    color: '#333',
  },
  searchContainer: {
    marginBottom: 20,
    backgroundColor: '#FFF',
    padding: 20,
    borderRadius: 10,
    elevation: 2,
  },
  searchLabel: {
    fontSize: 18,
    marginBottom: 10,
    color: '#333',
  },
  searchInputContainer: {
    flexDirection: 'row',
    alignItems: 'center',
    marginBottom: 10,
  },
  searchInput: {
    flex: 1,
    height: 40,
    borderWidth: 1,
    borderColor: '#CCC',
    paddingHorizontal: 10,
    marginRight: 10,
    borderRadius: 5,
    color: '#333',
  },
  resultsList: {
    marginBottom: 10,
  },
  resultItem: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
    marginBottom: 10,
    paddingVertical: 12,
    paddingHorizontal: 16,
    borderWidth: 1,
    borderColor: '#CCC',
    borderRadius: 8,
    backgroundColor: '#FFF',
  },
  resultText: {
    fontSize: 16,
    color: '#333',
  },
  mealContainer: {
    marginBottom: 20,
    backgroundColor: '#FFF',
    padding: 20,
    borderRadius: 10,
    elevation: 2,
  },
  mealTitle: {
    fontSize: 18,
    fontWeight: 'bold',
    marginBottom: 10,
    color: '#333',
  },
  mealList: {
    marginBottom: 10,
  },
  mealItem: {
    fontSize: 16,
    marginBottom: 5,
    color: '#333',
  },
});

export default RegistroDiarioConsumo;

