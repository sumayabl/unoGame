using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        delegate void DelegadoParaEscribir(string mensaje);
        delegate void DelegadoParaForm2Hide();
        Socket server;
        string mi_nombre;
        string mi_socket;
        string su_nombre;
        string su_socket;  //socket del compañero
        string Player = "";
       


        public Form2(Socket ser, string nombre)
        {
            InitializeComponent();
            server = ser;
            mi_nombre = nombre;
            label1.Text = nombre;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        public void Lista(string mensaje) {

            string[] words = mensaje.Split('/');
            ListaC.Items.Clear();

            int i = 0;
            int result = Int32.Parse(words[1]);

            while (i < result)
            {
                ListaC.Items.Add(words[i + 2]);
                i++;
            }
        }

        public void Invitacion(string mensaje) {

            string[] words = mensaje.Split('/');

            if (words[1] == "SI")
            {
                label2.Text = "Se ha enviado correctamente la peticion";
                mi_nombre = words[2];
                mi_socket = words[3];
            }
            else 
            {
                label2.Text = "No se ha enviado correctamente la peticion";
                mi_nombre = words[2];
                mi_socket = words[3];
            }
        }

        public void Resolucion(string mensaje) {

            string[] words = mensaje.Split('/');
            string text = "Te ha invitado a una partida:" + words[1];
            su_nombre = words[1];
            su_socket = words[2];
            label2.Text = text;
            button3.Enabled = true;
            button4.Enabled = true;
        }

        public void Partida(string mensaje) {

            string[] words = mensaje.Split('/');

            if (words[1] == "SI")
            {
                label2.Text = "Partida Aceptada";
                this.Hide();
            }
            else
            {
                label2.Text = "Partida NO Aceptada";
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\abc_s\OneDrive\Escritorio\cliente\WindowsFormsApplication1\bin\Debug\Uno.png");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mensaje = "3/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string mensaje = "4/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            Form1 Game = new Form1();
            this.Close();
            this.Hide();
            Game.ShowDialog();
        }

        private void ListaC_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Jugador = ListaC.SelectedItem.ToString();
            Player = Jugador;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Player == "")
            {
                MessageBox.Show("Selecciona un Jugador");
            }
            else if(Player == mi_nombre)
            {
                MessageBox.Show("Selecciona un Jugador Valido");
            }
            else 
            {
                string mensaje = "5/" + Player;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            button4.Enabled = false;

            string mensaje = "6/SI/" + su_nombre + "/" + su_socket;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            button4.Enabled = false;

            string mensaje = "6/NO/" + su_nombre + "/" + su_socket;
            su_socket = "";
            su_nombre = "";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }
    }
}
