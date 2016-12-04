using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace SOFTEVOLUTION
{
    class CONEXION
    {
        protected MySqlConnection cnConexion = new MySqlConnection();

        # region "CONEXION A LA BD"

        public void Conectar()
        {
            string strCadenaConexion;
            strCadenaConexion = "SERVER=localhost;PORT=3306;DATABASE=EvolutionGYM;UID=root;PWD=root";
            cnConexion.ConnectionString = strCadenaConexion;
            cnConexion.Open();
        }

        public void Cerrar()
        {
            cnConexion.Close();
        }

        # endregion
    }
}
