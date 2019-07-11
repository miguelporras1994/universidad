var localStorage = window.localStorage;
class Categorias {
    constructor(id, nombre, descripcion, estado, action) {

        this.id = id;
        this.nombre = nombre;
        this.descripcion = descripcion;
        this.estado = estado;
        this.action = action;

    }




    GuardarCategoria() {
        if (this.id == "") {
            document.getElementById("CategoriaID")

        }

        if (this.nombre == "") {
            document.getElementById("Nombre").focus();

        } else {
            if (this.descripcion == "") {
                document.getElementById("Descripcion").focus();
            } else {

                var id = this.id;
                var nombre = this.nombre;
                var descripcion = this.descripcion;
                var estado = this.estado;
                var action = this.action;
                var mensaje = '';
                $.ajax({
                    type: "POST",
                    url: action,
                    data: {
                        id, nombre, descripcion, estado
                    },
                    success: (response) => {
                        $.each(response, (index, val) => {
                            mensaje = val.code;
                        });


                        if (mensaje == "Save") {
                            this.restablecer();
                        } else {

                            document.getElementById("mensaje").innerHTML = "no se pudo guardar la categoria "

                        }
                    }


                });

            }
        }
    }


    getCategoria(id) {
        var action = this.action;
        $.ajax({
            type: "POST",
            url: action,
            data: { id },
            success: (response) => {
                console.log(response);
                if (response[0].estado) {
                    document.getElementById("titleCategoria").innerHTML = "Esta seguro de desactivar la categoría " + response[0].nombre;
                } else {
                    document.getElementById("titleCategoria").innerHTML = "Esta seguro de habilitar la categoría " + response[0].nombre;
                }
                localStorage.setItem("categoria", JSON.stringify(response));

            }


        });
    }

    editarCategoria(id, funcion) {
        var nombre = null;
        var descripcion = null;
        var estado = null;
        var action = null;
        switch (funcion) {
            case "estado":
                var response = JSON.parse(localStorage.getItem("categoria"));
                nombre = response[0].nombre;
                descripcion = response[0].descripcion;
                estado = response[0].estado;
                localStorage.removeItem("categoria");
                this.editar(id, nombre, descripcion, estado, funcion);
                break;
           
        }
    }
    editar(id, nombre, descripcion, estado, funcion) {
        var action = this.action;
        $.ajax({
            type: "POST",
            url: action,
            data: { id, nombre, descripcion, estado, funcion },
            success: (response) => {
                console.log(response);
                this.restablecer();
            }
        });
    }



    restablecer() {
        document.getElementById("Nombre").value = "";
        document.getElementById("Descripcion").value = "";
        document.getElementById("mensaje").innerHTML = "";
        document.getElementById("Estado").selectedIndex = 0;
        $('#CrearCategoria').modal('hide');
        $('#ModaEstado').modal('hide');
        filtrarDatos(1)
    }


    BuscarDatos(numPagina) {
        var valor = this.id;
        var action = this.action;
        if (valor == "") {
            valor = "null";
        }
        $.ajax({
            type: "POST",
            url: action,
            data: { valor, numPagina },
            success: (response) => {
                console.log(response);
                $.each(response, (index, val) => {
                    $("#resultSearch").html(val[0]);
                    $("#paginado").html(val[1]);

                });
            }
        });
     
    }


    
}