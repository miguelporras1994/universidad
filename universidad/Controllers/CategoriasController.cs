using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using universidad.Data;
using universidad.Models;

namespace universidad.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ApplicationDbContext _context;


        public object Covert { get; private set; }

        public CategoriasController(ApplicationDbContext context)
        {
            _context = context;

        }

        // GET: Categorias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categoria.ToListAsync());
        }


        public ActionResult ObtenerCategoria(int id)
        {



            Categoria encontrar = _context.Categoria.Where(a => a.CategoriaID == id).FirstOrDefault();

            return View(encontrar);
        }


        [HttpPost]

        public List<IdentityError> Crear(int id, string nombre, string descripcion, string estado)
        {

            var error = new List<IdentityError>();

            Categoria cat = new Categoria
            {
                CategoriaID = id,
                Nombre = nombre,
                Descripcion = descripcion,
                Estado = Convert.ToBoolean(estado)
            };
            _context.Add(cat);
            _context.SaveChanges();


            error.Add(new IdentityError
            {
                Code = "Save",
                Description = "Save"
            });



            return error;

        }





        public List<object[]> filtrarDatos(int numPagina, string valor, string order)
        {
            int contador = 0, cant, numregistro = 0, inicio = 0, resgistropagina = 4;
            int can_paginas, pagina;
            string Filtrador = "", paginador = "", Estado = null;
            List<object[]> data = new List<object[]>();

            IEnumerable<Categoria> Consulta;
            List<Categoria> Categorias = null;
            switch (order)
            {
                case "id":
                    Categorias = _context.Categoria.OrderBy(c => c.CategoriaID).ToList();
                    break;
                case "nombre":
                    Categorias = _context.Categoria.OrderBy(c => c.Nombre).ToList();
                    break;
                case "des":
                    Categorias = _context.Categoria.OrderBy(c => c.Descripcion).ToList();
                    break;
                case "estado":

                    Categorias = _context.Categoria.OrderBy(c => c.Estado).ToList();


                    break;


            }


            numregistro = Categorias.Count;
            if ((numregistro % resgistropagina) > 0)
            {
                numregistro += 3;
            }

            inicio = (numPagina - 1) * resgistropagina;
            can_paginas = (numregistro / resgistropagina);
            if (valor == "null")
            {
                Consulta = Categorias.Skip(inicio).Take(resgistropagina);

            }
            else
            {

                Consulta = Categorias.Where(c => c.Nombre.StartsWith(valor) || c.Descripcion.StartsWith(valor)).Skip(inicio).Take(resgistropagina);
            }


            cant = Consulta.Count();
            foreach (var nuevo in Consulta)
            {
                if (nuevo.Estado == true)
                {
                    Estado = "<a data-toggle='modal' data-target='#ModaEstado' onclick='BuscarEstado(" + nuevo.CategoriaID + ")' class='btn btn-success'>Activo</a>";
                }

                else
                {
                    Estado = "<a data-toggle='modal' data-target='#ModaEstado' onclick='BuscarEstado(" + nuevo.CategoriaID + ")' class='btn btn-danger'>Inactivo</a>";
                }

                Filtrador += "<tr>" +
                    "<td>" + nuevo.CategoriaID + "</td>" +
                    "<td>" + nuevo.Nombre + "</td>" +
                      "<td>" + nuevo.Descripcion + "</td>" +
                        "<td>" + Estado + "</td>" + "<td>" +


                          "   <a class='btn btn-success' data-toggle='modal' data-target='#EditarCaterogia' onclick='BuscarCategoria(" + nuevo.CategoriaID + ")'>Editar</a>";

            }
            if (valor == "null")
            {
                if (numPagina > 1)
                {
                    pagina = numPagina - 1;
                    paginador += "<a class='btn btn-default' onclick='filtrarDatos(" + 1 + ',' + '"' + order + '"' + ")'> << </a>" +
                    "<a class='btn btn-default' onclick='filtrarDatos(" + pagina + ',' + '"' + order + '"' + ")'> < </a>";
                }
                if (1 < can_paginas)
                {
                    paginador += "<strong class='btn btn-success'>" + numPagina + ".de." + can_paginas + "</strong>";
                }
                if (numPagina < can_paginas)
                {
                    pagina = numPagina + 1;
                    paginador += "<a class='btn btn-default' onclick='filtrarDatos(" + pagina + ',' + '"' + order + '"' + ")'>  > </a>" +
                                 "<a class='btn btn-default' onclick='filtrarDatos(" + can_paginas + ',' + '"' + order + '"' + ")'> >> </a>";
                }




            }

            object[] objecto = { Filtrador, paginador };
            data.Add(objecto);
            return data;

        }
    


            
    



            public List<Categoria> BuscarEstado(int id)
            {
                return _context.Categoria.Where(c => c.CategoriaID == id).ToList();


            }


            public List<IdentityError> EditarEstado(int id, string nombre, string descripcion, Boolean estado, string funcion)
            {


                var errorlist = new List<IdentityError>();
                string code = "", des = "";
                switch (funcion)
                {
                    case "estado":

                        if (estado == false)
                        {
                            estado = true;
                        }
                        else {
                            estado = false;
                        }

                        var categora = new Categoria() {
                            CategoriaID = id,
                            Nombre = nombre,
                            Descripcion = descripcion,
                            Estado = estado

                        };

                        try
                        {
                            _context.Update(categora);
                            _context.SaveChanges();
                            code = "Save";
                            des = "Save";
                        }
                        catch (Exception ex)
                        {
                            code = "Error";
                            des = ex.Message;
                        }


                        break;

                }

                errorlist.Add(new IdentityError
                {
                    Code = code,
                    Description = des
                });
                return errorlist;

            }
        

        public string EditarCategoria( int id, string nombre, string descripcion, Boolean estado)
        {
            string Code = " ";
            var validar = _context.Categoria.Where(a => a.CategoriaID == id).FirstOrDefault();

            if (validar == null)
            {
                Code = "  NO Save";
            }else { 
            validar.Nombre = nombre;
            validar.Descripcion = descripcion;
            validar.Estado = estado;
            _context.SaveChanges();

                Code = "Save";
            }
            return Code;
        }

      

            

    }

}


