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
    public partial class frmBusquedClientes : Form
    {
        
        private ClientesWSClient _daoClientes;
        private cliWS.cliente _clienteSeleccionado;
        private ordenVenta _ordenVenta;
        private cuentaPersonal _cuentaPersonal;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);

        public frmBusquedClientes(ordenVenta ordenVenta, cuentaPersonal cuentaPersonal)
        {
            InitializeComponent();
            _daoClientes = new ClientesWSClient();
            dgvClientes.AutoGenerateColumns = false;
            _ordenVenta = ordenVenta;
            _cuentaPersonal = cuentaPersonal;
        }
        public cliWS.cliente ClienteSeleccionado { get => _clienteSeleccionado; set => _clienteSeleccionado = value; }

        private void dgvClientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            cliWS.cliente clienteGenerico = (cliWS.cliente)dgvClientes.Rows[e.RowIndex].DataBoundItem;
            dgvClientes.Rows[e.RowIndex].
                Cells[0].Value = clienteGenerico.nombres+" "+clienteGenerico.apellidoPat;
            dgvClientes.Rows[e.RowIndex].
                Cells[1].Value = clienteGenerico.numDocumento;
            dgvClientes.Rows[e.RowIndex].
                Cells[2].Value = clienteGenerico.domicilio;
            dgvClientes.Rows[e.RowIndex].
                Cells[3].Value = clienteGenerico.fechaRegistro.ToShortDateString();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmDetalleOrdenVenta formCli = new frmDetalleOrdenVenta(_ordenVenta, _cuentaPersonal);
            this.Hide();
            formCli.ShowDialog();
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
                _clienteSeleccionado = (cliWS.cliente)dgvClientes.CurrentRow.DataBoundItem;
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
            dgvClientes.DataSource = _daoClientes.listarTodasClientesPorNombre_Apellido_DNI(textBox1.Text);
        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
