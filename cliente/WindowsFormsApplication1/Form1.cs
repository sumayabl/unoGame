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
    public partial class Form1 : Form
    {
        Socket server;
        int i;


        private void Conexion()
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.101");
            IPEndPoint ipep = new IPEndPoint(direc, 9060);


            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                MessageBox.Show("Conectado");
                i=0;

            }
            catch (SocketException ex)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No se ha podido conectar con el servidor");
                i=1;
                return;
            }
        }

        public Form1()
        {
            InitializeComponent();
            
        }   

        private void Form1_Load(object sender, EventArgs e)
        {
            Conexion();
            MessageBox.Show("" + i);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (nombre.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Debes Introducir un Nombre y/o contraseña");
                //Conexion();
            }
            else
            {
                if (i == 0)
                {
                    string mensaje = "2/" + nombre.Text + "/" + textBox1.Text;
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    //Recibimos la respuesta del servidor
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split(',')[0];

                    mensaje = mensaje.Substring(0,2);

                    MessageBox.Show(mensaje);

                    if (mensaje == "SI")
                    {
                        MessageBox.Show("Acceso Permitido");
                        Form2 Juego = new Form2(server);
                        this.Hide();
                        Juego.ShowDialog();
                        this.Show();
                    }  
                    else
                    {
                        MessageBox.Show("Accedo Denegado, NO ESTAS REGISTRADO");
                    }

                    //Conexion();
                }
                else
                {
                    MessageBox.Show("Intentanto Reconectar");
                    Conexion();
                }  
            }
            // Se terminó el servicio. 
            // Nos desconectamos
            //server.Shutdown(SocketShutdown.Both);
            //server.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (nombre.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Debes Introducir un Nombre y/o contraseña");
               // Conexion();
            }
            else
            {
                if (i == 0)
                {
                    string mensaje = "1/" + nombre.Text + "/" + textBox1.Text;
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    //Recibimos la respuesta del servidor
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split(',')[0];

                    mensaje = mensaje.Substring(0, 2);

                    MessageBox.Show(mensaje);

                    if (mensaje == "SI")
                    {
                        MessageBox.Show("Registrado ");
                    }
                    else
                    {
                     MessageBox.Show("NO Registrado, pruebe con otro nombre de usuario o pruebelo mas tarde ");
                    }
                    //Conexion();
                }
                else
                {
                    MessageBox.Show("Intentanto Reconectar");
                    Conexion();
                }
            }
        } 
    }
}


