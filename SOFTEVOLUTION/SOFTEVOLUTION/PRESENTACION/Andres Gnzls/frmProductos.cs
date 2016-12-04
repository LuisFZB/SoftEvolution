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
    public partial class frmProductos : Form
    {
        public frmProductos(ToolStripLabel Usuario)
        {
            InitializeComponent();
            usuario = Usuario;
        }

        #region "VARIBLES FORMULARIO"

        private string[] lstproducto;
        private string[] DetallesUsuario;
        private ToolStripLabel usuario;

        private CONSULTAS consultas = new CONSULTAS();
        private clsProducto datos = new clsProducto();
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
            
            txtProducto.Enabled = true;

            cmbProveedor.Enabled = true;
            cmbMarca.Enabled = true;
            cmbCategoria.Enabled = true;

            rtxtDescripcion.Enabled = true;

            txtCompra.Enabled = true;
            txtVenta.Enabled = true;
            txtMayoreo.Enabled = true;
            txtEntrenador.Enabled = true;
        }

        public void Deshabilitar()
        {
            txtCodigo.Enabled = false;
            txtProducto.Enabled = false;

            cmbProveedor.Enabled = false;
            cmbMarca.Enabled = false;
            cmbCategoria.Enabled = false;

            rtxtDescripcion.Enabled = false;

            txtCompra.Enabled = false;
            txtVenta.Enabled = false;
            txtMayoreo.Enabled = false;
            txtEntrenador.Enabled = false;
        }

        public void Limpiar()
        {
            txtCodigo.Clear();
            txtProducto.Clear();
            txtCantidad.Text = "0";

            cmbProveedor.Text = "";
            cmbMarca.Text = "";
            cmbCategoria.Text = "";

            rtxtDescripcion.Clear();

            txtCompra.Clear();
            txtVenta.Clear();
            txtMayoreo.Clear();
            txtEntrenador.Clear();
        }

        public void Cerrar()
        {
            this.Close();
        }


        public bool Validar()
        {
            if(txtCodigo.Text != "" && txtProducto.Text != "" &&
                cmbProveedor.Text != "" && cmbMarca.Text != "" && cmbCategoria.Text != "" &&
                txtCompra.Text != "" && txtVenta.Text != "" && txtMayoreo.Text != "" && txtEntrenador.Text != ""){
                return true;
            }else{
                return false;
            }
        }


        public void AgregarProducto()
        {
            datos.Codigo = txtCodigo.Text;
            datos.Codigo_Proveedor = cmbProveedor.Text;
            datos.Producto = txtProducto.Text;
            datos.Marca = cmbMarca.Text;
            datos.Categoria = cmbCategoria.Text;
            datos.Detalles = rtxtDescripcion.Text;
            datos.Precio_Compra = Convert.ToDouble(txtCompra.Text);
            datos.Precio_Venta_Menudeo = Convert.ToDouble(txtVenta.Text);
            datos.Precio_Venta_Mayoreo = Convert.ToDouble(txtMayoreo.Text);
            datos.Precio_Venta_Instructor = Convert.ToDouble(txtEntrenador.Text);
            datos.Cantidad = Convert.ToInt32(txtCantidad.Text);


            //consultas.RegistrarUsuario(datos);
            Limpiar();

            consultas.RegistrarProducto(datos);
        }

        public void ModificarProducto()
        {
            datos.Codigo = txtCodigo.Text;
            datos.Codigo_Proveedor = cmbProveedor.Text;
            datos.Producto = txtProducto.Text;
            datos.Marca = cmbMarca.Text;
            datos.Categoria = cmbCategoria.Text;
            datos.Detalles = rtxtDescripcion.Text;
            datos.Precio_Compra = Convert.ToDouble(txtCompra.Text);
            datos.Precio_Venta_Menudeo = Convert.ToDouble(txtVenta.Text);
            datos.Precio_Venta_Mayoreo = Convert.ToDouble(txtMayoreo.Text);
            datos.Precio_Venta_Instructor = Convert.ToDouble(txtEntrenador.Text);
            datos.Cantidad = Convert.ToInt32(txtCantidad.Text);


            //consultas.RegistrarUsuario(datos);
            Limpiar();

            consultas.ActualizarProducto(datos);
        }

        public void EliminarProducto()
        {
            consultas.EliminarProducto(txtCodigo.Text);

            //consultas.RegistrarUsuario(datos);
            Limpiar();
        }


        public void LlenarCajas(string[] lstProducto)
        {
            lstproducto = lstProducto;

            txtCodigo.Text = lstproducto[0];
            cmbProveedor.Text = lstproducto[1];
            txtProducto.Text = lstproducto[2];
            cmbMarca.Text = lstproducto[3];
            cmbCategoria.Text = lstproducto[4];
            rtxtDescripcion.Text = lstproducto[5];
            txtCompra.Text = lstproducto[6];
            txtVenta.Text = lstproducto[7];
            txtMayoreo.Text = lstproducto[8];
            txtEntrenador.Text = lstproducto[9];
            txtCantidad.Text = lstproducto[10];
        }

        public void LlenarGridView()
        {
            dataProductos.DataSource = consultas.getProducto();
        }

        public void configurarDatagridViwe()
        {
            dataProductos.Columns[0].Width = 80;
            dataProductos.Columns[1].Width = 160;
            dataProductos.Columns[2].Width = 200;
            dataProductos.Columns[3].Width = 150;
            dataProductos.Columns[4].Width = 150;
            dataProductos.Columns[5].Width = 120;
            dataProductos.Columns[6].Width = 80;
            dataProductos.Columns[7].Width = 95;
            dataProductos.Columns[8].Width = 80;
            dataProductos.Columns[9].Width = 80;
            dataProductos.Columns[10].Width = 85;


            dataProductos.Columns[0].ReadOnly = true;
            dataProductos.Columns[1].ReadOnly = true;
            dataProductos.Columns[2].ReadOnly = true;
            dataProductos.Columns[3].ReadOnly = true;
            dataProductos.Columns[4].ReadOnly = true;
            dataProductos.Columns[5].ReadOnly = true;
            dataProductos.Columns[6].ReadOnly = true;
            dataProductos.Columns[7].ReadOnly = true;
            dataProductos.Columns[8].ReadOnly = true;
            dataProductos.Columns[9].ReadOnly = true;
            dataProductos.Columns[10].ReadOnly = true;
        }

        #endregion

        private void frmProductos_Load(object sender, EventArgs e)
        {
            Deshabilitar();
            LlenarGridView();
            configurarDatagridViwe();

            DetallesUsuario = consultas.DatosUsuario(usuario.Text);
            txtPuesto.Text = DetallesUsuario[0];
            txtNombre.Text = DetallesUsuario[1];
            txtApellido.Text = DetallesUsuario[2];
        }

        private void txtCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && !(char.IsPunctuation(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && !(char.IsPunctuation(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtMayoreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && !(char.IsPunctuation(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtEntrenador_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && !(char.IsPunctuation(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void cmbProveedor_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void cmbProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }
    }
}
