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
var id
var userName
var email
var phoneNumber

    var items;
    function mostrarUsuario(response) {
        items = response;
        $.each(items, function (index, val) {
            $('input[name=Id]').val(val.id);
            $('input[name=UserName]').val(val.userName);
            $('input[name=Email]').val(val.email);
            $('input[name=PhoneNumber]').val(val.phoneNumber);


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
            window.location.href = "ApplicationUser/Index"
        } else {
            alert("no dejo Editar ");
        }
    }
     

    })

}