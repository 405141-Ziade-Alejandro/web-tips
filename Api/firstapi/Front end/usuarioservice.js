const url_api = "http://localhost:5145/usuarios/GetAll"

function listar_usuarios() {
    fetch(url_api)
    .then((respuesta) => respuesta.json())
    .then((respuesta)=> {
        if (!respuesta.success){
            alert("error de api")
            alert(respuesta.errorMessage)
        }
        else {
            const cuerpo_tabla = document.querySelector('tbody')

            respuesta.data.forEach(usu => {
                const fila = document.createElement('tr')
                fila.innerHTML += "<td>" + usu.email+"</td>"

                fila.innerHTML += "<td>" + usu.nombreUsuario+"</td>"

                cuerpo_tabla.append(fila)
            });
        }
    }).catch(err=>{
        alert("algo salio mal"+ err)
    })
}