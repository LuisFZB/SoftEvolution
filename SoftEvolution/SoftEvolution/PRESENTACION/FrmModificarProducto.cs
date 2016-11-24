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
            {
                //objetos de clsPoveedores y conexion
                clsProductos producto = new clsProductos();
                clsDatosProducto con = new clsDatosProducto();

                //obtiene los datos de los cuadros de texto y los pasa a la clase clsProveedores
                producto.Codigo = txtCodi.Text;
                producto.Producto = txtNom.Text;
                producto.Marca = txtMar.Text;
                producto.Categoria = txtCate.Text;
                producto.Precio_Compra = txtPC.Text;
                producto.Precio_Venta_Menudeo = txtPV.Text;
                producto.Precio_Venta_Mayoreo = txtPM.Text;
                producto.Precio_Venta_Instructor = txtPE.Text;
                producto.Cantidad = txtCantidad.Text;
                producto.Detalles = txtDescrip.Text;
                con.ModificarProducto(ref producto); //llamamos el metodo de modificar de la clase conexión y le pasamos la referencia de la clase con los datos 
                MessageBox.Show("Producto actualizado", "Modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //limpia los cuadros de texto
                txtCodi.Clear();
                txtNom.Clear();
                txtMar.Clear();
                txtCate.Clear();
                txtPC.Clear();
                txtPV.Clear();
                txtPM.Clear();
                txtPE.Clear();
                txtCantidad.Clear();
                txtDescrip.Clear();

                this.Close(); //cierra la ventana
                frmProductos pro = new frmProductos(); //objeto del catalogo de productos
                pro.Show(); //abre la ventana de productos
            }
        }

        private void cancerlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            frmProductos prod = new frmProductos();
            prod.Show();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
