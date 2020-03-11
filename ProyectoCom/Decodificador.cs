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
using Alturos.Yolo;
using Alturos.Yolo.Model;

namespace ProyectoCOM
{
    public partial class FormDecodificador : Form
    {
        Bitmap imagen = new Bitmap(ConfigurationManager.AppSettings["bitmap"]);
        private float hue;

        private Color color1 = new Color();

        //agrego las variables para los otros colores
        private Color color2 = new Color();
        private Color color3 = new Color();

        private float hue2;
        private float hue3;

        List<string> cadena_simbolos = new List<string>();
        List<string> cadena_final = new List<string>();

        //variables para decodificacion por deteccion de color
        bool rojo = false;
        bool verde = false;
        bool celeste = false;

        public FormDecodificador()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            VideoCaptureDeviceForm webcamform = new VideoCaptureDeviceForm();
            webcamform.ShowDialog();
            VideoCaptureDevice webcam = new VideoCaptureDevice(webcamform.VideoDeviceMoniker);
            webcam.NewFrame += new NewFrameEventHandler(Grabar);
            webcam.Start();
            this.vspWebcam.VideoSource = webcam;
            vspWebcam.Start();
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            vspWebcam.Stop();
        }
        
        private void vspWebcam_NewFrame(object sender, ref Bitmap image)
        {
            this.Grabar(sender, new NewFrameEventArgs(image));
        }

        private void Grabar(object sender, NewFrameEventArgs frame)
        {
            Bitmap video = (Bitmap)frame.Frame.Clone();
            Bitmap temp = new Bitmap(video.Width, video.Height);
            Graphics g = Graphics.FromImage(temp);
            int left = video.Width / 4;
            int top = video.Height / 4;
            int width = video.Width / 2;
            int height = video.Height / 2;
            Rectangle srcRect = new Rectangle(left, top, width, height);
            Rectangle dstRect = new Rectangle(0, 0, temp.Width, temp.Height);
            g.DrawImage(video, dstRect, srcRect, GraphicsUnit.Pixel);

            //========================================= Prueba IA =================================================
            picture.Image = video;
            var configurationDetector = new ConfigurationDetector();
            var config = configurationDetector.Detect();
            var yolo = new YoloWrapper(config);
            var memoryStream = new MemoryStream();
            video.Save(memoryStream, ImageFormat.Png);
            var items = yolo.Detect(memoryStream.ToArray()).ToList();
            AddDetailsToPictureBox(picture, items, frame);

            //========================================= Prueba IA =================================================

            //picture.Image = temp;
            //pictureBox1.Image = this.Tracker(frame, color1, "celeste");
            //pictureBox2.Image = this.Tracker(frame, color2, "verde");
            //pictureBox3.Image = this.Tracker(frame, color3, "rojo");
        }

        //=============================================================================================

        private void AddDetailsToPictureBox(PictureBox pictureBox, List<YoloItem> items, NewFrameEventArgs frame)
        {
            var img = pictureBox.Image;
            var font = new Font("Arial", 21, FontStyle.Bold);
            var brush = new SolidBrush(Color.Red);
            var graphics = Graphics.FromImage(img);
            foreach (var item in items)
            {
                var x = item.X;
                var y = item.Y;
                var width = item.Width;
                var height = item.Height;
                var tung = item.Type;
                var rect = new Rectangle(x, y, width, height);
                var pen = new Pen(Color.LightGreen, 6);
                var point = new Point(x, y);

                if (tung.ToLower() == "tvmonitor")
                {
                    pictureBox1.Image = this.Tracker(frame, color1, "celeste");
                    pictureBox2.Image = this.Tracker(frame, color2, "verde");
                    pictureBox3.Image = this.Tracker(frame, color3, "rojo");
                }
                graphics.DrawRectangle(pen, rect);
                graphics.DrawString(item.Type, font, brush, point);
            }
            pictureBox.Image = img;
        }

        //=============================================================================================

        private Bitmap Tracker(NewFrameEventArgs frame, Color color, string colorDetectado)
        {
            Bitmap copia = frame.Frame.Clone() as Bitmap;

            Bitmap temp = new Bitmap(copia.Width, copia.Height);
            Graphics g = Graphics.FromImage(temp);
            int left = copia.Width / 4;
            int top = copia.Height / 4;
            int width = copia.Width / 2;
            int height = copia.Height / 2;
            Rectangle srcRect = new Rectangle(left, top, width, height);
            Rectangle dstRect = new Rectangle(0, 0, temp.Width, temp.Height);
            g.DrawImage(copia, dstRect, srcRect, GraphicsUnit.Pixel);

            EuclideanColorFiltering filtro = new EuclideanColorFiltering();

            filtro.CenterColor = new AForge.Imaging.RGB(color.R, color.G, color.B);
            filtro.Radius = 100;
            filtro.ApplyInPlace(temp);

            BlobCounter blobcounter = new BlobCounter();
            blobcounter.MinWidth = 5;
            blobcounter.MinHeight = 5;
            blobcounter.FilterBlobs = true;
            blobcounter.ObjectsOrder = ObjectsOrder.Size;
            blobcounter.ProcessImage(temp);
            Rectangle[] rects = blobcounter.GetObjectsRectangles();

            if (rects.Length > 0)
            {
                Rectangle objectRect = rects[0];
                if (objectRect.Width >= 300 && objectRect.Height >= 300)
                {
                        //Graphics g = Graphics.FromImage(temp);
                        using (Pen pen = new Pen(Color.FromArgb(0, 255, 250), 5))
                    {
                        g.DrawRectangle(pen, objectRect);
                        this.ProcesarColor(colorDetectado);
                    }
                    g.Dispose();
                }
            }
            return temp;
        }

