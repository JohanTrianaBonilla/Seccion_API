using Business.Interfaces;
using Core.ModelView;
using Infrastructure.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementations
{
    public class MaestroServices : IMaestroServices
    {
        private readonly UniversidadContext _dbcontext;
        public MaestroServices() { }
        public MaestroServices(UniversidadContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public List<MaestroWiew> ConsultarServicios()
        {
            List<MaestroWiew> listaMaestroWievs = new List<MaestroWiew>();
            var listServicios = _dbcontext.Maestros.ToList();
            if (listServicios != null)
            {
                foreach (var item in listServicios)
                {
                    MaestroWiew MaestroWiew = new MaestroWiew()
                    {
                        Id= item.Id,
                        Nombre = item.Nombre,
                        Apellido = item.Apellido,

                    };
                    listaMaestroWievs.Add(MaestroWiew);
                }
            }
            return listaMaestroWievs;
        }
        public MaestroWiew Buscar(String Id)
        {
            var maestro = _dbcontext.Maestros.Find(Id);
            if (maestro == null)
            {
                return null;
            }
            var maestroWiew = new MaestroWiew()
            {
                Id= maestro.Id,
                Nombre=maestro.Nombre,
                Apellido=maestro.Apellido,  
            };

            return maestroWiew;
        }
        //se modifico aca 
        public String Actualizar(String Id, MaestroWiew registro)
        {
            var maestro = _dbcontext.Maestros.Find(Id);
            if(maestro != null)
            {
                throw new Exception("El Maestro no existe en la base de datos");
            }
            else
            {
                maestro.Nombre = registro.Nombre;
                maestro.Apellido = registro.Apellido;
                _dbcontext.SaveChanges();
                return maestro.Id;
            }
        }

        //se modifico aca tambien la funcion agregar
        public string Agregar(MaestroWiew Registro)
        {
            var maestro = _dbcontext.Maestros.Find(Registro.Id);
            if (maestro != null)
            {
                throw new Exception("El maestro ya existe en la base de datos");
            }
            else
            {
                var item = new Maestro
                {
                    Id = Registro.Id,
                    Nombre = Registro.Nombre,
                    Apellido = Registro.Apellido,
                };
                _dbcontext.Maestros.Add(item);
                _dbcontext.SaveChanges();
                return item.Id;
            }
        }

        public string Eliminar(string Id)
        {
            var Maestro = _dbcontext.Maestros.Find(Id);
            if (Maestro == null)
            {
                throw new Exception("El Maestro no existe en la base de datos");
            }
            _dbcontext.Maestros.Remove(Maestro);
            _dbcontext.SaveChanges();
            return Id;

        }

    }
}
