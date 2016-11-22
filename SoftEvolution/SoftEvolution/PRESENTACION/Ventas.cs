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
        int folio = 0;
        double cantidad = 0;
        double totalReal = 0;
        double total = 0;
        string bandera;
        int ext = 0;
        DAOVentas datos = new DAOVentas();
        VentasPojos getCodigo = new VentasPojos();
        private void Ventas_Load(object sender, EventArgs e)
        {
            DAOVentas datos = new DAOVentas();
            VentasPojos pojos = new VentasPojos();
            List<VentasPojos> li = datos.List();
            textBox4.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox5.ReadOnly = true;
            comboBox1.Items.Add("Mayoreo");
            comboBox1.Items.Add("Entrenador");
            comboBox1.Items.Add("Menudeo");
            if (li[0].folio.ToString() != "")
            {
                folio = Int32.Parse(li[0].folio.ToString()) + 1;
            }
            else
            {
                folio = folio + 1;
            }


            label12.Text = folio.ToString();
            label14.Text = DateTime.Now.ToString("yyyy/MM/dd");
            label15.Text = DateTime.Now.ToString("hh:mm:ss");
           
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                Buscar(textBox6.Text);
            }
            if (e.KeyValue == (char)Keys.Tab)
            {
                txtPago.Focus();
            }
            
        }
        private void Buscar(string codigo)
        {




            getCodigo = datos.getProductById(codigo);

            if (getCodigo != null)
            {

                if (getCodigo.codigo != bandera)
                {

                    ext = getCodigo.existencia;
                    bandera = getCodigo.codigo;

                }



                if (getCodigo.existencia < Int32.Parse(textBox2.Text))
                {

                    MessageBox.Show("No hay suficientes productos para la venta del producto: " + getCodigo.codigo + " productos existentes: " + getCodigo.existencia);
                }
                else
                {
                    if (ext >= Int32.Parse(textBox2.Text))
                    {
                        total = getCodigo.precio_venta_menudeo * double.Parse(textBox2.Text);
                        ListViewItem lista = new ListViewItem(getCodigo.codigo);

                        lista.SubItems.Add(getCodigo.producto);
                        lista.SubItems.Add(textBox2.Text);
                        lista.SubItems.Add(getCodigo.precio_venta_menudeo.ToString());
                        lista.SubItems.Add(total.ToString());

                        listView1.Items.Add(lista);

                        cantidad = cantidad + double.Parse(textBox2.Text);
                        label5.Text = cantidad.ToString();
                        totalReal = totalReal + total;
                        label8.Text = totalReal.ToString();
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
            double cambio;

            if (e.KeyValue == (char)Keys.F7)
            {
                if (txtPago.Text == "")
                {
                    MessageBox.Show("ingresa un valor");
                }
                else
                {
                    double pago = double.Parse(txtPago.Text);
                    if (pago < totalReal)
                    {
                        MessageBox.Show("importe incorrecto");
                    }
                    else
                    {
                        cambio = pago - totalReal;
                        label6.Text = "$" + cambio.ToString();

                        int tamaño = listView1.Items.Count;
                        DAOVentas datos = new DAOVentas();
                        VentasPojos pojos = new VentasPojos();
                        pojos.folio = Int32.Parse(label12.Text);
                        pojos.usuario = textBox3.Text;
                        pojos.fecha = label14.Text + " " + label15.Text;
                        pojos.cantidad = Int32.Parse(label5.Text);
                        pojos.total = double.Parse(label8.Text);

                        datos.insertar(pojos);
                        for (int i = 0; i < tamaño; i++)
                        {
                            if (listView1.Items[i].SubItems[0].Text != "")
                            {
                                pojos.codigo = listView1.Items[i].SubItems[0].Text;
                                pojos.cantidad = Int32.Parse(listView1.Items[i].SubItems[2].Text);
                                datos.modificarProducto(ref pojos);

                                try
                                {
                                    pojos.folio = Int32.Parse(label12.Text);
                                    pojos.codigo = listView1.Items[i].SubItems[0].Text;
                                    pojos.producto = listView1.Items[i].SubItems[1].Text;
                                    pojos.cantidad = Int32.Parse(listView1.Items[i].SubItems[2].Text);
                                    pojos.precio_venta_menudeo = Int32.Parse(listView1.Items[i].SubItems[3].Text);
                                    pojos.total = Int32.Parse(listView1.Items[i].SubItems[4].Text);
                                    datos.insertarDetalle(pojos);
                                }
                                catch (Exception)
                                {
                                    pojos.folio = Int32.Parse(label12.Text);
                                    pojos.codigo = listView1.Items[i].SubItems[0].Text;
                                    pojos.cantidad = Int32.Parse(listView1.Items[i].SubItems[2].Text);
                                    pojos.total = Int32.Parse(listView1.Items[i].SubItems[4].Text);
                                    datos.modificar(ref pojos);
                                }

                            }
                        }

                        MessageBox.Show("venta realizada");
                        folio++;
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
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tamaño = listView1.Items.Count;
            cantidad = 0;
            totalReal = 0;

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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

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

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Tab)
            {
                textBox4.Focus();
            }
        }

        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Tab)
            {
                textBox5.Focus();
            }
        }

        private void textBox5_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Tab)
            {
                textBox6.Focus();
            }
        }

        private void textBox6_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Tab)
            {
                textBox2.Focus();
            }
        }


    }
}
