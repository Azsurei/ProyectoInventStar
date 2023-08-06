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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventStar
{
    public partial class frmDetalleMermas : Form
    {
        private InventarioWSClient _daoMermas;
        private merma _merma;
        private cuentaPersonal _cuentaPersonal;
        DateTime fechaActual = DateTime.Now;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);

        public frmDetalleMermas(cuentaPersonal _cuentaPersonal)
        {
            InitializeComponent();
            _daoMermas = new InventarioWSClient();
            _merma = new merma();
            cboLote.DisplayMember = "nombre";
            cboLote.ValueMember = "idLote";
            cboLote.DataSource = _daoMermas.listarLotes();
            this._cuentaPersonal = _cuentaPersonal;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmMermas formCli = new frmMermas(_cuentaPersonal);
            this.Hide();
            formCli.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _merma.lote = new lote();
            _merma.lote.idLote = (int)cboLote.SelectedValue;
            _merma.fechaRegistro = dateTimePicker1.Value;
            _merma.fechaRegistroSpecified = true;
            _merma.cantidad = double.Parse(textBox3.Text);
            _merma.motivo = textBox5.Text;


            int resultado = _daoMermas.insertarMerma(_merma);
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

        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0xA1, 0x2, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
}
