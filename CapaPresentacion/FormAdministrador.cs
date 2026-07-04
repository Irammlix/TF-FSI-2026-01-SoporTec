using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static CapaDatos.DClasesAuxiliares;

namespace CapaPresentacion
{
    public partial class FormAdministrador : Form
    {
        private NTecnico nTecnico = new NTecnico();
        private NTicket nTicket = new NTicket();
        private NEspecialidad nEspecialidad = new NEspecialidad();
        private NSede nSede = new NSede();
        //===========

        private List<Tecnico> _listaMisTecnicos = new List<Tecnico>();
        private List<Tecnico> _listaTecnicosRegistro = new List<Tecnico>();

        //============
        private bool _sidebarAbierto = false;
        private Timer _timerSidebar = new Timer();

        private const int SIDEBAR_CERRADO = 62;
        private const int SIDEBAR_ABIERTO = 260;

        private readonly Color _colorBotonActivo = Color.Navy;
        private readonly Color _colorBotonDeshabilitado = Color.FromArgb(228, 228, 231);

        private Administrador adminActual;

        public FormAdministrador() : this(null)
        {
        }

        public FormAdministrador(Administrador administrador)
        {
            adminActual = administrador;
            InitializeComponent();
            InicializarSidebar();
            CargarComboFiltro();
            CargarMisTecnicos();
            CargarCombosEspecialidadYSede();
            CargarGridTecnicos();
            LimpiarFormulario();

            MostrarTickets();

           
            btn_CancelarEdicion.Click += btn_CancelarEdicion_Click;
            this.FormClosing += FormAdministrador_FormClosing;
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


        //=====================================para navegar entre las secciones del sidebar
        private void MostrarTickets()
        {
            
            dg_Tickets.DataSource = null;
            List<TicketVistaAdmin> lTickets = nTicket.ListarTodoAdministrador();

            if (lTickets.Count > 0)
            {
        
                dg_Tickets.DataSource = lTickets;
                dg_Tickets.Columns["FCreacion"].HeaderText = "Fecha de Creacion";
                dg_Tickets.Columns["FActualizacion"].HeaderText = "Fecha de Actualizacion";
                dg_Tickets.Columns["NombreTecnicoAsignado"].HeaderText = "Tecnico Asignado";
            }
        }
        private void btn_NuevaSolicitud_Click_1(object sender, EventArgs e)
        {
            if (!ConfirmarSalidaSinGuardar())
                return;
            tb_TicketsBuscarID.Text = "";
            cb_FiltroEstado.SelectedIndex = -1;
            MostrarPanel(pnl_Tickets);
            MostrarTickets();
        }

        private void btn_Reportes_Click_1(object sender, EventArgs e)
        {
            if (!ConfirmarSalidaSinGuardar())
                return;

            MostrarPanel(pnl_Reportes);
        }

        private void btn_RegistrarTecnico_Click_1(object sender, EventArgs e)
        {
            if (!ConfirmarSalidaSinGuardar())
                return;

            MostrarPanel(pnl_RegistrarTecnico);
        }

        private void btn_MisTecnicos_Click_1(object sender, EventArgs e)
        {
            if (!ConfirmarSalidaSinGuardar())
                return;

            MostrarPanel(pnl_MisTecnicos);
            CargarMisTecnicos();
        }

        private void btn_CerrarSesion_Click(object sender, EventArgs e)
        {
            if (!ConfirmarSalidaSinGuardar())
                return;
            FormPrincipal formPrincipal = new FormPrincipal();
            formPrincipal.Show();
            this.Close();
        }
        //============================================= para panel mis tecnicos
        private void CargarComboFiltro()
        {
            cb_TicketsFiltrar.Items.Clear();
            cb_TicketsFiltrar.Items.Add("Todos");
            cb_TicketsFiltrar.Items.Add("Especialidad");
            cb_TicketsFiltrar.Items.Add("Sede");
            cb_TicketsFiltrar.Items.Add("Cantidad de Tickets");
            cb_TicketsFiltrar.SelectedIndex = 0;
        }
        private void CargarMisTecnicos()
        {
            string filtro = tb_BuscarNombre.Text.Trim();
            string orden = cb_TicketsFiltrar.SelectedItem != null
                ? cb_TicketsFiltrar.SelectedItem.ToString()
                : "Todos";

            _listaMisTecnicos = nTecnico.ListarConDetalle(filtro, orden);

            dg_MisTecnicos.DataSource = _listaMisTecnicos
                .Select(t => new
                {
                    t.IdTecnico,
                    Codigo = t.CTecnico,
                    Nombre = t.DNombres + " " + t.DApellidos,
                    Especialidad = t.Especialidad.DNombre,
                    Sede = t.Sede.DNombreSede,
                    CantidadTickets = t.Ticket.Count
                })
                .ToList();

            btn_VerDetall.Enabled = false;
        }

        private void tb_BuscarNombre_TextChanged_1(object sender, EventArgs e)
        {
            CargarMisTecnicos();
        }
        private void cb_TicketsFiltrar_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            CargarMisTecnicos();
        }

