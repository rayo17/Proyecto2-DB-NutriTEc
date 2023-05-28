import { Routes, Route, BrowserRouter as BR } from 'react-router-dom'
import './App.css';
import MainScreen from './Components/MainScreen';
import Login from './Components/Vista_Cliente/Login';
import Producto from './Components/vistaPaciente/Productos';
import LoginAdmin from './Components/Vista_Admin/pages/LogAdmin';
import loginImg from './Components/assets/login.png'
import VistaRegistro from './Components/VistaNutricionista/pagesNutricionista/Registro';
import RegistroClient from './Components/Vista_Cliente/Registro';
import AgregaClient from './Components/VistaNutricionista/pagesNutricionista/AgregaClient';

function App() {
  return (
    <div className="App">
      <BR>
        <Routes>
        <Route path='/Producto' element={<Producto/>}/>
          <Route path='/' element={<MainScreen/>}/>
          <Route path="/cliente" element={<Login url={'/l'} img={loginImg} register={"/RegistroClient"}/>}/>
          <Route path="/LogNutri" element={<Login url={'/'} img={loginImg} register={"/NutricionistaRegistro"}/>}/>
          <Route path='/RegistroClient' element={<RegistroClient/>}/>
          <Route path='Administrador' element={<LoginAdmin/>}/>
        <Route path='/NutricionistaRegistro' element={<VistaRegistro/>}/>
        <Route path='/buscador' element={<AgregaClient/>}/> 
        </Routes>
      </BR>

    </div>
  );
}

export default App;
