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
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();

            VerProducto();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            FrmAgregarProducto agregaProduct = new FrmAgregarProducto();
            agregaProduct.Show();

        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmModificarProducto s = new FrmModificarProducto();
            s.Tipo.Text = "Actualizar";
            try
            {
                s.Buscar.Text = dgvProductos.Rows[dgvProductos.SelectedRows[0].Index].Cells[0].Value.ToString();
                this.Hide();
                s.Show();

            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Seleciona un registro");
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ver();


        }

        private void VerProducto()
        {
            clsDatosProducto objDatos = new clsDatosProducto();
            dgvProductos.DataSource = objDatos.getProducto();
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {


            try //entra en caso de que haya seleccionado un dato
            {
                clsProductos produc = new clsProductos();//objeto de la clase clsProductos
                clsDatosProducto datos = new clsDatosProducto();//objeto de la clase clsDatosProducto
                //le indicamos que el dato que seleccione, solo tome el id y haga la conversion a entero
                produc.Codigo = Convert.ToString(dgvProductos.Rows[dgvProductos.SelectedRows[0].Index].Cells[0].Value.ToString());
                //mensaje de confirmacion
                DialogResult dialog = MessageBox.Show("¿Deseas eliminar este producto?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dialog == DialogResult.Yes) //entra si el usuario elige eliminar el proveedor
                {
                    datos.EliminarProducto(produc);//elimina el dato seleccionado
                    ver();//llamado al metodo ver para cargar los datos actualizados
                    MessageBox.Show("Producto eliminado"); //mensaje 
                }
                else if (dialog == DialogResult.No) //en caso de que el usuario no quiera eliminarlo muestra mensaje
                {
                    MessageBox.Show("Producto no eliminado");
                }
            }
            catch (ArgumentOutOfRangeException)//entra en caso de que no se haya seleccionado ningun dato y muestra mensaje
            {
                MessageBox.Show("Seleciona un registro para poder eliminar");
            }

        }
        public void ver() //metodo que muestra los datos en el datagridview
        {
            clsDatosProducto produ = new clsDatosProducto(); //objeto de la clase de conexion
            dgvProductos.DataSource = produ.getProducto(); //muestra los datos en el datagridview
        }


        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCodig_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsNumber(e.KeyChar) == false) && (e.KeyChar != (char)Keys.Back)) //si no es numerico
            {
                e.Handled = true; //bloquea datos no numericos
            }
            else //en caso de que si sea numerico
            {
                e.Handled = false; e.Handled = false; //permite el ingreso de datos numericos
            }
        }

        private void txtCodig_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter) //si presiona la tecla enter entra
            {
                if (txtCodig.Text.Length == 0) //si el cuadr de texto esta vacío entra y muestra mensaje
                {
                    MessageBox.Show("Debe ingresar un valor", "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtCodig.Text.Length <= 10) //conndicion que limita el numero de caracteres
                {
                    clsDatosProducto con = new clsDatosProducto();//objeto de la clase de conexion

                    if (con.buscar(txtCodig.Text) == null)//entra en esta condicion solo si el dato no se encuentra
                    {
                        dgvProductos.DataSource = con.buscar(txtCodig.Text);//vacia el datagridview
                        txtCodig.Text = "";//vacia el cuadro de texto
                        txtCodig.Focus();//el cuadro de texto esta seleccionado para ingresar datos
                        MessageBox.Show("El producto no existe");//mensaje
                        ver();//llamado del metodo que muestra los datos
                    }
                    else //en caso de que el dato exista en la base de datos
                    {
                        dgvProductos.DataSource = con.buscar(txtCodig.Text);//muestra el dato buscado
                        txtCodig.Text = "";//vacia el cuadro de texto
                        txtCodig.Focus();//selecciona el cuadro de texto
                    }
                }
                else if (txtCodig.Text.Length > 10) //si rebasa el limite de caracteres entra
                {
                    MessageBox.Show("El valor ingresado debe ser menor a 10 digitos");//muestra mensaje
                    txtCodig.Text = "";//vacia el cuadro de texto
                    txtCodig.Focus();//selecciona el cuadro de texto
                }
            }
        }
    }
}
