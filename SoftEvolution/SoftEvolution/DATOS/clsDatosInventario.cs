using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace SoftEvolution
{
    /// <summary>
    /// Clase Principal clsDatosInventario
    /// </summary>
    class clsDatosInventario
    {
        private MySqlConnection cnConexion = new MySqlConnection();
        /// <summary>
        /// Metodo para conectar a la base de datos de Mysql
        /// </summary>
        public void Conectar()
        {
            string strCadenaConexion;
            strCadenaConexion = "SERVER=" + "localhost" + ";PORT=3306" + ";DATABASE=" + "evolutiongym" + ";UID=" + "root" + ";PWD=" + "root";
            cnConexion.ConnectionString = strCadenaConexion;
            cnConexion.Open();
        }
        /// <summary>
        /// Metodo para cerrar la conexion de la base de datos Mysql
        /// </summary>
        public void Cerrar()
        {
            cnConexion.Close();
        }
        /// <summary>
        /// Metodo lista, agregar un objeto de la clase clsInventario, conetar a Mysql
        /// para hacer la conexion y una consulta en Mysql.
        /// colocar los valores dentro de una lista que existen en la clase clsInventario
        /// 
        /// </summary>
        /// <returns>
        /// Agrega los valores obtenidos de la clase clsInventario y retorna un objeto llamado lstInv
        /// </returns>
        public List<clsInventario> getOrdenes()
        {
            List<clsInventario> lstInv = new List<clsInventario>();
            string sql;
            MySqlCommand cm = new MySqlCommand();
            MySqlDataReader dr;
            Conectar();
            sql = "SELECT * FROM productos";
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = cnConexion;
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                clsInventario objInv = new clsInventario();
                objInv.codigo = dr.GetInt32("codigo");
                objInv.Cantidad = dr.GetInt32("bodega");

                lstInv.Add(objInv);
            }
            Cerrar();
            return lstInv;
        }
        /// <summary>
        /// Metodo para obtner un producto especifico por medio de la clase getInventarioById 
        /// con el parametro Codigo en la base de datos de Mysql. 
        /// </summary>
        /// <param name="IDcodigo"></param>
        /// <returns></returns>
        public clsInventario getInventarioById(string IDcodigo)
        {
            clsInventario objInv = new clsInventario();
            string sql;
            MySqlCommand cm = new MySqlCommand();
            MySqlDataReader dr;
            Conectar();
            sql = "SELECT * FROM productos WHERE codigo = @codigo";
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Parameters.AddWithValue("@codigo", IDcodigo);
            cm.Connection = cnConexion;
            dr = cm.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                objInv.codigo = dr.GetInt32("codigo");
                objInv.Cantidad = dr.GetInt32("bodega");
                Cerrar();
                return objInv;
            }
            else
            {
                Cerrar();
                return null;
            }
        }
        /// <summary>
        /// método para buscar datos en la base de datos que retorna la lista con los datos
        /// 
        /// 
        /// </summary>
        /// <param name="codig"></param>
        /// <returns>Retorna una lista de los productos a buscar</returns>
        public List<clsInventario> buscar(string codigo) 
        {
            List<clsInventario> lista = new List<clsInventario>(); 
            string sql; 
            MySqlCommand cm = new MySqlCommand(); 
            MySqlDataReader _reader; 
            Conectar(); 
            sql = "SELECT * FROM productos where codigo =" + codigo; 
            cm.CommandText = sql; 
            cm.CommandType = CommandType.Text; 
            cm.Connection = cnConexion;
            _reader = cm.ExecuteReader(); 

            if (_reader.Read()) //si se esta leyendo la base de datos entrara al if
            {

                clsInventario Oinv = new clsInventario();   
                Oinv.codigo = _reader.GetInt32(0);
                Oinv.Cantidad = _reader.GetInt32(1);

                lista.Add(Oinv); 
                Cerrar(); 
                return lista; 
            }
            else 
            {
                Cerrar();  
                return null; 
            }
        }

        /// <summary>
        /// Metodod para buscar dato en la base de datos, mediante los datos con la refereancia 
        /// de la calse de Pojos.
        /// Colocamos una condicion para obtener los datos en caso de que haya uno a buscar
        /// lo obtenemos por los getter y setter de la clase de pojos
        /// de lo contrario no retornamos nada ya no hay dato a buscar
        /// </summary>
        /// <param name="inv"></param>
        /// <returns></returns>
        public clsInventario buscarProducto(ref clsInventario inv) 
        {
            Conectar(); 
            string consulta = "SELECT * FROM productos WHERE codigo =" + inv.codigo;
            MySqlCommand miCom = new MySqlCommand(consulta, cnConexion); 
            MySqlDataReader midataReader = miCom.ExecuteReader(); 
            midataReader.Read(); 
            if (midataReader.HasRows)
            {
                
                inv.codigo = Convert.ToInt32(midataReader["codigo"]);
                inv.Cantidad = Convert.ToInt32(midataReader["bodega"].ToString());

            }
            else 
            {
                return null; 
            }
            midataReader.Close(); 
            miCom.Dispose(); 
            cnConexion.Close(); 
            return inv; 
        }

    }

}