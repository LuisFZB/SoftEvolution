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
    public partial class frmCompras : Form
    {
        public frmCompras(ToolStripLabel Usuario)
        {
            InitializeComponent();
            usuario = Usuario;
        }

        # region "VARIABLES PARA EL FORMULARIO"

        string[] DetallesProducto;                              // ARREGLO QUE CONTIENE LOS DATOS DEL PRODUCTO QUE SE DESEA COMPRAR.
        string[] DetallesUsuario;                               // ARREGLO QUE CONTIENE LOS DATOS DEL USUARIO QUE SE HA LOGEADO.
        ToolStripLabel usuario;                                 // VARIBLE QUE CONTIENE LAS PROPIEDADES DEL TOOLSTRIPLABEL DEL USUARIO.
        string user;                                            //
        string UltimoCodigo;                                    // VARIABLE QUE GUARDA EL CODIGO DEL ULTIMO PRODUCTO QUE SE AGREGO AL LISTVIEW.
        ListViewItem ItemProducto = null;                       // VARIABLE DE TIPO ITEM PARA MANEJO DE LOS DATOS EN EL LISTVIEW.

        CONSULTAS consulta = new CONSULTAS();                   // INSTANCIA QUE MEPERMITE LLEGAR A LOS METODOS DE DICHA CLASS.
        frmAgregarCompras AgregarCantidad;                      //INSTANCIA PARA MOSTRAR Y MANDAR VALORES AL FORMULARIO DE AGRECAR COMPRAS.

        # endregion

        /// <summary>
        /// EVENTO QUE SE DISPARARA AL MOMENTO EN EL QUE SE PRECIONA LA TECLA ENTER EN EL CODIGO DEL PRODUCTO.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (consulta.ProductoRegistrado(txtCodigo.Text))
                {
                    LlenarListView();
                    ValoresIniciales();
                }
                else
                {
                    MessageBox.Show("PRODUCTO NUEVO.\nEl articulo no esta registrado en los productos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult eleccion = MessageBox.Show("¿Desea agregar el producto?", "OPCION", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (eleccion == DialogResult.Yes)
                    {
                        MessageBox.Show("MANDAR LLAMAR EL FORMULARIO PARA UN NUEVO PRODUCTO");
                    }
                    else if (eleccion == DialogResult.No)
                    {
                        ValoresIniciales();
                    }
                }
            }
        }

        /// <summary>
        /// METODO QUE RECOLECTA LOS VALORES DEL PRODUCTO SI ES QUE ESTA REGISTRADO Y LLENA LISTVIEW CON LOS DATOS RECOLECTADOS.
        /// ADEMAS, HACE LOS CALCULOS NECESARIOS PARA SACAR LA CANTIDAD DE ARTICULOS Y EL TOTAL DE LA COMPRA.   
        /// </summary>
        private void LlenarListView()
        {
            if (lstProductos.Items.Count > 0)
            {
                ItemProducto = lstProductos.FindItemWithText(txtCodigo.Text, false, 0);
            }

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

        /// <summary>
        /// METODO QUE REGRESA LAS CAJAS DE TEXTO A LOS VALORES INICIALES.
        /// </summary>
        private void ValoresIniciales()
        {
            lblFolio.Text = Convert.ToString(consulta.UltimoFolio() + 1);
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

        /// <summary>
        /// METODO QUE LIMPIA TODO EL FORMULARIO PARA INICIARR UNA NUEVA COMPRA.
        /// </summary>
        private void NuevaCompra()
        {
            lblFolio.Text = Convert.ToString(consulta.UltimoFolio());
            lstProductos.Items.Clear();

            lblArticulos.Text = "0";
            lblTotal.Text = "$0.00";
        }

        /// <summary>
        /// MUESTRA LA HORA Y FECHA EN EL FORMULARIO.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime fecha = new DateTime();
            fecha = DateTime.Now;
            lblFecha.Text = Convert.ToString(fecha.ToString("yyyy/MM/dd H:mm:ss"));
        }

        /// <summary>
        /// INICIA EL FORMULARIO EN UN ESTADO LIMPIPO, LISTO PARA REALIZAR UNA COMPRA NUEVA.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCompras_Load(object sender, EventArgs e)
        {
            ValoresIniciales();
        }

        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.A))
            {
                if (lstProductos.Items.Count > 0)
                {
                    ItemProducto = lstProductos.FindItemWithText(UltimoCodigo, false, 0);

                    //frmAgregarCompras AgregarCantidad = new frmAgregarCompras(lstProductos.Items[ItemProducto.Index].SubItems[0].ToString(), lstProductos.Items[ItemProducto.Index].SubItems[1].ToString(), lstProductos.Items[ItemProducto.Index].SubItems[3].ToString(), lstProductos.Items[ItemProducto.Index].SubItems[2].ToString());
                    AgregarCantidad = new frmAgregarCompras(lstProductos, ItemProducto, lblArticulos, lblTotal);
                    AgregarCantidad.Show();
                }
                else
                {
                    MessageBox.Show("No se ha agregado ningun producto.", "INVALIDO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
