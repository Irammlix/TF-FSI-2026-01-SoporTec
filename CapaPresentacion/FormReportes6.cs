using CapaDatos;
using CapaNegocio;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static CapaDatos.DClasesAuxiliares;

namespace CapaPresentacion
{
    public partial class FormReportes6 : Form
    {

        private NReporte nReporte = new NReporte();

        private Label lbl_TituloDetalle;

        private string[] nombresMes =
        {
            "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
            "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"
        };

        public FormReportes6()
        {
            InitializeComponent();

            chart_EvolucionMensual.Series["Series1"].Name = "Ingresados";
            chart_EvolucionMensual.Series["Ingresados"].ChartType = SeriesChartType.Line;
            chart_EvolucionMensual.Series["Ingresados"].BorderWidth = 3;
            chart_EvolucionMensual.Series["Ingresados"].Color = Color.Navy;

            Series serieResueltos = new Series("Resueltos")
            {
                ChartType = SeriesChartType.Line,
                ChartArea = "ChartArea1",
                Legend = "Legend1",
                BorderWidth = 3,
                Color = Color.DarkOrange
            };
            chart_EvolucionMensual.Series.Add(serieResueltos);

            // Título arriba de dgv_DetalleMes: aclara si lo que se ve son ingresados o resueltos.
            lbl_TituloDetalle = new Label
            {
                Dock = DockStyle.Top,
                Height = 22,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.Navy,
                TextAlign = ContentAlignment.MiddleLeft,
                Text = "Detalle: (haz clic en un punto del gráfico)"
            };
            panel20.Controls.Add(lbl_TituloDetalle);

            chart_EvolucionMensual.MouseClick += ChartEvolucionMensual_MouseClick;
            cmb_Anio.SelectedIndexChanged += (s, e) => CargarReporte();
            button23.Click += (s, e) => CargarReporte();          
            button22.Click += (s, e) => ExportarPdf();            
            btnLimpiarFiltrosR1.Click += (s, e) => LimpiarFiltros(); 
            button20.Click += (s, e) => this.Close();             

            this.Load += FormReportes6_Load;
        }

        private void FormReportes6_Load(object sender, EventArgs e)
        {
            CargarAnios();
            CargarReporte();
        }


        private void CargarAnios()
        {
            var anios = nReporte.ListarAniosConTickets();
            int anioActual = DateTime.Now.Year;

            if (!anios.Contains(anioActual))
                anios.Insert(0, anioActual);

            cmb_Anio.Items.Clear();
            foreach (int a in anios)
                cmb_Anio.Items.Add(a);

            cmb_Anio.SelectedItem = anioActual;
        }

        private void CargarReporte()
        {
            if (cmb_Anio.SelectedItem == null)
                return;

            int anio = (int)cmb_Anio.SelectedItem;

            int[] ingresados = nReporte.ContarIngresadosPorMes(anio);
            int[] resueltos = nReporte.ContarResueltosPorMes(anio);

            Series serieIngresados = chart_EvolucionMensual.Series["Ingresados"];
            Series serieResueltos = chart_EvolucionMensual.Series["Resueltos"];
            serieIngresados.Points.Clear();
            serieResueltos.Points.Clear();

            for (int mes = 0; mes < 12; mes++)
            {
                serieIngresados.Points.AddXY(nombresMes[mes], ingresados[mes]);
                serieResueltos.Points.AddXY(nombresMes[mes], resueltos[mes]);
            }

            int totalIngresados = ingresados.Sum();
            int totalResueltos = resueltos.Sum();

            lbl_TotalIngresados.Text = totalIngresados.ToString();
            lbl_TotalResueltos.Text = totalResueltos.ToString();
            lbl_SaldoPendiente.Text = (totalIngresados - totalResueltos).ToString();
            lbl_MesPico.Text = nReporte.ObtenerMesPico(anio);
            lbl_IndicadorTendencia.Text = nReporte.CalcularIndicadorTendencia(totalIngresados, totalResueltos);
            lbl_FechaGeneracion.Text = "Fecha de Generación de Reporte: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            dgv_DetalleMes.DataSource = null;
            lbl_TituloDetalle.Text = "Detalle: (haz clic en un punto del gráfico)";
        }


        private void ChartEvolucionMensual_MouseClick(object sender, MouseEventArgs e)
        {
            HitTestResult resultado = chart_EvolucionMensual.HitTest(e.X, e.Y);
            if (resultado.ChartElementType != ChartElementType.DataPoint || resultado.PointIndex < 0)
                return;

            int mes = resultado.PointIndex + 1;
            bool esIngresados = resultado.Series == null || resultado.Series.Name == "Ingresados";
            CargarDetalleMes(mes, esIngresados);
        }

