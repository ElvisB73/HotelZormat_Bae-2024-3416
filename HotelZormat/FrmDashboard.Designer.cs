namespace HotelZormat
{
    partial class FrmDashboard
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
            this.pnlMenu = new Guna.UI2.WinForms.Guna2Panel();
            this.BtnMenuCheckInOut = new Guna.UI2.WinForms.Guna2Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnCerrarSesion = new Guna.UI2.WinForms.Guna2Button();
            this.btnMenuDasboard = new Guna.UI2.WinForms.Guna2Button();
            this.btnMenuHabitaciones = new Guna.UI2.WinForms.Guna2Button();
            this.btnMenuHuesped = new Guna.UI2.WinForms.Guna2Button();
            this.btnReservas = new Guna.UI2.WinForms.Guna2Button();
            this.btnMenuReportes = new Guna.UI2.WinForms.Guna2Button();
            this.btnMenuBitacora = new Guna.UI2.WinForms.Guna2Button();
            this.lblUsuarioActual = new System.Windows.Forms.Label();
            this.flpLeyenda = new System.Windows.Forms.FlowLayoutPanel();
            this.flpHabitaciones = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.BtnMenuCheckInOut);
            this.pnlMenu.Controls.Add(this.lblNombre);
            this.pnlMenu.Controls.Add(this.btnCerrarSesion);
            this.pnlMenu.Controls.Add(this.btnMenuDasboard);
            this.pnlMenu.Controls.Add(this.btnMenuHabitaciones);
            this.pnlMenu.Controls.Add(this.btnMenuHuesped);
            this.pnlMenu.Controls.Add(this.btnReservas);
            this.pnlMenu.Controls.Add(this.btnMenuReportes);
            this.pnlMenu.Controls.Add(this.btnMenuBitacora);
            this.pnlMenu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(220)))));
            this.pnlMenu.Location = new System.Drawing.Point(3, -2);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(300, 694);
            this.pnlMenu.TabIndex = 0;
            // 
            // BtnMenuCheckInOut
            // 
            this.BtnMenuCheckInOut.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnMenuCheckInOut.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnMenuCheckInOut.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnMenuCheckInOut.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnMenuCheckInOut.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(220)))));
            this.BtnMenuCheckInOut.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnMenuCheckInOut.ForeColor = System.Drawing.Color.White;
            this.BtnMenuCheckInOut.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.BtnMenuCheckInOut.Image = global::HotelZormat.Properties.Resources.icon_checkinout;
            this.BtnMenuCheckInOut.Location = new System.Drawing.Point(10, 352);
            this.BtnMenuCheckInOut.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnMenuCheckInOut.Name = "BtnMenuCheckInOut";
            this.BtnMenuCheckInOut.Size = new System.Drawing.Size(280, 60);
            this.BtnMenuCheckInOut.TabIndex = 5;
            this.BtnMenuCheckInOut.Text = "Check-In / Check-Out";
            this.BtnMenuCheckInOut.Click += new System.EventHandler(this.btnMenuCheckInOut_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.BackColor = System.Drawing.Color.Transparent;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(15, 20);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(202, 40);
            this.lblNombre.TabIndex = 8;
            this.lblNombre.Text = "Hotel Zormat";
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCerrarSesion.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCerrarSesion.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCerrarSesion.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCerrarSesion.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.btnCerrarSesion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.White;
            this.btnCerrarSesion.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.btnCerrarSesion.Image = global::HotelZormat.Properties.Resources.icon_cerrarsesion;
            this.btnCerrarSesion.Location = new System.Drawing.Point(10, 600);
            this.btnCerrarSesion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(280, 70);
            this.btnCerrarSesion.TabIndex = 8;
            this.btnCerrarSesion.Text = "Cerrar Sesion";
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // btnMenuDasboard
            // 
            this.btnMenuDasboard.BorderColor = System.Drawing.Color.Transparent;
            this.btnMenuDasboard.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuDasboard.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuDasboard.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMenuDasboard.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMenuDasboard.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.btnMenuDasboard.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMenuDasboard.ForeColor = System.Drawing.Color.White;
            this.btnMenuDasboard.Image = global::HotelZormat.Properties.Resources.icon_dashboard;
            this.btnMenuDasboard.Location = new System.Drawing.Point(10, 80);
            this.btnMenuDasboard.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMenuDasboard.Name = "btnMenuDasboard";
            this.btnMenuDasboard.Size = new System.Drawing.Size(280, 60);
            this.btnMenuDasboard.TabIndex = 1;
            this.btnMenuDasboard.Text = "   Dashboard";
            // 
            // btnMenuHabitaciones
            // 
            this.btnMenuHabitaciones.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuHabitaciones.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuHabitaciones.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMenuHabitaciones.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMenuHabitaciones.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(220)))));
            this.btnMenuHabitaciones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMenuHabitaciones.ForeColor = System.Drawing.Color.White;
            this.btnMenuHabitaciones.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.btnMenuHabitaciones.Image = global::HotelZormat.Properties.Resources.icon_habitaciones;
            this.btnMenuHabitaciones.Location = new System.Drawing.Point(10, 148);
            this.btnMenuHabitaciones.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMenuHabitaciones.Name = "btnMenuHabitaciones";
            this.btnMenuHabitaciones.Size = new System.Drawing.Size(280, 60);
            this.btnMenuHabitaciones.TabIndex = 2;
            this.btnMenuHabitaciones.Text = "Habitaciones";
            this.btnMenuHabitaciones.Click += new System.EventHandler(this.btnMenuHabitaciones_Click);
            // 
            // btnMenuHuesped
            // 
            this.btnMenuHuesped.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuHuesped.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuHuesped.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMenuHuesped.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMenuHuesped.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(220)))));
            this.btnMenuHuesped.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMenuHuesped.ForeColor = System.Drawing.Color.White;
            this.btnMenuHuesped.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.btnMenuHuesped.Image = global::HotelZormat.Properties.Resources.icon_huespedes;
            this.btnMenuHuesped.Location = new System.Drawing.Point(10, 216);
            this.btnMenuHuesped.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMenuHuesped.Name = "btnMenuHuesped";
            this.btnMenuHuesped.Size = new System.Drawing.Size(280, 60);
            this.btnMenuHuesped.TabIndex = 3;
            this.btnMenuHuesped.Text = "Huespedes";
            this.btnMenuHuesped.Click += new System.EventHandler(this.btnMenuHuespedes_Click);
            // 
            // btnReservas
            // 
            this.btnReservas.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReservas.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReservas.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReservas.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReservas.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(220)))));
            this.btnReservas.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnReservas.ForeColor = System.Drawing.Color.White;
            this.btnReservas.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.btnReservas.Image = global::HotelZormat.Properties.Resources.icon_reservas;
            this.btnReservas.Location = new System.Drawing.Point(10, 284);
            this.btnReservas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReservas.Name = "btnReservas";
            this.btnReservas.Size = new System.Drawing.Size(280, 60);
            this.btnReservas.TabIndex = 4;
            this.btnReservas.Text = "Reservas";
            this.btnReservas.Click += new System.EventHandler(this.btnMenuReservas_Click);
            // 
            // btnMenuReportes
            // 
            this.btnMenuReportes.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuReportes.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuReportes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMenuReportes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMenuReportes.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(220)))));
            this.btnMenuReportes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMenuReportes.ForeColor = System.Drawing.Color.White;
            this.btnMenuReportes.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.btnMenuReportes.Image = global::HotelZormat.Properties.Resources.icon_reportes;
            this.btnMenuReportes.Location = new System.Drawing.Point(10, 420);
            this.btnMenuReportes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMenuReportes.Name = "btnMenuReportes";
            this.btnMenuReportes.Size = new System.Drawing.Size(280, 60);
            this.btnMenuReportes.TabIndex = 6;
            this.btnMenuReportes.Text = "Reportes";
            this.btnMenuReportes.Click += new System.EventHandler(this.btnMenuReportes_Click);
            // 
            // btnMenuBitacora
            // 
            this.btnMenuBitacora.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuBitacora.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuBitacora.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMenuBitacora.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMenuBitacora.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(220)))));
            this.btnMenuBitacora.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMenuBitacora.ForeColor = System.Drawing.Color.White;
            this.btnMenuBitacora.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.btnMenuBitacora.Image = global::HotelZormat.Properties.Resources.icon_bitacora__1_;
            this.btnMenuBitacora.Location = new System.Drawing.Point(10, 488);
            this.btnMenuBitacora.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMenuBitacora.Name = "btnMenuBitacora";
            this.btnMenuBitacora.Size = new System.Drawing.Size(280, 60);
            this.btnMenuBitacora.TabIndex = 7;
            this.btnMenuBitacora.Text = "Bitacora";
            this.btnMenuBitacora.Click += new System.EventHandler(this.btnMenuBitacora_Click);
            // 
            // lblUsuarioActual
            // 
            this.lblUsuarioActual.AutoSize = true;
            this.lblUsuarioActual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(122)))), ((int)(((byte)(137)))));
            this.lblUsuarioActual.Location = new System.Drawing.Point(969, 9);
            this.lblUsuarioActual.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsuarioActual.Name = "lblUsuarioActual";
            this.lblUsuarioActual.Size = new System.Drawing.Size(51, 20);
            this.lblUsuarioActual.TabIndex = 1;
            this.lblUsuarioActual.Text = "label2";
            // 
            // flpLeyenda
            // 
            this.flpLeyenda.Location = new System.Drawing.Point(311, 0);
            this.flpLeyenda.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flpLeyenda.Name = "flpLeyenda";
            this.flpLeyenda.Size = new System.Drawing.Size(650, 36);
            this.flpLeyenda.TabIndex = 3;
            // 
            // flpHabitaciones
            // 
            this.flpHabitaciones.AutoScroll = true;
            this.flpHabitaciones.Location = new System.Drawing.Point(291, 46);
            this.flpHabitaciones.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flpHabitaciones.Name = "flpHabitaciones";
            this.flpHabitaciones.Size = new System.Drawing.Size(912, 648);
            this.flpHabitaciones.TabIndex = 2;
            // 
            // FrmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.flpHabitaciones);
            this.Controls.Add(this.flpLeyenda);
            this.Controls.Add(this.lblUsuarioActual);
            this.Controls.Add(this.pnlMenu);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FrmDashboard";
            this.Text = "Frmdashboard";
            this.Load += new System.EventHandler(this.FrmDashboard_Load);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlMenu;
        private Guna.UI2.WinForms.Guna2Button btnMenuDasboard;
        private Guna.UI2.WinForms.Guna2Button btnMenuHabitaciones;
        private Guna.UI2.WinForms.Guna2Button btnMenuHuesped;
        private Guna.UI2.WinForms.Guna2Button btnReservas;
        private Guna.UI2.WinForms.Guna2Button btnMenuReportes;
        private Guna.UI2.WinForms.Guna2Button btnMenuBitacora;
        private Guna.UI2.WinForms.Guna2Button btnCerrarSesion;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblUsuarioActual;
        private System.Windows.Forms.FlowLayoutPanel flpLeyenda;
        private System.Windows.Forms.FlowLayoutPanel flpHabitaciones;
        private Guna.UI2.WinForms.Guna2Button BtnMenuCheckInOut;
    }
}