namespace SOFTEVOLUTION
{
    partial class frmUsuarios
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoVendedor = new System.Windows.Forms.RadioButton();
            this.rdoAdministrador = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtcontraseña = new System.Windows.Forms.TextBox();
            this.txtConfirmar = new System.Windows.Forms.TextBox();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoVendedor);
            this.groupBox1.Controls.Add(this.rdoAdministrador);
            this.groupBox1.Location = new System.Drawing.Point(9, 160);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 67);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo:";
            // 
            // rdoVendedor
            // 
            this.rdoVendedor.AutoSize = true;
            this.rdoVendedor.Location = new System.Drawing.Point(195, 27);
            this.rdoVendedor.Name = "rdoVendedor";
            this.rdoVendedor.Size = new System.Drawing.Size(99, 23);
            this.rdoVendedor.TabIndex = 3;
            this.rdoVendedor.TabStop = true;
            this.rdoVendedor.Text = "Vendedor";
            this.rdoVendedor.UseVisualStyleBackColor = true;
            this.rdoVendedor.Click += new System.EventHandler(this.rdoVendedor_Click);
            // 
            // rdoAdministrador
            // 
            this.rdoAdministrador.AutoSize = true;
            this.rdoAdministrador.Location = new System.Drawing.Point(45, 27);
            this.rdoAdministrador.Name = "rdoAdministrador";
            this.rdoAdministrador.Size = new System.Drawing.Size(144, 23);
            this.rdoAdministrador.TabIndex = 2;
            this.rdoAdministrador.TabStop = true;
            this.rdoAdministrador.Text = "Administrador";
            this.rdoAdministrador.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 19);
            this.label5.TabIndex = 16;
            this.label5.Text = "Apellidos:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 19);
            this.label4.TabIndex = 15;
            this.label4.Text = "Nombre(s):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(73, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 19);
            this.label3.TabIndex = 14;
            this.label3.Text = "Contaseña:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(73, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 19);
            this.label2.TabIndex = 13;
            this.label2.Text = "Usuario:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(73, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 19);
            this.label1.TabIndex = 17;
            this.label1.Text = "Confirmar contraseña:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(77, 52);
            this.txtUsuario.MaxLength = 15;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(202, 26);
            this.txtUsuario.TabIndex = 4;
            this.txtUsuario.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtUsuario_KeyUp);
            // 
            // txtcontraseña
            // 
            this.txtcontraseña.Location = new System.Drawing.Point(77, 113);
            this.txtcontraseña.MaxLength = 40;
            this.txtcontraseña.Name = "txtcontraseña";
            this.txtcontraseña.PasswordChar = '*';
            this.txtcontraseña.Size = new System.Drawing.Size(202, 26);
            this.txtcontraseña.TabIndex = 5;
            this.txtcontraseña.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtcontraseña_KeyUp);
            // 
            // txtConfirmar
            // 
            this.txtConfirmar.Location = new System.Drawing.Point(77, 164);
            this.txtConfirmar.MaxLength = 40;
            this.txtConfirmar.Name = "txtConfirmar";
            this.txtConfirmar.PasswordChar = '*';
            this.txtConfirmar.Size = new System.Drawing.Size(202, 26);
            this.txtConfirmar.TabIndex = 6;
            this.txtConfirmar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtConfirmar_KeyUp);
            // 
            // txtNombres
            // 
            this.txtNombres.Location = new System.Drawing.Point(10, 53);
            this.txtNombres.MaxLength = 30;
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(252, 26);
            this.txtNombres.TabIndex = 0;
            this.txtNombres.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNombres_KeyUp);
            // 
            // txtApellidos
            // 
            this.txtApellidos.Location = new System.Drawing.Point(10, 104);
            this.txtApellidos.MaxLength = 40;
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(341, 26);
            this.txtApellidos.TabIndex = 1;
            this.txtApellidos.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtApellidos_KeyUp);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtUsuario);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtConfirmar);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtcontraseña);
            this.groupBox2.Location = new System.Drawing.Point(9, 233);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(367, 207);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Seguridad:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtApellidos);
            this.groupBox3.Controls.Add(this.txtNombres);
            this.groupBox3.Location = new System.Drawing.Point(9, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(367, 147);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Personal:";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // frmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(388, 452);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUsuarios";
            this.Load += new System.EventHandler(this.frmUsuarios_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.RadioButton rdoVendedor;
        public System.Windows.Forms.RadioButton rdoAdministrador;
        public System.Windows.Forms.TextBox txtUsuario;
        public System.Windows.Forms.TextBox txtcontraseña;
        public System.Windows.Forms.TextBox txtConfirmar;
        public System.Windows.Forms.TextBox txtNombres;
        public System.Windows.Forms.TextBox txtApellidos;
    }
}