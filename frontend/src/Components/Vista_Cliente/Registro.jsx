import React from 'react'

function RegistroClient(){
    return(
        <div>

            <div className="form-div">
                <form>
                    <div className="div-nombre">
                    <label htmlFor="nombre" className="label-nombre">Nombre</label>
                    <input type='text'/>
                    </div>    
                    <div className="div-apellido1">
                        <label htmlFor="" className="label-apellido1">Apellido1</label>
                        <input type="text" name="" id="" />
                    </div>               
                    
                    <div className="div-apellido2">
                        <label htmlFor="" className="label-apellido2">Apellido2</label>
                    </div>
                    <div className="div-edad">
                        <label htmlFor="" className="label-edad">Edad</label>
                        <input type="text" />
                    </div>
                    <div className="div-fecha">
                        <label htmlFor="" className="label-fecha">fecha</label>
                        <input type="date" />
                    </div>
                    <div className="div-peso">
                        <label htmlFor="" className="label-peso">Peso</label>
                        <input type="text" />
                    </div>
                    <div className="div-imc">
                        <label htmlFor="" className="label-imc"></label>
                    </div>
                    <div className="div-pais">
                        <label htmlFor="" className="label-pais"></label>
                        <input type="text" />
                    </div>
                    <div className="div-pesoActual">
                        <label htmlFor="" className="label-pesoActual"></label>
                    </div>
                    <div className="div-medidas">
                        <div className="div-cintura">
                            <label htmlFor="" className="label-cintura"></label>
                            <input type='text'/>
                        </div>
                        <div className="div-cuello">
                            <label htmlFor="" className="label-cuello"></label>
                            <input type="text" />
                        </div>
                        <div className="div-caderas">
                            <label htmlFor="" className="label-caderas"></label>
                            <input type="text" />
                        </div>
                        <div className='div-grasa'>
                            <label htmlFor="" className="label-grasa">%Grasa</label>
                            <input type="text" />
                        </div>
                        <div className="div-consum-diario">
                            <label htmlFor="" className="label-consum-diario"></label>
                            <input type="text" />
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

                    </div>

                </form>

            </div>
        </div>
    )
}

export default RegistroClient;