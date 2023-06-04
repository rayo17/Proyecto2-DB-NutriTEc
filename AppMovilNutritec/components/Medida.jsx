import React, { useState } from 'react';
import { View, Text, TextInput, Button } from 'react-native';

const MedidasRegistro = () => {
  const [cintura, setCintura] = useState('');
  const [cuello, setCuello] = useState('');
  const [caderas, setCaderas] = useState('');
  const [porcentajeMusculo, setPorcentajeMusculo] = useState('');
  const [porcentajeGrasa, setPorcentajeGrasa] = useState('');

  const guardarMedidas = () => {
    // Aquí puedes agregar la lógica para guardar los datos en el sistema
    console.log('Medidas guardadas:');
    console.log('Cintura:', cintura);
    console.log('Cuello:', cuello);
    console.log('Caderas:', caderas);
    console.log('% de Músculo:', porcentajeMusculo);
    console.log('% de Grasa:', porcentajeGrasa);
  };

  return (
    <View>
      <Text>Fecha: [Fecha Actual]</Text>
      <Text>Cintura:</Text>
      <TextInput
        onChangeText={setCintura}
        value={cintura}
        placeholder="Ingrese la medida de la cintura"
        keyboardType="numeric"
      />
      <Text>Cuello:</Text>
      <TextInput
        onChangeText={setCuello}
        value={cuello}
        placeholder="Ingrese la medida del cuello"
        keyboardType="numeric"
      />
      <Text>Caderas:</Text>
      <TextInput
        onChangeText={setCaderas}
        value={caderas}
        placeholder="Ingrese la medida de las caderas"
        keyboardType="numeric"
      />
      <Text>% de Músculo:</Text>
      <TextInput
        onChangeText={setPorcentajeMusculo}
        value={porcentajeMusculo}
        placeholder="Ingrese el % de músculo"
        keyboardType="numeric"
      />
      <Text>% de Grasa:</Text>
      <TextInput
        onChangeText={setPorcentajeGrasa}
        value={porcentajeGrasa}
        placeholder="Ingrese el % de grasa"
        keyboardType="numeric"
      />
      <Button title="Guardar" onPress={guardarMedidas} />
    </View>
  );
};

export default MedidasRegistro;
