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

 public class ClaseServices : IClaseServices
      {
            private readonly UniversidadContext _dbcontext;
            public ClaseServices() { }
            public ClaseServices(UniversidadContext dbcontext)
            {
                _dbcontext = dbcontext;
            }
            public List<ClaseView> ConsultarClases()
            {
                List<ClaseView> listaClaseView = new List<ClaseView>();
                var listServicios = _dbcontext.Clases.ToList();
                if (listServicios != null)
                {
                    foreach (var item in listServicios)
                    {
                        ClaseView ClaseWiew = new ClaseView()
                        {
                            Codigo = item.Codigo,
                            Nombre = item.Nombre,
                        };
                    listaClaseView.Add(ClaseWiew);
                    }
                }
                return listaClaseView;
            }

             public ClaseView Buscar(int Id)
             {
                var clase = _dbcontext.Clases.Find(Id);
                if (clase == null)
                {
                    return null;
                }
                var claseView = new ClaseView()
                {
                    Codigo = clase.Codigo,
                    Nombre = clase.Nombre,
                };
                return claseView;
             }

            public int Agregar(ClaseView Registro)
            {
                var carrera = _dbcontext.Clases.Find(Registro.Codigo);
                if (carrera != null)
                {
                    throw new Exception("La clase ya existe en la base de datos");
                }
                else
                {
                    var item = new Clase
                    {
                        Codigo = Registro.Codigo,
                        Nombre = Registro.Nombre,
                    };
                    _dbcontext.Clases.Add(item);
                    _dbcontext.SaveChanges();
                    return item.Codigo;
                }
            }

        public int Actualizar(int Codigo, ClaseView registro)
            {
                var clase= _dbcontext.Clases.Find(Codigo);
                if (clase == null)
                {
                    throw new Exception("La clase que intenta actualizar no existe");
                }
                else
                {
                    clase.Nombre = registro.Nombre;
                    _dbcontext.SaveChanges();
                    return clase.Codigo;
                }
            }
            public int Eliminar(int Codigo)
            {
                var Carrera = _dbcontext.Carreras.Find(Codigo);
                if (Carrera == null)
                {
                    throw new Exception("La clase que intenta eliminar no esta registrada en la base de datos");
                }
                else
                {
                    _dbcontext.Carreras.Remove(Carrera);
                    _dbcontext.SaveChanges();
                    return Codigo;
                }
            }
    }
}

