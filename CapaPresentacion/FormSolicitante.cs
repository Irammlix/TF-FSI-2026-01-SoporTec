using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormSolicitante : Form
    {
        private Solicitante solicitanteActual;
        private int idTicketActual;
        private string estadoOriginal;
        //descargar pdf
        private Ticket ticketParaPdf;
        //para animacion
        private bool _sidebarAbierto = false;
        private Timer _timerSidebar = new Timer();

        //llamamos a lo de la capa negocio
        private NTipoSolicitud nTipoSolicitud = new NTipoSolicitud();
        private NSede nSede = new NSede();
        private NPabellon nPabellon = new NPabellon();
        private NTicket nTicket = new NTicket();

        public FormSolicitante(Solicitante solicitante)
        {
            InitializeComponent();
            dg_Tickets.MultiSelect = false;
            dg_Tickets.ReadOnly = true;
            dg_Tickets.AllowUserToResizeColumns = false;
            dg_Tickets.AllowUserToResizeRows = false;
            dg_Tickets.AllowUserToAddRows = false;

            solicitanteActual = solicitante;
            lb_Codigo.Text = solicitanteActual.CSolicitante;

            CargarComboEstadoFiltro();
            CargarCombosNuevaSolicitud();
            MostrarTickets();
            
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
        //pnl_NuevaSolicitud
        private void CargarCombosNuevaSolicitud()
        {
            List<TipoSolicitud> tipo = nTipoSolicitud.ListarTodo();
            cb_Tipo.DataSource = null;
            if (tipo.Count > 0)
            {
                cb_Tipo.DataSource = tipo;
                cb_Tipo.ValueMember = "IdTipoSolicitud";
                cb_Tipo.DisplayMember = "DNombre";
            }

            List<Sede> sede = nSede.ListarTodo();
            cb_Sede.DataSource = null;
            if (sede.Count > 0)
            {
                cb_Sede.DataSource = sede;
                cb_Sede.ValueMember = "IdSede";
                cb_Sede.DisplayMember = "DNombreSede";
            }

            List<Pabellon> pabellon = nPabellon.ListarTodo();
            cb_Pabellon.DataSource = null;
            if (pabellon.Count > 0)
            {
                cb_Pabellon.DataSource = pabellon;
                cb_Pabellon.ValueMember = "IdPabellon";
                cb_Pabellon.DisplayMember = "DNombrePabellon";
            }
        }
        //pnl_Mis tickets
        private void CargarComboEstadoFiltro()
        {
            //llenamos el comboBox con valores fijos
            cb_FiltroEstado.Items.Clear();
            cb_FiltroEstado.Items.Add("Todos");
            cb_FiltroEstado.Items.Add("Sin Asignar");
            cb_FiltroEstado.Items.Add("Asignado");
            cb_FiltroEstado.Items.Add("En Proceso");
            cb_FiltroEstado.Items.Add("Resuelto");
            //arranca en "Todos"
            cb_FiltroEstado.SelectedIndex = 0; 
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

        private void MostrarTickets()
        {
            //lee el estado seleccionado en el combo de filtro
            string estado = cb_FiltroEstado.SelectedItem.ToString();

            List<Ticket> ticket = nTicket.ListarPorSolicitante(solicitanteActual.IdSolicitante, estado);

            if (ticket.Count > 0)
            {

                var listaParaMostrar = ticket.Select(t => new
                {
                    IdTicket = t.IdTicket,
                    DTitulo = t.DTitulo,
                    TipoSolicitud = t.TipoSolicitud.DNombre,
                    Sede = t.Sede.DNombreSede,
                    Pabellon = t.Pabellon.DNombrePabellon,
                    DEstado = t.DEstado,
                    FCreacion = t.FCreacion,
                    FActualizacion = t.FActualizacion
                }).ToList();

                dg_Tickets.DataSource = listaParaMostrar;

                //nombre de los headers
                dg_Tickets.Columns["IdTicket"].HeaderText = "IdTicket";
                dg_Tickets.Columns["DTitulo"].HeaderText = "Titulo";
                dg_Tickets.Columns["DEstado"].HeaderText = "Estado";
                dg_Tickets.Columns["FCreacion"].HeaderText = "Fecha de Creacion";
                dg_Tickets.Columns["FActualizacion"].HeaderText = "Fecha de Actualizacion";

            }
            else
            {
                dg_Tickets.DataSource = null;
            }
        }

        private void btn_VerDetalle_Click(object sender, EventArgs e)
        {
            if (dg_Tickets.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un ticket");
                return;
            }
            int idTicket = int.Parse(dg_Tickets.SelectedRows[0].Cells["IdTicket"].Value.ToString());
            Ticket ticket = nTicket.ObtenerPorId(idTicket);
            lb_NumTicket.Text = "Detalle del Ticket N°" + ticket.IdTicket.ToString();
            //llenamos el panel de detalle con esos datos6
            CargarDetalleTicket(ticket);

            //POR AHORA SOLO NAVEGA AL PANEL DETALLE TICKET, falta implementar la clase tecnico para conectarlo
            MostrarPanel(pnl_DetalleTicket);
        }

        //pnl_detalleTicket
        private void CargarDetalleTicket(Ticket ticket)
        {
            lb_NumTicket.Text = "Detalle del Ticket N°" + ticket.IdTicket.ToString();
            tb_DetTitulo.Text = ticket.DTitulo;
            tb_DetTipo.Text = ticket.TipoSolicitud.DNombre;
            tb_DetDescripcion.Text = ticket.DDescripcion;
            tb_DetSede.Text = ticket.Sede.DNombreSede;
            tb_DetPabellon.Text = ticket.Pabellon.DNombrePabellon;
            tb_FechaActualizacion.Text = ticket.FActualizacion.ToString();
            tb_FechaCreacion.Text = ticket.FCreacion.ToString();
            tb_Comentario.Text = ticket.DComentario;
            tb_EstadoActual.Text = ticket.DEstado;

            if (ticket.Tecnico == null)
            {
                tb_NombreTecnico.Text = "Sin asignar";
            }
            else
            {
                tb_NombreTecnico.Text = ticket.Tecnico.DNombres;
            }

            idTicketActual = ticket.IdTicket;
            estadoOriginal = ticket.DEstado;

            ActualizarVisibilidadBotonCancelar();
        }
        ////el resto de eventos click va aquii

        private void btn_RegistrarSolicitud_Click(object sender, EventArgs e)
        {
            //validacion campo
            if (tb_Titulo.Text == "" || tb_Descripcion.Text == ""|| cb_Tipo.Text == "" || cb_Sede.Text == "" || cb_Pabellon.Text == "")
            {
                MessageBox.Show("Ingrese todos los campos");
                return;
            }

            Ticket ticket = new Ticket()
            {
                DTitulo = tb_Titulo.Text,
                DDescripcion = tb_Descripcion.Text,
                IdTipoSolicitud = int.Parse(cb_Tipo.SelectedValue.ToString()),
                IdSede = int.Parse(cb_Sede.SelectedValue.ToString()),
                IdPabellon = int.Parse(cb_Pabellon. SelectedValue.ToString()),
                IdCreadoPor = solicitanteActual.IdSolicitante,
               
            };
            string mensaje = nTicket.Registrar(ticket);
            MessageBox.Show(mensaje);
            LimpiarNuevaSolicitud();
            MostrarTickets();

        }

        private void LimpiarNuevaSolicitud()
        {
            //limpia los textbox
            tb_Titulo.Text = "";
            tb_Descripcion.Text = "";

            //resetea los combos
            cb_Tipo.SelectedIndex = -1;
            cb_Sede.SelectedIndex = -1;
            cb_Pabellon.SelectedIndex = -1;
        }

        private void cb_FiltroEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarTickets();
        }
      

        private void ActualizarVisibilidadBotonCancelar()
        { 
            if (estadoOriginal == "Sin Asignar")
            {
                btn_CancelarTicket.Visible = true;
            }
            else
            {
                btn_CancelarTicket.Visible = false;
            }
        }

        private void btn_CancelarTicket_Click(object sender, EventArgs e)
        {
            string mensaje = nTicket.CancelarTicket(idTicketActual,estadoOriginal);
            MessageBox.Show(mensaje);
            if(mensaje== "Ticket cancelado correctamente")
            {
                MostrarPanel(pnl_MisTickets);
                MostrarTickets();
            }
           
        }

        private void btn_CerrarDetalle_Click(object sender, EventArgs e)
        {
            MostrarPanel(pnl_MisTickets);
        }

        private void btn_DescargarDetalle_Click(object sender, EventArgs e)
        {
            ticketParaPdf = nTicket.ObtenerPorId(idTicketActual);

            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Filter = "Archivo PDF (*.pdf)|*.pdf";
            guardar.FileName = "Ticket_" + ticketParaPdf.IdTicket + ".pdf";

            if (guardar.ShowDialog() == DialogResult.OK)
            {
                PrintDocument doc = new PrintDocument();
                doc.PrinterSettings.PrinterName = "Microsoft Print to PDF";
                doc.PrinterSettings.PrintToFile = true;
                doc.PrinterSettings.PrintFileName = guardar.FileName;
                doc.PrintPage += Doc_PrintPage;
                doc.Print();

                MessageBox.Show("PDF generado correctamente");
            }
        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            Font titulo = new Font("Arial", 18, FontStyle.Bold);
            Font subtitulo = new Font("Arial", 10, FontStyle.Bold);
            Font texto = new Font("Arial", 10);

            Pen rojo = new Pen(Color.Firebrick, 2);

            int x = 40;
            int y = 40;

            // Encabezado
            g.DrawString("SoporTec UPC", titulo, Brushes.Firebrick, x, y);

            y += 50;

            g.DrawString(
                $"Detalle del Ticket N° {ticketParaPdf.IdTicket}",
                new Font("Arial", 14, FontStyle.Bold),
                Brushes.Black,
                x,
                y);

            y += 40;

            // Línea superior
            g.DrawLine(rojo, x, y, 760, y);

            y += 20;

            // Título
            g.DrawString("Título de Solicitud", subtitulo, Brushes.Black, x, y);
            g.DrawString("Última Fecha de Actualización", subtitulo, Brushes.Black, 430, y);

            y += 20;

            g.DrawString(ticketParaPdf.DTitulo, texto, Brushes.Black, x, y);
            g.DrawString(ticketParaPdf.FActualizacion.ToString(), texto, Brushes.Black, 430, y);

            y += 30;
            g.DrawLine(rojo, x, y, 760, y);

            y += 15;

            // Tipo
            g.DrawString("Tipo de Solicitud", subtitulo, Brushes.Black, x, y);
            g.DrawString("Fecha de Creación", subtitulo, Brushes.Black, 430, y);

            y += 20;

            g.DrawString(ticketParaPdf.TipoSolicitud.DNombre, texto, Brushes.Black, x, y);
            g.DrawString(ticketParaPdf.FCreacion.ToString(), texto, Brushes.Black, 430, y);

            y += 30;
            g.DrawLine(rojo, x, y, 760, y);

            y += 15;

            // Títulos cuadros
            g.DrawString("Descripción", subtitulo, Brushes.Black, x, y);
            g.DrawString("Comentario Técnico", subtitulo, Brushes.Black, 430, y);

            y += 20;

            Rectangle descripcion = new Rectangle(x, y, 340, 120);
            Rectangle comentario = new Rectangle(430, y, 340, 120);

            g.DrawRectangle(rojo, descripcion);
            g.DrawRectangle(rojo, comentario);

            g.DrawString(
                ticketParaPdf.DDescripcion,
                texto,
                Brushes.Black,
                descripcion);

            g.DrawString(
                ticketParaPdf.DComentario,
                texto,
                Brushes.Black,
                comentario);

            y += 140;

            // Sede/Técnico
            g.DrawString("Sede", subtitulo, Brushes.Black, x, y);
            g.DrawString("Nombre de Técnico Asignado", subtitulo, Brushes.Black, 430, y);

            y += 20;

            g.DrawString(ticketParaPdf.Sede.DNombreSede, texto, Brushes.Black, x, y);

            g.DrawString(
                ticketParaPdf.Tecnico == null
                    ? "Sin asignar"
                    : ticketParaPdf.Tecnico.DNombres,
                texto,
                Brushes.Black,
                430,
                y);

            y += 30;
            g.DrawLine(rojo, x, y, 760, y);

            y += 15;

            // Pabellón / Estado
            g.DrawString("Pabellón", subtitulo, Brushes.Black, x, y);
            g.DrawString("Estado Actual del Ticket", subtitulo, Brushes.Black, 430, y);

            y += 20;

            g.DrawString(ticketParaPdf.Pabellon.DNombrePabellon, texto, Brushes.Black, x, y);
            g.DrawString(ticketParaPdf.DEstado, texto, Brushes.Black, 430, y);

            y += 30;
            g.DrawLine(rojo, x, y, 760, y);
        }
    }
}
