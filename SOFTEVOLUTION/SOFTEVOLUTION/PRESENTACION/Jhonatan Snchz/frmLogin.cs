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
    public partial class frmLogin : Form
    {
        public frmLogin(ToolStripLabel Usuario, ToolStripButton Login,
             ToolStripSplitButton Archivo,
             ToolStripMenuItem Agregar, ToolStripMenuItem Modificar, ToolStripMenuItem Eliminar,
             ToolStripMenuItem Guardar, ToolStripMenuItem Cancelar,
             ToolStripMenuItem Cerrar,
             ToolStripButton Usuarios, ToolStripButton Productos, ToolStripButton Proveedores,
             ToolStripButton Compras, ToolStripButton Ventas,
             ToolStripMenuItem Corte, ToolStripMenuItem Reporte, ToolStripMenuItem Ordenes,
             ToolStripDropDownButton Administracion,
             ToolStripTextBox Buscar)
        {
            InitializeComponent();

            usuario = Usuario;
            log_in = Login;
            archivo = Archivo;
            agregar = Agregar;
            modificar = Modificar;
            eliminar = Eliminar;
            guardar = Guardar;
            cancelar = Cancelar;
            cerrar = Cerrar;
            usuarios = Usuarios;
            productos = Productos;
            proveedores = Proveedores;
            compras = Compras;
            ventas = Ventas;
            corte = Corte;
            reporte = Reporte;
            ordenes = Ordenes;
            administracion = Administracion;
            buscar = Buscar;
        }



        # region "VARIABLES DEL FORMULARIO"

        string[] DatosUsuario;
        ToolStripLabel usuario;
        ToolStripButton log_in;
        ToolStripSplitButton archivo;
        ToolStripMenuItem agregar;
        ToolStripMenuItem modificar;
        ToolStripMenuItem eliminar;
        ToolStripMenuItem guardar;
        ToolStripMenuItem cancelar;
        ToolStripMenuItem cerrar;
        ToolStripButton usuarios;
        ToolStripButton productos;
        ToolStripButton proveedores;
        ToolStripButton compras;
        ToolStripButton ventas;
        ToolStripMenuItem corte;
        ToolStripMenuItem reporte;
        ToolStripMenuItem ordenes;
        ToolStripDropDownButton administracion;
        ToolStripTextBox buscar;

        private frmPrincipal principal;

        # endregion





        #region "METODOS ORDEN Y LIMPIEZA"

        private bool login(string Usuario, string Contraseña)
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

        private void limpiarCajas()
        {
            txtUsuario.ClearUndo();
            txtUsuario.Clear();
            txtContraseña.ClearUndo();
            txtContraseña.Clear();

            txtUsuario.Focus();
        }

        private bool CajasLlenas()
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

        private void Logear()
        {
            if (CajasLlenas())
            {
                if (login(txtUsuario.Text, txtContraseña.Text))
                {
                    log_in.Text = "Logout";
                    MessageBox.Show("ENTRO");
                    usuario.Text = txtUsuario.Text;

                    Habilitar();

                    principal = new frmPrincipal();
                    principal.LogIn();

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

        private void Habilitar(){
            archivo.Enabled = true;
            agregar.Enabled = false;
            modificar.Enabled = false;
            eliminar.Enabled = false;
            guardar.Enabled = false;
            cancelar.Enabled = false;
            cerrar.Enabled = false;
            usuarios.Enabled = true;
            productos.Enabled = true;
            proveedores.Enabled = true;
            compras.Enabled = true;
            ventas.Enabled = true;
            corte.Enabled = true;
            reporte.Enabled = true;
            ordenes.Enabled = true;
            administracion.Enabled = true;
            buscar.Enabled = true;
        }

        #endregion





        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                Logear();
            }
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                Logear();
            }
        }


    }
}
