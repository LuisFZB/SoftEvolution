using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SoftEvolution
{
    class clsOrdenes
    {
        private int oCodigo;
        private int oCantidad;

        public static MySqlConnection ObtenerConexion()
        {
            MySqlConnection conectar = new MySqlConnection("SERVER=" + "localhost" + ";PORT=3306" + ";DATABASE=" + "evolutiongym" + ";UID=" + "root" + ";PWD=" + "root");

            conectar.Open();
            return conectar;
        }

        public int Codigo
        {
            get
            {
                return oCodigo;
            }
            set
            {
                oCodigo = value;
            }
        }


        public int Cantidad
        {
            get
            {
                return oCantidad;
            }
            set
            {
                oCantidad = value;
            }
        }
    }
}
