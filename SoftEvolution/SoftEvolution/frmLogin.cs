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
    public partial class frmLogin : Form
    {
        public frmLogin(ToolStripLabel Usuario)
        {
            InitializeComponent();
            usuario = Usuario;
        }

        # region "VARIABLES DEL FORMULARIO"

        string[] DatosUsuario;                                      // ARREGLO EN EL CUAL SE GUARDARAN LOS DATOS OBTENIDOS DEL USUARIO.
        ToolStripLabel usuario;                                     // VARIBLE QUE CONTIENE LAS PROPIEDADES DEL TOOLSTRIPLABEL DEL USUARIO.

        # endregion

        /// <summary>
        /// METODO PARA VERIFICAR SI EL USUARIO Y CONTRASEÑA ESTAN REGISTRADOS.
        /// </summary>
        /// <param name="Usuario"></param> PARAMETRO QUE CONTIENE EL USUARIO QUE DESEA HACER LA CONEXION.
        /// <param name="Contraseña"></param> PARAMETRO QUE CONTIENE LA CONTRASEÑA DEL USUARIO QUE DESEA HACER LA CONEXION.
        /// <returns>
        /// RETORNA UN VERDADERO SI EL USUARIO Y CONTRASEÑA SON CORRECTOS Y UN VALOR FALSO EN CASO CONTRARIO.
        /// </returns>
        public bool login(string Usuario, string Contraseña)
        {
            CONSULTAS consultas = new CONSULTAS();
            DatosUsuario = consultas.Login(Usuario, Contraseña);

            if (DatosUsuario != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// LIMPIA LOS TEXT BOX.
        /// </summary>
        public void limpiarCajas()
        {
            txtUsuario.ClearUndo();
            txtUsuario.Clear();
            txtContraseña.ClearUndo();
            txtContraseña.Clear();

            txtUsuario.Focus();
        }

        /// <summary>
        /// METODO PARA COPROBAR QUE TODAS LAS CAJAS CONTENGAN INFORMACION.
        /// </summary>
        /// <returns>
        /// RETORNA VERDADERO SI TODAS LAS CAJAS TIENEN CONTENIDO O UN VALOR FALSO EN CASO CONTRARIO.
        /// </returns>
        public bool CajasLlenas()
        {
            if (txtUsuario.Text == "" || txtContraseña.Text == "")
            {
                MessageBox.Show("Uno o mas campos estan vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (CajasLlenas())
                {
                    if (login(txtUsuario.Text, txtContraseña.Text))
                    {
                        MessageBox.Show("ENTRO");
                        usuario.Text = "Usuario: " + txtUsuario.Text;
                        MessageBox.Show("MOSTRAR Y OCULTAR ELEMENTOS");
                        this.Close();
                        limpiarCajas();
                    }
                    else
                    {
                        MessageBox.Show("NO ENTRO");
                        limpiarCajas();
                    }
                }
            }
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (CajasLlenas())
                {
                    if (login(txtUsuario.Text, txtContraseña.Text))
                    {
                        MessageBox.Show("ENTRO");
                        usuario.Text = "Usuario: " + txtUsuario.Text;
                        MessageBox.Show("MOSTRAR Y OCULTAR ELEMENTOS");
                        this.Close();
                        limpiarCajas();
                    }
                    else
                    {
                        MessageBox.Show("NO ENTRO");
                        limpiarCajas();
                    }
                }
            }
        }
    }
}
