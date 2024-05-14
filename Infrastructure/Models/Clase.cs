using System;
using System.Collections.Generic;

namespace Infrastructure.Models
{
    public partial class Clase
    {
        public Clase()
        {
            Secciones = new HashSet<Seccione>();
        }

        public int Codigo { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Seccione> Secciones { get; set; }
    }
}
