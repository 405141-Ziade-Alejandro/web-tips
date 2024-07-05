var url = "https://localhost:44302/api/Socio/GetAll"

function listarSocios(){
    fetch(urlApi)
    .then((respuesta) => respuesta.json())
    .then((respuesta) => {
        if(!respuesta.success){
            alert("Error al consumir la api")
            alert(respuesta.errorMessage)
        }
        else{
            const cuerpoTabla = document.querySelector('tbody')

            respuesta.data.forEach(soc => {
                const fila = document.createElement('tr')
                fila.innerHTML += "<td>"+soc.nombre+"</td>"
                fila.innerHTML += "<td>"+soc.apellido+"</td>"
                fila.innerHTML += "<td>"+soc.dni+"</td>"
                fila.innerHTML += "<td>"+soc.nombreDeporte+"</td>"

                cuerpoTabla.append(fila)
            });
        }
    }).catch(err =>{
        alert("Algo salio mal... " +err)
    })
}