using InventStar.InventarioWS;
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
    public partial class frmSeleccionarOC : Form
    {
        private InventarioWSClient _daoInventario;
        private ordenCompra ordenSeleccionada;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);
        public frmSeleccionarOC()
        {
            _daoInventario = new InventarioWSClient();
            ordenSeleccionada = new ordenCompra();
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = _daoInventario.listarOrdenCompraPorP(textBox1.Text);
            
        }

        public ordenCompra OrdenSeleccionada { get => ordenSeleccionada; set => ordenSeleccionada = value; }

        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0xA1, 0x2, 0);
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ordenCompra orden = (ordenCompra)dataGridView1.Rows[e.RowIndex].DataBoundItem;

            dataGridView1.Rows[e.RowIndex].Cells[0].Value = orden.proveedor.nombre;
            dataGridView1.Rows[e.RowIndex].Cells[1].Value = orden.sucursal.nombre;
            dataGridView1.Rows[e.RowIndex].Cells[2].Value = orden.fechaCompra.ToString("MM/dd/yyyy");
            dataGridView1.Rows[e.RowIndex].Cells[3].Value = orden.estado;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _daoInventario.listarOrdenCompraPorP(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ordenSeleccionada = (ordenCompra)dataGridView1.CurrentRow.DataBoundItem;
            this.DialogResult = DialogResult.OK;
        }
    }
}
