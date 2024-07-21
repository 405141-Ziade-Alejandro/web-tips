const api_url = "http://localhost:5133/api/Parcial/"
const urlParams = new URLSearchParams(window.location.search)

const id_obra = urlParams.get('idObra')
console.log(id_obra);

document.getElementById("obra-id").innerText = `id de la obra: ${id_obra}`

async function cargarAlbanilesNotEnObra() {
    const responce = await fetch(`${api_url}getalbaniles?idObra=${id_obra}`)
    const responce_json = await responce.json()

    if (!responce_json.success) {
        alert(responce_json.message)
    }

    let select = document.getElementById("albanil-select")

    responce_json.data.forEach(element => {
        const option = document.createElement('option')
        option.value = element.id
        option.innerText = `${element.nombre} ${element.apellido}`
        select.appendChild(option)
    });

}

async function asignarAlbanil() {
    const selected_albanil_id = document.getElementById("albanil-select").value
    console.log(selected_albanil_id);
    const text_tarea = document.getElementById("tarea-text-area").value
    console.log(text_tarea);

    const data = {
        idAlbanil: selected_albanil_id,
        idObra: id_obra,
        tareaArealizar: text_tarea
    }

    const responce = await fetch(`${api_url}postAlbanilxobra`, {
        method:'POST',
        headers: {
            'Content-type':'application/json'
        },
        body:JSON.stringify(data)
    })
    const responce_json = await responce.json()
    if (!responce_json.success) {
        alert(responce_json.message)
    }
    alert(responce_json.message)
}

cargarAlbanilesNotEnObra()