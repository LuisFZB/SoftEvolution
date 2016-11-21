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
    public partial class frmModificarProveedor : Form
    {
        public frmModificarProveedor()
        {
            InitializeComponent();
        }
        #region "Eventos botones"
        private void tlsActualizar_Click(object sender, EventArgs e)//boton actualizar
        {
            //cadenas con expresiones regulares para validación de correo y telefono
            string correo = @"^((([\w]+\.[\w]+)+)|([\w]+))@(([\w]+\.)+)([A-Za-z]{1,3})$";
            string telefono = @"^\d+|(^\d+[-])+|(^\d+\s)+";

            //condicion que verifica si los cuadros de texto estan vacíos
            if (txtCodigo.Text.Length == 0 || txtEmpresa.Text.Length == 0 || txtTelefono.Text.Length == 0 || txtEmail.Text.Length == 0 || txtContacto.Text.Length == 0 || txtApellido.Text.Length == 0 || txtObservaciones.Text.Length == 0)
            {
                MessageBox.Show("Debe llenar todos los campos", "Modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtCodigo.Text.Length <= 10 && txtTelefono.Text.Length <= 20) //codicion que limita el numero de caracteres
            {
                // condicion para checar la validacion de correo con la expresion regular
                if (Regex.IsMatch(txtEmail.Text, correo))
                {
                    if (Regex.IsMatch(txtTelefono.Text, telefono)) //  condicion para checar la validacion de telefono con la expresion regular
                    {
                        //objetos de clsPoveedores y conexion
                        clsProveedores proveedores = new clsProveedores();
                        ConexionProveedor con = new ConexionProveedor();

                        //obtiene los datos de los cuadros de texto y los pasa a la clase clsProveedores
                        proveedores.Codigo = Convert.ToInt32(txtCodigo.Text);
                        proveedores.NombreEmpresa = txtEmpresa.Text;
                        proveedores.TelefonoEmpresa = txtTelefono.Text;
                        proveedores.EmailEmpresa = txtEmail.Text;
                        proveedores.NombreContacto = txtContacto.Text;
                        proveedores.ApellidoContacto = txtApellido.Text;
                        proveedores.Observaciones = txtObservaciones.Text;

                        con.modificar(ref proveedores); //llamamos el metodo de modificar de la clase conexión y le pasamos la referencia de la clase con los datos 
                        MessageBox.Show("Proveedor actualizado", "Modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //limpia los cuadros de texto
                        txtCodigo.Clear();
                        txtEmpresa.Clear();
                        txtTelefono.Clear();
                        txtEmail.Clear();
                        txtContacto.Clear();
                        txtApellido.Clear();
                        txtObservaciones.Clear();

                        this.Close(); //cierra la ventana
                        frmProveedores pro = new frmProveedores(); //objeto del catalogo de proveedores
                        pro.Show(); //abre la ventana de proveedores
                    }
                    else //en caso de que no sea valido el telefono muestra mensaje
                    {
                        MessageBox.Show("Telefono inválido.", "Modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else //en caso de que el correo no sea valido, muestra mensaje
                {
                    MessageBox.Show("Email inválido.", "Modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (txtCodigo.Text.Length > 10) //en caso de que la cantidad de caracteres del id supere el limite muestra mensaje
            {
                MessageBox.Show("El id no debe superar los 10 digitos");
            }
            else if (txtTelefono.Text.Length > 20) //en caso de que el el numero de caracteres del telefono supere el limite, muestra mensaje
            {
                MessageBox.Show("El telefono no debe superar los 10 digitos");
            }
        }

        private void tlsCancelar_Click(object sender, EventArgs e)//boton cancelar
        {
            this.Close(); //cierra esta ventana
            frmProveedores prov = new frmProveedores(); //objeto del catalogo proveedores
            prov.Show(); //abre la ventana del catalogo de proveedores
        }
        #endregion

        #region "Eventos validaciones"
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e) //valida solo numeros en el cuadro de texto del id
        {
            if ((Char.IsNumber(e.KeyChar) == false) && (e.KeyChar != (char)Keys.Back)) //si no es numerico
            {
                e.Handled = true; //bloquea datos no numericos
            }
            else //en caso de que si sea numerico
            {
                e.Handled = false; //permite el ingreso de datos numericos
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)//validacion telefono
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

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)//validacion email
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

        private void frmModificarProveedor_Load(object sender, EventArgs e)
        {

        }
    }
}
