using AMP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AMP.Utilities
{
    internal class RestService
    {
        HttpClient httpclient;
        string urlBase = "https://asaludapi.azurewebsites.net/";
        string urlSeguridad = "Seguridad";

        public RestService()
        {
            httpclient = new HttpClient();
            if (!String.IsNullOrEmpty(Constantes.Token))
            {
                httpclient.DefaultRequestHeaders.Add("Authorization", $"Bearer {Constantes.Token}");
            }
        }

        public async Task<List<T>> Obtener<T>(string ruta)
        {
            List<T> lista = new List<T>();
            Uri uri = new Uri(urlBase + ruta);

            HttpResponseMessage response = await httpclient.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string resultado = await response.Content.ReadAsStringAsync();
                lista = JsonConvert.DeserializeObject<List<T>>(resultado);
            }

            return lista;
        }

        public async Task<Boolean> Guardar<T>(T dataModificar,bool esnuevo, string ruta)
        {

            var clienteSerializado = JsonConvert.SerializeObject(dataModificar);
            StringContent contect = new StringContent(clienteSerializado, Encoding.UTF8, "application/json");
           
            if (!esnuevo)
            {
                string uri = (urlBase + ruta);
                HttpResponseMessage response = await httpclient.PutAsync(uri, contect);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            else
            {
                Uri uriModificar = new Uri(urlBase + ruta);
                HttpResponseMessage responseModificar = await httpclient.PostAsync(uriModificar, contect);
                if (responseModificar.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<Boolean> Borrar(int id,string ruta)
        {
            string uri = ($"{urlBase + ruta}?id={id}");
            HttpResponseMessage response = await httpclient.DeleteAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<string> ValidarUsuario(string Login, string Clave)
        {
            string resultado = "";
            Usuario usuario = new Usuario();
            usuario.Clave = Clave;
            usuario.Login = Login;

            var clienteSerializado = JsonConvert.SerializeObject(usuario);
            StringContent content = new StringContent(clienteSerializado, Encoding.UTF8, "application/json");

            Uri uri = new Uri(urlBase + urlSeguridad + "/" + "ObtenerToken");
            
            HttpResponseMessage response = await httpclient.PostAsync(uri, content);
            if (response.IsSuccessStatusCode)
            {
                resultado = await response.Content.ReadAsStringAsync();
            }

            return resultado;
        }

    }
}
