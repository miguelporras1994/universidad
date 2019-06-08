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
        private object errorList;

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





        public List<object[]> filtrarDatos(int numPagina, string valor)
        {
            int contador = 0, cant, numregistro = 0, inicio = 0, resgistropagina = 4;
            int can_paginas, pagina;
            string Filtrador = "", paginador = "", Estado = null;
            List<object[]> data = new List<object[]>();

            IEnumerable<Categoria> Consulta;

            var Categorias = _context.Categoria.OrderBy(c => c.Nombre).ToList();

            numregistro = Categorias.Count;

            inicio = (numPagina - 1) * resgistropagina;
            can_paginas = (numPagina / resgistropagina);
            if (valor == "null")
            {
                Consulta = Categorias.Skip(inicio).Take(resgistropagina);

            }else
            {

                Consulta = Categorias.Where(c => c.Nombre.StartsWith(valor) || c.Descripcion.StartsWith(valor)).Skip(inicio).Take(resgistropagina);
            }


            cant = Consulta.Count();
            foreach (var nuevo in Consulta)
            {
                if (nuevo.Estado == true)
                {
                    Estado = "Activo";
                }

                else
                {
                    Estado = "Inactivo";
                }

                Filtrador += "<tr>" +
                    "<td>" + nuevo.CategoriaID+ "</td>" +
                    "<td>" + nuevo.Nombre + "</td>" +
                      "<td>" + nuevo.Descripcion + "</td>" +
                        "<td>" + Estado + "</td>" + "<td>"+


                          " <a class='btn  btn-success' data-toggle='modal' data-target='#EditarCaterogia' onclick='EnvioCategoria("+nuevo.CategoriaID +")'>Editar</a>" +

                       " <a class='btn  btn-danger' data-toggle='modal' data-target='#EliminarCategoria' >Eliminar</a>" +
                       "</td>" + "</tr>";
            }

            object[] objecto = { Filtrador, paginador };
            data.Add(objecto);
            return data;

        }
            





        }
    }


