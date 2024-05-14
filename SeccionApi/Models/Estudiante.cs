using System;
using System.Collections.Generic;

namespace SeccionApi.Models
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            Matriculas = new HashSet<Matricula>();
        }
        public string Id { get; set; } = null!;
        public int IdCarrera { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }

        public virtual Carrera IdCarreraNavigation { get; set; } = null!;
        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
