import React from 'react'
import '../../../styleCss/Cliente/AlertSuccess.css'
function AlertSucces(){
    return (
        <div id="success-alert" class="alert">
        <span class="closebtn" onclick="closeAlert()">&times;</span>
        ¡Inicio de sesión exitoso! Bienvenido.
         </div>
      
    )
}

export default AlertSucces