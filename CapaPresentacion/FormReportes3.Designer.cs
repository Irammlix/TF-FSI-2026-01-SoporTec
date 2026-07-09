namespace CapaPresentacion
{
    partial class FormReportes3
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReportes3));
            this.pnl_Top = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SoporTec = new System.Windows.Forms.Label();
            this.pnl_Bottom = new System.Windows.Forms.Panel();
            this.pnl_Reporte = new System.Windows.Forms.Panel();
            this.pnldatagriew = new System.Windows.Forms.Panel();
            this.dgDetalleTecnicos = new System.Windows.Forms.DataGridView();
            this.filtros = new System.Windows.Forms.TableLayoutPanel();
            this.filtros_especificos = new System.Windows.Forms.TableLayoutPanel();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cbTecnico = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.grafica = new System.Windows.Forms.Panel();
            this.chartTecnicos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.sdr_botones = new System.Windows.Forms.TableLayoutPanel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnLimpiarFiltros = new System.Windows.Forms.Button();
            this.btnExportarPdf = new System.Windows.Forms.Button();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.titulo_indicadores = new System.Windows.Forms.TableLayoutPanel();
            this.titulo_metricas = new System.Windows.Forms.Label();
            this.pnl_titulo_reporte = new System.Windows.Forms.Panel();
            this.lblFechaGeneracion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel52 = new System.Windows.Forms.TableLayoutPanel();
            this.label80 = new System.Windows.Forms.Label();
            this.lblCuelloBotella = new System.Windows.Forms.Label();
            this.lblNumAlta = new System.Windows.Forms.Label();
            this.tableLayoutPanel53 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTotalPendientes = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.lblNumMedia = new System.Windows.Forms.Label();
            this.tableLayoutPanel54 = new System.Windows.Forms.TableLayoutPanel();
            this.label84 = new System.Windows.Forms.Label();
            this.lblTicketa = new System.Windows.Forms.Label();
            this.lblTotalResueltos = new System.Windows.Forms.Label();
            this.tableLayoutPanel55 = new System.Windows.Forms.TableLayoutPanel();
            this.label86 = new System.Windows.Forms.Label();
            this.button21 = new System.Windows.Forms.Button();
            this.lblTotalTickets = new System.Windows.Forms.Label();
            this.pnl_Top.SuspendLayout();
            this.pnl_Reporte.SuspendLayout();
            this.pnldatagriew.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetalleTecnicos)).BeginInit();
            this.filtros.SuspendLayout();
            this.filtros_especificos.SuspendLayout();
            this.grafica.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTecnicos)).BeginInit();
            this.sdr_botones.SuspendLayout();
            this.titulo_indicadores.SuspendLayout();
            this.pnl_titulo_reporte.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel52.SuspendLayout();
            this.tableLayoutPanel53.SuspendLayout();
            this.tableLayoutPanel54.SuspendLayout();
            this.tableLayoutPanel55.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Top
            // 
            this.pnl_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.pnl_Top.Controls.Add(this.panel1);
            this.pnl_Top.Controls.Add(this.SoporTec);
            this.pnl_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Top.Location = new System.Drawing.Point(0, 0);
            this.pnl_Top.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnl_Top.Name = "pnl_Top";
            this.pnl_Top.Size = new System.Drawing.Size(1683, 87);
            this.pnl_Top.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 77);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1683, 10);
            this.panel1.TabIndex = 4;
            // 
            // SoporTec
            // 
            this.SoporTec.AutoSize = true;
            this.SoporTec.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.SoporTec.ForeColor = System.Drawing.Color.Navy;
            this.SoporTec.Location = new System.Drawing.Point(636, 9);
            this.SoporTec.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SoporTec.Name = "SoporTec";
            this.SoporTec.Size = new System.Drawing.Size(374, 54);
            this.SoporTec.TabIndex = 3;
            this.SoporTec.Text = "SoporTec Reportes";
            this.SoporTec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnl_Bottom
            // 
            this.pnl_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.pnl_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_Bottom.Location = new System.Drawing.Point(0, 843);
            this.pnl_Bottom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnl_Bottom.Name = "pnl_Bottom";
            this.pnl_Bottom.Size = new System.Drawing.Size(1683, 10);
            this.pnl_Bottom.TabIndex = 1;
            // 
            // pnl_Reporte
            // 
            this.pnl_Reporte.BackColor = System.Drawing.Color.White;
            this.pnl_Reporte.Controls.Add(this.pnldatagriew);
            this.pnl_Reporte.Controls.Add(this.filtros);
            this.pnl_Reporte.Controls.Add(this.grafica);
            this.pnl_Reporte.Controls.Add(this.sdr_botones);
            this.pnl_Reporte.Controls.Add(this.titulo_indicadores);
            this.pnl_Reporte.Controls.Add(this.pnl_titulo_reporte);
            this.pnl_Reporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Reporte.Location = new System.Drawing.Point(0, 87);
            this.pnl_Reporte.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnl_Reporte.Name = "pnl_Reporte";
            this.pnl_Reporte.Size = new System.Drawing.Size(1683, 756);
            this.pnl_Reporte.TabIndex = 5;
            // 
            // pnldatagriew
            // 
            this.pnldatagriew.Controls.Add(this.dgDetalleTecnicos);
            this.pnldatagriew.Location = new System.Drawing.Point(903, 304);
            this.pnldatagriew.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnldatagriew.Name = "pnldatagriew";
            this.pnldatagriew.Size = new System.Drawing.Size(764, 437);
            this.pnldatagriew.TabIndex = 8;
            // 
            // dgDetalleTecnicos
            // 
            this.dgDetalleTecnicos.AllowUserToAddRows = false;
            this.dgDetalleTecnicos.AllowUserToDeleteRows = false;
            this.dgDetalleTecnicos.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgDetalleTecnicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDetalleTecnicos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgDetalleTecnicos.Location = new System.Drawing.Point(0, 0);
            this.dgDetalleTecnicos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgDetalleTecnicos.Name = "dgDetalleTecnicos";
            this.dgDetalleTecnicos.ReadOnly = true;
            this.dgDetalleTecnicos.RowHeadersWidth = 51;
            this.dgDetalleTecnicos.RowTemplate.Height = 24;
            this.dgDetalleTecnicos.Size = new System.Drawing.Size(764, 437);
            this.dgDetalleTecnicos.TabIndex = 0;
            // 
            // filtros
            // 
            this.filtros.BackColor = System.Drawing.Color.OldLace;
            this.filtros.ColumnCount = 1;
            this.filtros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.filtros.Controls.Add(this.filtros_especificos, 0, 1);
            this.filtros.Controls.Add(this.label10, 0, 0);
            this.filtros.Location = new System.Drawing.Point(904, 197);
            this.filtros.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.filtros.Name = "filtros";
            this.filtros.RowCount = 2;
            this.filtros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.12621F));
            this.filtros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.87379F));
            this.filtros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.filtros.Size = new System.Drawing.Size(765, 103);
            this.filtros.TabIndex = 6;
            // 
            // filtros_especificos
            // 
            this.filtros_especificos.ColumnCount = 2;
            this.filtros_especificos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.99999F));
            this.filtros_especificos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.filtros_especificos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.filtros_especificos.Controls.Add(this.cbEstado, 1, 1);
            this.filtros_especificos.Controls.Add(this.label12, 1, 0);
            this.filtros_especificos.Controls.Add(this.label11, 0, 0);
            this.filtros_especificos.Controls.Add(this.cbTecnico, 0, 1);
            this.filtros_especificos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filtros_especificos.Location = new System.Drawing.Point(3, 31);
            this.filtros_especificos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.filtros_especificos.Name = "filtros_especificos";
            this.filtros_especificos.RowCount = 2;
            this.filtros_especificos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.56338F));
            this.filtros_especificos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.43662F));
            this.filtros_especificos.Size = new System.Drawing.Size(759, 70);
            this.filtros_especificos.TabIndex = 7;
            // 
            // cbEstado
            // 
            this.cbEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbEstado.BackColor = System.Drawing.Color.Wheat;
            this.cbEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Location = new System.Drawing.Point(382, 44);
            this.cbEstado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(374, 24);
            this.cbEstado.TabIndex = 6;
            this.cbEstado.SelectedIndexChanged += new System.EventHandler(this.cbEstado_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label12.Location = new System.Drawing.Point(382, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 42);
            this.label12.TabIndex = 3;
            this.label12.Text = "Estado";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label11.Location = new System.Drawing.Point(3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 42);
            this.label11.TabIndex = 2;
            this.label11.Text = "Técnico";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbTecnico
            // 
            this.cbTecnico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTecnico.BackColor = System.Drawing.Color.Wheat;
            this.cbTecnico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbTecnico.FormattingEnabled = true;
            this.cbTecnico.Location = new System.Drawing.Point(3, 44);
            this.cbTecnico.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbTecnico.Name = "cbTecnico";
            this.cbTecnico.Size = new System.Drawing.Size(373, 24);
            this.cbTecnico.TabIndex = 5;
            this.cbTecnico.SelectedIndexChanged += new System.EventHandler(this.cbTecnico_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 29);
            this.label10.TabIndex = 1;
            this.label10.Text = "Filtros:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grafica
            // 
            this.grafica.Controls.Add(this.chartTecnicos);
            this.grafica.Location = new System.Drawing.Point(125, 197);
            this.grafica.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grafica.Name = "grafica";
            this.grafica.Size = new System.Drawing.Size(750, 544);
            this.grafica.TabIndex = 5;
            // 
            // chartTecnicos
            // 
            chartArea1.Name = "ChartArea1";
            this.chartTecnicos.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartTecnicos.Legends.Add(legend1);
            this.chartTecnicos.Location = new System.Drawing.Point(0, 2);
            this.chartTecnicos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartTecnicos.Name = "chartTecnicos";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartTecnicos.Series.Add(series1);
            this.chartTecnicos.Size = new System.Drawing.Size(746, 538);
            this.chartTecnicos.TabIndex = 0;
            this.chartTecnicos.Text = "chart1";
            this.chartTecnicos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chartTecnicos_MouseClick_1);
            // 
            // sdr_botones
            // 
            this.sdr_botones.BackColor = System.Drawing.Color.Navy;
            this.sdr_botones.ColumnCount = 1;
            this.sdr_botones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.sdr_botones.Controls.Add(this.btnSalir, 0, 3);
            this.sdr_botones.Controls.Add(this.btnLimpiarFiltros, 0, 2);
            this.sdr_botones.Controls.Add(this.btnExportarPdf, 0, 1);
            this.sdr_botones.Controls.Add(this.btnRefrescar, 0, 0);
            this.sdr_botones.Location = new System.Drawing.Point(0, 0);
            this.sdr_botones.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sdr_botones.Name = "sdr_botones";
            this.sdr_botones.RowCount = 4;
            this.sdr_botones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.sdr_botones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.sdr_botones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.sdr_botones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.sdr_botones.Size = new System.Drawing.Size(115, 756);
            this.sdr_botones.TabIndex = 1;
            // 
            // btnSalir
            // 
            this.btnSalir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(4, 571);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.btnSalir.Size = new System.Drawing.Size(107, 181);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnLimpiarFiltros
            // 
            this.btnLimpiarFiltros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLimpiarFiltros.FlatAppearance.BorderSize = 0;
            this.btnLimpiarFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarFiltros.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarFiltros.ForeColor = System.Drawing.Color.White;
            this.btnLimpiarFiltros.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiarFiltros.Image")));
            this.btnLimpiarFiltros.Location = new System.Drawing.Point(4, 382);
            this.btnLimpiarFiltros.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            this.btnLimpiarFiltros.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.btnLimpiarFiltros.Size = new System.Drawing.Size(107, 181);
            this.btnLimpiarFiltros.TabIndex = 5;
            this.btnLimpiarFiltros.Text = "Limpiar Filtros";
            this.btnLimpiarFiltros.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLimpiarFiltros.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLimpiarFiltros.UseVisualStyleBackColor = true;
            this.btnLimpiarFiltros.Click += new System.EventHandler(this.btnLimpiarFiltros_Click_1);
            // 
            // btnExportarPdf
            // 
            this.btnExportarPdf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportarPdf.FlatAppearance.BorderSize = 0;
            this.btnExportarPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarPdf.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarPdf.ForeColor = System.Drawing.Color.White;
            this.btnExportarPdf.Image = ((System.Drawing.Image)(resources.GetObject("btnExportarPdf.Image")));
            this.btnExportarPdf.Location = new System.Drawing.Point(4, 193);
            this.btnExportarPdf.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportarPdf.Name = "btnExportarPdf";
            this.btnExportarPdf.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.btnExportarPdf.Size = new System.Drawing.Size(107, 181);
            this.btnExportarPdf.TabIndex = 4;
            this.btnExportarPdf.Text = "Exportar PDF";
            this.btnExportarPdf.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExportarPdf.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExportarPdf.UseVisualStyleBackColor = true;
            this.btnExportarPdf.Click += new System.EventHandler(this.btnExportarPdf_Click);
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRefrescar.FlatAppearance.BorderSize = 0;
            this.btnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefrescar.ForeColor = System.Drawing.Color.White;
            this.btnRefrescar.Image = ((System.Drawing.Image)(resources.GetObject("btnRefrescar.Image")));
            this.btnRefrescar.Location = new System.Drawing.Point(4, 4);
            this.btnRefrescar.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.btnRefrescar.Size = new System.Drawing.Size(107, 181);
            this.btnRefrescar.TabIndex = 3;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRefrescar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRefrescar.UseVisualStyleBackColor = true;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click_1);
            // 
            // titulo_indicadores
            // 
            this.titulo_indicadores.ColumnCount = 1;
            this.titulo_indicadores.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.titulo_indicadores.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.titulo_indicadores.Controls.Add(this.titulo_metricas, 0, 0);
            this.titulo_indicadores.Location = new System.Drawing.Point(112, 52);
            this.titulo_indicadores.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.titulo_indicadores.Name = "titulo_indicadores";
            this.titulo_indicadores.RowCount = 2;
            this.titulo_indicadores.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.titulo_indicadores.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.titulo_indicadores.Size = new System.Drawing.Size(1573, 133);
            this.titulo_indicadores.TabIndex = 4;
            // 
            // titulo_metricas
            // 
            this.titulo_metricas.AutoSize = true;
            this.titulo_metricas.BackColor = System.Drawing.Color.LightCyan;
            this.titulo_metricas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titulo_metricas.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titulo_metricas.ForeColor = System.Drawing.Color.Navy;
            this.titulo_metricas.Location = new System.Drawing.Point(4, 0);
            this.titulo_metricas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titulo_metricas.Name = "titulo_metricas";
            this.titulo_metricas.Size = new System.Drawing.Size(1565, 26);
            this.titulo_metricas.TabIndex = 6;
            this.titulo_metricas.Text = "   Visualiza el rendimiento de los técnicos mediante la comparación de tickets re" +
    "sueltos y pendientes, facilitando la identificación de sobrecarga operativa y po" +
    "sibles cuellos de botella.";
            this.titulo_metricas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnl_titulo_reporte
            // 
            this.pnl_titulo_reporte.BackColor = System.Drawing.Color.Transparent;
            this.pnl_titulo_reporte.Controls.Add(this.lblFechaGeneracion);
            this.pnl_titulo_reporte.Controls.Add(this.label1);
            this.pnl_titulo_reporte.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pnl_titulo_reporte.Location = new System.Drawing.Point(109, 0);
            this.pnl_titulo_reporte.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnl_titulo_reporte.Name = "pnl_titulo_reporte";
            this.pnl_titulo_reporte.Size = new System.Drawing.Size(1573, 50);
            this.pnl_titulo_reporte.TabIndex = 2;
            // 
            // lblFechaGeneracion
            // 
            this.lblFechaGeneracion.AutoSize = true;
            this.lblFechaGeneracion.Location = new System.Drawing.Point(1310, 21);
            this.lblFechaGeneracion.Name = "lblFechaGeneracion";
            this.lblFechaGeneracion.Size = new System.Drawing.Size(44, 16);
            this.lblFechaGeneracion.TabIndex = 6;
            this.lblFechaGeneracion.Text = "label3";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(13, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(740, 37);
            this.label1.TabIndex = 5;
            this.label1.Text = "Rendimiento de Técnicos: Tickets asignados vs Resueltos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel52, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel53, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel54, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel55, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 28);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1567, 103);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // tableLayoutPanel52
            // 
            this.tableLayoutPanel52.BackColor = System.Drawing.Color.MistyRose;
            this.tableLayoutPanel52.ColumnCount = 1;
            this.tableLayoutPanel52.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel52.Controls.Add(this.label80, 0, 0);
            this.tableLayoutPanel52.Controls.Add(this.lblCuelloBotella, 0, 1);
            this.tableLayoutPanel52.Controls.Add(this.lblNumAlta, 0, 2);
            this.tableLayoutPanel52.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel52.Location = new System.Drawing.Point(1176, 3);
            this.tableLayoutPanel52.Name = "tableLayoutPanel52";
            this.tableLayoutPanel52.RowCount = 3;
            this.tableLayoutPanel52.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel52.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.55556F));
            this.tableLayoutPanel52.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel52.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel52.Size = new System.Drawing.Size(388, 97);
            this.tableLayoutPanel52.TabIndex = 12;
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.BackColor = System.Drawing.Color.MistyRose;
            this.label80.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label80.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.label80.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(36)))), ((int)(((byte)(43)))));
            this.label80.Location = new System.Drawing.Point(3, 0);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(382, 21);
            this.label80.TabIndex = 0;
            this.label80.Text = "Cuello de Botella";
            this.label80.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCuelloBotella
            // 
            this.lblCuelloBotella.AutoSize = true;
            this.lblCuelloBotella.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(36)))), ((int)(((byte)(43)))));
            this.lblCuelloBotella.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCuelloBotella.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCuelloBotella.ForeColor = System.Drawing.Color.White;
            this.lblCuelloBotella.Location = new System.Drawing.Point(3, 21);
            this.lblCuelloBotella.Name = "lblCuelloBotella";
            this.lblCuelloBotella.Size = new System.Drawing.Size(382, 53);
            this.lblCuelloBotella.TabIndex = 4;
            this.lblCuelloBotella.Text = "30%";
            this.lblCuelloBotella.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNumAlta
            // 
            this.lblNumAlta.AutoSize = true;
            this.lblNumAlta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNumAlta.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblNumAlta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(36)))), ((int)(((byte)(43)))));
            this.lblNumAlta.Location = new System.Drawing.Point(3, 74);
            this.lblNumAlta.Name = "lblNumAlta";
            this.lblNumAlta.Size = new System.Drawing.Size(382, 23);
            this.lblNumAlta.TabIndex = 1;
            this.lblNumAlta.Text = "Tecnicos";
            this.lblNumAlta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel53
            // 
            this.tableLayoutPanel53.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(235)))));
            this.tableLayoutPanel53.ColumnCount = 1;
            this.tableLayoutPanel53.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel53.Controls.Add(this.lblTotalPendientes, 0, 1);
            this.tableLayoutPanel53.Controls.Add(this.label82, 0, 0);
            this.tableLayoutPanel53.Controls.Add(this.lblNumMedia, 0, 2);
            this.tableLayoutPanel53.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel53.Location = new System.Drawing.Point(785, 3);
            this.tableLayoutPanel53.Name = "tableLayoutPanel53";
            this.tableLayoutPanel53.RowCount = 3;
            this.tableLayoutPanel53.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel53.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.55556F));
            this.tableLayoutPanel53.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel53.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel53.Size = new System.Drawing.Size(385, 97);
            this.tableLayoutPanel53.TabIndex = 11;
            // 
            // lblTotalPendientes
            // 
            this.lblTotalPendientes.AutoSize = true;
            this.lblTotalPendientes.BackColor = System.Drawing.Color.Gold;
            this.lblTotalPendientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalPendientes.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPendientes.ForeColor = System.Drawing.Color.Black;
            this.lblTotalPendientes.Location = new System.Drawing.Point(3, 21);
            this.lblTotalPendientes.Name = "lblTotalPendientes";
            this.lblTotalPendientes.Size = new System.Drawing.Size(379, 53);
            this.lblTotalPendientes.TabIndex = 3;
            this.lblTotalPendientes.Text = "30%";
            this.lblTotalPendientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label82.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label82.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.label82.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label82.Location = new System.Drawing.Point(3, 0);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(379, 21);
            this.label82.TabIndex = 0;
            this.label82.Text = "Estado Pendiente General";
            this.label82.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNumMedia
            // 
            this.lblNumMedia.AutoSize = true;
            this.lblNumMedia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblNumMedia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNumMedia.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblNumMedia.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblNumMedia.Location = new System.Drawing.Point(3, 74);
            this.lblNumMedia.Name = "lblNumMedia";
            this.lblNumMedia.Size = new System.Drawing.Size(379, 23);
            this.lblNumMedia.TabIndex = 1;
            this.lblNumMedia.Text = "Tickets";
            this.lblNumMedia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel54
            // 
            this.tableLayoutPanel54.BackColor = System.Drawing.Color.GreenYellow;
            this.tableLayoutPanel54.ColumnCount = 1;
            this.tableLayoutPanel54.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel54.Controls.Add(this.label84, 0, 0);
            this.tableLayoutPanel54.Controls.Add(this.lblTicketa, 0, 2);
            this.tableLayoutPanel54.Controls.Add(this.lblTotalResueltos, 0, 1);
            this.tableLayoutPanel54.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel54.Location = new System.Drawing.Point(394, 3);
            this.tableLayoutPanel54.Name = "tableLayoutPanel54";
            this.tableLayoutPanel54.Padding = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel54.RowCount = 3;
            this.tableLayoutPanel54.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.63158F));
            this.tableLayoutPanel54.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.10526F));
            this.tableLayoutPanel54.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.26316F));
            this.tableLayoutPanel54.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel54.Size = new System.Drawing.Size(385, 97);
            this.tableLayoutPanel54.TabIndex = 10;
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.BackColor = System.Drawing.Color.Transparent;
            this.label84.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label84.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.label84.ForeColor = System.Drawing.Color.Green;
            this.label84.Location = new System.Drawing.Point(4, 1);
            this.label84.Name = "label84";
            this.label84.Padding = new System.Windows.Forms.Padding(1);
            this.label84.Size = new System.Drawing.Size(377, 26);
            this.label84.TabIndex = 0;
            this.label84.Text = "Estado Resuelto";
            this.label84.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTicketa
            // 
            this.lblTicketa.AutoSize = true;
            this.lblTicketa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTicketa.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblTicketa.ForeColor = System.Drawing.Color.Green;
            this.lblTicketa.Location = new System.Drawing.Point(4, 66);
            this.lblTicketa.Name = "lblTicketa";
            this.lblTicketa.Padding = new System.Windows.Forms.Padding(1);
            this.lblTicketa.Size = new System.Drawing.Size(377, 30);
            this.lblTicketa.TabIndex = 1;
            this.lblTicketa.Text = "Tickets";
            this.lblTicketa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalResueltos
            // 
            this.lblTotalResueltos.AutoSize = true;
            this.lblTotalResueltos.BackColor = System.Drawing.Color.Green;
            this.lblTotalResueltos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalResueltos.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalResueltos.ForeColor = System.Drawing.Color.White;
            this.lblTotalResueltos.Location = new System.Drawing.Point(4, 27);
            this.lblTotalResueltos.Name = "lblTotalResueltos";
            this.lblTotalResueltos.Size = new System.Drawing.Size(377, 39);
            this.lblTotalResueltos.TabIndex = 2;
            this.lblTotalResueltos.Text = "30%";
            this.lblTotalResueltos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel55
            // 
            this.tableLayoutPanel55.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tableLayoutPanel55.ColumnCount = 1;
            this.tableLayoutPanel55.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel55.Controls.Add(this.label86, 0, 0);
            this.tableLayoutPanel55.Controls.Add(this.button21, 0, 1);
            this.tableLayoutPanel55.Controls.Add(this.lblTotalTickets, 0, 2);
            this.tableLayoutPanel55.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel55.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel55.Name = "tableLayoutPanel55";
            this.tableLayoutPanel55.RowCount = 3;
            this.tableLayoutPanel55.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.81632F));
            this.tableLayoutPanel55.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.36735F));
            this.tableLayoutPanel55.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.81632F));
            this.tableLayoutPanel55.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel55.Size = new System.Drawing.Size(385, 97);
            this.tableLayoutPanel55.TabIndex = 9;
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label86.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.label86.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label86.Location = new System.Drawing.Point(3, 0);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(379, 39);
            this.label86.TabIndex = 0;
            this.label86.Text = "N° de Tickets";
            this.label86.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button21
            // 
            this.button21.BackColor = System.Drawing.Color.Goldenrod;
            this.button21.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button21.FlatAppearance.BorderSize = 0;
            this.button21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button21.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button21.ForeColor = System.Drawing.Color.White;
            this.button21.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button21.Location = new System.Drawing.Point(4, 46);
            this.button21.Margin = new System.Windows.Forms.Padding(4);
            this.button21.Name = "button21";
            this.button21.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.button21.Size = new System.Drawing.Size(377, 6);
            this.button21.TabIndex = 4;
            this.button21.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button21.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button21.UseVisualStyleBackColor = false;
            // 
            // lblTotalTickets
            // 
            this.lblTotalTickets.AutoSize = true;
            this.lblTotalTickets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalTickets.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalTickets.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblTotalTickets.Location = new System.Drawing.Point(3, 56);
            this.lblTotalTickets.Name = "lblTotalTickets";
            this.lblTotalTickets.Size = new System.Drawing.Size(379, 41);
            this.lblTotalTickets.TabIndex = 1;
            this.lblTotalTickets.Text = "10";
            this.lblTotalTickets.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormReportes3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1683, 853);
            this.Controls.Add(this.pnl_Reporte);
            this.Controls.Add(this.pnl_Bottom);
            this.Controls.Add(this.pnl_Top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormReportes3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SoporTec - Reportes";
            this.pnl_Top.ResumeLayout(false);
            this.pnl_Top.PerformLayout();
            this.pnl_Reporte.ResumeLayout(false);
            this.pnldatagriew.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgDetalleTecnicos)).EndInit();
            this.filtros.ResumeLayout(false);
            this.filtros.PerformLayout();
            this.filtros_especificos.ResumeLayout(false);
            this.filtros_especificos.PerformLayout();
            this.grafica.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTecnicos)).EndInit();
            this.sdr_botones.ResumeLayout(false);
            this.titulo_indicadores.ResumeLayout(false);
            this.titulo_indicadores.PerformLayout();
            this.pnl_titulo_reporte.ResumeLayout(false);
            this.pnl_titulo_reporte.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel52.ResumeLayout(false);
            this.tableLayoutPanel52.PerformLayout();
            this.tableLayoutPanel53.ResumeLayout(false);
            this.tableLayoutPanel53.PerformLayout();
            this.tableLayoutPanel54.ResumeLayout(false);
            this.tableLayoutPanel54.PerformLayout();
            this.tableLayoutPanel55.ResumeLayout(false);
            this.tableLayoutPanel55.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Top;
        private System.Windows.Forms.Panel pnl_Bottom;
        private System.Windows.Forms.Label SoporTec;
        private System.Windows.Forms.Panel pnl_Reporte;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel sdr_botones;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnLimpiarFiltros;
        private System.Windows.Forms.Button btnExportarPdf;
        private System.Windows.Forms.Panel pnl_titulo_reporte;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel titulo_indicadores;
        private System.Windows.Forms.Label titulo_metricas;
        private System.Windows.Forms.Panel grafica;
        private System.Windows.Forms.TableLayoutPanel filtros;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TableLayoutPanel filtros_especificos;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbTecnico;
        private System.Windows.Forms.Panel pnldatagriew;
        private System.Windows.Forms.DataGridView dgDetalleTecnicos;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTecnicos;
        private System.Windows.Forms.Label lblFechaGeneracion;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel52;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.Label lblCuelloBotella;
        private System.Windows.Forms.Label lblNumAlta;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel53;
        private System.Windows.Forms.Label lblTotalPendientes;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.Label lblNumMedia;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel54;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.Label lblTicketa;
        private System.Windows.Forms.Label lblTotalResueltos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel55;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Label lblTotalTickets;
    }
}
