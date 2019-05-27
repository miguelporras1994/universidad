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
                var mensaje ='';
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


                        if (mensaje == "SAVE") {
                            this.restablecer();
                        } else {

                            document.getElementById("mensaje").innerHTML = "no se pudo guardar la categoria "

                        }
                    }

                    
                });

            }
        }
    }

    restablecer() {
        document.getElementById("Nombre").value = "";
        document.getElementById("Descripcion").value = "";
        document.getElementById("mensaje").innerHTML = "";
        document.getElementById("Estado").selectedIndex = 0;
        $('#modalAC').modal('hide');
    }
}