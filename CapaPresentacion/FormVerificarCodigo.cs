using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormVerificarCodigo : Form
    {
        public string CodigoIngresado { get; private set; }

        public FormVerificarCodigo(string correoOculto)
        {
            InitializeComponent();
            lbl_Info.Text = "Se envió un código a: " + correoOculto;
            this.KeyPreview = true;
            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) btn_Verificar.PerformClick();
                if (e.KeyCode == Keys.Escape) btn_Cancelar.PerformClick();
            };
            tb_Codigo.KeyPress += (s, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                    e.Handled = true;
            };
        }

        private void btn_Verificar_Click(object sender, EventArgs e)
        {
            if (tb_Codigo.Text.Length != 4)
            {
                MessageBox.Show("Ingresa el código de 4 dígitos");
                return;
            }
            CodigoIngresado = tb_Codigo.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void lnk_Reenviar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
            this.Close();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
