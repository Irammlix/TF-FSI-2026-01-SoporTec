using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormReportes : Form
    {
        public FormReportes(int numeroReporte)
        {
            InitializeComponent();
            MostrarPanel(numeroReporte);
        }

        private void MostrarPanel(int numeroReporte)
        {
            pnl_Reporte1.Visible = false;
            pnl_Reporte2.Visible = false;
            pnl_Reporte3.Visible = false;
            pnl_Reporte4.Visible = false;
            pnl_Reporte5.Visible = false;
            pnl_Reporte6.Visible = false;

            switch (numeroReporte)
            {
                case 1: pnl_Reporte1.Visible = true; break;
                case 2: pnl_Reporte2.Visible = true; break;
                case 3: pnl_Reporte3.Visible = true; break;
                case 4: pnl_Reporte4.Visible = true; break;
                case 5: pnl_Reporte5.Visible = true; break;
                case 6: pnl_Reporte6.Visible = true; break;
            }
        }

        private void FormReportes_Load(object sender, EventArgs e)
        {

        }
    }
}
