import React from 'react'
function ListaPaciente({nombre,apellido1,apellido2}){
    return(
        <div>
            <table>
                <tr>
                   <th>nombre</th>
                   <th>apellido1</th>
                   <th>apellido2</th>
                </tr>
                <tr>
                    <td>{nombre}</td>
                    <td>{apellido1}</td>
                    <td>{apellido2}</td>
                </tr>

            
            </table>
        </div>
    )
}

export default ListaPaciente