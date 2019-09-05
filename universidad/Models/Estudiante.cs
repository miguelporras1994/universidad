using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace universidad.Models
{
    public class Estudiante : Tercero
    {
       

        [StringLength(20)]
        public string Codigo { get; set; }
    }
}
