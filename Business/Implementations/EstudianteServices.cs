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
    public class EstudianteServices : IEstudianteServices
    {
        private readonly UniversidadContext _dbcontext;
        public EstudianteServices() { }
        public EstudianteServices(UniversidadContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public List<EstudianteView> ConsultarEstudiantes()
        {
            List<EstudianteView> listaEstudiantesViews = new List<EstudianteView>();
            var listServicios = _dbcontext.Estudiantes.ToList();
            if (listServicios != null)
            {
                foreach (var item in listServicios)
                {
                    EstudianteView EstudianteView = new EstudianteView()
                    {
                        Id = item.Id,
                        IdCarrera = item.IdCarrera,  
                        Nombre = item.Nombre,
                        Apellido = item.Apellido,
                        FechaNacimiento = item.FechaNacimiento,

                    };
                    listaEstudiantesViews.Add(EstudianteView);
                }
            }
            return listaEstudiantesViews;
        }

        public EstudianteView Buscar(String Id)
        {
            var estudiante = _dbcontext.Estudiantes.Find(Id);
            if (estudiante == null)
            {
                return null;
            }
            var mestudianteView = new EstudianteView()
            {
                Id = estudiante.Id,
                IdCarrera= estudiante.IdCarrera,
                Nombre = estudiante.Nombre,
                Apellido = estudiante.Apellido,
                FechaNacimiento = estudiante.FechaNacimiento,
            };
            return mestudianteView;
        }

        public String Actualizar(String Id, EstudianteView estudiante)
        {
            var estudianteExiste = _dbcontext.Estudiantes.Find(Id);
            if(estudianteExiste == null)
            {
                throw new Exception("El estudiante no existe");
            }
            estudianteExiste.Id = estudiante.Id;
            estudianteExiste.IdCarrera = estudiante.IdCarrera;
            estudianteExiste.Nombre = estudiante.Nombre;
            estudianteExiste.Apellido = estudiante.Apellido;
            estudianteExiste.FechaNacimiento = estudiante.FechaNacimiento;
            _dbcontext.SaveChanges();
            return estudiante.Id;

            //estudiante.Id = registro.Id;
            //estudiante.IdCarrera = registro.IdCarrera;
            //estudiante.Nombre = registro.Nombre;
            //estudiante.Apellido = registro.Apellido;
            //estudiante.FechaNacimiento = registro.FechaNacimiento;
            //_dbcontext.SaveChanges();
            //return estudiante.Id;
        }

        public string Agregar(string Id, int IdCarrea, string Nombre, string Apellido, DateTime FechaNacimientoo)
        {
            var item = new Estudiante
            {
                Id = Id,
                IdCarrera = IdCarrea,
                Nombre = Nombre,
                Apellido = Apellido,
                FechaNacimiento = FechaNacimientoo,

            };
            _dbcontext.Estudiantes.Add(item);
            _dbcontext.SaveChanges();

            return item.Id;

            //var item = new Estudiante
            //{
            //    Id = Registro.Id,
            //    IdCarrera = Registro.IdCarrera,
            //    Nombre = Registro.Nombre,
            //    Apellido = Registro.Apellido,
            //    FechaNacimiento = Registro.FechaNacimiento,
            //};
            //_dbcontext.Estudiantes.Add(item);
            //_dbcontext.SaveChanges();

            //return item.Id;
        }
        public string Eliminar(string Id)
        {
            var Estudiante = _dbcontext.Estudiantes.Find(Id);
            _dbcontext.Estudiantes.Remove(Estudiante);
            _dbcontext.SaveChanges();
            return Id;
        }
    }
}
