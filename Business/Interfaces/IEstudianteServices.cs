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

        public EstudianteView Buscar(String Id);

        public String Eliminar(String id);

        public string Agregar(Estudiante Registro);

        public String Actualizar(String Id, Estudiante registro);
    }
}
