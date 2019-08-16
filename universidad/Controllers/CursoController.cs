using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using universidad.Data;
using universidad.Models;

namespace universidad.Controllers
{
    public class CursoController : Controller
    {
        public readonly ApplicationDbContext Db;

        public CursoController(ApplicationDbContext validar)
        {
            Db = validar;

        }
        // GET: Curso
        public ActionResult Index()
        {


            //List<Curso> Mostrar = Db.Curso.ToList();
            return View(/*Mostrar*/);
        }

        public List<Categoria> ValidarCategoria()
        {

            var consulta = Db.Categoria.Where(c => c.Estado == true).ToList();

            return consulta;


        }

        public string AgregarCurso(string nombre, string descripcion, int creditos, int horas, decimal costos, Boolean estado, int categoria)
        {

            Curso crear = new Curso();

            crear.Nombre = nombre;
            crear.Descripcion = descripcion;
            crear.Horas = horas;
            crear.Costo = costos;
            crear.Estado = estado;
            crear.CategoriaID = categoria;
            crear.Creditos = creditos;

            string Code = " ";
            try
            {

                Db.Add(crear);
                Db.SaveChanges();
                Code = "Save";

            }
            catch (Exception)
            {

                Code = "No save";
            }

            return Code;





        }

        public List<object[]> FiltrarCurso(int numPagina, string valor, string order)
        {
            int contador = 0, cant, numregistro = 0, inicio = 0, resgistropagina = 4;
            int can_paginas, pagina;
            string Filtrador = "", paginador = "", Estado = null;
            List<object[]> data = new List<object[]>();


            IEnumerable<Curso> Consulta;

            List<Curso> Curso = null;
            switch (order)
            {
                case "id":
                    Curso = Db.Curso.OrderBy(c => c.CursoID).ToList();
                    break;
                case "nombre":
                    Curso = Db.Curso.OrderBy(c => c.Nombre).ToList();
                    break;
                case "des":
                    Curso = Db.Curso.OrderBy(c => c.Descripcion).ToList();
                    break;
                case "estado":

                    Curso = Db.Curso.OrderBy(c => c.Estado).ToList();


                    break;
            }


            numregistro = Curso.Count;
            if ((numregistro % resgistropagina) > 0)
            {
                numregistro += 3;
            }

            inicio = (numPagina - 1) * resgistropagina;
            can_paginas = (numregistro / resgistropagina);
            if (valor == "null")
            {
                
                Consulta = Curso.Skip(inicio).Take(resgistropagina);

            }
            else
            {

                Consulta = Curso.Where(c => c.Nombre.StartsWith(valor) || c.Descripcion.StartsWith(valor)).Skip(inicio).Take(resgistropagina);
            }


            cant = Consulta.Count();
            foreach (var nuevo in Consulta)
            {
                if (nuevo.Estado == true)
                {
                    Estado = "<a data-toggle='modal' data-target='#ModaEstado' onclick='BuscarEstado(" + nuevo.CursoID + ")' class='btn btn-success'>Activo</a>";
                }

                else
                {
                    Estado = "<a data-toggle='modal' data-target='#ModaEstado' onclick='BuscarEstado(" + nuevo.CursoID + ")' class='btn btn-danger'>Inactivo</a>";
                }

                Filtrador += "<tr>" +
                    "<td>" + nuevo.CursoID + "</td>" +
                    "<td>" + nuevo.Nombre + "</td>" +
                      "<td>" + nuevo.Descripcion + "</td>" +
                       "<td>" + nuevo.Creditos + "</td>" +
                        "<td>" + nuevo.Horas + "</td>" +
                        "<td>" + nuevo.Costo+ "</td>" +
                          "<td>" + nuevo.CategoriaID + "</td>" +
                         "<td>" + Estado + "</td>" + "<td>" +


                          "   <a class='btn btn-success' data-toggle='modal' data-target='#EditarCaterogia' onclick='BuscarCategoria(" + nuevo.CursoID + ")'>Editar</a>";

            }
            object[] objecto = { Filtrador, paginador };
            data.Add(objecto);
            return data;
        }
    }
}

