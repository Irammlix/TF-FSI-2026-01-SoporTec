using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormAdministrador : Form
    {
        private bool _sidebarAbierto = false;
        private Timer _timerSidebar = new Timer();

        private const int SIDEBAR_CERRADO = 62;
        private const int SIDEBAR_ABIERTO = 260;

        public FormAdministrador()
        {
            InitializeComponent();
            InicializarSidebar();
        }

        private void InicializarSidebar()
        {
            Sidebar.Width = SIDEBAR_CERRADO;
            OcultarTextoSidebar();
            _timerSidebar.Interval = 5;
            _timerSidebar.Tick += TimerSidebar_Tick;
        }

        private void OcultarTextoSidebar()
        {
            foreach (Control c in Sidebar.Controls)
                if (c is Button) c.Text = "";
        }

        private void MostrarTextoSidebar()
        {
            btn_NuevaSolicitud.Text = "     Tickets";
            btn_Reportes.Text = "     Reportes";
            btn_RegistrarTecnico.Text = "     Registrar Tecnico";
            btn_MisTecnicos.Text = "     Mis Tecnicos";
            btn_CerrarSesion.Text = "     Cerrar Sesión";
        }

        private void TimerSidebar_Tick(object sender, EventArgs e)
        {
            if (_sidebarAbierto)
            {
                if (Sidebar.Width < SIDEBAR_ABIERTO) Sidebar.Width += 15;
                else { Sidebar.Width = SIDEBAR_ABIERTO; _timerSidebar.Stop(); MostrarTextoSidebar(); }
            }
            else
            {
                OcultarTextoSidebar();
                if (Sidebar.Width > SIDEBAR_CERRADO) Sidebar.Width -= 15;
                else { Sidebar.Width = SIDEBAR_CERRADO; _timerSidebar.Stop(); }
            }
        }

        private void btn_Hamburguesa_Click(object sender, EventArgs e)
        {
            _sidebarAbierto = !_sidebarAbierto;
            _timerSidebar.Start();
        }

    
    }
}