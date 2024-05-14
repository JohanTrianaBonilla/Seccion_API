using Core.ModelView;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IMatriculaServices
    {
        List<MatriculaView> ConsultarMatriculas();

        public MatriculaView Buscar(int id);

        public int Eliminar(int id);

        public int Agregar(Matricula Registro);

        public int Actualizar(int Id, Matricula registro);
    }
}
