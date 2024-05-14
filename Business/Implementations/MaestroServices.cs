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


        public String Actualizar(String Id, Maestro registro)
        {
            var maestro = _dbcontext.Maestros.Find(Id);
            maestro.Id = registro.Id;
            maestro.Nombre = registro.Nombre;
            maestro.Apellido = registro.Apellido;
            
            _dbcontext.SaveChanges();

            return maestro.Id;
        }

        //asnotraquin
        public string Agregar(Maestro Registro)
        {
            var item = new Maestro
            {
                Id= Registro.Id,
                Nombre = Registro.Nombre,
                Apellido = Registro.Apellido,
            };
            _dbcontext.Maestros.Add(item);
            _dbcontext.SaveChanges();

            return item.Id;

        }

        public string Eliminar(string Id)
        {
            var Maestro = _dbcontext.Maestros.Find(Id);
            _dbcontext.Maestros.Remove(Maestro);
            _dbcontext.SaveChanges();
            return Id;

        }

    }
}
