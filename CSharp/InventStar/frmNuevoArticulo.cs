using InventStar.InventarioWS;
using InventStar.PersonalWS;
using InventstarInventario;
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
    public partial class frmNuevoArticulo : Form
    {
        //private comida comi;
        //private ingrediente ingre;

        private InventarioWSClient _daoInventario;
        private insumoPerecible insumoSeleccionado;
        private cuentaPersonal _cuentaPersonal;
        

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);
        public frmNuevoArticulo(cuentaPersonal cuentaPersonal)
        {
            //comi = new comida();
            //ingre = new ingrediente();
            
            _daoInventario = new InventarioWSClient();
            insumoSeleccionado = new insumoPerecible();
            InitializeComponent();
            
            this._cuentaPersonal=cuentaPersonal;
        }

        public insumoPerecible InsumoSeleccionado { get => insumoSeleccionado; set => insumoSeleccionado = value; }


        public int getType()
        {
            if (insumoSeleccionado.ingrediente == null)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public Decimal getStock()
        {
            return numericUpDown1.Value;
        }

        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0xA1, 0x2, 0);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            insumoSeleccionado.fechaIngesoSpecified = true;
            insumoSeleccionado.fechaIngeso = dateTimePicker2.Value;
            insumoSeleccionado.fechaVencimientoSpecified = true;
            insumoSeleccionado.fechaVencimiento = dateTimePicker2.Value;
            insumoSeleccionado.cantidad = (Double)numericUpDown1.Value;

            this.DialogResult = DialogResult.OK;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmSeleccionarCI formCI = new frmSeleccionarCI();
            if (formCI.ShowDialog() == DialogResult.OK)
            {
                if(formCI.GetFlag() == 0)
                {
                    textBox3.Text = formCI.ComidaSeleccionada.nombre;
                    insumoSeleccionado.comida = formCI.ComidaSeleccionada;               
                    insumoSeleccionado.nombre = "Lote de " + formCI.ComidaSeleccionada.nombre;
                    insumoSeleccionado.ingrediente = null;
                    
                    
                }
                else
                {
                    textBox3.Text = formCI.IngredienteSeleccionado.nombre;
                    insumoSeleccionado.ingrediente = formCI.IngredienteSeleccionado;
                    insumoSeleccionado.nombre = "Lote de " + formCI.IngredienteSeleccionado.nombre;
                    insumoSeleccionado.comida = null;
                    
                }
                
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            frmSeleccionarOC formOC = new frmSeleccionarOC();
            if (formOC.ShowDialog() == DialogResult.OK)
            {
                textBox8.Text = formOC.OrdenSeleccionada.proveedor.nombre;
                insumoSeleccionado.ordenCompra = formOC.OrdenSeleccionada;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmSeleccionarCI formCI = new frmSeleccionarCI();
            if (formCI.ShowDialog() == DialogResult.OK)
            {
                if (formCI.GetFlag() == 0)
                {
                    textBox3.Text = formCI.ComidaSeleccionada.nombre;
                    insumoSeleccionado.comida = formCI.ComidaSeleccionada;
                    insumoSeleccionado.nombre = "Lote de " + formCI.ComidaSeleccionada.nombre;
                    insumoSeleccionado.ingrediente = null;


                }
                else
                {
                    textBox3.Text = formCI.IngredienteSeleccionado.nombre;
                    insumoSeleccionado.ingrediente = formCI.IngredienteSeleccionado;
                    insumoSeleccionado.nombre = "Lote de " + formCI.IngredienteSeleccionado.nombre;
                    insumoSeleccionado.comida = null;

                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmSeleccionarOC formOC = new frmSeleccionarOC();
            if (formOC.ShowDialog() == DialogResult.OK)
            {
                textBox8.Text = formOC.OrdenSeleccionada.proveedor.nombre;
                insumoSeleccionado.ordenCompra = formOC.OrdenSeleccionada;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
