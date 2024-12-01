// URLs base del backend para sucursales y configuraciones
const baseUrl = "http://localhost:5133/api/Sucursal"
const configURl = "http://localhost:5133/config"

// Función para obtener las configuraciones y aplicarlas al formulario

async function getConfgig() {
    try {
        const response = await fetch(configURl); // Realiza una petición GET al endpoint de configuraciones
        const result = await response.json();    // Convierte la respuesta a JSON
        console.log(result);                     // Imprime el resultado en la consola

        // Verifica si la respuesta es exitosa y contiene datos
        if (result.success && result.data ) {
            // Recorre cada configuración y aplica los estilos correspondientes al formulario
            result.data.forEach(config => {
                if (config.nombre === "padding-top") {
                    document.querySelector("form").style.paddingTop = config.valor
                } else if(config.nombre === "padding-left") {
                    document.querySelector("form").style.paddingLeft = config.valor
                }

            })
            console.log("corrected configurations applied")
        } else {
            console.error("No se encontraron resultado")
        }
    } catch (error) {
        console.error("error al obtener config",error )
    }
}

async function getSucursal() {
    try {
        const response = await fetch(baseUrl); // Realiza una petición GET al endpoint de sucursales
        const result = await response.json();  // Convierte la respuesta a JSON
        console.log("sucursal object", result); // Imprime la sucursal obtenida para debug

        // Verifica si la respuesta es exitosa y contiene datos

        if (result.success && result.data ) {
            document.getElementById("Id").value = result.data.id
            document.getElementById("Nombre").value = result.data.nombre
            document.getElementById("Ciudad").value = result.data.idCiudad
            document.getElementById("Telefono").value = result.data.telefono
            document.getElementById("ApellidoTitular").value = result.data.apellidoTitular
            document.getElementById("NombreTitular").value = result.data.nombreTitular
            document.getElementById("FechaAlta").value = result.data.fechaAlta.split("T")[0]

        }
    } catch (err){
        console.error("error al obtener sucursal",err)
    }
}

async function putSucursal(event) {
    event.preventDefault(); // Evita que el formulario recargue la página

    // Crea un objeto con los datos del formulario

    const sucursal = {
        id: document.getElementById("Id").value,
        nombre: document.getElementById("Nombre").value,
        idCiudad: document.getElementById("Ciudad").value,
        idTipo: document.getElementById("Tipo").value,
        idProvincia: document.getElementById("Provincia").value,
        telefono: document.getElementById("Telefono").value,
        nombreTitular: document.getElementById("NombreTitular").value,
        apellidoTitular: document.getElementById("ApellidoTitular").value,
        fechaAlta: document.getElementById("FechaAlta").value
    }

    try {
        const responce = await fetch(baseUrl, {
            method: "PUT", // Especifica el méto do PUT para actualizar
            headers: {
                "Content-Type": "application/json", // Especifica que el cuerpo es JSON
            },
            body: JSON.stringify(sucursal) // Convierte el objeto a JSON y lo envía como cuerpo
        });
        const result = await responce.json(); // Convierte la respuesta a JSON
        if (result.success ) {
            console.log("put successful", result.data)
        } else {
            console.error("error al obtener sucursal",result.message )
        }
    } catch (error) {
        console.error("error al obtener sucursal",error )
    }
}

document.addEventListener("DOMContentLoaded",  function () {
    getConfgig(); // Obtiene y aplica las configuraciones
    getSucursal(); // Obtiene los datos de la sucursal y los carga en el formulario

    // Asocia la función de actualización al evento submit del formulario
    document.querySelector("form").addEventListener("submit", putSucursal);
})


// Función para crear una nueva sucursal (POST)
async function pushSucursal(event) {
    event.preventDefault(); // Evita que el formulario recargue la página

    // Crea un objeto con los datos del formulario
    const sucursal = {
        id: crypto.randomUUID(), // Genera un GUID para la nueva sucursal
        nombre: document.getElementById("Nombre").value,
        idCiudad: document.getElementById("Ciudad").value,
        idTipo: document.getElementById("Tipo").value,
        idProvincia: document.getElementById("Provincia").value,
        telefono: document.getElementById("Telefono").value,
        nombreTitular: document.getElementById("NombreTitular").value,
        apellidoTitular: document.getElementById("ApellidoTitular").value,
        fechaAlta: new Date().toISOString().split("T")[0] // Fecha actual en formato ISO (solo la parte de fecha)
    };

    try {
        const response = await fetch(baseUrl, {
            method: "POST", // Especifica el método POST para crear
            headers: {
                "Content-Type": "application/json", // Especifica que el cuerpo es JSON
            },
            body: JSON.stringify(sucursal) // Convierte el objeto a JSON y lo envía como cuerpo
        });

        const result = await response.json(); // Convierte la respuesta a JSON
        if (result.success) {
            console.log("Sucursal creada exitosamente", result.data);
            alert("Sucursal creada con éxito.");
        } else {
            console.error("Error al crear sucursal", result.message);
            alert("Error al crear la sucursal: " + result.message);
        }
    } catch (error) {
        console.error("Error al crear sucursal", error);
        alert("Error al crear la sucursal: " + error.message);
    }
}

// // Función para eliminar una sucursal por ID (DELETE)
// async function deleteSucursal(id) {
//     try {
//         const response = await fetch(`${baseUrl}/${id}`, {
//             method: "DELETE", // Especifica el método DELETE
//         });
//
//         const result = await response.json(); // Convierte la respuesta a JSON
//         if (result.success) {
//             console.log("Sucursal eliminada exitosamente", result.data);
//             alert("Sucursal eliminada con éxito.");
//         } else {
//             console.error("Error al eliminar sucursal", result.message);
//             alert("Error al eliminar la sucursal: " + result.message);
//         }
//     } catch (error) {
//         console.error("Error al eliminar sucursal", error);
//         alert("Error al eliminar la sucursal: " + error.message);
//     }
// }
//
// // Ejemplo de uso para DELETE (se podría invocar al seleccionar una sucursal de una lista)
// document.getElementById("deleteButton").addEventListener("click", () => {
//     const id = document.getElementById("Id").value; // Obtén el ID desde el formulario
//     if (id) {
//         deleteSucursal(id); // Llama a la función delete con el ID proporcionado
//     } else {
//         alert("Por favor, selecciona una sucursal para eliminar.");
//     }
// });
//
// // Ejemplo de uso para POST (en lugar de PUT o en otro formulario)
// document.getElementById("createButton").addEventListener("click", pushSucursal);