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
            if (this.descripcion =="") {
                document.getElementById("Descripcion").focus();
            } else {
                alert(this.nombre);
                alert(this.id);
                alert(this.action);

                var id = this.id;
                var nombre = this.nombre;
                var descripcion = this.descripcion;
                var estado = this.estado;
                var action = this.action;
                $.ajax({
                    type: "POST",
                    url: action,
                    data: {
                        id, nombre, descripcion, estado
                    },
                    success: function (response) {
                        if (Response == "Save") {
                            window.location.href = "Categoria"

                        }
                        else {
                            alert("no funciona ")

                        }
                           

                    }

                });



            }



        }

    }
}
