using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace universidad.Models
{
    public class Usuarios
    {

        //
        // Resumen:
        

        //
        // Resumen:
        //     Gets or sets the date and time, in UTC, when any user lockout ends.
        //
        // Comentarios:
        //     A value in the past means the user is not locked out.
        public virtual DateTimeOffset? LockoutEnd { get; set; }
        //
        // Resumen:
        //     Gets or sets a flag indicating if two factor authentication is enabled for this
        //     user.
        public virtual bool TwoFactorEnabled { get; set; }
        //
        // Resumen:
        //     Gets or sets a flag indicating if a user has confirmed their telephone address.
        public virtual bool PhoneNumberConfirmed { get; set; }
        //
        // Resumen:
        //     Gets or sets a telephone number for the user.
        public virtual string PhoneNumber { get; set; }
        //
        // Resumen:
        //     A random value that must change whenever a user is persisted to the store
        public virtual string ConcurrencyStamp { get; set; }
        //
        // Resumen:
        //     A random value that must change whenever a users credentials change (password
        //     changed, login removed)
        public virtual string SecurityStamp { get; set; }
        //
        // Resumen:
        //     Gets or sets a salted and hashed representation of the password for this user.
        public virtual string PasswordHash { get; set; }
        //
        // Resumen:
        //     Gets or sets a flag indicating if a user has confirmed their email address.
        public virtual bool EmailConfirmed { get; set; }
        //
        // Resumen:
        //     Gets or sets the normalized email address for this user.
        public virtual string NormalizedEmail { get; set; }
        //
        // Resumen:
        //     Gets or sets the email address for this user.
        public virtual string Email { get; set; }
        //
        // Resumen:
        //     Gets or sets the normalized user name for this user.
        public virtual string NormalizedUserName { get; set; }
        //
        // Resumen:
        //     Gets or sets the user name for this user.
        public virtual string UserName { get; set; }
        //
        // Resumen:
        //     Gets or sets the primary key for this user.
        public virtual  string  Id { get; set; }
        //
        // Resumen:
        //     Gets or sets a flag indicating if the user could be locked out.
        public virtual bool LockoutEnabled { get; set; }
        //
        // Resumen:
        //     Gets or sets the number of failed login attempts for the current user.
        public virtual int AccessFailedCount { get; set; }

        //
        // Resumen:
        //     Returns the username for this user.
       public string Role { get; set; }
        public string Roleid { get; set; }
    }
}
