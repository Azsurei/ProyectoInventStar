using InventStar.ClientesWS;
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

using cliWS = InventStar.ClientesWS;

namespace InventStar
{
    public partial class frmMermas : Form
    {
        private InventarioWSClient _daoMermas;
        private merma _mermaSeleccionada;
        private cuentaPersonal _cuentaPersonal;

        public merma MermaSeleccionada { get => _mermaSeleccionada; set => _mermaSeleccionada = value; }

        //private cliWS.cliente _clienteSeleccionadoEliminar;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);

        public frmMermas(cuentaPersonal _cuentaPersonal)
        {
            InitializeComponent();
            _daoMermas = new InventarioWSClient();
            dgvMermas.AutoGenerateColumns = false;
            dgvMermas.DataSource = _daoMermas.listarMerma();
            this._cuentaPersonal = _cuentaPersonal;
        }


        private void dgvMermas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            merma mermaGenerica = (merma)dgvMermas.Rows[e.RowIndex].DataBoundItem;
            dgvMermas.Rows[e.RowIndex].
                Cells[0].Value = mermaGenerica.idMerma;
            dgvMermas.Rows[e.RowIndex].Cells[1].Value = mermaGenerica.fechaRegistro.ToString("dd-MM-yyyy");
            dgvMermas.Rows[e.RowIndex].Cells[2].Value = mermaGenerica.cantidad.ToString();
            dgvMermas.Rows[e.RowIndex].Cells[3].Value = mermaGenerica.motivo;
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmInventario formInv = new frmInventario(_cuentaPersonal);
            formInv.ShowDialog();
            this.Hide();
        }

        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0xA1, 0x2, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmDetalleMermas frmDet= new frmDetalleMermas(_cuentaPersonal);
            frmDet.ShowDialog();
            this.Hide();
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
            //dgvMermas.DataSource = _daoMermas.listarTodasClientesPorNombre_Apellido_DNI(textBox1.Text);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            _mermaSeleccionada = (merma)dgvMermas.CurrentRow.DataBoundItem;
            DialogResult resultadoInteraccion = MessageBox.Show("¿Está seguro de que desea eliminar esta merma", "Mensaje de Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resultadoInteraccion == DialogResult.Yes)
            {
                int resultado = _daoMermas.eliminarMerma(_mermaSeleccionada.idMerma);
                if (resultado != 0)
                {
                    MessageBox.Show("Se ha eliminado correctamente", "Mensaje de Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvMermas.DataSource = _daoMermas.listarMerma();
                    dgvMermas.Refresh();
                    dgvMermas.Update();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error al momento de eliminar", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvMermas_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _mermaSeleccionada = (merma)dgvMermas.CurrentRow.DataBoundItem;
        }

        private void dgvMermas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _mermaSeleccionada = (merma)dgvMermas.CurrentRow.DataBoundItem;
        }
    }
}
