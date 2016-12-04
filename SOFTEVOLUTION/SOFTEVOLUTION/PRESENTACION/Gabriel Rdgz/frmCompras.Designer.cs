namespace SOFTEVOLUTION
{
    partial class frmCompras
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblFolio = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtPuesto = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblArticulos = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lstProductos = new System.Windows.Forms.ListView();
            this.lstCodigo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstProducto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstCantidad = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstPrecioUnitario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstSubtotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox2.Location = new System.Drawing.Point(9, 90);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(122, 574);
            this.pictureBox2.TabIndex = 51;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.Location = new System.Drawing.Point(1098, 90);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 574);
            this.pictureBox1.TabIndex = 50;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblFecha);
            this.groupBox5.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(1098, 11);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(256, 73);
            this.groupBox5.TabIndex = 49;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Fecha:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(29, 36);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(200, 22);
            this.lblFecha.TabIndex = 29;
            this.lblFecha.Text = "2000/01/01 00:00:00";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblFolio);
            this.groupBox4.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(9, 11);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(122, 73);
            this.groupBox4.TabIndex = 48;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Folio:";
            // 
            // lblFolio
            // 
            this.lblFolio.AutoSize = true;
            this.lblFolio.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolio.Location = new System.Drawing.Point(16, 36);
            this.lblFolio.Name = "lblFolio";
            this.lblFolio.Size = new System.Drawing.Size(90, 22);
            this.lblFolio.TabIndex = 27;
            this.lblFolio.Text = "00000000";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtCodigo);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtCantidad);
            this.groupBox3.Location = new System.Drawing.Point(140, 134);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(948, 93);
            this.groupBox3.TabIndex = 47;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos Articulo:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(16, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 18);
            this.label9.TabIndex = 6;
            this.label9.Text = "Codigo:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(86, 40);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(221, 25);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            this.txtCodigo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyUp);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(423, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 18);
            this.label10.TabIndex = 8;
            this.label10.Text = "Cantidad:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(509, 40);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.ReadOnly = true;
            this.txtCantidad.Size = new System.Drawing.Size(120, 25);
            this.txtCantidad.TabIndex = 100;
            this.txtCantidad.TabStop = false;
            this.txtCantidad.Text = "1";
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.txtApellido);
            this.groupBox2.Controls.Add(this.txtPuesto);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.txtNombre);
            this.groupBox2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(140, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(948, 96);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos vendedor:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(27, 32);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 18);
            this.label17.TabIndex = 16;
            this.label17.Text = "Puesto:";
            // 
            // txtApellido
            // 
            this.txtApellido.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellido.Location = new System.Drawing.Point(449, 53);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.ReadOnly = true;
            this.txtApellido.Size = new System.Drawing.Size(367, 25);
            this.txtApellido.TabIndex = 100;
            this.txtApellido.TabStop = false;
            // 
            // txtPuesto
            // 
            this.txtPuesto.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPuesto.Location = new System.Drawing.Point(30, 53);
            this.txtPuesto.Name = "txtPuesto";
            this.txtPuesto.ReadOnly = true;
            this.txtPuesto.Size = new System.Drawing.Size(131, 25);
            this.txtPuesto.TabIndex = 100;
            this.txtPuesto.TabStop = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(446, 32);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(88, 18);
            this.label19.TabIndex = 20;
            this.label19.Text = "Apellidos:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(196, 32);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(88, 18);
            this.label18.TabIndex = 18;
            this.label18.Text = "Nombre(s):";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(199, 53);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(230, 25);
            this.txtNombre.TabIndex = 100;
            this.txtNombre.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTotal);
            this.groupBox1.Controls.Add(this.lblArticulos);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(140, 565);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(948, 99);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(812, 60);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(60, 22);
            this.lblTotal.TabIndex = 8;
            this.lblTotal.Text = "$0.00";
            // 
            // lblArticulos
            // 
            this.lblArticulos.AutoSize = true;
            this.lblArticulos.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArticulos.Location = new System.Drawing.Point(812, 21);
            this.lblArticulos.Name = "lblArticulos";
            this.lblArticulos.Size = new System.Drawing.Size(20, 22);
            this.lblArticulos.TabIndex = 5;
            this.lblArticulos.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(589, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "CANTIDAD DE ARTICULOS:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(589, 62);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "TOTAL:";
            // 
            // lstProductos
            // 
            this.lstProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstProductos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lstCodigo,
            this.lstProducto,
            this.lstCantidad,
            this.lstPrecioUnitario,
            this.lstSubtotal});
            this.lstProductos.GridLines = true;
            this.lstProductos.Location = new System.Drawing.Point(140, 234);
            this.lstProductos.Margin = new System.Windows.Forms.Padding(4);
            this.lstProductos.Name = "lstProductos";
            this.lstProductos.Size = new System.Drawing.Size(948, 323);
            this.lstProductos.TabIndex = 44;
            this.lstProductos.TabStop = false;
            this.lstProductos.UseCompatibleStateImageBehavior = false;
            this.lstProductos.View = System.Windows.Forms.View.Details;
            // 
            // lstCodigo
            // 
            this.lstCodigo.Text = "Codigo";
            this.lstCodigo.Width = 162;
            // 
            // lstProducto
            // 
            this.lstProducto.Text = "Producto";
            this.lstProducto.Width = 445;
            // 
            // lstCantidad
            // 
            this.lstCantidad.Text = "Cantidad";
            this.lstCantidad.Width = 107;
            // 
            // lstPrecioUnitario
            // 
            this.lstPrecioUnitario.Text = "P_Unitario";
            this.lstPrecioUnitario.Width = 117;
            // 
            // lstSubtotal
            // 
            this.lstSubtotal.Text = "Total";
            this.lstSubtotal.Width = 117;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1362, 675);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lstProductos);
            this.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCompras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCompras";
            this.Load += new System.EventHandler(this.frmCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblFolio;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtPuesto;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblArticulos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lstProductos;
        private System.Windows.Forms.ColumnHeader lstCodigo;
        private System.Windows.Forms.ColumnHeader lstProducto;
        private System.Windows.Forms.ColumnHeader lstCantidad;
        private System.Windows.Forms.ColumnHeader lstPrecioUnitario;
        private System.Windows.Forms.ColumnHeader lstSubtotal;
        private System.Windows.Forms.Timer timer1;
    }
}