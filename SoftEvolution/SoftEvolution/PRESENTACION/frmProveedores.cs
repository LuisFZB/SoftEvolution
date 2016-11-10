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
    public partial class frmProveedores : Form
    {
        public frmProveedores()
        {
            InitializeComponent();
        }

        private void tlsAgregar_Click(object sender, EventArgs e)
        {
            frmAgregar agregar = new frmAgregar();
            agregar.Show();
            this.Dispose();
        }

        private void tlsModificar_Click(object sender, EventArgs e)
        {
            clsProveedores Proveedor = new clsProveedores();
            Conexion con = new Conexion();
            try
            {
                //Proveedor.accion = true;
                
                Proveedor.Codigo = Convert.ToInt32(this.dgvProveedores.CurrentRow.Cells[0].Value.ToString());

                con.getProveedor();
                con.buscarProveedor(ref Proveedor);
                frmModificar x = new frmModificar();
                //x.label2.Text = "True";
                x.txtCodigo.Text = Proveedor.Codigo.ToString();
                x.txtEmpresa.Text = Proveedor.NombreEmpresa;
                x.txtTelefono.Text = Proveedor.TelefonoEmpresa;
                x.txtEmail.Text = Proveedor.EmailEmpresa;
                x.txtContacto.Text = Proveedor.NombreContacto;
                x.txtApellido.Text = Proveedor.ApellidoContacto;
                x.txtObservaciones.Text = Proveedor.Observaciones;
                x.Show();
                this.Dispose();
            }
            catch (Exception)
            {
                MessageBox.Show("Seleciona un registro");
            }
        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            Conexion con = new Conexion();
            dgvProveedores.DataSource = con.getProveedor();
        }

        public void ver()
        {
            Conexion con = new Conexion();
            dgvProveedores.DataSource = con.getProveedor();
        }

        private void tlsSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void tlsEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                clsProveedores proveedor = new clsProveedores();
                Conexion con = new Conexion();
                proveedor.Codigo = Convert.ToInt32(dgvProveedores.Rows[dgvProveedores.SelectedRows[0].Index].Cells[0].Value.ToString());
                MessageBox.Show("¿Deseas eliminar este proveedor?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                con.eliminar(proveedor);
                ver();
                MessageBox.Show("Producto eliminado");
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Seleciona un registro");
            }
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyValue == (char)Keys.Enter)
            {
                Conexion con = new Conexion();
                dgvProveedores.DataSource = con.buscar(txtBuscar.Text);
                txtBuscar.Text = "";
                txtBuscar.Focus();
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((Char.IsNumber(e.KeyChar) == false) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void dgvProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /*private void Buscar(string Folio)
        {
            
        }*/
    }
}
