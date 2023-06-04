//import { StatusBar } from 'expo-status-bar';
import { Text, View,StyleSheet,TextInput } from 'react-native';
import {NavigationContainer} from '@react-navigation/native';
import {createNativeStackNavigator} from '@react-navigation/native-stack';
import LoginScreen from './components/Login';
import Registro from './components/Register';
import RegistroDiarioConsumo from './components/ConsumoD';
export default function App() {
  const Stack = createNativeStackNavigator();

  return (
          <NavigationContainer>
          <Stack.Navigator>
              <Stack.Screen name="consumo Diario" component={RegistroDiarioConsumo} />
              <Stack.Screen
              name="login"
              component={LoginScreen}
              
                          />
             <Stack.Screen name="register" component={Registro} />
            </Stack.Navigator>
           
      

        </NavigationContainer>

     
  
  );
};




const MyStack = () => {
  return (
    <NavigationContainer>
      <Stack.Navigator>
        <Stack.Screen
          name="Home"
          component={HomeScreen}
          options={{title: 'Welcome'}}
        />
        <Stack.Screen name="Profile" component={ProfileScreen} />
      </Stack.Navigator>
    </NavigationContainer>
  );
};