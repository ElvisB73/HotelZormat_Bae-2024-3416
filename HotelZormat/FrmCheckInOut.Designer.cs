namespace HotelZormat
{
    partial class FrmCheckInOut
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstReservasConfirmadas = new System.Windows.Forms.ListView();
            this.lstHabitacionesOcupadas = new System.Windows.Forms.ListView();
            this.btnHacerCheckIn = new Guna.UI2.WinForms.Guna2Button();
            this.btnCheckOut = new Guna.UI2.WinForms.Guna2Button();
            this.lblCheckOut = new System.Windows.Forms.Label();
            this.lblHabitacionesOcupadas = new System.Windows.Forms.Label();
            this.lblCheckIn = new System.Windows.Forms.Label();
            this.LblReservasConfirmadas = new System.Windows.Forms.Label();
            this.lblFactura = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstReservasConfirmadas
            // 
            this.lstReservasConfirmadas.HideSelection = false;
            this.lstReservasConfirmadas.Location = new System.Drawing.Point(38, 29);
            this.lstReservasConfirmadas.Name = "lstReservasConfirmadas";
            this.lstReservasConfirmadas.Size = new System.Drawing.Size(349, 194);
            this.lstReservasConfirmadas.TabIndex = 0;
            this.lstReservasConfirmadas.UseCompatibleStateImageBehavior = false;
            // 
            // lstHabitacionesOcupadas
            // 
            this.lstHabitacionesOcupadas.HideSelection = false;
            this.lstHabitacionesOcupadas.Location = new System.Drawing.Point(427, 29);
            this.lstHabitacionesOcupadas.Name = "lstHabitacionesOcupadas";
            this.lstHabitacionesOcupadas.Size = new System.Drawing.Size(314, 194);
            this.lstHabitacionesOcupadas.TabIndex = 1;
            this.lstHabitacionesOcupadas.UseCompatibleStateImageBehavior = false;
           // this.lstHabitacionesOcupadas.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // btnHacerCheckIn
            // 
            this.btnHacerCheckIn.BorderRadius = 10;
            this.btnHacerCheckIn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHacerCheckIn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHacerCheckIn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHacerCheckIn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHacerCheckIn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnHacerCheckIn.ForeColor = System.Drawing.Color.White;
            this.btnHacerCheckIn.Location = new System.Drawing.Point(38, 280);
            this.btnHacerCheckIn.Name = "btnHacerCheckIn";
            this.btnHacerCheckIn.Size = new System.Drawing.Size(180, 45);
            this.btnHacerCheckIn.TabIndex = 2;
            this.btnHacerCheckIn.Text = "Check-In";
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.BorderRadius = 10;
            this.btnCheckOut.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCheckOut.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCheckOut.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCheckOut.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCheckOut.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCheckOut.ForeColor = System.Drawing.Color.White;
            this.btnCheckOut.Location = new System.Drawing.Point(427, 280);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(180, 45);
            this.btnCheckOut.TabIndex = 3;
            this.btnCheckOut.Text = "Check-Out";
            // 
            // lblCheckOut
            // 
            this.lblCheckOut.AutoSize = true;
            this.lblCheckOut.Location = new System.Drawing.Point(424, 13);
            this.lblCheckOut.Name = "lblCheckOut";
            this.lblCheckOut.Size = new System.Drawing.Size(181, 13);
            this.lblCheckOut.TabIndex = 4;
            this.lblCheckOut.Text = "Check-Out ( HabitacionesOcupadas)";
            // 
            // lblHabitacionesOcupadas
            // 
            this.lblHabitacionesOcupadas.AutoSize = true;
            this.lblHabitacionesOcupadas.Location = new System.Drawing.Point(424, 236);
            this.lblHabitacionesOcupadas.Name = "lblHabitacionesOcupadas";
            this.lblHabitacionesOcupadas.Size = new System.Drawing.Size(0, 13);
            this.lblHabitacionesOcupadas.TabIndex = 5;
            // 
            // lblCheckIn
            // 
            this.lblCheckIn.AutoSize = true;
            this.lblCheckIn.Location = new System.Drawing.Point(35, 13);
            this.lblCheckIn.Name = "lblCheckIn";
            this.lblCheckIn.Size = new System.Drawing.Size(155, 13);
            this.lblCheckIn.TabIndex = 6;
            this.lblCheckIn.Text = "Check-In (Reserva Confirmada)";
            // 
            // LblReservasConfirmadas
            // 
            this.LblReservasConfirmadas.AutoSize = true;
            this.LblReservasConfirmadas.Location = new System.Drawing.Point(35, 236);
            this.LblReservasConfirmadas.Name = "LblReservasConfirmadas";
            this.LblReservasConfirmadas.Size = new System.Drawing.Size(0, 13);
            this.LblReservasConfirmadas.TabIndex = 7;
            // 
            // lblFactura
            // 
            this.lblFactura.AutoSize = true;
            this.lblFactura.Location = new System.Drawing.Point(35, 357);
            this.lblFactura.Name = "lblFactura";
            this.lblFactura.Size = new System.Drawing.Size(122, 13);
            this.lblFactura.TabIndex = 8;
            this.lblFactura.Text = "Ultima factura Generada";
            // 
            // FrmCheckInOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblFactura);
            this.Controls.Add(this.LblReservasConfirmadas);
            this.Controls.Add(this.lblCheckIn);
            this.Controls.Add(this.lblHabitacionesOcupadas);
            this.Controls.Add(this.lblCheckOut);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.btnHacerCheckIn);
            this.Controls.Add(this.lstHabitacionesOcupadas);
            this.Controls.Add(this.lstReservasConfirmadas);
            this.Name = "FrmCheckInOut";
            this.Text = "FrmCheckInOut";
            this.Load += new System.EventHandler(this.FrmCheckInOut_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstReservasConfirmadas;
        private System.Windows.Forms.ListView lstHabitacionesOcupadas;
        private Guna.UI2.WinForms.Guna2Button btnHacerCheckIn;
        private Guna.UI2.WinForms.Guna2Button btnCheckOut;
        private System.Windows.Forms.Label lblCheckOut;
        private System.Windows.Forms.Label lblHabitacionesOcupadas;
        private System.Windows.Forms.Label lblCheckIn;
        private System.Windows.Forms.Label LblReservasConfirmadas;
        private System.Windows.Forms.Label lblFactura;
    }
}