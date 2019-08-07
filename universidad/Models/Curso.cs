using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace universidad.Models
{
    public class Curso
    {
        public int CursoID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int  Creditos { get; set; }
        public int Horas { get; set; }
        public decimal? Costo { get; set; }
        public Boolean Estado { get; set; }
        public int CategoriaID  { get; set; }
        public Categoria  Categoria { get; set; }
        




    }
}
