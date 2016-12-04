using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace SOFTEVOLUTION
{
    public partial class frmCorteCaja : Form
    {
        public frmCorteCaja()
        {
            InitializeComponent();
        }

        # region "VARIABLES DEL FORMULARIO"

        CONSULTAS consultas = new CONSULTAS();

        #endregion

        private void frmCorteCaja_Load(object sender, EventArgs e)
        {
            Corte();
            configurarDatagridViwe();
        }

        public void Corte()
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime fechaActual = DateTime.Today;
            Calendar cal = dfi.Calendar;

            int dia = fechaActual.Day;

            //DatosReporte = consultas.ReporteSemanal(año, mes, semana, fechaCorta);
            dataCorte.DataSource = consultas.Corte(dia);

            lblVentas.Text = Convert.ToString(consultas.CorteVentasRealizadas(dia));
            lblArticulos.Text = Convert.ToString(consultas.CorteArticulos(dia));
            lblTotal.Text = "$" + Convert.ToString(consultas.CorteTotal(dia));
        }

        public void configurarDatagridViwe()
        {
            dataCorte.Columns[0].Width = 150;
            dataCorte.Columns[1].Width = 150;
            dataCorte.Columns[2].Width = 305;
            dataCorte.Columns[3].Width = 100;
            dataCorte.Columns[4].Width = 100;
            dataCorte.Columns[5].Width = 100;


            dataCorte.Columns[0].ReadOnly = true;
            dataCorte.Columns[1].ReadOnly = true;
            dataCorte.Columns[2].ReadOnly = true;
            dataCorte.Columns[3].ReadOnly = true;
            dataCorte.Columns[4].ReadOnly = true;
            dataCorte.Columns[5].ReadOnly = true;
        }
    }
}
