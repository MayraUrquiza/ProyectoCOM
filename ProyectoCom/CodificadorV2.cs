using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Configuration;
using System.Diagnostics;

namespace ProyectoCOM
{
    public partial class CodificadorV2 : Form
    {
        Bitmap imagen;
        bool codificando = false;
        int contador = 0;
        int tiempo = 3000;
        int tecla = 0;
        public CodificadorV2()
        {
            InitializeComponent();
        }

        private void txtGenerar_TextChanged(object sender, EventArgs e)
        {
            tecla++;
            string mensaje = txtGenerar.Text.ToString();
            if (tecla >= 2 && mensaje.Length >= 1)
            {
                ThreadStart delegado = new ThreadStart(CodificarLetra);
                Thread hilo = new Thread(delegado);
                hilo.Start();
            }
        }

      
        private void CodificarLetra()
        {
            string mensaje = txtGenerar.Text.ToString().ToLower();
            
            if (codificando == false)
            {
                codificando = true;
                
              //punto: verde; raya: rojo; transicion: celeste
                switch (mensaje[contador])
                {
                    case 'a':
                        Punto();
                        Punto();
                        Punto();
                        Punto();
                        Punto();
                        break;
                    case 'b':
                        Punto();
                        Punto();
                        Punto();
                        Punto();
                        Raya();
                        break;
                    case 'c':
                        Punto();
                        Punto();
                        Punto();
                        Raya();
                        Punto();
                        break;
                    case 'd':
                        Punto();
                        Punto();
                        Punto();
                        Raya();
                        Raya();
                        break;
                    case 'e':
                        Punto();
                        Punto();
                        Raya();
                        Punto();
                        Punto();
                        break;
                    case 'f':
                        Punto();
                        Punto();
                        Raya();
                        Punto();
                        Raya();
                        break;
                    case 'g':
                        Punto();
                        Punto();
                        Raya();
                        Raya();
                        Punto();
                        break;
                    case 'h':
                        Punto();
                        Punto();
                        Raya();
                        Raya();
                        Raya();
                        break;
                    case 'i':
                        Punto();
                        Raya();
                        Punto();
                        Punto();
                        Punto();
                        break;
                    case 'j':
                        Punto();
                        Raya();
                        Punto();
                        Punto();
                        Raya();
                        break;
                    case 'k':
                        Punto();
                        Raya();
                        Punto();
                        Raya();
                        Punto();
                        break;
                    case 'l':
                        Punto();
                        Raya();
                        Punto();
                        Raya();
                        Raya();
                        break;
                    case 'm':
                        Punto();
                        Raya();
                        Raya();
                        Punto();
                        Punto();
                        break;
                    case 'n':
                        Punto();
                        Raya();
                        Raya();
                        Punto();
                        Raya();
                        break;
                    case 'ñ':
                        Punto();
                        Raya();
                        Raya();
                        Raya();
                        Punto();
                        break;
                    case 'o':
                        Punto();
                        Raya();
                        Raya();
                        Raya();
                        Raya();
                        break;
                    case 'p':
                        Raya();
                        Punto();
                        Punto();
                        Punto();
                        Punto();
                        break;
                    case 'q':
                        Raya();
                        Punto();
                        Punto();
                        Punto();
                        Raya();
                        break;
                    case 'r':
                        Raya();
                        Punto();
                        Punto();
                        Raya();
                        Punto();
                        break;
                    case 's':
                        Raya();
                        Punto();
                        Punto();
                        Raya();
                        Raya();
                        break;
                    case 't':
                        Raya();
                        Punto();
                        Raya();
                        Punto();
                        Punto();
                        break;
                    case 'u':
                        Raya();
                        Punto();
                        Raya();
                        Punto();
                        Raya();
                        break;
                    case 'v':
                        Raya();
                        Punto();
                        Raya();
                        Raya();
                        Punto();
                        break;
                    case 'w':
                        Raya();
                        Punto();
                        Raya();
                        Raya();
                        Raya();
                        break;
                    case 'x':
                        Raya();
                        Raya();
                        Punto();
                        Punto();
                        Punto();
                        break;
                    case 'y':
                        Raya();
                        Raya();
                        Punto();
                        Punto();
                        Raya();
                        break;
                    case 'z':
                        Raya();
                        Raya();
                        Punto();
                        Raya();
                        Punto();
                        break;
                    case ' ':
                        Raya();
                        Raya();
                        Punto();
                        Raya();
                        Raya();
                        break;
                    case '.':
                    default:
                        Raya();
                        Raya();
                        Raya();
                        Punto();
                        Punto();
                        break;
                }

                contador++;
                codificando = false;
                ControlarCompletitudTransmision();
            }
                    
        }

        private void ControlarCompletitudTransmision()
        {
            int mensaje = txtGenerar.Text.ToString().Length;
            if (mensaje > contador)
            {
                codificando = false;
                CodificarLetra();
            }

            if (mensaje == contador)
            {
                MessageBox.Show("Fin envío del mensaje.");
            }
        }

        private void Limpiar()
        {
            txtGenerar.Text = "";
            codificando = false;
            lblCadena.Text = "";
            contador = 0;
        }

        private void Punto()
        {
            imagen = new Bitmap(ConfigurationManager.AppSettings["punto"]);
            this.Transmitir(imagen);
            TransmitirTransicion();
        }

        private void Raya()
        {
            imagen = new Bitmap(ConfigurationManager.AppSettings["raya"]);
            this.Transmitir(imagen);
            TransmitirTransicion();
        }

        private void TransmitirTransicion()
        {
            imagen = new Bitmap(ConfigurationManager.AppSettings["transicion"]);
            this.Transmitir(imagen);           
        }

        private void Transmitir(Bitmap imagen)
        {
            picture.Image = imagen;

            var freno = new Stopwatch();
            freno.Start();
            using (var tarea = Task.Delay(tiempo))
            {
                tarea.Wait();
            }
            freno.Stop();

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtGenerar.Text = "";
            imagen = new Bitmap(ConfigurationManager.AppSettings["transicion"]);

            if (codificando)
            {
                MessageBox.Show("Transmisión interrumpida.", "Importante", MessageBoxButtons.OK,MessageBoxIcon.Information);
                picture.Image = imagen; 
                //HAY QUE CONTROLAR LA INTERRUPCION EN EL DECODIFICADOR
            }
        }

        private void cmbTiempo_SelectedIndexChanged(object sender, EventArgs e)
        {
            tiempo = (int)cmbTiempo.SelectedIndex * 1000;
        }    }
}
