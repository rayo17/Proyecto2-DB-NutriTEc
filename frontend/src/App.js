import { Routes, Route, BrowserRouter as BR } from 'react-router-dom'
import './App.css';
import MainScreen from './Components/MainScreen';
import Login from './Components/Vista_Cliente/pages/Login';
import Producto from './Components/templates/Productos';
import LoginAdmin from './Components/Vista_Admin/pages/LogAdmin';
import loginImg from './Components/assets/login.png'
import VistaRegistro from './Components/VistaNutricionista/pagesNutricionista/Registro';
import RegistroClient from './Components/Vista_Cliente/pages/Registro';
import AgregaClient from './Components/VistaNutricionista/pagesNutricionista/AgregaClient';
import VistaMainCliente from './Components/Vista_Cliente/pages/VistaMainCliente';
import VistaMaiAdmin from './Components/Vista_Admin/pages/pages/VistaMainAdmin';
import VistaMainNutri from './Components/VistaNutricionista/pagesNutricionista/VistaMainNutri';
import GestionProducto from './Components/VistaNutricionista/pagesNutricionista/GestionProducto';
import ListaPaciente from './Components/VistaNutricionista/pagesNutricionista/ListaPaciente';
import Receta from './Components/Vista_Cliente/pages/Receta';
import ProductApproval from './Components/Vista_Admin/pages/pages/ProductAccept';
import RegistroDiarioDeConsumo from './Components/Vista_Cliente/pages/RegistroDiarioConsumo';
import PlanGestionComponent from './Components/VistaNutricionista/Plan';
import AsignacionPlan from './Components/VistaNutricionista/AsignarPlan';

function App() {
  return (

    //create the routes of component en screen
    <div className="App">
      <BR>
        <Routes>

        <Route path='/' element={<MainScreen/>}/>
        
        <Route path='/cliente' element={<VistaMainCliente/>}/>
        <Route path="/cliente/login" element={<Login url={'/l'} img={loginImg} register={"/RegistroClient"}/>}/>
        <Route path='/cliente/registro' element={<RegistroClient/>}/>
        <Route path='/cliente/receta' element={<Receta/>}/>
        <Route path='/cliente/consumo' element={<RegistroDiarioDeConsumo/>}/>
        <Route path='/cliente/productos' element={<GestionProducto/>}/>
        


    
     

        <Route path='/administrador' element={<VistaMaiAdmin/>}/>
        <Route path='/Administrador/login' element={<LoginAdmin/>}/>
        <Route path='/Administrador/productos' element={<ProductApproval/>}/>
        
        <Route path='/nutricionista/añadir' element={<Producto/>}/>
    
        <Route path='/nutricionista' element={<VistaMainNutri/>}/>
        <Route path="/nutricionista/login" element={<Login url={'/'} img={loginImg} register={"/nutricionista/registro"}/>}/>
        <Route path='/nutricionista/productos' element={<GestionProducto/>}/>
        <Route path='/nutricionista/registro' element={<VistaRegistro/>}/>
        <Route path='/nutricionista/agregarcliente' element={<AgregaClient/>}/>
        <Route path='/nutricionista/listapaciente' element={<ListaPaciente/>}/>
        <Route path='/nutricionista/planes' element={<PlanGestionComponent/>}/>
        <Route path='/nutricionista/asignarplan' element={<AsignacionPlan/>}/>
   
       
       
        </Routes>
      </BR>

    </div>
  );
}

export default App;
