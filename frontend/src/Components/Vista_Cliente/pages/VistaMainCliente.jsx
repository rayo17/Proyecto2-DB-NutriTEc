import React from 'react'
import Card from '../../templates/Card'
import '../../../styleCss/Cliente/VistaMainCliente.css'
function VistaMainCliente(){
    return(
        <div className='VistaMainCliente'>
            <Card title='Registro' url='cliente/registro' imageUrl={"https://img.freepik.com/vector-gratis/ilustracion-concepto-sesion-movil_114360-135.jpg?size=626&ext=jpg&ga=GA1.1.1762212929.1685554050&semt=robertav1_2_sidr"}/>
            <Card title='Login' url='/cliente/login' imageUrl={'https://img.freepik.com/vector-gratis/ilustracion-icono-avatar-usuario_53876-5907.jpg?size=626&ext=jpg&ga=GA1.2.1762212929.1685554050&semt=robertav1_2_sidr'}/>
            <Card title='Registro Consumo' url='/cliente/consumo' imageUrl={'https://img.freepik.com/vector-gratis/ilustracion-concepto-caza-productos_114360-791.jpg?size=626&ext=jpg&ga=GA1.1.1762212929.1685554050&semt=robertav1_2_sidr'}/>
            <Card title='Gestion Producto' url='/cliente/producto' imageUrl={'https://img.freepik.com/vector-gratis/productos-alimenticios-cotidianos-comunes-conjunto-imagenes-predisenadas-dibujos-animados-queso-pescado-salchichas-leche_1284-42699.jpg?size=626&ext=jpg&ga=GA1.1.1762212929.1685554050&semt=robertav1_2_sidr'}/>
            <Card title='Gestion receta' url={'/cliente/receta'} imageUrl={'https://img.freepik.com/vector-gratis/concepto-culinario-ilustracion-restaurante-negocios_81522-1043.jpg?size=626&ext=jpg&ga=GA1.1.1762212929.1685554050&semt=robertav1_2_sidr'}/>
            <Card title='Reporte de Avance' imageUrl={'https://img.freepik.com/vector-gratis/hombre-negocios-documento_23-2147519967.jpg?size=626&ext=jpg&ga=GA1.1.1762212929.1685554050&semt=robertav1_2_sidr'}/>
        </div>
        )
}

export default VistaMainCliente