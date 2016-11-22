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
    public partial class frmAgregarCompras : Form
    {
        /// <summary>
        /// INICIA EL FORMULARIO Y RECIBE PROPIEDADES NECESARIAS PARA TRABAJAR ENTRE FORMULARIOS.
        /// </summary>
        /// <param name="Propiedades"></param> // TRAE LAS PROPIEDADES DEL LISTVIEW DEL FORMULARIO frmCompras.
        /// <param name="ItemSeleccionado"></param> // TRAE LAS PROPIEDADES DEL ITEM CON EL QUE VAMOS A TRABAJAR.
        /// <param name="Articulos"></param> // CONTIENE LAS PROPIEDADES DEL lblArticulos.
        /// <param name="Total"></param> // CONTIENE LAS PROPIEDADES DEL txtTotal.
        public frmAgregarCompras(ListView Propiedades, ListViewItem ItemSeleccionado, Label Articulos, Label Total)
        {
            InitializeComponent();
            propiedades = Propiedades;              // PASAMOS LAS PROPIEDADES A LA VARIABLE DEL MISMO TIPO QUE EL DEL OTRO FORMULARIO.
            itemseleccionado = ItemSeleccionado;    // PASAMOS LAS PROPIEDADES A LA VARIABLE DEL MISMO TIPO QUE EL DEL OTRO FORMULARIO.
            articulos = Articulos;                  // PASAMOS LAS PROPIEDADES A LA VARIABLE DEL MISMO TIPO QUE EL DEL OTRO FORMULARIO.
            total = Total;                          // PASAMOS LAS PROPIEDADES A LA VARIABLE DEL MISMO TIPO QUE EL DEL OTRO FORMULARIO.
        }

        # region "VARIBLES GLOBALES"

        ListView propiedades;               // VARIABLE DE TIPO LISTVIEW PARA MODIFICAR LAS PROPIEDADES
        ListViewItem itemseleccionado;      // VARIABLE DE TIPO LISTVIEWITEM PARA MODIFICAR LAS PROPIEDADES
        Label articulos;                    // VARIABLE DE TIPO LABEL PARA MODIFICAR LAS PROPIEDADES
        Label total;                        // VARIABLE DE TIPO LABEL PARA MODIFICAR LAS PROPIEDADES

        #endregion

        /// <summary>
        /// ACCIONES QUE SE REALIZARAN AL CARGAR EL FORMULARIO POR PRIMERA VEZ.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAgregarCompras_Load(object sender, EventArgs e)
        {
            lblCodigo.Text = propiedades.Items[itemseleccionado.Index].SubItems[0].ToString();
            lblNombre.Text = propiedades.Items[itemseleccionado.Index].SubItems[0].ToString();
            lblPrecio.Text = "$ " + propiedades.Items[itemseleccionado.Index].SubItems[0].ToString();

            txtCantidad.Focus();
        }

        /// <summary>
        /// EVENTO QUE SE DESENCADENARA AL MOMENTO DE PRECIONAR ENTER EN LA CAJA DE TEXTO.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                if (((int)e.KeyChar == (int)Keys.Enter))
                {
                    if (txtCantidad.Text != null && txtCantidad.Text != "")
                    {
                        if (txtCantidad.Text == "1")
                        {
                            MessageBox.Show("La cantidad debe ser mayor a 1", "INVALIDO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtCantidad.Clear();
                            txtCantidad.ClearUndo();
                        }
                        else
                        {
                            propiedades.BeginUpdate();
                            propiedades.Items[itemseleccionado.Index].SubItems[2].Text = txtCantidad.Text;
                            propiedades.Items[itemseleccionado.Index].SubItems[4].Text = Convert.ToString(Convert.ToInt32(propiedades.Items[itemseleccionado.Index].SubItems[2].Text) * Convert.ToDouble(propiedades.Items[itemseleccionado.Index].SubItems[3].Text));
                            propiedades.EndUpdate();

                            articulos.Text = Convert.ToString(Convert.ToInt32(articulos.Text) + Convert.ToInt32(txtCantidad.Text) - Convert.ToInt32(propiedades.Items[itemseleccionado.Index].SubItems[2].Text));
                            total.Text = "$" + Convert.ToString(Convert.ToDouble(total.Text.Replace("$", "")) + (Convert.ToDouble(propiedades.Items[itemseleccionado.Index].SubItems[3].Text) * Convert.ToDouble(txtCantidad.Text)));

                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("El campo de cantidad esta vacio.", "INVALIDO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }                        

    }
}
