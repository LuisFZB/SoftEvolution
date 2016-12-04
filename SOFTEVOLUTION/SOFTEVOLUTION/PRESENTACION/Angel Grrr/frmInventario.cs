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
    public partial class frmInventario : Form
    {
        public frmInventario(ToolStripTextBox Buscar)
        {
            InitializeComponent();
            buscar = Buscar;
        }

        # region "VARIABLES DEL FORMULARIO"

        CONSULTAS consultas = new CONSULTAS();

        ToolStripTextBox buscar;

        #endregion  

        private void frmInventario_Load(object sender, EventArgs e)
        {
            dataProductos.DataSource = consultas.getProducto();
            configurarDatagridViwe();
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
    }
}
