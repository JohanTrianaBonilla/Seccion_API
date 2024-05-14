using System;
using System.Collections.Generic;

namespace SeccionApi.Models
{
    public partial class Seccione
    {
        public Seccione()
        {
            Matriculas = new HashSet<Matricula>();
        }

        public string Id { get; set; } = null!;
        public int IdClase { get; set; }
        public string IdMaestro { get; set; } = null!;
        public TimeSpan Hora { get; set; }
        public string Aula { get; set; } = null!;
        public int Cupos { get; set; }

        public virtual Clase IdClaseNavigation { get; set; } = null!;
        public virtual Maestro IdMaestroNavigation { get; set; } = null!;
        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
