import React from 'react'
import Card from '../../templates/Card'
function RegistroConsumo(){
    return(
        <div>
            <Card title={"Desayuno"} url={"/cliente/consumo/filtro/desayuno"}/>
            <Card title={"Merienda Mañana"} url={"/cliente/consumo/filtro/meriendadia"}/>
            <Card title={"Almuerzo"} url={"/cliente/consumo/filtro/almuerzo"}/>
            <Card title={"Merienda Tarde"} url={"/cliente/consumo/filtro/meriendatarde"}/>
            <Card title={"Cena"} url={"/cliente/consumo/filtro/cena"}/>
        </div>
    )
}
export default RegistroConsumo