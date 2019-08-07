using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace universidad.Models
{
    public class Categoria
    {


        [Key]
        public int CaterogiaID { get; set; }

        [StringLength(255)]
        public string Nombre { get; set; }

        [StringLength(255)]
        public string Descripcion { get; set; }

        public bool? Estado { get; set; }

       
        public virtual ICollection<Curso> Curso { get; set; }
    }
}
    