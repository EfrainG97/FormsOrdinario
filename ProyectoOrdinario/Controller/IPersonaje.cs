using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoOrdinario.Model;

namespace ProyectoOrdinario.Controller
{
    internal interface IPersonaje
    {
        Task<List<Personaje>> GetPersonajes();
        Task<List<Personaje>> ObtenerPersonajePorID(string id);
        Task<List<Personaje>> GetPersonajesCasa(string casa);
    }
}
