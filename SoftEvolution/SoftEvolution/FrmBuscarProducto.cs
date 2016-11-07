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
    public partial class FrmBuscarProducto : Form
    {
        public FrmBuscarProducto()
        {
            InitializeComponent();
        }

        int bus;
        private void button1_Click(object sender, EventArgs e)
        {
            dgvBuscar.DataSource = clsDatosProducto.Buscar(txtCodig.Text);
           
                txtCodig.Text = "";
        }

        private void txtCodig_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsNumber(e.KeyChar) == false) && (e.KeyChar != (char)Keys.Back))
            {
                
                e.Handled = true;
            }
            else
                e.Handled = false;
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            frmProductos prod = new frmProductos();
            prod.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
