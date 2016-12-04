namespace SOFTEVOLUTION.PRESENTACION.Eduardo_Gmz
{
    partial class frmRemoverVentas
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdbParcial = new System.Windows.Forms.RadioButton();
            this.rdbTotal = new System.Windows.Forms.RadioButton();
            this.gpbProducto = new System.Windows.Forms.GroupBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.gpbCantidadBorrar = new System.Windows.Forms.GroupBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.gpbProducto.SuspendLayout();
            this.gpbCantidadBorrar.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdbParcial);
            this.groupBox3.Controls.Add(this.rdbTotal);
            this.groupBox3.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(8, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(335, 100);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tipo de Borrado:";
            // 
            // rdbParcial
            // 
            this.rdbParcial.AutoSize = true;
            this.rdbParcial.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbParcial.Location = new System.Drawing.Point(177, 46);
            this.rdbParcial.Name = "rdbParcial";
            this.rdbParcial.Size = new System.Drawing.Size(98, 26);
            this.rdbParcial.TabIndex = 1;
            this.rdbParcial.TabStop = true;
            this.rdbParcial.Text = "Parcial";
            this.rdbParcial.UseVisualStyleBackColor = true;
            this.rdbParcial.Click += new System.EventHandler(this.rdbParcial_Click);
            // 
            // rdbTotal
            // 
            this.rdbTotal.AutoSize = true;
            this.rdbTotal.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbTotal.Location = new System.Drawing.Point(55, 46);
            this.rdbTotal.Name = "rdbTotal";
            this.rdbTotal.Size = new System.Drawing.Size(78, 26);
            this.rdbTotal.TabIndex = 0;
            this.rdbTotal.TabStop = true;
            this.rdbTotal.Text = "Total";
            this.rdbTotal.UseVisualStyleBackColor = true;
            this.rdbTotal.Click += new System.EventHandler(this.rdbTotal_Click);
            // 
            // gpbProducto
            // 
            this.gpbProducto.Controls.Add(this.txtCodigo);
            this.gpbProducto.Controls.Add(this.gpbCantidadBorrar);
            this.gpbProducto.Controls.Add(this.lblCodigo);
            this.gpbProducto.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbProducto.Location = new System.Drawing.Point(8, 112);
            this.gpbProducto.Margin = new System.Windows.Forms.Padding(4);
            this.gpbProducto.Name = "gpbProducto";
            this.gpbProducto.Padding = new System.Windows.Forms.Padding(4);
            this.gpbProducto.Size = new System.Drawing.Size(335, 318);
            this.gpbProducto.TabIndex = 6;
            this.gpbProducto.TabStop = false;
            this.gpbProducto.Text = "Producto:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(126, 68);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(171, 32);
            this.txtCodigo.TabIndex = 2;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            this.txtCodigo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyUp);
            // 
            // gpbCantidadBorrar
            // 
            this.gpbCantidadBorrar.Controls.Add(this.txtCantidad);
            this.gpbCantidadBorrar.Location = new System.Drawing.Point(39, 140);
            this.gpbCantidadBorrar.Margin = new System.Windows.Forms.Padding(4);
            this.gpbCantidadBorrar.Name = "gpbCantidadBorrar";
            this.gpbCantidadBorrar.Padding = new System.Windows.Forms.Padding(4);
            this.gpbCantidadBorrar.Size = new System.Drawing.Size(258, 148);
            this.gpbCantidadBorrar.TabIndex = 3;
            this.gpbCantidadBorrar.TabStop = false;
            this.gpbCantidadBorrar.Text = "Cantidad Borrar";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(68, 63);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(4);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCantidad.Size = new System.Drawing.Size(132, 36);
            this.txtCantidad.TabIndex = 3;
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            this.txtCantidad.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCantidad_KeyUp);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(39, 71);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(94, 24);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Codigo:";
            this.lblCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmRemoverVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(352, 437);
            this.Controls.Add(this.gpbProducto);
            this.Controls.Add(this.groupBox3);
            this.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmRemoverVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAgregarVentas";
            this.Load += new System.EventHandler(this.frmRemoverVentas_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gpbProducto.ResumeLayout(false);
            this.gpbProducto.PerformLayout();
            this.gpbCantidadBorrar.ResumeLayout(false);
            this.gpbCantidadBorrar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdbParcial;
        private System.Windows.Forms.RadioButton rdbTotal;
        private System.Windows.Forms.GroupBox gpbProducto;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.GroupBox gpbCantidadBorrar;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblCodigo;
    }
}