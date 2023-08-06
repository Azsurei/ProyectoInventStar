using InventStar.ClientesWS;
using InventStar.InventarioWS;
using InventStar.PersonalWS;
using java.lang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventStar
{
    public partial class frmDetalleOrdenVenta : Form
    {
        private ClientesWS.cliente _cliente;
        private PersonalWS.sucursal _sucursal;
        private ClientesWSClient daoTransaccion;
        private ClientesWSClient daoResenha;
        private PersonalWSClient daoOrdenVenta;
        private personal _personal;
        private ordenVenta _ordenVenta;
        private cuentaPersonal _cuentaPersonal;
        DateTime fechaActual = DateTime.Now;
        DateTime horaEspecifica = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 13, 30, 45);
        public frmDetalleOrdenVenta(ordenVenta ordenVenta, cuentaPersonal cuentaPersonal)
        {
            InitializeComponent();
            daoTransaccion = new ClientesWSClient();
            daoResenha = new ClientesWSClient();
            daoOrdenVenta = new PersonalWSClient();
            _cliente = new ClientesWS.cliente();
            _sucursal = new PersonalWS.sucursal();
            _personal = new personal();
            _ordenVenta = ordenVenta;
            _cuentaPersonal = cuentaPersonal;

        }

        private void lblPanel_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmBusquedClientes formBusqClie = new frmBusquedClientes(_ordenVenta, _cuentaPersonal);
            if (formBusqClie.ShowDialog() == DialogResult.OK)
            {
                this._cliente = formBusqClie.ClienteSeleccionado;
                txtCliente.Text = _cliente.nombres + " " + _cliente.apellidoPat;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmBusquedaSucursal formBusqSuc = new frmBusquedaSucursal(_ordenVenta, _cuentaPersonal);
            if (formBusqSuc.ShowDialog() == DialogResult.OK)
            {
                this._sucursal = formBusqSuc.SucursalSeleccionado;
                txtSucursal.Text = _sucursal.nombre;

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            _ordenVenta.personal = _cuentaPersonal.personal;
            _ordenVenta.cliente = new PersonalWS.cliente();
            _ordenVenta.cliente.idPersona = _cliente.idPersona;
            _ordenVenta.cliente.nombres = _cliente.nombres;
            _ordenVenta.cliente.apellidoPat = _cliente.apellidoPat;
            _ordenVenta.cliente.apellidoMat = _cliente.apellidoMat;
            _ordenVenta.cliente.numDocumento = _cliente.numDocumento;
            _ordenVenta.cliente.telefono1 = _cliente.telefono1;
            _ordenVenta.cliente.telefono2 = _cliente.telefono2;
            _ordenVenta.cliente.email = _cliente.email;
            _ordenVenta.cliente.domicilio = _cliente.domicilio;
            _ordenVenta.cliente.fechaRegistro = _cliente.fechaRegistro;
            _ordenVenta.cliente.fechaCumpleanhosSpecified = true;
            _ordenVenta.cliente.fechaCumpleanhos = _cliente.fechaCumpleanhos;
            _ordenVenta.sucursal = _sucursal;
            _ordenVenta.transaccion = new PersonalWS.transaccion();
            ClientesWS.transaccion transaccionCliente = new ClientesWS.transaccion();
           

            _ordenVenta.transaccion.fecha = fechaActual; transaccionCliente.fecha = fechaActual;
            _ordenVenta.transaccion.fechaSpecified = true; transaccionCliente.fechaSpecified = true;
            _ordenVenta.transaccion.hora = horaEspecifica.ToString("hh:mm"); transaccionCliente.hora = horaEspecifica.ToString("hh:mm");
            _ordenVenta.transaccion.moneda = cbMoneda.SelectedItem.ToString(); transaccionCliente.moneda = cbMoneda.SelectedItem.ToString();
            if (cbTipoPago.SelectedItem.ToString() == "Efectivo")
            {
                _ordenVenta.transaccion.tipo = PersonalWS.tipoDePago.Efectivo;
                transaccionCliente.tipo = ClientesWS.tipoDePago.Efectivo;
            }
            else if (cbTipoPago.SelectedItem.ToString() == "Yape")
            {
                _ordenVenta.transaccion.tipo = PersonalWS.tipoDePago.Yape;
                transaccionCliente.tipo = ClientesWS.tipoDePago.Yape;
            }
            else
            {
                _ordenVenta.transaccion.tipo = PersonalWS.tipoDePago.TarjetaBancaria;
                transaccionCliente.tipo = ClientesWS.tipoDePago.TarjetaBancaria;
            }
            _ordenVenta.transaccion.tipoSpecified = true;
            transaccionCliente.tipoSpecified = true;

            int resultado1 = daoTransaccion.insertarTransaccion(transaccionCliente);
            if (resultado1 != 0)
            {
                MessageBox.Show("Se ha agrega la transaccion ",
                    "Mensaje de éxito", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                _ordenVenta.transaccion.idTransaccion = resultado1;
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error con la transaccion",
                    "Mensaje de éxito", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            
            //resenha 

            _ordenVenta.resenha = new PersonalWS.reseña();
            ClientesWS.reseña resenhaCliente = new ClientesWS.reseña();
            _ordenVenta.resenha.comentario = " "; resenhaCliente.comentario = " ";
            _ordenVenta.resenha.valoracion = 0; resenhaCliente.valoracion = 0;
            int resultado2 = daoResenha.insertarResenha(resenhaCliente);
            if (resultado1 != 0)
            {
                MessageBox.Show("Se ha agrega la resenha ",
                    "Mensaje de éxito", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                _ordenVenta.transaccion.idTransaccion = resultado1;
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error con la resenha ",
                    "Mensaje de éxito", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            _ordenVenta.resenha.idReseña = resultado2;
            int resultado3 = daoOrdenVenta.insertarOrdenV(_ordenVenta);
            if (resultado1 != 0)
            {
                MessageBox.Show("Se ha agrega la orden de venta ",
                    "Mensaje de éxito", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                _ordenVenta.transaccion.idTransaccion = resultado1;
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error con la orden venta",
                    "Mensaje de éxito", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmBebidas formSuc = new frmBebidas(_cuentaPersonal);
            this.Hide();
            formSuc.ShowDialog();
        }

        private void txtPersonal_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
