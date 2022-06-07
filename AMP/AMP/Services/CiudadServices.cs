using AMP.Models;
using AMP.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace AMP.Services
{
    public class CiudadServices
    {
        RestService ServiceAPI = new RestService();
        string rutaControlador = "Ciudad";
        public async Task<List<Ciudad>> ObtenerCiudades()
        {
            var lista = await ServiceAPI.Obtener<Ciudad>(rutaControlador + "/ObtenerCiudades");
            return lista;
        }
    }
}
