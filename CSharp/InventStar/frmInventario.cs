using InventStar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using InventStar.PersonalWS;
using InventStar.InventarioWS;

namespace InventstarInventario
{
    public partial class frmInventario : Form
    {
        private cuentaPersonal _cuentaPersonal;
        private PersonalWSClient daoPersonal;
        private InventarioWSClient _daoInventario;
        private insumoPerecible insumoSeleccionado;
        private int result;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);
        public frmInventario(cuentaPersonal cuentaPersonal)
        {
            _daoInventario = new InventarioWSClient();
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = _daoInventario.listarTodosInsumos();
            daoPersonal = new PersonalWSClient();
            this._cuentaPersonal = cuentaPersonal;
        }

        public insumoPerecible InsumoSeleccionado { get => insumoSeleccionado; set => insumoSeleccionado = value; }

        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0xA1, 0x2, 0);
        }

        private void frmInventario_Load(object sender, EventArgs e)
        {

        }

        private void frmInventario_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            int resultado1 = daoPersonal.verificarCuentaPersonalConPermisos(_cuentaPersonal);
            if (resultado1 != 0)
            {
                frmPaginaPrincipal1 formHome1 = new frmPaginaPrincipal1(_cuentaPersonal);
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
                formHome1.LblUsuarioActual.Text = _cuentaPersonal.username.ToUpper();
                formHome1.Show();
            }
            else
            {
                frmPaginaPrincipal formHome = new frmPaginaPrincipal(_cuentaPersonal);
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
                formHome.LblUsuarioActual.Text = _cuentaPersonal.username.ToUpper();
                formHome.Show();
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmNuevoArticulo formArt = new frmNuevoArticulo(_cuentaPersonal);
            if (formArt.ShowDialog() == DialogResult.OK)
            {
                result = _daoInventario.insertarInsumoPerecible(formArt.InsumoSeleccionado);
                if (result != 0)
                {
                    dataGridView1.DataSource = _daoInventario.listarTodosInsumos();
                    MessageBox.Show("Se ha insertado correctamente", "Mensaje de Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error al momento de insertar", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            //this.Hide();
            //formArt.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            insumoPerecible insu = (insumoPerecible)dataGridView1.Rows[e.RowIndex].DataBoundItem;

            if (insu.comida == null)
            {
                dataGridView1.Rows[e.RowIndex].Cells[0].Value = false;
            }
            else
            {
                dataGridView1.Rows[e.RowIndex].Cells[0].Value = true;
            }
            dataGridView1.Rows[e.RowIndex].Cells[1].Value = insu.nombre;
            dataGridView1.Rows[e.RowIndex].Cells[2].Value = insu.cantidad;
            if (insu.comida == null)
            {
                dataGridView1.Rows[e.RowIndex].Cells[3].Value = insu.ingrediente.unidadMedida;
            }
            else
            {
                dataGridView1.Rows[e.RowIndex].Cells[3].Value = insu.comida.unidadMedida;
            }
            dataGridView1.Rows[e.RowIndex].Cells[4].Value = insu.fechaIngeso.ToString("MM/dd/yyyy"); ;
            dataGridView1.Rows[e.RowIndex].Cells[5].Value = insu.fechaVencimiento.ToString("MM/dd/yyyy"); ;
            //dataGridView1.Rows[e.RowIndex].Cells[5].Value = DateTime.Now;

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //insumoSeleccionado = new insumoPerecible();
            insumoSeleccionado = (insumoPerecible)dataGridView1.CurrentRow.DataBoundItem;
            frmInventarioActualizar formActu = new frmInventarioActualizar(_cuentaPersonal, insumoSeleccionado);
            if (formActu.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.DataSource = _daoInventario.listarTodosInsumos();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmMermas frmMer= new frmMermas(_cuentaPersonal);
            frmMer.ShowDialog();
            this.Hide();
        }
    }
}
