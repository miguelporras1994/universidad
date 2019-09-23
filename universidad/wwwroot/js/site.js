// Write your JavaScript code.
//alert("hola site")


$().ready(() => {
    var url = window.location;




    switch (url.pathname) {
        case "/Categorias":

    //document.getElementById("filtrar").focus();
    filtrarDatos(1, "nombre");
            break;

        case "/Curso":
            //document.getElementById("filtrarCurso").focus();
            filtrarCurso(1, "id");
            ValidarCategoria(0, 0);
            break;

        case "/Estudiante":
            FiltrarEstudiante(1, "id");
            break;
}
});



$('#ModalEditar').on('shown.bs.modal', function () {
    $('#myInput').focus()
})

function getUsuario(id, action ) {
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
// PROGRAMACION DE CATEGORIA

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


     email = $('input[name=email]')[0].value;     
  
    PasswordHash = $('input[name=PasswordHash]')[0].value;

    repeticionclave= $('input[name=PasswordRepi]')[0].value;
    telefono = $('input[name=PhoneNumbernuevo]')[0].value;
    role = document.getElementById('selectNuevo');
    SelectRole = role.options[role.selectedIndex].text;

    respuesta = "";



    //validar que los campos no este vacios 

    if (email =="n") {
        alert("Ingrese un correo")
    } else {

        if (PasswordHash =="") {
            alert("ingrse una clave ")
        }
        else {
            $.ajax({
                type:"POST",
                url: action,
                data: {email,PasswordHash,telefono,SelectRole},
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

$('#CrearCategoria').on('shown.bs.modal', function () {
    $('#myInput').focus()
})


$('#EditarCaterogia').on('shown.bs.modal', function () {
    $('#myInput').focus()
})


$('#EliminarCategoria').on('shown.bs.modal', function () {
    $('#myInput').focus()
})


var AgregarCategoria = () => {
    //var id = document.getElementById("CategoriaID").value;
    var nombre = document.getElementById("Nombre").value;
    var descripcion = document.getElementById("Descripcion").value;
    var estados = document.getElementById('Estado');
    var estado = estados.options[estados.selectedIndex].value;
    var action = 'Categorias/Crear';
    var categoria = new Categorias(id,nombre,descripcion,estado,action);
    categoria.GuardarCategoria();

}


var filtrarDatos = (numPagina,order) => {
    var valor = document.getElementById("filtrar").value;
      var action = 'Categorias/FiltrarDatos';
    var envio = new Categorias(valor, "", "", "",action);
    envio.BuscarDatos(numPagina,order);

}



var BuscarEstado = (id) => {

    idCategoria = id;
    var action = 'Categorias/BuscarEstado';
    var encontrar = new Categorias("", "", "","",action);
    encontrar.BuscarEstado(id);
}


var EditarEstado = () => {
    var action = 'Categorias/EditarEstado';
    var categoria = new Categorias("", "", "","", action);
    categoria.EditarEstado(idCategoria , "estado")
}

var BuscarCategoria = (id) => {
    var action = 'Categorias/BuscarEstado';
    var Buscar = new Categorias(id, "", "", "", action);
    Buscar.BuscarCategoria(id)
}

var EditarCategoria = () => {
    var id = document.getElementById("Categoria2").value;
    var nombre = document.getElementById("Nombre1").value;
    var descripcion = document.getElementById("Descripcion1").value;
    var estados = document.getElementById('Estado1');
    var estado = estados.options[estados.selectedIndex].value;
    var action = 'Categorias/EditarCategoria';
    var categoria = new Categorias(id, nombre, descripcion, estado, action);
    categoria.EditarCategoria();

};


//PROGRAMACION DE MODULO CURSO :)



$('#CrearCurso').on('shown.bs.modal', function () {
    $('#myInput').focus()
})



var filtrarCurso  = (numPagina, order) => {
    var valor = document.getElementById("filtrarCurso").value;
    var action = 'Curso/FiltrarCurso';
    var envio = new Cursos(valor,"", "", "", "","","", action);
    envio.BuscarCursos(numPagina, order);

}

var ValidarCategoria = (id , funcion) => {
    var action = 'Curso/ValidarCategoria';
    var Curso = new Cursos("","","","","","","",action);
    Curso.GetCategoria(id,funcion);
}
var agregarCurso = () => {
    var action = 'Curso/AgregarCurso';
    var nombre = document.getElementById("Nombre").value;
    var descripcion = document.getElementById("Descripcion").value;
    var creditos = document.getElementById("Creditos").value;
    var horas = document.getElementById("Horas").value;
    var costo = document.getElementById("osto").value;
    var estado = document.getElementById("Estado").checked
    var categorias = document.getElementById('CategoriaCursos');
    var categoria = categorias.options[categorias.selectedIndex].value;
    var curso = new Cursos(nombre, descripcion, creditos, horas, costo, estado, categoria, action);
    curso.agregarCurso("", "");
}

var BuscarCurso = (id) => {
    var action = 'Curso/BuscarCurso';
    var Buscar = new Cursos(id, "", "", "", "", "", "", action);
    Buscar.BuscarCurso(id)
}

var EditarCurso = () => {
    action = "Curso/EditarCurso"
    cursoid = document.getElementById("Cursoid1").value;
    nombre = document.getElementById("Nombre1").value;
    descripcion = document.getElementById("Descripcion1").value;
    creditos = document.getElementById("Creditos1").value;
    horas = document.getElementById("Horas1").value;
    costo = document.getElementById("Costo1").value;
    estados = document.getElementById('Estado1');
    estado = estados.options[estados.selectedIndex].value;
    categorias = document.getElementById('CategoriaCursos1');  
    categoria = categorias.options[categorias.selectedIndex].value;
    var curso = new Cursos(nombre, descripcion, creditos, horas, costo, estado, categoria, action);
    curso.EditarCurso(cursoid);
    


};

var BuscarEstadoCurso = (id) => {
    action = "Curso/BuscarEstadoCurso"
    var curso = new Cursos("", "", "", "", "", "", "",action);
    curso.BuscarEstadoCurso(id);


};


var EditarEstadocurso = () => {
    id = document.getElementById("Cursoid2").value;
    action = "Curso/EditarEstadocurso"
    var curso = new Cursos("", "", "", "", "", "", "", action);
    curso.EditarEstadocurso (id);
}





//PROGRAMACION DE MODULO ESTUDIANTE :)



$('#CrearEstudiante').on('shown.bs.modal', function () {
    $('#myInput').focus()
})



var FiltrarEstudiante = (numPagina, order) => {
    //var valor = document.getElementById("filtrarCurso").value;
    var action = 'Estudiante/FiltrarEstudiante  ';
    var envio = new Estudiante("", "", "", "", "", "", "", action);
    envio.BuscarEstudiantes(numPagina, order);

}

var ValidarCategoria = (id, funcion) => {
    var action = 'Curso/ValidarCategoria';
    var Curso = new Cursos("", "", "", "", "", "", "", action);
    Curso.GetCategoria(id, funcion);
}
var agregarCurso = () => {
    var action = 'Curso/AgregarCurso';
    var nombre = document.getElementById("Nombre").value;
    var descripcion = document.getElementById("Descripcion").value;
    var creditos = document.getElementById("Creditos").value;
    var horas = document.getElementById("Horas").value;
    var costo = document.getElementById("osto").value;
    var estado = document.getElementById("Estado").checked
    var categorias = document.getElementById('CategoriaCursos');
    var categoria = categorias.options[categorias.selectedIndex].value;
    var curso = new Cursos(nombre, descripcion, creditos, horas, costo, estado, categoria, action);
    curso.agregarCurso("", "");
}

var BuscarEstudiante = (id) => {
    var action = 'Estudiante/BuscarEstudiante';
    var Buscar = new Estudiante(id, "", "", "", "", "", "", action);
    Buscar.BuscarEstudiante(id)
}

var EditarEstudiantes = () => {
    action = "Estudiante/EditarEstudiante"
    Cedula = document.getElementById("Nombre").value;
    Nombre = document.getElementById("Nombre").value;
    Apellido= document.getElementById("Apellido").value;
    Correo = document.getElementById("Correo").value;
    Telefono = document.getElementById("Telefono").value;
    Direccion = document.getElementById("Direccion").value;
    costo = document.getElementById("Costo1").value;
    estados = document.getElementById('Estado1');
    estado = estados.options[estados.selectedIndex].value;
    categorias = document.getElementById('CategoriaCursos1');
    categoria = categorias.options[categorias.selectedIndex].value;
    var curso = new Cursos(nombre, descripcion, creditos, horas, costo, estado, categoria, action);
    curso.EditarCurso(cursoid);



};

var BuscarEstadoCurso = (id) => {
    action = "Curso/BuscarEstadoCurso"
    var curso = new Cursos("", "", "", "", "", "", "", action);
    curso.BuscarEstadoCurso(id);


};


var EditarEstadocurso = () => {
    id = document.getElementById("Cursoid2").value;
    action = "Curso/EditarEstadocurso"
    var curso = new Cursos("", "", "", "", "", "", "", action);
    curso.EditarEstadocurso(id);
}

// Estudiante

BuscarEstudiante = (id) => {
    action = "Estudiante/BuscarEstudiante";
    var buscar = new Estudiante("", "", "", "", "", "", "", action)
    buscar.BuscarEstudiante(id)

}


var EditarEstudiante = () => {

    var action = "Estudiante/EditarEstudiante";
    var id = document.getElementById("IdEstudiante").value;
    var Nombre = document.getElementById("Nombre").value;
    var Apellido = document.getElementById("Apellido").value;
    var Correo = document.getElementById("Correo").value;
    var Telefono = document.getElementById("Telefono").value;
    var Direccion = document.getElementById("Direccion").value;
    var Nacimiento = document.getElementById("Nacimiento").value;
    var Estados = document.getElementById('Estado');
    var Estado = Estados.options[Estados.selectedIndex].value;
    var Estudio = new Estudiante(Nombre, Apellido, Correo, Telefono, Direccion, Nacimiento , Estado, action);
    Estudio.EditarEstudiante(id);
     }

    
