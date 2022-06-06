using AMP.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static AMP.Services.UsuarioService;

namespace AMP.Services
{
    internal class UsuarioService
    {

        public async Task<bool> ValidarUsuarioAsync(string Login, string Clave)
        {
            RestService rest = new RestService();
            Constantes.Token = String.Empty;
            var resultado = await rest.ValidarUsuario(Login, Clave);
            if (!string.IsNullOrEmpty(resultado))
            {
                Constantes.Token = resultado;   
                return true;
            }
            else
            {
                return false;
            }
        }

        public interface IUsuarioService
        {
           Task<bool> ValidarUsuario(string Login, string Contrasena);
        }
    }
}
