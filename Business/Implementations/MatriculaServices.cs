using Business.Interfaces;
using Core.ModelView;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Implementations
{
    public class MatriculaServices : IMatriculaServices
    {
        private readonly UniversidadContext _dbcontext;
        public MatriculaServices() { }
        public MatriculaServices(UniversidadContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public List<MatriculaView> ConsultarMatriculas()
        {
            List<MatriculaView> listaMatriculaView = new List<MatriculaView>();
            var listServicios = _dbcontext.Matriculas.ToList();
            if (listServicios != null)
            {
                foreach (var item in listServicios)
                {
                    MatriculaView MatriculaView = new MatriculaView()
                    {
                        Id= item.Id,
                        IdEstudiante = item.IdEstudiante,
                        IdSeccion= item.IdSeccion,
                    };
                    listaMatriculaView.Add(MatriculaView);
                }
            }
            return listaMatriculaView;
        }
        public MatriculaView Buscar(int Id)
        {
            var matricula = _dbcontext.Matriculas.Find(Id);
            if (matricula == null)
            {
                return null;
            }
            var matriculaWiew = new MatriculaView()
            {
                Id = matricula.Id,
                IdEstudiante = matricula.IdEstudiante,
                IdSeccion = matricula.IdSeccion,
            };
            return matriculaWiew;
        }

        public int Actualizar(int Id, MatriculaView registro)
        {
            var matricula = _dbcontext.Matriculas.Find(Id);
            if(matricula == null)
            {
                throw new Exception("La matricula no existe en la base de datos para actualizar");
            }
            else
            {
                matricula.IdEstudiante = registro.IdEstudiante;
                matricula.IdSeccion = registro.IdSeccion;
                _dbcontext.SaveChanges();
                return matricula.Id;
            }
        }

        public int Agregar(int Id, string IdEstudiante, string IdSeccion)
        {
            var matricula = _dbcontext.Matriculas.Find(Id); 
            if(matricula != null)
            {
                throw new Exception("La matricula ya existe en la base de datos");
            }else
            {
                var item = new Matricula
                {
                    Id = Id,
                    IdSeccion = IdSeccion,
                    IdEstudiante = IdEstudiante,
                };
                _dbcontext.Matriculas.Add(item);
                _dbcontext.SaveChanges();
                return item.Id;
            }
        }

        public int Eliminar(int Id)
        {
            var Matricula = _dbcontext.Matriculas.Find(Id);
            if (Matricula == null)
            {
                throw new Exception("La matricula que intenta eliminar no existe en la base de datos");
            }
            _dbcontext.Matriculas.Remove(Matricula);
            _dbcontext.SaveChanges();
            return Id;
        }
    }
}
