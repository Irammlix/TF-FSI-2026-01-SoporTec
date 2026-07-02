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
    public partial class FormTecnico : Form
    {
        private Tecnico tecnicoActual;
        private bool _sidebarAbierto = false;
        private Timer _timerSidebar = new Timer();

        public FormTecnico(Tecnico tecnico)
        {
            InitializeComponent();
            tecnicoActual = tecnico;
            lb_Codigo.Text = tecnicoActual.CTecnico;
            MostrarPanel(pnl_TicketsAsignados);
            InicializarSidebar();

        }
        private void MostrarPanel(Panel panel)
        {
            pnl_TicketsAsignados.Visible = false;
            pnl_DetalleTicket.Visible = false;
            panel.Visible = true;
        }

        private void InicializarSidebar()
        {
            Sidebar.Width = 85;
            _timerSidebar.Interval = 5;
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
            btn_TicketsAsignados.BackColor = _colorNormal;
        }


        private void btn_TicketsAsignados_Click(object sender, EventArgs e)
        {
            SetBotonesNormal();
            btn_TicketsAsignados.BackColor = _colorActivo;
            MostrarPanel(pnl_TicketsAsignados);
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
            MostrarPanel(pnl_DetalleTicket);
            //cuando se tenga a clase ticket ya se cargan los datos del ticket selecciondo
        }

        private void btn_ActualizarTicket_Click(object sender, EventArgs e)
        {
            if (cb_EstadoActual.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un estado");
                return;
            }
            // cuando se tenga NTicket la lógica sería similar a esto
            // int ticketId = int.Parse(lb_NumTicket.Text);
            // string nuevoEstado = cb_EstadoActual.SelectedItem.ToString();
            // string mensaje = nTicket.ActualizarEstado(ticketId, nuevoEstado, tb_Comentario.Text);
            // MessageBox.Show(mensaje);

            MessageBox.Show("Pendiente conectar NTicket");
        }
    }
}
