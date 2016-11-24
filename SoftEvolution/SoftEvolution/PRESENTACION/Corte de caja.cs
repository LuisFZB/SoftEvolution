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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
     
        private void Corte_de_caja_Load(object sender, EventArgs e)
        {
           
        }

        private void Corte_de_caja_Load_1(object sender, EventArgs e)
        {
            //objeto de la clase de datos
            DAOCorte datos = new DAOCorte();
            //objeto de la clase pojos
            PojosCorte pojos = new PojosCorte();
            //creacion de lista con los datos cargados de la consulta
            List<PojosCorte> li = datos.ListCorte();
            //condicion en caso de no encontrar valores en la consulta
            if (li.Count == 0)
            {
                MessageBox.Show("No hay ventas registradas");
            }
            else
            {

                int con = 0; //variable para almacenar la cantidad de ventas realizadas
                double suma = 0; //variable para almacenar la cantidad de productos vendidos
                int cant = 0;//variable para almacenar la suma total de las ventas
                try
                {
                    //ciclo para recorer la lista y llenar el listview
                    foreach (PojosCorte po in li)
                    {

                        ListViewItem lista = new ListViewItem(li[con].folio.ToString());
                        lista.SubItems.Add(li[con].usuario);
                        //creacion de la lista para la busqueda en la tabla detalle_ventas
                        List<PojosCorte> l0 = datos.getProductById(li[con].folio.ToString());

                        lista.SubItems.Add(l0[0].producto);

                        lista.SubItems.Add(li[con].cantidad.ToString());
                        lista.SubItems.Add(l0[0].precio.ToString());
                        lista.SubItems.Add(li[con].total.ToString());
                        suma = suma + li[con].total;
                        cant = cant + li[con].cantidad;


                        listView1.Items.Add(lista);

                        con++;
                    }

                    label5.Text = con.ToString();//la cantidad de ventas realizadas
                    label6.Text = cant.ToString();//la cantidad de productos vendidos
                    label7.Text = suma.ToString();// la suma total de las ventas
                }
                catch (Exception)
                {
                    MessageBox.Show("Error consulte al administrador");
                }
            }
           
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
