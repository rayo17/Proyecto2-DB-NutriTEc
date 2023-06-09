import React, { useState, useEffect } from 'react';
import axios from 'axios';

const AsignacionPlan = () => {
  const [pacientes, setPacientes] = useState([]);
  const [planesAlimentacion, setPlanesAlimentacion] = useState([]);
  const [selectedPaciente, setSelectedPaciente] = useState('');
  const [selectedPlan, setSelectedPlan] = useState('');
  const [selectedStartDate, setSelectedStartDate] = useState('');
  const [selectedEndDate, setSelectedEndDate] = useState('');
  let nutricionista = localStorage.getItem('cedula');
  nutricionista = "117920898";

  const cargarPlanes = async () => {
    const url = `https://apinutritecbd.azurewebsites.net/Nutricionista/planes/${nutricionista}`;
    try {
      const response = await axios.get(url);
      setPlanesAlimentacion(response.data);
    } catch (error) {
      console.error(error);
    }
  };

  const cargarPacientes = async () => {
    const url = `https://apinutritecbd.azurewebsites.net/Nutricionista/ObtenerPacientesPorCedula/${nutricionista}`;
    try {
      const response = await axios.get(url);
      setPacientes(response.data);
    } catch (error) {
      console.error(error);
    }
  };

  useEffect(() => {
    cargarPacientes();
  }, []);

  useEffect(() => {
    cargarPlanes();
  }, []);

  const handlePacienteChange = event => {
    setSelectedPaciente(event.target.value);
  };

  const handlePlanChange = event => {
    setSelectedPlan(event.target.value);
  };

  const handleFormSubmit = async event => {
    event.preventDefault();

    const url = "||";

    /*const response = await axios.post(url, {
      pacienteid: selectedPaciente.correoelectronico,
      nutricionistaid: localStorage.getItem('cedula'),
      planid: selectedPlan,
      fechainicio: selectedStartDate,
      fechafinalizacion: selectedEndDate,
    });*/

    // Rest of the code
  };

  return (
    <div className="container">
      <h2 className="mt-4 mb-4">Asignación de Plan de Alimentación</h2>
      <form onSubmit={handleFormSubmit}>
        <div className="form-group">
          <label htmlFor="paciente">Paciente:</label>
          <select
            className="form-control"
            id="paciente"
            value={selectedPaciente}
            onChange={handlePacienteChange}
          >
            <option value="">Seleccione un paciente</option>
            {pacientes.map(paciente => (
              <option key={paciente.nombre} value={paciente.nombre}>
                {paciente.nombre} {paciente.correoElectronico}
              </option>
            ))}
          </select>
        </div>
        <div className="form-group">
          <label htmlFor="plan">Plan de Alimentación:</label>
          <select
            className="form-control"
            id="plan"
            value={selectedPlan}
            onChange={handlePlanChange}
          >
            <option value="">Seleccione un plan de alimentación</option>
            {planesAlimentacion.map(plan => (
              <option key={plan} value={plan}>
                {plan}
              </option>
            ))}
          </select>
        </div>
        <div className="form-group">
          <label htmlFor="startDate">Fecha de inicio:</label>
          <input
            type="date"
            className="form-control"
            id="startDate"
            value={selectedStartDate}
            onChange={event => setSelectedStartDate(event.target.value)}
          />
        </div>
        <div className="form-group">
          <label htmlFor="endDate">Fecha de finalización:</label>
          <input
            type="date"
            className="form-control"
            id="endDate"
            value={selectedEndDate}
            onChange={event => setSelectedEndDate(event.target.value)}
          />
        </div>
        <button type="submit" className="btn btn-primary">
          Asignar Plan
        </button>
      </form>
      {selectedPaciente && (
        <div className="mt-4">
          <h3>Información del Paciente:</h3>
          <p>
            <strong>Nombre:</strong>{' '}
            {pacientes.find(paciente => paciente.id === parseInt(selectedPaciente)).nombre}{' '}
            {pacientes.find(paciente => paciente.id === parseInt(selectedPaciente)).apellidos}
          </p>
          <p>
            <strong>Edad:</strong>{' '}
            {pacientes.find(paciente => paciente.id === parseInt(selectedPaciente)).edad}
          </p>
          <p>
            <strong>Fecha de Nacimiento:</strong>{' '}
            {pacientes.find(paciente => paciente.id === parseInt(selectedPaciente)).fechaNacimiento}
          </p>
          <p>
            <strong>Peso:</strong>{' '}
            {pacientes.find(paciente => paciente.id === parseInt(selectedPaciente)).peso}
          </p>
          <p>
            <strong>IMC:</strong>{' '}
            {pacientes.find(paciente => paciente.id === parseInt(selectedPaciente)).imc}
          </p>
          <p>
            <strong>País de Residencia:</strong>{' '}
            {pacientes.find(paciente => paciente.id === parseInt(selectedPaciente)).pais}
          </p>
          <p>
            <strong>Peso Actual:</strong>{' '}
            {pacientes.find(paciente => paciente.id === parseInt(selectedPaciente)).pesoActual}
          </p>
          <p>
            <strong>Medidas:</strong>
          </p>
          <ul>
            <li>
              <strong>Cintura:</strong>{' '}
              {pacientes.find(paciente => paciente.id === parseInt(selectedPaciente)).medidas.cintura}
            </li>
            <li>
              <strong>Cuello:</strong>{' '}
              {pacientes.find(paciente => paciente.id === parseInt(selectedPaciente)).medidas.cuello}
            </li>
            <li>
              <strong>Caderas:</strong>{' '}
              {pacientes.find(paciente => paciente.id === parseInt(selectedPaciente)).medidas.caderas}
            </li>
          </ul>
          <p>
            <strong>% de Músculo:</strong>{' '}
            {pacientes.find(paciente => paciente.id === parseInt(selectedPaciente)).porcentajeMusculo}
          </p>
          <p>
            <strong>% de Grasa:</strong>{' '}
            {pacientes.find(paciente => paciente.id === parseInt(selectedPaciente)).porcentajeGrasa}
          </p>
          <p>
            <strong>Consumo Diario Máximo de Calorías:</strong>{' '}
            {pacientes.find(paciente => paciente.id === parseInt(selectedPaciente)).consumoMaxCalorias}
          </p>
          <p>
            <strong>Correo Electrónico:</strong>{' '}
            {pacientes.find(paciente => paciente.id === parseInt(selectedPaciente)).correo}
          </p>
        </div>
      )}
    </div>
  );
};

export default AsignacionPlan;
