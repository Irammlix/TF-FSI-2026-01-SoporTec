namespace CapaPresentacion
{
    partial class FormVerificarCodigo
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
            this.lbl_Titulo = new System.Windows.Forms.Label();
            this.lbl_Info = new System.Windows.Forms.Label();
            this.tb_Codigo = new System.Windows.Forms.TextBox();
            this.btn_Verificar = new System.Windows.Forms.Button();
            this.lnk_Reenviar = new System.Windows.Forms.LinkLabel();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lbl_Titulo
            //
            this.lbl_Titulo.AutoSize = true;
            this.lbl_Titulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lbl_Titulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(35)))), ((int)(((byte)(45)))));
            this.lbl_Titulo.Location = new System.Drawing.Point(75, 25);
            this.lbl_Titulo.Name = "lbl_Titulo";
            this.lbl_Titulo.Size = new System.Drawing.Size(291, 32);
            this.lbl_Titulo.TabIndex = 0;
            this.lbl_Titulo.Text = "Verificación de Código";
            //
            // lbl_Info
            //
            this.lbl_Info.AutoSize = true;
            this.lbl_Info.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lbl_Info.Location = new System.Drawing.Point(75, 72);
            this.lbl_Info.Name = "lbl_Info";
            this.lbl_Info.Size = new System.Drawing.Size(195, 19);
            this.lbl_Info.TabIndex = 1;
            this.lbl_Info.Text = "Se envió un código a: ***@***.com";
            //
            // tb_Codigo
            //
            this.tb_Codigo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.tb_Codigo.Location = new System.Drawing.Point(75, 110);
            this.tb_Codigo.MaxLength = 4;
            this.tb_Codigo.Name = "tb_Codigo";
            this.tb_Codigo.Size = new System.Drawing.Size(300, 50);
            this.tb_Codigo.TabIndex = 2;
            this.tb_Codigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //
            // btn_Verificar
            //
            this.btn_Verificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(35)))), ((int)(((byte)(45)))));
            this.btn_Verificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Verificar.FlatAppearance.BorderSize = 0;
            this.btn_Verificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Verificar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn_Verificar.ForeColor = System.Drawing.Color.White;
            this.btn_Verificar.Location = new System.Drawing.Point(75, 175);
            this.btn_Verificar.Name = "btn_Verificar";
            this.btn_Verificar.Size = new System.Drawing.Size(300, 45);
            this.btn_Verificar.TabIndex = 3;
            this.btn_Verificar.Text = "VERIFICAR";
            this.btn_Verificar.UseVisualStyleBackColor = false;
            this.btn_Verificar.Click += new System.EventHandler(this.btn_Verificar_Click);
            //
            // lnk_Reenviar
            //
            this.lnk_Reenviar.AutoSize = true;
            this.lnk_Reenviar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lnk_Reenviar.Location = new System.Drawing.Point(165, 235);
            this.lnk_Reenviar.Name = "lnk_Reenviar";
            this.lnk_Reenviar.Size = new System.Drawing.Size(112, 19);
            this.lnk_Reenviar.TabIndex = 4;
            this.lnk_Reenviar.TabStop = true;
            this.lnk_Reenviar.Text = "Reenviar código";
            this.lnk_Reenviar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_Reenviar_LinkClicked);
            //
            // btn_Cancelar
            //
            this.btn_Cancelar.BackColor = System.Drawing.Color.White;
            this.btn_Cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btn_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancelar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btn_Cancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.btn_Cancelar.Location = new System.Drawing.Point(75, 270);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(300, 35);
            this.btn_Cancelar.TabIndex = 5;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = false;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            //
            // FormVerificarCodigo
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(450, 330);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.lnk_Reenviar);
            this.Controls.Add(this.btn_Verificar);
            this.Controls.Add(this.tb_Codigo);
            this.Controls.Add(this.lbl_Info);
            this.Controls.Add(this.lbl_Titulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormVerificarCodigo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Verificación";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lbl_Titulo;
        private System.Windows.Forms.Label lbl_Info;
        private System.Windows.Forms.TextBox tb_Codigo;
        private System.Windows.Forms.Button btn_Verificar;
        private System.Windows.Forms.LinkLabel lnk_Reenviar;
        private System.Windows.Forms.Button btn_Cancelar;
    }
}
