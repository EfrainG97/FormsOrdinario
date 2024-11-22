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
            httpClient.BaseAddress = new Uri("https://hp-api.onrender.com/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        }

        private static readonly HttpClient client = CrearCliente();


        public async Task<List<Personaje>> GetPersonajes()
        {
            HttpResponseMessage response = await client.GetAsync("api/characters");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var personajes = JsonConvert.DeserializeObject<List<Personaje>>(jsonResponse);
                return personajes;
            }
            return new List<Personaje>();
        }

        public Task<List<Personaje>> GetPersonajesCasa()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Personaje>> ObtenerPersonajePorID(string id)
        {
            HttpResponseMessage response = await client.GetAsync($"https://hp-api.onrender.com/api/character/{id}");
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
