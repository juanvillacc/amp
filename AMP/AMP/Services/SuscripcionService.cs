using AMP.Models;
using AMP.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AMP.Services
{
    internal class SuscripcionService
    {
        RestService ServiceAPI = new RestService();
        string rutaControlador = "Suscripcion";
        public async Task<List<Suscripcion>> ObtenerSuscripciones()
        {
            var lista = await ServiceAPI.Obtener<Suscripcion>(rutaControlador + "/ObtenerSuscripciones");

            return lista;
        }

        
    }
}
