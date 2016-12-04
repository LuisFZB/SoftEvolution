namespace SOFTEVOLUTION
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
            this.dataProveedores = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rtxtObservaciones = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.txtContacto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtLada = new System.Windows.Forms.TextBox();
            this.txtEmpresa = new System.Windows.Forms.TextBox();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtPuesto = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataProveedores)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataProveedores
            // 
            this.dataProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataProveedores.Location = new System.Drawing.Point(12, 418);
            this.dataProveedores.Name = "dataProveedores";
            this.dataProveedores.Size = new System.Drawing.Size(1330, 245);
            this.dataProveedores.TabIndex = 52;
            this.dataProveedores.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rtxtObservaciones);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtCodigo);
            this.groupBox3.Controls.Add(this.lblObservaciones);
            this.groupBox3.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(140, 115);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(948, 297);
            this.groupBox3.TabIndex = 51;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos Proveedor:";
            // 
            // rtxtObservaciones
            // 
            this.rtxtObservaciones.Location = new System.Drawing.Point(609, 83);
            this.rtxtObservaciones.Name = "rtxtObservaciones";
            this.rtxtObservaciones.Size = new System.Drawing.Size(309, 211);
            this.rtxtObservaciones.TabIndex = 9;
            this.rtxtObservaciones.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtApellidos);
            this.groupBox4.Controls.Add(this.txtContacto);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(0, 199);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(603, 98);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Contacto:";
            // 
            // txtApellidos
            // 
            this.txtApellidos.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellidos.Location = new System.Drawing.Point(176, 61);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(404, 25);
            this.txtApellidos.TabIndex = 8;
            // 
            // txtContacto
            // 
            this.txtContacto.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContacto.Location = new System.Drawing.Point(176, 30);
            this.txtContacto.Name = "txtContacto";
            this.txtContacto.Size = new System.Drawing.Size(259, 25);
            this.txtContacto.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 19);
            this.label1.TabIndex = 18;
            this.label1.Text = "Nombre(s):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(71, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 19);
            this.label2.TabIndex = 19;
            this.label2.Text = "Apellidos:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.txtTelefono);
            this.groupBox1.Controls.Add(this.txtLada);
            this.groupBox1.Controls.Add(this.txtEmpresa);
            this.groupBox1.Controls.Add(this.lblEmpresa);
            this.groupBox1.Controls.Add(this.lblTelefono);
            this.groupBox1.Controls.Add(this.lblEmail);
            this.groupBox1.Location = new System.Drawing.Point(0, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(507, 135);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Empresa:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(250, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 19);
            this.label3.TabIndex = 31;
            this.label3.Text = "-";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(149, 92);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(320, 25);
            this.txtEmail.TabIndex = 5;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.Location = new System.Drawing.Point(274, 61);
            this.txtTelefono.MaxLength = 7;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(195, 25);
            this.txtTelefono.TabIndex = 4;
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            // 
            // txtLada
            // 
            this.txtLada.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLada.Location = new System.Drawing.Point(174, 61);
            this.txtLada.MaxLength = 3;
            this.txtLada.Name = "txtLada";
            this.txtLada.Size = new System.Drawing.Size(70, 25);
            this.txtLada.TabIndex = 3;
            this.txtLada.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLada_KeyPress);
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmpresa.Location = new System.Drawing.Point(149, 30);
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.Size = new System.Drawing.Size(320, 25);
            this.txtEmpresa.TabIndex = 2;
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpresa.Location = new System.Drawing.Point(71, 32);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(72, 19);
            this.lblEmpresa.TabIndex = 18;
            this.lblEmpresa.Text = "Nombre:";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefono.Location = new System.Drawing.Point(71, 63);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(90, 19);
            this.lblTelefono.TabIndex = 19;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(71, 94);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(63, 19);
            this.lblEmail.TabIndex = 20;
            this.lblEmail.Text = "Email:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(17, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 18);
            this.label10.TabIndex = 25;
            this.label10.Text = "Codigo:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(112, 31);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(221, 25);
            this.txtCodigo.TabIndex = 0;
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObservaciones.Location = new System.Drawing.Point(605, 62);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(135, 19);
            this.lblObservaciones.TabIndex = 23;
            this.lblObservaciones.Text = "Observaciones:";
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
            this.groupBox2.TabIndex = 50;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Capturista:";
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
            // frmProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.dataProveedores);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmProveedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmProveedores";
            this.Load += new System.EventHandler(this.frmProveedores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataProveedores)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataProveedores;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtPuesto;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.RichTextBox rtxtObservaciones;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.TextBox txtContacto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtLada;
        private System.Windows.Forms.TextBox txtEmpresa;
    }
}