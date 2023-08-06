using InventStar.ClientesWS;
using InventStar.PersonalWS;
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

using cliWS = InventStar.ClientesWS;

namespace InventStar
{
    public partial class frmBusquedaPersonal : Form
    {
        
        private PersonalWSClient _daoPersonal;
        private personal _personalSeleccionado;
        private ordenVenta _ordenVenta;
        private cuentaPersonal _cuentaPersonal;
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);

        public frmBusquedaPersonal(ordenVenta ordenVenta,cuentaPersonal cuentaPersonal)
        {
            InitializeComponent();
            _daoPersonal = new PersonalWSClient();
            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.DataSource = _daoPersonal.listarPersonal();
            _ordenVenta = ordenVenta;
            this._cuentaPersonal = cuentaPersonal;
        }
        public personal PersonalSeleccionado { get => _personalSeleccionado; set => _personalSeleccionado = value; }

        private void dgvClientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            personal personalGenerico = (personal)dgvClientes.Rows[e.RowIndex].DataBoundItem;
            dgvClientes.Rows[e.RowIndex].
                Cells[0].Value = personalGenerico.nombres+" "+ personalGenerico.apellidoPat;
            dgvClientes.Rows[e.RowIndex].
                Cells[1].Value = personalGenerico.numDocumento;
            dgvClientes.Rows[e.RowIndex].
                Cells[2].Value = personalGenerico.domicilio;
            dgvClientes.Rows[e.RowIndex].
                Cells[3].Value = personalGenerico.fechaRegistro.ToShortDateString();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmDetalleOrdenVenta formHome = new frmDetalleOrdenVenta(_ordenVenta, _cuentaPersonal);
            this.Hide();
            formHome.Show();
        }

        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0xA1, 0x2, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow != null)
            {
                _personalSeleccionado = (personal)dgvClientes.CurrentRow.DataBoundItem;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void pnlTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblPanel_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
