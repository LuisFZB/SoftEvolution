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
                objInv.codigo = dr.GetString("codigo");
                objInv.Cantidad = dr.GetString("bodega");

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
                objInv.codigo = dr.GetString("codigo");
                objInv.Cantidad = dr.GetString("bodega");
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
        /// Metodo de buscar, verificar el producto a buscar con una consulta en  productos.
        /// 
        /// </summary>
        /// <param name="codig"></param>
        /// <returns>Retorna una lista de los productos a buscar</returns>
        public static List<clsInventario> Buscar(string codig)
        {
            List<clsInventario> _lista = new List<clsInventario>();

            MySqlCommand _comando = new MySqlCommand(String.Format(
           "SELECT codigo, bodega FROM productos where codigo ='{0}'", codig), clsInventario.ObtenerConexion());
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                clsInventario objInv = new clsInventario();
                objInv.codigo = _reader.GetString(0);
                objInv.Cantidad = _reader.GetString(1);

                _lista.Add(objInv);
            }

            return _lista;
        }
    }

}

