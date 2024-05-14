using System;
using System.Collections.Generic;

namespace SeccionApi.Models
{
    public partial class Maestro
    {
        public Maestro()
        {
            Secciones = new HashSet<Seccione>();
        }

        public string Id { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;

        public virtual ICollection<Seccione> Secciones { get; set; }
    }
}
