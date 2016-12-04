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
    public partial class frmVentas : Form
    {
        public frmVentas(ToolStripLabel Usuario, ToolStripMenuItem Guardar)
        {
            InitializeComponent();
            usuario = Usuario;
            guardar = Guardar;
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            txtCodigo.Focus();
            ValoresIniciales();
            NuevaCompra();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (consulta.ProductoRegistrado(txtCodigo.Text))
                {
                    LlenarListView();
                    txtCodigo.Clear();
                    txtCodigo.ClearUndo();

                    guardar.Enabled = true;
                }
                else
                {
                    MessageBox.Show("PRODUCTO NUEVO.\nEl articulo no esta registrado en los productos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.A))
            {
                if (lstProductos.Items.Count > 0)
                {
                    ItemProducto = lstProductos.FindItemWithText(UltimoCodigo, false, 0);

                    AgregarCantidad = new frmAgregarCompras(lstProductos, ItemProducto, lblArticulos, lblTotal, txtCodigo);
                    AgregarCantidad.Show();
                    txtCodigo.ReadOnly = true;
                }
                else
                {
                    MessageBox.Show("No se ha agregado ningun producto.", "INVALIDO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.E))
            {
                if (lstProductos.Items.Count > 0)
                {
                    RemoverCantidad = new frmRemoverCompras(lstProductos, ItemProducto, lblArticulos, lblTotal, txtCodigo);
                    RemoverCantidad.Show();
                    txtCodigo.ReadOnly = true;
                }
                else
                {
                    MessageBox.Show("No se ha agregado ningun producto.", "INVALIDO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime fecha = new DateTime();
            fecha = DateTime.Now;
            lblFecha.Text = Convert.ToString(fecha.ToString("yyyy/MM/dd H:mm:ss"));
        }

        # region "VARIABLES PARA EL FORMULARIO"

        string[] DetallesProducto;                              // ARREGLO QUE CONTIENE LOS DATOS DEL PRODUCTO QUE SE DESEA COMPRAR.
        string[] DetallesUsuario;                               // ARREGLO QUE CONTIENE LOS DATOS DEL USUARIO QUE SE HA LOGEADO.
        ToolStripLabel usuario;                                 // VARIBLE QUE CONTIENE LAS PROPIEDADES DEL TOOLSTRIPLABEL DEL USUARIO.
        ToolStripMenuItem guardar;
        string user;                                            //
        string UltimoCodigo;                                    // VARIABLE QUE GUARDA EL CODIGO DEL ULTIMO PRODUCTO QUE SE AGREGO AL LISTVIEW.
        ListViewItem ItemProducto = null;                       // VARIABLE DE TIPO ITEM PARA MANEJO DE LOS DATOS EN EL LISTVIEW.
        bool bandera = true;
        int CantidadVender;

        CONSULTAS consulta = new CONSULTAS();                   // INSTANCIA QUE MEPERMITE LLEGAR A LOS METODOS DE DICHA CLASS.
        frmAgregarCompras AgregarCantidad;                      // INSTANCIA PARA MOSTRAR Y MANDAR VALORES AL FORMULARIO DE AGRECAR COMPRAS.
        frmRemoverCompras RemoverCantidad;                      // INSTANCIA PARA MOSTRAR Y MANDAR VALORES AL FORMULARIO DE REMOVER COMPRAS.
        frmPrincipal principal = new frmPrincipal();

        double cambio;
        //variable para el almacenamiento del folio maximo en la base de datos
        int folio = 0;
        // variable para almacenar la cantidad de productos en la venta
        double cantidad = 0;
        // variable para almacenar la suma total de las cantidades de productos
        double totalReal = 0;
        // variable para almacenar la suma de los productos insertados en la busqueda del poducto
        double total = 0;
        int ext = 0;
        //objetos de las clases pojos y datos
        CONSULTAS datos = new CONSULTAS();
        clsVentas getCodigo = new clsVentas();
        # endregion


        #region "METODOS PARA LIMPIEZA"

        private void LlenarListView()
        {
            CantidadVender = 1;
            if (lstProductos.Items.Count > 0)
            {
                ItemProducto = lstProductos.FindItemWithText(txtCodigo.Text, false, 0);
            }
            else
            {
                ItemProducto = lstProductos.FindItemWithText(txtCodigo.Text);
            }

            if (ItemProducto != null)
            {
                CantidadVender = Convert.ToInt32(lstProductos.Items[ItemProducto.Index].SubItems[2].Text);
            }
            

            if(consulta.RevisarExistencias(txtCodigo.Text) >= CantidadVender){
                
                if (ItemProducto != null)
                {
                    lstProductos.BeginUpdate();
                    lstProductos.Items[ItemProducto.Index].SubItems[2].Text = Convert.ToString(Convert.ToInt32(lstProductos.Items[ItemProducto.Index].SubItems[2].Text) + Convert.ToInt32(txtCantidad.Text));
                    lstProductos.Items[ItemProducto.Index].SubItems[4].Text = Convert.ToString(Convert.ToInt32(lstProductos.Items[ItemProducto.Index].SubItems[2].Text) * Convert.ToDouble(lstProductos.Items[ItemProducto.Index].SubItems[3].Text));
                    lstProductos.EndUpdate();

                    lblTotal.Text = "$" + Convert.ToString(Convert.ToDouble(lblTotal.Text.Replace("$", "")) + (Convert.ToDouble(lstProductos.Items[ItemProducto.Index].SubItems[3].Text) * Convert.ToDouble(txtCantidad.Text)));
                }
                else
                {
                    DetallesProducto = consulta.Articulo(txtCodigo.Text);

                    ListViewItem item = new ListViewItem(txtCodigo.Text);

                    item.SubItems.Add(DetallesProducto[1]);
                    item.SubItems.Add(txtCantidad.Text);
                    item.SubItems.Add(DetallesProducto[2]);
                    item.SubItems.Add(Convert.ToString(Convert.ToInt32(txtCantidad.Text) * Convert.ToDouble(DetallesProducto[2])));
                    lstProductos.Items.Add(item);

                    lblTotal.Text = "$" + Convert.ToString(Convert.ToDouble(lblTotal.Text.Replace("$", "")) + (Convert.ToDouble(DetallesProducto[2]) * Convert.ToDouble(txtCantidad.Text)));// CAMBIAR
                }

                lblArticulos.Text = Convert.ToString(Convert.ToInt32(lblArticulos.Text) + Convert.ToInt32(txtCantidad.Text));
                UltimoCodigo = txtCodigo.Text;
            }
            else
            {
                MessageBox.Show("Cantidad en bodega insuficiente", "Insuficiencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ValoresIniciales()
        {
            txtCodigo.Focus();

            if (consulta.UltimoFolio() == -1)
            {
                lblFolio.Text = "1";
            }
            else
            {
                lblFolio.Text = Convert.ToString(consulta.UltimoFolio() + 1);
            }

            for (int i = lblFolio.Text.Length; i < 8; i++)
            {
                lblFolio.Text = "0" + lblFolio.Text;
            }

            user = usuario.Text;
            user = user.Replace("Usuario: ", "");

            DetallesUsuario = consulta.DatosUsuario(user);
            txtPuesto.Text = DetallesUsuario[0];
            txtNombre.Text = DetallesUsuario[1];
            txtApellido.Text = DetallesUsuario[2];

            txtCodigo.Clear();
            txtCodigo.ClearUndo();

            txtCantidad.Text = "1";
        }

        public void NuevaCompra()
        {
            lblFolio.Text = Convert.ToString(consulta.UltimoFolio2() + 1);
            lstProductos.Items.Clear();

            lblArticulos.Text = "0";
            lblTotal.Text = "$0.00";
        }

        public void InsertarVenta()
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
                        lblCambio.Text = "$" + cambio.ToString();
                        //tamaño de la lista
                        int tamaño = lstProductos.Items.Count;
                        CONSULTAS datos = new CONSULTAS();
                        clsVentas pojos = new clsVentas();
                        //llena los datos para insertarlos a la tabla de ventas
                        pojos.folio = Int32.Parse(lblFolio.Text);
                        pojos.usuario = usuario.Text;
                        pojos.fecha = lblFecha.Text;
                        pojos.cantidad = Int32.Parse(lblArticulos.Text);
                        pojos.total = Convert.ToDouble(lblTotal.Text.Replace("$", ""));
                        //pasa los datos para llenar la tabla ventas
                        datos.insertar(pojos);
                        //recorre el listview para hacer la disminucion de existencias en la base de datos
                        for (int i = 0; i < tamaño; i++)
                        {
                            if (lstProductos.Items[i].SubItems[0].Text != "")
                            {
                                pojos.codigo = lstProductos.Items[i].SubItems[0].Text;
                                pojos.cantidad = Int32.Parse(lstProductos.Items[i].SubItems[2].Text);
                                datos.modificarProducto(ref pojos);

                                try
                                {
                                    //recorre el listview para hacer el llenado de la tabla detalles de venta
                                    pojos.folio = Int32.Parse(lblFolio.Text);
                                    pojos.codigo = lstProductos.Items[i].SubItems[0].Text;
                                    pojos.producto = lstProductos.Items[i].SubItems[1].Text;
                                    pojos.cantidad = Int32.Parse(lstProductos.Items[i].SubItems[2].Text);
                                    pojos.precio_venta_menudeo = Int32.Parse(lstProductos.Items[i].SubItems[3].Text);
                                    pojos.total = Int32.Parse(lstProductos.Items[i].SubItems[4].Text);
                                    datos.insertarDetalle(pojos);
                                }
                                //TRY CATCH cuando encuentra llaves duplicadas 
                                catch (Exception)
                                {
                                    // modifica el valor de cantidad y subtotal cuando encuentra llaves compuestas iguales
                                    pojos.folio = Int32.Parse(lblFolio.Text);
                                    pojos.codigo = lstProductos.Items[i].SubItems[0].Text;
                                    pojos.cantidad = Int32.Parse(lstProductos.Items[i].SubItems[2].Text);
                                    pojos.total = double.Parse(lstProductos.Items[i].SubItems[4].Text);
                                    datos.modificar(ref pojos);
                                }

                            }
                        }

                        MessageBox.Show("venta realizada");
                        //incrementa el valor del folio
                        folio++;
                        //limpia todo para una nueva venta
                        lblFolio.Text = folio.ToString();
                        lstProductos.Items.Clear();
                        lblArticulos.Text = "0";
                        lblTotal.Text = "$0.00";
                        txtPago.Clear();
                        lblCambio.Text = "$0.00";
                        cmbDescuento.Text = "";
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
         
        #endregion

        private void cmbDescuento_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tamaño = lstProductos.Items.Count;
            cantidad = 0;
            totalReal = 0;
            // hace la modificacion del precio buscando por precio de entrenador cuando se selecciona en el combobox
            if (cmbDescuento.Text == "Entrenador")
            {
                for (int i = 0; i < tamaño; i++)
                {
                    if (lstProductos.Items[i].SubItems[0].Text != "")
                    {
                        getCodigo = datos.PrecioEntrenador(lstProductos.Items[i].SubItems[0].Text);

                        if (getCodigo != null)
                        {
                            total = 0;
                            total = getCodigo.precio_venta_menudeo * double.Parse(lstProductos.Items[i].SubItems[2].Text);
                            ListViewItem lista = new ListViewItem(getCodigo.codigo);

                            lista.SubItems.Add(getCodigo.producto);
                            lista.SubItems.Add(lstProductos.Items[i].SubItems[2].Text);
                            lista.SubItems.Add(getCodigo.precio_venta_menudeo.ToString());
                            lista.SubItems.Add(total.ToString());

                            lstProductos.Items.Add(lista);



                            totalReal = totalReal + total;
                            lblTotal.Text = totalReal.ToString();

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
                    lstProductos.Items.RemoveAt(0);
                }

            }
            //hace la modificacion del precio buscando por precio de mayoreo cuando se selecciona en el combobox
            if (cmbDescuento.Text == "Mayoreo")
            {
                for (int i = 0; i < tamaño; i++)
                {
                    if (lstProductos.Items[i].SubItems[0].Text != "")
                    {
                        getCodigo = datos.PrecioMayoreo(lstProductos.Items[i].SubItems[0].Text);

                        if (getCodigo != null)
                        {
                            total = 0;
                            total = getCodigo.precio_venta_menudeo * double.Parse(lstProductos.Items[i].SubItems[2].Text);
                            ListViewItem lista = new ListViewItem(getCodigo.codigo);

                            lista.SubItems.Add(getCodigo.producto);
                            lista.SubItems.Add(lstProductos.Items[i].SubItems[2].Text);
                            lista.SubItems.Add(getCodigo.precio_venta_menudeo.ToString());
                            lista.SubItems.Add(total.ToString());

                            lstProductos.Items.Add(lista);



                            totalReal = totalReal + total;
                            lblTotal.Text = totalReal.ToString();
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
                    lstProductos.Items.RemoveAt(0);
                }

            }
            //hace la modificacion del precio buscando por precio de menudeo cuando se selecciona en el combobox
            if (cmbDescuento.Text == "Menudeo")
            {
                for (int i = 0; i < tamaño; i++)
                {
                    if (lstProductos.Items[i].SubItems[0].Text != "")
                    {
                        getCodigo = datos.getProductById(lstProductos.Items[i].SubItems[0].Text);

                        if (getCodigo != null)
                        {
                            total = 0;
                            total = getCodigo.precio_venta_menudeo * double.Parse(lstProductos.Items[i].SubItems[2].Text);
                            ListViewItem lista = new ListViewItem(getCodigo.codigo);

                            lista.SubItems.Add(getCodigo.producto);
                            lista.SubItems.Add(lstProductos.Items[i].SubItems[2].Text);
                            lista.SubItems.Add(getCodigo.precio_venta_menudeo.ToString());
                            lista.SubItems.Add(total.ToString());

                            lstProductos.Items.Add(lista);



                            totalReal = totalReal + total;
                            lblTotal.Text = totalReal.ToString();
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
                    lstProductos.Items.RemoveAt(0);
                }


            }
        }

        private void txtPago_KeyPress(object sender, KeyPressEventArgs e)
        {
           if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back)){
                e.Handled = true;
                if ((int)e.KeyChar == (int)Keys.Enter)
                {
                    if (Convert.ToDouble(txtPago.Text) >= Convert.ToDouble(lblTotal.Text.Replace("$", "")))
                    {
                        InsertarVenta();
                        NuevaCompra();
                    }
                    else
                    {
                        MessageBox.Show("Efectivo insuficiente.");
                    }
                    
                }
            }
        }
    }
}
