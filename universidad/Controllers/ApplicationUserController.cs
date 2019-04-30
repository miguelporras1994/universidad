﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using universidad.Data;
using universidad.Models;

namespace universidad.Controllers
{
    public class ApplicationUserController : Controller
    {
        // GET: Tercero
        private readonly ApplicationDbContext Db;

        public ApplicationUserController(ApplicationDbContext context)
        {
            Db = context;
        }
        public ActionResult Index()
        {




            return View(Db.ApplicationUser.ToList());
        }









        public ActionResult Editar(string id)
        {

            try
            {



                {


                    ApplicationUser val = Db.ApplicationUser.Where(a => a.Id == id).FirstOrDefault();


                    //Tercero val = db.Tercero.Find(id);
                    return View(val);

                }
            }
            catch (Exception ex)
            {
                // ModelState.AddModelError("NO SE PUDO EDITAR VOY LLOARAR", ex);
                return View();

            }


        }

        [HttpPost]
        public ActionResult Editar(ApplicationUser c)
        {

            try
            {


                {




                    ApplicationUser va = Db.ApplicationUser.Find(c.Id);

                   
                    va.UserName = c.UserName;
                    va.PhoneNumber = c.PhoneNumber;
                     va.PasswordHash = c.PasswordHash;
                    //va.Telefono = c.Telefono;

                    Db.SaveChanges();
                    return RedirectToAction("Index");


                }
            }
            catch (Exception ex)
            {
                /// ModelState.AddModelError("hay un error con los con el regsitro", ex);

                return View();
            }


        }





        public ActionResult Detalles(string id)
        {

            try
            {




                ApplicationUser val = Db.ApplicationUser.Where(a => a.Id == id).FirstOrDefault();


                //Tercero val = db.Tercero.Find(id);
                return View(val);



            }
            catch (Exception ex)
            {
                // ModelState.AddModelError("NO SE PUDO EDITAR VOY LLOARAR", ex);
                return View();

            }



        }

        public ActionResult Eliminar(string id)


        {

            if (ModelState.IsValid)
            {
                ApplicationUser eli = Db.ApplicationUser.Where(a => a.Id == id).FirstOrDefault();
                Db.ApplicationUser.Remove(eli);
                Db.SaveChanges();
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Crear()
        {

            return View();

        }
    }
}
    