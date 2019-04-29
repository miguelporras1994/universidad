using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace universidad.Models
{
    public class Tercero
    {

        [DisplayName("Cedula")]
        public int TerceroID { get; set; }
    public string  Apellido { get; set; }
    public string Nombres { get; set; }

        public DateTime FechaNacimiento { get; set; }
    public string Email  { get; set; }
    public string Telefono{ get; set; }
    public string Direccion { get; set; }
    public Boolean Estado { get; set; } 
 
    }
}
