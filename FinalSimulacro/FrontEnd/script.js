$(document).ready(function () {
    $("#formulario").validate({
        rules: {
            name: {
                required: true
            },
            lastName: {
                required: true
            },
            cargo: {
                required: true
            },
            sucursal: {
                required: true
            },
            dni: {
                required: true
            },
            jefe: {
                required: true
            }
        },
        messages: {
            name: {
                required: "Por favor, ingrese su nombre"
            },
            lastName: {
                required: "Por favor, ingrese su nombre"
            },
            cargo: {
                required: "Por favor, seleccione un cargo"
            },
            sucursal: {
                required: "Por favor, seleccione un cargo"
            },
            dni: {
                required: "Por favor, ingrese su DNI",
                digits: "el dni solo deben ser numeros"
            },
            jefe: {
                required: "Por favor, ingrese el nombre de su jefe"
            }
        },
        submitHandler: async function (form) {
            event.preventDefault()
            //api post


            const nombre = document.getElementById('name').value
            const apellido = document.getElementById('last-name').value
            const dni = document.getElementById('dni').value
            const jefe = document.getElementById('jefe').value
            console.log("nombre, ", nombre);


            const idCargo = document.getElementById('cargo').value
            const idSucursal = document.getElementById('sucursal').value

            let formulario = document.getElementById('formulario')

            let body = {
                nombre,
                apellido,
                idCargo,
                idSucursal,
                dni,
                jefe
            }
            console.log("body ", body);


            let package = JSON.stringify(body)

            const api_url = 'http://localhost:5133/api/post/empleados'

            try {
                const responce = await fetch(api_url, {
                    method: 'POST',
                    headers: {
                        'content-Type': 'application/json'
                    },
                    body: package
                })

                let responce_json = await responce.json()
                console.log("responce json", responce_json);

                if (!responce_json.success) {
                    console.log(responce_json.message);
                    alert("erro, algo se rompio")
                    return
                }
                formulario.reset()

                alert("se dio de alta con exito")


            } catch (error) {
                console.log(error);
                alert("error de red")


            }
            //fin del api post
            form.submit()
        }
    })
})

/* document.getElementById('formulario').addEventListener('submit', async function (event) {
    event.preventDefault()

    const nombre = document.getElementById('name').value
    const apellido = document.getElementById('last-name').value
    const dni = document.getElementById('dni').value
    const jefe = document.getElementById('jefe').value
    console.log(nombre);


    const idCargo = document.getElementById('cargo').value
    const idSucursal = document.getElementById('sucursal').value

    let formulario = document.getElementById('formulario')

    let body = {
        nombre,
        apellido,
        idCargo,
        idSucursal,
        dni,
        jefe
    }
    console.log(body);


    let package = JSON.stringify(body)

    const api_url = 'http://localhost:5133/api/post/empleados'

    try {
        const responce = await fetch(api_url, {
            method: 'POST',
            headers: {
                'content-Type': 'application/json'
            },
            body: package
        })
        console.log(responce);


        const responce_json = await responce.json()
        console.log(responce_json);

        if (!responce_json.success) {
            console.log(responce_json.message);
            alert("erro, algo se rompio")
            return
        }
        //formulario.reset()

        alert("se dio de alta con exito")


    } catch (error) {
        console.log(error);
        alert("error de red")
    }
}) */