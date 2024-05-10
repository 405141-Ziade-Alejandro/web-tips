$(document).ready(function () {

    $("#send").click(function () {
        //event.preventDefault()

        let name = $("#name").val()

        let pass = $("#password").val()

         if (name.length == 0 || pass.length == 0) {
            alert("you need to fill name and password")
        } else if (pass.length < 8) {
            alert("password should be at least 8 digits long")
        } else { 
            console.log("Button clicked!");
            $(location).attr('href', 'http://127.0.0.1:5500/index2.html?name='+name+'&pass='+pass)
        }
    })
})