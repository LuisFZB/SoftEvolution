using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
namespace SoftEvolution
{
    class clsDatosProducto
    {
        public int h;


        private MySqlConnection conexion = new MySqlConnection(); // creacion del objeto para hacer la conexion

        public void Conectar() //Método de conexión
        {
            string strCadenaConexion; //variable para almacenar los datos de conexión de la base de datos
            strCadenaConexion = "SERVER=" + "localhost" + ";PORT=3306" + ";DATABASE=" + "evolutiongym" + ";UID=" + "root" + ";PWD=" + "12345";
            conexion.ConnectionString = strCadenaConexion; //pasa los datos de la cadena para realizar la conexion
            conexion.Open();  //abre la conexión
        }

        public void Cerrar() //Metodo que cierra la coneción
        {
            conexion.Close(); //cierra la conexión
        }
        #region "Métodos de manipulación de datos"
        public List<clsProductos> getProducto() //obtiene todos los datos de la base de datos y returna una lista con todos los datos
        {
            List<clsProductos> lstProduc = new List<clsProductos>(); //lista que almacenara los datos
            string sql; //cadena que contendra el script
            MySqlCommand cm = new MySqlCommand(); //objeto de MySQL
            MySqlDataReader dr; //objeto para que lea los datos de la base de datos
            Conectar(); //hace la conexión con la base de datos
            sql = "SELECT * FROM productos"; //script de la consulta
            cm.CommandText = sql;  //se le pasa la cadena que contiene el script
            cm.CommandType = CommandType.Text;
            cm.Connection = conexion; //asigna el tipo de comando
            dr = cm.ExecuteReader();
            while (dr.Read()) //ciclo while que se repetira mientras se este leyendo la base de datos
            {
                clsProductos objProducto = new clsProductos(); //objeto de los getters y setters
                                                               //obtenemos los datos de la base de datos y los pasamos a los getters de cada campo
                objProducto.Codigo = dr.GetString("codigo");
                objProducto.Producto = dr.GetString("producto");
                objProducto.Marca = dr.GetString("marca");
                objProducto.Categoria = dr.GetString("categoria");
                objProducto.Detalles = dr.GetString("detalles");
                objProducto.Precio_Compra = dr.GetString("precio_compra");
                objProducto.Precio_Venta_Menudeo = dr.GetString("precio_venta_menudeo");
                objProducto.Precio_Venta_Mayoreo = dr.GetString("precio_venta_mayoreo");
                objProducto.Precio_Venta_Instructor = dr.GetString("precio_venta_instructor");
                objProducto.Cantidad = dr.GetString("cantidad");

                lstProduc.Add(objProducto);//añade los datos a la lista
            }
            Cerrar();//cierra la conexión
            return lstProduc; //retorna la lista
        }


