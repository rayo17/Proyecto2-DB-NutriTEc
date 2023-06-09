

import React, { useState } from "react";
import { View, TextInput, Button, Text, StyleSheet } from "react-native";
import axios from "axios";
import md5 from "crypto-js/md5";
import HomePage from "./HomePage";

const LoginForm = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [loggedIn, setLoggedIn] = useState(false);
  const [message, setMessage] = useState("");

  const handleLogin = async () => {
    if (email.trim() === "" || password.trim() === "") {
      setMessage("Por favor, completa todos los campos");
      return;
    }

    try {
      const response = await axios.post(
        "https://apinutritecbd.azurewebsites.net/Cliente/validarcliente",
        {
          correoelectronico: email,
          contrasena: md5(password).toString(),
        }
      );

      if (response.data !== 0) {
        setLoggedIn(true);
        setMessage("¡Has iniciado sesión exitosamente!");
      } else {
        setMessage("Credenciales inválidas");
      }
    } catch (error) {
      setMessage("Hubo un error en la solicitud");
      console.log(error);
    }
  };

  if (loggedIn) {
    return <HomePage />;
  }

  return (
    <View style={styles.container}>
      <Text style={styles.title}>Inicio de sesión</Text>
      <TextInput
        style={styles.input}
        placeholder="Correo electrónico"
        value={email}
        onChangeText={(text) => setEmail(text)}
      />
      <TextInput
        style={styles.input}
        placeholder="Contraseña"
        secureTextEntry={true}
        value={password}
        onChangeText={(text) => setPassword(text)}
      />
      <Button title="Iniciar sesión" onPress={handleLogin} />
      <Text style={styles.message}>{message}</Text>
      {!loggedIn && (
        <Text style={styles.registerMessage}>Necesitas registrarte</Text>
      )}
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    alignItems: "center",
    justifyContent: "center",
    padding: 20,
  },
  title: {
    fontSize: 24,
    fontWeight: "bold",
    marginBottom: 20,
  },
  input: {
    width: "100%",
    height: 40,
    borderWidth: 1,
    borderColor: "#ccc",
    borderRadius: 5,
    marginBottom: 10,
    paddingHorizontal: 10,
  },
  message: {
    marginTop: 10,
    fontWeight: "bold",
  },
  registerMessage: {
    marginTop: 10,
  },
});

export default LoginForm;
