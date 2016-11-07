using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace SoftEvolution
{
    class clsConexion
    {
        private MySqlConnection cnConexion = new MySqlConnection();

        public void Conectar()
        {
            string strCadenaConexion;
            strCadenaConexion = "SERVER=" + "localhost" + ";PORT=3306" + ";DATABASE=" + "evolutiongym" + ";UID=" + "root" + ";PWD=" + "1234";
            cnConexion.ConnectionString = strCadenaConexion;
            cnConexion.Open();
        }

        public void Cerrar()
        {
            cnConexion.Close();
        }
    }
}
