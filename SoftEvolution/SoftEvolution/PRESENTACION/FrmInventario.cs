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
   
    public partial class FrmInventario : Form
    {
        public FrmInventario()
        {
            InitializeComponent();
        }

        private void Buscar(string codigo)
        {
            clsDatosInventario x = new clsDatosInventario();
            clsInventario inv = new clsInventario();
            inv = x.getInventarioById(codigo);
            if (inv != null)
            {
                ListViewItem datos = new ListViewItem(inv.codigo);
                datos.SubItems.Add(inv.Cantidad);


                lstInve.Items.Add(datos);
                
            }
            else
            {

            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmBuscarInven buscar = new frmBuscarInven();
            buscar.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
