using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
/// <summary>
/// 
/// </summary>
namespace SoftEvolution
{
    /// <summary>
    /// Clase principal clsInventario
    /// </summary>
    class clsInventario
    {
        private string Icodigo;
        private string Icantidad;
        /// <summary>
        /// Declaraciones de los atributos Codigo,Cantidad 
        /// Conexion a la Base de datos 
        /// Clase pojos para enviar los datos a la clase clsDatosInventario para
        /// mandar los valores.
        /// </summary>
        /// <returns>
        /// Los getters y setters de Codigo y Cantidad de los inventarios
        ///
        /// </returns>
        public static MySqlConnection ObtenerConexion()
        {
            MySqlConnection conectar = new MySqlConnection("SERVER=" + "localhost" + ";PORT=3306" + ";DATABASE=" + "evolutiongym" + ";UID=" + "root" + ";PWD=" + "root");

            conectar.Open();
            return conectar;
        }

        public string codigo
        {
            get
            {
                return Icodigo;
            }
            set
            {
                Icodigo = value;
            }
        }


        public string Cantidad
        {
            get
            {
                return Icantidad;
            }
            set
            {
                Icantidad = value;
            }
        }
    }

    

}
