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
    public partial class frmAgregarProveedor : Form
    {
        public frmAgregarProveedor()
        {
            InitializeComponent();
        }
        #region
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
        #endregion

        #region "Eventos botones"
        private void tlsAgregar_Click(object sender, EventArgs e)//boton agregar
        {
            try
            {
                //Expresiones regulares para validación de telefono y email
                string regex = @"^((([\w]+\.[\w]+)+)|([\w]+))@(([\w]+\.)+)([A-Za-z]{1,3})$";
                string telefono = @"^\d+|(^\d+[-])+|(^\d+\s)+";
                //condicion que evalua si los cuadros de texto están vacíos
                if (txtCodigo.Text.Length == 0 || txtEmpresa.Text.Length == 0 || txtTelefono.Text.Length == 0 || txtEmail.Text.Length == 0 || txtContacto.Text.Length == 0 || txtApellido.Text.Length == 0 || txtObservaciones.Text.Length == 0)
                {
                    MessageBox.Show("Debe llenar todos los campos", "Insertar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtCodigo.Text.Length <= 10 && txtTelefono.Text.Length <= 20)//condicion que limita el numero de caracteres de clave y telefono
                {
                    if (Regex.IsMatch(txtEmail.Text, regex)) //condicion para validar email
                    {
                        if (Regex.IsMatch(txtTelefono.Text, telefono)) //condicion para validar telefono
                        {
                            //objetos de la clase de getters y setters y de la conexión
                            clsProveedores proveedores = new clsProveedores();
                            ConexionProveedor con = new ConexionProveedor();

                            //pasamos los datos los getters
                            proveedores.Codigo = Convert.ToInt32(txtCodigo.Text);
                            proveedores.NombreEmpresa = txtEmpresa.Text;
                            proveedores.TelefonoEmpresa = txtTelefono.Text;
                            proveedores.EmailEmpresa = txtEmail.Text;
                            proveedores.NombreContacto = txtContacto.Text;
                            proveedores.ApellidoContacto = txtApellido.Text;
                            proveedores.Observaciones = txtObservaciones.Text;
                            con.insertar(proveedores); //mandamos llamar el metodo de insertar de la clase conexion y le pasamos el objeto
                            MessageBox.Show("Proveedor registrado", "Insertar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //vaciamos los cuadros de texto
                            txtCodigo.Clear();
                            txtEmpresa.Clear();
                            txtTelefono.Clear();
                            txtEmail.Clear();
                            txtContacto.Clear();
                            txtApellido.Clear();
                            txtObservaciones.Clear();

                            this.Close(); //cerramos la ventana
                            frmProveedores pro = new frmProveedores(); //llamamos el formulario principal del catalogo
                            pro.Show();//abrimos la ventana
                        }
                        else //en caso de que el telefono no sea valido muestra mensaje
                        {
                            MessageBox.Show("Telefono inválido.", "Insertar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else //en caso de que el email no sea valido muestra mensaje
                    {
                        MessageBox.Show("Email inválido.", "Insertar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (txtCodigo.Text.Length > 10) //si el contenido del cuadro de texto supera el limite, muestra mensaje
                {
                    MessageBox.Show("El id no debe superar los 10 digitos");
                }
                else if (txtTelefono.Text.Length > 20) //si el contenido del cuadro de texto de telefono supera el limite, muestra mensaje
                {
                    MessageBox.Show("El telefono no debe superar los 20 digitos");
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException) //en caso de que el id del proveedor exista
            {
                txtCodigo.Text = "";//vacía el cuadro de texto
                txtCodigo.Focus();//selecciona el cuadro de texto
                MessageBox.Show("El id del proveedor ya existe en la base de datos");//muestra mensaje de error
            }
        }

        private void tlsCancelar_Click(object sender, EventArgs e)//boton de cancelar
        {
            this.Close(); //cierra esta ventana
            frmProveedores prov = new frmProveedores(); //llama la ventana del catalogo de proveedores
            prov.Show(); //abre la ventana de proveedores
        }
        #endregion

        #region "Eventos validaciones"
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e) //validación de solo numeros en el cuadro de texto del id
        {
            if ((Char.IsNumber(e.KeyChar) == false) && (e.KeyChar != (char)Keys.Back)) //si el valor no es un numero y no es el boton de borrar
            {
                e.Handled = true; //bloquea el ingreso de todos los caracteres
            }
            else //en caso contrario
            {
                e.Handled = false; //no se realiza ningún bloqueo
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e) //validación de telefono
        {
            //en caso de que no sea un número, no sea el boton de borrar, no sea el boton de espacio ni el caracter -
            if ((Char.IsNumber(e.KeyChar) == false) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != '-') && (e.KeyChar != (char)Keys.Space))
            {
                e.Handled = true;//bloquea el ingreso
            }
            //en caso de que sea numero, el caracter - y el boton de espacio
            else if ((Char.IsNumber(e.KeyChar) == true) && (e.KeyChar == '-') && (e.KeyChar == (char)Keys.Space))
            {
                e.Handled = false; //no realiza ningún bloqueo
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)//validación de correo
        {
            if ((e.KeyChar != (char)Keys.Back) && (e.KeyChar == (char)Keys.Space))//si se presiona el boton de espacio
            {
                e.Handled = true;//bloquea el ingreso
            }
            else //en caso contrario
            {
                e.Handled = false;//no realiza ningún bloqueo
            }
        }
        #endregion

        

        
    }
}
