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


            var  Mostrar = Db.Curso;
            return View(Mostrar.ToList());
        }

        // GET: Curso/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Curso/Create
        public ActionResult Create()

        {





            return View();
        }

        // POST: Curso/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Curso A)
        {

            if (ModelState.IsValid)
            {
                Db.Curso.Add(A);
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();

            }
        }

        // GET: Curso/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Curso/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Curso/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Curso/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}