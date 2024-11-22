using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoOrdinario.Model;
using ProyectoOrdinario.Controller;
using System.IO;
using System.Net.Http;

namespace ProyectoOrdinario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        PersonajeController pc = new PersonajeController();

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarPersonajes();
        }

        void Limpiar(Control con)
        {
            foreach (Control c in con.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
            }
        }

        private async void CargarPersonajes()
        {
            DGVPersonajes.DataSource = null;
            DGVPersonajes.DataSource = await pc.GetPersonajes();
            DGVPersonajes.Columns["Image"].Visible = false;
        }

        private async void BtnBuscar_Click(object sender, EventArgs e)
        {
            string bus = TBid.Text;
            DGVPersonajes.DataSource = null;
            var personajes = await pc.ObtenerPersonajePorID(bus);
            DGVPersonajes.DataSource = personajes;
            DGVPersonajes.Columns["Image"].Visible = false;

            var primerPersonaje = personajes[0];
            if (!string.IsNullOrEmpty(primerPersonaje.Image))
            {
                await CargarImagenEnPictureBox(PcbPersonaje, primerPersonaje.Image);
            }
            else
            {
                MessageBox.Show("La URL de la imagen no está disponible.");
            }
        }

        private async Task CargarImagenEnPictureBox(PictureBox pictureBox, string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var data = await client.GetByteArrayAsync(url);

                    using (var stream = new MemoryStream(data))
                    {
                        pictureBox.Image = Image.FromStream(stream);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la imagen: {ex.Message}");
            }
        }
    }
}
