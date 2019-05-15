// Write your JavaScript code.
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
            x.remove(i);
        }

       
        $.each(items, function (index, val) {
            $('input[name=Id]').val(val.id);
            $('input[name=UserName]').val(val.userName);
            $('input[name=Email]').val(val.email);
            $('input[name=PhoneNumber]').val(val.phoneNumber);
            document.getElementById('select').options[0] = new Option(val.role, val.roleId);


            $('input[name=EliminarId]').val(val.id);


        });
}

function getRoles(Action) {
    $.ajax({
        type: "POST",
        url: Action,
        data: {},
        success: function (response) {
            if (j == 0) {
                for (var i = 0; i < response.length; i++) {
                    document.getElementById('select').options[i] = new Option(response[i].text, response[i].value);
                    document.getElementById('selectNuevo').options[i] = new Option(response[i].text, response[i].value);
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
    role = document.getElementById('select');
    selectRole = role.options[role.selectedIndex].text;


$.ajax({
    type:"POST",
    url: action,
    data: { id, userName, phoneNumber,selectRole },
    success: function (response) {
        if (response == "Save") {
            window.location.href = "ApplicationUser"
        } else {
            alert("no dejo Editar ");
        }
    }
     

    })

}

$('#ModalEliminar').on('shown.bs.modal', function () {
    $('#myInput').focus()
})

function EliminarUsuario(action) {

    var id = $('input[name=EliminarId]')[0].value;
   $.ajax({
        type: "POST",
        url: action,
        data: { id },
        success: function (evaluar) {
            if (evaluar == "borrando") {
                window.location.href = "ApplicationUser"

            }
            else {
                alert("no lo puedes eliminar")
            }

        }

    });

}
$('#ModalCrear').on('shown.bs.modal', function () {
    $('#myInput').focus()
})


function CrearUsuario(action) {
     
  
    PasswordHash = $('input[name=PasswordHash]')[0].value;
    correo = document.getElementById('email');

    repeticionclave= $('input[name=PasswordRepi]')[0].value;
    telefono = $('input[name=PhoneNumbernuevo]')[0].value;
    role = document.getElementById('selectNuevo');
    SelectRole = role.options[role.selectedIndex].text;

    respuesta = "";



    //validar que los campos no este vacios 

    if (correo ="null") {
        alert("Ingrese un correo")
    } else {

        if (clave = "") {
            alert("ingrse una clave ")
        }
        else {
            $.ajax({
                type:"POST",
                url: action,
                data: {correo,PasswordHash,telefono,SelectRole},
                success: function (response) {
                    if (response == "save") {
                        window.location.href = "ApplicationUser";
                    } else
                        alert("no esta guardado")

                }


            });
        }
    }







}
