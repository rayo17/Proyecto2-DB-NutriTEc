import React, { useState } from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import generatePDF from 'pdf-generator';
import axios from 'axios';
import { DatePicker } from 'antd';
import '../../../styleCss/Cliente/Reporte.css'
function Reporte() {
  const [medidas, setMedidas] = useState([]);
  const [fechaI, setFechaI] = useState(null); // Initialize as null
  const [fechaF, setFechaF] = useState(null); // Initialize as null

  const changeFechaI = (date, dateString) => {
    setFechaI(date);
  };

  const changeFechaF = (date, dateString) => {
    setFechaF(date);
  };

  const obtenerMedidasRegistradas = async () => {
    try {
      const url = 'https://apinutritecbd.azurewebsites.net/Cliente/Consulta_por_Periodo_medidas';
      const response = await axios.get(url, {
        correocliente: localStorage.getItem('cliente'),
        fechainicio: fechaI,
        fechafinal: fechaF,
      });

      if (response.status === 200) {
        const medidasFiltradas = response.data.filter((medida) => {
          return medida.fecha >= fechaI && medida.fecha <= fechaF;
        });

        setMedidas(medidasFiltradas);
      } else {
        console.error('Error al obtener las medidas registradas:', response.data.error);
      }
    } catch (error) {
      console.error('Error al obtener las medidas registradas:', error);
    }
  };

  const generarReportePDF = () => {
    generatePDF(medidas);
  };

  return (
    <div className="container">
      <div className="row">
        <div className="col-md-6">
          <label className="form-label">Fecha Inicio:</label>
          <DatePicker className="form-control" value={fechaI} onChange={changeFechaI} />
        </div>

        <div className="col-md-6">
          <label className="form-label">Fecha Final:</label>
          <DatePicker className="form-control" value={fechaF} onChange={changeFechaF} />
        </div>
      </div>

      <div className="row mt-3">
        <div className="col-md-6">
          <button className="btn btn-primary" onClick={obtenerMedidasRegistradas}>
            Obtener Medidas Registradas
          </button>
        </div>
        <div className="col-md-6">
          <button className="btn btn-primary" onClick={generarReportePDF}>
            Generar Reporte PDF
          </button>
        </div>
      </div>

      <table className="table mt-3">
        <thead>
          <tr>
            <th>Cintura</th>
            <th>Cuello</th>
            <th>Caderas</th>
            <th>% de Musculo</th>
            <th>% de Grasa</th>
          </tr>
        </thead>
        <tbody>
          {medidas.map((index) => {
            return (
              <tr key={index.id}>
                <td>{index.cintura}</td>
                <td>{index.cuello}</td>
                <td>{index.cadera}</td>
                <td>{index.porcentajemusculo}</td>
                <td>{index.porcentajegrasa}</td>
              </tr>
            );
          })}
        </tbody>
      </table>
    </div>
  );
}

export default Reporte;