        private void CargarDetalleMes(int mes, bool esIngresados)
        {
            int anio = (int)cmb_Anio.SelectedItem;
            var tickets = esIngresados
                ? nReporte.ListarPorMes(anio, mes)
                : nReporte.ListarResueltosPorMes(anio, mes);

            var vista = tickets.Select(t => new
            {
                ID = t.IdTicket,
                Título = t.DTitulo,
                Estado = t.DEstado,
                Prioridad = t.DPrioridad,
                FechaCreacion = t.FCreacion.ToString("dd/MM/yyyy"),
                FechaActualizacion = t.FActualizacion.HasValue ? t.FActualizacion.Value.ToString("dd/MM/yyyy") : ""
            }).ToList();

            dgv_DetalleMes.DataSource = vista;

            if (dgv_DetalleMes.Columns.Count >= 6)
            {
                dgv_DetalleMes.Columns[0].HeaderText = "ID";
                dgv_DetalleMes.Columns[1].HeaderText = "Título";
                dgv_DetalleMes.Columns[2].HeaderText = "Estado";
                dgv_DetalleMes.Columns[3].HeaderText = "Prioridad";
                dgv_DetalleMes.Columns[4].HeaderText = "Fecha Creación";
                dgv_DetalleMes.Columns[5].HeaderText = "Fecha Actualización";
            }

            string tipo = esIngresados ? "Tickets ingresados en " : "Tickets resueltos en ";
            lbl_TituloDetalle.Text = tipo + nombresMes[mes - 1] + " " + anio;
        }

        private void LimpiarFiltros()
        {
            int anioActual = DateTime.Now.Year;
            if (cmb_Anio.Items.Contains(anioActual))
                cmb_Anio.SelectedItem = anioActual;
            else if (cmb_Anio.Items.Count > 0)
                cmb_Anio.SelectedIndex = 0;

            dgv_DetalleMes.DataSource = null;
            CargarReporte();
        }


        private void ExportarPdf()
        {
            if (cmb_Anio.SelectedItem == null)
            {
                MessageBox.Show("No hay datos para exportar.");
                return;
            }

            int anio = (int)cmb_Anio.SelectedItem;
            int[] ingresados = nReporte.ContarIngresadosPorMes(anio);
            int[] resueltos = nReporte.ContarResueltosPorMes(anio);

            PrintDocument doc = new PrintDocument { DocumentName = "Reporte RF-21 - Evolución Mensual de Tickets" };
            doc.PrintPage += (s, e) => Doc_PrintPage(e, anio, ingresados, resueltos);

            using (PrintPreviewDialog preview = new PrintPreviewDialog { Document = doc, WindowState = FormWindowState.Maximized })
            {
                preview.ShowDialog();
            }
        }


        private void Doc_PrintPage(PrintPageEventArgs e, int anio, int[] ingresados, int[] resueltos)
        {
            Graphics g = e.Graphics;
            float x = 50, y = 50;
            float ancho = e.PageBounds.Width - 100;

            g.FillRectangle(new SolidBrush(Color.Navy), x, y, ancho, 46);
            g.DrawString("SoporTec — Evolución Mensual de Tickets", new Font("Segoe UI", 16, FontStyle.Bold), Brushes.White, x + 12, y + 10);
            y += 58;

            g.DrawString("Año: " + anio, new Font("Segoe UI", 11, FontStyle.Bold), Brushes.Black, x, y);
            g.DrawString("Generado: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), new Font("Segoe UI", 9), Brushes.Gray, x + ancho - 220, y + 4);
            y += 34;

            g.DrawString("Ingresados: " + ingresados.Sum() + "   Resueltos: " + resueltos.Sum() + "   Saldo: " + (ingresados.Sum() - resueltos.Sum()),
                new Font("Segoe UI", 10), Brushes.Black, x, y);
            y += 22;
            g.DrawString(lbl_IndicadorTendencia.Text, new Font("Segoe UI", 10, FontStyle.Italic), Brushes.Black, x, y);
            y += 30;

            var fH = new Font("Segoe UI", 10, FontStyle.Bold);
            var fC = new Font("Segoe UI", 10);
            g.FillRectangle(new SolidBrush(Color.FromArgb(237, 239, 242)), x, y, ancho, 26);
            g.DrawString("Mes", fH, Brushes.Black, x + 8, y + 4);
            g.DrawString("Ingresados", fH, Brushes.Black, x + ancho - 300, y + 4);
            g.DrawString("Resueltos", fH, Brushes.Black, x + ancho - 150, y + 4);
            y += 26;

            for (int mes = 0; mes < 12; mes++)
            {
                g.DrawRectangle(Pens.Gainsboro, x, y, ancho, 22);
                g.DrawString(nombresMes[mes], fC, Brushes.Black, x + 8, y + 3);
                g.DrawString(ingresados[mes].ToString(), fC, Brushes.Black, x + ancho - 300, y + 3);
                g.DrawString(resueltos[mes].ToString(), fC, Brushes.Black, x + ancho - 150, y + 3);
                y += 22;
            }

            if (dgv_DetalleMes.DataSource != null && dgv_DetalleMes.CurrentRow != null)
            {
                y += 20;
                g.DrawString("Detalle del mes seleccionado:", fH, Brushes.Black, x, y);
                y += 24;

                foreach (DataGridViewColumn col in dgv_DetalleMes.Columns)
                {
                    g.DrawString(col.HeaderText + ": " + dgv_DetalleMes.CurrentRow.Cells[col.Index].Value, fC, Brushes.Black, x + 8, y);
                    y += 18;
                }
            }

            e.HasMorePages = false;
        }
    }
}
