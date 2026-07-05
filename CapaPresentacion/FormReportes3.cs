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
    public partial class FormReportes3 : Form
    {
        private NReporte nReporte = new NReporte();
        public FormReportes3()
        {
            InitializeComponent();
            lblFechaGeneracion.Text = "Generado: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            MostrarReporteTecnicos();
            CargarTecnicos();
            CargarEstados();
        }
        private void MostrarReporteTecnicos()
        {

            string tecnico = cbTecnico.SelectedItem?.ToString();

            string estado =cbEstado.SelectedItem?.ToString();

            List<ReporteTecnico> lista = nReporte.ObtenerRendimientoPorTecnico(tecnico,estado);

            chartTecnicos.Series.Clear();

            Series serieResueltos = new Series("Resueltos");

            serieResueltos.ChartType = SeriesChartType.StackedColumn;

            serieResueltos.Color = Color.Blue;

            Series seriePendientes = new Series("Pendientes");

            seriePendientes.ChartType = SeriesChartType.StackedColumn;

            seriePendientes.Color = Color.Red;

            int totalResueltos = 0;
            int totalPendientes = 0;

            string cuelloBotella = "Ninguno";

            int mayorDiferencia = 0;

            foreach (ReporteTecnico r in lista)
            {
                serieResueltos.Points.AddXY(
                    r.NombreTecnico,
                    r.CantidadResueltos);

                seriePendientes.Points.AddXY(
                    r.NombreTecnico,
                    r.CantidadPendientes);

                totalResueltos += r.CantidadResueltos;
                totalPendientes += r.CantidadPendientes;

                if (r.CantidadPendientes > r.CantidadResueltos)
                {
                    int diferencia = r.CantidadPendientes - r.CantidadResueltos;

                    if (diferencia > mayorDiferencia)
                    {
                        mayorDiferencia = diferencia;

                        cuelloBotella = r.NombreTecnico;
                    }
                }
            }

            chartTecnicos.Series.Add(serieResueltos);

            chartTecnicos.Series.Add(seriePendientes);

            lblTotalTickets.Text =(totalResueltos + totalPendientes).ToString();

            lblTotalResueltos.Text = totalResueltos.ToString();

            lblTotalPendientes.Text = totalPendientes.ToString();

            lblCuelloBotella.Text = cuelloBotella;
        }

        private void MostrarDetalleTecnico(string tecnico)
        {
            dgDetalleTecnicos.DataSource =
                nReporte.ObtenerDetalleTecnico(
                    tecnico);
        }
        private void btnRefrescar_Click_1(object sender, EventArgs e)
        {
            MostrarReporteTecnicos();
            dgDetalleTecnicos.DataSource = null;

            lblFechaGeneracion.Text ="Generado: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }

        private void btnExportarPdf_Click(object sender, EventArgs e)
        {

            PrintDocument doc = new PrintDocument();

            doc.DocumentName ="Reporte Rendimiento Tecnicos";

            doc.PrintPage += Doc_PrintPage;

            PrintPreviewDialog vista =
                new PrintPreviewDialog();

            vista.Document = doc;

            vista.WindowState =
                FormWindowState.Maximized;

            vista.ShowDialog();

        }

        private void Doc_PrintPage(object sender,PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            float x = 50;
            float y = 50;
            float ancho = e.PageBounds.Width - 100;

            Color colorNavy = Color.Navy;
            Color colorGris = Color.FromArgb(237, 239, 242);

            Font titulo = new Font("Segoe UI", 16, FontStyle.Bold);
            Font subtitulo = new Font("Segoe UI", 11, FontStyle.Bold);
            Font normal = new Font("Segoe UI", 9);

            // Encabezado

            g.FillRectangle(
                new SolidBrush(colorNavy),
                x,
                y,
                ancho,
                50);

            g.DrawString(
                "SOPORTEC",
                titulo,
                Brushes.White,
                x + 12,
                y + 10);

            y += 70;

            g.DrawString(
                "Reporte de rendimiento por técnico",
                subtitulo,
                Brushes.Black,
                x,
                y);

            y += 30;

            g.DrawString(
                lblFechaGeneracion.Text,
                normal,
                Brushes.Gray,
                x,
                y);

            y += 35;

            // Resumen

            g.DrawString(
                "Resumen General",
                subtitulo,
                Brushes.Navy,
                x,
                y);

            y += 25;

            g.FillRectangle(
                new SolidBrush(colorGris),
                x,
                y,
                ancho,
                35);

            g.DrawString(
                "Total Tickets: " +
                lblTotalTickets.Text,
                normal,
                Brushes.Black,
                x + 10,
                y + 10);

            g.DrawString(
                "Resueltos: " +
                lblTotalResueltos.Text,
                normal,
                Brushes.Black,
                x + 180,
                y + 10);

            g.DrawString(
                "Pendientes: " +
                lblTotalPendientes.Text,
                normal,
                Brushes.Black,
                x + 330,
                y + 10);

            y += 55;

            Bitmap grafico = new Bitmap(chartTecnicos.Width,chartTecnicos.Height);

            chartTecnicos.DrawToBitmap(
                grafico,
                new Rectangle(
                    0,
                    0,
                    chartTecnicos.Width,
                    chartTecnicos.Height));

            g.DrawImage(
                grafico,
                x,
                y,
                500,
                220);

            y += 240;

            g.DrawString(
                "Posible cuello de botella: " +
                lblCuelloBotella.Text,
                subtitulo,
                Brushes.Black,
                x,
                y);

            y += 30;

            g.DrawLine(
                Pens.Navy,
                x,
                y,
                x + ancho,
                y);

            y += 25;

            // Detalle

            g.DrawString(
                "Detalle de tickets",
                subtitulo,
                Brushes.Navy,
                x,
                y);

            y += 30;

            g.FillRectangle(
                new SolidBrush(colorGris),
                x,
                y,
                ancho,
                25);

            g.DrawString("ID", normal, Brushes.Black, x + 10, y + 5);
            g.DrawString("Título", normal, Brushes.Black, x + 70, y + 5);
            g.DrawString("Estado", normal, Brushes.Black, x + 320, y + 5);
            g.DrawString("Prioridad", normal, Brushes.Black, x + 450, y + 5);
            g.DrawString("Fecha", normal, Brushes.Black, x + 580, y + 5);

            y += 30;

            foreach (DataGridViewRow fila in dgDetalleTecnicos.Rows)
            {
                if (fila.IsNewRow)
                    continue;

                g.DrawString(
                    fila.Cells[0].Value?.ToString(),
                    normal,
                    Brushes.Black,
                    x + 10,
                    y);

                g.DrawString(
                    fila.Cells[1].Value?.ToString(),
                    normal,
                    Brushes.Black,
                    x + 70,
                    y);

                g.DrawString(
                    fila.Cells[4].Value?.ToString(),
                    normal,
                    Brushes.Black,
                    x + 320,
                    y);

                g.DrawString(
                    fila.Cells[3].Value?.ToString(),
                    normal,
                    Brushes.Black,
                    x + 450,
                    y);

                g.DrawString(
                    fila.Cells[5].Value?.ToString(),
                    normal,
                    Brushes.Black,
                    x + 580,
                    y);

                y += 22;
            }
            e.HasMorePages = false;
        }

        private void btnLimpiarFiltros_Click_1(object sender, EventArgs e)
        {
            cbTecnico.SelectedIndex = 0;
            cbEstado.SelectedIndex = 0;
            dgDetalleTecnicos.DataSource = null;
            MostrarReporteTecnicos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chartTecnicos_MouseClick_1(object sender, MouseEventArgs e)
        {
            HitTestResult resultado =
                chartTecnicos.HitTest(
                    e.X,
                    e.Y);

            if (resultado.PointIndex >= 0)
            {
                string tecnico =
                    resultado.Series
                    .Points[resultado.PointIndex]
                    .AxisLabel;

                MostrarDetalleTecnico(
                    tecnico);
            }
        }
        private void CargarTecnicos()
        {
            cbTecnico.DataSource =
                nReporte.ObtenerTecnicos();
        }
        private void CargarEstados()
        {
            cbEstado.Items.Clear();

            cbEstado.Items.Add("Todos");
            cbEstado.Items.Add("Asignado");
            cbEstado.Items.Add("En Proceso");
            cbEstado.Items.Add("Resuelto");

            cbEstado.SelectedIndex = 0;
        }

        private void cbTecnico_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarReporteTecnicos();
        }

        private void cbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarReporteTecnicos();
        }
    }
}
