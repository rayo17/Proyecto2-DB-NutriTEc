import React, { useState } from 'react';

const ReporteCobro = () => {
  const [reportData, setReportData] = useState(null);

  const generarReporte = () => {
    // Aquí deberías llamar a tu Store Procedure para obtener los datos del reporte
    // y asignarlos al estado "reportData" en el formato adecuado.
    // Puedes utilizar la librería adecuada para generar el PDF, como pdfmake o react-pdf.

    // Ejemplo de datos del reporte:
    const datosReporte = [
      {
        tipoPago: 'Semanal',
        correo: 'nutricionista1@example.com',
        nombre: 'Nutricionista 1',
        numeroTarjeta: '**** **** **** 1234',
        montoTotal: 10,
        descuento: 0,
        montoCobrar: 10,
      },
      {
        tipoPago: 'Mensual',
        correo: 'nutricionista2@example.com',
        nombre: 'Nutricionista 2',
        numeroTarjeta: '**** **** **** 5678',
        montoTotal: 20,
        descuento: 1,
        montoCobrar: 19,
      },
      // ... más datos del reporte
    ];

    setReportData(datosReporte);
  };

  const exportarPDF = () => {
    // Aquí deberías implementar la funcionalidad para exportar los datos del reporte
    // almacenados en "reportData" a un archivo PDF.
  };

  return (
    <div>
      <h1>Reporte de Cobro</h1>
      <button onClick={generarReporte}>Generar Reporte</button>
      {reportData && (
        <>
          <table>
            <thead>
              <tr>
                <th>Tipo de Pago</th>
                <th>Correo Electrónico</th>
                <th>Nombre Completo</th>
                <th>Número de Tarjeta</th>
                <th>Monto Total</th>
                <th>Descuento</th>
                <th>Monto a Cobrar</th>
              </tr>
            </thead>
            <tbody>
              {reportData.map((item, index) => (
                <tr key={index}>
                  <td>{item.tipoPago}</td>
                  <td>{item.correo}</td>
                  <td>{item.nombre}</td>
                  <td>{item.numeroTarjeta}</td>
                  <td>{item.montoTotal}</td>
                  <td>{item.descuento}</td>
                  <td>{item.montoCobrar}</td>
                </tr>
              ))}
            </tbody>
          </table>
          <button onClick={exportarPDF}>Exportar a PDF</button>
        </>
      )}
    </div>
  );
};

export default ReporteCobro;
