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
    public partial class frmOrdenes : Form
    {
        public frmOrdenes()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
           /// <summary>
           /// Metodo de evento Enter; presionando la tecla enter entra 
           /// si la caja de texto esta vacia, muestra le mensaje de "Debe de ingresar un valor"
           /// </summary>
           /// <param name="sender"></param>
           /// <param name="e"></param>

        private void txtBus_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                if (txtBus.Text.Length == 0)
                {
                    MessageBox.Show("Debe ingresar un valor", "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // Debe de cumplir el nuero de caracteres a ingresar
                else if (txtBus.Text.Length <= 10)
                {
                    clsDatosOrdenes con = new clsDatosOrdenes();

                    //Si la condicon se cumple cuando no se encuentra el dato muestra mensaje "El producto no existe" y muestra los datos
                    if (con.buscar(txtBus.Text) == null)
                    {
                        dgvOrden.DataSource = con.buscar(txtBus.Text);
                        txtBus.Text = "";
                        txtBus.Focus();
                        MessageBox.Show("La orden no existe");
                        ver();
                    }
                    // si el dato existe en a base de datos muestra le dato
                    else
                    {
                        dgvOrden.DataSource = con.buscar(txtBus.Text);
                        txtBus.Text = "";
                        txtBus.Focus();
                    }
                }
                // Tiene un limite de caracteres a ingresar si el numero es mayor a 10 muestra el mensaje
                else if (txtBus.Text.Length > 10)
                {
                    MessageBox.Show("El valor ingresado debe ser menor a 10 digitos");
                    txtBus.Text = "";
                    txtBus.Focus();
                }
            }
        }


        /// <summary>
        /// Validacion para que solo permita datos numericos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsNumber(e.KeyChar) == false) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false; e.Handled = false;
            }
        }

        public void ver() //metodo que muestra los datos en el datagridview
        {
            clsDatosOrdenes orden = new clsDatosOrdenes();
            dgvOrden.DataSource = orden.getOrdenes();
        }

        private void txtBus_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
