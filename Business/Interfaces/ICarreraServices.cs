using Core.ModelView;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ICarreraServices
    {
        List<CarreraView> ConsultarServicios();
        public CarreraView Buscar(int id);

        public int Eliminar(int id);

        public int Agregar(Carrera Registro);

        public int Actualizar(int Id, Carrera registro);
    }
}
