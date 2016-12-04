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
    public partial class frmReporteSemanal : Form
    {
        public frmReporteSemanal()
        {
            InitializeComponent();
        }

        private void frmReporteSemanal_Load(object sender, EventArgs e)
        {
            GenerarReporte();
            Semana();
            configurarDatagridViwe();
        }

        # region "VARIABLES DEL FORMULARIO"

        CONSULTAS consultas = new CONSULTAS();

        string[] DatosReporte;

        #endregion

        public void GenerarReporte()
        {
            /*ListViewItem item = new ListViewItem();

            item.SubItems.Add(DatosReporte[0]);
            item.SubItems.Add(DatosReporte[1]);
            item.SubItems.Add(DatosReporte[2]);
            item.SubItems.Add(DatosReporte[3]);
            item.SubItems.Add(DatosReporte[4]);
            lstReporteSemanal.Items.Add(item);*/

            
        }

        public void Semana()
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime fechaActual = DateTime.Today;
            Calendar cal = dfi.Calendar;

            int año = fechaActual.Year;

            int mes = fechaActual.Month;

            int semana = cal.GetWeekOfYear(fechaActual, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

            semana--;

            string fechaCorta = DateTime.Now.ToString("yyyy-MM-dd");

            //DatosReporte = consultas.ReporteSemanal(año, mes, semana, fechaCorta);
            dataReporte.DataSource = consultas.ReporteSemanal(año, mes, semana, fechaCorta);

            lblArticulos.Text = Convert.ToString(consultas.ReporteArticulos(año, mes, semana, fechaCorta));
            lblTotal.Text = "$" + Convert.ToString(consultas.ReporteTotal(año, mes, semana, fechaCorta));
        }

        public void configurarDatagridViwe()
        {
            dataReporte.Columns[0].Width = 150;
            dataReporte.Columns[1].Width = 350;
            dataReporte.Columns[2].Width = 100;
            dataReporte.Columns[3].Width = 200;
            dataReporte.Columns[4].Width = 100;


            dataReporte.Columns[0].ReadOnly = true;
            dataReporte.Columns[1].ReadOnly = true;
            dataReporte.Columns[2].ReadOnly = true;
            dataReporte.Columns[3].ReadOnly = true;
            dataReporte.Columns[4].ReadOnly = true;
        }
    }
}
