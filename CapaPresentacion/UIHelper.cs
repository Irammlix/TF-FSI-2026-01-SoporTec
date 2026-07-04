using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public static class UIHelper
    {
        // ============== TOGGLE MOSTRAR/OCULTAR CONTRASEÑA ==============
        public static void AgregarTogglePassword(TextBox textBox)
        {
            textBox.UseSystemPasswordChar = true;

            var lbl = new Label
            {
                Text = "●",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Size = new Size(28, textBox.Height),
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand,
                BackColor = textBox.BackColor,
                ForeColor = Color.Gray
            };
            lbl.Location = new Point(textBox.ClientSize.Width - lbl.Width, 0);
            lbl.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            textBox.Controls.Add(lbl);
            lbl.BringToFront();

            bool visible = false;
            lbl.Click += (s, e) =>
            {
                visible = !visible;
                textBox.UseSystemPasswordChar = !visible;
                lbl.Text = visible ? "○" : "●";
                lbl.ForeColor = visible ? Color.FromArgb(180, 35, 45) : Color.Gray;
            };
        }
    }
}
