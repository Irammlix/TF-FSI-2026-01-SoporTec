using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static CapaDatos.DClasesAuxiliares;

namespace CapaPresentacion
{
    public partial class FormReportes : Form
    {
        private static readonly Color ColorNavy = Color.Navy;
        private readonly NReporte nReporte = new NReporte();
        public FormReportes()
        {
            InitializeComponent();
            CargarReporte1();
            cbSedeReporte1.SelectedIndex = 0;
        }

        // REPORTE 1

        private void cbSedeReporte1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarReporte1();
        }

        private void btnSalirR1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExportarPdf_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            save.Filter = "PDF (*.pdf)|*.pdf";
            save.Title = "Guardar Reporte PDF";

            if (save.ShowDialog() == DialogResult.OK)
            {
                string rutaGrafico = Path.Combine(
                    Application.StartupPath,
                    "graficoReporte1.png");

                chartReporte1.SaveImage(
                    rutaGrafico,
                    ChartImageFormat.Png);

                ExportadorTickets.ExportarPdfReporte1(
                    save.FileName,
                    rutaGrafico,
                    lblFechaGenerado.Text,
                    cbSedeReporte1.Text,
                    lblNumerodeTickets.Text,
                    lblNumSinAsignar.Text + " (" + lblPorcentajeSinAsignar.Text + ")",
                    lblNumAsignado.Text + " (" + lblPorcentajeAsignado.Text + ")",
                    lblNumEnProceso.Text + " (" + lblPorcentajeEnProceso.Text + ")",
                    lblNumResuelto.Text + " (" + lblPorcentajeResuelto.Text + ")"
                );

                MessageBox.Show(
                    "Reporte exportado correctamente.",
                    "PDF",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

        }

        //refrescar
        private void button23_Click(object sender, EventArgs e)
        {
            CargarReporte1();
        }

        private void dgReporte1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgReporte1.Rows[e.RowIndex].DataBoundItem == null)
                return;

            Ticket ticket = dgReporte1.Rows[e.RowIndex].DataBoundItem as Ticket;

            if (ticket == null)
                return;

            string nombreColumna = dgReporte1.Columns[e.ColumnIndex].Name;

            if (nombreColumna == "IdSede")
            {
                e.Value = ticket.Sede.DNombreSede;
                e.FormattingApplied = true;
            }

            if (nombreColumna == "IdAtendidoPor")
            {
                if (ticket.Tecnico != null)
                {
                    e.Value = ticket.Tecnico.CTecnico;
                }
                else
                {
                    e.Value = "Sin asignar";
                }

                e.FormattingApplied = true;
            }

