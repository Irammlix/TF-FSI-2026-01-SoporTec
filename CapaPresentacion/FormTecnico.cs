using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormTecnico : Form
    {
        private Tecnico tecnicoActual;

        private NTecnico nTecnico= new NTecnico();
        private NTicket nTicket = new NTicket();

        private bool _sidebarAbierto = false;
        private Timer _timerSidebar = new Timer();

        private int idTicketActual = 0;
        private string estadoOriginal = "";
        private string comentarioOriginal = "";

        public FormTecnico(Tecnico tecnico)
        {
            InitializeComponent();

            dg_Tickets.CellFormatting += dg_Tickets_CellFormatting;

            tecnicoActual = tecnico;
            lb_Codigo.Text = tecnicoActual.CTecnico;

            MostrarPanel(pnl_TicketsAsignados);
            cbEstadoFiltro.SelectedIndex = 0;
            cbPrioridadFiltro.SelectedIndex = 0;

            InicializarSidebar();
            MostrarTickets();
        }

        //------------------------------INTERFAZ---------------------------------
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

        private void MostrarPanel(Panel panel)
        {
            pnl_TicketsAsignados.Visible = false;
            pnl_DetalleTicket.Visible = false;
            panel.Visible = true;
        }

        private void btn_TicketsAsignados_Click(object sender, EventArgs e)
        {
            if (HayCambiosSinGuardar())
            {
                DialogResult respuesta = MessageBox.Show(
                    "No se guardaron los cambios. ¿Desea actualizar el ticket?",
                    "Cambios sin guardar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (respuesta == DialogResult.Yes)
                {
                    btn_ActualizarTicket_Click(sender, e);
                }
            }

            SetBotonesNormal();
            btn_TicketsAsignados.BackColor = _colorActivo;
            MostrarPanel(pnl_TicketsAsignados);
            LimpiarDetalleTicket();
        }

        private void btn_CerrarSesion_Click(object sender, EventArgs e)
        {
            if (HayCambiosSinGuardar())
            { 
                DialogResult respuesta = MessageBox.Show(
                    "No se guardaron los cambios. ¿Desea actualizar el ticket?",
                    "Cambios sin guardar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (respuesta == DialogResult.Yes)
                {
                    btn_ActualizarTicket_Click(sender, e);
                }
            }

            FormPrincipal formPrincipal = new FormPrincipal();
            formPrincipal.Show();
            this.Close();
        }

        private void dg_Tickets_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dg_Tickets.Rows[e.RowIndex].DataBoundItem == null)
                return;

            Ticket ticket = dg_Tickets.Rows[e.RowIndex].DataBoundItem as Ticket;

            if (ticket == null)
                return;

            string nombreColumna = dg_Tickets.Columns[e.ColumnIndex].Name;

            if (nombreColumna == "IdTipoSolicitud")
            {
                e.Value = ticket.TipoSolicitud.DNombre;
                e.FormattingApplied = true;
            }

            if (nombreColumna == "IdSede")
            {
                e.Value = ticket.Sede.DNombreSede;
                e.FormattingApplied = true;
            }

            if (nombreColumna == "IdPabellon")
            {
                e.Value = ticket.Pabellon.DNombrePabellon;
                e.FormattingApplied = true;
            }

            if (nombreColumna == "IdCreadoPor")
            {
                e.Value = ticket.Solicitante.CSolicitante;
                e.FormattingApplied = true;
            }
        }

        //----------------------------------------------------------------------------------

        // para solo el panel de vista general de los tickets

        private void cbPrioridadFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarTickets();
        }

        private void cbEstadoFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarTickets();
        }
        private void MostrarTickets()
        {
            string prioridad = cbPrioridadFiltro.Text;
            string estado = cbEstadoFiltro.Text;

            dg_Tickets.DataSource = null;

            List<Ticket> lTickets = nTicket.ListarPorTecnico(
                tecnicoActual.IdTecnico,
                prioridad,
                estado
            );

            if (lTickets.Count > 0)
            {
                dg_Tickets.DataSource = lTickets;

                dg_Tickets.Columns["Administrador"].Visible = false;
                dg_Tickets.Columns["Pabellon"].Visible = false;
                dg_Tickets.Columns["Sede"].Visible = false;
                dg_Tickets.Columns["Solicitante"].Visible = false;
                dg_Tickets.Columns["Tecnico"].Visible = false;
                dg_Tickets.Columns["TipoSolicitud"].Visible = false;

                dg_Tickets.Columns["FActualizacion"].Visible = false;
                dg_Tickets.Columns["IdAtendidoPor"].Visible = false;
                dg_Tickets.Columns["IdAsignadoPor"].Visible = false;

                dg_Tickets.Columns["IdTipoSolicitud"].HeaderText = "Tipo Solicitud";
                dg_Tickets.Columns["IdSede"].HeaderText = "Sede";
                dg_Tickets.Columns["IdPabellon"].HeaderText = "Pabellón";
                dg_Tickets.Columns["IdCreadoPor"].HeaderText = "Solicitante";

                dg_Tickets.Columns["IdTicket"].HeaderText = "N° Ticket";
                dg_Tickets.Columns["DTitulo"].HeaderText = "Título";
                dg_Tickets.Columns["DDescripcion"].HeaderText = "Descripción";
                dg_Tickets.Columns["DEstado"].HeaderText = "Estado";
                dg_Tickets.Columns["DPrioridad"].HeaderText = "Prioridad";
                dg_Tickets.Columns["DComentario"].HeaderText = "Comentario";
                dg_Tickets.Columns["FCreacion"].HeaderText = "Fecha Creación";
            }
        }

        //-------------------------------------------------------------------------------------------

        // para solo el detalle de un ticket
        private void btn_VerDetalle_Click(object sender, EventArgs e)
        {
            if (dg_Tickets.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un ticket");
                return;
            }
            int idTicket = int.Parse(dg_Tickets.SelectedRows[0].Cells["IdTicket"].Value.ToString());

            Ticket objTicket = nTicket.ObtenerPorId(idTicket);

            idTicketActual = objTicket.IdTicket;
            estadoOriginal = objTicket.DEstado;
            comentarioOriginal = objTicket.DComentario ?? "";

            lb_NumTicket.Text = "Detalle del Ticket N°"+objTicket.IdTicket.ToString();

            tb_DetTitulo.Text = objTicket.DTitulo;
            tb_DetTipo.Text = objTicket.TipoSolicitud.DNombre;
            tb_DetDescripcion.Text = objTicket.DDescripcion;
            tb_DetSede.Text = objTicket.Sede.DNombreSede;
            tb_DetPabellon.Text = objTicket.Pabellon.DNombrePabellon;
            tb_FechaActualizacion.Text = objTicket.FActualizacion.ToString();
            tb_FechaCreacion.Text = objTicket.FCreacion.ToString();
            tb_Comentario.Text = objTicket.DComentario ?? "";
            tb_CodigoSolicitante.Text = objTicket.Solicitante.CSolicitante.ToString();
            tb_Prioridad.Text = objTicket.DPrioridad;
            cb_EstadoActual.Text = objTicket.DEstado.ToString();

            MostrarPanel(pnl_DetalleTicket);
        }

        private bool HayCambiosSinGuardar()
        {
            if (idTicketActual == 0)
                return false;

            if (cb_EstadoActual.Text != estadoOriginal)
                return true;

            if (tb_Comentario.Text != comentarioOriginal)
                return true;

            return false;
        }

        private bool ValidarCambioEstado(string estadoAnterior, string estadoNuevo)
        {
            if (estadoAnterior == estadoNuevo)
                return true;

            if (estadoAnterior == "Asignado" && estadoNuevo == "En Proceso")
                return true;

            if (estadoAnterior == "En Proceso" && estadoNuevo == "Resuelto")
                return true;

            return false;
        }

        private void btn_ActualizarTicket_Click(object sender, EventArgs e)
        {
            string estadoNuevo = cb_EstadoActual.Text;
            string comentarioNuevo = tb_Comentario.Text;

            if (idTicketActual == 0)
            {
                MessageBox.Show("No hay un ticket seleccionado");
                return;
            }

            if (!ValidarCambioEstado(estadoOriginal, estadoNuevo))
            {
                MessageBox.Show("El cambio de estado no es válido");
                cb_EstadoActual.Text = estadoOriginal;
                return;
            }

            if (estadoNuevo == estadoOriginal && comentarioNuevo == comentarioOriginal)
            {
                MessageBox.Show("No se realizaron cambios");
                CerrarDetalleTicket();
                return;
            }

            string mensaje = nTicket.ActualizarTicketTecnico(
                idTicketActual,
                estadoNuevo,
                comentarioNuevo
            );

            MessageBox.Show(mensaje);

            estadoOriginal = estadoNuevo;
            comentarioOriginal = comentarioNuevo;

            CerrarDetalleTicket();
        }
        private void LimpiarDetalleTicket()
        {
            tb_DetTitulo.Clear();
            tb_DetTipo.Clear();
            tb_DetDescripcion.Clear();
            tb_DetSede.Clear();
            tb_DetPabellon.Clear();
            tb_FechaActualizacion.Clear();
            tb_FechaCreacion.Clear();
            tb_Comentario.Clear();
            tb_CodigoSolicitante.Clear();
            tb_Prioridad.Clear();

            cb_EstadoActual.SelectedIndex = -1;

            idTicketActual = 0;
            estadoOriginal = "";
            comentarioOriginal = "";
        }

        private void CerrarDetalleTicket()
        {
            LimpiarDetalleTicket();
            MostrarTickets();
            MostrarPanel(pnl_TicketsAsignados);
        }
        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            if (HayCambiosSinGuardar())
            {
                string estadoNuevo = cb_EstadoActual.Text;

                if (!ValidarCambioEstado(estadoOriginal, estadoNuevo))
                {
                    MessageBox.Show("No se puede realizar ese cambio de estado");

                    cb_EstadoActual.Text = estadoOriginal;
                    CerrarDetalleTicket();
                    return;
                }

                DialogResult respuesta = MessageBox.Show(
                    "No se guardaron los cambios. ¿Desea actualizar el ticket?",
                    "Cambios sin guardar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (respuesta == DialogResult.Yes)
                {
                    btn_ActualizarTicket_Click(sender, e);
                    return;
                }
            }

            CerrarDetalleTicket();
        }

        // EXPORTACIONES
        private void btn_DescargarListado_Click(object sender, EventArgs e)
        {
            string prioridad = cbPrioridadFiltro.Text;
            string estado = cbEstadoFiltro.Text;

            List<Ticket> lTickets = nTicket.ListarPorTecnico(
                tecnicoActual.IdTecnico,
                prioridad,
                estado
            );

            if (lTickets.Count == 0)
            {
                MessageBox.Show("No hay tickets para exportar con los filtros seleccionados");
                return;
            }

            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Filter = "Archivo CSV|*.csv";
            guardar.Title = "Guardar reporte de tickets";
            guardar.FileName = "Tickets_Tecnico.csv";

            if (guardar.ShowDialog() == DialogResult.OK)
            {
                ExportadorTickets.ExportarCsv(lTickets, guardar.FileName);
                MessageBox.Show("Reporte CSV descargado correctamente");
            }
        }

        private void btn_DescargarDetalle_Click(object sender, EventArgs e)
        {

            if (HayCambiosSinGuardar())
            {
                MessageBox.Show("Guarda los cambios antes de descargar la ficha del ticket");
                return;
            }

            Ticket objTicket = nTicket.ObtenerPorId(idTicketActual);

            if (objTicket == null)
            {
                MessageBox.Show("No se encontró el ticket");
                return;
            }

            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Filter = "Archivo PDF|*.pdf";
            guardar.Title = "Guardar ficha del ticket";
            guardar.FileName = "Ficha_Ticket_" + idTicketActual + ".pdf";

            if (guardar.ShowDialog() == DialogResult.OK)
            {
                ExportadorTickets.ExportarPdfTicket(objTicket, guardar.FileName);
                MessageBox.Show("PDF descargado correctamente");
            }
        }
    }
}
