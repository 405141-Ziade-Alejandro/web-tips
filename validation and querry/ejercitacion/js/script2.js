$(document).ready(function() {

    let name = window.location.href.slice(window.location.href.indexOf('=')+1,window.location.href.indexOf('&'))
    //slice corta la url, en dos index, index = donde empieza el nombre le agregamos 1 para que no campure el =, y el otro es en & donde termina el nombre este no lo captura

    



    $("#form-repaso").validate({// validacion no tiene function ya lo es entonces se hace con ({})
        rules:{//reglas que definen el valor
            email:{
                required:true,
                email: true
            },
            flexRadioDefault: {
                required:true
            },
            seleccion: {
                required: true
            }// si agregara un text, podria poner minlength para la cantidad de string, y si pusiera numero min or max
        },
        messages:{
            email:{
                required: "email is required"
            },
            flexRadioDefault:{
                required: "pick one please",
                email:"a valid email please"
            },
            seleccion:{
                required:"need to pick one option"
            },
        },
        errorClass:"text-danger m-2"//esto es para colorear los errores
    })

    $("#send").click(function(){
        const jsonValues={// objeto js
            name:name,
            selected: $("#seleccion").val(),//val() devuelve el valor
            check1: $("#flexCheckDefault1").is(":checked"),//is checked para ver si esta clickeado o no, se usa is(":checked")
            check2: $("#flexCheckDefault2").is(":checked"),
            check3: $("#flexCheckDefault3").is(":checked"),
            check4: $("#flexCheckDefault4").is(":checked"),
            check5: $("#flexCheckDefault5").is(":checked"),
            textarea: $("#exampleFormControlTextarea1").val(),
            radio: $("input[name='flexRadioDefault']:checked").val(),//esto es para el grupo en conjunto llamado flexRadioDefault entonces se pone en un array, y no se empieza con # tambien se chekea con :checked
            color: $("#exampleColorInput").val()

        }

        let jsonReady = JSON.stringify(jsonValues)// combierte el objeto js en string

        localStorage.setItem("form_data",jsonReady)//se guarda con string y valor
        console.log(jsonReady);
    })

})