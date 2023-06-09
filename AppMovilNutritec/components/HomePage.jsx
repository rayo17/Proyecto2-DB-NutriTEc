import React from "react";
import { View, Text, Button, StyleSheet } from "react-native";

const HomePage = ({ navigation }) => {
  const handleDailyRegistration = () => {
    // Lógica para redirigir al usuario a la página de registro diario
    navigation.navigate("consumodiario"); // Reemplaza "DailyRegistration" con el nombre de la pantalla correspondiente
  };

  const handleRecipeManagement = () => {
    // Lógica para redirigir al usuario a la página de gestión de recetas
    navigation.navigate(""); // Reemplaza "RecipeManagement" con el nombre de la pantalla correspondiente
  };

  return (
    <View style={styles.container}>
      <Text style={styles.title}>Opciones</Text>
      <Button
        title="Registro Diario"
        onPress={handleDailyRegistration}
      />
      <Button
        title="Gestión de Recetas"
        onPress={handleRecipeManagement}
      />
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
});

export default HomePage;
