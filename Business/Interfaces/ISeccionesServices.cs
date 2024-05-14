using Core.ModelView;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ISeccionesServices
    {
        List<SeccionesView> ConsultarSecciones();

        public SeccionesView Buscar(String id);

        public String Eliminar(String id);

        public string Agregar(Seccione Registro);

        public String Actualizar(String Id, Seccione registro);
    }
}
