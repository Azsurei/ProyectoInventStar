using InventStar.InventarioWS;
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

namespace InventStar
{
    public partial class frmProductos : Form
    {
        private InventarioWSClient _daoInventario;
        private cuentaPersonal _cuentaPersonal;
        private PersonalWSClient daoPersonal;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);
        public frmProductos(cuentaPersonal cuentaPersonal)
        {
            InitializeComponent();
            _daoInventario = new InventarioWSClient();
            daoPersonal = new PersonalWSClient();
            bebida[] bebidas = _daoInventario.listarTodasBebidas();
            comida[] comidas = _daoInventario.listarTodasComidas();
            List<object> list = new List<object>();
            list.AddRange(bebidas);
            list.AddRange(comidas);
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.DataSource = list;
            this._cuentaPersonal = cuentaPersonal;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmAgregarProducto formAgregarProd = new frmAgregarProducto(_cuentaPersonal);
            this.Hide();
            formAgregarProd.ShowDialog();
        }

        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0xA1, 0x2, 0);
        }

        private void dgvProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvProductos.Rows[e.RowIndex].DataBoundItem is bebida bebidaGen)
            {
                dgvProductos.Rows[e.RowIndex].Cells[0].Value = bebidaGen.nombre;
                dgvProductos.Rows[e.RowIndex].Cells[1].Value = bebidaGen.tipo.ToString();
                dgvProductos.Rows[e.RowIndex].Cells[2].Value = bebidaGen.precioUnitario.ToString("N2");
            }
            else if (dgvProductos.Rows[e.RowIndex].DataBoundItem is comida comidaGen)
            {
                dgvProductos.Rows[e.RowIndex].Cells[0].Value = comidaGen.nombre;
                dgvProductos.Rows[e.RowIndex].Cells[1].Value = comidaGen.tipo.ToString();
                dgvProductos.Rows[e.RowIndex].Cells[2].Value = comidaGen.precioUnitario.ToString("N2");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            object filaActual = dgvProductos.CurrentRow.DataBoundItem;

            if(filaActual is bebida bebidaSeleccionada)
            {
                frmModificarProducto formModProd = new frmModificarProducto(_cuentaPersonal, bebidaSeleccionada);
                this.Hide();
                formModProd.ShowDialog();
            }
            else if(filaActual is comida comidaSeleccionada)
            {
                frmModificarProducto formModProd = new frmModificarProducto(_cuentaPersonal, comidaSeleccionada);
                this.Hide();
                formModProd.ShowDialog();
            }
            else
            {
                MessageBox.Show("Tiene que seleccionar una fila para modificar",
                    "Mensaje de éxito", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            
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
    }
}
