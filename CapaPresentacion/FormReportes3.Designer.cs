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
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label17 = new System.Windows.Forms.Label();
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
            this.indicadores = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalTickets = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotalResueltos = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTotalPendientes = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCuelloBotella = new System.Windows.Forms.Label();
            this.titulo_metricas = new System.Windows.Forms.Label();
            this.pnl_titulo_reporte = new System.Windows.Forms.Panel();
            this.lblFechaGeneracion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_Top.SuspendLayout();
            this.pnl_Reporte.SuspendLayout();
            this.pnldatagriew.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetalleTecnicos)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            this.filtros.SuspendLayout();
            this.filtros_especificos.SuspendLayout();
            this.grafica.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTecnicos)).BeginInit();
            this.sdr_botones.SuspendLayout();
            this.titulo_indicadores.SuspendLayout();
            this.indicadores.SuspendLayout();
            this.pnl_titulo_reporte.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Top
            // 
            this.pnl_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.pnl_Top.Controls.Add(this.panel1);
            this.pnl_Top.Controls.Add(this.SoporTec);
            this.pnl_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Top.Location = new System.Drawing.Point(0, 0);
            this.pnl_Top.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnl_Top.Name = "pnl_Top";
            this.pnl_Top.Size = new System.Drawing.Size(1262, 71);
            this.pnl_Top.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 63);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1262, 8);
            this.panel1.TabIndex = 4;
            // 
            // SoporTec
            // 
            this.SoporTec.AutoSize = true;
            this.SoporTec.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.SoporTec.ForeColor = System.Drawing.Color.Navy;
            this.SoporTec.Location = new System.Drawing.Point(477, 7);
            this.SoporTec.Name = "SoporTec";
            this.SoporTec.Size = new System.Drawing.Size(302, 45);
            this.SoporTec.TabIndex = 3;
            this.SoporTec.Text = "SoporTec Reportes";
            this.SoporTec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnl_Bottom
            // 
            this.pnl_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.pnl_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_Bottom.Location = new System.Drawing.Point(0, 685);
            this.pnl_Bottom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnl_Bottom.Name = "pnl_Bottom";
            this.pnl_Bottom.Size = new System.Drawing.Size(1262, 8);
            this.pnl_Bottom.TabIndex = 1;
            // 
            // pnl_Reporte
            // 
            this.pnl_Reporte.BackColor = System.Drawing.Color.White;
            this.pnl_Reporte.Controls.Add(this.pnldatagriew);
            this.pnl_Reporte.Controls.Add(this.tableLayoutPanel5);
            this.pnl_Reporte.Controls.Add(this.filtros);
            this.pnl_Reporte.Controls.Add(this.grafica);
            this.pnl_Reporte.Controls.Add(this.sdr_botones);
            this.pnl_Reporte.Controls.Add(this.titulo_indicadores);
            this.pnl_Reporte.Controls.Add(this.pnl_titulo_reporte);
            this.pnl_Reporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Reporte.Location = new System.Drawing.Point(0, 71);
            this.pnl_Reporte.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnl_Reporte.Name = "pnl_Reporte";
            this.pnl_Reporte.Size = new System.Drawing.Size(1262, 614);
            this.pnl_Reporte.TabIndex = 5;
            // 
            // pnldatagriew
            // 
            this.pnldatagriew.Controls.Add(this.dgDetalleTecnicos);
            this.pnldatagriew.Location = new System.Drawing.Point(677, 334);
            this.pnldatagriew.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnldatagriew.Name = "pnldatagriew";
            this.pnldatagriew.Size = new System.Drawing.Size(573, 268);
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
            this.dgDetalleTecnicos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgDetalleTecnicos.Name = "dgDetalleTecnicos";
            this.dgDetalleTecnicos.ReadOnly = true;
            this.dgDetalleTecnicos.RowHeadersWidth = 51;
            this.dgDetalleTecnicos.RowTemplate.Height = 24;
            this.dgDetalleTecnicos.Size = new System.Drawing.Size(573, 268);
            this.dgDetalleTecnicos.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.label17, 0, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(678, 271);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(574, 49);
            this.tableLayoutPanel5.TabIndex = 7;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(2, 0);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(74, 49);
            this.label17.TabIndex = 1;
            this.label17.Text = "Leyenda:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // filtros
            // 
            this.filtros.ColumnCount = 1;
            this.filtros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.filtros.Controls.Add(this.filtros_especificos, 0, 1);
            this.filtros.Controls.Add(this.label10, 0, 0);
            this.filtros.Location = new System.Drawing.Point(678, 160);
            this.filtros.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.filtros.Name = "filtros";
            this.filtros.RowCount = 2;
            this.filtros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.12621F));
            this.filtros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.87379F));
            this.filtros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.filtros.Size = new System.Drawing.Size(574, 84);
            this.filtros.TabIndex = 6;
            // 
            // filtros_especificos
            // 
            this.filtros_especificos.ColumnCount = 2;
            this.filtros_especificos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.99999F));
            this.filtros_especificos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.filtros_especificos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.filtros_especificos.Controls.Add(this.cbEstado, 1, 1);
            this.filtros_especificos.Controls.Add(this.label12, 1, 0);
            this.filtros_especificos.Controls.Add(this.label11, 0, 0);
            this.filtros_especificos.Controls.Add(this.cbTecnico, 0, 1);
            this.filtros_especificos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filtros_especificos.Location = new System.Drawing.Point(2, 26);
            this.filtros_especificos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.filtros_especificos.Name = "filtros_especificos";
            this.filtros_especificos.RowCount = 2;
            this.filtros_especificos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.56338F));
            this.filtros_especificos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.43662F));
            this.filtros_especificos.Size = new System.Drawing.Size(570, 56);
            this.filtros_especificos.TabIndex = 7;
            // 
            // cbEstado
            // 
            this.cbEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Location = new System.Drawing.Point(286, 35);
            this.cbEstado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(282, 21);
            this.cbEstado.TabIndex = 6;
            this.cbEstado.SelectedIndexChanged += new System.EventHandler(this.cbEstado_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label12.Location = new System.Drawing.Point(286, 0);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 33);
            this.label12.TabIndex = 3;
            this.label12.Text = "Estado";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label11.Location = new System.Drawing.Point(2, 0);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 33);
            this.label11.TabIndex = 2;
            this.label11.Text = "Técnico";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbTecnico
            // 
            this.cbTecnico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTecnico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbTecnico.FormattingEnabled = true;
            this.cbTecnico.Location = new System.Drawing.Point(2, 35);
            this.cbTecnico.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbTecnico.Name = "cbTecnico";
            this.cbTecnico.Size = new System.Drawing.Size(280, 21);
            this.cbTecnico.TabIndex = 5;
            this.cbTecnico.SelectedIndexChanged += new System.EventHandler(this.cbTecnico_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(2, 0);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 24);
            this.label10.TabIndex = 1;
            this.label10.Text = "Filtros:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grafica
            // 
            this.grafica.Controls.Add(this.chartTecnicos);
            this.grafica.Location = new System.Drawing.Point(94, 160);
            this.grafica.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grafica.Name = "grafica";
            this.grafica.Size = new System.Drawing.Size(574, 442);
            this.grafica.TabIndex = 5;
            // 
            // chartTecnicos
            // 
            chartArea1.Name = "ChartArea1";
            this.chartTecnicos.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartTecnicos.Legends.Add(legend1);
            this.chartTecnicos.Location = new System.Drawing.Point(-3, 2);
            this.chartTecnicos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chartTecnicos.Name = "chartTecnicos";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartTecnicos.Series.Add(series1);
            this.chartTecnicos.Size = new System.Drawing.Size(574, 437);
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
            this.sdr_botones.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sdr_botones.Name = "sdr_botones";
            this.sdr_botones.RowCount = 4;
            this.sdr_botones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.sdr_botones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.sdr_botones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.sdr_botones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.sdr_botones.Size = new System.Drawing.Size(86, 614);
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
            this.btnSalir.Location = new System.Drawing.Point(3, 462);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.btnSalir.Size = new System.Drawing.Size(80, 149);
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
            this.btnLimpiarFiltros.Location = new System.Drawing.Point(3, 309);
            this.btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            this.btnLimpiarFiltros.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.btnLimpiarFiltros.Size = new System.Drawing.Size(80, 147);
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
            this.btnExportarPdf.Location = new System.Drawing.Point(3, 156);
            this.btnExportarPdf.Name = "btnExportarPdf";
            this.btnExportarPdf.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.btnExportarPdf.Size = new System.Drawing.Size(80, 147);
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
            this.btnRefrescar.Location = new System.Drawing.Point(3, 3);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.btnRefrescar.Size = new System.Drawing.Size(80, 147);
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
            this.titulo_indicadores.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.titulo_indicadores.Controls.Add(this.indicadores, 0, 1);
            this.titulo_indicadores.Controls.Add(this.titulo_metricas, 0, 0);
            this.titulo_indicadores.Location = new System.Drawing.Point(84, 42);
            this.titulo_indicadores.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.titulo_indicadores.Name = "titulo_indicadores";
            this.titulo_indicadores.RowCount = 2;
            this.titulo_indicadores.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.40741F));
            this.titulo_indicadores.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.59259F));
            this.titulo_indicadores.Size = new System.Drawing.Size(1180, 108);
            this.titulo_indicadores.TabIndex = 4;
            // 
            // indicadores
            // 
            this.indicadores.ColumnCount = 4;
            this.indicadores.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.indicadores.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.indicadores.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.indicadores.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.indicadores.Controls.Add(this.label2, 0, 0);
            this.indicadores.Controls.Add(this.lblTotalTickets, 0, 1);
            this.indicadores.Controls.Add(this.label4, 1, 0);
            this.indicadores.Controls.Add(this.lblTotalResueltos, 1, 1);
            this.indicadores.Controls.Add(this.label6, 2, 0);
            this.indicadores.Controls.Add(this.lblTotalPendientes, 2, 1);
            this.indicadores.Controls.Add(this.label8, 3, 0);
            this.indicadores.Controls.Add(this.lblCuelloBotella, 3, 1);
            this.indicadores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.indicadores.Location = new System.Drawing.Point(2, 37);
            this.indicadores.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.indicadores.Name = "indicadores";
            this.indicadores.RowCount = 2;
            this.indicadores.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.indicadores.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.indicadores.Size = new System.Drawing.Size(1176, 69);
            this.indicadores.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(290, 27);
            this.label2.TabIndex = 0;
            this.label2.Text = "Total de tickets";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblTotalTickets
            // 
            this.lblTotalTickets.AutoSize = true;
            this.lblTotalTickets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalTickets.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTickets.Location = new System.Drawing.Point(2, 27);
            this.lblTotalTickets.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalTickets.Name = "lblTotalTickets";
            this.lblTotalTickets.Size = new System.Drawing.Size(290, 42);
            this.lblTotalTickets.TabIndex = 1;
            this.lblTotalTickets.Text = "label3";
            this.lblTotalTickets.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(296, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(290, 27);
            this.label4.TabIndex = 2;
            this.label4.Text = "Total de tickets resueltos";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblTotalResueltos
            // 
            this.lblTotalResueltos.AutoSize = true;
            this.lblTotalResueltos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalResueltos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalResueltos.ForeColor = System.Drawing.Color.Navy;
            this.lblTotalResueltos.Location = new System.Drawing.Point(296, 27);
            this.lblTotalResueltos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalResueltos.Name = "lblTotalResueltos";
            this.lblTotalResueltos.Size = new System.Drawing.Size(290, 42);
            this.lblTotalResueltos.TabIndex = 3;
            this.lblTotalResueltos.Text = "label5";
            this.lblTotalResueltos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(590, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(290, 27);
            this.label6.TabIndex = 4;
            this.label6.Text = "Total tickets pendientes";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblTotalPendientes
            // 
            this.lblTotalPendientes.AutoSize = true;
            this.lblTotalPendientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalPendientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPendientes.ForeColor = System.Drawing.Color.Firebrick;
            this.lblTotalPendientes.Location = new System.Drawing.Point(590, 27);
            this.lblTotalPendientes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalPendientes.Name = "lblTotalPendientes";
            this.lblTotalPendientes.Size = new System.Drawing.Size(290, 42);
            this.lblTotalPendientes.TabIndex = 5;
            this.lblTotalPendientes.Text = "label7";
            this.lblTotalPendientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(884, 0);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(290, 27);
            this.label8.TabIndex = 6;
            this.label8.Text = "Cuello de botella";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblCuelloBotella
            // 
            this.lblCuelloBotella.AutoSize = true;
            this.lblCuelloBotella.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCuelloBotella.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCuelloBotella.Location = new System.Drawing.Point(884, 27);
            this.lblCuelloBotella.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCuelloBotella.Name = "lblCuelloBotella";
            this.lblCuelloBotella.Size = new System.Drawing.Size(290, 42);
            this.lblCuelloBotella.TabIndex = 7;
            this.lblCuelloBotella.Text = "label9";
            this.lblCuelloBotella.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // titulo_metricas
            // 
            this.titulo_metricas.AutoSize = true;
            this.titulo_metricas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titulo_metricas.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titulo_metricas.ForeColor = System.Drawing.Color.Black;
            this.titulo_metricas.Location = new System.Drawing.Point(3, 0);
            this.titulo_metricas.Name = "titulo_metricas";
            this.titulo_metricas.Size = new System.Drawing.Size(1174, 35);
            this.titulo_metricas.TabIndex = 6;
            this.titulo_metricas.Text = "Visualiza el rendimiento de los técnicos mediante la comparación de tickets resue" +
    "ltos y pendientes, facilitando la identificación de sobrecarga operativa y posib" +
    "les cuellos de botella.";
            this.titulo_metricas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnl_titulo_reporte
            // 
            this.pnl_titulo_reporte.BackColor = System.Drawing.Color.Transparent;
            this.pnl_titulo_reporte.Controls.Add(this.lblFechaGeneracion);
            this.pnl_titulo_reporte.Controls.Add(this.label1);
            this.pnl_titulo_reporte.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pnl_titulo_reporte.Location = new System.Drawing.Point(82, 0);
            this.pnl_titulo_reporte.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnl_titulo_reporte.Name = "pnl_titulo_reporte";
            this.pnl_titulo_reporte.Size = new System.Drawing.Size(1180, 41);
            this.pnl_titulo_reporte.TabIndex = 2;
            // 
            // lblFechaGeneracion
            // 
            this.lblFechaGeneracion.AutoSize = true;
            this.lblFechaGeneracion.Location = new System.Drawing.Point(993, 17);
            this.lblFechaGeneracion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFechaGeneracion.Name = "lblFechaGeneracion";
            this.lblFechaGeneracion.Size = new System.Drawing.Size(35, 13);
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
            this.label1.Location = new System.Drawing.Point(10, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(596, 30);
            this.label1.TabIndex = 5;
            this.label1.Text = "Rendimiento de Técnicos: Tickets asignados vs Resueltos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormReportes3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1262, 693);
            this.Controls.Add(this.pnl_Reporte);
            this.Controls.Add(this.pnl_Bottom);
            this.Controls.Add(this.pnl_Top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
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
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.filtros.ResumeLayout(false);
            this.filtros.PerformLayout();
            this.filtros_especificos.ResumeLayout(false);
            this.filtros_especificos.PerformLayout();
            this.grafica.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTecnicos)).EndInit();
            this.sdr_botones.ResumeLayout(false);
            this.titulo_indicadores.ResumeLayout(false);
            this.titulo_indicadores.PerformLayout();
            this.indicadores.ResumeLayout(false);
            this.indicadores.PerformLayout();
            this.pnl_titulo_reporte.ResumeLayout(false);
            this.pnl_titulo_reporte.PerformLayout();
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
        private System.Windows.Forms.TableLayoutPanel indicadores;
        private System.Windows.Forms.Label titulo_metricas;
        private System.Windows.Forms.Panel grafica;
        private System.Windows.Forms.TableLayoutPanel filtros;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TableLayoutPanel filtros_especificos;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbTecnico;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel pnldatagriew;
        private System.Windows.Forms.DataGridView dgDetalleTecnicos;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTecnicos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalTickets;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotalResueltos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTotalPendientes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCuelloBotella;
        private System.Windows.Forms.Label lblFechaGeneracion;
    }
}
