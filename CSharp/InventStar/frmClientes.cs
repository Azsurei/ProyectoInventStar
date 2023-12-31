﻿using InventStar.ClientesWS;
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
    public partial class frmClientes : Form
    {
        
        private ClientesWSClient _daoClientes;
        private cliWS.cliente _clienteSeleccionado;
        private cliWS.cliente _clienteSeleccionadoEliminar;
        private cuentaPersonal _cuentaPersonal;
        private PersonalWSClient daoPersonal;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);

        public frmClientes(cuentaPersonal cuentaPersonal)
        {
            InitializeComponent();
            _daoClientes = new ClientesWSClient();
            daoPersonal = new PersonalWSClient();
            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.DataSource = _daoClientes.listarTodasClientes();
            this._cuentaPersonal = cuentaPersonal;
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
            frmDetalleCliente formDet = new frmDetalleCliente(_cuentaPersonal);
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
            dgvClientes.DataSource = _daoClientes.listarTodasClientesPorNombre_Apellido_DNI(textBox1.Text);
        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _clienteSeleccionado = (cliWS.cliente)dgvClientes.CurrentRow.DataBoundItem;
            frmDetalleCliente2 formDet = new frmDetalleCliente2(_clienteSeleccionado, _cuentaPersonal);
            this.Hide();
            formDet.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _clienteSeleccionadoEliminar = (cliWS.cliente)dgvClientes.CurrentRow.DataBoundItem;
            int _codigoEliminar=_clienteSeleccionadoEliminar.idPersona;
            String _nombrePersona = _clienteSeleccionadoEliminar.nombres;
            int resultado=_daoClientes.eliminar(_codigoEliminar);
            if (resultado != 0)
            {
                MessageBox.Show("Se ha eliminado el cliente "+_nombrePersona+ " de código "+ _codigoEliminar,
                    "Mensaje de éxito", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                dgvClientes.DataSource = _daoClientes.listarTodasClientes();
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error con la eliminación",
                    "Mensaje de éxito", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
