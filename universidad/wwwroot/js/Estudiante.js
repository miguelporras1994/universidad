class Estudiante {
    constructor(Nombre, Apellido, Correo, Telefono, Direccion, Nacimiento, Estado, action) {
        this.Nombre = Nombre;
        this.Apellido = Apellido;
        this.Correo = Correo;
        this.Telefono = Telefono;
        this.Direccion = Direccion;
        this.Estado = Estado;
        this.Naciemiento = Nacimiento;
        this.action = action
    }
    GetCategoria(id, funcion) {
        var action = this.action;
        var count = 1;
        $.ajax({
            type: "POST",
            url: action,
            data: {},
            success: (response) => {
                //console.log(response);
                //document.getElementById('CategoriaCursos').options[0] = new Option("Selecione un curso ", 0);
                //document.getElementById('CategoriaCursos1').options[0] = new Option("Selecione un curso ", 0);

                if (0 < response.length) {

                    for (var i = 0; i < response.length; i++) {
                        if (0 == funcion) {

                            document.getElementById('CategoriaCursos').options[count] = new Option(response[i].nombre, response[i].caterogiaID);

                            document.getElementById('CategoriaCursos1').options[count] = new Option(response[i].nombre, response[i].caterogiaID);
                            count++;
                        }

                        else {
                            if (1 == funcion) {


                                if (id == response[i].caterogiaID) {
                                    document.getElementById('CategoriaCursos1').options[0] = new Option(response[i].nombre, response[i].caterogiaID);
                                    document.getElementById('CategoriaCursos1').selectedIndex = 0;
                                    break
                                }
                            }

                        }

                    }
                }
            }
        });
    }
    agregarCurso(id, funcion) {
        if (this.nombre == "") {
            document.getElementById("Nombre").focus();
        } else {
            if (this.descripcion == "") {
                document.getElementById("Descripcion").focus();
            } else {
                if (this.creditos == "") {
                    document.getElementById("Creditos").focus();
                } else {
                    if (this.horas == "") {
                        document.getElementById("Horas").focus();
                    } else {
                        if (this.costos == "") {
                            document.getElementById("Costo").focus();
                        } else {
                            if (this.categoria == "0") {
                                document.getElementById("mensaje").innerHTML = "Seleccione un curso";
                            } else {
                                var nombre = this.nombre;
                                var descripcion = this.descripcion;
                                var creditos = this.creditos;
                                var horas = this.horas;
                                var costos = this.costos;
                                var estado = this.estado;
                                var categoria = this.categoria;
                                var action = this.action;
                                console.log(nombre);
                                $.ajax({
                                    type: "POST",
                                    url: action,
                                    data: {
                                        id, nombre, descripcion, creditos, horas, costos, estado, categoria, funcion
                                    },
                                    success: (response) => {
                                        if ("Save" == response) {
                                            this.restablecer();
                                        } else {
                                            document.getElementById("mensaje").innerHTML = "No se puede guardar el curso";
                                        }
                                    }
                                });
                            }
                        }
                    }
                }
            }
        }
    }
    restablecer() {
        document.getElementById("Nombre").value = "";
        document.getElementById("Descripcion").value = "";
        document.getElementById("Creditos").value = "";
        document.getElementById("Horas").value = "";
        document.getElementById("osto").value = "";
        document.getElementById("Estado").checked = false;
        document.getElementById('CategoriaCursos').selectedIndex = 0;
        document.getElementById("mensaje").innerHTML = "";

        $('#CrearCurso').modal('hide');
        filtrarCurso("", "id");
    }



     BuscarEstudiantes(numPagina, order) {
        var valor = this.nombre;
        var action = this.action;
        if (valor == "") {
            valor = "null";
        }
        $.ajax({
            type: "POST",
            url: action,
            data: { valor, numPagina, order },
            success: (response) => {
                console.log(response);
                $.each(response, (index, val) => {
                    $("#MostrarEstudiante").html(val[0]);
                    $("#paginadorEstudiante").html(val[1]);

                });
            }
        });

    }

    BuscarEstudiante(id) {
        var action = this.action;
        $.ajax({
            type: "POST",
            url: action,
            data: { id },
            success: (response) => {
                console.log(response);
                document.getElementById("IdEstudiante").value = response.terceroID;
                document.getElementById("Nombre").value = response.nombres;
                document.getElementById("Apellido").value = response.apellido;
                document.getElementById("Correo").value = response.email;
                document.getElementById("Telefono").value = response.telefono;
                document.getElementById("Direccion").value = response.direccion;
                document.getElementById("Nacimiento").value = response.fechaNacimiento;
                document.getElementById("Estado").value = response.estado;
                //ValidarCategoria(response.categoriaID, 1);
               

            }




        })
    }


 EditarEstudiante(id) {
     var Nombre =this.Nombre;
     var Apellido = this.Apellido;
     var Correo = this.Correo;
     var Telefono = this.Telefono;
     var Direccion = this.Direccion;
     var Nacimiento = this.Naciemiento;
     var Estado = this.Estado;
   
     
     var action = this.action;

        $.ajax({
            type:"POST",
            url: action,
            data: { id, Nombre, Apellido, Correo, Telefono, Direccion,Nacimiento,Estado},
            success: (response) => {
                console.log(response)
                this.cerrar();
            }
        })

    }

    cerrar() {

        $('#CrearEstudiante').modal('hide');
        
        FiltrarEstudiante(1, "id");
    }

    BuscarEstadoCurso(id) {
        var action = this.action;
        $.ajax({
            type: "POST",
            url: action,
            data: { id },
            success: (response) => {
                console.log(response)
                if (response[0].estado == true) {
                    document.getElementById("titleCurso").innerHTML = "Esta seguro de  desactivar el curso " + response[0].nombre;
                    document.getElementById("Cursoid2").value = response[0].cursoID;

                } else {

                    document.getElementById("titleCurso").innerHTML = "Esta seguro de  activar el el curso " + response[0].nombre;
                    document.getElementById("Cursoid2").value = response[0].cursoID;

                }
            }


        })

    }
    EditarEstadocurso(id) {
        var action = this.action;
        $.ajax({
            type: "POST",
            url: action,
            data: { id },
            success: (response) => {
                console.log(response)

                if (response = "Save") {
                    this.cerrar();
                } else {

                }

            }

        })
    }

}