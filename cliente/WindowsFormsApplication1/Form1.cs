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
    public partial class Form1 : Form
    {
        Socket server;
        int i;
        delegate void DelegadoParaEscribir(string mensaje);
        delegate void DelegadoParaForm1Hide();

        Thread atender;
        Form2 Juego;
        Thread mostrar;

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
                i = 0;

                ThreadStart ts = delegate { atender_mensaje_servidor(); };
                atender = new Thread(ts);
                atender.Start();

            }
            catch (SocketException ex)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No se ha podido conectar con el servidor");
                i = 1;
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (nombre.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Debes Introducir un Nombre y/o contraseña");
            }
            else
            {
                if (i == 0)
                {
                    string mensaje = "2/" + nombre.Text + "/" + textBox1.Text;
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
                else
                {
                    MessageBox.Show("Intentanto Reconectar");
                    Conexion();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (nombre.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Debes Introducir un Nombre y/o contraseña");
            }
            else
            {
                if (i == 0)
                {
                    string mensaje = "1/" + nombre.Text + "/" + textBox1.Text;
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
                else
                {
                    MessageBox.Show("Intentanto Reconectar");
                    Conexion();
                }
            }
        }

        private void Form1Hide(){
             this.Hide();
        }

        public void Mostrar(string nombre)
        {
            Juego = new Form2(server,nombre);
            Juego.ShowDialog();

        }

        private void atender_mensaje_servidor()
        {
            while (true)
            {

                int op;
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                string mensaje = Encoding.ASCII.GetString(msg2).Split(',')[0];
                mensaje = mensaje.TrimEnd('\0');
                string[] words = mensaje.Split('/');
                op = Convert.ToInt32(words[0]);
                
                switch (op)
                {
                    case 1:
                         mensaje = words[1];
                       
                        MessageBox.Show(words[1]);

                        if (words[1].TrimEnd('\0') == "SI")
                        {
                            MessageBox.Show("Registrado ");
                        }
                        else
                        {
                            MessageBox.Show("NO Registrado, pruebe con otro nombre de usuario o pruebelo mas tarde ");
                        }

                        break;

                    case 2:

                        mensaje = words[1];

                        MessageBox.Show(mensaje);

                        if (words[1].TrimEnd('\0') == "SI")
                        {
                            MessageBox.Show("Acceso Permitido");
                            string nombre = words[2];

                            //
                            ThreadStart ts1 = delegate { Mostrar(nombre); };
                            mostrar = new Thread(ts1);
                            mostrar.Start();
                            Thread.Sleep(200);
                            this.Invoke(new DelegadoParaForm1Hide(Form1Hide), new object[] { });
                            //

                        }
                        else
                        {
                            MessageBox.Show("Accedo Denegado, NO ESTAS REGISTRADO");
                        }

                        break;

                    case 3: 

                        MessageBox.Show(mensaje);

                        Juego.Invoke(new DelegadoParaEscribir(Juego.Lista), new object[] { mensaje.TrimEnd('\0') });

                        break;

                    case 4:

                        Juego.Invoke(new DelegadoParaEscribir(Juego.Lista), new object[] { mensaje.TrimEnd('\0') });

                        break;

                    case 5:

                        Juego.Invoke(new DelegadoParaEscribir(Juego.Lista), new object[] { mensaje.TrimEnd('\0') });
                        Thread.Sleep(200);
                        break;

                    case 6:

                        Juego.Invoke(new DelegadoParaEscribir(Juego.Invitacion), new object[] { mensaje.TrimEnd('\0') });

                        break;

                    case 7:

                        Juego.Invoke(new DelegadoParaEscribir(Juego.Resolucion), new object[] { mensaje.TrimEnd('\0') });

                        break;

                    case 8:

                        Juego.Invoke(new DelegadoParaEscribir(Juego.Partida), new object[] { mensaje.TrimEnd('\0') });

                        break;

                }
            }
        }
    }
}
