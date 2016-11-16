using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SoftEvolution
{
    public partial class FrmAgregarProducto : Form
    {
        public FrmAgregarProducto()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Agregar();
            
            }

      

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAgregarProducto_Load(object sender, EventArgs e)
        {

        }

        private void txtCodi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar) < 40) && ((e.KeyChar) != 8) || ((e.KeyChar) > 57))
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
            if ((Char.IsNumber(e.KeyChar) == false) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
            else
                e.Handled = false;
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

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Agregar();
        }

        private void cancelarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            frmProductos prod = new frmProductos();
            prod.Show();
        }

        public void Agregar()
        {
            
                try
                {
                    // CREA LOS OBJETOS
                    clsProductos objProducto = new clsProductos();
                    clsDatosProducto objDatos = new clsDatosProducto();

                    // LEE LOS DATOS DE LAS CAJAS Y LOS GUARDA EN EL OBJETO
                    objProducto.Codigo = txtCodi.Text;
                    objProducto.Producto = txtNom.Text;
                    objProducto.Marca = txtMar.Text;
                    objProducto.Categoria = txtCate.Text;
                    objProducto.Detalles = txtDescrip.Text;
                    objProducto.Precio_Compra = txtPC.Text;
                    objProducto.Precio_Venta_Menudeo = txtPV.Text;
                    objProducto.Precio_Venta_Mayoreo = txtPM.Text;
                    objProducto.Precio_Venta_Instructor = txtPE.Text;
                    objProducto.Cantidad = txtCantidad.Text;
                    // INSERTA AL PRODUCTO MEDIANTE EL MÉTODO
                    objDatos.AgregarProducto(objProducto);
                    // MUESTRA MENSAJE DE CONFIRMACION
                    MessageBox.Show("Producto registrado", "Insertar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                    frmProductos prod = new frmProductos();
                    prod.Show();
                }

            catch(MySqlException) {
                MessageBox.Show("***Este producto ya existe***");

            }
            catch
            {
                MessageBox.Show("***Llenar los campos***");

            }
            //}
        }
    }
}

