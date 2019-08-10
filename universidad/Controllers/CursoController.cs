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


            List<Curso> Mostrar = Db.Curso.ToList();
            return View(Mostrar);
        }
      
        public List<Categoria> ValidarCategoria(){

            var consulta =Db.Categoria.Where(c => c.Estado == true).ToList();

            return consulta;


        }

        public string AgregarCurso( string nombre, string descripcion,int creditos , int horas, decimal costo,  Boolean estado,  int categoria)
        {

            Curso crear = new Curso();

            crear.Nombre = nombre;
            crear.Descripcion = descripcion;
            crear.Horas = horas;
            crear.Costo = costo;
            crear.Estado = estado;
            crear.CategoriaID = categoria;
            crear.Creditos = creditos;

            string Code =" ";
            try
            {

                Db.Add(crear);
                Db.SaveChanges();
              Code = "Save";

            } catch( Exception ){

                Code = "No save";
            }

            return Code;

            



        }



    }
}