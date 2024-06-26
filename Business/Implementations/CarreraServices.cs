﻿using Business.Interfaces;
using Core.ModelView;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementations
{
    public class CarreraServices : ICarreraServices
    {
        private readonly UniversidadContext _dbcontext;
        public CarreraServices() { }
        public CarreraServices(UniversidadContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public List<CarreraView> ConsultarServicios()
        {
            List<CarreraView> listaCarreraVievs = new List<CarreraView>();
            var listServicios = _dbcontext.Carreras.ToList();
            if (listServicios != null)
            {
                foreach (var item in listServicios)
                {
                    CarreraView CarreraView = new CarreraView()
                    {
                        Codigo=item.Codigo,
                        Nombre=item.Nombre,

                    };
                    listaCarreraVievs.Add(CarreraView);
                }
            }
            return listaCarreraVievs;
        }

        public CarreraView Buscar(int Id)
        {
            var carrera = _dbcontext.Carreras.Find(Id);
            if (carrera == null)
            {
                return null;
            }
            var carreraView = new CarreraView()
            {
              Codigo = carrera.Codigo,  
              Nombre = carrera.Nombre,
            };

            return carreraView;
        }

        public int Actualizar(int Codigo, CarreraView registro)
        {
            var carrera = _dbcontext.Carreras.Find(Codigo);
            if (carrera == null)
            {
                throw new Exception("La carrera que intenta actualizar no existe");
            }
            else
            {
                carrera.Nombre = registro.Nombre;
                _dbcontext.SaveChanges();
                return carrera.Codigo;
            }
        }

        public int Agregar(CarreraView Registro)
        {
            var carrera = _dbcontext.Carreras.Find(Registro.Codigo); 
            if (carrera != null)
            {
                throw new Exception("La carrera ya existe en la base de datos");
            }
            else
            {
                var item = new Carrera
                {
                    Codigo = Registro.Codigo,
                    Nombre = Registro.Nombre,
                };
                _dbcontext.Carreras.Add(item);
                _dbcontext.SaveChanges();

                return item.Codigo;
            }
        }

        public int Eliminar(int Codigo)
        {
            var Carrera = _dbcontext.Carreras.Find(Codigo);
            if (Carrera == null)
            {
                throw new Exception("La carrera que intenta eliminar no esta registrada en la base de datos");
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
