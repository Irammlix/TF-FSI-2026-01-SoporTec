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
    public partial class FormReportes2 : Form
    {
        private static readonly Color ColorNavy = Color.Navy;
        private readonly NReporte nReporte = new NReporte();
        public FormReportes2()
        {
            InitializeComponent();
            cb_FiltroEstado.SelectedIndex = 2;
            cb_FiltroSede.SelectedIndex = 4;
            CargarReporte2();

        }

        private void dg_Reporte2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dg_Reporte2.Rows[e.RowIndex].DataBoundItem == null)
                return;

            Ticket ticket = dg_Reporte2.Rows[e.RowIndex].DataBoundItem as Ticket;

            if (ticket == null)
                return;

            string nombreColumna = dg_Reporte2.Columns[e.ColumnIndex].Name;

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

        private void cb_FiltroEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarReporte2();
        }

        private void cb_FiltroSede_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarReporte2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            save.Filter = "PDF (*.pdf)|*.pdf";
            save.Title = "Guardar Reporte PDF";

            if (save.ShowDialog() == DialogResult.OK)
            {
                string rutaGrafico = Path.Combine(
                    Application.StartupPath,
                    "graficoReporte1.png");

                chartReporte2.SaveImage(
                    rutaGrafico,
                    ChartImageFormat.Png);

                ExportadorTickets.ExportarPdfReporte2(
                    save.FileName,
                    rutaGrafico,
                    lblFechaGenerado.Text,
                    cb_FiltroSede.Text,
                    cb_FiltroEstado.Text,
                    lblNumerodeTickets.Text,
                    lblNumBaja.Text + " (" + lblPorcentajeBaja.Text + ")",
                    lblNumMedia.Text + " (" + lblPorcentajeMedia.Text + ")",
                    lblNumAlta.Text + " (" + lblPorcentajeAlta.Text + ")"

                );

                MessageBox.Show(
                    "Reporte exportado correctamente.",
                    "PDF",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private double CalcularPorcentaje(int cantidad, int total)
        {
            if (total == 0)
                return 0;

            return Math.Round((cantidad * 100.0) / total, 2);
        }

        private void CargarReporte2()
        {
            string estado = cb_FiltroEstado.Text;
            string sede = cb_FiltroSede.Text;

            if (string.IsNullOrWhiteSpace(sede))
                sede = "Todos";

            List<Ticket> tickets = nReporte.ListarTicketReportePrioridad(estado,sede);

            int total = tickets.Count;

            int baja = nReporte.CantidadPrioridades("Baja", estado, sede);

            int media = nReporte.CantidadPrioridades("Media", estado, sede);
            int alta = nReporte.CantidadPrioridades("Alta", estado, sede);


            lblFechaGenerado.Text = "Fecha de Generacion de Reporte:  " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            lblNumerodeTickets.Text = total.ToString() + " tickets";

            lblPorcentajeBaja.Text = CalcularPorcentaje(baja, total) + "%";
            lblNumBaja.Text = baja.ToString() + " tickets";

            lblPorcentajeMedia.Text = CalcularPorcentaje(media, total) + "%";
            lblNumMedia.Text = media.ToString() + " tickets";

            lblPorcentajeAlta.Text = CalcularPorcentaje(alta, total) + "%";
            lblNumAlta.Text = alta.ToString() + " tickets";

            CargarGraficoReporte2(baja, media, alta, total);
            CargarTablaReporte2(tickets);
        }
        private void CargarGraficoReporte2(int baja, int media, int alta, int total)
        {
            chartReporte2.Series.Clear();
            chartReporte2.ChartAreas.Clear();
            chartReporte2.Legends.Clear();

            chartReporte2.BorderlineColor = ColorNavy;
            chartReporte2.BorderlineWidth = 2;
            chartReporte2.BorderlineDashStyle = ChartDashStyle.Solid;

            ChartArea area = new ChartArea();
            area.BackColor = System.Drawing.Color.White;
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.Enabled = false;
            chartReporte2.ChartAreas.Add(area);

            Series serie = new Series("Estados");
            serie.ChartType = SeriesChartType.Column;
            serie.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            serie.LabelForeColor = System.Drawing.Color.Black;

            double porcBaja = CalcularPorcentaje(baja, total);
            double porcMedia = CalcularPorcentaje(media, total);
            double porcAlta = CalcularPorcentaje(alta, total);

            int p1 = serie.Points.AddXY("Baja", baja);
            serie.Points[p1].Label = porcBaja == 0 ? "" : porcBaja + "%";
            serie.Points[p1].ToolTip = $"Baja: {baja} tickets - {porcBaja}%";
            serie.Points[p1].Color = System.Drawing.Color.DodgerBlue;
            serie.Points[p1].LabelForeColor = System.Drawing.Color.White; 

            int p2 = serie.Points.AddXY("Media", media);
            serie.Points[p2].Label = porcMedia == 0 ? "" : porcMedia + "%";
            serie.Points[p2].ToolTip = $"Media: {media} tickets - {porcMedia}%";
            serie.Points[p2].Color = System.Drawing.Color.Gold;

            int p3 = serie.Points.AddXY("Alta", alta);
            serie.Points[p3].Label = porcAlta == 0 ? "" : porcAlta + "%";
            serie.Points[p3].ToolTip = $"Alta: {alta} tickets - {porcAlta}%";
            serie.Points[p3].Color = System.Drawing.Color.FromArgb(227, 36, 43); 
            serie.Points[p3].LabelForeColor = System.Drawing.Color.White;

            chartReporte2.Series.Add(serie);
        }

        private void CargarTablaReporte2(List<Ticket> tickets)
        {
            dg_Reporte2.DataSource = null;
            dg_Reporte2.DataSource = tickets;

            // Ocultar todo primero
            foreach (DataGridViewColumn columna in dg_Reporte2.Columns)
            {
                columna.Visible = false;
            }

            // Mostrar solo lo necesario
            dg_Reporte2.Columns["IdTicket"].Visible = true;
            dg_Reporte2.Columns["IdAtendidoPor"].Visible = true;
            dg_Reporte2.Columns["IdSede"].Visible = true;
            dg_Reporte2.Columns["DEstado"].Visible = true;
            dg_Reporte2.Columns["DPrioridad"].Visible = true;

            // Encabezados bonitos :v
            dg_Reporte2.Columns["IdTicket"].HeaderText = "N° Ticket";
            dg_Reporte2.Columns["IdAtendidoPor"].HeaderText = "Técnico";
            dg_Reporte2.Columns["IdSede"].HeaderText = "Sede";
            dg_Reporte2.Columns["DEstado"].HeaderText = "Estado";
            dg_Reporte2.Columns["DPrioridad"].HeaderText = "Prioridad";

            dg_Reporte2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
     
        private void btn_LimpiarFiltros_Click(object sender, EventArgs e)
        {
            cb_FiltroEstado.SelectedIndex = 2;
            cb_FiltroSede.SelectedIndex = 4;
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Refrescar_Click(object sender, EventArgs e)
        {
            cb_FiltroEstado.SelectedIndex = 2;
            cb_FiltroSede.SelectedIndex = 4;
            lblFechaGenerado.Text = "Fecha de Generacion de Reporte:  " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            MessageBox.Show("Reporte actualizado: " + DateTime.Now.ToString());
            CargarReporte2();
        }
 
    }
}
