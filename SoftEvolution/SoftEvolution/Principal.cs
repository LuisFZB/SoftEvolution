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
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            frmProveedores catalogo = new frmProveedores();
            catalogo.Show();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            frmProductos productos = new frmProductos();
            productos.Show();
        }

        private void Corte_Click(object sender, EventArgs e)
        {
            Corte_de_caja corte = new Corte_de_caja();
            corte.Show();
        }
    }
}
