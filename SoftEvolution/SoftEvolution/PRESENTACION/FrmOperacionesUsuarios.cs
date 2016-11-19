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
   //La Clase Buscar
    public partial class FrmOperacionesUsuarios : Form
    {
        //Variable para eliminar usuario
        string campo_Eliminar;
        //Objeto para comunicarme con otra clase
        Form1 obj = new Form1();
        //Creo mi tabla
        DataGridViewRow dgv;
        //Constructor de mi clase Buscar
        public FrmOperacionesUsuarios()
        {
            InitializeComponent();
            //No deja minimizar una ventana
            MinimizeBox = false;
            //Creo un objeto de mi clase en la que estan os diferentes metodos de Cargar,Buscar,Modificar,Eliminar
            UsuariosDAL datos = new UsuariosDAL();
            //Cargo todos los datos en mi tabla una ves que se abre está ventana.
            dataGridView1.DataSource = datos.CargarDatos();
        }
       
      

        private void Buscar_Load(object sender, EventArgs e)
        {

        }

    

   
        //Una ves que se selecciona un renglon se pone el valor de la columna 1(Usuario/Clave) el la variable campo_Eliminar y se imprime un mensaje
        // del campo seleccionado o usuario seleccionado.
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
           
           dgv = dataGridView1.Rows[e.RowIndex];
            campo_Eliminar = dgv.Cells[1].Value.ToString();
           
            MessageBox.Show("Usuario Seleccionado: " + campo_Eliminar);

        }

      
        //Revisamos si el txtClave tiene texto, si hay texto mandamos llamar al metodo buscar de la clase UsuariosDAL y ponemos el resultado en 
        // el dataGridView1, si el campo esta vacio muestra un mensaje de no hay Usuario a buscar
        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtClave.Text.Length>0) {
                UsuariosDAL buscar = new UsuariosDAL();
                dataGridView1.DataSource = buscar.BuscarUsuario(txtClave.Text.Trim());
            }
            else
            {
                MessageBox.Show("No hay Ususario a buscar");
            }
            }

        //recibe un campo usuario_Eliminar de la tabla si la variable es mayor a cero o ya se a seleccionado algun campo usuario entrara y se
        // pedira la confirmación para eliminar ese usuario si acepta procede a eliminarce y dar a conocer su eliminación y actualización de la 
        // tabla de lo contrario muestra el mensaje no se ah seleccionado usuario a eliminar.
        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (campo_Eliminar.Length > 0)
                {
                    if (MessageBox.Show("Estas seguro de eliminar este registro ?", "Eliminar registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        UsuariosDAL eliminar = new UsuariosDAL();
                        eliminar.EliminarUsuario(campo_Eliminar);
                        MessageBox.Show("Registro eliminado");
                        eliminar.CargarDatos();
                    }

                }

            }
            catch (Exception)
            {
                MessageBox.Show("No has seleccionado el usuario a eliminar.");
            }
        }
        // Una ves que se selecciona el renglon se cargan los datos en la ventana 1, menos la clave, para guardar los cambios hay que desplegar moodificar y dar
        // en guardar o cancelar los cambios.
        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            try
            {
                obj.comboTipo.Text = dgv.Cells[0].Value.ToString();
                 obj.txtClave.Text = dgv.Cells[1].Value.ToString();
                obj.txtClave.Enabled=false;
                 obj.txtContrasena.Text = dgv.Cells[2].Value.ToString();
                obj.txtNombre.Text = dgv.Cells[3].Value.ToString();
                obj.txtApellidos.Text = dgv.Cells[4].Value.ToString();
                this.Hide();
                obj.Show();
                obj.yaseleccionoparaeliminar = 1;
            }
            catch
            {
                MessageBox.Show("No has seleccionado un usuario a Modificar");
            }
        }
        //Metodo que sirve para cargar todos los datos una ves que la caja de texto esta vacia, si hay texto no hace nada.
        private void txtClave_TextChanged(object sender, EventArgs e)
        {
            if (txtClave.Text.Length==0)
            {
                UsuariosDAL datos = new UsuariosDAL();
                dataGridView1.DataSource = datos.CargarDatos();
            }
        }
        //Metodo del boton CargrarDatos Usa un metodo de la Clase usuariosDAL que carga todos los datos en el DataGridView1. 
        private void cargarDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuariosDAL datos = new UsuariosDAL();
            dataGridView1.DataSource = datos.CargarDatos();
        }
        //Metodo del boton Regresar que esta en el FormBuscar;
        private void regresarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            a.Show();
            this.Hide();
        }
    }
}


