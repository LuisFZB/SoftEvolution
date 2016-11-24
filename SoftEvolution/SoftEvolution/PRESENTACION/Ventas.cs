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
    public partial class Ventas : Form
    {
        public Ventas()
        {
            InitializeComponent();
        }
        //variable para el almacenamiento del folio maximo en la base de datos
        int folio = 0;
        // variable para almacenar la cantidad de productos en la venta
        double cantidad = 0;
        // variable para almacenar la suma total de las cantidades de productos
        double totalReal = 0;
        // variable para almacenar la suma de los productos insertados en la busqueda del poducto
        double total = 0;
        string bandera;
        int ext = 0;
        //objetos de las clases pojos y datos
        DAOVentas datos = new DAOVentas();
        VentasPojos getCodigo = new VentasPojos();
        private void Ventas_Load(object sender, EventArgs e)
        {
            DAOVentas datos = new DAOVentas();
            VentasPojos pojos = new VentasPojos();
            //lista para almacenar el valor del folio consultado en la base de datos
            List<VentasPojos> li = datos.List();
            //bloquea las cajas de texto
            textBox4.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox5.ReadOnly = true;
            //campos a seleccionar en el combobox
            comboBox1.Items.Add("Mayoreo");
            comboBox1.Items.Add("Entrenador");
            comboBox1.Items.Add("Menudeo");
            //validacion en caso de que no exista valor de folio en la base de datos
            if (li[0].folio.ToString() != "")
            {
                //obtirne el valor del folio y lo almacena
                folio = Int32.Parse(li[0].folio.ToString()) + 1;
            }
            else
            {
                //en caso de que el folio sea 0 lo inicializa en 1
                folio = folio + 1;
            }

            //muestra el valor del folio
            label12.Text = folio.ToString();
            //obtirne el valor de la fecha actual y lo imprime 
            label14.Text = DateTime.Now.ToString("yyyy/MM/dd");
            //obtirne el valor de la hora actual y lo imprime 
            label15.Text = DateTime.Now.ToString("hh:mm:ss");
           
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            //cuando el usuario preciona enter llama el metodo buscar
            if (e.KeyValue == (char)Keys.Enter)
            {
                Buscar(textBox6.Text);
            }
            //cuando el usuario preciona tab manda ala proxima caja de texto
            if (e.KeyValue == (char)Keys.Tab)
            {
                txtPago.Focus();
            }
            
        }
        //metodo que busca el producto por codigo
        private void Buscar(string codigo)
        {



            //hace llamado al metodo buscar de la clase DAOVentas
            getCodigo = datos.getProductById(codigo);
            //validacion para cuando el codigo es nulo
            if (getCodigo != null)
            {
                //bandera para controlar la existencia de los productos
                if (getCodigo.codigo != bandera)
                {

                    ext = getCodigo.existencia;
                    bandera = getCodigo.codigo;

                }


                //bandera para controlar la existencia de los productos cuando el numero de productos excede al existente en la base de datos 
                if (getCodigo.existencia < Int32.Parse(textBox2.Text))
                {

                    MessageBox.Show("No hay suficientes productos para la venta del producto: " + getCodigo.codigo + " productos existentes: " + getCodigo.existencia);
                }
                else
                {
                    //bandera para controlar la existencia de los productos cuando se inserta producto por producto
                    if (ext >= Int32.Parse(textBox2.Text))
                    {
                        //operacion para calcular el tatal de la insercion de los productos
                        total = getCodigo.precio_venta_menudeo * double.Parse(textBox2.Text);
                        //insercion de los datos al listview
                        ListViewItem lista = new ListViewItem(getCodigo.codigo);

                        lista.SubItems.Add(getCodigo.producto);
                        lista.SubItems.Add(textBox2.Text);
                        lista.SubItems.Add(getCodigo.precio_venta_menudeo.ToString());
                        lista.SubItems.Add(total.ToString());

                        listView1.Items.Add(lista);
                        //operacion para calcular el total de los productos vendos
                        cantidad = cantidad + double.Parse(textBox2.Text);
                        label5.Text = cantidad.ToString();
                        //operacion para calcular la suma total de todos los productos vendidos
                        totalReal = totalReal + total;
                        label8.Text = totalReal.ToString();
                        // decrmento de los productos en existencia
                        ext = ext - 1;

                        textBox6.Text = "";
                        textBox6.Focus();

                    }
                    else
                    {
                        MessageBox.Show("Producto agotado");
                    }



                }

            }
            else
            {
                MessageBox.Show("Producto no registrado");
            }



        }

        private void txtPago_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPago_KeyUp(object sender, KeyEventArgs e)
        {
            //variable para el almacenamiento del cambio
            double cambio;

            //evento para insertar la venta
            if (e.KeyValue == (char)Keys.F7)
            {
                try
                {
                    // validacion en caso de que el usuario no ingrese valor
                    if (txtPago.Text == "")
                    {
                        MessageBox.Show("ingresa un valor");
                    }
                    else
                    {
                        //operacion para mostrar el cambio
                        double pago = double.Parse(txtPago.Text);
                        // validacion en caso de que el usuario no cubra el total de la venta
                        if (pago < totalReal)
                        {
                            MessageBox.Show("importe incorrecto");
                        }
                        else
                        {
                            //mostrar el cambio
                            cambio = pago - totalReal;
                            label6.Text = "$" + cambio.ToString();
                            //tamaño de la lista
                            int tamaño = listView1.Items.Count;
                            DAOVentas datos = new DAOVentas();
                            VentasPojos pojos = new VentasPojos();
                            //llena los datos para insertarlos a la tabla de ventas
                            pojos.folio = Int32.Parse(label12.Text);
                            pojos.usuario = textBox3.Text;
                            pojos.fecha = label14.Text + " " + label15.Text;
                            pojos.cantidad = Int32.Parse(label5.Text);
                            pojos.total = double.Parse(label8.Text);
                            //pasa los datos para llenar la tabla ventas
                            datos.insertar(pojos);
                            //recorre el listview para hacer la disminucion de existencias en la base de datos
                            for (int i = 0; i < tamaño; i++)
                            {
                                if (listView1.Items[i].SubItems[0].Text != "")
                                {
                                    pojos.codigo = listView1.Items[i].SubItems[0].Text;
                                    pojos.cantidad = Int32.Parse(listView1.Items[i].SubItems[2].Text);
                                    datos.modificarProducto(ref pojos);

                                    try
                                    {
                                        //recorre el listview para hacer el llenado de la tabla detalles de venta
                                        pojos.folio = Int32.Parse(label12.Text);
                                        pojos.codigo = listView1.Items[i].SubItems[0].Text;
                                        pojos.producto = listView1.Items[i].SubItems[1].Text;
                                        pojos.cantidad = Int32.Parse(listView1.Items[i].SubItems[2].Text);
                                        pojos.precio_venta_menudeo = Int32.Parse(listView1.Items[i].SubItems[3].Text);
                                        pojos.total = Int32.Parse(listView1.Items[i].SubItems[4].Text);
                                        datos.insertarDetalle(pojos);
                                    }
                                    //TRY CATCH cuando encuentra llaves duplicadas 
                                    catch (Exception)
                                    {
                                        // modifica el valor de cantidad y subtotal cuando encuentra llaves compuestas iguales
                                        pojos.folio = Int32.Parse(label12.Text);
                                        pojos.codigo = listView1.Items[i].SubItems[0].Text;
                                        pojos.cantidad = Int32.Parse(listView1.Items[i].SubItems[2].Text);
                                        pojos.total = Int32.Parse(listView1.Items[i].SubItems[4].Text);
                                        datos.modificar(ref pojos);
                                    }

                                }
                            }

                            MessageBox.Show("venta realizada");
                            //incrementa el valor del folio
                            folio++;
                            //limpia todo para una nueva venta
                            label12.Text = folio.ToString();
                            listView1.Items.Clear();
                            label5.Text = "0";
                            label8.Text = "$0.00";
                            txtPago.Clear();
                            label6.Text = "$0.00";
                            comboBox1.Text = "";
                            cantidad = 0;
                            totalReal = 0;
                            total = 0;

                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Primero realice una venta");
                }
            
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tamaño = listView1.Items.Count;
            cantidad = 0;
            totalReal = 0;
            // hace la modificacion del precio buscando por precio de entrenador cuando se selecciona en el combobox
            if (comboBox1.Text == "Entrenador")
            {
                for (int i = 0; i < tamaño; i++)
                {
                    if (listView1.Items[i].SubItems[0].Text != "")
                    {
                        getCodigo = datos.PrecioEntrenador(listView1.Items[i].SubItems[0].Text);

                        if (getCodigo != null)
                        {
                            total = 0;
                            total = getCodigo.precio_venta_menudeo * double.Parse(listView1.Items[i].SubItems[2].Text);
                            ListViewItem lista = new ListViewItem(getCodigo.codigo);

                            lista.SubItems.Add(getCodigo.producto);
                            lista.SubItems.Add(listView1.Items[i].SubItems[2].Text);
                            lista.SubItems.Add(getCodigo.precio_venta_menudeo.ToString());
                            lista.SubItems.Add(total.ToString());

                            listView1.Items.Add(lista);



                            totalReal = totalReal + total;
                            label8.Text = totalReal.ToString();

                            txtPago.Focus();

                        }
                        else
                        {
                            MessageBox.Show("Producto no registrado");
                        }

                    }


                }
                for (int j = 0; j < tamaño; j++)
                {
                    listView1.Items.RemoveAt(0);
                }

            }
             //hace la modificacion del precio buscando por precio de mayoreo cuando se selecciona en el combobox
            if (comboBox1.Text == "Mayoreo")
            {
                for (int i = 0; i < tamaño; i++)
                {
                    if (listView1.Items[i].SubItems[0].Text != "")
                    {
                        getCodigo = datos.PrecioMayoreo(listView1.Items[i].SubItems[0].Text);

                        if (getCodigo != null)
                        {
                            total = 0;
                            total = getCodigo.precio_venta_menudeo * double.Parse(listView1.Items[i].SubItems[2].Text);
                            ListViewItem lista = new ListViewItem(getCodigo.codigo);

                            lista.SubItems.Add(getCodigo.producto);
                            lista.SubItems.Add(listView1.Items[i].SubItems[2].Text);
                            lista.SubItems.Add(getCodigo.precio_venta_menudeo.ToString());
                            lista.SubItems.Add(total.ToString());

                            listView1.Items.Add(lista);



                            totalReal = totalReal + total;
                            label8.Text = totalReal.ToString();
                            txtPago.Focus();


                        }
                        else
                        {
                            MessageBox.Show("Producto no registrado");
                        }

                    }


                }
                for (int j = 0; j < tamaño; j++)
                {
                    listView1.Items.RemoveAt(0);
                }

            }
             //hace la modificacion del precio buscando por precio de menudeo cuando se selecciona en el combobox
            if (comboBox1.Text == "Menudeo")
            {
                for (int i = 0; i < tamaño; i++)
                {
                    if (listView1.Items[i].SubItems[0].Text != "")
                    {
                        getCodigo = datos.getProductById(listView1.Items[i].SubItems[0].Text);

                        if (getCodigo != null)
                        {
                            total = 0;
                            total = getCodigo.precio_venta_menudeo * double.Parse(listView1.Items[i].SubItems[2].Text);
                            ListViewItem lista = new ListViewItem(getCodigo.codigo);

                            lista.SubItems.Add(getCodigo.producto);
                            lista.SubItems.Add(listView1.Items[i].SubItems[2].Text);
                            lista.SubItems.Add(getCodigo.precio_venta_menudeo.ToString());
                            lista.SubItems.Add(total.ToString());

                            listView1.Items.Add(lista);



                            totalReal = totalReal + total;
                            label8.Text = totalReal.ToString();
                            txtPago.Focus();


                        }
                        else
                        {
                            MessageBox.Show("Producto no registrado");
                        }

                    }


                }
                for (int j = 0; j < tamaño; j++)
                {
                    listView1.Items.RemoveAt(0);
                }


            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        /*private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }*/
        //validaciones
        private void textBox6_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                textBox2.Focus();
            }
            if (e.KeyValue == (char)Keys.Tab)
            {
                textBox2.Focus();
            }
        }
        //validaciones
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validaciones
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        //validaciones
        private void txtPago_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        //validaciones
        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Tab)
            {
                textBox4.Focus();
            }
        }
        //validaciones
        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Tab)
            {
                textBox5.Focus();
            }
        }
        //validaciones
        private void textBox5_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Tab)
            {
                textBox6.Focus();
            }
        }
        //validaciones
        private void textBox6_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Tab)
            {
                textBox2.Focus();
            }
        }


    }
}
