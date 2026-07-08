using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static CapaDatos.DClasesAuxiliares;

namespace CapaPresentacion
{
    public partial class FormReportes5 : Form
    {
        // ======== Paleta (misma plantilla que los demás reportes) ========
        private static readonly Color ColorNavy = Color.Navy;
        private static readonly Color ColorResaltado = Color.FromArgb(192, 57, 43);

        // Colores fijos por tipo de incidencia (coinciden con la leyenda del Designer).
        // Los nombres son los que realmente existen en la tabla TipoSolicitud.
        private static readonly Dictionary<string, Color> ColoresPorTipo = new Dictionary<string, Color>
        {
            { "Problema de conectividad", Color.FromArgb(66, 133, 244) },
            { "Falla física de equipo", Color.FromArgb(234, 67, 53) },
            { "Error en aplicación", Color.FromArgb(52, 168, 83) },
            { "Problema de acceso", Color.FromArgb(251, 188, 5) },
            { "Error en base de datos", Color.FromArgb(155, 89, 182) },
        };
        private static readonly Color ColorTipoDesconocido = Color.Gray;

        private readonly NReporte nReporte = new NReporte();
        private readonly NSede nSede = new NSede();
        private List<NReporte.ConteoTipo> datosActuales = new List<NReporte.ConteoTipo>();

        public FormReportes5()
        {
            InitializeComponent();
        }

        private void FormReportes5_Load(object sender, EventArgs e)
        {
            CargarSedes();
            CargarReporte();
        }

        // ---------- Lógica de datos ----------

