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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }



        #region "VARIABLES FORMULARIO"

        private bool inicioSistema = false;
        private string formularioCargado = "";
        private string accionRealizar = "";
        private string[] lstDatos;

        private CONSULTAS consultas = new CONSULTAS();

        private frmLogin login;
        private frmUsuarios usuarios;
        private frmReporteSemanal reporte;
        private frmProductos productos;
        private frmCorteCaja corte;
        private frmVentas ventas;
        private frmAgregarCompras agregarcompras;
        private frmCompras compras;
        private frmRemoverCompras removercompras;
        private frmProveedores proveedores;
        private frmOrdenes ordenes;
        private frmInventario inventario;

        private int cantidadUsuarios = 0;

        #endregion




        #region "METODOS ORDEN Y LIMPIEZA"

        private void Agregar(string Formulario)
        {
            accionRealizar = "Insert";

            switch (Formulario)
            {
                case "Ninguno":

                    break;

                case "Usuarios":
                    usuarios.Habilitar(accionRealizar);
                    break;

                case "Productos":
                    productos.Habilitar(accionRealizar);
                    break;

                case "Proveedores":
                    proveedores.Habilitar(accionRealizar);
                    break;

                case "Corte":

                    break;

                case "Ventas":

                    break;

                case "Compras":

                    break;

                case "Login":

                    break;

                case "Reporte":

                    break;
            }
        }

        private void Modificar(string Formulario)
        {
            accionRealizar = "Update";
            switch (Formulario)
            {
                case "Ninguno":

                    break;

                case "Usuarios":
                    usuarios.Habilitar(accionRealizar);
                    break;

                case "Productos":
                    productos.Habilitar(accionRealizar);
                    break;

                case "Proveedores":
                    proveedores.Habilitar(accionRealizar);
                    break;

                case "Login":

                    break;

                case "Reporte":

                    break;

                case "Corte":

                    break;

                case "Ventas":

                    break;

                case "compras":

                    break;
            }
        }

        private void Eliminar(string Formulario)
        {
            accionRealizar = "Delete";
            switch (Formulario)
            {
                case "Ninguno":

                    break;

                case "Usuarios":

                    break;

                case "Login":

                    break;

                case "Reporte":

                    break;

                case "Productos":

                    break;

                case "Corte":

                    break;

                case "Ventas":

                    break;

                case "compras":

                    break;

                case "Proveedores":

                    break;
            }
        }

        private void FinAccion(string Formulario)
        {
            accionRealizar = "";

            switch (Formulario)
            {
                case "Ninguno":

                    break;

                case "Usuarios":
                    usuarios.Deshabilitar();
                    usuarios.Limpiar();
                    break;

                case "Productos":
                    productos.Deshabilitar();
                    productos.Limpiar();
                    break;

                case "Proveedores":
                    proveedores.Deshabilitar();
                    proveedores.Limpiar();
                    break;

                case "Login":

                    break;

                case "Reporte":

                    break;

                case "Corte":

                    break;

                case "Ventas":

                    break;

                case "Compras":
                    compras.ValoresIniciales();
                    compras.NuevaCompra();
                    break;
            }
        }




        private void AccionRealizar(string Accion)
        {
            switch (Accion)
            {
                case "Insert":
                    Insert(formularioCargado);
                    break;

                case "Update":
                    Update(formularioCargado);
                    break;

                case "Delete":
                    Delete(formularioCargado);
                    break;

                case "Select":
                    Select(formularioCargado);
                    break;
            }
        }


        private void Insert(string Formulario)
        {
            switch (Formulario)
            {
                case "Ninguno":

                    break;

                case "Usuarios":
                    if (usuarios.ValidarLleno() && usuarios.ValidarContraseña())
                    {
                        usuarios.AgregarUsuario();
                    }
                    break;

                case "Productos":
                    if(productos.Validar()){
                        productos.AgregarProducto();
                        productos.LlenarGridView();
                    }
                    break;

                case "Proveedores":
                    if(proveedores.Validar()){
                        proveedores.AgregarProveedor();
                        proveedores.LlenarGridView();
                    }
                    break;

                case "Login":

                    break;

                case "Reporte":

                    break;

                case "Corte":

                    break;

                case "Ventas":
                    ventas.InsertarVenta();
                    break;

                case "Compras":
                    compras.InsertarCompra();
                    break;
            }
        }

        private void Update(string Formulario)
        {
            switch (Formulario)
            {
                case "Ninguno":

                    break;

                case "Usuarios":
                    if (usuarios.ValidarLleno() && usuarios.ValidarContraseña())
                    {
                        usuarios.ModificarUsuario();
                    }
                    break;

                case "Productos":
                    if(productos.Validar()){
                        productos.ModificarProducto();
                        productos.LlenarGridView();
                    }
                    break;

                case "Proveedores":
                    if(proveedores.Validar()){
                        proveedores.ModificarProveedor();
                        proveedores.LlenarGridView();
                    }
                    break;

                case "Login":
                    
                    break;

                case "Reporte":

                    break;

                case "Corte":

                    break;

                case "Ventas":

                    break;

                case "compras":

                    break;
            }
        }

        private void Delete(string Formulario)
        {
            DialogResult opcion;
            switch (Formulario)
            {
                case "Ninguno":

                    break;

                case "Usuarios":
                    opcion = MessageBox.Show("¿Desea eliminar el usuario?", "OPCION", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (opcion == DialogResult.Yes)
                    {
                        usuarios.EliminarUsuario();
                        Submenu();
                    }
                    break;

                case "Productos":
                    opcion = MessageBox.Show("¿Desea eliminar el producto?", "OPCION", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (opcion == DialogResult.Yes)
                    {
                        productos.EliminarProducto();
                        Submenu();
                        productos.LlenarGridView();
                    }
                    break;

                case "Proveedores":
                    opcion = MessageBox.Show("¿Desea eliminar el proveedor?", "OPCION", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (opcion == DialogResult.Yes)
                    {
                        proveedores.EliminarProveedor();
                        Submenu();
                        proveedores.LlenarGridView();
                    }
                    break;

                case "Login":

                    break;

                case "Reporte":

                    break;

                case "Corte":

                    break;

                case "Ventas":

                    break;

                case "compras":

                    break;
            }
        }

        private void Select(string Formulario)
        {
            switch (Formulario)
            {
                case "Ninguno":

                    break;

                case "Usuarios":
                    lstDatos = consultas.BuscarUsuario(toolStripTextBox_Buscar.Text);
                    if (lstDatos != null)
                    {
                        usuarios.LlenarCajas(lstDatos);
                        SubmenuBuscar();
                    }
                    else
                    {
                        MessageBox.Show("Usario no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;

                case "Productos":
                    lstDatos = consultas.BuscarProducto(toolStripTextBox_Buscar.Text);
                    if (lstDatos != null)
                    {
                        productos.LlenarCajas(lstDatos);
                        SubmenuBuscar();
                        productos.configurarDatagridViwe();
                    }
                    else
                    {
                        MessageBox.Show("Producto no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;

                case "Proveedores":
                    lstDatos = consultas.BuscarProveedor(toolStripTextBox_Buscar.Text);
                    if (lstDatos != null)
                    {
                        proveedores.LlenarCajas(lstDatos);
                        SubmenuBuscar();
                        proveedores.configurarDatagridViwe();
                    }
                    else
                    {
                        MessageBox.Show("Proveedor no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;

                case "Login":

                    break;

                case "Reporte":
                    reporte.configurarDatagridViwe();
                    break;

                case "Corte":
                    corte.configurarDatagridViwe();
                    break;

                case "Ventas":

                    break;

                case "compras":

                    break;

                case "Ordenes":
                    if (toolStripTextBox_Buscar.Text != "")
                    {
                        ordenes.DetallesOrdenes();
                        ordenes.configurarDatagridViweDetalles();
                    }
                    break;

                case "Inventario":
                    if (toolStripTextBox_Buscar.Text != "")
                    {
                        inventario.configurarDatagridViwe();
                    }
                    break;
            }
        }



        private void Inicio()
        {
            cantidadUsuarios = consultas.UsuariosRegistrados();

            if (cantidadUsuarios != 0)
            {
                formularioCargado = "Login";

                login = new frmLogin(toolStripLabel_Usuario, toolStripButton_Login,
                        toolStripSplitButton_Archivo,
                        ToolStripMenuItem_Agregar, ToolStripMenuItem_Modificar, ToolStripMenuItem_Eliminar,
                        ToolStripMenuItem_Guardar, ToolStripMenuItem_Cancelar,
                        ToolStripMenuItem_Cerrar,
                        toolStripButton_Usuarios, toolStripButton_Productos, toolStripButton_Proveedores,
                        toolStripButton_Compras, toolStripButton_Ventas,
                        ToolStripMenuItem_Corte, ToolStripMenuItem_Reporte, ToolStripMenuItem_Ordenes,
                        toolStripButton_Administracion,
                        toolStripTextBox_Buscar);
                login.MdiParent = this;
                login.Show();
            }
            else
            {
                MessageBox.Show("                                 Bienvenido. \n"
                              + "Gracias por su preferencia al instalar nuestro software.",
                    "Inicio de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MessageBox.Show("Antes de iniciar debera crear un un usuario Administrador.", "Inicio de Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                inicioSistema = true;

                formularioCargado = "Usuarios";

                usuarios = new frmUsuarios(inicioSistema, toolStripLabel_Usuario);
                usuarios.MdiParent = this;
                usuarios.Show();
            }
        }

        public void MensajeError(string Error)
        {
            MessageBox.Show(Error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void FormularioCargado(string Formulario)
        {
            switch (Formulario)
            {
                case "Ninguno":
                    ToolStripMenuItem_Agregar.Text = "Agregar";
                    ToolStripMenuItem_Modificar.Text = "Modificar";
                    ToolStripMenuItem_Eliminar.Text = "Eliminar";
                    break;

                case "Usuarios":
                    ToolStripMenuItem_Agregar.Text = ToolStripMenuItem_Agregar.Text + " usuario";
                    ToolStripMenuItem_Modificar.Text = ToolStripMenuItem_Modificar.Text + " usuario";
                    ToolStripMenuItem_Eliminar.Text = ToolStripMenuItem_Eliminar.Text + " usuario";

                    Submenu();

                    usuarios = new frmUsuarios(inicioSistema, toolStripLabel_Usuario);
                    usuarios.MdiParent = this;
                    usuarios.Show();
                    break;

                case "Productos":
                    ToolStripMenuItem_Agregar.Text = ToolStripMenuItem_Agregar.Text + " producto";
                    ToolStripMenuItem_Modificar.Text = ToolStripMenuItem_Modificar.Text + " producto";
                    ToolStripMenuItem_Eliminar.Text = ToolStripMenuItem_Eliminar.Text + " producto";

                    Submenu();

                    productos = new frmProductos(toolStripLabel_Usuario);
                    productos.MdiParent = this;
                    productos.Show();
                    break;

                case "Proveedores":
                    ToolStripMenuItem_Agregar.Text = ToolStripMenuItem_Agregar.Text + " proveedor";
                    ToolStripMenuItem_Modificar.Text = ToolStripMenuItem_Modificar.Text + " proveedor";
                    ToolStripMenuItem_Eliminar.Text = ToolStripMenuItem_Eliminar.Text + " proveedor";

                    Submenu();

                    proveedores = new frmProveedores(toolStripLabel_Usuario);
                    proveedores.MdiParent = this;
                    proveedores.Show();
                    break;

                case "Login":
                    login = new frmLogin(toolStripLabel_Usuario, toolStripButton_Login,
                        toolStripSplitButton_Archivo,
                        ToolStripMenuItem_Agregar, ToolStripMenuItem_Modificar, ToolStripMenuItem_Eliminar,
                        ToolStripMenuItem_Guardar, ToolStripMenuItem_Cancelar,
                        ToolStripMenuItem_Cerrar,
                        toolStripButton_Usuarios, toolStripButton_Productos, toolStripButton_Proveedores,
                        toolStripButton_Compras, toolStripButton_Ventas,
                        ToolStripMenuItem_Corte, ToolStripMenuItem_Reporte, ToolStripMenuItem_Ordenes,
                        toolStripButton_Administracion,
                        toolStripTextBox_Buscar);
                    login.MdiParent = this;
                    login.Show();
                    break;

                case "Compras":
                    ToolStripMenuItem_Agregar.Text = "Agregar";
                    ToolStripMenuItem_Modificar.Text = "Modificar";
                    ToolStripMenuItem_Eliminar.Text = "Eliminar";

                    SubmenuCompraVenta();

                    compras = new frmCompras(toolStripLabel_Usuario, ToolStripMenuItem_Guardar);
                    compras.MdiParent = this;
                    compras.Show();
                    break;

                case "Ventas":
                    ToolStripMenuItem_Agregar.Text = "Agregar";
                    ToolStripMenuItem_Modificar.Text = "Modificar";
                    ToolStripMenuItem_Eliminar.Text = "Eliminar";

                    Submenu2();

                    ventas = new frmVentas(toolStripLabel_Usuario, ToolStripMenuItem_Guardar);
                    ventas.MdiParent = this;
                    ventas.Show();
                    break;

                case "Corte":
                    ToolStripMenuItem_Agregar.Text = "Agregar";
                    ToolStripMenuItem_Modificar.Text = "Modificar";
                    ToolStripMenuItem_Eliminar.Text = "Eliminar";

                    Submenu2();

                    corte = new frmCorteCaja();
                    corte.MdiParent = this;
                    corte.Show();
                    break;

                case "Reporte":
                    ToolStripMenuItem_Agregar.Text = "Agregar";
                    ToolStripMenuItem_Modificar.Text = "Modificar";
                    ToolStripMenuItem_Eliminar.Text = "Eliminar";

                    Submenu2();

                    reporte = new frmReporteSemanal();
                    reporte.MdiParent = this;
                    reporte.Show();
                    break;

                case "Ordenes":
                    ToolStripMenuItem_Agregar.Text = "Agregar";
                    ToolStripMenuItem_Modificar.Text = "Modificar";
                    ToolStripMenuItem_Eliminar.Text = "Eliminar";

                    Submenu2();

                    ordenes = new frmOrdenes(toolStripTextBox_Buscar);
                    ordenes.MdiParent = this;
                    ordenes.Show();
                    break;

                case "Inventario":
                    ToolStripMenuItem_Agregar.Text = "Agregar";
                    ToolStripMenuItem_Modificar.Text = "Modificar";
                    ToolStripMenuItem_Eliminar.Text = "Eliminar";

                    Submenu2();

                    inventario = new frmInventario(toolStripTextBox_Buscar);
                    inventario.MdiParent = this;
                    inventario.Show();
                    break;
            }
        }

        public void FormularioCerrar(string Formulario)
        {
            switch (Formulario)
            {
                case "Ninguno":
                    ToolStripMenuItem_Agregar.Text = "Agregar";
                    ToolStripMenuItem_Modificar.Text = "Modificar";
                    ToolStripMenuItem_Eliminar.Text = "Eliminar";
                    break;

                case "Usuarios":
                    usuarios = new frmUsuarios(inicioSistema, toolStripLabel_Usuario);
                    usuarios.Close();
                    break;

                case "Login":
                    login = new frmLogin(toolStripLabel_Usuario, toolStripButton_Login,
                        toolStripSplitButton_Archivo,
                        ToolStripMenuItem_Agregar, ToolStripMenuItem_Modificar, ToolStripMenuItem_Eliminar,
                        ToolStripMenuItem_Guardar, ToolStripMenuItem_Cancelar,
                        ToolStripMenuItem_Cerrar,
                        toolStripButton_Usuarios, toolStripButton_Productos, toolStripButton_Proveedores,
                        toolStripButton_Compras, toolStripButton_Ventas,
                        ToolStripMenuItem_Corte, ToolStripMenuItem_Reporte, ToolStripMenuItem_Ordenes,
                        toolStripButton_Administracion,
                        toolStripTextBox_Buscar);
                    login.Close();
                    break;

                case "Reporte":
                    reporte = new frmReporteSemanal();
                    reporte.Close();
                    break;

                case "Productos":
                    productos = new frmProductos(toolStripLabel_Usuario);
                    productos.Cerrar();
                    break;

                case "Corte":
                    corte = new frmCorteCaja();
                    corte.Close();
                    break;

                case "Ventas":
                    ventas = new frmVentas(toolStripLabel_Usuario, ToolStripMenuItem_Guardar);
                    ventas.Close();
                    break;

                case "Compras":
                    compras = new frmCompras(toolStripLabel_Usuario, ToolStripMenuItem_Guardar);
                    compras.Close();
                    break;

                case "Proveedores":
                    proveedores = new frmProveedores(toolStripLabel_Usuario);
                    proveedores.Close();
                    break;
            }
        }

        private void LogOut()
        {
            formularioCargado = "Ninguno";

            toolStripSplitButton_Archivo.Enabled = false;
            ToolStripMenuItem_Agregar.Enabled = false;
            ToolStripMenuItem_Modificar.Enabled = false;
            ToolStripMenuItem_Eliminar.Enabled = false;
            ToolStripMenuItem_Guardar.Enabled = false;
            ToolStripMenuItem_Cancelar.Enabled = false;
            ToolStripMenuItem_Cerrar.Enabled = false;

            toolStripButton_Usuarios.Enabled = false;
            toolStripButton_Productos.Enabled = false;
            toolStripButton_Proveedores.Enabled = false;
            toolStripButton_Compras.Enabled = false;
            toolStripButton_Ventas.Enabled = false;

            toolStripButton_Administracion.Enabled = false;
            ToolStripMenuItem_Corte.Enabled = false;
            ToolStripMenuItem_Reporte.Enabled = false;
            ToolStripMenuItem_Ordenes.Enabled = false;

            toolStripTextBox_Buscar.Enabled = false;


        }

        public void LogIn()
        {
            formularioCargado = "Ninguno";

            toolStripSplitButton_Archivo.Enabled = true;
            ToolStripMenuItem_Agregar.Enabled = true;
            ToolStripMenuItem_Modificar.Enabled = true;
            ToolStripMenuItem_Eliminar.Enabled = true;
            ToolStripMenuItem_Guardar.Enabled = true;
            ToolStripMenuItem_Cancelar.Enabled = true;
            ToolStripMenuItem_Cerrar.Enabled = true;

            toolStripButton_Usuarios.Enabled = true;
            toolStripButton_Productos.Enabled = true;
            toolStripButton_Proveedores.Enabled = true;
            toolStripButton_Compras.Enabled = true;
            toolStripButton_Ventas.Enabled = true;

            toolStripButton_Administracion.Enabled = false;
            ToolStripMenuItem_Corte.Enabled = true;
            ToolStripMenuItem_Reporte.Enabled = true;
            ToolStripMenuItem_Ordenes.Enabled = true;

            toolStripTextBox_Buscar.Enabled = true;
        }

        private void Submenu()
        {
            ToolStripMenuItem_Agregar.Enabled = true;
            ToolStripMenuItem_Modificar.Enabled = false;
            ToolStripMenuItem_Eliminar.Enabled = false;
            ToolStripMenuItem_Guardar.Enabled = false;
            ToolStripMenuItem_Cancelar.Enabled = false;
            ToolStripMenuItem_Cerrar.Enabled = true;
        }

        private void SubmenuAgregar()
        {
            ToolStripMenuItem_Agregar.Enabled = false;
            ToolStripMenuItem_Modificar.Enabled = false;
            ToolStripMenuItem_Eliminar.Enabled = false;
            ToolStripMenuItem_Guardar.Enabled = true;
            ToolStripMenuItem_Cancelar.Enabled = true;
            ToolStripMenuItem_Cerrar.Enabled = true;
        }

        private void SubmenuModificar()
        {
            ToolStripMenuItem_Agregar.Enabled = false;
            ToolStripMenuItem_Modificar.Enabled = false;
            ToolStripMenuItem_Eliminar.Enabled = false;
            ToolStripMenuItem_Guardar.Enabled = true;
            ToolStripMenuItem_Cancelar.Enabled = true;
            ToolStripMenuItem_Cerrar.Enabled = true;
        }

        private void SubmenuEliminar()
        {
            ToolStripMenuItem_Agregar.Enabled = false;
            ToolStripMenuItem_Modificar.Enabled = false;
            ToolStripMenuItem_Eliminar.Enabled = false;
            ToolStripMenuItem_Guardar.Enabled = true;
            ToolStripMenuItem_Cancelar.Enabled = true;
            ToolStripMenuItem_Cerrar.Enabled = true;
        }

        private void SubmenuGuardar()
        {
            ToolStripMenuItem_Agregar.Enabled = true;
            ToolStripMenuItem_Modificar.Enabled = false;
            ToolStripMenuItem_Eliminar.Enabled = false;
            ToolStripMenuItem_Guardar.Enabled = false;
            ToolStripMenuItem_Cancelar.Enabled = false;
            ToolStripMenuItem_Cerrar.Enabled = true;
        }

        private void SubmenuBuscar()
        {
            ToolStripMenuItem_Agregar.Enabled = false;
            ToolStripMenuItem_Modificar.Enabled = true;
            ToolStripMenuItem_Eliminar.Enabled = true;
            ToolStripMenuItem_Guardar.Enabled = false;
            ToolStripMenuItem_Cancelar.Enabled = true;
            ToolStripMenuItem_Cerrar.Enabled = true;
        }

        private void SubmenuCompraVenta()
        {
            ToolStripMenuItem_Agregar.Enabled = false;
            ToolStripMenuItem_Modificar.Enabled = false;
            ToolStripMenuItem_Eliminar.Enabled = false;
            ToolStripMenuItem_Guardar.Enabled = false;
            ToolStripMenuItem_Cancelar.Enabled = true;
            ToolStripMenuItem_Cerrar.Enabled = true;
        }

        public void Submenu2()
        {
            ToolStripMenuItem_Agregar.Enabled = false;
            ToolStripMenuItem_Modificar.Enabled = false;
            ToolStripMenuItem_Eliminar.Enabled = false;
            ToolStripMenuItem_Guardar.Enabled = true;
            ToolStripMenuItem_Cancelar.Enabled = true;
            ToolStripMenuItem_Cerrar.Enabled = true;
        }

        #endregion




        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            LogOut();
            Inicio();
        }

        private void toolStripButton_Login_Click(object sender, EventArgs e)
        {
            FormularioCerrar(formularioCargado);

            formularioCargado = "Login";
            if (toolStripButton_Login.Text == formularioCargado)
            {
                FormularioCargado(formularioCargado);
            }
            else
            {
                toolStripButton_Login.Text = "Login";
                toolStripLabel_Usuario.Text = "Sin usuario";
                LogOut();
                FormularioCerrar(formularioCargado);
            }
        }

        private void toolStripButton_Usuarios_Click(object sender, EventArgs e)
        {
            FormularioCerrar(formularioCargado);

            formularioCargado = "Usuarios";

            FormularioCargado(formularioCargado);
        }

        private void toolStripButton_Productos_Click(object sender, EventArgs e)
        {
            FormularioCerrar(formularioCargado);

            formularioCargado = "Productos";

            FormularioCargado(formularioCargado);
        }

        private void toolStripButton_Proveedores_Click(object sender, EventArgs e)
        {
            FormularioCerrar(formularioCargado);

            formularioCargado = "Proveedores";

            FormularioCargado(formularioCargado);
        }

        private void toolStripButton_Compras_Click(object sender, EventArgs e)
        {
            FormularioCerrar(formularioCargado);

            formularioCargado = "Compras";
            Agregar(formularioCargado);

            FormularioCargado(formularioCargado);
        }

        private void toolStripButton_Ventas_Click(object sender, EventArgs e)
        {
            FormularioCerrar(formularioCargado);

            formularioCargado = "Ventas";

            FormularioCargado(formularioCargado);
        }

        private void toolStripTextBox_Buscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                Select(formularioCargado);
                toolStripTextBox_Buscar.Clear();
            }
        }

        private void ToolStripMenuItem_Agregar_Click(object sender, EventArgs e)
        {
            Agregar(formularioCargado);

            SubmenuAgregar();
        }

        private void ToolStripMenuItem_Modificar_Click(object sender, EventArgs e)
        {
            Modificar(formularioCargado);
            SubmenuModificar();
        }

        private void ToolStripMenuItem_Eliminar_Click(object sender, EventArgs e)
        {   
            Delete(formularioCargado);
        }

        private void ToolStripMenuItem_Guardar_Click(object sender, EventArgs e)
        {
            AccionRealizar(accionRealizar);
            FinAccion(formularioCargado);
            if (formularioCargado == "Compras" || formularioCargado == "Ventas")
                SubmenuCompraVenta();
            else
                SubmenuGuardar();
        }

        private void ToolStripMenuItem_Cancelar_Click(object sender, EventArgs e)
        {
            FinAccion(formularioCargado);
            if (formularioCargado == "Compras" || formularioCargado == "Ventas")
                SubmenuCompraVenta();
            else
                Submenu();
        }

        private void ToolStripMenuItem_Cerrar_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem_Corte_Click(object sender, EventArgs e)
        {
            FormularioCerrar(formularioCargado);

            formularioCargado = "Corte";

            FormularioCargado(formularioCargado);
        }

        private void ToolStripMenuItem_Reporte_Click(object sender, EventArgs e)
        {
            FormularioCerrar(formularioCargado);

            formularioCargado = "Reporte";

            FormularioCargado(formularioCargado);
        }

        private void ToolStripMenuItem_Ordenes_Click(object sender, EventArgs e)
        {
            FormularioCerrar(formularioCargado);

            formularioCargado = "Ordenes";

            FormularioCargado(formularioCargado);
        }

        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormularioCerrar(formularioCargado);

            formularioCargado = "Inventario";

            FormularioCargado(formularioCargado);
        }

        
    }
}
