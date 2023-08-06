using InventStar.ClientesWS;
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

using cliWS = InventStar.ClientesWS;

namespace InventStar
{
    public partial class frmProveedores : Form
    {
        private InventarioWSClient _daoProveedores;
        private proveedor _proveedorSeleccionado;
        private cuentaPersonal _cuentaPersonal;
        private PersonalWSClient daoPersonal;

        public proveedor ProveedorSeleccionado { get => _proveedorSeleccionado; set => _proveedorSeleccionado = value; }

        //private cliWS.cliente _clienteSeleccionadoEliminar;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);

        public frmProveedores(cuentaPersonal cuentaPersonal)
        {
            InitializeComponent();
            _daoProveedores = new InventarioWSClient();
            daoPersonal = new PersonalWSClient();
            dgvProveedores.AutoGenerateColumns = false;
            dgvProveedores.DataSource = _daoProveedores.listarProveedor();
            _cuentaPersonal = cuentaPersonal;
        }


        private void dgvProveedores_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            proveedor proveedorGenerico = (proveedor)dgvProveedores.Rows[e.RowIndex].DataBoundItem;
            dgvProveedores.Rows[e.RowIndex].
                Cells[0].Value = proveedorGenerico.RUC;
            if (proveedorGenerico.nombre == null)
            {
                dgvProveedores.Rows[e.RowIndex].Cells[1].Value = "No tiene";
            }
            else
            {
                dgvProveedores.Rows[e.RowIndex].
                Cells[1].Value = proveedorGenerico.nombre;
            }
            dgvProveedores.Rows[e.RowIndex].
                Cells[2].Value = proveedorGenerico.razonSocial;
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

        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0xA1, 0x2, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmDetalleProveedor formDet = new frmDetalleProveedor(_cuentaPersonal);
            this.Hide();
            formDet.ShowDialog();
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
            //dgvProveedores.DataSource = _daoProveedores.listarTodasClientesPorNombre_Apellido_DNI(textBox1.Text);
        }

        private void dgvProveedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _proveedorSeleccionado = (proveedor)dgvProveedores.CurrentRow.DataBoundItem;
            frmDetalleProveedor formDet = new frmDetalleProveedor(_proveedorSeleccionado, _cuentaPersonal);
            this.Hide();
            formDet.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _proveedorSeleccionado = (proveedor)dgvProveedores.CurrentRow.DataBoundItem;
            int resultado = _daoProveedores.eliminarProveedor(_proveedorSeleccionado.idProveedor);

            if (resultado != 0)
            {
                MessageBox.Show("Se ha eliminado correctamente",
                                       "Mensaje de éxito", MessageBoxButtons.OK,
                                                          MessageBoxIcon.Information);
                dgvProveedores.DataSource = _daoProveedores.listarProveedor();
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error con la eliminación",
                                       "Mensaje de éxito", MessageBoxButtons.OK,
                                                          MessageBoxIcon.Error);
            }
        }

        private void dgvProveedores_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

    }
}
