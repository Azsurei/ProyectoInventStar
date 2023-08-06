using InventStar.PersonalWS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventStar
{
    public partial class frmGuias : Form
    {
        private cuentaPersonal _cuentaUsuario;
        private PersonalWSClient daoPersonal;
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);
        public frmGuias(cuentaPersonal cuentaUsuario)
        {
            InitializeComponent();
            InitializeFontCollection();
            this._cuentaUsuario = cuentaUsuario;
            daoPersonal = new PersonalWSClient();
        }

        private void InitializeFontCollection()
        {
            #region PrivateFonts
            PrivateFontCollection pfc_regular = new PrivateFontCollection();
            byte[] prop_regular = Properties.Resources.SoDoSans_Regular;
            PrivateFontCollection pfc_bold = new PrivateFontCollection();
            byte[] prop_bold = Properties.Resources.SoDoSans_Bold;
            PrivateFontCollection pfc_black = new PrivateFontCollection();
            byte[] prop_black = Properties.Resources.SoDoSans_Black;
            #endregion

            InitializeFonts(pfc_regular, prop_regular);
            InitializeFonts(pfc_bold, prop_bold);
            InitializeFonts(pfc_black, prop_black);

            lblTitulo1.Font = new Font(pfc_bold.Families[0], lblTitulo1.Font.Size);
            lblTitulo2.Font = new Font(pfc_bold.Families[0], lblTitulo2.Font.Size);
            lblMaterial.Font = new Font(pfc_regular.Families[0], lblMaterial.Font.Size);
            lblProgreso.Font = new Font(pfc_regular.Families[0], lblProgreso.Font.Size);
        }

        private void InitializeFonts(PrivateFontCollection pfc, byte[] prop)
        {
            int fontLength = prop.Length;
            byte[] fontdata = prop;
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontdata, 0, data, fontLength);
            pfc.AddMemoryFont(data, fontLength);
        }

        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0xA1, 0x2, 0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmVideos formVid = new frmVideos(_cuentaUsuario);
            this.Hide();
            formVid.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            frmArticulos formArt = new frmArticulos(_cuentaUsuario);
            this.Hide();
            formArt.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
           frmProgreso formProg = new frmProgreso();
            this.Hide();
            formProg.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            int resultado1 = daoPersonal.verificarCuentaPersonalConPermisos(_cuentaUsuario);
            if (resultado1 != 0)
            {
                frmPaginaPrincipal1 formHome1 = new frmPaginaPrincipal1(_cuentaUsuario);
                this.Hide();
                formHome1.LblVentas.Cursor = System.Windows.Forms.Cursors.Hand;
                formHome1.LblClientes.Cursor = System.Windows.Forms.Cursors.Hand;
                formHome1.LblInventario.Cursor = System.Windows.Forms.Cursors.Hand;
                formHome1.LblGuias.Cursor = System.Windows.Forms.Cursors.Hand;
                formHome1.PbVentas.Cursor = System.Windows.Forms.Cursors.Hand;
                formHome1.PbClientes.Cursor = System.Windows.Forms.Cursors.Hand;
                formHome1.PbInventario.Cursor = System.Windows.Forms.Cursors.Hand;
                formHome1.PbGuias.Cursor = System.Windows.Forms.Cursors.Hand;
                formHome1.LblUsuarioActual.Visible = true;
                formHome1.LblInicioSesion.Visible = false;
                formHome1.PbVentasEnabled.Visible = true;
                formHome1.PbClientesEnabled.Visible = true;
                formHome1.PbInventarioEnabled.Visible = true;
                formHome1.PbGuiasEnabled.Visible = true;
                formHome1.PB6Enabled.Visible = true;
                formHome1.PbPermisosEnabled.Visible = true;
                formHome1.LblUsuarioActual.Text = _cuentaUsuario.username.ToUpper();
                formHome1.Show();
            }
            else
            {
                frmPaginaPrincipal formHome = new frmPaginaPrincipal(_cuentaUsuario);
                this.Hide();
                formHome.LblVentas.Cursor = System.Windows.Forms.Cursors.Hand;
                formHome.LblClientes.Cursor = System.Windows.Forms.Cursors.Hand;
                formHome.LblInventario.Cursor = System.Windows.Forms.Cursors.Hand;
                formHome.LblGuias.Cursor = System.Windows.Forms.Cursors.Hand;
                formHome.PbVentas.Cursor = System.Windows.Forms.Cursors.Hand;
                formHome.PbClientes.Cursor = System.Windows.Forms.Cursors.Hand;
                formHome.PbInventario.Cursor = System.Windows.Forms.Cursors.Hand;
                formHome.PbGuias.Cursor = System.Windows.Forms.Cursors.Hand;
                formHome.LblUsuarioActual.Visible = true;
                formHome.LblInicioSesion.Visible = false;
                formHome.PbVentasEnabled.Visible = true;
                formHome.PbClientesEnabled.Visible = true;
                formHome.PbInventarioEnabled.Visible = true;
                formHome.PbGuiasEnabled.Visible = true;
                formHome.PB6Enabled.Visible = true;
                formHome.PBProductosEnabled.Visible = true;
                formHome.LblUsuarioActual.Text = _cuentaUsuario.username.ToUpper();
                formHome.Show();
            }
        }
    }
}
