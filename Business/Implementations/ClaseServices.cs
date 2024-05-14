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
      }
  }

