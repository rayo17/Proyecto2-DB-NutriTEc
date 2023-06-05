import React, { useState } from 'react';
import { useForm } from 'react-hook-form';
import axios from 'axios';
import md5 from 'md5';


function RegistroClient() {
  const { register, handleSubmit, formState: { errors } } = useForm();
  const [isRegistered, setIsRegistered] = useState(false);

  const onSubmit = async (data) => {
    // Encriptar la contraseña con MD5
    const password = md5(data.password);

    // Realizar la solicitud de registro
    try {
      const response = await axios.post('http://localhost:5000/Clientes', {
        nombre: data.nombre,
        apellido1: data.apellido1,
        apellido2: data.apellido2,
        edad: data.edad,
        fecha: data.fecha,
        peso: data.peso,
        imc: data.imc,
        pais: data.pais,
        cintura: data.cintura,
        cuello: data.cuello,
        caderas: data.caderas,
        musculo: data.musculo,
        grasa: data.grasa,
        calorias: data.calorias,
        correo: data.correo,
        password: password
      });

      console.log(response);
      setIsRegistered(true);
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <div className="registro-cliente">
      <h2>Registro de Cliente</h2>
      {!isRegistered ? (
        <form onSubmit={handleSubmit(onSubmit)}>
          <div className="mb-3">
            <label htmlFor="nombre" className="form-label">Nombre</label>
            <input type="text" className="form-control" {...register('nombre', { required: true })} />
            {errors.nombre && <span className="error-message">Nombre es requerido</span>}
          </div>

          <div className="mb-3">
            <label htmlFor="apellido1" className="form-label">Apellido 1</label>
            <input type="text" className="form-control" {...register('apellido1', { required: true })} />
            {errors.apellido1 && <span className="error-message">Apellido 1 es requerido</span>}
          </div>

          <div className="mb-3">
            <label htmlFor="apellido2" className="form-label">Apellido 2</label>
            <input type="text" className="form-control" {...register('apellido2', { required: true })} />
            {errors.apellido2 && <span className="error-message">Apellido 2 es requerido</span>}
          </div>

          <div className="mb-3">
            <label htmlFor="edad" className="form-label">Edad</label>
            <input type="number" className="form-control" {...register('edad', { required: true })} />
            {errors.edad && <span className="error-message">Edad es requerida</span>}
          </div>

          <div className="mb-3">
            <label htmlFor="fecha" className="form-label">Fecha de Nacimiento</label>
            <input type="date" className="form-control" {...register('fecha', { required: true })} />
            {errors.fecha && <span className="error-message">Fecha de Nacimiento es requerida</span>}
          </div>

          <div className="mb-3">
            <label htmlFor="peso" className="form-label">Peso</label>
            <input type="number" className="form-control" {...register('peso', { required: true })} />
            {errors.peso && <span className="error-message">Peso es requerido</span>}
          </div>

          <div className="mb-3">
            <label htmlFor="imc" className="form-label">IMC</label>
            <input type="number" className="form-control" {...register('imc', { required: true })} />
            {errors.imc && <span className="error-message">IMC es requerido</span>}
          </div>

          <div className="mb-3">
            <label htmlFor="pais" className="form-label">País de Residencia</label>
            <input type="text" className="form-control" {...register('pais', { required: true })} />
            {errors.pais && <span className="error-message">País de Residencia es requerido</span>}
          </div>

          <div className="mb-3">
            <label htmlFor="cintura" className="form-label">Medida de Cintura</label>
            <input type="number" className="form-control" {...register('cintura', { required: true })} />
            {errors.cintura && <span className="error-message">Medida de Cintura es requerida</span>}
          </div>

          <div className="mb-3">
            <label htmlFor="cuello" className="form-label">Medida de Cuello</label>
            <input type="number" className="form-control" {...register('cuello', { required: true })} />
            {errors.cuello && <span className="error-message">Medida de Cuello es requerida</span>}
          </div>

          <div className="mb-3">
            <label htmlFor="caderas" className="form-label">Medida de Caderas</label>
            <input type="number" className="form-control" {...register('caderas', { required: true })} />
            {errors.caderas && <span className="error-message">Medida de Caderas es requerida</span>}
          </div>

          <div className="mb-3">
            <label htmlFor="musculo" className="form-label">% de Músculo</label>
            <input type="number" className="form-control" {...register('musculo', { required: true })} />
            {errors.musculo && <span className="error-message">% de Músculo es requerido</span>}
          </div>

          <div className="mb-3">
            <label htmlFor="grasa" className="form-label">% de Grasa</label>
            <input type="number" className="form-control" {...register('grasa', { required: true })} />
            {errors.grasa && <span className="error-message">% de Grasa es requerido</span>}
          </div>

          <div className="mb-3">
            <label htmlFor="calorias" className="form-label">Consumo Diario Máximo de Calorías</label>
            <input type="number" className="form-control" {...register('calorias', { required: true })} />
            {errors.calorias && <span className="error-message">Consumo Diario Máximo de Calorías es requerido</span>}
          </div>

          <div className="mb-3">
            <label htmlFor="correo" className="form-label">Correo Electrónico</label>
            <input type="email" className="form-control" {...register('correo', { required: true })} />
            {errors.correo && <span className="error-message">Correo Electrónico es requerido</span>}
          </div>

          <div className="mb-3">
            <label htmlFor="password" className="form-label">Contraseña</label>
            <input type="password" className="form-control" {...register('password', { required: true })} />
            {errors.password && <span className="error-message">Contraseña es requerida</span>}
          </div>

          <button type="submit" className="btn btn-primary">Registrar</button>
        </form>
      ) : (
        <div className="registro-exitoso">
          <h3>Registro exitoso</h3>
          <p>Tu cuenta ha sido registrada exitosamente.</p>
        </div>
      )}
    </div>
  );
}

export default RegistroClient;
