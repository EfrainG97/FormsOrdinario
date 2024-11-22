using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoOrdinario.Model
{
    internal class Personaje
    {
        public Personaje(string id, string name, string house, string gender, string patronus, string image)
        {
            Id = id;
            Name = name;
            House = house;
            Gender = gender;
            Patronus = patronus;
            Image = image;
        }

        public Personaje() { }

        public string Id { get; set; }
        public string Name { get; set; }
        public string House { get; set; }
        public string Gender { get; set; }
        public string Patronus { get; set; }
        public string Image { get; set; }
    }
}
