using InventStar.InventarioWS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventStar
{
    public partial class frmSeleccionarCI : Form
    {
        private InventarioWSClient _daoInventario;
        private comida comidaSeleccionada;
        private ingrediente ingredienteSeleccionado;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);

        public frmSeleccionarCI()
        {
            _daoInventario = new InventarioWSClient();
            comidaSeleccionada = new comida();
            ingredienteSeleccionado = new ingrediente();
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AutoGenerateColumns = false;
            dataGridView1.DataSource = _daoInventario.listarComidasXNombre(textBox1.Text);
            dataGridView2.DataSource = _daoInventario.listarIngredientesXNombre(textBox3.Text);
        }

        public int GetFlag()
        {
            return tabControl1.SelectedIndex;
        }

        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0xA1, 0x2, 0);
        }


        public comida ComidaSeleccionada { get => comidaSeleccionada; set => comidaSeleccionada = value; }
        public ingrediente IngredienteSeleccionado { get => ingredienteSeleccionado; set => ingredienteSeleccionado = value; }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            comida comi = (comida)dataGridView1.Rows[e.RowIndex].DataBoundItem;

            dataGridView1.Rows[e.RowIndex].Cells[0].Value = comi.idItemVenta;
            dataGridView1.Rows[e.RowIndex].Cells[1].Value = comi.nombre;
            dataGridView1.Rows[e.RowIndex].Cells[2].Value = comi.unidadMedida;
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ingrediente ingre = (ingrediente)dataGridView2.Rows[e.RowIndex].DataBoundItem;

            dataGridView2.Rows[e.RowIndex].Cells[0].Value = ingre.idIngrediente;
            dataGridView2.Rows[e.RowIndex].Cells[1].Value = ingre.nombre;
            dataGridView2.Rows[e.RowIndex].Cells[2].Value = ingre.unidadMedida;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _daoInventario.listarComidasXNombre(textBox1.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = _daoInventario.listarIngredientesXNombre(textBox3.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && tabControl1.SelectedIndex == 0)
            {
                comidaSeleccionada = (comida)dataGridView1.CurrentRow.DataBoundItem;
            }
            else if (dataGridView2.CurrentRow != null && tabControl1.SelectedIndex == 1)
            {
                ingredienteSeleccionado = (ingrediente)dataGridView2.CurrentRow.DataBoundItem;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
