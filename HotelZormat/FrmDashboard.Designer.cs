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
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnCerrarSesion = new Guna.UI2.WinForms.Guna2Button();
            this.btnMenuDasboard = new Guna.UI2.WinForms.Guna2Button();
            this.btnMenuHabitaciones = new Guna.UI2.WinForms.Guna2Button();
            this.btnMenuHuesped = new Guna.UI2.WinForms.Guna2Button();
            this.btnReservas = new Guna.UI2.WinForms.Guna2Button();
            this.btnMenuReportes = new Guna.UI2.WinForms.Guna2Button();
            this.btnMenuBitacora = new Guna.UI2.WinForms.Guna2Button();
            this.lblUsuarioActual = new System.Windows.Forms.Label();
            this.flpHabitaciones = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.lblNombre);
            this.pnlMenu.Controls.Add(this.btnCerrarSesion);
            this.pnlMenu.Controls.Add(this.btnMenuDasboard);
            this.pnlMenu.Controls.Add(this.btnMenuHabitaciones);
            this.pnlMenu.Controls.Add(this.btnMenuHuesped);
            this.pnlMenu.Controls.Add(this.btnReservas);
            this.pnlMenu.Controls.Add(this.btnMenuReportes);
            this.pnlMenu.Controls.Add(this.btnMenuBitacora);
            this.pnlMenu.FillColor = System.Drawing.Color.Blue;
            this.pnlMenu.Location = new System.Drawing.Point(2, -1);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(200, 451);
            this.pnlMenu.TabIndex = 0;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.BackColor = System.Drawing.Color.Blue;
            this.lblNombre.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(10, 10);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(176, 21);
            this.lblNombre.TabIndex = 8;
            this.lblNombre.Text = "Hotel Zormat_Bae";
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCerrarSesion.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCerrarSesion.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCerrarSesion.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCerrarSesion.FillColor = System.Drawing.Color.Blue;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.White;
            this.btnCerrarSesion.Location = new System.Drawing.Point(3, 364);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(197, 53);
            this.btnCerrarSesion.TabIndex = 7;
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
            this.btnMenuDasboard.FillColor = System.Drawing.Color.Blue;
            this.btnMenuDasboard.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMenuDasboard.ForeColor = System.Drawing.Color.White;
            this.btnMenuDasboard.Location = new System.Drawing.Point(0, 54);
            this.btnMenuDasboard.Name = "btnMenuDasboard";
            this.btnMenuDasboard.Size = new System.Drawing.Size(200, 45);
            this.btnMenuDasboard.TabIndex = 1;
            this.btnMenuDasboard.Text = "Dashboard";
            // 
            // btnMenuHabitaciones
            // 
            this.btnMenuHabitaciones.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuHabitaciones.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuHabitaciones.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMenuHabitaciones.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMenuHabitaciones.FillColor = System.Drawing.Color.Blue;
            this.btnMenuHabitaciones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMenuHabitaciones.ForeColor = System.Drawing.Color.White;
            this.btnMenuHabitaciones.Location = new System.Drawing.Point(0, 105);
            this.btnMenuHabitaciones.Name = "btnMenuHabitaciones";
            this.btnMenuHabitaciones.Size = new System.Drawing.Size(200, 45);
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
            this.btnMenuHuesped.FillColor = System.Drawing.Color.Blue;
            this.btnMenuHuesped.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMenuHuesped.ForeColor = System.Drawing.Color.White;
            this.btnMenuHuesped.Location = new System.Drawing.Point(0, 156);
            this.btnMenuHuesped.Name = "btnMenuHuesped";
            this.btnMenuHuesped.Size = new System.Drawing.Size(200, 45);
            this.btnMenuHuesped.TabIndex = 3;
            this.btnMenuHuesped.Text = "Huespedes";
            this.btnMenuHuesped.Click += new System.EventHandler(this.btnMenuHuesped_Click);
            // 
            // btnReservas
            // 
            this.btnReservas.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReservas.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReservas.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReservas.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReservas.FillColor = System.Drawing.Color.Blue;
            this.btnReservas.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnReservas.ForeColor = System.Drawing.Color.White;
            this.btnReservas.Location = new System.Drawing.Point(0, 207);
            this.btnReservas.Name = "btnReservas";
            this.btnReservas.Size = new System.Drawing.Size(200, 45);
            this.btnReservas.TabIndex = 4;
            this.btnReservas.Text = "Reservas";
            this.btnReservas.Click += new System.EventHandler(this.btnReservas_Click);
            // 
            // btnMenuReportes
            // 
            this.btnMenuReportes.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuReportes.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuReportes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMenuReportes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMenuReportes.FillColor = System.Drawing.Color.Blue;
            this.btnMenuReportes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMenuReportes.ForeColor = System.Drawing.Color.White;
            this.btnMenuReportes.Location = new System.Drawing.Point(0, 258);
            this.btnMenuReportes.Name = "btnMenuReportes";
            this.btnMenuReportes.Size = new System.Drawing.Size(200, 45);
            this.btnMenuReportes.TabIndex = 5;
            this.btnMenuReportes.Text = "Resportes";
            // 
            // btnMenuBitacora
            // 
            this.btnMenuBitacora.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuBitacora.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuBitacora.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMenuBitacora.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMenuBitacora.FillColor = System.Drawing.Color.Blue;
            this.btnMenuBitacora.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMenuBitacora.ForeColor = System.Drawing.Color.White;
            this.btnMenuBitacora.Location = new System.Drawing.Point(0, 309);
            this.btnMenuBitacora.Name = "btnMenuBitacora";
            this.btnMenuBitacora.Size = new System.Drawing.Size(200, 49);
            this.btnMenuBitacora.TabIndex = 6;
            this.btnMenuBitacora.Text = "Bitacora";
            // 
            // lblUsuarioActual
            // 
            this.lblUsuarioActual.AutoSize = true;
            this.lblUsuarioActual.Location = new System.Drawing.Point(734, 13);
            this.lblUsuarioActual.Name = "lblUsuarioActual";
            this.lblUsuarioActual.Size = new System.Drawing.Size(35, 13);
            this.lblUsuarioActual.TabIndex = 1;
            this.lblUsuarioActual.Text = "label2";
            // 
            // flpHabitaciones
            // 
            this.flpHabitaciones.AutoScroll = true;
            this.flpHabitaciones.Location = new System.Drawing.Point(194, -1);
            this.flpHabitaciones.Name = "flpHabitaciones";
            this.flpHabitaciones.Size = new System.Drawing.Size(608, 451);
            this.flpHabitaciones.TabIndex = 2;
            this.flpHabitaciones.Paint += new System.Windows.Forms.PaintEventHandler(this.flpHabitaciones_Paint);
            // 
            // FrmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flpHabitaciones);
            this.Controls.Add(this.lblUsuarioActual);
            this.Controls.Add(this.pnlMenu);
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
        private System.Windows.Forms.FlowLayoutPanel flpHabitaciones;
    }
}