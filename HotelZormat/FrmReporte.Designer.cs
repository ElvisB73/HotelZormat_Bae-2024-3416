namespace HotelZormat
{
    partial class FrmReporte
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
            this.btnCalcularIngresos = new Guna.UI2.WinForms.Guna2Button();
            this.dtpDesde = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpHasta = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lstOcupacion = new System.Windows.Forms.ListView();
            this.lblIngresoTotal = new System.Windows.Forms.Label();
            this.lblDesde = new System.Windows.Forms.Label();
            this.lblHasta = new System.Windows.Forms.Label();
            this.lblIngresosPorDias = new System.Windows.Forms.Label();
            this.btnAtualizarOcupacion = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(220)))));
            this.lblTitulo.Location = new System.Drawing.Point(25, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(170, 21);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Text = "Ocupacion del Dia";
            //
            // lstOcupacion
            //
            this.lstOcupacion.BackColor = System.Drawing.Color.White;
            this.lstOcupacion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstOcupacion.FullRowSelect = true;
            this.lstOcupacion.GridLines = true;
            this.lstOcupacion.HideSelection = false;
            this.lstOcupacion.Location = new System.Drawing.Point(28, 34);
            this.lstOcupacion.Name = "lstOcupacion";
            this.lstOcupacion.Size = new System.Drawing.Size(715, 129);
            this.lstOcupacion.TabIndex = 4;
            this.lstOcupacion.UseCompatibleStateImageBehavior = false;
            //
            // btnAtualizarOcupacion
            //
            this.btnAtualizarOcupacion.BorderRadius = 10;
            this.btnAtualizarOcupacion.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAtualizarOcupacion.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAtualizarOcupacion.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAtualizarOcupacion.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAtualizarOcupacion.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(220)))));
            this.btnAtualizarOcupacion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAtualizarOcupacion.ForeColor = System.Drawing.Color.White;
            this.btnAtualizarOcupacion.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.btnAtualizarOcupacion.Location = new System.Drawing.Point(30, 180);
            this.btnAtualizarOcupacion.Name = "btnAtualizarOcupacion";
            this.btnAtualizarOcupacion.Size = new System.Drawing.Size(180, 45);
            this.btnAtualizarOcupacion.TabIndex = 9;
            this.btnAtualizarOcupacion.Text = "Actualizar";
            this.btnAtualizarOcupacion.Click += new System.EventHandler(this.btnActualizarOcupacion_Click);
            //
            // lblIngresosPorDias
            //
            this.lblIngresosPorDias.AutoSize = true;
            this.lblIngresosPorDias.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngresosPorDias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(220)))));
            this.lblIngresosPorDias.Location = new System.Drawing.Point(26, 246);
            this.lblIngresosPorDias.Name = "lblIngresosPorDias";
            this.lblIngresosPorDias.Size = new System.Drawing.Size(262, 21);
            this.lblIngresosPorDias.TabIndex = 8;
            this.lblIngresosPorDias.Text = "Ingresos Por rango De Fecha";
            //
            // lblDesde
            //
            this.lblDesde.AutoSize = true;
            this.lblDesde.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDesde.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(122)))), ((int)(((byte)(137)))));
            this.lblDesde.Location = new System.Drawing.Point(27, 285);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(41, 13);
            this.lblDesde.TabIndex = 6;
            this.lblDesde.Text = "Desde:";
            //
            // lblHasta
            //
            this.lblHasta.AutoSize = true;
            this.lblHasta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHasta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(122)))), ((int)(((byte)(137)))));
            this.lblHasta.Location = new System.Drawing.Point(270, 285);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(38, 13);
            this.lblHasta.TabIndex = 7;
            this.lblHasta.Text = "Hasta:";
            //
            // dtpDesde
            //
            this.dtpDesde.BorderRadius = 10;
            this.dtpDesde.Checked = true;
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpDesde.Location = new System.Drawing.Point(29, 301);
            this.dtpDesde.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDesde.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(200, 36);
            this.dtpDesde.TabIndex = 1;
            this.dtpDesde.Value = new System.DateTime(2026, 7, 31, 16, 24, 18, 810);
            //
            // dtpHasta
            //
            this.dtpHasta.BorderRadius = 10;
            this.dtpHasta.Checked = true;
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpHasta.Location = new System.Drawing.Point(273, 301);
            this.dtpHasta.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpHasta.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(200, 36);
            this.dtpHasta.TabIndex = 2;
            this.dtpHasta.Value = new System.DateTime(2026, 7, 31, 16, 24, 18, 810);
            //
            // btnCalcularIngresos
            //
            this.btnCalcularIngresos.BorderRadius = 10;
            this.btnCalcularIngresos.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCalcularIngresos.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCalcularIngresos.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCalcularIngresos.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCalcularIngresos.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(220)))));
            this.btnCalcularIngresos.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCalcularIngresos.ForeColor = System.Drawing.Color.White;
            this.btnCalcularIngresos.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.btnCalcularIngresos.Location = new System.Drawing.Point(511, 301);
            this.btnCalcularIngresos.Name = "btnCalcularIngresos";
            this.btnCalcularIngresos.Size = new System.Drawing.Size(180, 36);
            this.btnCalcularIngresos.TabIndex = 0;
            this.btnCalcularIngresos.Text = "Calcular";
            this.btnCalcularIngresos.Click += new System.EventHandler(this.btnCalcularIngresos_Click);
            //
            // lblIngresoTotal
            //
            this.lblIngresoTotal.AutoSize = true;
            this.lblIngresoTotal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngresoTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(220)))));
            this.lblIngresoTotal.Location = new System.Drawing.Point(44, 372);
            this.lblIngresoTotal.Name = "lblIngresoTotal";
            this.lblIngresoTotal.Size = new System.Drawing.Size(180, 29);
            this.lblIngresoTotal.TabIndex = 5;
            this.lblIngresoTotal.Text = "Ingreso Total:";
            //
            // FrmReporte
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAtualizarOcupacion);
            this.Controls.Add(this.lblIngresosPorDias);
            this.Controls.Add(this.lblHasta);
            this.Controls.Add(this.lblDesde);
            this.Controls.Add(this.lblIngresoTotal);
            this.Controls.Add(this.lstOcupacion);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.btnCalcularIngresos);
            this.Name = "FrmReporte";
            this.Text = "FrmReporte";
            this.Load += new System.EventHandler(this.FrmReporte_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnCalcularIngresos;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDesde;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ListView lstOcupacion;
        private System.Windows.Forms.Label lblIngresoTotal;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.Label lblIngresosPorDias;
        private Guna.UI2.WinForms.Guna2Button btnAtualizarOcupacion;
    }
}