using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftEvolution
{
    public partial class frmAgregar : Form
    {
        public frmAgregar()
        {
            InitializeComponent();
        }

        private void frmAgregar_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblEmpresa_Click(object sender, EventArgs e)
        {

        }

        private void lblCodigo_Click(object sender, EventArgs e)
        {

        }

        private void lblTelefono_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblEmail_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblContacto_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblObservaciones_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            string regex = @"^((([\w]+\.[\w]+)+)|([\w]+))@(([\w]+\.)+)([A-Za-z]{1,3})$";
            string telefono = @"^\d+|(^\d+[-])+|(^\d+\s)+";

            if (txtCodigo.Text.Length == 0 || txtEmpresa.Text.Length == 0 || txtTelefono.Text.Length == 0 || txtEmail.Text.Length == 0 || txtContacto.Text.Length == 0 || txtApellido.Text.Length == 0 || txtObservaciones.Text.Length == 0)
            {
                MessageBox.Show("Debe llenar todos los campos", "Insertar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else { 
                // Validación
                if (Regex.IsMatch(txtEmail.Text, regex))
                {
                    if (Regex.IsMatch(txtTelefono.Text, telefono))
                    {
                        //Console.WriteLine("Email válido.");
                        clsProveedores proveedores = new clsProveedores();
                        Conexion con = new Conexion();

                        proveedores.Codigo = Convert.ToInt32(txtCodigo.Text);
                        proveedores.NombreEmpresa = txtEmpresa.Text;
                        proveedores.TelefonoEmpresa = txtTelefono.Text;
                        proveedores.EmailEmpresa = txtEmail.Text;
                        proveedores.NombreContacto = txtContacto.Text;
                        proveedores.ApellidoContacto = txtApellido.Text;
                        proveedores.Observaciones = txtObservaciones.Text;
                        con.insertar(proveedores);
                        MessageBox.Show("Proveedor registrado", "Insertar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCodigo.Clear();
                        txtEmpresa.Clear();
                        txtTelefono.Clear();
                        txtEmail.Clear();
                        txtContacto.Clear();
                        txtApellido.Clear();
                        txtObservaciones.Clear();

                        this.Close();
                        frmProveedores pro = new frmProveedores();
                        pro.Show();
                    }
                    else
                    {
                        MessageBox.Show("Telefono inválido.", "Insertar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Email inválido.","Insertar",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            frmProveedores prov = new frmProveedores();
            prov.Show();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsNumber(e.KeyChar) == false) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsNumber(e.KeyChar) == false) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            string regex = @"^((([\w]+\.[\w]+)+)|([\w]+))@(([\w]+\.)+)([A-Za-z]{1,3})$";

            // Validación
            if (Regex.IsMatch(txtEmail.Text, regex))
            {
                Console.WriteLine("Email válido.");
            }
            else
            {
                Console.WriteLine("Email inválido.");
            }
        }
    }
}
