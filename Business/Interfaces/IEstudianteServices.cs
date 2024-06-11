using Core.ModelView;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IEstudianteServices
    {
        List<EstudianteView> ConsultarEstudiantes();

        public EstudianteView Buscar(string Id);

        public String Eliminar(string id);

        public string Agregar(string Id, int IdCarrea, string Nombre, string Apellido, DateTime FechaNacimiento);

        public String Actualizar(string Id, EstudianteView estudiante); 
    }
}
