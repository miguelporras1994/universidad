﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace universidad.Models
{
    public class UsuarioRole
    {

        public List<SelectListItem> usuarioRoles;
        public UsuarioRole()
        {
            usuarioRoles = new List<SelectListItem>();
        }


        public async Task<List<SelectListItem>>GetRole(UserManager<ApplicationUser> userManager,RoleManager<IdentityRole>roleManager,string Id) {



            usuarioRoles = new List<SelectListItem>();
            string rol;
            var usuario = await userManager.FindByIdAsync(Id);
            var roles = await userManager.GetRolesAsync(usuario);
            // vamos comprobar si esta funcionando
            if(roles.Count == 0)
            {
                usuarioRoles.Add(new SelectListItem()
                {
                    Value = "null",
                    Text ="no Role"
                });


            } else

           {
                rol = Convert.ToString(roles[0]);
                var rolesId = roleManager.Roles.Where(m => m.Name == rol);

                foreach (var Data in rolesId){


                    usuarioRoles.Add(new SelectListItem()
                    {   Value =Data.Id,
                        Text = Data.Name,
                });
                }

           
            }
            return usuarioRoles;


        }
    }
}
