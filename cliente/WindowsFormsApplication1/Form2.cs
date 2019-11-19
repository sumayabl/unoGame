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

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        Socket server;

        public Form2(Socket ser)
        {
            InitializeComponent();
            server = ser;

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\sumaa\Desktop\Escritorio\cliente\WindowsFormsApplication1\bin\Debug\Uno.png");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mensaje = "3/";
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            //Recibimos la respuesta del servidor
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split(',')[0];

            MessageBox.Show(mensaje);

            string[] words = mensaje.Split('/');
            ListaC.Items.Clear();

            int i = 0;
            int result = Int32.Parse(words[0]);

            while (i < result)
            {
                ListaC.Items.Add(words[i+1]);
                i++;
            }
        }

      
       /* private void button1_Click(object sender, EventArgs e)
        {
            /*int i = 1;
            string[] words = mensaje.Split('/');
             
            int s = Int32.Parse(words[0]);
            
            while(i< s+1){
                ListaC.Items.Add(words[i]);
            s++;
            }
        }*/
    }
}
