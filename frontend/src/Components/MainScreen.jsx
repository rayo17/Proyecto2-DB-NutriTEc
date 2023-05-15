import React from 'react';
import BarraNav from './Barra';
import imagenPortada from './assets/imagenPortada.jpg'
import '../styleCss/MainScreen.css'

function MainScreen(){
    return(
        <div>
            <header>
                <BarraNav/>    
            </header>
            <div className='div-img'>
                <img src={imagenPortada} alt='imagen' width={'100%'} height={'50%'}></img>
            </div>
            <div className='H'>
                FJAOSDFJSFOWOFWOEFWEFOWJEFOJWEFWE
                <h1>NUTRITEC</h1>
            </div>
        </div>
    )
}

export default MainScreen