        private void dg_MisTecnicos_SelectionChanged(object sender, EventArgs e)
        {
            btn_VerDetall.Enabled = dg_MisTecnicos.SelectedRows.Count > 0;
        }

        private void btn_VerDetall_Click(object sender, EventArgs e)
        {
            if (dg_MisTecnicos.SelectedRows.Count == 0)
                return;

            int idTecnico = (int)dg_MisTecnicos.SelectedRows[0].Cells["IdTecnico"].Value;
            Tecnico tecnico = _listaMisTecnicos.FirstOrDefault(t => t.IdTecnico == idTecnico);

            if (tecnico == null)
                return;

            pnl_MisTecnicos.Visible = false;
            pbl_TicketsDeTecnico.Visible = true;
            CargarDetalleTecnico(tecnico);
            CargarTicketsDeTecnico(tecnico.IdTecnico);
           
        }
        //=========== para panel tickets de tecnicos
        private void CargarDetalleTecnico(Tecnico tecnico)
        {
            tb_DetTicketTecNombre.Text = tecnico.DNombres + " " + tecnico.DApellidos;
            tb_DetTicketTecCodigo.Text = tecnico.CTecnico;
            tb_DetTicketTecEspecialidad.Text = tecnico.Especialidad.DNombre;
            tb_DetTicketTecSede.Text = tecnico.Sede.DNombreSede;
            tb_DetTicketTecFechaCrea.Text = tecnico.FCreacion.ToString("dd/MM/yyyy");
        }
        private void CargarTicketsDeTecnico(int idTecnico)
        {
            List<Ticket> tickets = nTicket.ListarPorTecnico(idTecnico, "Todos", "Todos");

            dg_TicketsDeTecnico.DataSource = tickets
                .Select(t => new
                {
                    t.IdTicket,
                    t.DTitulo,
                    TipoSolicitud = t.TipoSolicitud.DNombre,
                    t.DEstado,
                    t.DPrioridad,
                    t.FCreacion,
                    t.FActualizacion
                })
                .ToList();

        }

        private void btn_CerrarDetalleTicketTec_Click(object sender, EventArgs e)
        {
            pbl_TicketsDeTecnico.Visible = false;
            pnl_MisTecnicos.Visible = true;
        }

