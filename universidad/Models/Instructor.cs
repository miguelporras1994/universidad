using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace universidad.Models
{
    public class Instructor : Tercero
    {
        

        [StringLength(20)]
        public string Especialidad { get; set; }

    }
}
