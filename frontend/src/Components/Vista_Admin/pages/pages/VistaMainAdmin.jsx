import React from 'react'
import Card from '../../../templates/Card'
import '../../../../styleCss/Templates/Card.css'

function VistaMaiAdmin(){
    return(
        <div>
            <Card title='login' url='/administrador/login' imageUrl={'https://img.freepik.com/vector-gratis/ilustracion-icono-avatar-usuario_53876-5907.jpg?size=626&ext=jpg&ga=GA1.2.1762212929.1685554050&semt=robertav1_2_sidr'} />
            <Card title='Productos' url='/administrador/productos'  imageUrl={'https://img.freepik.com/vector-gratis/productos-alimenticios-cotidianos-comunes-conjunto-imagenes-predisenadas-dibujos-animados-queso-pescado-salchichas-leche_1284-42699.jpg?size=626&ext=jpg&ga=GA1.1.1762212929.1685554050&semt=robertav1_2_sidr'}/>
            <Card title='Reporte' url='administrador/reporte'imageUrl={'https://img.freepik.com/vector-gratis/doodle-grafico-informe-empresarial_53876-6522.jpg?size=626&ext=jpg&ga=GA1.1.1762212929.1685554050&semt=robertav1_2_sidr'}/>
        </div>
    )
}

export default VistaMaiAdmin