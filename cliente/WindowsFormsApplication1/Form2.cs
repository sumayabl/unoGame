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
        Socket server;
        string name;
        string Player = "";
        string Player2;
        Form3 Juego3;


        public Form2(Socket ser, string nombre)
        {
            InitializeComponent();
            server = ser;
            name = nombre;
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
            }
            else 
            {
                label2.Text = "No se ha enviado correctamente la peticion";
            }
        }

        public void Resolucion(string mensaje) {

            string[] words = mensaje.Split('/');
            string text = "Te ha invitado a una partida:" + words[1];
            Player2 = words[1];
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
                Juego3 = new Form3(server);
                Juego3.ShowDialog();
            }
            else {

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
            else if(Player == name)
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

            string mensaje = "6/SI/" + Player2;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            this.Hide();
            Juego3= new Form3(server);
            Juego3.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            button4.Enabled = false;

            string mensaje = "6/NO/" + Player2;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

    }
}
