using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftEvolution

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       public int yaseleccionoparaeliminar = 0;
       


     

       
        public void comboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

           

        }

        public void txtClave_TextChanged(object sender, EventArgs e)
        {

        }

        public void txtContrasena_TextChanged(object sender, EventArgs e)
        {

        }

        public void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        public void txtApellidos_TextChanged(object sender, EventArgs e)
        {

        }
        //Se crea un objeto de Clase UsuariosDAL,Usuarios y se toman los datos que se tienen en los campos y se ponen en las variables de la clase usuario
        // una ves que ya se tienen los datos se manda llamar al metodo agregarUsuario con pUsuarios1  se le mandan los datos y si todo salio bien 
        // manda un mensaje de confirmacion de agregado de lo contrario un no se pudo agregar y si faltaron campos por llenar manda un mns que faltan campos 
        //por llenar o Seleccionar cuando se modifica.
        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                try
                {
                    UsuariosDAL pUsuarios1 = new UsuariosDAL();
                    Usuarios pUsuarios = new Usuarios();
                    pUsuarios.tipo = comboTipo.SelectedItem.ToString();
                    pUsuarios.usuario = txtClave.Text;
                    pUsuarios.contraseña = txtContrasena.Text;
                    pUsuarios.nombres = txtNombre.Text.Trim();
                    pUsuarios.apellidos = txtApellidos.Text.Trim();

                    int resultado = pUsuarios1.AgregarUsuario(pUsuarios);
                    if (resultado > 0)
                    {
                        MessageBox.Show("Cliente Guardado Con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtClave.Text = "";
                    txtContrasena.Text = "";
                    txtNombre.Text = "";
                    txtApellidos.Text = "";
                    comboTipo.Text = "Seleccionar:";
                    }
                    else
                    {
                        MessageBox.Show("No se pudo guardar el cliente", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch
                {
                    MessageBox.Show("Faltan campos por llenar o seleccionar");
                }
            

        }

        // abre la ventana buscar y cierra esta ventana
        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
           // MessageBox.Show("valor de yaseleccionoparaeliminar " + yaseleccionoparaeliminar);
            FrmOperacionesUsuarios mod = new FrmOperacionesUsuarios();
            mod.Show();
            this.Hide();

        }
        // abre la ventana buscar y cierra esta ventana
        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOperacionesUsuarios buscar = new FrmOperacionesUsuarios();
            buscar.Show();
            this.Hide();
        }
        // abre la ventana buscar y cierra esta ventana
        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOperacionesUsuarios eli = new FrmOperacionesUsuarios();
            eli.Show();
            this.Hide();
        }
        //Se valida que ya álla seleccionado el usuario a modificar y una ves que ya se modifico al dar en guardar se guarder los cambios, 
        //si no se a seleccionado algo a modificar y se da en guardar se mostrara otro mensaje que diga No hay datos a modificar.
        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            if (yaseleccionoparaeliminar == 1)
            {

                Usuarios pUsuarios = new Usuarios();
                pUsuarios.tipo = comboTipo.SelectedItem.ToString();
                pUsuarios.usuario = txtClave.Text;
                pUsuarios.contraseña = txtContrasena.Text;
                pUsuarios.nombres = txtNombre.Text.Trim();
                pUsuarios.apellidos = txtApellidos.Text.Trim();

               
                UsuariosDAL modifica = new UsuariosDAL();
                int resultado = modifica.ModificarUsuario(pUsuarios);
                if (resultado > 0)
                {
                    MessageBox.Show("Cliente Modificado Con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtClave.Text = "";
                    yaseleccionoparaeliminar = 0;
                    //Activar(true) o desactivar(false) un txt
                    txtClave.Enabled=true;
                    txtContrasena.Text = "";
                    txtNombre.Text = "";
                    txtApellidos.Text = "";
                    comboTipo.Text = "Seleccionar:";
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el cambio", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtClave.Enabled = true;
                    yaseleccionoparaeliminar = 0;
                }
            }else
            {
                MessageBox.Show("No hay nada que modificar");
            } 
        }
        //Abre la ventana de buscar y cierra esta ventana
        private void verDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FrmOperacionesUsuarios buscar = new FrmOperacionesUsuarios();
            buscar.Show();
            this.Hide();
        }
        //Evento que no permite que se escriba en el combobox de tipo
        private void comboTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled=true;
        }
        //Evento de txtNombre que valida solo letras y y cambia la 1era letra a mayuscula y el puntero lo pone al final 
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
             
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

            if (txtNombre.Text.Length == 1)
            {
                string Mayuscula = txtNombre.Text.Substring(0, 1).ToUpper();
                
                txtNombre.Text = Mayuscula + "";
                
                txtNombre.SelectionStart = txtNombre.Text.Length;
            }
        }
        
        private void txtApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            //Combertir primera letra de Apellidos a Mayuscula
            if (txtApellidos.Text.Length == 1)
            {
                string Mayuscula = txtApellidos.Text.Substring(0, 1).ToUpper();
                //  MessageBox.Show("cadena nombre " + Mayuscula);
                txtApellidos.Text = Mayuscula + "";
                //pasa puntero al final
                txtApellidos.SelectionStart = txtApellidos.Text.Length;
            }

        }

        private void funcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //limpia los campos cuando se cancela modificar
        private void cancelarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtClave.Text = "";
            txtClave.Enabled = true;
            txtContrasena.Text = "";
            txtNombre.Text = "";
            txtApellidos.Text = "";
            comboTipo.Text = "Seleccionar:";
        }
    }
}
