using System;
using System.Collections.Generic;

namespace SeccionApi.Models
{
    public partial class Matricula
    {
        public int Id { get; set; }
        public string IdEstudiante { get; set; } = null!;
        public string IdSeccion { get; set; } = null!;

        public virtual Estudiante IdEstudianteNavigation { get; set; } = null!;
        public virtual Seccione IdSeccionNavigation { get; set; } = null!;
    }
}
