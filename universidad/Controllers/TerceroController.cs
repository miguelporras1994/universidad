using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using universidad.Data;
using universidad.Models;

namespace universidad.Controllers
{
    public class TerceroController : Controller
    {

        private readonly ApplicationDbContext Db;

        public TerceroController(ApplicationDbContext validar)
        {
            Db = validar;
        }

        // GET: Tercero
        public ActionResult Index()
        {
            return View(Db.Tercero.ToList());
        }

        // GET: Tercero/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Tercero/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tercero/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tercero ter)
        {

            if (ModelState.IsValid)

            {
                // TODO: Add insert logic here
                Db.Tercero.Add(ter);
                Db.SaveChanges();
                return RedirectToAction("Index");
            }

            {

                return View();
            }

        }

       
        public ActionResult Edit(int id)
        {

            try {


                Tercero val = Db.Tercero.Where(s => s.TerceroID == id).FirstOrDefault();

                return View(val);

            }
            catch {



                return View();


            }

        }
        [HttpPost]
        
        public ActionResult Edit(Tercero  c)
        {

            try
            {


                Tercero encuen = Db.Tercero.Find(c.TerceroID);

                encuen.Nombres = c.Nombres;
                encuen.Apellido = c.Apellido;
                encuen.FechaNacimiento = c.FechaNacimiento;
               
                encuen.Email = c.Email;
                encuen.Telefono = c.Telefono;
                encuen.Direccion = c.Direccion;
                encuen.Estado = c.Estado;
                Db.SaveChanges();
                
                return RedirectToAction("Index");

            }
            catch
            {



                return View();


            }

        }


        /*

      // GET: Tercero/Delete/5
      public ActionResult Delete(int id)
      {
          return View();
      }

      // POST: Tercero/Delete/5
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
      }*/
    }
}