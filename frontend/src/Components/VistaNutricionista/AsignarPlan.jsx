import React, { useState, useEffect } from 'react';

const AsignacionPlan = () => {
  const [pacientes, setPacientes] = useState([]);
  const [planesAlimentacion, setPlanesAlimentacion] = useState([]);
  const [selectedPaciente, setSelectedPaciente] = useState('');
  const [selectedPlan, setSelectedPlan] = useState('');

  // Simulación de carga de pacientes desde la API
  useEffect(() => {
    const mockPacientes = [
      {
        id: 1,
        nombre: 'John',
        apellidos: 'Doe',
        edad: 30,
        fechaNacimiento: '1993-05-15',
        peso: 70,
        imc: 24.5,
        pais: 'Estados Unidos',
        pesoActual: 68,
        medidas: {
          cintura: 80,
          cuello: 40,
          caderas: 90
        },
        porcentajeMusculo: 35,
        porcentajeGrasa: 20,
        consumoMaxCalorias: 2000,
        correo: 'john.doe@example.com'
      },
      {
        id: 2,
        nombre: 'Jane',
        apellidos: 'Smith',
        edad: 25,
        fechaNacimiento: '1996-09-22',
        peso: 65,
        imc: 23.5,
        pais: 'Canadá',
        pesoActual: 63,
        medidas: {
          cintura: 75,
          cuello: 38,
          caderas: 85
        },
        porcentajeMusculo: 30,
        porcentajeGrasa: 25,
        consumoMaxCalorias: 1800,
        correo: 'jane.smith@example.com'
      }
    ];

    setPacientes(mockPacientes);
  }, []);

  // Simulación de carga de planes de alimentación desde la API
  useEffect(() => {
    const mockPlanesAlimentacion = [
      { id: 1, nombre: 'Plan 1' },
      { id: 2, nombre: 'Plan 2' },
      { id: 3, nombre: 'Plan 3' }
    ];

    setPlanesAlimentacion(mockPlanesAlimentacion);
  }, []);

  // Manejar selección de paciente
  const handlePacienteChange = event => {
    setSelectedPaciente(event.target.value);
  };

  // Manejar selección de plan de alimentación
  const handlePlanChange = event => {
    setSelectedPlan(event.target.value);
  };

  // Manejar envío del formulario de asignación
  const handleFormSubmit = event => {
    event.preventDefault();

    // Simulación de asignación del plan al paciente
    const paciente = pacientes.find(p => p.id === parseInt(selectedPaciente));
    const plan = planesAlimentacion.find(p => p.id === parseInt(selectedPlan));
    console.log(`Asignación realizada: ${paciente.nombre} ${paciente.apellidos} - ${plan.nombre}`);
  };

  return (
    <div className="container">
      <h2 className="mt-4 mb-4">Asignación de Plan de Alimentación</h2>
      <form onSubmit={handleFormSubmit}>
        <div className="form-group">
          <label htmlFor="paciente">Paciente:</label>
          <select className="form-control" id="paciente" value={selectedPaciente} onChange={handlePacienteChange}>
            <option value="">Seleccione un paciente</option>
            {pacientes.map(paciente => (
              <option key={paciente.id} value={paciente.id}>
                {paciente.nombre} {paciente.apellidos}
              </option>
            ))}
          </select>
        </div>
        <div className="form-group">
          <label htmlFor="plan">Plan de Alimentación:</label>
          <select className="form-control" id="plan" value={selectedPlan} onChange={handlePlanChange}>
            <option value="">Seleccione un plan de alimentación</option>
            {planesAlimentacion.map(plan => (
              <option key={plan.id} value={plan.id}>
                {plan.nombre}
              </option>
            ))}
          </select>
        </div>
        <button type="submit" className="btn btn-primary">Asignar Plan</button>
      </form>
      {selectedPaciente && (
        <div className="mt-4">
          <h3>Información del Paciente:</h3>
          <p><strong>Nombre:</strong> {pacientes.find(paciente => paciente.id === parseInt(selectedPaciente)).nombre} {pacientes.find(paciente => paciente.id === parseInt(selectedPaciente)).apellidos}</p>
          <p><strong>Edad:</strong> {pacientes.find(paciente => paciente.id === parseInt(selectedPaciente)).edad}</p>
          <p><strong>Fecha de Nacimiento:</strong> {pacientes.find(paciente => paciente.id === parseInt(selectedPaciente)).fechaNacimiento}</p>
          <p><strong>Peso:</strong> {pacientes.find(paciente => paciente.id === parseInt(selectedPaciente)).peso}</p>
          <p><strong>IMC:</strong> {pacientes.find(paciente => paciente.id === parseInt(selectedPaciente)).imc}</p>
          <p><strong>País de Residencia:</strong> {pacientes.find(paciente => paciente.id === parseInt(selectedPaciente)).pais}</p>
          <p><strong>Peso Actual:</strong> {pacientes.find(paciente => paciente.id === parseInt(selectedPaciente)).pesoActual}</p>
          <p><strong>Medidas:</strong></p>
          <ul>
            <li><strong>Cintura:</strong> {pacientes.find(paciente => paciente.id === parseInt(selectedPaciente)).medidas.cintura}</li>
            <li><strong>Cuello:</strong> {pacientes.find(paciente => paciente.id === parseInt(selectedPaciente)).medidas.cuello}</li>
            <li><strong>Caderas:</strong> {pacientes.find(paciente => paciente.id === parseInt(selectedPaciente)).medidas.caderas}</li>
          </ul>
          <p><strong>% de Músculo:</strong> {pacientes.find(paciente => paciente.id === parseInt(selectedPaciente)).porcentajeMusculo}</p>
          <p><strong>% de Grasa:</strong> {pacientes.find(paciente => paciente.id === parseInt(selectedPaciente)).porcentajeGrasa}</p>
          <p><strong>Consumo Diario Máximo de Calorías:</strong> {pacientes.find(paciente => paciente.id === parseInt(selectedPaciente)).consumoMaxCalorias}</p>
          <p><strong>Correo Electrónico:</strong> {pacientes.find(paciente => paciente.id === parseInt(selectedPaciente)).correo}</p>
        </div>
      )}
    </div>
  );
};

export default AsignacionPlan;
