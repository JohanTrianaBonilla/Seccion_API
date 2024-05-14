using Business.Interfaces;
using Core.ModelView;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementations
{
    public class SeccionesServices : ISeccionesServices
    {
        private readonly UniversidadContext _dbcontext;
        public SeccionesServices() { }
        public SeccionesServices(UniversidadContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public List<SeccionesView> ConsultarSecciones()
        {
            List<SeccionesView> listaSeccionesView = new List<SeccionesView>();
            var listServicios = _dbcontext.Secciones.ToList();
            if (listServicios != null)
            {
                foreach (var item in listServicios)
                {

                    SeccionesView SeccionesView = new SeccionesView()
                    {
                       Id= item.Id,
                       IdClase= item.IdClase,
                       IdMaestro= item.IdMaestro,
                       Hora= item.Hora, 
                       Aula=item.Aula,
                       Cupos=item.Cupos,
                    };
                    listaSeccionesView.Add(SeccionesView);
                }
            }
            return listaSeccionesView;
        }
        public SeccionesView Buscar(String Id)
        {
            var secciones = _dbcontext.Secciones.Find(Id);
            if (secciones == null)
            {
                return null;
            }
            var seccionesView = new SeccionesView()
            {
                Id = secciones.Id,
                IdClase = secciones.IdClase,
                IdMaestro = secciones.IdMaestro,    
                Hora = secciones.Hora,
                Aula = secciones.Aula,
                Cupos = secciones.Cupos,
            };
            return seccionesView;
        }
        public String Actualizar(String Id, Seccione registro)
        {
            var secion = _dbcontext.Secciones.Find(Id);
            secion.Id = registro.Id;
            secion.IdClase = registro.IdClase;
            secion.IdMaestro = registro.IdMaestro;
            secion.Hora = registro.Hora;
            secion.Aula = registro.Aula;
            secion.Cupos = registro.Cupos;
            _dbcontext.SaveChanges();
            return secion.Id;
        }

        public string Agregar(Seccione Registro)
        {
            
            var item = new Seccione
            {
                Id = Registro.Id,
                IdClase = Registro.IdClase,
                IdMaestro = Registro.IdMaestro,
                Hora  = Registro.Hora,  
                Aula = Registro.Aula,   
                Cupos = Registro.Cupos,
                //IdClaseNavigation = Registro.IdClaseNavigation,
                //IdMaestroNavigation = Registro.IdMaestroNavigation,
            };
            _dbcontext.Secciones.Add(item);
            _dbcontext.SaveChanges();
    
            return item.Id;
        }

        public string Eliminar(string Id)
        {
            var seccion = _dbcontext.Secciones.Find(Id);
            _dbcontext.Secciones.Remove(seccion);
            _dbcontext.SaveChanges();
            return Id;

        }

    }
}
