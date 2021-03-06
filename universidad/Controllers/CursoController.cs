﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
            int contador = 0, cant, numregistro = 0, inicio = 0, resgistropagina = 6;
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
                case "cat":

                    Curso = Db.Curso.OrderBy(c => c.CategoriaID).ToList();


                    break;
            }


            numregistro = Curso.Count;
            if ((numregistro % resgistropagina) > 0)
            {
                numregistro += 5;
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
                var categorias = Db.Categoria.Where(a => a.CaterogiaID == nuevo.CategoriaID).FirstOrDefault();
               

                if (nuevo.Estado == true)
                {
                    Estado = "<a data-toggle='modal' data-target='#ModalEstadoCurso' onclick='BuscarEstadoCurso(" + nuevo.CursoID + ")' class='btn btn-success'>Activo</a>";
                }

                else
                {
                    Estado = "<a data-toggle='modal' data-target='#ModalEstadoCurso' onclick='BuscarEstadoCurso(" + nuevo.CursoID + ")' class='btn btn-danger'>Inactivo</a>";
                }

                Filtrador += "<tr>" +
                    "<td>" + nuevo.CursoID + "</td>" +
                    "<td>" + nuevo.Nombre + "</td>" +
                      "<td>" + nuevo.Descripcion + "</td>" +
                       "<td>" + nuevo.Creditos + "</td>" +
                        "<td>" + nuevo.Horas + "</td>" +
                        "<td>" + nuevo.Costo + "</td>" +
                          "<td>" + categorias.Nombre + "</td>" +
                         "<td>" + Estado + "</td>" + "<td>" +


                          "   <a class='btn btn-success' data-toggle='modal' data-target='#EditarCurso' onclick='BuscarCurso(" + nuevo.CursoID + ")'>Editar</a>";

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

        public  string EditarCurso(int id, string nombre, string descripcion, int creditos, int horas, decimal costos, Boolean estado, int categoria)
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


        public string EditarEstadocurso (int id)
        {

            string code = "";
            var consultar = Db.Curso.Where(c => c.CursoID == id).FirstOrDefault();

            if(consultar.Estado == true)
            {
                consultar.Estado = false;
            }else
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




