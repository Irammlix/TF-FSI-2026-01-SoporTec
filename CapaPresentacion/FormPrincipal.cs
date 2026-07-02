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
    public partial class FormPrincipal : Form
    {
        private NTecnico nTecnico = new NTecnico();
        private NSolicitante nSolicitante = new NSolicitante(); 
        private NAdmin nAdministrador = new NAdmin(); 

        public FormPrincipal()
        {
            InitializeComponent();
            this.Resize += (s, e) => CentrarPanel();
            CentrarPanel();
            MostrarPanel(pnl_PaginaPrincipal);
        }
        private void MostrarPanel(Panel panel)
        {
            pnl_PaginaPrincipal.Visible = false;
            pnl_LoginSolicitante.Visible = false;
            pnl_LoginTecnico.Visible = false;
            pnl_LoginAdmin.Visible = false;
            pnl_RegistroSolicitante.Visible = false;

            panel.Visible = true;
        }
        // ===================== DISEÑO
        private void CentrarPanel()
        {
            pnl_LoginSolicitante.Location = new Point(
            (this.ClientSize.Width - pnl_LoginSolicitante.Width) / 2,
            (this.ClientSize.Height - pnl_LoginSolicitante.Height) / 2
    );
            pnl_LoginTecnico.Location = new Point(
                (this.ClientSize.Width - pnl_LoginTecnico.Width) / 2,
                (this.ClientSize.Height - pnl_LoginTecnico.Height) / 2
            );
            pnl_LoginAdmin.Location = new Point(
                (this.ClientSize.Width - pnl_LoginAdmin.Width) / 2,
                (this.ClientSize.Height - pnl_LoginAdmin.Height) / 2
            );
        }
        private void LimpiarCampos(Panel panel)
        {
            foreach (Control control in panel.Controls)
            {
                if (control is TextBox) ((TextBox)control).Text = "";
            }
        }


        // ===================== EVENTOS CLICK
        // PAGINA PRINCIPAL

        private void btn_Solicitante_Click(object sender, EventArgs e)
        {
            LimpiarCampos(pnl_LoginSolicitante);
            MostrarPanel(pnl_LoginSolicitante);
        }

        private void btn_Tecnico_Click(object sender, EventArgs e)
        {
            LimpiarCampos(pnl_LoginTecnico);
            MostrarPanel(pnl_LoginTecnico);
        }

        private void btn_Admin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LimpiarCampos(pnl_LoginAdmin);
            MostrarPanel(pnl_LoginAdmin);
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
        // LOGIN SOLICITANTE
        private void btn_Volver1_Click(object sender, EventArgs e)
        {
            MostrarPanel(pnl_PaginaPrincipal);
        }

        private void btn_IngresarSoli_Click(object sender, EventArgs e)
        {
            if (tb_CodigoSoli.Text == "" || tb_ContraSoli.Text == "")
            {
                MessageBox.Show("Ingrese todos los campos");
                return;
            }
            Solicitante solicitante = nSolicitante.ValidarLogin(tb_CodigoSoli.Text, tb_ContraSoli.Text);
            if (solicitante != null)
            {
                FormSolicitante formSolicitante = new FormSolicitante(solicitante);
                formSolicitante.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Código o contraseña incorrectos");
            }
        }

        private void lnk_OlvidarContraSoli_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRecuperarContrasenia formRecuperar = new FormRecuperarContrasenia();
            formRecuperar.MostrarPanelSolicitante();
            formRecuperar.ShowDialog();
        }
        //
        private void lnk_RegistrarSoli_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LimpiarCampos(pnl_RegistroSolicitante);
            MostrarPanel(pnl_RegistroSolicitante);
        }

        //LOGIN TECNICO
        private void btn_Volver2_Click(object sender, EventArgs e)
        {
            MostrarPanel(pnl_PaginaPrincipal);
        }

        private void btn_IngresarTecnico_Click(object sender, EventArgs e)
        {
            if (tb_CodigoTecnico.Text == "" || tb_ContraTecnico.Text == "")
            {
                MessageBox.Show("Ingrese todos los campos");
                return;
            }

            Tecnico tecnico = nTecnico.ValidarLogin(tb_CodigoTecnico.Text, tb_ContraTecnico.Text);
            if (tecnico != null)
            {
                FormTecnico formTecnico = new FormTecnico(tecnico);
                formTecnico.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Código o contraseña incorrectos");
            }
        }

        private void lnk_OlvidarContraTecnico_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRecuperarContrasenia formRecuperar = new FormRecuperarContrasenia();
            formRecuperar.MostrarPanelTecnico();
            formRecuperar.ShowDialog();
        }

        //LOGIN ADMIN
        private void btn_Volver3_Click(object sender, EventArgs e)
        {
            MostrarPanel(pnl_PaginaPrincipal);
        }

        private void btn_IngresarAdmin_Click(object sender, EventArgs e)
        {
            if (tb_CodigoAdmin.Text == "" || tb_ContraAdmin.Text == "")
            {
                MessageBox.Show("Ingrese todos los campos");
                return;
            }

            // Administrador admin = nAdministrador.ValidarLogin(tb_CodigoAdmin.Text, tb_ContraAdmin.Text);
            // if (admin != null)
            // {
            //     FormAdmin formAdmin = new FormAdmin(admin);
            //     formAdmin.Show();
            //     this.Hide();
            // }
            // else
            // {
            //     MessageBox.Show("Código o contraseña incorrectos");
            // }

            MessageBox.Show("Login admin — pendiente conectar NAdministrador");
        }

        private void lnk_OlvidarContraAdmin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRecuperarContrasenia formRecuperar = new FormRecuperarContrasenia();
            formRecuperar.MostrarPanelAdmin();
            formRecuperar.ShowDialog();
        }

        //REGISTRO SOLICITANTE
        private void btn_VolverSesionSoli_Click(object sender, EventArgs e)
        {
            MostrarPanel(pnl_LoginSolicitante);

        }

        private void btn_RegistrarSoli_Click(object sender, EventArgs e)
        {
            if (tb_NombresSoli.Text == "" || tb_ApellidosSoli.Text == "" ||
                tb_CodigoNuevoSoli.Text == "" || tb_ContraNuevoSoli.Text == "" ||
                tb_ConfirmarContraSoli.Text == "")
            {
                MessageBox.Show("Ingrese todos los campos");
                return;
            }

            if (tb_ContraNuevoSoli.Text != tb_ConfirmarContraSoli.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden");
                return;
            }

            Solicitante solicitante = new Solicitante()
            {
                DNombres = tb_NombresSoli.Text,
                DApellidos = tb_ApellidosSoli.Text,
                CSolicitante = tb_CodigoNuevoSoli.Text,
                DContrasena = tb_ContraNuevoSoli.Text
            };
            string mensaje = nSolicitante.Registrar(solicitante);
            MessageBox.Show(mensaje);
            if (mensaje == "Registrado exitosamente")
            { 
                MostrarPanel(pnl_LoginSolicitante); 
            }
        }
    }

        

}
