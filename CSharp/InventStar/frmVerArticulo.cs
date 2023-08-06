using InventStar.PersonalWS;
using java.security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventStar
{
    public partial class frmVerArticulo : Form
    {
        private cuentaPersonal _cuentaPersonal;
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);

        public frmVerArticulo()
        {
            InitializeComponent();
        }

        public frmVerArticulo(articulo _articulo,cuentaPersonal cuentaPersonal)
        {
            InitializeComponent();
            label1.Text = _articulo.titulo.ToUpper();
            txtContenido.Text = _articulo.contenido;
            this._cuentaPersonal = cuentaPersonal;
        }

        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0xA1, 0x2, 0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmArticulos formArt = new frmArticulos(_cuentaPersonal);
            this.Hide();
            formArt.ShowDialog();
        }
    }
}
