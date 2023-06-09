//import { StatusBar } from 'expo-status-bar';
import { Text, View,StyleSheet,TextInput } from 'react-native';
import {NavigationContainer} from '@react-navigation/native';
import {createNativeStackNavigator} from '@react-navigation/native-stack';
import LoginScreen from './components/Login';

export default function App() {
  const Stack = createNativeStackNavigator();

  return (
          <NavigationContainer>
          <Stack.Navigator>
         
            
              <Stack.Screen
              name="login"
              component={LoginScreen}
              
              
                          />
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