import React from "react";
import '../../styleCss/LoginCliente.css'
import login from '../assets/login.png'
import BarraNav from "../Barra";
function Login(){
    return(
        <div>
            <BarraNav/>
        <div className="container-login-cliente">
            <div className="container-img">
                <img className="img-login" src={login} alt="imagen"/>
            </div>
            <form className="container-form">
                <div className="icon">
                  <i class="fa-solid fa-user"></i>
                </div>
                <div className="div-gmail">
                    <i class="fa-sharsp fa-solid fa-envelope"></i>
                    <input type="gmail" className="input-gmail"/>
                    <label>Gmail</label>
                </div>
                <div className="div-password">
                    <i class="fa-solid fa-lock"></i>
                    <input type="password"  className="input-password"/>
                    <label>password</label>
                </div>

                <div className="icons-application">
                   <i class="fa-brands fa-instagram"></i>
                   <i class="fa-brands fa-facebook facebook"></i>
                   <i class="fa-brands fa-twitter"></i>

                </div>
                <div className="pregunta-registro">
                    <a className="a-pregunta" href='e'>No tiene cuenta registrada?</a>
                </div>
                <div className="button-login-div">
                    <button className="button-login">Login</button>
                </div>
                
            </form>
        </div>
        </div>
    )
}

export default Login;