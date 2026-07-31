using System;

namespace HotelZormat
{
    partial class FrmHabitacionGestiion
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTituloTipo = new System.Windows.Forms.Label();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.lblIcono = new System.Windows.Forms.Label();
            this.lblTarifa = new System.Windows.Forms.Label();
            this.lblTituloLista = new System.Windows.Forms.Label();
            this.lstHabitaciones = new System.Windows.Forms.ListBox();
            this.lblTituloBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.btnReservar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTituloTipo
            // 
            this.lblTituloTipo.Location = new System.Drawing.Point(12, 15);
            this.lblTituloTipo.Name = "lblTituloTipo";
            this.lblTituloTipo.Size = new System.Drawing.Size(130, 16);
            this.lblTituloTipo.TabIndex = 0;
            this.lblTituloTipo.Text = "Tipo de habitación:";
            // 
            // cboTipo
            // 
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.Location = new System.Drawing.Point(12, 35);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(150, 28);
            this.cboTipo.TabIndex = 1;
            this.cboTipo.SelectedIndexChanged += new System.EventHandler(this.cboTipo_SelectedIndexChanged);
            // 
            // lblIcono
            // 
            this.lblIcono.Location = new System.Drawing.Point(175, 35);
            this.lblIcono.Name = "lblIcono";
            this.lblIcono.Size = new System.Drawing.Size(30, 24);
            this.lblIcono.TabIndex = 2;
            // 
            // lblTarifa
            // 
            this.lblTarifa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTarifa.Location = new System.Drawing.Point(210, 38);
            this.lblTarifa.Name = "lblTarifa";
            this.lblTarifa.Size = new System.Drawing.Size(180, 16);
            this.lblTarifa.TabIndex = 3;
            this.lblTarifa.Text = "Tarifa: RD$ 0.00";
            // 
            // lblTituloLista
            // 
            this.lblTituloLista.Location = new System.Drawing.Point(12, 72);
            this.lblTituloLista.Name = "lblTituloLista";
            this.lblTituloLista.Size = new System.Drawing.Size(140, 16);
            this.lblTituloLista.TabIndex = 4;
            this.lblTituloLista.Text = "Habitaciones - Piso";
            // 
            // lstHabitaciones
            // 
            this.lstHabitaciones.ItemHeight = 20;
            this.lstHabitaciones.Location = new System.Drawing.Point(12, 90);
            this.lstHabitaciones.Name = "lstHabitaciones";
            this.lstHabitaciones.Size = new System.Drawing.Size(160, 84);
            this.lstHabitaciones.TabIndex = 5;
            // 
            // lblTituloBuscar
            // 
            this.lblTituloBuscar.Location = new System.Drawing.Point(12, 205);
            this.lblTituloBuscar.Name = "lblTituloBuscar";
            this.lblTituloBuscar.Size = new System.Drawing.Size(120, 16);
            this.lblTituloBuscar.TabIndex = 6;
            this.lblTituloBuscar.Text = "Buscar habitación";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(12, 224);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(120, 26);
            this.txtBuscar.TabIndex = 7;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(140, 222);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(70, 26);
            this.btnBuscar.TabIndex = 8;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblEstado
            // 
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblEstado.Location = new System.Drawing.Point(12, 262);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(200, 18);
            this.lblEstado.TabIndex = 9;
            this.lblEstado.Text = "Estado: ---";
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.Enabled = false;
            this.btnCheckIn.Location = new System.Drawing.Point(12, 292);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(90, 28);
            this.btnCheckIn.TabIndex = 10;
            this.btnCheckIn.Text = "Check In";
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Enabled = false;
            this.btnCheckOut.Location = new System.Drawing.Point(108, 292);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(90, 28);
            this.btnCheckOut.TabIndex = 11;
            this.btnCheckOut.Text = "Check Out";
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // btnReservar
            // 
            this.btnReservar.Enabled = false;
            this.btnReservar.Location = new System.Drawing.Point(204, 292);
            this.btnReservar.Name = "btnReservar";
            this.btnReservar.Size = new System.Drawing.Size(90, 28);
            this.btnReservar.TabIndex = 12;
            this.btnReservar.Text = "Reservar";
            this.btnReservar.Click += new System.EventHandler(this.btnReservar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Enabled = false;
            this.btnLimpiar.Location = new System.Drawing.Point(300, 292);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(90, 28);
            this.btnLimpiar.TabIndex = 13;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(12, 334);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(390, 36);
            this.btnGuardar.TabIndex = 14;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // FrmHabitacionGestiion
            // 
            this.ClientSize = new System.Drawing.Size(414, 409);
            this.Controls.Add(this.lblTituloTipo);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.lblIcono);
            this.Controls.Add(this.lblTarifa);
            this.Controls.Add(this.lblTituloLista);
            this.Controls.Add(this.lstHabitaciones);
            this.Controls.Add(this.lblTituloBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.btnCheckIn);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.btnReservar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnGuardar);
            this.Name = "FrmHabitacionGestiion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Habitaciones - Hotel";
            this.Load += new System.EventHandler(this.FrmHabitacionGestiion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // Declaracion de controles
        private System.Windows.Forms.Label lblTituloTipo;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.Label lblIcono;
        private System.Windows.Forms.Label lblTarifa;
        private System.Windows.Forms.Label lblTituloLista;
        private System.Windows.Forms.ListBox lstHabitaciones;
        private System.Windows.Forms.Label lblTituloBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Button btnReservar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnGuardar;
    }
}