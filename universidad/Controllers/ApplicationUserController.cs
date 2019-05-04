﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using universidad.Data;
using universidad.Models;

namespace universidad.Controllers
{
    public class ApplicationUserController : Controller
    {
        // GET: Tercero
        private readonly ApplicationDbContext Db;
        UserManager<ApplicationUser> _userManager;
        UsuarioRole _usuarioRole;
        RoleManager<IdentityRole> _roleManager;

        public List<SelectListItem> UsuarioRole;

        public ApplicationUserController(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,  List<SelectListItem> Role)
        {
            Db = context;
            _userManager = userManager;
            _roleManager = roleManager;


        }
        public ActionResult Index()
        {




            return View(Db.ApplicationUser.ToList());
        }


        public async Task<List<ApplicationUser>>Usuario(string id)
        {
            List<ApplicationUser> lista = new List<ApplicationUser>();
            var Obtener = await Db.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id);
            lista.Add(Obtener);

            return lista;
        }






        /*public ActionResult Editar(string id)
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


        }*/

        [HttpPost]
        public  string Editar(ApplicationUser c)
        {
            var Resp = "";

            try
            {






                    ApplicationUser va = Db.ApplicationUser.Find(c.Id);

                   
                    va.UserName = c.UserName;
                    va.PhoneNumber = c.PhoneNumber;
                     
                    

                    Db.SaveChanges();
                    Resp = "Save";

                    return Resp;

             
            }
            catch 
            {
                /// ModelState.AddModelError("hay un error con los con el regsitro", ex);
                 Resp = "no_save";
                return Resp;
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
            catch 
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
    