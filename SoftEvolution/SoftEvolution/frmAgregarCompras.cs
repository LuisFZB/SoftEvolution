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
        public frmAgregarCompras(ListView Propiedades, ListViewItem ItemSeleccionado, Label Articulos, Label Total, TextBox Codigo)
        {
            InitializeComponent();
            propiedades = Propiedades;              // PASAMOS LAS PROPIEDADES A LA VARIABLE DEL MISMO TIPO QUE EL DEL OTRO FORMULARIO.
            itemseleccionado = ItemSeleccionado;    // PASAMOS LAS PROPIEDADES A LA VARIABLE DEL MISMO TIPO QUE EL DEL OTRO FORMULARIO.
            articulos = Articulos;                  // PASAMOS LAS PROPIEDADES A LA VARIABLE DEL MISMO TIPO QUE EL DEL OTRO FORMULARIO.
            total = Total;                          // PASAMOS LAS PROPIEDADES A LA VARIABLE DEL MISMO TIPO QUE EL DEL OTRO FORMULARIO.
            codigo = Codigo;
        }

        # region "VARIBLES GLOBALES"

        ListView propiedades;               // VARIABLE DE TIPO LISTVIEW PARA MODIFICAR LAS PROPIEDADES
        ListViewItem itemseleccionado;      // VARIABLE DE TIPO LISTVIEWITEM PARA MODIFICAR LAS PROPIEDADES
        Label articulos;                    // VARIABLE DE TIPO LABEL PARA MODIFICAR LAS PROPIEDADES
        Label total;                        // VARIABLE DE TIPO LABEL PARA MODIFICAR LAS PROPIEDADES
        TextBox codigo;

        #endregion

        /// <summary>
        /// ACCIONES QUE SE REALIZARAN AL CARGAR EL FORMULARIO POR PRIMERA VEZ.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
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
                            articulos.Text = Convert.ToString(Convert.ToInt32(articulos.Text) + Convert.ToInt32(txtCantidad.Text) - Convert.ToInt32(propiedades.Items[itemseleccionado.Index].SubItems[2].Text));
                            total.Text = "$" + Convert.ToString(Convert.ToDouble(total.Text.Replace("$", "")) - Convert.ToDouble(propiedades.Items[itemseleccionado.Index].SubItems[4].Text) + (Convert.ToDouble(propiedades.Items[itemseleccionado.Index].SubItems[3].Text) * Convert.ToDouble(txtCantidad.Text)));

                            propiedades.BeginUpdate();
                            propiedades.Items[itemseleccionado.Index].SubItems[2].Text = txtCantidad.Text;
                            propiedades.Items[itemseleccionado.Index].SubItems[4].Text = Convert.ToString(Convert.ToInt32(propiedades.Items[itemseleccionado.Index].SubItems[2].Text) * Convert.ToDouble(propiedades.Items[itemseleccionado.Index].SubItems[3].Text));
                            propiedades.EndUpdate();

                            codigo.ReadOnly = false;
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

        private void txtCantidad_KeyUp(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.C))
            {
                codigo.ReadOnly = false;
                this.Close();
            }
        }

        private void frmAgregarCompras_Load(object sender, EventArgs e)
        {
            txtCantidad.Focus();

            lblCodigo.Text = propiedades.Items[itemseleccionado.Index].SubItems[0].Text;
            lblNombre.Text = propiedades.Items[itemseleccionado.Index].SubItems[1].Text;
            lblPrecio.Text = "$ " + propiedades.Items[itemseleccionado.Index].SubItems[3].Text;

            txtCantidad.Focus();
        }
    }
}
