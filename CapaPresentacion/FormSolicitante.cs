using CapaDatos;
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
    public partial class FormSolicitante : Form
    {
        private Solicitante solicitanteActual;
        //para animacion
        private bool _sidebarAbierto = false;
        private Timer _timerSidebar = new Timer();

        public FormSolicitante(Solicitante solicitante)
        {
            InitializeComponent();
            solicitanteActual = solicitante;
            lb_Codigo.Text = solicitanteActual.CSolicitante;
            MostrarPanel(pnl_NuevaSolicitud);
            //esto es para la animacion del sidebar que se mueva
            InicializarSidebar();

        }
        private void MostrarPanel(Panel panel)
        {
            pnl_NuevaSolicitud.Visible = false;
            pnl_MisTickets.Visible = false;
            pnl_DetalleTicket.Visible = false;
            panel.Visible = true;
        }

        // temas de animaciones
        private void InicializarSidebar()
        {
            Sidebar.Width = 85;
            _timerSidebar.Interval = 5;  // más rápido
            _timerSidebar.Tick += TimerSidebar_Tick;
        }

        private void TimerSidebar_Tick(object sender, EventArgs e)
        {
            if (_sidebarAbierto)
            {
                if (Sidebar.Width < 260)
                    Sidebar.Width += 15;
                else
                {
                    Sidebar.Width = 260; 
                    _timerSidebar.Stop();
                }
            }
            else
            {
                if (Sidebar.Width > 85)
                    Sidebar.Width -= 15;
                else
                {
                    Sidebar.Width = 85;
                    _timerSidebar.Stop();
                }
            }
        }
        private void btn_Hamburguesa_Click(object sender, EventArgs e)
        {
            _sidebarAbierto = !_sidebarAbierto;
            _timerSidebar.Start();
        }

        private Color _colorNormal = Color.FromArgb(35, 45, 65);  
        private Color _colorActivo = Color.FromArgb(40, 60, 100);

        private void SetBotonesNormal()
        {
            btn_NuevaSolicitud.BackColor = _colorNormal;
            btn_MisTickets.BackColor = _colorNormal;
        }

        private void btn_NuevaSolicitud_Click(object sender, EventArgs e)
        {
            SetBotonesNormal();
            btn_NuevaSolicitud.BackColor = _colorActivo;
            MostrarPanel(pnl_NuevaSolicitud);
        }

        private void btn_MisTickets_Click(object sender, EventArgs e)
        {
            SetBotonesNormal();
            btn_MisTickets.BackColor = _colorActivo;
            MostrarPanel(pnl_MisTickets);
        }

        private void btn_CerrarSesion_Click(object sender, EventArgs e)
        {
            FormPrincipal formPrincipal = new FormPrincipal();
            formPrincipal.Show();
            this.Close();
        }

        private void btn_VerDetalle_Click(object sender, EventArgs e)
        {
            if (dg_Tickets.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un ticket");
                return;
            }
            //POR AHORA SOLO NAVEGA AL PANEL DETALLE TICKET, falta implementar la clase tecnico para conectarlo
            MostrarPanel(pnl_DetalleTicket);
        }


        ////el resto de eventos click va aqui
    }
}
