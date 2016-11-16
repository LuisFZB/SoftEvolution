namespace SoftEvolution
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.funcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verDatosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.comboTipo = new System.Windows.Forms.ComboBox();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // funcionesToolStripMenuItem
            // 
            this.funcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarToolStripMenuItem,
            this.modificarToolStripMenuItem,
            this.buscarToolStripMenuItem,
            this.eliminarToolStripMenuItem,
            this.verDatosToolStripMenuItem});
            this.funcionesToolStripMenuItem.Name = "funcionesToolStripMenuItem";
            this.funcionesToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.funcionesToolStripMenuItem.Text = "Funciones";
            this.funcionesToolStripMenuItem.Click += new System.EventHandler(this.funcionesToolStripMenuItem_Click);
            // 
            // agregarToolStripMenuItem
            // 
            this.agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            this.agregarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.agregarToolStripMenuItem.Text = "Agregar";
            this.agregarToolStripMenuItem.Click += new System.EventHandler(this.agregarToolStripMenuItem_Click);
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guardarToolStripMenuItem,
            this.cancelarToolStripMenuItem});
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.modificarToolStripMenuItem.Text = "Modificar";
            this.modificarToolStripMenuItem.Click += new System.EventHandler(this.modificarToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // cancelarToolStripMenuItem
            // 
            this.cancelarToolStripMenuItem.Name = "cancelarToolStripMenuItem";
            this.cancelarToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.cancelarToolStripMenuItem.Text = "Cancelar";
            this.cancelarToolStripMenuItem.Click += new System.EventHandler(this.cancelarToolStripMenuItem_Click);
            // 
            // buscarToolStripMenuItem
            // 
            this.buscarToolStripMenuItem.Name = "buscarToolStripMenuItem";
            this.buscarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.buscarToolStripMenuItem.Text = "Buscar";
            this.buscarToolStripMenuItem.Click += new System.EventHandler(this.buscarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // verDatosToolStripMenuItem
            // 
            this.verDatosToolStripMenuItem.Name = "verDatosToolStripMenuItem";
            this.verDatosToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.verDatosToolStripMenuItem.Text = "Ver Datos";
            this.verDatosToolStripMenuItem.Click += new System.EventHandler(this.verDatosToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.funcionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(612, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // comboTipo
            // 
            this.comboTipo.Items.AddRange(new object[] {
            "Privilegiado",
            "Invitado"});
            this.comboTipo.Location = new System.Drawing.Point(293, 106);
            this.comboTipo.Name = "comboTipo";
            this.comboTipo.Size = new System.Drawing.Size(121, 21);
            this.comboTipo.TabIndex = 3;
            this.comboTipo.Text = "Selecciona:";
            this.comboTipo.SelectedIndexChanged += new System.EventHandler(this.comboTipo_SelectedIndexChanged);
            this.comboTipo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboTipo_KeyPress);
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(293, 152);
            this.txtClave.MaxLength = 15;
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(100, 20);
            this.txtClave.TabIndex = 4;
            this.txtClave.TextChanged += new System.EventHandler(this.txtClave_TextChanged);
            // 
            // txtContrasena
            // 
            this.txtContrasena.Location = new System.Drawing.Point(293, 189);
            this.txtContrasena.MaxLength = 25;
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.PasswordChar = '*';
            this.txtContrasena.Size = new System.Drawing.Size(100, 20);
            this.txtContrasena.TabIndex = 5;
            this.txtContrasena.TextChanged += new System.EventHandler(this.txtContrasena_TextChanged);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(293, 226);
            this.txtNombre.MaxLength = 25;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 6;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // txtApellidos
            // 
            this.txtApellidos.Location = new System.Drawing.Point(293, 265);
            this.txtApellidos.MaxLength = 25;
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(100, 20);
            this.txtApellidos.TabIndex = 7;
            this.txtApellidos.TextChanged += new System.EventHandler(this.txtApellidos_TextChanged);
            this.txtApellidos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellidos_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(209, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Tipo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Clave";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(209, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Contaseña";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(209, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Nombre";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(209, 268);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Apellidos";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 470);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtApellidos);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtContrasena);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.comboTipo);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem funcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verDatosToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.TextBox txtClave;
        public System.Windows.Forms.TextBox txtContrasena;
        public System.Windows.Forms.TextBox txtNombre;
        public System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox comboTipo;
    }
}

