import React,{useState} from "react";
import '../../styleCss/LoginCliente.css'
import login from '../assets/login.png'
import BarraNav from "../Barra";
import axios from "axios";
import {useForm} from 'react-hook-form'
//const  {register, formState:{errors}, handleSubmit}=useForm();
function Login({url,img,register}){

    const [gmail,setgmail]=useState("")
    const [password,setpassword]=useState("")
    const changeGmail=(e)=>{
        setgmail(e.target.value)
        console.log("Gmail",gmail)
    }
    const changePassword=(e)=>{
        setpassword(e.target.value)
        console.log("Password",password)
    }  

    function sendinfo(e){
        e.preventDefautl()

         axios.get("",{
            Gmail:gmail,
            password: password
        }
        ).then(info=>{console.log(info)}).catch(error=>console.log(error))

    }


    
    

    return(
        <div>
            <BarraNav/>
        <div className="container-login-cliente">
            <div className="container-img">
                <img className="img-login" src={img} alt="imagen"/>
            </div>
            <form className="container-form">
                <div className="icon">
                  <i class="fa-solid fa-user"></i>
                </div>
                <div className="div-gmail">
                    <i class="fa-sharsp fa-solid fa-envelope"></i>
                    <input type="gmail" className="input-gmail" name="gmail" onChange={changeGmail}/>
                    <label>Gmail</label>
                </div>
                <div className="div-password">
                    <i class="fa-solid fa-lock"></i>
                    <input type="password"  className="input-password" name="password" onChange={changePassword}/>
                    <label>password</label>
                </div>

                <div className="icons-application">
                   <i class="fa-brands fa-instagram"></i>
                   <i class="fa-brands fa-facebook facebook"></i>
                   <i class="fa-brands fa-twitter"></i>

                </div>
                <div className="pregunta-registro">
                    <a className="a-pregunta" href={register}>No tiene cuenta registrada?</a>
                </div>
                <div className="button-login-div">
                    <button className="button-login" onClick={sendinfo}>Login</button>
                </div>
                
            </form>
        </div>
        </div>
    )
}

export default Login;