        private void CargarSedes()
        {
            cboSede.Items.Clear();
            cboSede.Items.Add("Todas");
            try
            {
                var sedes = nSede.ListarTodo();
                foreach (var s in sedes)
                    cboSede.Items.Add(s.DNombreSede);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            cboSede.SelectedIndex = 0;
        }

        private void CargarReporte()
        {
            if (cboSede.SelectedItem == null)
                return;

            string sede = cboSede.SelectedItem.ToString();

            datosActuales = nReporte.TicketsPorTipo(sede);

            lblFechaGenerado.Text = "Fecha de Generación de Reporte: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            // Gráfico de pastel
            Series serie = chartTipos.Series[0];
            serie.Points.Clear();

            int total = datosActuales.Sum(d => d.Cantidad);

            foreach (var c in datosActuales)
            {
                int idx = serie.Points.AddY(c.Cantidad);
                double porcentaje = total > 0 ? c.Cantidad * 100.0 / total : 0;
                serie.Points[idx].AxisLabel = c.TipoSolicitud;
                serie.Points[idx].Label = c.TipoSolicitud + ": " + c.Cantidad + " (" + porcentaje.ToString("0.#") + "%)";
                serie.Points[idx].Color = ObtenerColorTipo(c.TipoSolicitud);
            }

            // KPIs
            kpiTotal.Text = total.ToString();

            if (datosActuales.Count > 0)
            {
                var top = datosActuales.OrderByDescending(d => d.Cantidad).First();
                kpiTipoFrecuente.Text = top.TipoSolicitud;
                kpiTipoFrecuenteCant.Text = top.Cantidad.ToString();

                double? variacion = nReporte.CalcularVariacionMensualTipo(top.TipoSolicitud, sede);
                if (variacion == null)
                {
                    kpiVariacion.Text = "N/D";
                    kpiVariacion.ForeColor = Color.Gray;
                }
                else if (variacion > 0)
                {
                    kpiVariacion.Text = "+" + variacion.Value.ToString("0.#") + "%";
                    kpiVariacion.ForeColor = ColorResaltado;
                }
                else if (variacion < 0)
                {
                    kpiVariacion.Text = variacion.Value.ToString("0.#") + "%";
                    kpiVariacion.ForeColor = Color.SeaGreen;
                }
                else
                {
                    kpiVariacion.Text = "0%";
                    kpiVariacion.ForeColor = ColorNavy;
                }
            }
            else
            {
                kpiTipoFrecuente.Text = "-";
                kpiTipoFrecuenteCant.Text = "0";
                kpiVariacion.Text = "-";
                kpiVariacion.ForeColor = ColorNavy;
            }

            // Reset del detalle
            dgvDetalle.DataSource = null;
            lblDetalleTitulo.Text = "Detalle: (haz clic en una porción)";
        }

        private Color ObtenerColorTipo(string tipoSolicitud)
        {
            if (tipoSolicitud != null && ColoresPorTipo.ContainsKey(tipoSolicitud))
                return ColoresPorTipo[tipoSolicitud];
            return ColorTipoDesconocido;
        }

        private void chartTipos_MouseClick(object sender, MouseEventArgs e)
        {
            HitTestResult h = chartTipos.HitTest(e.X, e.Y);
            if (h.ChartElementType != ChartElementType.DataPoint || h.PointIndex < 0)
                return;

            DataPoint punto = chartTipos.Series[0].Points[h.PointIndex];
            string tipo = punto.AxisLabel;
            CargarDetalle(tipo);
        }

        private void CargarDetalle(string tipoSolicitud)
        {
            string sede = cboSede.SelectedItem?.ToString() ?? "Todas";

            List<TicketVistaAdmin> detalle = nReporte.DetalleTicketsTipo(tipoSolicitud, sede);

            var vista = detalle.Select(t => new
            {
                Id = t.IdTicket,
                Título = t.Titulo,
                Sede = t.Sede,
                Estado = t.Estado,
                Prioridad = t.Prioridad,
                Creación = t.FCreacion.ToString("dd/MM/yyyy")
            }).ToList();

            dgvDetalle.DataSource = vista;
            lblDetalleTitulo.Text = "Detalle: " + tipoSolicitud + "  (" + detalle.Count + " tickets)";
        }

        private void LimpiarFiltros()
        {
            if (cboSede.Items.Count > 0)
                cboSede.SelectedIndex = 0;
            CargarReporte();
        }

        // ---------- Exportar a PDF (vista previa -> Microsoft Print to PDF) ----------
        private void ExportarPdf()
        {
            if (datosActuales == null || datosActuales.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.");
                return;
            }

            PrintDocument doc = new PrintDocument { DocumentName = "Reporte RF-20 - Tickets por Tipo de Incidencia" };
            doc.PrintPage += Doc_PrintPage;

            using (PrintPreviewDialog preview = new PrintPreviewDialog { Document = doc, WindowState = FormWindowState.Maximized })
            {
                preview.ShowDialog();
            }
        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            float x = 50, y = 50;
            float ancho = e.PageBounds.Width - 100;

            string sede = cboSede.SelectedItem?.ToString() ?? "Todas";

            g.FillRectangle(new SolidBrush(ColorNavy), x, y, ancho, 46);
            g.DrawString("SoporTec — Tickets por Tipo de Incidencia", new Font("Segoe UI", 16, FontStyle.Bold), Brushes.White, x + 12, y + 10);
            y += 58;

            g.DrawString("Sede: " + sede, new Font("Segoe UI", 11, FontStyle.Bold), Brushes.Black, x, y);
            g.DrawString("Generado: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), new Font("Segoe UI", 9), Brushes.Gray, x + ancho - 220, y + 4);
            y += 34;

            int total = datosActuales.Sum(d => d.Cantidad);
            g.DrawString("Total de tickets: " + total, new Font("Segoe UI", 10), Brushes.Black, x, y);
            y += 30;

            var fH = new Font("Segoe UI", 10, FontStyle.Bold);
            var fC = new Font("Segoe UI", 10);
            g.FillRectangle(new SolidBrush(Color.FromArgb(237, 239, 242)), x, y, ancho, 26);
            g.DrawString("Tipo de Incidencia", fH, Brushes.Black, x + 8, y + 4);
            g.DrawString("Cantidad", fH, Brushes.Black, x + ancho - 260, y + 4);
            g.DrawString("Porcentaje", fH, Brushes.Black, x + ancho - 120, y + 4);
            y += 26;

            foreach (var d in datosActuales)
            {
                double porcentaje = total > 0 ? d.Cantidad * 100.0 / total : 0;
                g.DrawRectangle(Pens.Gainsboro, x, y, ancho, 24);
                g.DrawString(d.TipoSolicitud, fC, Brushes.Black, x + 8, y + 4);
                g.DrawString(d.Cantidad.ToString(), fC, Brushes.Black, x + ancho - 260, y + 4);
                g.DrawString(porcentaje.ToString("0.#") + "%", fC, Brushes.Black, x + ancho - 120, y + 4);
                y += 24;
            }

            e.HasMorePages = false;
        }

        // ---------- Manejadores de eventos (suscritos en InitializeComponent) ----------

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarReporte();
        }

        private void btnExportarPdf_Click(object sender, EventArgs e)
        {
            ExportarPdf();
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboSede_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarReporte();
        }
    }
}
