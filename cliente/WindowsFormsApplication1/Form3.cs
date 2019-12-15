using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        Socket server;
        string su_socket;
        string su_nombre;
        string mi_nombre;
        string mi_socket;

        public Form3(Socket ser,string Player2, string User2, string Player1, string User1)
        {
            InitializeComponent();
            server = ser;
            su_nombre = Player2;
            su_socket = User2;
            mi_nombre = Player1;
            mi_socket = User1;
          
        }

        private void Form3_Load(object sender, EventArgs e)
        {
              this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
              pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
              pictureBox1.Image = Image.FromFile(@"C:\Users\abc_s\OneDrive\Escritorio\cliente\WindowsFormsApplication1\bin\Debug\Tablero.png");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mensaje = "7/" + mi_nombre + ": " + textBox1.Text + "/" + su_socket;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        public void chat(string mensaje) 
        {
            string[] words = mensaje.Split('/');
            listBox1.Items.Clear();

            int i = 0;
            int result = Int32.Parse(words[1]);

            while (i < result)
            {
                listBox1.Items.Add(words[i + 2]);
                i++;
            }
        }

    }
}
