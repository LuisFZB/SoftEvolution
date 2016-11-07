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
            // CREA LOS OBJETOS
            clsDatosProducto datos = new clsDatosProducto();
            clsProductos producto = new clsProductos();
            try
            {
                // OBTIENE LA CLAVE DEL PRODUCTO SELECCIONADO PARA ELIMINARLO
                producto.Codigo = dgvProductos.Rows[dgvProductos.SelectedRows[0].Index].Cells[0].Value.ToString();
                // LLAMA AL MÉTODO PARA ELIMINAR EL producto
                datos.EliminarProducto(producto);

                if (datos.h == 1)
                {
                    // REFRESCA LOS DATOS Y MUESTRA EL MENSAJE "ELIMINADO"
                    VerProducto();
                    MessageBox.Show("Producto eliminado");
                }
            }
            catch(Exception )
            {
                MessageBox.Show("Seleciona un campo para eliminar");
            }

            
        }

        private void VerProducto()
        {
            clsDatosProducto objDatos = new clsDatosProducto();
            dgvProductos.DataSource = objDatos.getProducto();
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBuscarProducto bus = new FrmBuscarProducto();
            bus.Show();
            this.Hide();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
