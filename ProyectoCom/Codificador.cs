using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging.Filters;
using AForge.Imaging;
using System.Timers;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Configuration;

namespace ProyectoCOM
{
    public partial class FormCodificador : Form
    {
        private string mensaje = "";
        Bitmap imagen;

        public FormCodificador()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click_1(object sender, EventArgs e)
        {
            mensaje = txtGenerar.Text;
            
            foreach (char letra in mensaje)
            {
                TransmitirTransicion();
                TransmitirTransicion();
                TransmitirTransicion();
                CodificarLetra(letra.ToString().ToLower());
            }
        }

        #region codificación
        private void CodificarLetra(string letra)
        {
            //punto: verde; raya: rojo; transicion: celeste
            switch (letra)
            {
                case "a":
                    Punto();
                    Punto();
                    Punto();
                    Punto();
                    Punto();
                    break;
                case "b":
                    Punto();
                    Punto();
                    Punto();
                    Punto();
                    Raya();
                    break;
                case "c":
                    Punto();
                    Punto();
                    Punto();
                    Raya();
                    Punto();
                    break;
                case "d":
                    Punto();
                    Punto();
                    Punto();
                    Raya();
                    Raya();
                    break;
                case "e":
                    Punto();
                    Punto();
                    Raya();
                    Punto();
                    Punto();
                    break;
                case "f":
                    Punto();
                    Punto();
                    Raya();
                    Punto();
                    Raya();
                    break;
                case "g":
                    Punto();
                    Punto();
                    Raya();
                    Raya();
                    Punto();
                    break;
                case "h":
                    Punto();
                    Punto();
                    Raya();
                    Raya();
                    Raya();
                    break;
                case "i":
                    Punto();
                    Raya();
                    Punto();
                    Punto();
                    Punto();
                    break;
                case "j":
                    Punto();
                    Raya();
                    Punto();
                    Punto();
                    Raya();
                    break;
                case "k":
                    Punto();
                    Raya();
                    Punto();
                    Raya();
                    Punto();
                    break;
                case "l":
                    Punto();
                    Raya();
                    Punto();
                    Raya();
                    Raya();
                    break;
                case "m":
                    Punto();
                    Raya();
                    Raya();
                    Punto();
                    Punto();
                    break;
                case "n":
                    Punto();
                    Raya();
                    Raya();
                    Punto();
                    Raya();
                    break;
                case "ñ":
                    Punto();
                    Raya();
                    Raya();
                    Raya();
                    Punto();
                    break;
                case "o":
                    Punto();
                    Raya();
                    Raya();
                    Raya();
                    Raya();
                    break;
                case "p":
                    Raya();
                    Punto();
                    Punto();
                    Punto();
                    Punto();
                    break;
                case "q":
                    Raya();
                    Punto();
                    Punto();
                    Punto();
                    Raya();
                    break;
                case "r":
                    Raya();
                    Punto();
                    Punto();
                    Raya();
                    Punto();
                    break;
                case "s":
                    Raya();
                    Punto();
                    Punto();
                    Raya();
                    Raya();
                    break;
                case "t":
                    Raya();
                    Punto();
                    Raya();
                    Punto();
                    Punto();
                    break;
                case "u":
                    Raya();
                    Punto();
                    Raya();
                    Punto();
                    Raya();
                    break;
                case "v":
                    Raya();
                    Punto();
                    Raya();
                    Raya();
                    Punto();
                    break;
                case "w":
                    Raya();
                    Punto();
                    Raya();
                    Raya();
                    Raya();
                    break;
                case "x":
                    Raya();
                    Raya();
                    Punto();
                    Punto();
                    Punto();
                    break;
                case "y":
                    Raya();
                    Raya();
                    Punto();
                    Punto();
                    Raya();
                    break;
                case "z":
                    Raya();
                    Raya();
                    Punto();
                    Raya();
                    Punto();
                    break;
                case " ":
                    Raya();
                    Raya();
                    Punto();
                    Raya();
                    Raya();
                    break;
                case ".":
                default:
                    Raya();
                    Raya();
                    Raya();
                    Punto();
                    Punto();
                    break;
            }
        }
        #endregion

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
            pictureCodificador.Image = imagen;

            var freno = new Stopwatch();
            freno.Start();
            using (var tarea = Task.Delay(2500))
            {
                tarea.Wait();
            }
            freno.Stop();
        }
    }
}
