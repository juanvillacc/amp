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
        string urlBase = "https://6284fece3060bbd34742ca84.mockapi.io/api/v1/";
        
        public RestService()
        {
            httpclient = new HttpClient();
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
            string uri = ($"{urlBase + ruta}/{id}");
            HttpResponseMessage response = await httpclient.DeleteAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }



    }
}
