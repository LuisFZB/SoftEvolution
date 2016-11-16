namespace SoftEvolution
{
    partial class frmProveedores
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsAgregar = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsModificar = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.dgvProveedores = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tlsMostrar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(760, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsAgregar,
            this.tlsModificar,
            this.tlsEliminar,
            this.tlsSalir,
            this.tlsMostrar});
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // tlsAgregar
            // 
            this.tlsAgregar.Name = "tlsAgregar";
            this.tlsAgregar.Size = new System.Drawing.Size(152, 22);
            this.tlsAgregar.Text = "Agregar";
            this.tlsAgregar.Click += new System.EventHandler(this.tlsAgregar_Click);
            // 
            // tlsModificar
            // 
            this.tlsModificar.Name = "tlsModificar";
            this.tlsModificar.Size = new System.Drawing.Size(152, 22);
            this.tlsModificar.Text = "Modificar";
            this.tlsModificar.Click += new System.EventHandler(this.tlsModificar_Click);
            // 
            // tlsEliminar
            // 
            this.tlsEliminar.Name = "tlsEliminar";
            this.tlsEliminar.Size = new System.Drawing.Size(152, 22);
            this.tlsEliminar.Text = "Eliminar";
            this.tlsEliminar.Click += new System.EventHandler(this.tlsEliminar_Click);
            // 
            // tlsSalir
            // 
            this.tlsSalir.Name = "tlsSalir";
            this.tlsSalir.Size = new System.Drawing.Size(152, 22);
            this.tlsSalir.Text = "Salir";
            this.tlsSalir.Click += new System.EventHandler(this.tlsSalir_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(123, 4);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(100, 20);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            this.txtBuscar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyUp);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(82, 7);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(40, 13);
            this.lblBuscar.TabIndex = 2;
            this.lblBuscar.Text = "Buscar";
            // 
            // dgvProveedores
            // 
            this.dgvProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProveedores.Location = new System.Drawing.Point(21, 44);
            this.dgvProveedores.Name = "dgvProveedores";
            this.dgvProveedores.Size = new System.Drawing.Size(713, 327);
            this.dgvProveedores.TabIndex = 3;
            this.dgvProveedores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProveedores_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(663, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 4;
            // 
            // tlsMostrar
            // 
            this.tlsMostrar.Name = "tlsMostrar";
            this.tlsMostrar.Size = new System.Drawing.Size(152, 22);
            this.tlsMostrar.Text = "Mostrar todos";
            this.tlsMostrar.Click += new System.EventHandler(this.tlsMostrar_Click);
            // 
            // frmProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 397);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvProveedores);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmProveedores";
            this.Text = "frmProveedores";
            this.Load += new System.EventHandler(this.frmProveedores_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tlsAgregar;
        private System.Windows.Forms.ToolStripMenuItem tlsModificar;
        private System.Windows.Forms.ToolStripMenuItem tlsEliminar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.DataGridView dgvProveedores;
        private System.Windows.Forms.ToolStripMenuItem tlsSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem tlsMostrar;
    }
}