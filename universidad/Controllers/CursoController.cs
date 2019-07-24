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


            var Mostrar = Db.Curso;
            return View(Mostrar.ToList());
        }
      
        public List<Categoria> ValidarCategoria(){

            return Db.Categoria.Where(c => c.Estado == true).ToList();


        }



    }
}