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

        public int Actualizar(int Id, Matricula registro)
        {
            var matricula = _dbcontext.Matriculas.Find(Id);
            matricula.Id = registro.Id;
            matricula.IdEstudiante = registro.IdEstudiante;
            matricula.IdSeccion = registro.IdSeccion;
            _dbcontext.SaveChanges();
            return matricula.Id;
        }

        public int Agregar(Matricula Registro)
        {
            var item = new Matricula
            {
                Id = Registro.Id,
                IdSeccion = Registro.IdSeccion,
                IdEstudiante = Registro.IdEstudiante,
            };
            _dbcontext.Matriculas.Add(item);
            _dbcontext.SaveChanges();
            return item.Id;
        }

        public int Eliminar(int Id)
        {
            var Matricula = _dbcontext.Matriculas.Find(Id);
            _dbcontext.Matriculas.Remove(Matricula);
            _dbcontext.SaveChanges();
            return Id;
        }
    }
}
