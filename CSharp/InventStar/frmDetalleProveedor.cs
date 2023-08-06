using InventStar.ClientesWS;
using InventStar.InventarioWS;
using InventStar.PersonalWS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventStar
{
    public partial class frmDetalleProveedor : Form
    {
        private InventarioWSClient _daoProveedores;
        //private contacto _contactoSeleccionado;
        private proveedor _proveedorSeleccionado;
        private InventarioWSClient _daoOrdenCompra;
        private ordenCompra _ordenSeleccionada;
        private cuentaPersonal _cuentaPersonal;
        private contacto _contacto;
        private bool agregar;

        public proveedor ProveedorSeleccionado { get => _proveedorSeleccionado; set => _proveedorSeleccionado = value; }
        public ordenCompra OrdenSeleccionada { get => _ordenSeleccionada; set => _ordenSeleccionada = value; }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);

        public frmDetalleProveedor(cuentaPersonal cuentaPersonal)
        {
            InitializeComponent();
            _daoProveedores = new InventarioWSClient();
            _daoOrdenCompra = new InventarioWSClient();
            _ordenSeleccionada = new ordenCompra();
            txtIDCompra.Enabled = false;
            _proveedorSeleccionado = new proveedor();
            _contacto = new contacto();
            agregar = true;
        }

        public frmDetalleProveedor(proveedor _proveedorSeleccionado,cuentaPersonal cuentaPersonal)
        {
            InitializeComponent();
            _daoProveedores = new InventarioWSClient();
            _daoOrdenCompra = new InventarioWSClient();
            _ordenSeleccionada = new ordenCompra();
            this._cuentaPersonal = cuentaPersonal;
            this.ProveedorSeleccionado = _proveedorSeleccionado;
            _contacto = _daoProveedores.obtenerContactoPorIdProveedor(_proveedorSeleccionado.idProveedor);
            txtIDCompra.Enabled = false;
            txtRUC.Text = _proveedorSeleccionado.RUC;
            txtRRSS.Text = _proveedorSeleccionado.razonSocial;
            textBox1.Text = _contacto.nombres;
            textBox2.Text = _contacto.apellidoPat;
            textBox7.Text = _contacto.apellidoMat;
            textBox6.Text = _contacto.numDocumento;
            textBox4.Text = _contacto.telefono1;
            textBox8.Text = _contacto.telefono2;
            textBox9.Text = _contacto.email;
            textBox5.Text = _contacto.domicilio;
            dateTimePicker1.Value = _contacto.fechaRegistro == DateTime.MinValue ? DateTime.Now : _contacto.fechaRegistro;
            dateTimePicker2.Value = _contacto.fechaCumpleanhos == DateTime.MinValue ? DateTime.Now : _contacto.fechaCumpleanhos;
            textBox3.Text = _contacto.puesto;

            if (_proveedorSeleccionado.nombre == null)
            {
                txtNombre.Text = "No tiene";
            }
            else
            {
                txtNombre.Text = _proveedorSeleccionado.nombre;
            }
            txtDireccion.Text = _proveedorSeleccionado.direccion;
            txtTelefono.Text = _proveedorSeleccionado.telefono;
            txtEmail.Text = _proveedorSeleccionado.email;
            dgvOrdenes.AutoGenerateColumns = false;
            dgvOrdenes.DataSource = _daoOrdenCompra.listarOrdenCompraPorProveedor(_proveedorSeleccionado);
            agregar = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmProveedores formPro = new frmProveedores(_cuentaPersonal);
            this.Hide();
            formPro.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int resultado = 0;
            _proveedorSeleccionado.RUC = txtRUC.Text;
            _proveedorSeleccionado.nombre = txtNombre.Text;
            _proveedorSeleccionado.razonSocial = txtRRSS.Text;
            _proveedorSeleccionado.direccion = txtDireccion.Text;
            _proveedorSeleccionado.telefono = txtTelefono.Text;
            _proveedorSeleccionado.email = txtEmail.Text;

            _contacto.nombres = textBox1.Text;
            _contacto.apellidoPat = textBox2.Text;
            _contacto.apellidoMat = textBox7.Text;
            _contacto.numDocumento = textBox6.Text;
            _contacto.telefono1 = textBox4.Text;
            _contacto.telefono2 = textBox8.Text;
            _contacto.email = textBox9.Text;
            _contacto.domicilio = textBox5.Text;
            _contacto.fechaRegistro = dateTimePicker1.Value;
            _contacto.fechaRegistroSpecified = true;
            _contacto.fechaCumpleanhos = dateTimePicker2.Value;
            _contacto.fechaCumpleanhosSpecified = true;
            _contacto.puesto = textBox3.Text;
            if (!agregar)
                resultado = _daoProveedores.modificarProveedor(_proveedorSeleccionado, _contacto);
            else
                resultado = _daoProveedores.insertarProveedor(_proveedorSeleccionado, _contacto);

            if (resultado != 0)
            {
                MessageBox.Show("Se ha modificado correctamente",
                                       "Mensaje de éxito", MessageBoxButtons.OK,
                                                          MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error con la modificación",
                                       "Mensaje de éxito", MessageBoxButtons.OK,
                                                          MessageBoxIcon.Error);
            }
        }

        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0xA1, 0x2, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dgvOrdenes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ordenCompra ordenGenerica = (ordenCompra)dgvOrdenes.Rows[e.RowIndex].DataBoundItem;
            if(ordenGenerica == null)
            {
                return;
            }
            
            dgvOrdenes.Rows[e.RowIndex].Cells[0].Value = ordenGenerica.idCompra;
            dgvOrdenes.Rows[e.RowIndex].Cells[1].Value = ordenGenerica.fechaCompra;
            dgvOrdenes.Rows[e.RowIndex].Cells[2].Value = ordenGenerica.estado;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _ordenSeleccionada.fechaCompra = dtpFechaCompra.Value;
            _ordenSeleccionada.fechaCompraSpecified = true;
            _ordenSeleccionada.estado = txtEstado.Text;
            _ordenSeleccionada.proveedor = new proveedor();
            _ordenSeleccionada.proveedor = _proveedorSeleccionado;
            _ordenSeleccionada.sucursal = new InventarioWS.sucursal();
            _ordenSeleccionada.sucursal.id_sucursal = 1;
            int resultado = _daoOrdenCompra.insertarOrdenCompra(_ordenSeleccionada);
            if (resultado != 0)
            {
                MessageBox.Show("Se ha registrado correctamente",
                    "Mensaje de éxito", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                _ordenSeleccionada.idCompra = resultado;
                txtIDCompra.Text = resultado.ToString();
                dgvOrdenes.AutoGenerateColumns = false;
                dgvOrdenes.DataSource = _daoProveedores.listarOrdenCompraPorProveedor(_proveedorSeleccionado);
                dgvOrdenes.Refresh();
                dgvOrdenes.Update();
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error con el registro",
                    "Mensaje de error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int _codigoEliminar = _ordenSeleccionada.idCompra;
            int resultado = _daoOrdenCompra.eliminarOrdenCompra(_codigoEliminar);
            if (resultado != 0)
            {
                MessageBox.Show("Se ha eliminado la orden de compra",
                    "Mensaje de éxito", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    txtIDCompra.Text = " ";
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error con la eliminación",
                    "Mensaje de error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvOrdenes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OrdenSeleccionada = (ordenCompra)dgvOrdenes.CurrentRow.DataBoundItem;
        }

        private void dgvOrdenes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OrdenSeleccionada = (ordenCompra)dgvOrdenes.CurrentRow.DataBoundItem;
        }
    }
}
