using Core.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IClaseServices
    {
        List<ClaseView> ConsultarClases();
        public ClaseView Buscar(int Id);
        public int Agregar(ClaseView Registro);
        public int Actualizar(int Codigo, ClaseView registro);
        public int Eliminar(int Codigo);



    }
}
