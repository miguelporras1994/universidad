using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using universidad.Data;
using universidad.Models;

namespace universidad.Controllers
{
    public class EstudianteController : Controller
    {
        private readonly ApplicationDbContext Db;

        public EstudianteController(ApplicationDbContext context)
        {
               Db = context;
        }

        // GET: Estudiante
        public ActionResult Index()
        {
            return View();

        }


        public List<Categoria> ValidarCategoria()
        {

            var consulta = Db.Categoria.Where(c => c.Estado == true).ToList();

            return consulta;


        }

        public string AgregarEstudiamte(string nombre, string descripcion, int creditos, int horas, decimal costos, Boolean estado, int categoria)
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

        public List<object[]> FiltrarEstudiante(int numPagina, string valor, string order)
        {
            int contador = 0, cant, numregistro = 0, inicio = 0, resgistropagina = 6;
            int can_paginas, pagina;
            string Filtrador = "", paginador = "", Estado = null;
            List<object[]> data = new List<object[]>();

            IEnumerable<Estudiante> Consulta;


            List<Estudiante> Estudiante = null;
            switch (order)
            {
                case "id":
                    Estudiante = Db.Estudiante.OrderBy(c => c.TerceroID).ToList();
                    break;
                case "nombre":
                    Estudiante = Db.Estudiante.OrderBy(c => c.Nombres).ToList();
                    break;
                case "apellido":
                    Estudiante = Db.Estudiante.OrderBy(c => c.Apellido).ToList();
                    break;
                case "estado":

                    Estudiante = Db.Estudiante.OrderBy(c => c.Estado).ToList();


                    break;
                
            }


            numregistro = Estudiante.Count;
            if ((numregistro % resgistropagina) > 0)
            {
                numregistro += 5;
            }

            inicio = (numPagina - 1) * resgistropagina;
            can_paginas = (numregistro / resgistropagina);
            if (valor == "null")
            {

                Consulta = Estudiante.Skip(inicio).Take(resgistropagina);

            }
            else
            {

                Consulta = Estudiante.Where(c => c.Nombres.StartsWith(valor) || c.Apellido.StartsWith(valor)).Skip(inicio).Take(resgistropagina);
            }


            cant = Consulta.Count();
            foreach (var nuevo in Consulta)
            {
                

                if (nuevo.Estado == true)
                {
                    Estado = "<a data-toggle='modal' data-target='#ModalEstadoEstudiante' onclick='BuscarEstadoCurso(" + nuevo.TerceroID + ")' class='btn btn-success'>Activo</a>";
                }

                else
                {
                    Estado = "<a data-toggle='modal' data-target='#CrearEstudiante' onclick='BuscarEstudiante(" + nuevo.TerceroID + ")' class='btn btn-danger'>Inactivo</a>";
                }

                Filtrador += "<tr>" +
                    "<td>" + nuevo.TerceroID + "</td>" +
                    "<td>" + nuevo.Nombres + "</td>" +
                      "<td>" + nuevo.Apellido + "</td>" +
                       "<td>" + nuevo.Codigo + "</td>" +
                        "<td>" + nuevo.Email + "</td>" +
                        "<td>" + nuevo.Telefono + "</td>" +
                        "<td>" + nuevo.Direccion + "</td>" +
                            "<td>" + nuevo.FechaNacimiento + "</td>" +
                              "<td>" + Estado + "</td>" + "<td>" +





                          "   <a class='btn btn-success' data-toggle='modal' data-target='#CrearEstudiante' onclick='BuscarEstudiante(" + nuevo.TerceroID + ")'>Editar</a>";

            }

            if (valor == "null")
            {
                if (numPagina > 1)
                {
                    pagina = numPagina - 1;
                    paginador += "<a class='btn btn-default' onclick='filtrarCurso(" + 1 + ',' + '"' + order + '"' + ")'> << </a>" +
                    "<a class='btn btn-default' onclick='filtrarCurso(" + pagina + ',' + '"' + order + '"' + ")'> < </a>";
                }
                if (1 < can_paginas)
                {
                    paginador += "<strong class='btn btn-success'>" + numPagina + ".de." + can_paginas + "</strong>";
                }
                if (numPagina < can_paginas)
                {
                    pagina = numPagina + 1;
                    paginador += "<a class='btn btn-default' onclick='filtrarCurso(" + pagina + ',' + '"' + order + '"' + ")'>  > </a>" +
                                 "<a class='btn btn-default' onclick='filtrarCurso(" + can_paginas + ',' + '"' + order + '"' + ")'> >> </a>";
                }
            }
            object[] objecto = { Filtrador, paginador };
            data.Add(objecto);
            return data;
        }

        public Curso BuscarCurso(int id)
        {


            var consulta = Db.Curso.Where(c => c.CursoID == id).FirstOrDefault();

            return consulta;

        }

        public string EditarCurso(int id, string nombre, string descripcion, int creditos, int horas, decimal costos, Boolean estado, int categoria)
        {
            var consulta = Db.Curso.Where(a => a.CursoID == id).FirstOrDefault();
            consulta.Nombre = nombre;
            consulta.Descripcion = descripcion;
            consulta.Creditos = creditos;
            consulta.Horas = horas;
            consulta.Costo = costos;
            consulta.Estado = estado;
            consulta.CategoriaID = categoria;

            Db.Update(consulta);
            Db.SaveChanges();

            string Guardado = "save";
            return Guardado;


        }


        public List<Curso> BuscarEstadoCurso(int id)
        {
            var consultar = Db.Curso.Where(c => c.CursoID == id).ToList();

            return consultar;
        }


        public string EditarEstadocurso(int id)
        {

            string code = "";
            var consultar = Db.Curso.Where(c => c.CursoID == id).FirstOrDefault();

            if (consultar.Estado == true)
            {
                consultar.Estado = false;
            }
            else
            {
                consultar.Estado = true;
            }


            try
            {
                Db.Update(consultar);
                Db.SaveChanges();
                code = "Save";


            }
            catch (Exception ex)
            {
                code = "Error";

            }

            return code;
        }


    }
}