        public clsProductos getProductosById(string IDcodigo)
        {
            clsProductos objProducto = new clsProductos();
            string sql;
            MySqlCommand cm = new MySqlCommand();
            MySqlDataReader dr;
            Conectar();//abre la conexion
            //realiza la consulta
            sql = "SELECT * FROM productos WHERE codigo = @codigo";
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Parameters.AddWithValue("@codigo", IDcodigo);//anade el id principal de la tabla de productos
            cm.Connection = conexion;
            dr = cm.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                objProducto.Codigo = dr.GetString("codigo");
                objProducto.Producto = dr.GetString("producto");
                objProducto.Marca = dr.GetString("marca");
                objProducto.Categoria = dr.GetString("categoria");
                objProducto.Detalles = dr.GetString("detalles");
                objProducto.Precio_Compra = dr.GetString("precio_compra");
                objProducto.Precio_Venta_Menudeo = dr.GetString("precio_venta_menudeo");
                objProducto.Precio_Venta_Mayoreo = dr.GetString("precio_venta_mayoreo");
                objProducto.Precio_Venta_Instructor = dr.GetString("precio_venta_instructor");
                objProducto.Cantidad = dr.GetString("cantidad");
                Cerrar();
                return objProducto;
            }
            else
            {
                Cerrar();
                return null;
            }
        }
        public void AgregarProducto(clsProductos objProducto) //Método que agrega un producto
        {
            //definición de variables y objetos a utilizar
            string sql;
            MySqlCommand cm;
            Conectar(); //llamado al método conectar para hacer la conexión

            cm = new MySqlCommand();//inicializacion del objeto
                                    //se le pasan los parametros de todos los campos al objeto de la base de datos
            cm.Parameters.AddWithValue("@codigo", objProducto.Codigo);
            cm.Parameters.AddWithValue("@producto", objProducto.Producto);
            cm.Parameters.AddWithValue("@marca", objProducto.Marca);
            cm.Parameters.AddWithValue("@categoria", objProducto.Categoria);
            cm.Parameters.AddWithValue("@detalles", objProducto.Detalles);
            cm.Parameters.AddWithValue("@precio_compra", objProducto.Precio_Compra);
            cm.Parameters.AddWithValue("@precio_venta_menudeo", objProducto.Precio_Venta_Menudeo);
            cm.Parameters.AddWithValue("@precio_venta_mayoreo", objProducto.Precio_Venta_Mayoreo);
            cm.Parameters.AddWithValue("@precio_venta_instructor", objProducto.Precio_Venta_Instructor);
            cm.Parameters.AddWithValue("@cantidad", objProducto.Cantidad);
            //ingresamos a la variable el escript de la base de datos
            sql = "INSERT INTO productos (codigo, producto, marca, categoria, detalles, precio_compra, precio_venta_menudeo, precio_venta_mayoreo, precio_venta_instructor, cantidad ) VALUES (@codigo, @producto, @marca, @categoria, @detalles, @precio_compra, @precio_venta_menudeo, @precio_venta_mayoreo, @precio_venta_instructor, @cantidad)";
            //pasamos el escript para realizar la consulta
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = conexion;
            cm.ExecuteNonQuery();//ejecuta el escript
            Cerrar(); //cierra la conexión
        }

        public void ModificarProducto(clsProductos objProducto) //metodo para modificar los datos del producto
        {
            string sql;
            MySqlCommand cm;
            Conectar(); //conecta con la base de datos

            cm = new MySqlCommand();//inicializacion del objeto
                                    //se le pasan los parametros de todos los campos al objeto de la base de datos
            cm.Parameters.AddWithValue("@codigo", objProducto.Codigo);
            cm.Parameters.AddWithValue("@producto", objProducto.Producto);
            cm.Parameters.AddWithValue("@marca", objProducto.Marca);
            cm.Parameters.AddWithValue("@categoria", objProducto.Categoria);
            cm.Parameters.AddWithValue("@detalles", objProducto.Detalles);
            cm.Parameters.AddWithValue("@precio_compra", objProducto.Precio_Compra);
            cm.Parameters.AddWithValue("@precio_venta_menudeo", objProducto.Precio_Venta_Menudeo);
            cm.Parameters.AddWithValue("@precio_venta_mayoreo", objProducto.Precio_Venta_Mayoreo);
            cm.Parameters.AddWithValue("@precio_venta_instructor", objProducto.Precio_Venta_Instructor);
            cm.Parameters.AddWithValue("@cantidad", objProducto.Cantidad);
            //ingresamos a la variable el escript de la base de datos
            sql = "UPDATE productos SET codigo = @codigo, producto = @producto, marca = @marca, categoria = @categoria," +
            "detalles = @detalles, precio_compra = @precio_compra, precio_venta_menudeo = @precio_venta_menudeo," +
            "precio_venta_mayoreo = @precio_venta_mayoreo, precio_venta_instructor = @precio_venta_instructor, cantidad = @cantidad WHERE codigo = @codigo and cantidad = @cantidad";
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = conexion;
            cm.ExecuteNonQuery();//ejecuta el escript
            Cerrar();//cierra la conexión
        }

        public void EliminarProducto(clsProductos objProducto) //método que elimina un producto
        {
            string sql;
            MySqlCommand cm;
            Conectar(); //conecta con la base de datos

            try
            {
                cm = new MySqlCommand();//inicialización del objeto
                sql = "DELETE FROM productos WHERE codigo = '" + objProducto.Codigo + "'"; //script de la consulta
                cm.CommandText = sql;//pasamos la variable que contiene el script
                cm.CommandType = CommandType.Text; ;//asignamos el tipo de comando
                cm.Connection = conexion;//realiza la conexión
                cm.ExecuteNonQuery();// ejecuta el script
                Cerrar();//cierra la conexión
                h = 1;
            }
            catch (MySqlException)
            {
                h = 0;
            }

        }






