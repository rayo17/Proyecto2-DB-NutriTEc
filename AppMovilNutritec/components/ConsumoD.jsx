import React, { useState } from 'react';
import { View, Text, TextInput, Button, FlatList, StyleSheet,ScrollView } from 'react-native';

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
  const [filtro, setFiltro] = useState('');

  // Simulación de la búsqueda de alimentos
  const buscarAlimentosSimulado = () => {
    const alimentosSimulados = [
      {
        nombre: 'Manzana',
        codigoBarras: '123456789',
        descripcion: 'Una deliciosa manzana',
        tamanoPorcion: 100,
        energia: 52,
        grasa: 0.2,
        sodio: 1,
        carbohidratos: 14,
        proteina: 0.3,
        vitaminas: 'A, C',
        calcio: 6,
        hierro: 0.1,
      },
      {
        nombre: 'Banana',
        codigoBarras: '987654321',
        descripcion: 'Una sabrosa banana',
        tamanoPorcion: 120,
        energia: 96,
        grasa: 0.2,
        sodio: 1,
        carbohidratos: 23,
        proteina: 1.1,
        vitaminas: 'A, C',
        calcio: 6,
        hierro: 0.3,
      },
      // Agrega más alimentos simulados aquí
    ];

    // Aplicar filtros de búsqueda
    let alimentosFiltrados = alimentosSimulados;
    if (filtro === 'nombre' && busqueda.trim() !== '') {
      alimentosFiltrados = alimentosFiltrados.filter(alimento => alimento.nombre.toLowerCase().includes(busqueda.toLowerCase()));
    } else if (filtro === 'codigo' && busqueda.trim() !== '') {
      alimentosFiltrados = alimentosFiltrados.filter(alimento => alimento.codigoBarras.toLowerCase().includes(busqueda.toLowerCase()));
    }

    setAlimentos(alimentosFiltrados);
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
            placeholder="Escribe el nombre o código del alimento"
            placeholderTextColor="#666"
          />
          <Button
            title="Buscar"
            onPress={buscarAlimentosSimulado}
            color="#2196F3"
          />
        </View>

        <View style={styles.filterContainer}>
          <Text style={styles.filterLabel}>Filtrar por:</Text>
          <Button
            title="Nombre"
            onPress={() => setFiltro('nombre')}
            color={filtro === 'nombre' ? '#2196F3' : '#999'}
          />
          <Button
            title="Código"
            onPress={() => setFiltro('codigo')}
            color={filtro === 'codigo' ? '#2196F3' : '#999'}
          />
        </View>
        
        <FlatList
          style={styles.resultsList}
          data={alimentos}
          keyExtractor={(item, index) => index.toString()}
          renderItem={({ item }) => (
            <View style={styles.resultItem}>
              <Text style={styles.resultText}>{item.nombre}</Text>
              <Text style={styles.resultDescription}>{item.descripcion}</Text>
              <Text style={styles.resultNutrition}>Tamaño porción: {item.tamanoPorcion} g/ml</Text>
              <Text style={styles.resultNutrition}>Energía: {item.energia} Kcal</Text>
              <Text style={styles.resultNutrition}>Grasa: {item.grasa} g</Text>
              <Text style={styles.resultNutrition}>Sodio: {item.sodio} mg</Text>
              <Text style={styles.resultNutrition}>Carbohidratos: {item.carbohidratos} g</Text>
              <Text style={styles.resultNutrition}>Proteína: {item.proteina} g</Text>
              <Text style={styles.resultNutrition}>Vitaminas: {item.vitaminas}</Text>
              <Text style={styles.resultNutrition}>Calcio: {item.calcio} mg</Text>
              <Text style={styles.resultNutrition}>Hierro: {item.hierro} mg</Text>
              <Button
                title="Agregar"
                onPress={() => agregarAlimento(item.nombre, 'desayuno')}
                color="#2196F3"
              />
              <Button
                title="Agregar"
                onPress={() => agregarAlimento(item.nombre, 'mediaManana')}
                color="#2196F3"
              />
              <Button
                title="Agregar"
                onPress={() => agregarAlimento(item.nombre, 'almuerzo')}
                color="#2196F3"
              />
              <Button
                title="Agregar"
                onPress={() => agregarAlimento(item.nombre, 'merienda')}
                color="#2196F3"
              />
              <Button
                title="Agregar"
                onPress={() => agregarAlimento(item.nombre, 'cena')}
                color="#2196F3"
              />
            </View>
          )}
        />
      </View>

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
  filterContainer: {
    flexDirection: 'row',
    marginBottom: 10,
    justifyContent: 'center',
  },
  filterLabel: {
    fontSize: 16,
    marginRight: 10,
    color: '#333',
  },
  resultsList: {
    marginBottom: 10,
  },
  resultItem: {
    marginBottom: 10,
    paddingVertical: 12,
    paddingHorizontal: 16,
    borderWidth: 1,
    borderColor: '#CCC',
    borderRadius: 8,
    backgroundColor: '#FFF',
  },
  resultText: {
    fontSize: 18,
    fontWeight: 'bold',
    color: '#333',
    marginBottom: 2,
  },
  resultDescription: {
    fontSize: 14,
    color: '#666',
    marginBottom: 2,
  },
  resultNutrition: {
    fontSize: 12,
    color: '#666',
    marginBottom: 2,
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