            if (nombreColumna == "DPrioridad")
            {
                if (ticket.DEstado == "Sin Asignar" ||
                    string.IsNullOrWhiteSpace(ticket.DPrioridad))
                {
                    e.Value = "-";
                    e.FormattingApplied = true;
                }
            }
        }

        //botones
        private void btnLimpiarFiltrosR1_Click_1(object sender, EventArgs e)
        {
            cbSedeReporte1.SelectedIndex = 0;
        }

        private double CalcularPorcentaje(int cantidad, int total)
        {
            if (total == 0)
                return 0;

            return Math.Round((cantidad * 100.0) / total, 2);
        }

        private void CargarReporte1()
        {
            string sede = cbSedeReporte1.Text;

            if (string.IsNullOrWhiteSpace(sede))
                sede = "Todos";

            List<Ticket> tickets = nReporte.ListarTicketReporteEstado(sede);

            int total = tickets.Count;

            int sinAsignar = tickets
                .Where(t => t.DEstado == "Sin Asignar")
                .Count();

            int asignado = tickets
                .Where(t => t.DEstado == "Asignado")
                .Count();

            int enProceso = tickets
                .Where(t => t.DEstado == "En Proceso")
                .Count();

            int resuelto = tickets
                .Where(t => t.DEstado == "Resuelto")
                .Count();

            lblFechaGenerado.Text = "Fecha de Generacion de Reporte:  " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            lblNumerodeTickets.Text = total.ToString() + " tickets";

            lblPorcentajeSinAsignar.Text = CalcularPorcentaje(sinAsignar, total) + "%";
            lblNumSinAsignar.Text = sinAsignar.ToString() + " tickets";

            lblPorcentajeAsignado.Text = CalcularPorcentaje(asignado, total) + "%";
            lblNumAsignado.Text = asignado.ToString() + " tickets";

            lblPorcentajeEnProceso.Text = CalcularPorcentaje(enProceso, total) + "%";
            lblNumEnProceso.Text = enProceso.ToString() + " tickets";

            lblPorcentajeResuelto.Text = CalcularPorcentaje(resuelto, total) + "%";
            lblNumResuelto.Text = resuelto.ToString() + " tickets";

            CargarGraficoReporte1(sinAsignar, asignado, enProceso, resuelto, total);
            CargarTablaReporte1(tickets);
        }

        private void CargarGraficoReporte1(int sinAsignar, int asignado, int enProceso, int resuelto, int total)
        {
            chartReporte1.Series.Clear();
            chartReporte1.ChartAreas.Clear();
            chartReporte1.Legends.Clear();

            chartReporte1.BorderlineColor = ColorNavy;
            chartReporte1.BorderlineWidth = 2;
            chartReporte1.BorderlineDashStyle = ChartDashStyle.Solid;

            ChartArea area = new ChartArea();
            area.BackColor = System.Drawing.Color.White;
            chartReporte1.ChartAreas.Add(area);

            Series serie = new Series("Estados");
            serie.ChartType = SeriesChartType.Doughnut;
            serie.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            serie.LabelForeColor = System.Drawing.Color.Black;

            double porcSinAsignar = CalcularPorcentaje(sinAsignar, total);
            double porcAsignado = CalcularPorcentaje(asignado, total);
            double porcEnProceso = CalcularPorcentaje(enProceso, total);
            double porcResuelto = CalcularPorcentaje(resuelto, total);

            int p1 = serie.Points.AddY(sinAsignar);
            serie.Points[p1].Label = porcSinAsignar == 0 ? "" : porcSinAsignar + "%";
            serie.Points[p1].ToolTip = $"Sin Asignar: {sinAsignar} tickets - {porcSinAsignar}%";
            serie.Points[p1].Color = System.Drawing.Color.Firebrick;

            int p2 = serie.Points.AddY(asignado);
            serie.Points[p2].Label = porcAsignado == 0 ? "" : porcAsignado + "%";
            serie.Points[p2].ToolTip = $"Asignado: {asignado} tickets - {porcAsignado}%";
            serie.Points[p2].Color = System.Drawing.Color.DarkBlue;
            serie.Points[p2].LabelForeColor = System.Drawing.Color.White; 

            int p3 = serie.Points.AddY(enProceso);
            serie.Points[p3].Label = porcEnProceso == 0 ? "" : porcEnProceso + "%";
            serie.Points[p3].ToolTip = $"En Proceso: {enProceso} tickets - {porcEnProceso}%";
            serie.Points[p3].Color = System.Drawing.Color.Gold;

            int p4 = serie.Points.AddY(resuelto);
            serie.Points[p4].Label = porcResuelto == 0 ? "" : porcResuelto + "%";
            serie.Points[p4].ToolTip = $"Resuelto: {resuelto} tickets - {porcResuelto}%";
            serie.Points[p4].Color = System.Drawing.Color.SeaGreen;

            chartReporte1.Series.Add(serie);
        }

        private void CargarTablaReporte1(List<Ticket> tickets)
        {
            dgReporte1.DataSource = null;
            dgReporte1.DataSource = tickets;

            // Ocultar todo primero
            foreach (DataGridViewColumn columna in dgReporte1.Columns)
            {
                columna.Visible = false;
            }

            // Mostrar solo lo necesario
            dgReporte1.Columns["IdTicket"].Visible = true;
            dgReporte1.Columns["IdAtendidoPor"].Visible = true;
            dgReporte1.Columns["IdSede"].Visible = true;
            dgReporte1.Columns["DEstado"].Visible = true;
            dgReporte1.Columns["DPrioridad"].Visible = true;

            // Encabezados bonitos
            dgReporte1.Columns["IdTicket"].HeaderText = "N° Ticket";
            dgReporte1.Columns["IdAtendidoPor"].HeaderText = "Técnico";
            dgReporte1.Columns["IdSede"].HeaderText = "Sede";
            dgReporte1.Columns["DEstado"].HeaderText = "Estado";
            dgReporte1.Columns["DPrioridad"].HeaderText = "Prioridad";

            dgReporte1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

    }
}
