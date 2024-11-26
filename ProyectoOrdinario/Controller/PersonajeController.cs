using ProyectoOrdinario.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;

namespace ProyectoOrdinario.Controller
{
    internal class PersonajeController : IPersonaje
    {
        private static HttpClient CrearCliente()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7250/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        }

        private static readonly HttpClient client = CrearCliente();


        public async Task<List<Personaje>> GetPersonajes()
        {
            HttpResponseMessage response = await client.GetAsync("personaje");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var personajes = JsonConvert.DeserializeObject<List<Personaje>>(jsonResponse);
                return personajes;
            }
            return new List<Personaje>();
        }

        public async Task<List<Personaje>> GetPersonajesCasa(string casa)
        {
            HttpResponseMessage response = await client.GetAsync($"personaje/casa/{casa}");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var personajes = JsonConvert.DeserializeObject<List<Personaje>>(jsonResponse);
                return personajes;
            }
            return new List<Personaje>();
        }

        public async Task<List<Personaje>> ObtenerPersonajePorID(string id)
        {
            HttpResponseMessage response = await client.GetAsync($"personaje/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var personajes = JsonConvert.DeserializeObject<List<Personaje>>(jsonResponse);
                return personajes;
            }
            return new List<Personaje>();
        }
    }
}
