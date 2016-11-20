using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace SoftEvolution
{
    class DAOCorte
    {
        //uso de la libreria de MySQL para la conexion

        private MySqlConnection conexion = new MySqlConnection();
        //metodo para hacer la conexion a la base datos
        public void conectar()
        {
            string cadena;
            cadena = "SERVER=" + "localhost" + ";PORT=3306" + ";DATABASE=" + "evolutiongym" + ";UID=" + "root" + ";PWD=EDW95";
            conexion.ConnectionString = cadena;
            conexion.Open();

        }
        //metodo para cerrar la conexion
        public void cerrar()
        {
            conexion.Close();
        }
        //metodo para hacer la consulta de busqueda

        public List<PojosCorte> ListCorte()
        {
            //lista para almacenar los valores de la consulta
            List<PojosCorte> lista = new List<PojosCorte>();
            String sql;
            MySqlCommand cm = new MySqlCommand();
            MySqlDataReader dr;
            conectar();
            // toma la fecha del sietma para ña consulta
            cm.Parameters.AddWithValue("@fecha", DateTime.Now.ToString("yyyy-MM-dd"));
            //consulta sql
            sql = "SELECT folio,usuario,codigo_producto,cantidad,precio,total FROM ventas where fecha = @fecha";
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = conexion;
            dr = cm.ExecuteReader();

            while (dr.Read())
            {
                PojosCorte objCorte = new PojosCorte();
                objCorte.folio = dr.GetInt32("folio");
                objCorte.usuario = dr.GetString("usuario");
                objCorte.codigo_producto = dr.GetString("codigo_producto");
                objCorte.cantidad = dr.GetInt32("cantidad");
                objCorte.precio = dr.GetDouble("precio");
                objCorte.total = dr.GetDouble("total");
                lista.Add(objCorte);
            }
            cerrar();


            return lista;
        }


    }
}
