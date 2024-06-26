﻿using Core.ModelView;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IMaestroServices
    {
        /// <summary>
        /// Me trae todos los servicios de la bd
        /// </summary>
        /// <returns>Lista</returns>
        List<MaestroWiew> ConsultarServicios();

        public MaestroWiew Buscar(String id);

        public String Eliminar(String id);

        public string Agregar(MaestroWiew Registro);

        public String Actualizar(String Id, MaestroWiew registro);
       
    }
}
