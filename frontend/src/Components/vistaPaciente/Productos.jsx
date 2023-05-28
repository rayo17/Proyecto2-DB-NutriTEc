import React from 'react'
import '../../styleCss/Producto.css'
function Producto(){
    return (
        <div className='card'>
            <div className="div-codigo">
              <i class="fa-solid fa-code"></i>
              <input type='text'/>
              <label>Codigo de barra </label>
            </div>
            <div className="div-tamano">
              <i class="fa-solid fa-code"></i>
              <input type='text'/>
              <label>Tamaño de la Porcion</label>
            </div>
            <div className="div-codigo">
              <i class="fa-solid fa-code"></i>
              <input type='text'/>
              <label>{'Energia(Kcal)'}</label>
            </div>
            <div className="div-codigo">
              <i class="fa-solid fa-code"></i>
              <input type='text'/>
              <label>{'Grasa(g)'}</label>
              </div>
            <div className="div-codigo">
              <i class="fa-solid fa-code"></i>
              <input type='text'/>
              <label>{'Sodio(mg)'}</label>
            </div>
            <div className="div-codigo">
              <i class="fa-solid fa-code"></i>
              <input type='text'/>
              <label>{'Carbohidratos(g)'}</label>
            </div>
            <div className="div-codigo">
              <i class="fa-solid fa-code"></i>
              <input type='text'/>
              <label>{'Proteina(g)'}</label>
            </div>
            <div className="div-codigo">
              <i class="fa-solid fa-code"></i>
              <input type='text'/>
              <label>Vitaminas</label>
            </div>
            <div className="div-codigo">
              <i class="fa-solid fa-code"></i>
              <input type='text'/>
              <label>{'Calcio(g)'}</label>
            </div>
            <div className="div-codigo">
              <i class="fa-solid fa-code"></i>
              <input type='text'/>
              <label>Sodio</label>
            </div>
            <div className="boton-agregar">
                <button className='boto-agregar'>Agregar</button>
            </div>
        </div>
    )
    

}

export default Producto