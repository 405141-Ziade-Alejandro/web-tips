document.getElementById('formulario-albanil').addEventListener('submit', async function (event) {
    
    event.preventDefault()

    const nombre = document.getElementById('input-nombre').value
    const apellido = document.getElementById('input-apellido').value
    const dni = document.getElementById('input-dni').value
    const telefono = document.getElementById('input-telefono').value
    const calle = document.getElementById('input-calle').value
    const altura = document.getElementById('input-numero').value
    const codigo_postal = document.getElementById('input-codpostal').value

    const data = {
        nombre: nombre,
        apellido: apellido,
        dni: dni,
        telefono: telefono,
        calle: calle,
        numero: altura,
        codPost: codigo_postal
    }

    const responce = await fetch('http://localhost:5133/api/Parcial/postAlbanil', {
        method: 'POST',
        headers: {
            'Content-type': 'application/json'
        },
        body: JSON.stringify(data)
    })

    const responce_json = await responce.json()

    if (!responce_json.success) {
        alert(responce_json.message)
        return
    } else {
        alert(responce_json.message)
    }

    document.getElementById('formulario-albanil').reset()

})