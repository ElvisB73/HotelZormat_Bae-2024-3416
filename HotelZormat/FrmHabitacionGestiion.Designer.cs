namespace HotelZormat
{
    partial class FrmHabitacionGestiion
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
            this.txtNumero = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboTipo = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtPiso = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtCapacidad = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtTarifa = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboEstado = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnNuevo = new Guna.UI2.WinForms.Guna2Button();
            this.btnGuardar = new Guna.UI2.WinForms.Guna2Button();
            this.btnEliminar = new Guna.UI2.WinForms.Guna2Button();
            this.cboFiltroPiso = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cboFiltroEstado = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnFiltrar = new Guna.UI2.WinForms.Guna2Button();
            this.lstHabitaciones = new System.Windows.Forms.ListView();
            this.No = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tipo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Piso = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Estado = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblNumero = new System.Windows.Forms.Label();
            this.lblTip = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblPiso = new System.Windows.Forms.Label();
            this.lblTarifa = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblCapacidad = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNumero
            // 
            this.txtNumero.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNumero.DefaultText = "";
            this.txtNumero.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNumero.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNumero.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNumero.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNumero.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNumero.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNumero.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNumero.Location = new System.Drawing.Point(11, 86);
            this.txtNumero.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.PlaceholderText = "Numero";
            this.txtNumero.SelectedText = "";
            this.txtNumero.Size = new System.Drawing.Size(293, 36);
            this.txtNumero.TabIndex = 0;
            // 
            // cboTipo
            // 
            this.cboTipo.BackColor = System.Drawing.Color.Transparent;
            this.cboTipo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTipo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTipo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboTipo.ItemHeight = 30;
            this.cboTipo.Items.AddRange(new object[] {
            "Sencilla,Doble,Suite"});
            this.cboTipo.Location = new System.Drawing.Point(11, 157);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(294, 36);
            this.cboTipo.TabIndex = 1;
            // 
            // txtPiso
            // 
            this.txtPiso.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPiso.DefaultText = "";
            this.txtPiso.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPiso.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPiso.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPiso.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPiso.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPiso.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPiso.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPiso.Location = new System.Drawing.Point(9, 209);
            this.txtPiso.Name = "txtPiso";
            this.txtPiso.PlaceholderText = "";
            this.txtPiso.SelectedText = "";
            this.txtPiso.Size = new System.Drawing.Size(131, 23);
            this.txtPiso.TabIndex = 2;
            // 
            // txtCapacidad
            // 
            this.txtCapacidad.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCapacidad.DefaultText = "";
            this.txtCapacidad.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCapacidad.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCapacidad.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCapacidad.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCapacidad.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCapacidad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCapacidad.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCapacidad.Location = new System.Drawing.Point(156, 209);
            this.txtCapacidad.Name = "txtCapacidad";
            this.txtCapacidad.PlaceholderText = "";
            this.txtCapacidad.SelectedText = "";
            this.txtCapacidad.Size = new System.Drawing.Size(156, 23);
            this.txtCapacidad.TabIndex = 3;
            // 
            // txtTarifa
            // 
            this.txtTarifa.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTarifa.DefaultText = "";
            this.txtTarifa.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTarifa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTarifa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTarifa.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTarifa.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTarifa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTarifa.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTarifa.Location = new System.Drawing.Point(11, 259);
            this.txtTarifa.Name = "txtTarifa";
            this.txtTarifa.PlaceholderText = "";
            this.txtTarifa.SelectedText = "";
            this.txtTarifa.Size = new System.Drawing.Size(301, 31);
            this.txtTarifa.TabIndex = 4;
            // 
            // cboEstado
            // 
            this.cboEstado.BackColor = System.Drawing.Color.Transparent;
            this.cboEstado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboEstado.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboEstado.ItemHeight = 30;
            this.cboEstado.Items.AddRange(new object[] {
            "Disponible, Ocupada, Reservada, Limpieza"});
            this.cboEstado.Location = new System.Drawing.Point(13, 324);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(300, 36);
            this.cboEstado.TabIndex = 5;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BorderRadius = 10;
            this.btnNuevo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNuevo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNuevo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNuevo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(28, 394);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(120, 29);
            this.btnNuevo.TabIndex = 6;
            this.btnNuevo.Text = "Nueva";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BorderRadius = 10;
            this.btnGuardar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGuardar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGuardar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGuardar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(166, 394);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(120, 29);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.White;
            this.btnEliminar.BorderRadius = 10;
            this.btnEliminar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEliminar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEliminar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEliminar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEliminar.FillColor = System.Drawing.Color.Red;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(315, 394);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(120, 29);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // cboFiltroPiso
            // 
            this.cboFiltroPiso.BackColor = System.Drawing.Color.Transparent;
            this.cboFiltroPiso.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboFiltroPiso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiltroPiso.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboFiltroPiso.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboFiltroPiso.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboFiltroPiso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboFiltroPiso.ItemHeight = 30;
            this.cboFiltroPiso.Items.AddRange(new object[] {
            "Sencilla,Doble,Suite"});
            this.cboFiltroPiso.Location = new System.Drawing.Point(333, 9);
            this.cboFiltroPiso.Name = "cboFiltroPiso";
            this.cboFiltroPiso.Size = new System.Drawing.Size(153, 36);
            this.cboFiltroPiso.TabIndex = 9;
            // 
            // cboFiltroEstado
            // 
            this.cboFiltroEstado.BackColor = System.Drawing.Color.Transparent;
            this.cboFiltroEstado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiltroEstado.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboFiltroEstado.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboFiltroEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboFiltroEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboFiltroEstado.ItemHeight = 30;
            this.cboFiltroEstado.Items.AddRange(new object[] {
            "Sencilla,Doble,Suite"});
            this.cboFiltroEstado.Location = new System.Drawing.Point(489, 8);
            this.cboFiltroEstado.Name = "cboFiltroEstado";
            this.cboFiltroEstado.Size = new System.Drawing.Size(166, 36);
            this.cboFiltroEstado.TabIndex = 10;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.White;
            this.btnFiltrar.BorderRadius = 10;
            this.btnFiltrar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFiltrar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFiltrar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFiltrar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFiltrar.FillColor = System.Drawing.Color.Lime;
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.Location = new System.Drawing.Point(659, 8);
            this.btnFiltrar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(120, 23);
            this.btnFiltrar.TabIndex = 11;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // lstHabitaciones
            // 
            this.lstHabitaciones.AllowDrop = true;
            this.lstHabitaciones.BackColor = System.Drawing.SystemColors.GrayText;
            this.lstHabitaciones.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.No,
            this.Tipo,
            this.Piso,
            this.Estado});
            this.lstHabitaciones.FullRowSelect = true;
            this.lstHabitaciones.GridLines = true;
            this.lstHabitaciones.HideSelection = false;
            this.lstHabitaciones.Location = new System.Drawing.Point(333, 38);
            this.lstHabitaciones.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstHabitaciones.Name = "lstHabitaciones";
            this.lstHabitaciones.Size = new System.Drawing.Size(447, 219);
            this.lstHabitaciones.TabIndex = 12;
            this.lstHabitaciones.UseCompatibleStateImageBehavior = false;
            this.lstHabitaciones.View = System.Windows.Forms.View.Details;
            this.lstHabitaciones.SelectedIndexChanged += new System.EventHandler(this.lstHabitaciones_SelectedIndexChanged);
            // 
            // No
            // 
            this.No.Text = "no.";
            // 
            // Tipo
            // 
            this.Tipo.Text = "Tipo";
            this.Tipo.Width = 120;
            // 
            // Piso
            // 
            this.Piso.Text = "Piso";
            // 
            // Estado
            // 
            this.Estado.Text = "Estado";
            this.Estado.Width = 120;
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(11, 68);
            this.lblNumero.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(44, 13);
            this.lblNumero.TabIndex = 13;
            this.lblNumero.Text = "Numero";
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Location = new System.Drawing.Point(64, 220);
            this.lblTip.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(0, 13);
            this.lblTip.TabIndex = 14;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(11, 140);
            this.lblTipo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(28, 13);
            this.lblTipo.TabIndex = 15;
            this.lblTipo.Text = "Tipo";
            // 
            // lblPiso
            // 
            this.lblPiso.AutoSize = true;
            this.lblPiso.Location = new System.Drawing.Point(8, 193);
            this.lblPiso.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPiso.Name = "lblPiso";
            this.lblPiso.Size = new System.Drawing.Size(27, 13);
            this.lblPiso.TabIndex = 16;
            this.lblPiso.Text = "Piso";
            // 
            // lblTarifa
            // 
            this.lblTarifa.AutoSize = true;
            this.lblTarifa.Location = new System.Drawing.Point(14, 242);
            this.lblTarifa.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTarifa.Name = "lblTarifa";
            this.lblTarifa.Size = new System.Drawing.Size(34, 13);
            this.lblTarifa.TabIndex = 17;
            this.lblTarifa.Text = "Tarifa";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(14, 308);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(40, 13);
            this.lblEstado.TabIndex = 18;
            this.lblEstado.Text = "Estado";
            // 
            // lblCapacidad
            // 
            this.lblCapacidad.AutoSize = true;
            this.lblCapacidad.Location = new System.Drawing.Point(153, 193);
            this.lblCapacidad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCapacidad.Name = "lblCapacidad";
            this.lblCapacidad.Size = new System.Drawing.Size(58, 13);
            this.lblCapacidad.TabIndex = 19;
            this.lblCapacidad.Text = "Capacidad";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(21, 6);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(191, 26);
            this.lblNombre.TabIndex = 20;
            this.lblNombre.Text = "Datos De Habitacion";
            // 
            // FrmHabitacionGestiion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblCapacidad);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblTarifa);
            this.Controls.Add(this.lblPiso);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblTip);
            this.Controls.Add(this.lblNumero);
            this.Controls.Add(this.lstHabitaciones);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.cboFiltroEstado);
            this.Controls.Add(this.cboFiltroPiso);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.cboEstado);
            this.Controls.Add(this.txtTarifa);
            this.Controls.Add(this.txtCapacidad);
            this.Controls.Add(this.txtPiso);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.txtNumero);
            this.Name = "FrmHabitacionGestiion";
            this.Text = "FrmHabitacionGestiion";
            this.Load += new System.EventHandler(this.FrmHabitacionGestiion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtNumero;
        private Guna.UI2.WinForms.Guna2ComboBox cboTipo;
        private Guna.UI2.WinForms.Guna2TextBox txtPiso;
        private Guna.UI2.WinForms.Guna2TextBox txtCapacidad;
        private Guna.UI2.WinForms.Guna2TextBox txtTarifa;
        private Guna.UI2.WinForms.Guna2ComboBox cboEstado;
        private Guna.UI2.WinForms.Guna2Button btnNuevo;
        private Guna.UI2.WinForms.Guna2Button btnGuardar;
        private Guna.UI2.WinForms.Guna2Button btnEliminar;
        private Guna.UI2.WinForms.Guna2ComboBox cboFiltroPiso;
        private Guna.UI2.WinForms.Guna2ComboBox cboFiltroEstado;
        private Guna.UI2.WinForms.Guna2Button btnFiltrar;
        private System.Windows.Forms.ListView lstHabitaciones;
        private System.Windows.Forms.ColumnHeader No;
        private System.Windows.Forms.ColumnHeader Tipo;
        private System.Windows.Forms.ColumnHeader Piso;
        private System.Windows.Forms.ColumnHeader Estado;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblPiso;
        private System.Windows.Forms.Label lblTarifa;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblCapacidad;
        private System.Windows.Forms.Label lblNombre;
    }
}