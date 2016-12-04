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
    public partial class frmOrdenes : Form
    {
        public frmOrdenes(ToolStripTextBox Buscar)
        {
            InitializeComponent();
            buscar = Buscar;
        }

        # region "VARIABLES DEL FORMULARIO"

        CONSULTAS consultas = new CONSULTAS();

        ToolStripTextBox buscar;

        #endregion

        private void Ordenes_Load(object sender, EventArgs e)
        {
            Ordenes();
            configurarDatagridViwe();
        }

        public void Ordenes()
        {
            dataOrdenes.DataSource = consultas.OrdenesCompras();
        }

        public void DetallesOrdenes()
        {
            dataOrdenes.DataSource = consultas.OrdenesDetallesCompras(Convert.ToInt32(buscar.Text));
        }

        public void configurarDatagridViwe()
        {
            dataOrdenes.Columns[0].Width = 200;
            dataOrdenes.Columns[1].Width = 240;
            dataOrdenes.Columns[2].Width = 280;
            dataOrdenes.Columns[3].Width = 100;
            dataOrdenes.Columns[4].Width = 80;


            dataOrdenes.Columns[0].ReadOnly = true;
            dataOrdenes.Columns[1].ReadOnly = true;
            dataOrdenes.Columns[2].ReadOnly = true;
            dataOrdenes.Columns[3].ReadOnly = true;
            dataOrdenes.Columns[4].ReadOnly = true;
        }

        public void configurarDatagridViweDetalles()
        {
            dataOrdenes.Columns[0].Width = 180;
            dataOrdenes.Columns[1].Width = 180;
            dataOrdenes.Columns[2].Width = 286;
            dataOrdenes.Columns[3].Width = 100;
            dataOrdenes.Columns[4].Width = 80;
            dataOrdenes.Columns[5].Width = 80;


            dataOrdenes.Columns[0].ReadOnly = true;
            dataOrdenes.Columns[1].ReadOnly = true;
            dataOrdenes.Columns[2].ReadOnly = true;
            dataOrdenes.Columns[3].ReadOnly = true;
            dataOrdenes.Columns[4].ReadOnly = true;
            dataOrdenes.Columns[5].ReadOnly = true;
        }
    }
}
