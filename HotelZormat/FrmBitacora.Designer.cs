namespace HotelZormat
{
    partial class FrmBitacora
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
            this.lstBitacora = new System.Windows.Forms.ListView();
            this.btnAtualizar = new Guna.UI2.WinForms.Guna2Button();
            this.lblAcciones = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.SuspendLayout();
            //
            // lblAcciones
            //
            this.lblAcciones.BackColor = System.Drawing.Color.Transparent;
            this.lblAcciones.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(220)))));
            this.lblAcciones.Location = new System.Drawing.Point(46, 18);
            this.lblAcciones.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblAcciones.Name = "lblAcciones";
            this.lblAcciones.Size = new System.Drawing.Size(271, 33);
            this.lblAcciones.TabIndex = 2;
            this.lblAcciones.Text = "Registro De Acciones";
            //
            // lstBitacora
            //
            this.lstBitacora.BackColor = System.Drawing.Color.White;
            this.lstBitacora.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstBitacora.HideSelection = false;
            this.lstBitacora.Location = new System.Drawing.Point(46, 89);
            this.lstBitacora.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstBitacora.Name = "lstBitacora";
            this.lstBitacora.Size = new System.Drawing.Size(1105, 479);
            this.lstBitacora.TabIndex = 0;
            this.lstBitacora.UseCompatibleStateImageBehavior = false;
            //
            // btnAtualizar
            //
            this.btnAtualizar.BorderRadius = 10;
            this.btnAtualizar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAtualizar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAtualizar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAtualizar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAtualizar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(220)))));
            this.btnAtualizar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAtualizar.ForeColor = System.Drawing.Color.White;
            this.btnAtualizar.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.btnAtualizar.Location = new System.Drawing.Point(46, 605);
            this.btnAtualizar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(270, 69);
            this.btnAtualizar.TabIndex = 1;
            this.btnAtualizar.Text = "Actualizar";
            this.btnAtualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            //
            // FrmBitacora
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.lblAcciones);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.lstBitacora);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBitacora";
            this.Text = "FrmBitacora";
            this.Load += new System.EventHandler(this.FrmBitacora_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstBitacora;
        private Guna.UI2.WinForms.Guna2Button btnAtualizar;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblAcciones;
    }
}