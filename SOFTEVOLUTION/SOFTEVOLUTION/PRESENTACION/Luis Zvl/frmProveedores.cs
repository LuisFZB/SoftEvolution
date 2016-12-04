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
    public partial class frmProveedores : Form
    {
        public frmProveedores(ToolStripLabel Usuario)
        {
            InitializeComponent();
            usuario = Usuario;
        }

        #region "VARIBLES FORMULARIO"

        private string[] lstproveedor;
        private string[] DetallesUsuario;
        private string lada;
        private string telefono;
        private ToolStripLabel usuario;

        private CONSULTAS consultas = new CONSULTAS();
        private clsProveedor datos = new clsProveedor();
        //private frmLogin login;
        private frmPrincipal principal;

        #endregion

        #region "METODOS ORDEN Y LIMPIEZA"

        public void Habilitar(string oriundo)
        {
            if(oriundo == "Update")
                txtCodigo.Enabled = false;
            else
                txtCodigo.Enabled = true;

            txtEmpresa.Enabled = true;
            txtLada.Enabled = true;
            txtTelefono.Enabled = true;
            txtEmail.Enabled = true;

            txtContacto.Enabled = true;
            txtApellidos.Enabled = true;

            rtxtObservaciones.Enabled = true;
        }

        public void Deshabilitar()
        {
            txtCodigo.Enabled = false;

            txtEmpresa.Enabled = false;
            txtLada.Enabled = false;
            txtTelefono.Enabled = false;
            txtEmail.Enabled = false;

            txtContacto.Enabled = false;
            txtApellidos.Enabled = false;

            rtxtObservaciones.Enabled = false;
        }

        public void Limpiar()
        {
            txtCodigo.Clear();

            txtEmpresa.Clear();
            txtLada.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();

            txtContacto.Clear();
            txtApellidos.Clear();

            rtxtObservaciones.Clear();
        }

        public void Cerrar()
        {
            this.Close();
        }


        public bool Validar()
        {
            if(txtCodigo.Text != "" &&
                txtEmpresa.Text != "" && txtLada.Text != "" && txtTelefono.Text != "" && txtEmail.Text != "" &&
                txtContacto.Text != "" && txtApellidos.Text != ""){
                if(txtLada.Text.Length == 3 && txtTelefono.Text.Length == 7){
                    return true;
                }
                else
                {
                    return false;
                }
                
            }else{
                return false;
            }
        }


        public void AgregarProveedor()
        {
            datos.Codigo = txtCodigo.Text;
            datos.NombreEmpresa = txtEmpresa.Text;
            datos.TelefonoEmpresa = "(" + txtLada.Text + ")" + txtTelefono.Text;
            datos.EmailEmpresa = txtEmail.Text;
            datos.NombreContacto = txtContacto.Text;
            datos.ApellidoContacto = txtApellidos.Text;
            datos.Observaciones = rtxtObservaciones.Text;


            //consultas.RegistrarUsuario(datos);
            Limpiar();

            consultas.RegistrarProveedor(datos);
        }

        public void ModificarProveedor()
        {
            datos.Codigo = txtCodigo.Text;
            datos.NombreEmpresa = txtEmpresa.Text;
            datos.TelefonoEmpresa = "(" + txtLada.Text + ")" + txtTelefono.Text;
            datos.EmailEmpresa = txtEmail.Text;
            datos.NombreContacto = txtContacto.Text;
            datos.ApellidoContacto = txtApellidos.Text;
            datos.Observaciones = rtxtObservaciones.Text;


            //consultas.RegistrarUsuario(datos);
            Limpiar();

            consultas.ActualizarProveedor(datos);
        }

        public void EliminarProveedor()
        {
            consultas.EliminarProveedor(txtCodigo.Text);

            //consultas.RegistrarUsuario(datos);
            Limpiar();
        }


        public void LlenarCajas(string[] lstProveedor)
        {
            lstproveedor = lstProveedor;

            lada = lstproveedor[2];
            telefono = lstproveedor[2];

            lada = lada[1].ToString() + lada[2].ToString() + lada[3].ToString();
            telefono = telefono[5].ToString() + telefono[6].ToString() + telefono[7].ToString() + telefono[8].ToString() + telefono[9].ToString() + telefono[10].ToString() + telefono[11].ToString();

            txtCodigo.Text = lstproveedor[0];
            txtEmpresa.Text = lstproveedor[1];
            txtLada.Text = lada;
            txtTelefono.Text = telefono;
            txtEmail.Text = lstproveedor[3];
            txtContacto.Text = lstproveedor[4];
            txtApellidos.Text = lstproveedor[5];
            rtxtObservaciones.Text = lstproveedor[6];
        }

        public void LlenarGridView()
        {
            dataProveedores.DataSource = consultas.getProveedor();
        }

        public void configurarDatagridViwe()
        {
            dataProveedores.Columns[0].Width = 100;
            dataProveedores.Columns[1].Width = 200;
            dataProveedores.Columns[2].Width = 200;
            dataProveedores.Columns[3].Width = 190;
            dataProveedores.Columns[4].Width = 200;
            dataProveedores.Columns[5].Width = 255;
            dataProveedores.Columns[6].Width = 140;


            dataProveedores.Columns[0].ReadOnly = true;
            dataProveedores.Columns[1].ReadOnly = true;
            dataProveedores.Columns[2].ReadOnly = true;
            dataProveedores.Columns[3].ReadOnly = true;
            dataProveedores.Columns[4].ReadOnly = true;
            dataProveedores.Columns[5].ReadOnly = true;
            dataProveedores.Columns[6].ReadOnly = true;
        }

        #endregion

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            Deshabilitar();
            LlenarGridView();
            configurarDatagridViwe();

            DetallesUsuario = consultas.DatosUsuario(usuario.Text);
            txtPuesto.Text = DetallesUsuario[0];
            txtNombre.Text = DetallesUsuario[1];
            txtApellido.Text = DetallesUsuario[2];
        }

        private void txtLada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }
    }
}
