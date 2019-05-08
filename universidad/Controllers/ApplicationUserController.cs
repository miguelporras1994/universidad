using System;
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

        public ApplicationUserController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager
          )
        {
            Db = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _usuarioRole = new UsuarioRole();
            UsuarioRole = new List<SelectListItem>();





        }
        public async Task<ActionResult> Index()
        {
            var Id = "";

            List<Usuarios> usuario = new List<Usuarios>();

            var agrupar = await Db.ApplicationUser.ToListAsync();

            foreach (var data in agrupar)
            {
                Id = data.Id;
                UsuarioRole = await _usuarioRole.GetRole(_userManager, _roleManager, Id);

                usuario.Add(new Usuarios()
                {
                    Id = data.Id,
                    UserName = data.UserName,
                    PhoneNumber = data.PhoneNumber,
                    Email = data.Email,
                    Role = UsuarioRole[0].Text,

                });




            }
            return View(usuario.ToList());
        }


        public async Task<List<Usuarios>> EnvioUsuario(string id)
        {
            /* List<ApplicationUser> lista = new List<ApplicationUser>();
             var Obtener = await Db.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id);
             lista.Add(Obtener);

             return lista;*/

            List<Usuarios> lista = new List<Usuarios>();
            var Obtener = await Db.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id);
            UsuarioRole = await _usuarioRole.GetRole(_userManager, _roleManager, id);

            lista.Add(new Usuarios()
            {
                Id = Obtener.Id,
                Email = Obtener.Email,
                UserName = Obtener.UserName,
                PhoneNumber = Obtener.PhoneNumber,
                Role = UsuarioRole[0].Text,
                Roleid = UsuarioRole[0].Value



            });
        

                return lista;



        }

        public List<SelectListItem>GetRoles()
        {
            //Creamos un objeto llamado rolesLista  
            List<SelectListItem> rolesLista = new List<SelectListItem>();
            rolesLista =  _usuarioRole.Roles(_roleManager);
            return rolesLista;
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
        public  string Editar(Usuarios c)
        {
            var Resp = "";

            try
            {


                List<Usuarios> usuarios = new List<Usuarios>();



                   var Obtener = Db.ApplicationUser.Find(c.Id);

                usuarios.Add(new Usuarios(){
                    Id = Obtener.Id,
                    Email = Obtener.Email,
                    UserName = Obtener.UserName,
                    PhoneNumber = Obtener.PhoneNumber,
                    Role = UsuarioRole[0].Text,
                    Roleid = UsuarioRole[0].Value

              



            });
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
    