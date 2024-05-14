using Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace Infrastructure.Models
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
