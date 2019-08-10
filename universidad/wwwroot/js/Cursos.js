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
    GetCategoria() {
        var action = this.action;
        var count = 1;
        $.ajax({
            type: "POST",
            url: action,
            data: {},
            success: (response) => {
                console.log(response);
                if (0 < response.length) {
                    for (var i = 0; i < response.length; i++) {
                        document.getElementById('CategoriaCursos').options[count] = new Option(response[i].nombre, response[i].caterogiaID);
                        count++;
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
        document.getElementById("Costo").value = "";
        document.getElementById("Estado").checked = false;
        document.getElementById('CategoriaCursos').selectedIndex = 0;
        document.getElementById("mensaje").innerHTML = "";

        $('#modalCS').modal('hide');
    }
}
