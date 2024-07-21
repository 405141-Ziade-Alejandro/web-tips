async function cargar_obras() {
    const api = "http://localhost:5133/api/Parcial/getobras"

    try {
        const responce = await fetch(api)
        let responce_json = await responce.json()
        if (!responce_json.success) {
            alert(responce_json.message)
        }

        let obras = responce_json.data
        console.log(obras);
        let obras_body = document.getElementById("table-body")

        obras.forEach(element => {
            const row = `<tr>
                    <td>${element.nombre}</td>
                    <td>${element.datosVarios}</td>
                    <td>${element.nombreTipoObra}</td>
                    <td>${element.cantAlbaniles}</td>
                    <td>
                        ${element.nombreTipoObra==='Edificio' ? `<button class="btn btn-primary" onclick="asignar_alb('${element.id}')">Asignar Albanil</button>` : ''}     
                    </td>
                    </tr>`
                    console.log(element.nombre);
                    obras_body.innerHTML+=row
        });
    } catch (error) {
        alert(error)
        console.log(error)
    }
}
function asignar_alb(id_obra) {
    window.location.href= `index2.html?idObra=${id_obra}`
}

cargar_obras()