        private void ProcesarColor(string color)
        {
            switch (color)
            {
                case "rojo":
                    if (rojo)
                    {
                        cadena_final.Add("-");
                        AgregarSimbolo("-");
                        rojo = false;
                        celeste = true;
                        verde = false;
                    }
                    break;
                case "verde":
                    if (verde)
                    {
                        cadena_final.Add(".");
                        AgregarSimbolo(".");
                        verde = false;
                        celeste = true;
                        rojo = false;
                    }
                    break;
                case "celeste":
                default:
                    string codigo = "";
                    if (celeste)
                    {
                        cadena_final.Add("T");
                        AgregarSimbolo("T");
                        lblcaracteres.Text = cadena_final.Count.ToString();
                        if (cadena_final.Count % 10 == 0)
                        {
                            if (cadena_final.Count != 10)
                                codigo = "";
                            for (int i = cadena_final.Count - 10; i < cadena_final.Count; i++)
                            {
                                codigo += cadena_final[i];
                            }
                            lblFinal.Text = lblFinal.Text + this.Decodificar(codigo);
                        }
                        rojo = true;
                        verde = true;
                        celeste = false;
                    }
                    break;
            }
        }

        public Rectangle objectRect { get; set; }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (chkAzul.Checked)
            {
                colorDialog1.ShowDialog();
                color1 = (Color)colorDialog1.Color;
                hue = color1.GetHue();
                //chkRojo.Enabled = false;
                chkAzul.Checked = false;
            }
            if (chkVerde.Checked)
            {
                colorDialog2.ShowDialog();
                color2 = (Color)colorDialog2.Color;
                hue2 = color2.GetHue();
                //chkVerde.Enabled = false;
                chkVerde.Checked = false;
            }
            if (chkNaranja.Checked)
            {
                colorDialog3.ShowDialog();
                color3 = (Color)colorDialog3.Color;
                hue3 = color3.GetHue();
                //chkCeleste.Enabled = false;
                chkNaranja.Checked = false;
            }
        }
        
        private void AgregarSimbolo(string simbolo)
        {
            lblCadena.Text = lblCadena.Text + simbolo.ToString();
            //cadena_simbolos.Add(simbolo);
        }

        private void CrearCadenaFinal(string simbolo)
        {
            cadena_final.Add(simbolo);

            //lblFinal.Text = lblFinal.Text + cadena_final.ElementAt(0).ToString();
            //txtMensaje.Text = txtMensaje.Text + simbolo.ToString();
        }

        private string Decodificar(string codigo)
        {
            string letra = "";
            switch (codigo)
            {
                case ".T.T.T.T.T":
                    letra = "a";
                    break;
                case ".T.T.T.T-T":
                    letra = "b";
                    break;
                case ".T.T.T-T.T":
                    letra = "c";
                    break;
                case ".T.T.T-T-T":
                    letra = "d";
                    break;
                case ".T.T-T.T.T":
                    letra = "e";
                    break;
                case ".T.T-T.T-T":
                    letra = "f";
                    break;
                case ".T.T-T-T.T":
                    letra = "g";
                    break;
                case ".T.T-T-T-T":
                    letra = "h";
                    break;
                case ".T-T.T.T.T":
                    letra = "i";
                    break;
                case ".T-T.T.T-T":
                    letra = "j";
                    break;
                case ".T-T.T-T.T":
                    letra = "k";
                    break;
                case ".T-T.T-T-T":
                    letra = "l";
                    break;
                case ".T-T-T.T.T":
                    letra = "m";
                    break;
                case ".T-T-T.T-T":
                    letra = "n";
                    break;
                case ".T-T-T-T.T":
                    letra = "ñ";
                    break;
                case ".T-T-T-T-T":
                    letra = "o";
                    break;
                case "-T.T.T.T.T":
                    letra = "p";
                    break;
                case "-T.T.T.T-T":
                    letra = "q";
                    break;
                case "-T.T.T-T.T":
                    letra = "r";
                    break;
                case "-T.T.T-T-T":
                    letra = "s";
                    break;
                case "-T.T-T.T.T":
                    letra = "t";
                    break;
                case "-T.T-T.T-T":
                    letra = "u";
                    break;
                case "-T.T-T-T.T":
                    letra = "v";
                    break;
                case "-T.T-T-T-T":
                    letra = "w";
                    break;
                case "-T-T.T.T.T":
                    letra = "x";
                    break;
                case "-T-T.T.T-T":
                    letra = "y";
                    break;
                case "-T-T.T-T.T":
                    letra = "z";
                    break;
                case "-T-T.T-T-T":
                    letra = " ";
                    break;
                case "-T-T-T.T.T":
                    letra = ".";
                    break;
                case "-T-T-T.T-T":
                    letra = ",";
                    break;
                case "-T-T-T-T-T":
                    letra = "";
                    //vspWebcam.Stop();
                    MessageBox.Show("Fin del mensaje.");
                    break;
                default:
                    break;
            }
            return letra;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cadena_final.Clear();
            lblCadena.Text = "Cadena: ";
            lblFinal.Text = "Cadena final: ";
            celeste = false;
            verde = true;
            rojo = true;
        }
    }
}
