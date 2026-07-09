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
    public partial class FormReportes4 : Form
    {
        // ======== Paleta (tomada del diseño del formulario) ========
        private static readonly Color ColorNavy = Color.Navy;
        private static readonly Color ColorFondo = Color.FromArgb(242, 245, 250);
        private static readonly Color ColorBorde = Color.FromArgb(204, 211, 220);
        private static readonly Color ColorTituloReporte = Color.FromArgb(74, 127, 199);
        private static readonly Color ColorBarra = Color.FromArgb(100, 140, 190);
        private static readonly Color ColorResaltado = Color.FromArgb(192, 57, 43);

        // ======== RF-19: dependencias de datos ========
        private readonly NReporte nReporte = new NReporte();
        private readonly NSede nSede = new NSede();
        private List<NReporte.ConteoPabellon> datosActuales = new List<NReporte.ConteoPabellon>();

        public FormReportes4()
        {
            InitializeComponent();
        }

        private void FormReportes4_Load(object sender, EventArgs e)
        {
            CargarSedes();
            CargarReporte();
        }

        // ---------- Lógica de datos ----------

        private void CargarSedes()
        {
            cboSede.Items.Clear();
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

            if (cboSede.Items.Count > 0)
                cboSede.SelectedIndex = 0;
        }

        private void CargarReporte()
        {
            if (cboSede == null || cboSede.SelectedItem == null)
                return;

            string sede = cboSede.SelectedItem.ToString();
            string estado = cboEstado.SelectedItem?.ToString() ?? "Todos";
            bool descendente = cboOrden.SelectedIndex == 0;

            datosActuales = nReporte.TicketsPorPabellon(sede, estado, descendente);

            // Subtítulo + fecha de generación
            lblSubtitulo.Text = "Concentración de incidencias — Sede: " + sede;
            lblFechaGenerado.Text = "Fecha de Generación de Reporte: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            // Gráfico
            Series serie = chartPabellones.Series[0];
            serie.Points.Clear();

            int idxMax = -1, maxCant = -1;
            for (int i = 0; i < datosActuales.Count; i++)
            {
                int idx = serie.Points.AddY(datosActuales[i].Cantidad);
                serie.Points[idx].AxisLabel = datosActuales[i].Pabellon;
                serie.Points[idx].Color = ColorBarra;
                if (datosActuales[i].Cantidad > maxCant)
                {
                    maxCant = datosActuales[i].Cantidad;
                    idxMax = idx;
                }
            }
            if (idxMax >= 0)
                serie.Points[idxMax].Color = ColorResaltado;

            // KPIs
            int total = datosActuales.Sum(d => d.Cantidad);
            kpiTotal.Text = total.ToString();
            kpiPabActivos.Text = datosActuales.Count.ToString();
            if (datosActuales.Count > 0)
            {
                var top = datosActuales.OrderByDescending(d => d.Cantidad).First();
                kpiPabTop.Text = top.Pabellon;
                kpiPabTopCant.Text = top.Cantidad.ToString();
            }
            else
            {
                kpiPabTop.Text = "-";
                kpiPabTopCant.Text = "0";
            }

            // Reset del detalle
            dgvDetalle.DataSource = null;
            lblDetalleTitulo.Text = "Detalle: (haz clic en una barra)";
        }

        private void chartPabellones_MouseClick(object sender, MouseEventArgs e)
        {
            HitTestResult h = chartPabellones.HitTest(e.X, e.Y);
            if (h.ChartElementType != ChartElementType.DataPoint || h.PointIndex < 0)
                return;

            DataPoint punto = chartPabellones.Series[0].Points[h.PointIndex];
            string pabellon = punto.AxisLabel;
            CargarDetalle(pabellon);
        }

        private void CargarDetalle(string pabellon)
        {
            string sede = cboSede.SelectedItem.ToString();
            string estado = cboEstado.SelectedItem?.ToString() ?? "Todos";

            List<TicketVistaAdmin> detalle = nReporte.DetalleTicketsPabellon(sede, pabellon, estado);

            var vista = detalle.Select(t => new
            {
                Id = t.IdTicket,
                Título = t.Titulo,
                Estado = t.Estado,
                Prioridad = t.Prioridad,
                Creación = t.FCreacion.ToString("dd/MM/yyyy")
            }).ToList();

            dgvDetalle.DataSource = vista;
            lblDetalleTitulo.Text = "Detalle: " + pabellon + "  (" + detalle.Count + " tickets)";
        }

        private void LimpiarFiltros()
        {
            cboEstado.SelectedIndex = 0;
            cboOrden.SelectedIndex = 0;
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

            PrintDocument doc = new PrintDocument { DocumentName = "Reporte RF-19 - Tickets por Pabellón" };
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

            string sede = cboSede.SelectedItem.ToString();

            g.FillRectangle(new SolidBrush(ColorNavy), x, y, ancho, 46);
            g.DrawString("SoporTec — Tickets por Sede y Pabellón", new Font("Segoe UI", 16, FontStyle.Bold), Brushes.White, x + 12, y + 10);
            y += 58;

            g.DrawString("Sede: " + sede, new Font("Segoe UI", 11, FontStyle.Bold), Brushes.Black, x, y);
            g.DrawString("Generado: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), new Font("Segoe UI", 9), Brushes.Gray, x + ancho - 220, y + 4);
            y += 34;

            int total = datosActuales.Sum(d => d.Cantidad);
            g.DrawString("Total de tickets en la sede: " + total, new Font("Segoe UI", 10), Brushes.Black, x, y);
            y += 30;

            // Encabezado tabla
            var fH = new Font("Segoe UI", 10, FontStyle.Bold);
            var fC = new Font("Segoe UI", 10);
            g.FillRectangle(new SolidBrush(Color.FromArgb(237, 239, 242)), x, y, ancho, 26);
            g.DrawString("Pabellón", fH, Brushes.Black, x + 8, y + 4);
            g.DrawString("Cantidad de tickets", fH, Brushes.Black, x + ancho - 200, y + 4);
            y += 26;

            foreach (var d in datosActuales)
            {
                g.DrawRectangle(Pens.Gainsboro, x, y, ancho, 24);
                g.DrawString(d.Pabellon, fC, Brushes.Black, x + 8, y + 4);
                g.DrawString(d.Cantidad.ToString(), fC, Brushes.Black, x + ancho - 200, y + 4);
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

        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarReporte();
        }

        private void cboOrden_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarReporte();
        }
    }
}
