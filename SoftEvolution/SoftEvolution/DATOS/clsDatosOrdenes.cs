using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;


namespace SoftEvolution
{
    class clsDatosOrdenes
    {
        private MySqlConnection cnConexion = new MySqlConnection();

        public void Conectar()
        {
            string strCadenaConexion;
            strCadenaConexion = "SERVER=" + "localhost" + ";PORT=3306" + ";DATABASE=" + "evolutiongym" + ";UID=" + "root" + ";PWD=" + "root";
            cnConexion.ConnectionString = strCadenaConexion;
            cnConexion.Open();
        }

        public void Cerrar()
        {
            cnConexion.Close();
        }

        public List<clsOrdenes> getOrdenes()
        {
            List<clsOrdenes> lstOrdenes = new List<clsOrdenes>();
            string sql;
            MySqlCommand cm = new MySqlCommand();
            MySqlDataReader dr;
            Conectar();
            sql = "SELECT * FROM detalle_compra";
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = cnConexion;
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                clsOrdenes objOrd = new clsOrdenes();
                objOrd.Codigo = dr.GetInt32("codigo_compra");
                objOrd.Cantidad = dr.GetInt32("cantidad");

                lstOrdenes.Add(objOrd);
            }
            Cerrar();
            return lstOrdenes;
        }

        public clsOrdenes getOrdenesById(string IDcodigo)
        {
            clsOrdenes objOrd = new clsOrdenes();
            string sql;
            MySqlCommand cm = new MySqlCommand();
            MySqlDataReader dr;
            Conectar();
            sql = "SELECT * FROM detalle_compra WHERE codigo = @codigo_compra";
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Parameters.AddWithValue("@codigo_compra", IDcodigo);
            cm.Connection = cnConexion;
            dr = cm.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                objOrd.Codigo = dr.GetInt32("codigo_compra");
                objOrd.Cantidad = dr.GetInt32("cantidad");
                Cerrar();
                return objOrd;
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
        public List<clsOrdenes> buscar(string codigo)
        {
            List<clsOrdenes> lista = new List<clsOrdenes>();
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

                clsOrdenes Oinv = new clsOrdenes();
                Oinv.Codigo = _reader.GetInt32(0);
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
        public clsOrdenes buscarProducto(ref clsOrdenes inv)
        {
            Conectar();
            string consulta = "SELECT * FROM detalle_compra WHERE codigo =" + inv.Codigo;
            MySqlCommand miCom = new MySqlCommand(consulta, cnConexion);
            MySqlDataReader midataReader = miCom.ExecuteReader();
            midataReader.Read();
            if (midataReader.HasRows)
            {

                inv.Codigo = Convert.ToInt32(midataReader["codigo"]);
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
