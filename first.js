$(document).ready(function () {




        $("#form-login").validate({
            rules: {
                name: {
                    required: true
                },
                password: {
                    required: true
                },
                check:{
                    required:true
                }
            },
            messages: {
                name: {
                    required: "need a name"
                },
                password: {
                    required: "papers please"
                },
                check:{
                    required: "error es requerido"
                }
            },
            errorClass: "ml-5 text-danger",
            submitHandler: function(form){
                let name = $("#floating-name").val()

                $(location).attr('href', 'http://127.0.0.1:5500/second.html?name=' + name)
                return false

            }


        })

    
})