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
    public partial class frmModificarProducto : Form
    {
        private InventarioWSClient _daoInventario;
        private bebida _bebida;
        private comida _comida;
        private cuentaPersonal _cuentaPersonal;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);

        public frmModificarProducto(cuentaPersonal cuentaPersonal)
        {
            InitializeComponent();
            _daoInventario = new InventarioWSClient();
            cbTipo.DataSource = Enum.GetValues(typeof(tipoDeComida));
            cbTipo.DisplayMember = "ToString";
            this._cuentaPersonal = cuentaPersonal;
        }

        public frmModificarProducto(cuentaPersonal cuentaPersonal, comida comida)
        {
            InitializeComponent();
            _daoInventario = new InventarioWSClient();
            _comida = comida;
            cbTipo.DataSource = Enum.GetValues(typeof(tipoDeComida));
            cbTipo.DisplayMember = "ToString";
            label3.Text = "Segundos a calentar:";
            label5.Enabled = false;
            txtInstrucciones.Enabled = false;
            label2.Enabled = false;
            cbTamanho.Enabled = false;
            label4.Enabled = false;
            cbFrio.Enabled = false;
            rbBebida.Checked = false;
            rbComida.Checked = true;
            rbComida.Enabled = false;
            rbBebida.Enabled = false;
            label10.Enabled = false;

            #region Asignación
            txtNombre.Text = comida.nombre;
            txtDescripcion.Text = comida.descripcion;
            txtPrecio.Text = comida.precioUnitario.ToString("N2");
            nuCalorias.Value = comida.calorias;
            cbTipo.SelectedItem = comida.tipo;

            nuTiempo.Value = comida.segundosACalentar;
            #endregion

            this._cuentaPersonal = cuentaPersonal;
        }

        public frmModificarProducto(cuentaPersonal cuentaPersonal, bebida bebida)
        {
            InitializeComponent();
            _daoInventario = new InventarioWSClient();
            _bebida = bebida;
            

            cbTipo.DataSource = Enum.GetValues(typeof(tipoDeBebida));
            cbTipo.DisplayMember = "ToString";
            cbTamanho.DataSource = Enum.GetValues(typeof(tamanhoBebida));
            cbTamanho.DisplayMember = "ToString";
            label3.Text = "Tiempo de preparación:";
            label5.Enabled = true;
            txtInstrucciones.Enabled = true;
            label2.Enabled = true;
            cbTamanho.Enabled = true;
            label4.Enabled = true;
            cbFrio.Enabled = true;

            rbComida.Enabled = false;
            rbBebida.Enabled = false;
            label10.Enabled = false;

            rbComida.Checked = false;
            rbBebida.Checked = true;

            #region Asignación
            txtNombre.Text = bebida.nombre;
            txtDescripcion.Text = bebida.descripcion;
            txtPrecio.Text = bebida.precioUnitario.ToString("N2");
            nuCalorias.Value = bebida.calorias;
            cbTipo.SelectedItem = bebida.tipo;
            if (bebida.esFria)
                cbFrio.Checked = true;
            cbTamanho.SelectedItem = bebida.tamanho;
            txtInstrucciones.Text = bebida.instrucciones;
            nuTiempo.Value = bebida.tiempoPreparacion;
            rbBebida.Checked = true;
            #endregion

            this._cuentaPersonal = cuentaPersonal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int resultado = 0;
            if (rbBebida.Checked)
            {
                _bebida.nombre = txtNombre.Text;
                _bebida.descripcion = txtDescripcion.Text;
                _bebida.precioUnitario = Double.Parse(txtPrecio.Text);
                _bebida.cantidad = 0;
                _bebida.unidadMedida = "";
                _bebida.calorias = (int)nuCalorias.Value;
                _bebida.tipo = (tipoDeBebida)cbTipo.SelectedItem;
                _bebida.tipoSpecified = true;
                _bebida.esFria = cbFrio.Checked ? true : false;
                _bebida.tamanho = (tamanhoBebida)cbTamanho.SelectedItem;
                _bebida.tamanhoSpecified = true;
                _bebida.instrucciones = txtInstrucciones.Text;
                _bebida.tiempoPreparacion = (int)nuTiempo.Value;

                resultado = _daoInventario.modificarBebida(_bebida);
            }
            else if (rbComida.Checked)
            {
                _comida.nombre = txtNombre.Text;
                _comida.descripcion = txtDescripcion.Text;
                _comida.precioUnitario = Double.Parse(txtPrecio.Text);
                _comida.cantidad = 0;
                _comida.unidadMedida = "";
                _comida.calorias = (int)nuCalorias.Value;
                _comida.tipo = (tipoDeComida)cbTipo.SelectedItem;
                _comida.tipoSpecified = true;
                _comida.segundosACalentar = (int)nuTiempo.Value;

                resultado = _daoInventario.modificarComida(_comida);
            }

            if (resultado != 0)
            {
                MessageBox.Show("Se ha registrado correctamente",
                    "Mensaje de éxito", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error con el registro",
                    "Mensaje de éxito", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmProductos formProd = new frmProductos(_cuentaPersonal);
            this.Hide();
            formProd.ShowDialog();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0xA1, 0x2, 0);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cbFrio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void nuTiempo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void nuCalorias_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cbTamanho_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
