import { Routes, Route, BrowserRouter as BR } from 'react-router-dom'
import './App.css';
import MainScreen from './Components/MainScreen';
import Login from './Components/Vista_Cliente/Login';
import Registro from './Components/Vista_Cliente/Registro';


function App() {
  return (
    <div className="App">
      <BR>
        <Routes>
          <Route path='/' element={<MainScreen/>}/>
          <Route path="/cliente" element={<Login/>}/>
          <Route path='/Registro' element={<Registro/>}/>
        </Routes>
      </BR>

    </div>
  );
}

export default App;
