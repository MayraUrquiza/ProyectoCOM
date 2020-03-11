using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCOM
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void btnCod_Click(object sender, EventArgs e)
        {
            FormCodificador codificador = new FormCodificador();
            codificador.ShowDialog();
        }

        private void btnDecod_Click(object sender, EventArgs e)
        {
            FormDecodificador decodificador = new FormDecodificador();
            decodificador.ShowDialog();
        }
    }
}
