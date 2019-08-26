class Cursos {
    constructor(nombre, descripcion, creditos, horas, costos, estado, categoria, action) {
        this.nombre = nombre;
        this.descripcion = descripcion;
        this.creditos = creditos;
        this.horas = horas;
        this.costos = costos;
        this.estado = estado;
        this.categoria = categoria;
        this.action = action
    }
    GetCategoria(id , funcion) {
        var action = this.action;
        var count = 1;
        $.ajax({
            type: "POST",
            url: action,
            data: {},
            success: (response) => {
                //console.log(response);
                document.getElementById('CategoriaCursos').options[0] = new Option("Selecione un curso ", 0);
                //document.getElementById('CategoriaCursos1').options[0] = new Option("Selecione un curso ", 0);
                
                if (0 < response.length) {
                    for (var i = 0; i < response.length; i++) {
                        if (0 == funcion) {
                            if (id == response[i].caterogiaID) {
                                document.getElementById('CategoriaCursos1').options[0] = new Option(response[i].nombre, response[i].caterogiaID);
                                break

                            }
                        }
                    else {
                        if (1 == funcion) {
                            document.getElementById('CategoriaCursos').options[count] = new Option(response[i].nombre, response[i].caterogiaID);

                            document.getElementById('CategoriaCursos1').options[count] = new Option(response[i].nombre, response[i].caterogiaID);
                            count++;
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
    }



    BuscarCursos(numPagina, order) {
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
                //console.log(response);
                $.each(response, (index, val) => {
                    $("#MostrarCurso").html(val[0]);
                    $("#paginador").html(val[1]);

                });
            }
        });

    }

    BuscarCurso(id) {
         var action = this.action;
        $.ajax({
            type : "POST",
            url: action,
            data: { id },
            success: (response) => {
                //console.log(response);
                document.getElementById("Cursoid1").value = response.cursoID;
                document.getElementById("Nombre1").value = response.nombre;
                document.getElementById("Descripcion1").value = response.descripcion;
                document.getElementById("Creditos1").value = response.creditos;
                document.getElementById("Horas1").value = response.horas;
                document.getElementById("Costo1").value = response.costo;
                ValidarCategoria(response.categoriaID, 0);
                document.getElementById("Estado1").value = response.estado;

            }




        })
    }
    

    EditarCurso(id) {
        var nombre = this.nombre;
        var descripcion = this.descripcion;
        var creditos = this.creditos;
        var horas = this.horas;
        var costos = this.costos;
        var estado = this.estado;
        var categoria = this.categoria;
        var action = this.action;
        $.ajax({
            type: "POST",
            url: action,
            data: { id, nombre, descripcion, creditos, horas, costos, estado, categoria },
            success: (response) => {
                console.log(response)
                this.cerrar();
            }
        })

    }

    cerrar() {

        $('#EditarCurso').modal('hide');
        filtrarCurso ("","id");
    }
}
