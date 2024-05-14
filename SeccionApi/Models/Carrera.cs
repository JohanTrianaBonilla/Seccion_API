using System;
using System.Collections.Generic;

namespace SeccionApi.Models
{
    public partial class Carrera
    {
        public Carrera()
        {
            Estudiantes = new HashSet<Estudiante>();
        }

        public int Codigo { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Estudiante> Estudiantes { get; set; }
    }
}
