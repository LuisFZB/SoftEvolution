﻿namespace SoftEvolution
{
    partial class frmOrdenes
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.buscarOrdenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvOrden = new System.Windows.Forms.DataGridView();
            this.txtBus = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrden)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buscarOrdenToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(479, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // buscarOrdenToolStripMenuItem
            // 
            this.buscarOrdenToolStripMenuItem.Name = "buscarOrdenToolStripMenuItem";
            this.buscarOrdenToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.buscarOrdenToolStripMenuItem.Text = "Buscar Orden:";
            // 
            // dgvOrden
            // 
            this.dgvOrden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrden.Location = new System.Drawing.Point(12, 61);
            this.dgvOrden.Name = "dgvOrden";
            this.dgvOrden.Size = new System.Drawing.Size(452, 196);
            this.dgvOrden.TabIndex = 1;
            // 
            // txtBus
            // 
            this.txtBus.Location = new System.Drawing.Point(96, 4);
            this.txtBus.Name = "txtBus";
            this.txtBus.Size = new System.Drawing.Size(100, 20);
            this.txtBus.TabIndex = 2;
            this.txtBus.TextChanged += new System.EventHandler(this.txtBus_TextChanged);
            this.txtBus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBus_KeyPress);
            this.txtBus.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBus_KeyUp);
            // 
            // frmOrdenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 287);
            this.Controls.Add(this.txtBus);
            this.Controls.Add(this.dgvOrden);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmOrdenes";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrden)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem buscarOrdenToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvOrden;
        private System.Windows.Forms.TextBox txtBus;
    }
}
