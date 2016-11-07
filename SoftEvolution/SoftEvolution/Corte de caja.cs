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
    public partial class Corte_de_caja : Form
    {
        public Corte_de_caja()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Corte_de_caja_Load(object sender, EventArgs e)
        {
            DAOCorte datos = new DAOCorte();
            PojosCorte pojos = new PojosCorte();
            List<PojosCorte> li = datos.ListCorte();


            int con = 0;
            double suma = 0;
            int cant = 0;
            try
            {
                foreach (PojosCorte po in li)
                {

                    ListViewItem lista = new ListViewItem(li[con].folio.ToString());
                    lista.SubItems.Add(li[con].usuario);
                    lista.SubItems.Add(li[con].codigo_producto);

                    lista.SubItems.Add(li[con].cantidad.ToString());
                    lista.SubItems.Add(li[con].precio.ToString());
                    lista.SubItems.Add(li[con].total.ToString());
                    suma = suma + li[con].total;
                    cant = cant + li[con].cantidad;


                    listView1.Items.Add(lista);

                    con++;
                }

                label5.Text = con.ToString();
                label6.Text = cant.ToString();
                label7.Text = suma.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error consulte al administrador");
            }
        }
    }
}
