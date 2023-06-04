import React, { useState } from "react";
import { View, TextInput, StyleSheet, TouchableOpacity, Text, Button } from "react-native";
import { useNavigation } from "@react-navigation/native";

const LoginScreen = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const navigation = useNavigation();
  const [emailError, setEmailError] = useState('');
  const [passwordError, setPasswordError] = useState('');

  const handleRegister = () => {
    navigation.navigate('register');
  };

  const validateEmail = () => {
    // Expresión regular para validar el formato de correo electrónico
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailRegex.test(email)) {
      setEmailError('Correo electrónico inválido');
    } else {
      setEmailError('');
    }
  };

  const validatePassword = () => {
    if (password.length < 6) {
      setPasswordError('La contraseña debe tener al menos 6 caracteres');
    } else {
      setPasswordError('');
    }
  };

  const sendInformation = async () => {
    // Validar campos antes de enviar la información
    validateEmail();
    validatePassword();

    if (emailError === '' && passwordError === '') {
      // Aquí puedes realizar la lógica de enviar la información o hacer la llamada a la API
      const url = '';
      const response = await axios.post(url);
      const data = response.data;
      if (data === 'ok') {
        alert("Se registró correctamente");
      } else {
        alert('Usuario no existe');
      }
    }
  };

  return (
    <View style={styles.container}>
      <TextInput
        style={styles.input}
        placeholder="Correo electrónico"
        onChangeText={text => setEmail(text)}
        onBlur={validateEmail} // Validar el correo cuando el campo pierde el foco
        value={email}
      />
      {emailError !== '' && <Text style={styles.errorText}>{emailError}</Text>}
      <TextInput
        style={styles.input}
        placeholder="Contraseña"
        secureTextEntry
        onChangeText={text => setPassword(text)}
        onBlur={validatePassword} // Validar la contraseña cuando el campo pierde el foco
        value={password}
      />
      {passwordError !== '' && <Text style={styles.errorText}>{passwordError}</Text>}
      <Button
        title="Iniciar sesión"
        onPress={sendInformation}
      />
      <TouchableOpacity onPress={handleRegister}>
        <Text style={styles.registerText}>
          ¿No tienes una cuenta? <Text style={styles.registerLink}>Regístrate</Text>
        </Text>
      </TouchableOpacity>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    padding: 16,
  },
  input: {
    width: '100%',
    height: 40,
    borderColor: 'gray',
    borderWidth: 1,
    marginBottom: 12,
    paddingHorizontal: 8,
  },
  errorText: {
    color: 'red',
    marginBottom: 12,
  },
  registerText: {
    marginTop: 16,
    textAlign: 'center',
  },
  registerLink: {
    fontWeight: 'bold',
    color: 'blue',
  }
});

export default LoginScreen;
