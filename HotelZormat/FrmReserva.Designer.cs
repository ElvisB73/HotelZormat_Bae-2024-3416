namespace HotelZormat
{
    partial class Frmreserva
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
            this.btnCrearReserva = new Guna.UI2.WinForms.Guna2Button();
            this.lblHabitacion = new System.Windows.Forms.Label();
            this.cbohabitacion = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtBuscarHuesped = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboTemporada = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblCheckin = new System.Windows.Forms.Label();
            this.lblCheckOut = new System.Windows.Forms.Label();
            this.lblhuesped = new System.Windows.Forms.Label();
            this.lblNoches = new System.Windows.Forms.Label();
            this.lblTemporada = new System.Windows.Forms.Label();
            this.lblCancelar = new Guna.UI2.WinForms.Guna2Button();
            this.btnConfirmar = new Guna.UI2.WinForms.Guna2Button();
            this.btnBuscar = new Guna.UI2.WinForms.Guna2Button();
            this.lstReservasProximas = new System.Windows.Forms.ListView();
            this.lblReserva = new System.Windows.Forms.Label();
            this.lblMonto = new System.Windows.Forms.Label();
            this.dtpCheckIn = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpCheckOut = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblHuespedEncontrado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCrearReserva
            // 
            this.btnCrearReserva.BorderRadius = 10;
            this.btnCrearReserva.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCrearReserva.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCrearReserva.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCrearReserva.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCrearReserva.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCrearReserva.ForeColor = System.Drawing.Color.White;
            this.btnCrearReserva.Location = new System.Drawing.Point(26, 393);
            this.btnCrearReserva.Name = "btnCrearReserva";
            this.btnCrearReserva.Size = new System.Drawing.Size(180, 45);
            this.btnCrearReserva.TabIndex = 0;
            this.btnCrearReserva.Text = "Reservar";
            this.btnCrearReserva.Click += new System.EventHandler(this.btnCrearReserva_Click);
            // 
            // lblHabitacion
            // 
            this.lblHabitacion.AutoSize = true;
            this.lblHabitacion.Location = new System.Drawing.Point(27, 55);
            this.lblHabitacion.Name = "lblHabitacion";
            this.lblHabitacion.Size = new System.Drawing.Size(58, 13);
            this.lblHabitacion.TabIndex = 1;
            this.lblHabitacion.Text = "Habitacion";
            // 
            // cbohabitacion
            // 
            this.cbohabitacion.BackColor = System.Drawing.Color.Transparent;
            this.cbohabitacion.BorderRadius = 10;
            this.cbohabitacion.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbohabitacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbohabitacion.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbohabitacion.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbohabitacion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbohabitacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbohabitacion.ItemHeight = 30;
            this.cbohabitacion.Location = new System.Drawing.Point(26, 71);
            this.cbohabitacion.Name = "cbohabitacion";
            this.cbohabitacion.Size = new System.Drawing.Size(140, 36);
            this.cbohabitacion.TabIndex = 2;
            this.cbohabitacion.SelectedIndexChanged += new System.EventHandler(this.cbohabitacion_SelectedIndexChanged);
            // 
            // txtBuscarHuesped
            // 
            this.txtBuscarHuesped.BorderRadius = 10;
            this.txtBuscarHuesped.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscarHuesped.DefaultText = "";
            this.txtBuscarHuesped.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBuscarHuesped.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBuscarHuesped.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscarHuesped.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscarHuesped.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBuscarHuesped.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBuscarHuesped.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBuscarHuesped.Location = new System.Drawing.Point(26, 144);
            this.txtBuscarHuesped.Name = "txtBuscarHuesped";
            this.txtBuscarHuesped.PlaceholderText = "";
            this.txtBuscarHuesped.SelectedText = "";
            this.txtBuscarHuesped.Size = new System.Drawing.Size(200, 36);
            this.txtBuscarHuesped.TabIndex = 3;
            // 
            // cboTemporada
            // 
            this.cboTemporada.BackColor = System.Drawing.Color.Transparent;
            this.cboTemporada.BorderRadius = 10;
            this.cboTemporada.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTemporada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTemporada.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTemporada.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTemporada.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTemporada.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboTemporada.ItemHeight = 30;
            this.cboTemporada.Location = new System.Drawing.Point(27, 322);
            this.cboTemporada.Name = "cboTemporada";
            this.cboTemporada.Size = new System.Drawing.Size(200, 36);
            this.cboTemporada.TabIndex = 4;
            this.cboTemporada.SelectedIndexChanged += new System.EventHandler(this.cboTemporada_SelectedIndexChanged);
            // 
            // lblCheckin
            // 
            this.lblCheckin.AutoSize = true;
            this.lblCheckin.Location = new System.Drawing.Point(36, 212);
            this.lblCheckin.Name = "lblCheckin";
            this.lblCheckin.Size = new System.Drawing.Size(49, 13);
            this.lblCheckin.TabIndex = 7;
            this.lblCheckin.Text = "Check-in";
            // 
            // lblCheckOut
            // 
            this.lblCheckOut.AutoSize = true;
            this.lblCheckOut.Location = new System.Drawing.Point(28, 258);
            this.lblCheckOut.Name = "lblCheckOut";
            this.lblCheckOut.Size = new System.Drawing.Size(58, 13);
            this.lblCheckOut.TabIndex = 8;
            this.lblCheckOut.Text = "Check-Out";
            // 
            // lblhuesped
            // 
            this.lblhuesped.AutoSize = true;
            this.lblhuesped.Location = new System.Drawing.Point(23, 128);
            this.lblhuesped.Name = "lblhuesped";
            this.lblhuesped.Size = new System.Drawing.Size(150, 13);
            this.lblhuesped.TabIndex = 9;
            this.lblhuesped.Text = "Huesped (cedula o pasaporte)";
            // 
            // lblNoches
            // 
            this.lblNoches.AutoSize = true;
            this.lblNoches.Location = new System.Drawing.Point(39, 371);
            this.lblNoches.Name = "lblNoches";
            this.lblNoches.Size = new System.Drawing.Size(47, 13);
            this.lblNoches.TabIndex = 10;
            this.lblNoches.Text = "Noches:";
            this.lblNoches.Click += new System.EventHandler(this.label5_Click);
            // 
            // lblTemporada
            // 
            this.lblTemporada.AutoSize = true;
            this.lblTemporada.Location = new System.Drawing.Point(24, 306);
            this.lblTemporada.Name = "lblTemporada";
            this.lblTemporada.Size = new System.Drawing.Size(61, 13);
            this.lblTemporada.TabIndex = 11;
            this.lblTemporada.Text = "Temporada";
            // 
            // lblCancelar
            // 
            this.lblCancelar.BorderRadius = 10;
            this.lblCancelar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.lblCancelar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.lblCancelar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.lblCancelar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.lblCancelar.FillColor = System.Drawing.Color.Red;
            this.lblCancelar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCancelar.ForeColor = System.Drawing.Color.White;
            this.lblCancelar.Location = new System.Drawing.Point(591, 196);
            this.lblCancelar.Name = "lblCancelar";
            this.lblCancelar.Size = new System.Drawing.Size(180, 45);
            this.lblCancelar.TabIndex = 12;
            this.lblCancelar.Text = "Cancelar";
            this.lblCancelar.Click += new System.EventHandler(this.lblCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BorderRadius = 10;
            this.btnConfirmar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnConfirmar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnConfirmar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnConfirmar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnConfirmar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Location = new System.Drawing.Point(346, 196);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(180, 45);
            this.btnConfirmar.TabIndex = 13;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BorderRadius = 10;
            this.btnBuscar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBuscar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBuscar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBuscar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(253, 144);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(95, 25);
            this.btnBuscar.TabIndex = 14;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lstReservasProximas
            // 
            this.lstReservasProximas.CheckBoxes = true;
            this.lstReservasProximas.FullRowSelect = true;
            this.lstReservasProximas.GridLines = true;
            this.lstReservasProximas.HideSelection = false;
            this.lstReservasProximas.Location = new System.Drawing.Point(389, 40);
            this.lstReservasProximas.Name = "lstReservasProximas";
            this.lstReservasProximas.ShowItemToolTips = true;
            this.lstReservasProximas.Size = new System.Drawing.Size(400, 140);
            this.lstReservasProximas.TabIndex = 15;
            this.lstReservasProximas.UseCompatibleStateImageBehavior = false;
            this.lstReservasProximas.View = System.Windows.Forms.View.Details;
            // 
            // lblReserva
            // 
            this.lblReserva.AutoSize = true;
            this.lblReserva.Location = new System.Drawing.Point(386, 24);
            this.lblReserva.Name = "lblReserva";
            this.lblReserva.Size = new System.Drawing.Size(82, 13);
            this.lblReserva.TabIndex = 16;
            this.lblReserva.Text = "Proximos 7 Dias";
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(156, 371);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(40, 13);
            this.lblMonto.TabIndex = 17;
            this.lblMonto.Text = "Monto:";
            // 
            // dtpCheckIn
            // 
            this.dtpCheckIn.BorderRadius = 10;
            this.dtpCheckIn.Checked = true;
            this.dtpCheckIn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpCheckIn.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpCheckIn.Location = new System.Drawing.Point(27, 230);
            this.dtpCheckIn.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpCheckIn.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpCheckIn.Name = "dtpCheckIn";
            this.dtpCheckIn.Size = new System.Drawing.Size(194, 25);
            this.dtpCheckIn.TabIndex = 18;
            this.dtpCheckIn.Value = new System.DateTime(2026, 7, 31, 15, 41, 57, 902);
            this.dtpCheckIn.ValueChanged += new System.EventHandler(this.dtpCheckIn_ValueChanged);
            // 
            // dtpCheckOut
            // 
            this.dtpCheckOut.BorderRadius = 10;
            this.dtpCheckOut.Checked = true;
            this.dtpCheckOut.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpCheckOut.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpCheckOut.Location = new System.Drawing.Point(27, 278);
            this.dtpCheckOut.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpCheckOut.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpCheckOut.Name = "dtpCheckOut";
            this.dtpCheckOut.Size = new System.Drawing.Size(194, 25);
            this.dtpCheckOut.TabIndex = 19;
            this.dtpCheckOut.Value = new System.DateTime(2026, 7, 31, 15, 41, 57, 902);
            this.dtpCheckOut.ValueChanged += new System.EventHandler(this.dtpCheckOut_ValueChanged);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(23, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(136, 21);
            this.lblTitulo.TabIndex = 20;
            this.lblTitulo.Text = "Nueva Reserva";
            // 
            // lblHuespedEncontrado
            // 
            this.lblHuespedEncontrado.AutoSize = true;
            this.lblHuespedEncontrado.Location = new System.Drawing.Point(39, 183);
            this.lblHuespedEncontrado.Name = "lblHuespedEncontrado";
            this.lblHuespedEncontrado.Size = new System.Drawing.Size(0, 13);
            this.lblHuespedEncontrado.TabIndex = 21;
            this.lblHuespedEncontrado.Click += new System.EventHandler(this.label1_Click);
            // 
            // Frmreserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblHuespedEncontrado);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.dtpCheckOut);
            this.Controls.Add(this.dtpCheckIn);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.lblReserva);
            this.Controls.Add(this.lstReservasProximas);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.lblCancelar);
            this.Controls.Add(this.lblTemporada);
            this.Controls.Add(this.lblNoches);
            this.Controls.Add(this.lblhuesped);
            this.Controls.Add(this.lblCheckOut);
            this.Controls.Add(this.lblCheckin);
            this.Controls.Add(this.cboTemporada);
            this.Controls.Add(this.txtBuscarHuesped);
            this.Controls.Add(this.cbohabitacion);
            this.Controls.Add(this.lblHabitacion);
            this.Controls.Add(this.btnCrearReserva);
            this.Name = "Frmreserva";
            this.Text = "Frmreserva";
            this.Load += new System.EventHandler(this.Frmreserva_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnCrearReserva;
        private System.Windows.Forms.Label lblHabitacion;
        private Guna.UI2.WinForms.Guna2ComboBox cbohabitacion;
        private Guna.UI2.WinForms.Guna2TextBox txtBuscarHuesped;
        private Guna.UI2.WinForms.Guna2ComboBox cboTemporada;
        private System.Windows.Forms.Label lblCheckin;
        private System.Windows.Forms.Label lblCheckOut;
        private System.Windows.Forms.Label lblhuesped;
        private System.Windows.Forms.Label lblNoches;
        private System.Windows.Forms.Label lblTemporada;
        private Guna.UI2.WinForms.Guna2Button lblCancelar;
        private Guna.UI2.WinForms.Guna2Button btnConfirmar;
        private Guna.UI2.WinForms.Guna2Button btnBuscar;
        private System.Windows.Forms.ListView lstReservasProximas;
        private System.Windows.Forms.Label lblReserva;
        private System.Windows.Forms.Label lblMonto;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpCheckIn;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpCheckOut;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblHuespedEncontrado;
    }
}