﻿// Write your JavaScript code.
$('#ModalEditar').on('shown.bs.modal', function () {
    $('#myInput').focus()
})

function getUsuario(id, action) {
    $.ajax({
        type:"POST",
        url: action,
        data: { id },
        success: function (response){

            mostrarUsuario(response);
        }


    });
}
var j = 0;
var id;
var userName;
var email;
var phoneNumber;
var index;


    var items;
    function mostrarUsuario(response) {
        items = response;
        for (var i = 0; i < 3; i++) {
            var x = document.getElementById('select');
            X.romove(i);
        }

       
        $.each(items, function (index, val) {
            $('input[name=Id]').val(val.id);
            $('input[name=UserName]').val(val.userName);
            $('input[name=Email]').val(val.email);
            $('input[name=PhoneNumber]').val(val.phoneNumber);
            document.getElementById('select').options[0] = new Option(val.role, val.roleId);


        });
}

function getRoles(Action) {
    $.ajax({
        type: "POST",
        url: action,
        data: {},
        success: function (response) {
            if (j == 0) {
                for (var i = 0; i < response.length; i++) {
                    document.getElementById('select').options.[i] = new Option(response[i].text, response[i].value);
                }
                j = 1;
            }
            }
        
    });

    }
           

function editarusuario(action) {
    id = $('input[name=Id]')[0].value;
    userName = $('input[name=UserName]')[0].value;
    phoneNumber = $('input[name=PhoneNumber]')[0].value;


$.ajax({
    type:"POST",
    url: action,
    data: { id, userName, phoneNumber },
    success: function (response) {
        if (response == "Save") {
            window.location.href = "ApplicationUser"
        } else {
            alert("no dejo Editar ");
        }
    }
     

    })

}