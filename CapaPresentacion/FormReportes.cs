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

        // ======== Paleta (tomada del diseño del formulario) ========
        private static readonly Color ColorNavy = Color.Navy;
        private static readonly Color ColorFondo = Color.FromArgb(242, 245, 250);
        private static readonly Color ColorBorde = Color.FromArgb(204, 211, 220);
        private static readonly Color ColorTituloReporte = Color.FromArgb(74, 127, 199);
        private static readonly Color ColorBarra = Color.FromArgb(100, 140, 190);
        private static readonly Color ColorResaltado = Color.FromArgb(192, 57, 43);

        // ======== RF-19: dependencias y controles construidos en runtime ========
        private readonly NReporte nReporte = new NReporte();
        private readonly NSede nSede = new NSede();

        private ComboBox cboSede, cboEstado, cboOrden;
        private Chart chartPabellones;
        private DataGridView dgvDetalle;
        private Label lblSubtitulo, lblGenerado, lblDetalleTitulo;
        private Label kpiTotal, kpiPabTop, kpiPabTopCant, kpiPabActivos;
        private List<NReporte.ConteoPabellon> datosActuales = new List<NReporte.ConteoPabellon>();

        public FormReportes()
        {
            InitializeComponent();
            CargarReporte1();
            cbSedeReporte1.SelectedIndex = 0;
        }

        

        // ---------- Bloques de UI ----------

        private Panel CrearTitulo()
        {
            Panel cont = new Panel { Dock = DockStyle.Top, Height = 60, BackColor = ColorFondo, Padding = new Padding(0, 0, 0, 6) };

            Label titulo = new Label
            {
                Dock = DockStyle.Top,
                Height = 30,
                Text = "Tickets por Sede y Pabellón",
                Font = new Font("Segoe UI", 15F, FontStyle.Bold),
                ForeColor = ColorTituloReporte,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.White
            };
            lblSubtitulo = new Label
            {
                Dock = DockStyle.Top,
                Height = 24,
                Text = "Concentración de incidencias por instalación",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.White
            };
            cont.Controls.Add(lblSubtitulo);
            cont.Controls.Add(titulo);
            return cont;
        }

        private TableLayoutPanel CrearFilaKpis()
        {
            TableLayoutPanel fila = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 98,
                ColumnCount = 4,
                RowCount = 1,
                BackColor = ColorFondo,
                Padding = new Padding(0, 4, 0, 8)
            };
            for (int i = 0; i < 4; i++)
                fila.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));

            fila.Controls.Add(CrearTarjetaKpi("Total tickets (sede)", out kpiTotal, ColorNavy), 0, 0);
            fila.Controls.Add(CrearTarjetaKpi("Pabellón con más incidencias", out kpiPabTop, ColorResaltado), 1, 0);
            fila.Controls.Add(CrearTarjetaKpi("Tickets en ese pabellón", out kpiPabTopCant, ColorResaltado), 2, 0);
            fila.Controls.Add(CrearTarjetaKpi("Pabellones activos", out kpiPabActivos, ColorNavy), 3, 0);
            return fila;
        }

        private Panel CrearTarjetaKpi(string titulo, out Label valor, Color colorValor)
        {
            Panel card = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Margin = new Padding(4), Padding = new Padding(4) };
            card.BorderStyle = BorderStyle.FixedSingle;

            Label lblTitulo = new Label
            {
                Dock = DockStyle.Top,
                Height = 34,
                Text = titulo,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };
            valor = new Label
            {
                Dock = DockStyle.Fill,
                Text = "-",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = colorValor,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoEllipsis = true
            };
            card.Controls.Add(valor);
            card.Controls.Add(lblTitulo);
            return card;
        }

        private TableLayoutPanel CrearColumnaGrafico()
        {
            TableLayoutPanel col = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                BackColor = ColorFondo,
                Margin = new Padding(0, 0, 6, 0)
            };
            col.RowStyles.Add(new RowStyle(SizeType.Percent, 58F));
            col.RowStyles.Add(new RowStyle(SizeType.Percent, 42F));

            // Gráfico
            Panel pnlChart = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Margin = new Padding(0, 0, 0, 6), BorderStyle = BorderStyle.FixedSingle };
            chartPabellones = new Chart { Dock = DockStyle.Fill, BackColor = Color.White };
            ChartArea area = new ChartArea("area");
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisX.Interval = 1;
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 8F);
            area.AxisY.MajorGrid.LineColor = Color.Gainsboro;
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 8F);
            area.AxisY.Minimum = 0;
            chartPabellones.ChartAreas.Add(area);
            Series serie = new Series("Tickets")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
                Color = ColorBarra,
                Font = new Font("Segoe UI", 8F, FontStyle.Bold)
            };
            chartPabellones.Series.Add(serie);
            chartPabellones.MouseClick += ChartPabellones_MouseClick;
            pnlChart.Controls.Add(chartPabellones);

            // Detalle (drill-down)
            Panel pnlDetalle = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, BorderStyle = BorderStyle.FixedSingle };
            lblDetalleTitulo = new Label
            {
                Dock = DockStyle.Top,
                Height = 24,
                Text = "Detalle: (haz clic en una barra)",
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = ColorNavy,
                Padding = new Padding(6, 4, 0, 0)
            };
            dgvDetalle = new DataGridView
            {
                Dock = DockStyle.Fill,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };
            dgvDetalle.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(237, 239, 242);
            dgvDetalle.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            dgvDetalle.EnableHeadersVisualStyles = false;
            pnlDetalle.Controls.Add(dgvDetalle);
            pnlDetalle.Controls.Add(lblDetalleTitulo);

            col.Controls.Add(pnlChart, 0, 0);
            col.Controls.Add(pnlDetalle, 0, 1);
            return col;
        }

        private Panel CrearColumnaFiltros()
        {
            Panel col = new Panel { Dock = DockStyle.Fill, BackColor = ColorFondo, Margin = new Padding(0) };

            // --- Filtros ---
            Panel pnlFiltros = new Panel { Dock = DockStyle.Top, Height = 180, BackColor = Color.White, BorderStyle = BorderStyle.FixedSingle, Padding = new Padding(10) };

            cboOrden = new ComboBox { Dock = DockStyle.Top, DropDownStyle = ComboBoxStyle.DropDownList, Margin = new Padding(0, 0, 0, 8) };
            cboOrden.Items.AddRange(new object[] { "Mayor a menor", "Menor a mayor" });
            cboOrden.SelectedIndex = 0;
            cboOrden.SelectedIndexChanged += (s, e) => CargarReporte();

            cboEstado = new ComboBox { Dock = DockStyle.Top, DropDownStyle = ComboBoxStyle.DropDownList };
            cboEstado.Items.AddRange(new object[] { "Todos", "Sin Asignar", "Asignado", "En Proceso", "Resuelto" });
            cboEstado.SelectedIndex = 0;
            cboEstado.SelectedIndexChanged += (s, e) => CargarReporte();

            cboSede = new ComboBox { Dock = DockStyle.Top, DropDownStyle = ComboBoxStyle.DropDownList };
            cboSede.SelectedIndexChanged += (s, e) => CargarReporte();

            // Se agregan de abajo hacia arriba (por el Dock Top)
            pnlFiltros.Controls.Add(cboOrden);
            pnlFiltros.Controls.Add(CrearEtiquetaFiltro("Ordenar por:"));
            pnlFiltros.Controls.Add(cboEstado);
            pnlFiltros.Controls.Add(CrearEtiquetaFiltro("Estado (opcional):"));
            pnlFiltros.Controls.Add(cboSede);
            pnlFiltros.Controls.Add(CrearEtiquetaFiltro("Sede:"));
            pnlFiltros.Controls.Add(new Label
            {
                Dock = DockStyle.Top,
                Height = 26,
                Text = "Filtros",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold)
            });

            // --- Leyenda ---
            Panel pnlLeyenda = new Panel { Dock = DockStyle.Top, Height = 104, BackColor = Color.White, BorderStyle = BorderStyle.FixedSingle, Padding = new Padding(12, 10, 12, 10), Margin = new Padding(0, 8, 0, 0) };
            pnlLeyenda.Controls.Add(CrearItemLeyenda("Mayor cantidad", ColorResaltado));
            pnlLeyenda.Controls.Add(CrearItemLeyenda("Cantidad de tickets", ColorBarra));
            pnlLeyenda.Controls.Add(new Label
            {
                Dock = DockStyle.Top,
                Height = 26,
                Text = "Leyenda",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold)
            });

            // --- Fecha de generación ---
            lblGenerado = new Label
            {
                Dock = DockStyle.Top,
                Height = 34,
                Text = "",
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.Gray,
                BackColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(8, 0, 0, 0)
            };

            Panel espacio = new Panel { Dock = DockStyle.Top, Height = 8, BackColor = ColorFondo };

            col.Controls.Add(lblGenerado);
            col.Controls.Add(espacio);
            col.Controls.Add(pnlLeyenda);
            col.Controls.Add(new Panel { Dock = DockStyle.Top, Height = 8, BackColor = ColorFondo });
            col.Controls.Add(pnlFiltros);
            return col;
        }

        private Label CrearEtiquetaFiltro(string texto)
        {
            return new Label
            {
                Dock = DockStyle.Top,
                Height = 20,
                Text = texto,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Margin = new Padding(0, 4, 0, 0)
            };
        }

        private Panel CrearItemLeyenda(string texto, Color color)
        {
            // El item ocupa toda la fila; la etiqueta llena y el cuadro de color
            // se ancla a la izquierda, ambos centrados verticalmente para que "cuadre".
            Panel item = new Panel { Dock = DockStyle.Top, Height = 26, BackColor = Color.White };

            Label lbl = new Label
            {
                Dock = DockStyle.Fill,
                Text = texto,
                Font = new Font("Segoe UI", 9F),
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.White,
                Padding = new Padding(26, 0, 0, 0)
            };

            Panel cuadro = new Panel
            {
                Dock = DockStyle.Left,
                Width = 20,
                BackColor = Color.White
            };
            Panel swatch = new Panel
            {
                Width = 16,
                Height = 16,
                BackColor = color,
                Location = new Point(2, 5),
                Anchor = AnchorStyles.Left | AnchorStyles.Top
            };
            cuadro.Controls.Add(swatch);

            item.Controls.Add(lbl);
            item.Controls.Add(cuadro);
            return item;
        }

        private Button CrearBotonSidebar(string texto, DockStyle dock, EventHandler onClick)
        {
            Button btn = new Button
            {
                Text = texto,
                Dock = dock,
                Height = 78,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                BackColor = ColorNavy,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderColor = Color.FromArgb(30, 30, 90);
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 40, 120);
            btn.Click += onClick;
            return btn;
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
            lblGenerado.Text = "Generado: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");

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

        private void ChartPabellones_MouseClick(object sender, MouseEventArgs e)
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
