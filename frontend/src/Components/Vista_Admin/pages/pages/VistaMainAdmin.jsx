import React from 'react';
import Card from '../../../templates/Card';
import '../../../../styleCss/Templates/Card.css';

function VistaMaiAdmin() {
  return (
    <div className="container">
      <div className="row">
        <div className="col-md-6 offset-md-3">
          <Card
            title="Login"
            url="/administrador/login"
            imageUrl="https://img.freepik.com/vector-gratis/ilustracion-icono-avatar-usuario_53876-5907.jpg?size=626&ext=jpg&ga=GA1.2.1762212929.1685554050&semt=robertav1_2_sidr"
            className="card"
          />
        </div>
      </div>
    </div>
  );
}

export default VistaMaiAdmin;