        ///===== para el panel de registrar tecnicos
        private void CargarCombosEspecialidadYSede()
        {
            cb_Especialidad.DataSource = nEspecialidad.ListarTodo();
            cb_Especialidad.DisplayMember = "DNombre";
            cb_Especialidad.ValueMember = "IdEspecialidad";

            cb_Sede.DataSource = nSede.ListarTodo();
            cb_Sede.DisplayMember = "DNombreSede";
            cb_Sede.ValueMember = "IdSede";
        }
        private void CargarGridTecnicos()
        {
            _listaTecnicosRegistro = nTecnico.ListarConDetalle("", "Todos");

            dataGridView1.DataSource = _listaTecnicosRegistro
                .Select(t => new
                {
                    t.IdTecnico,
                    Codigo = t.CTecnico,
                    Nombre = t.DNombres + " " + t.DApellidos,
                    Especialidad = t.Especialidad.DNombre,
                    t.DCorreo
                })
                .ToList();
        }
        private void LimpiarFormulario()
        {
            tb_CodigoTecnico.Text = "";
            tb_NombreTec.Text = "";
            tb_ApellidosTecnico.Text = "";
            tb_Correo.Text = "";
            tb_Contraseña.Text = "";
            cb_Especialidad.SelectedIndex = -1;
            cb_Sede.SelectedIndex = -1;

            tb_CodigoTecnico.Enabled = true;
            tb_Contraseña.Enabled = true;

            btn_RegistrarSolicitud.Enabled = true;
            btn_RegistrarSolicitud.BackColor = _colorBotonActivo;
            btn_ModificarTecnico.Enabled = false;
            btn_ModificarTecnico.BackColor = _colorBotonDeshabilitado;
            btn_CancelarEdicion.Visible = false;
        }

        private void btn_CancelarEdicion_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            LimpiarFormulario();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                LimpiarFormulario();
                return;
            }

            int idTecnico = (int)dataGridView1.SelectedRows[0].Cells["IdTecnico"].Value;
            Tecnico tecnico = _listaTecnicosRegistro.FirstOrDefault(t => t.IdTecnico == idTecnico);

            if (tecnico == null)
                return;

            tb_CodigoTecnico.Text = tecnico.CTecnico;
            tb_NombreTec.Text = tecnico.DNombres;
            tb_ApellidosTecnico.Text = tecnico.DApellidos;
            tb_Correo.Text = tecnico.DCorreo;
            cb_Especialidad.SelectedValue = tecnico.IdEspecialidad;
            cb_Sede.SelectedValue = tecnico.IdSede;

            tb_CodigoTecnico.Enabled = false;
            tb_Contraseña.Text = "";
            tb_Contraseña.Enabled = false;

