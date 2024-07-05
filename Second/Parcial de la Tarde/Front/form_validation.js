$(document).ready(function () {
    $('#registrationForm').validate({
        rules: {
            nombre: {
                required: true
            },
            apellido: {
                required: true
            },
            dni: {
                required: true
            },
            deporte: {
                required: true
            }
        },
        messages: {
            nombre: {
                required: "Por favor ingresa tu nombre"
            },
            apellido: {
                required: "Por favor ingresa tu apellido"
            },
            dni: {
                required: "Por favor ingresa tu DNI"
            },
            deporte: {
                required: "Por favor ingresa tu deporte"
            }
        },
        submitHandler: function (form) {
            // Crea una variable con el contenido del formulario
            const formData = {
                nombre: document.getElementById('inputNombre').value,
                apellido: document.getElementById('inputApellido').value,
                dni: document.getElementById('inputDni').value,
                deporte: document.getElementById('inputDeporte').value
            };

            // Almacena la variable en el localStorage
            localStorage.setItem('formData', JSON.stringify(formData));

            // Opcional: Muestra un mensaje de confirmación
            alert('Datos guardados en localStorage');

            // Opcional: Puedes enviar el formulario aquí si necesitas
            // form.submit();
        }
    });
});