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
    public partial class frmModificar : Form
    {
        public frmModificar()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            frmProveedores prov = new frmProveedores();
            prov.Show();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string correo = @"^((([\w]+\.[\w]+)+)|([\w]+))@(([\w]+\.)+)([A-Za-z]{1,3})$";
            //string telefono = @"^[+-]?\d+(\.\d+)?$";
            string telefono = @"^\d+|(^\d+[-])+|(^\d+\s)+";

            if (txtCodigo.Text.Length == 0 || txtEmpresa.Text.Length == 0 || txtTelefono.Text.Length == 0 || txtEmail.Text.Length == 0 || txtContacto.Text.Length == 0 || txtApellido.Text.Length == 0 || txtObservaciones.Text.Length == 0)
            {
                MessageBox.Show("Debe llenar todos los campos", "Insertar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Validación
                if (Regex.IsMatch(txtEmail.Text, correo))
                {
                    if (Regex.IsMatch(txtTelefono.Text, telefono))
                    {
                        clsProveedores proveedores = new clsProveedores();
                        Conexion con = new Conexion();

                        proveedores.Codigo = Convert.ToInt32(txtCodigo.Text);
                        proveedores.NombreEmpresa = txtEmpresa.Text;
                        proveedores.TelefonoEmpresa = txtTelefono.Text;
                        proveedores.EmailEmpresa = txtEmail.Text;
                        proveedores.NombreContacto = txtContacto.Text;
                        proveedores.ApellidoContacto = txtApellido.Text;
                        proveedores.Observaciones = txtObservaciones.Text;

                        con.modificar(ref proveedores);
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
                    MessageBox.Show("Email inválido.", "Insertar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
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
            /*if (e.KeyChar == (char)Keys.Back)

            {

                return;

            }

            string expresionRegular = @"^[+-]?\d+(\.\d+)?$";

            if (Regex.IsMatch(e.KeyChar.ToString(), expresionRegular))

            {

                e.Handled = true;

            }*/
        }
    }
}
