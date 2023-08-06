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
    public partial class frmInventarioActualizar : Form
    {
        private InventarioWSClient _daoInventario;
        private cuentaPersonal _cuentaPersonal;
        private insumoPerecible _insumo;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);
        public frmInventarioActualizar(cuentaPersonal cuentaPersonal,insumoPerecible insumo)
        {
            _daoInventario = new InventarioWSClient();
            _insumo = insumo;
            InitializeComponent();
            textBox1.Text = insumo.nombre;
            dateTimePicker1.Value = insumo.fechaIngeso;
            dateTimePicker2.Value = insumo.fechaVencimiento;
            numericUpDown1.Value = (Decimal)insumo.cantidad;
            this._cuentaPersonal = cuentaPersonal;   
        }

        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0xA1, 0x2, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int result;
            _insumo.nombre = textBox1.Text;
            _insumo.fechaIngeso = dateTimePicker1.Value;
            _insumo.fechaVencimiento = dateTimePicker2.Value;
            _insumo.cantidad = (Double)numericUpDown1.Value;
            if(_insumo.comida != null)
            {
                _insumo.ingrediente = null;
            }
            else if (_insumo.ingrediente != null)
            {
                _insumo.comida = null;
            }
            result = _daoInventario.modificarInsumoPerecible(_insumo);
            if (result != 0)
            {
                MessageBox.Show("Se ha modificado correctamente", "Mensaje de Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error al momento de modificar", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
