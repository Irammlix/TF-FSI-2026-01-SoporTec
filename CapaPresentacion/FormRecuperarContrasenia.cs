using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormRecuperarContrasenia : Form
    {
        private NTecnico nTecnico = new NTecnico();
        private NSolicitante nSolicitante = new NSolicitante();
        private NAdmin nAdministrador = new NAdmin();
        public FormRecuperarContrasenia()
        {
            InitializeComponent();
            pnl_RecuperarSolicitante.Visible = false;
            pnl_RecuperarTecnico.Visible = false;
            pnl_RecuperarAdmin.Visible = false;
        }
        public void MostrarPanelSolicitante() 
        { 
            pnl_RecuperarSolicitante.Visible = true; 
        }
        public void MostrarPanelTecnico() 
        { 
            pnl_RecuperarTecnico.Visible = true; 
        }
        public void MostrarPanelAdmin() 
        { 
            pnl_RecuperarAdmin.Visible = true; 
        }

        // SOLICITANTE
        private void btn_VolverSesionSoli_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_RecuperarSoli_Click(object sender, EventArgs e)
        {
            if (tb_CodigoSoli.Text == "" || tb_ContraNuevoSoli.Text == "" ||
               tb_ConfirmaContraSoli.Text == "")
            {
                MessageBox.Show("Ingrese todos los campos");
                return;
            }

            if (tb_ContraNuevoSoli.Text != tb_ConfirmaContraSoli.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden");
                return;
            }
            string mensaje = nSolicitante.CambiarContrasena(tb_CodigoSoli.Text, tb_ContraNuevoSoli.Text);
            MessageBox.Show(mensaje);
            if (mensaje == "Contraseña actualizada exitosamente")
            {this.Close();}
            MessageBox.Show("Recuperar solicitante — pendiente conectar NSolicitante");
        }
        //TECNICO
        private void btn_VolverSesionTecnico_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_RecuperarTecnico_Click(object sender, EventArgs e)
        {
            if (tb_CodigoAdmin.Text == "" || tb_ContraNuevoAdmin.Text == "" ||
                tb_ConfirmaContraAdmin.Text == "")
            {
                MessageBox.Show("Ingrese todos los campos");
                return;
            }

            if (tb_ContraNuevoAdmin.Text != tb_ConfirmaContraAdmin.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden");
                return;
            }

            // string mensaje = nAdministrador.CambiarContrasena(tb_CodigoAdmin.Text, tb_ContraNuevoAdmin.Text);
            // MessageBox.Show(mensaje);
            // if (mensaje == "Contraseña actualizada exitosamente") this.Close();

            MessageBox.Show("Recuperar admin — pendiente conectar NAdministrador");
        }
    }

}
