﻿using System;
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
    public partial class frmRemoverCompras : Form
    {
        /// <summary>
        /// INICIA EL FORMULARIO Y RECIBE PROPIEDADES NECESARIAS PARA TRABAJAR ENTRE FORMULARIOS.
        /// </summary>
        /// <param name="Propiedades"></param> // TRAE LAS PROPIEDADES DEL LISTVIEW DEL FORMULARIO frmCompras.
        /// <param name="ItemSeleccionado"></param> // TRAE LAS PROPIEDADES DEL ITEM CON EL QUE VAMOS A TRABAJAR.
        /// <param name="Articulos"></param> // CONTIENE LAS PROPIEDADES DEL lblArticulos.
        /// <param name="Total"></param> // CONTIENE LAS PROPIEDADES DEL txtTotal.
        public frmRemoverCompras(ListView Propiedades, ListViewItem ItemSeleccionado, Label Articulos, Label Total, TextBox Codigo)
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

        public void AdaptarTamañoTotal()
        {
            rdbTotal.Checked = true;
            gpbCantidadBorrar.Visible = false;
            gpbProducto.Height = 174;
            this.Height = 294;
        }

        public void AdaptarTamañoParcial()
        {
            rdbParcial.Checked = true;
            gpbCantidadBorrar.Visible = true;
            gpbProducto.Height = 318;
            this.Height = 437;
        }

        private void frmRemoverCompras_Load(object sender, EventArgs e)
        {
            txtCantidad.Focus();
            AdaptarTamañoTotal();
        }

        private void rdbTotal_Click(object sender, EventArgs e)
        {
            AdaptarTamañoTotal();
        }

        private void rdbParcial_Click(object sender, EventArgs e)
        {
            AdaptarTamañoParcial();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar == (int)Keys.Enter))
            {
                if (rdbTotal.Checked == true)
                {
                    if (txtCodigo.Text != null && txtCodigo.Text != "")
                    {
                        itemseleccionado = propiedades.FindItemWithText(txtCodigo.Text, false, 0);

                        if (itemseleccionado == null)
                        {
                            MessageBox.Show("El Producto no esta registrado en la compra", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            articulos.Text = Convert.ToString(Convert.ToInt32(articulos.Text) - Convert.ToInt32(propiedades.Items[itemseleccionado.Index].SubItems[2].Text));
                            total.Text = "$" + Convert.ToString(Convert.ToDouble(total.Text.Replace("$", "")) - Convert.ToDouble(propiedades.Items[itemseleccionado.Index].SubItems[4].Text));

                            propiedades.BeginUpdate();
                            propiedades.Items[itemseleccionado.Index].SubItems[2].Text = "0";
                            propiedades.Items[itemseleccionado.Index].SubItems[4].Text = "0";
                            propiedades.EndUpdate();

                            codigo.ReadOnly = false;
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("El campo del codigo esta vacio.", "INVALIDO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                if (((int)e.KeyChar == (int)Keys.Enter))
                {
                    if (rdbParcial.Checked == true)
                    {
                        if (txtCodigo.Text != null && txtCodigo.Text != "")
                        {
                            itemseleccionado = propiedades.FindItemWithText(txtCodigo.Text, false, 0);

                            if (itemseleccionado == null)
                            {
                                MessageBox.Show("El Producto no esta registrado en la compra", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                if (Convert.ToInt32(propiedades.Items[itemseleccionado.Index].SubItems[2].Text) >= Convert.ToInt32(txtCantidad.Text))
                                {
                                    articulos.Text = Convert.ToString(Convert.ToInt32(articulos.Text) - Convert.ToInt32(txtCantidad.Text));
                                    total.Text = "$" + Convert.ToString(Convert.ToDouble(total.Text.Replace("$", "")) - Convert.ToDouble(propiedades.Items[itemseleccionado.Index].SubItems[3].Text) * Convert.ToInt32(txtCantidad.Text));

                                    propiedades.BeginUpdate();
                                    propiedades.Items[itemseleccionado.Index].SubItems[2].Text = Convert.ToString(Convert.ToInt32(propiedades.Items[itemseleccionado.Index].SubItems[2].Text) - Convert.ToInt32(txtCantidad.Text));
                                    propiedades.Items[itemseleccionado.Index].SubItems[4].Text = Convert.ToString(Convert.ToInt32(propiedades.Items[itemseleccionado.Index].SubItems[2].Text) * Convert.ToDouble(propiedades.Items[itemseleccionado.Index].SubItems[3].Text));
                                    propiedades.EndUpdate();

                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Cantidad en la compra insuficiente", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("El campo del codigo esta vacio.", "INVALIDO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.C))
            {
                codigo.ReadOnly = false;
                this.Close();
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
    }
}
