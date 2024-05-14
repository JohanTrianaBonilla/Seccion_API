using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ModelView
{
    public class SeccionesView
    {
        public string Id { get; set; } = null!;
        public int IdClase { get; set; }
        public string IdMaestro { get; set; } = null!;
        public TimeSpan Hora { get; set; }
        public string Aula { get; set; } = null!;
        public int Cupos { get; set; }
    }
}