            btn_RegistrarSolicitud.Enabled = false;
            btn_RegistrarSolicitud.BackColor = _colorBotonDeshabilitado;
            btn_ModificarTecnico.Enabled = true;
            btn_ModificarTecnico.BackColor = _colorBotonActivo;
            btn_CancelarEdicion.Visible = true;
        }

        private void btn_RegistrarSolicitud_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_CodigoTecnico.Text) ||
                string.IsNullOrWhiteSpace(tb_NombreTec.Text) ||
                string.IsNullOrWhiteSpace(tb_ApellidosTecnico.Text) ||
                string.IsNullOrWhiteSpace(tb_Correo.Text) ||
                string.IsNullOrWhiteSpace(tb_Contraseña.Text) ||
                cb_Especialidad.SelectedValue == null ||
                cb_Sede.SelectedValue == null)
            {
                MessageBox.Show("Todos los campos son obligatorios");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Desea registrar este técnico?",
                "Confirmar registro",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta != DialogResult.Yes)
                return;

            Tecnico tecnico = new Tecnico
            {
                CTecnico = tb_CodigoTecnico.Text.Trim(),
                DNombres = tb_NombreTec.Text.Trim(),
                DApellidos = tb_ApellidosTecnico.Text.Trim(),
                DCorreo = tb_Correo.Text.Trim(),
                DContrasena = tb_Contraseña.Text,
                IdEspecialidad = (int)cb_Especialidad.SelectedValue,
                IdSede = (int)cb_Sede.SelectedValue
            };

            MessageBox.Show(nTecnico.Registrar(tecnico));

            CargarGridTecnicos();
            LimpiarFormulario();
        }


        private void btn_ModificarTecnico_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un técnico del listado para modificar");
                return;
            }

            if (string.IsNullOrWhiteSpace(tb_NombreTec.Text) ||
                string.IsNullOrWhiteSpace(tb_ApellidosTecnico.Text) ||
                string.IsNullOrWhiteSpace(tb_Correo.Text) ||
                cb_Especialidad.SelectedValue == null ||
                cb_Sede.SelectedValue == null)
            {
                MessageBox.Show("Todos los campos son obligatorios");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Desea guardar los cambios de este técnico?",
                "Confirmar modificación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta != DialogResult.Yes)
                return;

            int idTecnico = (int)dataGridView1.SelectedRows[0].Cells["IdTecnico"].Value;

            Tecnico tecnico = new Tecnico
            {
                IdTecnico = idTecnico,
                DNombres = tb_NombreTec.Text.Trim(),
                DApellidos = tb_ApellidosTecnico.Text.Trim(),
                DCorreo = tb_Correo.Text.Trim(),
                IdEspecialidad = (int)cb_Especialidad.SelectedValue,
                IdSede = (int)cb_Sede.SelectedValue
            };

            MessageBox.Show(nTecnico.Modificar(tecnico));

            CargarGridTecnicos();
            LimpiarFormulario();
        }

        private bool HayCambiosSinGuardar()
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return !string.IsNullOrWhiteSpace(tb_CodigoTecnico.Text) ||
                       !string.IsNullOrWhiteSpace(tb_NombreTec.Text) ||
                       !string.IsNullOrWhiteSpace(tb_ApellidosTecnico.Text) ||
                       !string.IsNullOrWhiteSpace(tb_Correo.Text) ||
                       !string.IsNullOrWhiteSpace(tb_Contraseña.Text) ||
                       cb_Especialidad.SelectedIndex != -1 ||
                       cb_Sede.SelectedIndex != -1;
            }

            int idTecnico = (int)dataGridView1.SelectedRows[0].Cells["IdTecnico"].Value;
            Tecnico original = _listaTecnicosRegistro.FirstOrDefault(t => t.IdTecnico == idTecnico);

            if (original == null)
                return false;

            return tb_NombreTec.Text != original.DNombres ||
                   tb_ApellidosTecnico.Text != original.DApellidos ||
                   tb_Correo.Text != original.DCorreo ||
                   (int)cb_Especialidad.SelectedValue != original.IdEspecialidad ||
                   (int)cb_Sede.SelectedValue != original.IdSede;
        }

        private bool ConfirmarSalidaSinGuardar()
        {
            if (!HayCambiosSinGuardar())
                return true;

            DialogResult respuesta = MessageBox.Show(
                "Tiene cambios sin guardar en el formulario de técnico. ¿Desea continuar sin guardar?",
                "Cambios sin guardar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            return respuesta == DialogResult.Yes;
        }

        private void MostrarPanel(Panel panelDestino)
        {
            pnl_MisTecnicos.Visible = false;
            pnl_RegistrarTecnico.Visible = false;
            pnl_Tickets.Visible = false;
            pnl_Reportes.Visible = false;
            pbl_TicketsDeTecnico.Visible = false;
            pnl_AsignarTicket.Visible = false;
            pnl_DetalleTicket.Visible = false;

            panelDestino.Visible = true;
        }

        private void FormAdministrador_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ConfirmarSalidaSinGuardar())
                e.Cancel = true;
        }

        private void btn_VerDetalle_Click(object sender, EventArgs e)
        {
            if(dg_Tickets.Rows.Count == 0)
            {
                return;
            }
            if(dg_Tickets.SelectedRows.Count<1)
            {
                MessageBox.Show("Seleccione una fila ticket para ver el detalle");
            }

        }

        private void cb_FiltroEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if(cb_FiltroEstado.Text.Equals("Listar Todos Los Estados"))
            {
                MostrarTickets();
                return;
            }
           
            dg_Tickets.DataSource=nTicket.ListarTicketsEstado(cb_FiltroEstado.Text);
            

        }

        private void tb_TicketsBuscarID_TextChanged(object sender, EventArgs e)
        {
           
            dg_Tickets.DataSource=nTicket.ObtenerTitutloOID(tb_TicketsBuscarID.Text);

        }
    }
}