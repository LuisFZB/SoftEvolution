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
    public partial class FrmModificarProducto : Form
    {
        public FrmModificarProducto()
        {
            InitializeComponent();
        }
        int s;
        clsDatosProducto datos = new clsDatosProducto();
      

        private void FrmModificarProducto_Load(object sender, EventArgs e)
        {
            if (Tipo.Text.Equals("Agregar"))
            {
                s = 1;
            }
            else if (Tipo.Text.Equals("Buscar"))
            {
                s = 2;
                guardarToolStripMenuItem.Visible = false;
                cancerlarToolStripMenuItem.Text = "Salir";
                txtCodi.Enabled = false;
                txtNom.Enabled = false;
                txtMar.Enabled = false;
                txtCate.Enabled = false;
                txtDescrip.Enabled = false;
                txtPC.Enabled = false;
                txtPV.Enabled = false;
                txtPM.Enabled = false;
                txtPE.Enabled = false;
                txtCantidad.Enabled = false;
                clsProductos producto = datos.getProductosById(Buscar.Text);
                try
                {
                    txtCodi.Text = Convert.ToString(producto.Codigo);
                    txtNom.Text = producto.Producto;
                    txtMar.Text = producto.Marca;
                    txtCate.Text = producto.Categoria;
                    txtDescrip.Text = producto.Detalles;
                    txtPC.Text = producto.Precio_Compra;
                    txtPV.Text =producto.Precio_Venta_Menudeo;
                    txtPM.Text = producto.Precio_Venta_Mayoreo;
                    txtPE.Text = producto.Precio_Venta_Instructor;
                    txtCantidad.Text = producto.Cantidad;
                   
                }
                catch (NullReferenceException)
                {

                }
            }
            else if (Tipo.Text.Equals("Actualizar"))
            {
                s = 3;
                guardarToolStripMenuItem.Text = "Actualizar";
                txtCodi.Enabled = false;
                txtCantidad.Enabled = false;
                clsProductos producto = datos.getProductosById(Buscar.Text);
                txtCodi.Text = Convert.ToString(producto.Codigo);
                txtNom.Text = producto.Producto;
                txtMar.Text = producto.Marca;
                txtCate.Text = producto.Categoria;
                txtDescrip.Text = producto.Detalles;
                txtPC.Text = producto.Precio_Compra;
                txtPV.Text = producto.Precio_Venta_Menudeo;
                txtPM.Text = producto.Precio_Venta_Mayoreo;
                txtPE.Text = producto.Precio_Venta_Instructor;
                txtCantidad.Text = producto.Cantidad;


            }
        }

        private void btncan_Click(object sender, EventArgs e)
        {
            this.Close();
            frmProductos prod = new frmProductos();
            prod.Show();
        }

        private void txtCodi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar) < 48) && ((e.KeyChar) != 8) || ((e.KeyChar) > 57))
            {
                e.Handled = true;
            }
        }

        private void txtPC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar) < 48) && ((e.KeyChar) != 8) || ((e.KeyChar) > 57))
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',')
                e.KeyChar = '.';
            //Permitir comas y puntos (si es punto )
            if (e.KeyChar == ',' || e.KeyChar == '.')
                //si ya hay una coma no permite un nuevo ingreso de esta
                if (txtPC.Text.Contains(",") || txtPC.Text.Contains("."))
                    e.Handled = true;
                else
                    e.Handled = false;
        }

        private void txtPV_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar) < 48) && ((e.KeyChar) != 8) || ((e.KeyChar) > 57))
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',')
                e.KeyChar = '.';
            //Permitir comas y puntos (si es punto )
            if (e.KeyChar == ',' || e.KeyChar == '.')
                //si ya hay una coma no permite un nuevo ingreso de esta
                if (txtPV.Text.Contains(",") || txtPV.Text.Contains("."))
                    e.Handled = true;
                else
                    e.Handled = false;
        }

        private void txtPM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar) < 48) && ((e.KeyChar) != 8) || ((e.KeyChar) > 57))
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',')
                e.KeyChar = '.';
            //Permitir comas y puntos (si es punto )
            if (e.KeyChar == ',' || e.KeyChar == '.')
                //si ya hay una coma no permite un nuevo ingreso de esta
                if (txtPM.Text.Contains(",") || txtPM.Text.Contains("."))
                    e.Handled = true;
                else
                    e.Handled = false;
        }

        private void txtPE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar) < 48) && ((e.KeyChar) != 8) || ((e.KeyChar) > 57))
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',')
                e.KeyChar = '.';
            //Permitir comas y puntos (si es punto )
            if (e.KeyChar == ',' || e.KeyChar == '.')
                //si ya hay una coma no permite un nuevo ingreso de esta
                if (txtPE.Text.Contains(",") || txtPE.Text.Contains("."))
                    e.Handled = true;
                else
                    e.Handled = false;
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtNom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsNumber(e.KeyChar) == true) && (Char.IsLetter(e.KeyChar) == false) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
            else
                e.Handled = false;
        }

        private void txtMar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsNumber(e.KeyChar) == true) && (Char.IsLetter(e.KeyChar) == false) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
            else
                e.Handled = false;
        }

        private void txtCate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsNumber(e.KeyChar) == true) && (Char.IsLetter(e.KeyChar) == false) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
            else
                e.Handled = false;
        }

        private void txtDescrip_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsNumber(e.KeyChar) == true) && (Char.IsLetter(e.KeyChar) == false) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
            else
                e.Handled = false;
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (s == 1)
            {
                clsProductos producto = new clsProductos();
                producto.Codigo = txtCodi.Text;
                producto.Producto = txtNom.Text;
                producto.Marca = txtMar.Text;
                producto.Categoria = txtDescrip.Text;
                producto.Detalles = txtDescrip.Text;
                producto.Precio_Compra = txtPC.Text;
                producto.Precio_Venta_Menudeo = txtPV.Text;
                producto.Precio_Venta_Mayoreo = txtPM.Text;
                producto.Precio_Venta_Instructor = txtPE.Text;
                producto.Cantidad = txtCantidad.Text;

                if (!txtCodi.Text.Equals("") && !txtCantidad.Text.Equals(""))
                {
                    datos.AgregarProducto(producto);
                    new frmProductos().Show();
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Llene los campos obligatorios");
                }
            }
            else if (s == 3)
            {
                clsProductos producto = new clsProductos();
                producto.Codigo = txtCodi.Text;
                producto.Producto = txtNom.Text;
                producto.Marca = txtMar.Text;
                producto.Categoria = txtDescrip.Text;
                producto.Detalles = txtDescrip.Text;
                producto.Precio_Compra = txtPC.Text;
                producto.Precio_Venta_Menudeo = txtPV.Text;
                producto.Precio_Venta_Mayoreo = txtPM.Text;
                producto.Precio_Venta_Instructor = txtPE.Text;
                producto.Cantidad = txtCantidad.Text;
               
                if (!txtCodi.Text.Equals("") && !txtCantidad.Text.Equals(""))
                {
                    datos.ModificarProducto(producto);
                    new frmProductos().Show();
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Llene los campos obligatorios");
                }
            }
        }

        private void cancerlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            frmProductos prod = new frmProductos();
            prod.Show();
        }
    }
}
