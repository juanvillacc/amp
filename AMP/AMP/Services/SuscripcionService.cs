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
        public async Task GuardarSuscripcion(Suscripcion dato)
        {
            // puede ser actualizar o ingresar
            var esNuevo = dato.id_usuario_suscripcion == 0;
            var rutaMetodo = !esNuevo ? "Actualizar" : "Ingresar"; 
            await ServiceAPI.Guardar<Suscripcion>(dato, esNuevo, rutaControlador + $"/{rutaMetodo}");
        }

        public async Task EliminarSuscripcion(int id)
        {
            await ServiceAPI.Borrar(id, rutaControlador + "/Eliminar");
        }
    }
}
