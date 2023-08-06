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
    public partial class frmAlimentos : Form
    {
        private InventarioWSClient daoComida;
        private BindingList<comida> listaComidas;
        private comida _comida;
        private ordenVenta _ordenVenta;
        private PersonalWSClient daoOrdenVenta;
        private lineaOrdenVenta lineaSeleccionada;
        private lineaOrdenVenta _linea;
        private PersonalWSClient daoLinea;
        private cuentaPersonal _cuentaPersonal;
        private PersonalWSClient daoPersonal;

        private double subtotal, descuentos, impuestos, total, recargo;
        DateTime fechaActual = DateTime.Now;
        DateTime horaEspecifica = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 13, 30, 45);

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);
        public frmAlimentos(cuentaPersonal cuentaPersonal)
        {
            InitializeComponent();
            daoComida = new InventarioWSClient();
            daoLinea = new PersonalWSClient();
            daoOrdenVenta = new PersonalWSClient();
            daoPersonal = new PersonalWSClient();

            this._cuentaPersonal = cuentaPersonal;

            _linea = new lineaOrdenVenta();
            _comida = new comida();
            _ordenVenta = new ordenVenta();
            subtotal = 0; descuentos = 0;
            impuestos = 0; recargo = 0;

            //lineas = new BindingList<lineaOrdenVenta>();
            comida[] comidas = daoComida.listarTodasComidas();
            lineaOrdenVenta[] lineas = daoLinea.listarLineasOrdenVenta();
            listaComidas = new BindingList<comida>(comidas);
            if (lineas != null)
            {
                for (int i = 0; i < lineas.Length; i++)
                {
                    subtotal += lineas[i].subtotal;
                    impuestos = 1.07;
                    recargo = 0.93;
                }
            }
            total = subtotal + descuentos + impuestos + recargo;
            textBox1.Text = subtotal.ToString();
            textBox2.Text = descuentos.ToString();
            textBox3.Text = impuestos.ToString();
            textBox4.Text = recargo.ToString();
            textBox5.Text = total.ToString();
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.DataSource = lineas;
        }

        public lineaOrdenVenta LineaSeleccionada { get => lineaSeleccionada; set => lineaSeleccionada = value; }

        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0xA1, 0x2, 0);
        }

        private void dgvProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            lineaOrdenVenta lineaGenerico = (lineaOrdenVenta)dgvProductos.Rows[e.RowIndex].DataBoundItem;
            if (lineaGenerico != null)
            {
                dgvProductos.Rows[e.RowIndex].
                Cells[0].Value = lineaGenerico.item.nombre;
                dgvProductos.Rows[e.RowIndex].
                    Cells[1].Value = lineaGenerico.cantidad;
            }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            _ordenVenta.fecha = fechaActual;
            _ordenVenta.fechaSpecified = true;
            _ordenVenta.horaVenta = fechaActual.ToString("hh:mm");
            _ordenVenta.horaFinPedido = horaEspecifica.ToString("hh:mm");
            _ordenVenta.tipo = tipoDeVenta.Local;
            _ordenVenta.tipoSpecified = true;
            _ordenVenta.estado = "Activo";
            _ordenVenta.total = 0;
            _ordenVenta.lineas = daoLinea.listarLineasOrdenVenta();
            for (int i = 0; i < _ordenVenta.lineas.Length; i++)
            {
                daoLinea.eliminarLinea(_ordenVenta.lineas[i]);
            }
            frmDetalleOrdenVenta formOrden = new frmDetalleOrdenVenta(_ordenVenta, _cuentaPersonal);
            this.Hide();
            formOrden.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _linea.cantidad = 1;
            _linea.subtotal = _comida.precioUnitario;
            _linea.item = new PersonalWS.itemVenta();
            _linea.item.idItemVenta = _comida.idItemVenta;
            _linea.item.nombre = _comida.nombre;
            _linea.item.descripcion = _comida.descripcion;
            _linea.item.precioUnitario = _comida.precioUnitario;
            if ((Int32.Parse(textBox5.Text)) == 0)
            {

                impuestos = 1.07;
                recargo = 0.93;

            }
            int resultado = daoLinea.insertarLineaOrdenVenta(_linea);
            if (resultado != 0)
            {
                MessageBox.Show("Se ha agrega la linea ",
                    "Mensaje de éxito", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                dgvProductos.DataSource = daoLinea.listarLineasOrdenVenta();
                subtotal += _linea.subtotal;
                total = subtotal + descuentos + impuestos + recargo;
                textBox1.Text = subtotal.ToString();
                textBox2.Text = descuentos.ToString();
                textBox3.Text = impuestos.ToString();
                textBox4.Text = recargo.ToString();
                textBox5.Text = total.ToString();
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error con la agregación",
                    "Mensaje de éxito", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lineaSeleccionada = (lineaOrdenVenta)dgvProductos.CurrentRow.DataBoundItem;
            lineaSeleccionada.cantidad += 1;
            lineaSeleccionada.subtotal += lineaSeleccionada.item.precioUnitario;
            int resultado = daoLinea.modificarLinea(lineaSeleccionada);
            if (resultado != 0)
            {
                MessageBox.Show("Se ha aumentado la cantidad",
                    "Mensaje de éxito", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                dgvProductos.DataSource = daoLinea.listarLineasOrdenVenta();
                subtotal += lineaSeleccionada.subtotal;
                total = subtotal + descuentos + impuestos + recargo;
                textBox1.Text = subtotal.ToString();
                textBox2.Text = descuentos.ToString();
                textBox3.Text = impuestos.ToString();
                textBox4.Text = recargo.ToString();
                textBox5.Text = total.ToString();
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error con la modificacion",
                    "Mensaje de éxito", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int resultado;
            lineaSeleccionada = (lineaOrdenVenta)dgvProductos.CurrentRow.DataBoundItem;
            lineaSeleccionada.cantidad -= 1;
            lineaSeleccionada.subtotal -= lineaSeleccionada.item.precioUnitario;
            if (lineaSeleccionada.cantidad == 0)
            {
                resultado = daoLinea.eliminarLinea(lineaSeleccionada);
            }
            else
            {
                resultado = daoLinea.modificarLinea(lineaSeleccionada);
            }
            if (resultado != 0)
            {
                MessageBox.Show("Se ha eliminado la cantidad",
                    "Mensaje de éxito", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                dgvProductos.DataSource = daoLinea.listarLineasOrdenVenta();
                subtotal -= lineaSeleccionada.subtotal;
                total = subtotal + descuentos + impuestos + recargo;
                textBox1.Text = subtotal.ToString();
                textBox2.Text = descuentos.ToString();
                textBox3.Text = impuestos.ToString();
                textBox4.Text = recargo.ToString();
                textBox5.Text = total.ToString();
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error con la eliminación",
                    "Mensaje de éxito", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_DoubleClick(object sender, EventArgs e)
        {
            _comida = listaComidas[0];
        }

        private void pictureBox11_DoubleClick(object sender, EventArgs e)
        {
            _comida = listaComidas[1];
        }

        private void pictureBox5_DoubleClick(object sender, EventArgs e)
        {
            _comida = listaComidas[3];
        }

        private void pictureBox14_DoubleClick(object sender, EventArgs e)
        {
            _comida = listaComidas[4];
        }

        private void pictureBox15_DoubleClick(object sender, EventArgs e)
        {
            _comida = listaComidas[7];
        }

        private void pictureBox16_DoubleClick(object sender, EventArgs e)
        {
            _comida = listaComidas[5];
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmBebidas formBebidas = new frmBebidas(_cuentaPersonal);
            this.Hide();
            formBebidas.ShowDialog();
        }

        private void picBack_Click(object sender, EventArgs e)
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            frmMerch formMerch = new frmMerch(_cuentaPersonal);
            this.Hide();
            formMerch.ShowDialog();
        }
    }
}
