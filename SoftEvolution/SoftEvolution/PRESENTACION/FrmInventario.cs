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
    public partial class frmInventario : Form
    {
        public frmInventario()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void ver() //metodo que muestra los datos en el datagridview
        {
            clsDatosInventario produ = new clsDatosInventario(); 
            dgvInven.DataSource = produ.getOrdenes(); 
        }

        /// <summary>
        /// Validacion para que solo permita datos numericos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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
        /// <summary>
        /// Metodo de evento Enter; presionando la tecla enter entra 
        /// si la caja de texto esta vacia, muestra le mensaje de "Debe de ingresar un valor"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
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
                    clsDatosInventario con = new clsDatosInventario();

                    //Si la condicon se cumple cuando no se encuentra el dato muestra mensaje "El producto no existe" y muestra los datos
                    if (con.buscar(txtBus.Text) == null)
                    {
                        dgvInven.DataSource = con.buscar(txtBus.Text);
                        txtBus.Text = "";
                        txtBus.Focus();
                        MessageBox.Show("El producto no existe");
                        ver();
                    }
                    // si el dato existe en a base de datos muestra le dato
                    else 
                    {
                        dgvInven.DataSource = con.buscar(txtBus.Text);
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

        private void txtBus_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