        public List<clsProductos> buscar(string codigo) //método para buscar datos en la base de datos que retorna la lista con los datos
        {
            List<clsProductos> lista = new List<clsProductos>(); //lista de tipo clsProductos
            string sql; //cadena que contendra el script de la base de datos
            MySqlCommand cm = new MySqlCommand(); //objeto del command
            MySqlDataReader _reader; //objeto para leer la base de datos
            Conectar(); //conecta con la base de datos
            sql = "SELECT * FROM productos where codigo =" + codigo; // script de la base de datos
            cm.CommandText = sql; // pasamos el script de la consulta
            cm.CommandType = CommandType.Text; //asignamos el tipo de command
            cm.Connection = conexion;
            _reader = cm.ExecuteReader(); //ejecutamos el script

            if (_reader.Read()) //si se esta leyendo la base de datos entrara al if
            {

                clsProductos pProducto = new clsProductos();    //objeto de la clase co getters y setters
                                                                //se obtienen los datos de la base de datos y los agrega a la clase
                pProducto.Codigo = _reader.GetString(0);
                pProducto.Producto = _reader.GetString(1);
                pProducto.Marca = _reader.GetString(2);
                pProducto.Categoria = _reader.GetString(3);
                pProducto.Detalles = _reader.GetString(4);
                pProducto.Precio_Compra = _reader.GetString(5);
                pProducto.Precio_Venta_Menudeo = _reader.GetString(6);
                pProducto.Precio_Venta_Mayoreo = _reader.GetString(7);
                pProducto.Precio_Venta_Instructor = _reader.GetString(8);
                pProducto.Cantidad = _reader.GetString(9);

                lista.Add(pProducto); //los datos los agrega a la lista
                Cerrar(); //cierra la conexion
                return lista; //retornamos la lista
            }
            else //si no se esta buscando nada entra
            {
                Cerrar(); //cerramos la conexion 
                return null; //no retornamos nada
            }
        }


        public clsProductos buscarProducto(ref clsProductos produ) //método para buscar un dato en específico para modificarlo
        {
            Conectar(); //conecta con la base de datos
            string consulta = "SELECT * FROM productos WHERE codigo =" + produ.Codigo; //script de la consulta
            MySqlCommand miCom = new MySqlCommand(consulta, conexion); //pasamos el script y la coexion al objeto
            MySqlDataReader midataReader = miCom.ExecuteReader(); //objeto para leer los datos de la base de datos
            midataReader.Read(); //lee la base de datos
            if (midataReader.HasRows) //codicion para obtener los datos en caso de que haya uno a buscar
            {
                //obtenemos los datos y los pasamos a la referencia de la clase que tiene los getters y setters
                produ.Codigo = midataReader["codigo"].ToString();
                produ.Producto = midataReader["producto"].ToString();
                produ.Marca = midataReader["marca"].ToString();
                produ.Categoria = midataReader["categoria"].ToString();
                produ.Detalles = midataReader["detalles"].ToString();
                produ.Precio_Compra = midataReader["precio_compra"].ToString();
                produ.Precio_Venta_Menudeo = midataReader["precio_venta_menudeo"].ToString();
                produ.Precio_Venta_Mayoreo = midataReader["precio_venta_mayoreo"].ToString();
                produ.Precio_Venta_Instructor = midataReader["precio_venta_instructor"].ToString();
                produ.Cantidad = midataReader["cantidad"].ToString();

            }
            else //si no hay ningun dato a buscar
            {
                return null; //no retornamos nada ya que no hay dato a busucar
            }
            midataReader.Close(); //cerramos la lectura 
            miCom.Dispose(); //cerramos el command
            conexion.Close(); //cerramos la connexión
            return produ; //retornamos la referencia de la clase
        }

        #endregion

    }
}
