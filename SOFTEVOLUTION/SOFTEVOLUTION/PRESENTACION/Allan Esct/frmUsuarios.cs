using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SOFTEVOLUTION
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios(bool InicioSistema, ToolStripLabel Usuario)
        {
            InitializeComponent();

            iniciosistema = InicioSistema;
            usuario = Usuario;
        }



        #region "VARIBLES FORMULARIO"

        private bool iniciosistema;
        private ToolStripLabel usuario;
        private string[] lstusuario;

        private CONSULTAS consultas = new CONSULTAS();
        private clsUsuario datos = new clsUsuario();
        //private frmLogin login;
        private frmPrincipal principal;

        #endregion



        #region "METODOS ORDEN Y LIMPIEZA"

        public void Habilitar(string oriundo)
        {
            
            txtNombres.Enabled = true;
            txtApellidos.Enabled = true;

            rdoAdministrador.Enabled = true;
            rdoVendedor.Enabled = true;

            if (oriundo == "Update")
                txtUsuario.Enabled = false;
            else
                txtUsuario.Enabled = true;
            txtcontraseña.Enabled = true;
            txtConfirmar.Enabled = true;
        }

        public void Deshabilitar()
        {
            txtNombres.Enabled = false;
            txtApellidos.Enabled = false;

            rdoAdministrador.Enabled = false;
            rdoVendedor.Enabled = false;

            txtUsuario.Enabled = false;
            txtcontraseña.Enabled = false;
            txtConfirmar.Enabled = false;
        }

        public void Limpiar()
        {
            txtNombres.Clear();
            txtApellidos.Clear();

            rdoAdministrador.Checked = false;
            rdoVendedor.Checked = false;

            txtUsuario.Clear();
            txtcontraseña.Clear();
            txtConfirmar.Clear();
        }

        public void Cerrar()
        {
            this.Close();
        }



        public bool ValidarLleno()
        {
            if ((rdoAdministrador.Checked == true || rdoVendedor.Checked == true) &&
                (txtNombres.Text != "" && txtApellidos.Text != "" && txtUsuario.Text != "" &&
                txtcontraseña.Text != "" && txtConfirmar.Text != ""))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Llene correctamente cada uno de los campos.", "Informacion faltante",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        public void AgregarUsuario()
        {
            if(rdoAdministrador.Checked){
                datos.Tipo = "Administrador";
            }
            else
            {
                datos.Tipo = "vendedor";
            }
            datos.Usuario = txtUsuario.Text;
            datos.Contraseña = txtcontraseña.Text;
            datos.Nombres = txtNombres.Text;
            datos.Apellidos = txtApellidos.Text;
            

            //consultas.RegistrarUsuario(datos);
            Limpiar();

            if(consultas.RegistrarUsuario(datos)){
                if (iniciosistema == true)
                {
                    this.Close();

                    MessageBox.Show("                         Felicidades!!!\n"
                        + "Ya puede empezar a usuar su nuevo Sistema", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    principal = new frmPrincipal();
                    principal.FormularioCargado("Login");

                }
            }
        }

        public void ModificarUsuario()
        {
            if (rdoAdministrador.Checked)
            {
                datos.Tipo = "Administrador";
            }
            else
            {
                datos.Tipo = "vendedor";
            }
            datos.Usuario = txtUsuario.Text;
            datos.Contraseña = txtcontraseña.Text;
            datos.Nombres = txtNombres.Text;
            datos.Apellidos = txtApellidos.Text;


            //consultas.RegistrarUsuario(datos);
            Limpiar();

            consultas.ActualizarUsuario(datos);
        }

        public void EliminarUsuario()
        {
            consultas.EliminarUsuario(txtUsuario.Text);

            //consultas.RegistrarUsuario(datos);
            Limpiar();
        }


        public void LlenarCajas(string[] lstUsuario)
        {
            lstusuario = lstUsuario;

            if (lstusuario[0] == "Administrador")
            {
                rdoAdministrador.Checked = true;
            }
            else
            {
                rdoVendedor.Checked = true;
            }
            txtUsuario.Text = lstusuario[1];
            txtcontraseña.Text = lstusuario[2];
            txtConfirmar.Text = lstusuario[2];
            txtNombres.Text = lstusuario[3];
            txtApellidos.Text = lstusuario[4];
        }


        private void InicioSistema()
        {
            rdoAdministrador.Checked = true;
        }

        private void LoadFormulario()
        {
            txtNombres.Focus();

            Limpiar();
        }

        public bool ValidarContraseña()
        {
            if(txtcontraseña.Text == txtConfirmar.Text){
                return true;
            }
            else
            {
                MessageBox.Show("La contraseña no coincide en la confirmacion.", "Error de informacion",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        



        #endregion



        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            if(iniciosistema == false){
                LoadFormulario();
                Deshabilitar();
            }
            else
            {
                LoadFormulario();
                InicioSistema();
            }
        }

        private void rdoVendedor_Click(object sender, EventArgs e)
        {
            if (iniciosistema == false)
            {
                rdoVendedor.Checked = true;
            }
            else
            {
                InicioSistema();
            }
        }

        private void txtNombres_KeyUp(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.G))
            {
                if (ValidarLleno() && ValidarContraseña())
                {
                    AgregarUsuario();
                }
            }
        }

        private void txtApellidos_KeyUp(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.G))
            {
                if (ValidarLleno() && ValidarContraseña())
                {
                    AgregarUsuario();
                }
            }
        }

        private void txtUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.G))
            {
                if (ValidarLleno() && ValidarContraseña())
                {
                    AgregarUsuario();
                }
            }
        }

        private void txtcontraseña_KeyUp(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.G))
            {
                if (ValidarLleno() && ValidarContraseña())
                {
                    AgregarUsuario();
                }
            }
        }

        private void txtConfirmar_KeyUp(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.G))
            {
                if (ValidarLleno() && ValidarContraseña())
                {
                    AgregarUsuario();
                }
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
