$(document).ready(function () {
    const params = new URLSearchParams(window.location.search);
    const name = params.get("name");
    const lastName = params.get("apellido");

    if (name) {
        $("#name").val(name);
    }
    if (lastName) {
        $('#last-name').val(lastName);
    }

    //validations
    $('#shippingForm').validate({
        rules: {
            name: {
                required: true,
            },
            lastName: {

                required: true,
            },
            email: {
                required: true,
                email: true,
            },
            address: {

                required: true,
            },
            country: {
                required: true,
            },
            region: {
                required: true,
            },
            city:{
                required: true,
            },
            zip: {
                required: true,
                minlength: 4,
            }
        },
        messages: {
            name: "Please enter your name",
            lastName: "Please enter your last name",
            email: {
                required: "Please enter your email",
                email: "Please enter a valid email address"
            },
            address: "Please enter your address",
            country: "Please enter your country",
            region: "Please enter your region",
            city: "Please enter your city",
            zip: {
                required: "Please enter your zip code",
                minlength: "Zip code must be at least 4 characters long"
            }
        },
        submitHandler: function (form) {
            alert(`Completado \nName:${name} \napellido:${lastName} `);
        }
    })
})