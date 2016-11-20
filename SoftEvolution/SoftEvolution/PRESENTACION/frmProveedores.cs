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

        #region "Eventos formulario"
        private void tlsAgregar_Click(object sender, EventArgs e)//menu de agregar
        {
            frmAgregarProveedor agregar = new frmAgregarProveedor();//objeto al formulario de agregar
            agregar.Show();//abre el formulario de agregar
            this.Dispose();//oculta este formulario
        }

        private void tlsModificar_Click(object sender, EventArgs e)//menu modificar
        {
            clsProveedores Proveedor = new clsProveedores();//objeto clsProveedores
            ConexionProveedor con = new ConexionProveedor();//objeto de conexion
            try //bloque try para que solo entre en caso de que se haya seleccionado un dato
            {
                //indica que tomara el id del dato seleccionado en el datagridview
                Proveedor.Codigo = Convert.ToInt32(dgvProveedores.Rows[dgvProveedores.SelectedRows[0].Index].Cells[0].Value.ToString());
                //llama al metodo getProveedor para obtener los datos
                con.getProveedor();
                con.buscarProveedor(ref Proveedor); //llama al metodo buscarProveedor para realizar la busqueda de ese dato
                frmModificarProveedor x = new frmModificarProveedor();//objeto del formulario modificar
                //pasamos los datos de la clase clsProveedores y los mostramos en los cuadros de texto del otro formulario
                x.txtCodigo.Text = Proveedor.Codigo.ToString();
                x.txtEmpresa.Text = Proveedor.NombreEmpresa;
                x.txtTelefono.Text = Proveedor.TelefonoEmpresa;
                x.txtEmail.Text = Proveedor.EmailEmpresa;
                x.txtContacto.Text = Proveedor.NombreContacto;
                x.txtApellido.Text = Proveedor.ApellidoContacto;
                x.txtObservaciones.Text = Proveedor.Observaciones;
                x.Show();//abrimos el formulario de modificar
                this.Dispose();//ocultamos este formulario
            }
            catch (Exception) //entra e caso de que no se haya seleccionado ningun dato y manda mensaje
            {
                MessageBox.Show("Seleciona un registro");
            }
        }

        private void frmProveedores_Load(object sender, EventArgs e)//evento del formulario
        {
            ConexionProveedor con = new ConexionProveedor();//objeto de la clase conexion
            dgvProveedores.DataSource = con.getProveedor();//muestra los datos de la base de datos en el datagridview
            //Código para adaptar el datagridview al tamaño de la ventana
            dgvProveedores.Left = this.Left + 25;
            dgvProveedores.Height = this.Height - dgvProveedores.Top - 100;
            dgvProveedores.Width = this.Width - 50;
        }

        

        private void tlsSalir_Click(object sender, EventArgs e)//menu salir
        {
            this.Close(); //cierra este formulario

        }

        private void tlsEliminar_Click(object sender, EventArgs e)//menu de eliminar
        {
            try //entra en caso de que haya seleccionado un dato
            {
                clsProveedores proveedor = new clsProveedores();//objeto de la clase clsProveedores
                ConexionProveedor con = new ConexionProveedor();//objeto de la clase ConexionProveedor
                //le indicamos que el dato que seleccione, solo tome el id y haga la conversion a entero
                proveedor.Codigo = Convert.ToInt32(dgvProveedores.Rows[dgvProveedores.SelectedRows[0].Index].Cells[0].Value.ToString());
                //mensaje de confirmacion
                DialogResult dialog = MessageBox.Show("¿Deseas eliminar este proveedor?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dialog == DialogResult.Yes) //entra si el usuario elige eliminar el proveedor
                {
                    con.eliminar(proveedor);//elimina el dato seleccionado
                    ver();//llamado al metodo ver para cargar los datos actualizados
                    MessageBox.Show("Proveedor eliminado"); //mensaje 
                }
                else if (dialog == DialogResult.No) //en caso de que el usuario no quiera eliminarlo muestra mensaje
                {
                    MessageBox.Show("Proveedor no eliminado");
                }
            }
            catch (ArgumentOutOfRangeException)//entra en caso de que no se haya seleccionado ningun dato y muestra mensaje
            {
                MessageBox.Show("Seleciona un registro");
            }
        }

        private void tlsMostrar_Click(object sender, EventArgs e)//menu para mostrar los datos
        {
            ver();//llamado al metodo ver
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)// evento de buscar con tecla enter
        {
            if (e.KeyValue == (char)Keys.Enter) //si presiona la tecla enter entra
            {
                if (txtBuscar.Text.Length == 0) //si el cuadr de texto esta vacío entra y muestra mensaje
                {
                    MessageBox.Show("Debe ingresar un valor", "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtBuscar.Text.Length <= 10) //conndicion que limita el numero de caracteres
                {
                    ConexionProveedor con = new ConexionProveedor();//objeto de la clase de conexion

                    if (con.buscar(txtBuscar.Text) == null)//entra en esta condicion solo si el dato no se encuentra
                    {
                        dgvProveedores.DataSource = con.buscar(txtBuscar.Text);//vacia el datagridview
                        txtBuscar.Text = "";//vacia el cuadro de texto
                        txtBuscar.Focus();//el cuadro de texto esta seleccionado para ingresar datos
                        MessageBox.Show("El proveedor no existe");//mensaje
                        ver();//llamado del metodo que muestra los datos
                    }
                    else //en caso de que el dato exista en la base de datos
                    {
                        dgvProveedores.DataSource = con.buscar(txtBuscar.Text);//muestra el dato buscado
                        txtBuscar.Text = "";//vacia el cuadro de texto
                        txtBuscar.Focus();//selecciona el cuadro de texto
                    }
                }
                else if (txtBuscar.Text.Length > 10) //si rebasa el limite de caracteres entra
                {
                    MessageBox.Show("El valor ingresado debe ser menor a 10 digitos");//muestra mensaje
                    txtBuscar.Text = "";//vacia el cuadro de texto
                    txtBuscar.Focus();//selecciona el cuadro de texto
                }
            }
        }
        #endregion

        #region "Metodos y validaciones"
        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)//evento para validacion de solo numeros
        {
            if ((Char.IsNumber(e.KeyChar) == false) && (e.KeyChar != (char)Keys.Back)) //si no es numerico
            {
                e.Handled = true; //bloquea datos no numericos
            }
            else //en caso de que si sea numerico
            {
                e.Handled = false; e.Handled = false; //permite el ingreso de datos numericos
            }
        }

        public void ver()//metodo que muestra los datos en el datagridview
        {
            ConexionProveedor con = new ConexionProveedor(); //objeto de la clase de conexion
            dgvProveedores.DataSource = con.getProveedor(); //muestra los datos en el datagridview
        }

        private void dgvProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        #endregion


        /*private void Buscar(string Folio)
        {
            
        }*/
    }
}
