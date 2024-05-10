$(document).ready(function () {
    $("#form-reserva").validate({
        rules: {
            name: {
                required: true,
                minlength: 1,
                maxlength: 25
            },
            email: {
                required: true,
                email: true
            },
            cantidad_huespedes: {
                required: true,
                min: 1,
                max: 3
            },
            tipo_habitacion: {
                required: true,
            },
            terminos: {
                required: true
            }
        },
        messages: {
            name: {
                required: "nombre apellido es necesario",
                maxlengh: "nombre muy largo"
            },
            email: {
                required: "email es obligatorio",
                emai: "ingrese un email valido"
            },
            cantidad_huespedes: {
                required: "ingrese la cantidad de huespedes",
                min: "dbe por lo menos haber un huesped",
                max: "no se permiten mas de 3 huespedes"
            },
            tipo_habitacion:{
                required:"please choose one sir"
            },
            terminos:{
                required:"tenes que hacer click aca pa"
            }
        },
        errorClass: "text-danger m-2"

    })
})