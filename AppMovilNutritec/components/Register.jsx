import React, { useState } from 'react';
import { View, TextInput, Button, StyleSheet } from 'react-native';
import md5 from 'md5';

const Registro = () => {
  const [nombre, setNombre] = useState('');
  const [apellidos, setApellidos] = useState('');
  const [edad, setEdad] = useState('');
  const [fechaNacimiento, setFechaNacimiento] = useState('');
  const [peso, setPeso] = useState('');
  const [imc, setImc] = useState('');
  const [pais, setPais] = useState('');
  const [pesoActual, setPesoActual] = useState('');
  const [medidas, setMedidas] = useState({
    cintura: '',
    cuello: '',
    caderas: '',
  });
  const [porcentajeMusculo, setPorcentajeMusculo] = useState('');
  const [porcentajeGrasa, setPorcentajeGrasa] = useState('');
  const [caloriasMaximas, setCaloriasMaximas] = useState('');
  const [correo, setCorreo] = useState('');
  const [password, setPassword] = useState('');

  const handleSubmit = () => {
    // Enviar los datos del formulario al servidor o realizar cualquier otra lógica necesaria

    // Encriptar la contraseña usando MD5 (nota: esto es solo para el ejemplo, no es seguro en la práctica)
    const encryptedPassword = md5(password);

    // Restablecer los campos del formulario después de enviar los datos
    setNombre('');
    setApellidos('');
    setEdad('');
    setFechaNacimiento('');
    setPeso('');
    setImc('');
    setPais('');
    setPesoActual('');
    setMedidas({ cintura: '', cuello: '', caderas: '' });
    setPorcentajeMusculo('');
    setPorcentajeGrasa('');
    setCaloriasMaximas('');
    setCorreo('');
    setPassword('');
  };

  return (
    <View style={styles.container}>
      <TextInput
        style={styles.input}
        placeholder="Nombre"
        value={nombre}
        onChangeText={(text) => setNombre(text)}
      />
      <TextInput
        style={styles.input}
        placeholder="Apellidos"
        value={apellidos}
        onChangeText={(text) => setApellidos(text)}
      />
      <TextInput
        style={styles.input}
        placeholder="Edad"
        value={edad}
        onChangeText={(text) => setEdad(text)}
      />
      <TextInput
        style={styles.input}
        placeholder="Fecha de Nacimiento"
        value={fechaNacimiento}
        onChangeText={(text) => setFechaNacimiento(text)}
      />
      <TextInput
        style={styles.input}
        placeholder="Peso"
        value={peso}
        onChangeText={(text) => setPeso(text)}
      />
      <TextInput
        style={styles.input}
        placeholder="IMC"
        value={imc}
        onChangeText={(text) => setImc(text)}
      />
      <TextInput
        style={styles.input}
        placeholder="País donde reside"
        value={pais}
        onChangeText={(text) => setPais(text)}
      />
      <TextInput
        style={styles.input}
        placeholder="Peso Actual"
        value={pesoActual}
        onChangeText={(text) => setPesoActual(text)}
      />
      <TextInput
        style={styles.input}
        placeholder="Cintura"
        value={medidas.cintura}
        onChangeText={(text) =>
          setMedidas({ ...medidas, cintura: text })
        }
      />
      <TextInput
        style={styles.input}
        placeholder="Cuello"
        value={medidas.cuello}
        onChangeText={(text) =>
          setMedidas({ ...medidas, cuello: text })
        }
      />
      <TextInput
        style={styles.input}
        placeholder="Caderas"
        value={medidas.caderas}
        onChangeText={(text) =>
          setMedidas({ ...medidas, caderas: text })
        }
      />
      <TextInput
        style={styles.input}
        placeholder="% de Musculo"
        value={porcentajeMusculo}
        onChangeText={(text) => setPorcentajeMusculo(text)}
      />
      <TextInput
        style={styles.input}
        placeholder="% de Grasa"
        value={porcentajeGrasa}
        onChangeText={(text) => setPorcentajeGrasa(text)}
      />
      <TextInput
        style={styles.input}
        placeholder="Consumo diario máximo de calorías"
        value={caloriasMaximas}
        onChangeText={(text) => setCaloriasMaximas(text)}
      />
      <TextInput
        style={styles.input}
        placeholder="Correo electrónico"
        value={correo}
        onChangeText={(text) => setCorreo(text)}
      />
      <TextInput
        style={styles.input}
        placeholder="Contraseña"
        secureTextEntry
        value={password}
        onChangeText={(text) => setPassword(text)}
      />
      <Button title="Registrarse" onPress={handleSubmit} />
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center',
    paddingHorizontal: 20,
    backgroundColor: '#fff',
  },
  input: {
    height: 40,
    width: '100%',
    borderColor: '#ccc',
    borderWidth: 1,
    marginBottom: 10,
    paddingHorizontal: 10,
    borderRadius: 5,
  },
});

export default Registro;
