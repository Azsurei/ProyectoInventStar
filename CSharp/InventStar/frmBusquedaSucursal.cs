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
    public partial class frmBusquedaSucursal : Form
    {
        private PersonalWSClient _daoSucursal;
        private sucursal _sucursalSeleccionado;
        private ordenVenta _ordenVenta;
        private cuentaPersonal _cuentaPersonal;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);

        public frmBusquedaSucursal(ordenVenta ordenVenta, cuentaPersonal cuentaPersonal)
        {
            InitializeComponent();
            _daoSucursal = new PersonalWSClient();
            dgvSucursales.AutoGenerateColumns = false;
            _ordenVenta = ordenVenta;
            _cuentaPersonal = cuentaPersonal;
        }
        public sucursal SucursalSeleccionado { get => _sucursalSeleccionado; set => _sucursalSeleccionado = value; }

        private void dgvSucursal_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            sucursal sucursalGenerico = (sucursal)dgvSucursales.Rows[e.RowIndex].DataBoundItem;
            dgvSucursales.Rows[e.RowIndex].
                Cells[0].Value = sucursalGenerico.nombre;
            dgvSucursales.Rows[e.RowIndex].
                Cells[1].Value = sucursalGenerico.aforo;
            dgvSucursales.Rows[e.RowIndex].
                Cells[2].Value = sucursalGenerico.telefono;
            dgvSucursales.Rows[e.RowIndex].
                Cells[3].Value = sucursalGenerico.email;
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmDetalleOrdenVenta fromPerm = new frmDetalleOrdenVenta(_ordenVenta, _cuentaPersonal);
            this.Hide();
            fromPerm.Show();
        }

        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0xA1, 0x2, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvSucursales.CurrentRow != null)
            {
                _sucursalSeleccionado = (sucursal)dgvSucursales.CurrentRow.DataBoundItem;
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
            dgvSucursales.DataSource = _daoSucursal.listarTodosSucursalesPorNombre(textBox1.Text);
        }



        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void dgvSucursales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }
    }
}
