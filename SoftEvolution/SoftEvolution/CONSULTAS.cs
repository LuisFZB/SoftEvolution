using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace SoftEvolution
{
    class CONSULTAS : clsConexion
    {
        # region "METODOS DE JHONATAN"

        /// <summary>
        /// METODO PARA VERIFICAR SI EL USUARIO Y CONTRASEÑA SON CORRECTOS.
        /// </summary>
        /// <param name="Usuario"></param> PARAMETRO QUE CONTIENE EL USUARIO QUE DESEA HACER LA CONEXION.
        /// <param name="Contraseña"></param> PARAMETRO QUE CONTIENE LA CONTRASEÑA DEL USUARIO QUE DESEA HACER LA CONEXION.
        /// <returns>
        /// RETORNA UN ARREGLO DE STRINGS QUE CONTIENE TODOS LOS DATOS DEL USUARIO SI EL USUARIO Y CONTRASEÑA ES CORRECTO. O UN
        /// VALOR NULL EN CASO CONTRARIO</returns>
        public string[] Login(string Usuario, string Contraseña)
        {
            try
            {
                string[] DatosUsuario = new string[4];

                string sql;
                MySqlCommand cm = new MySqlCommand();
                MySqlDataReader dr;

                Conectar();

                sql = "select * from usuarios where usuario = @USUARIO and contraseña = sha1(@CONTRASEÑA);";

                cm.CommandText = sql;
                cm.CommandType = CommandType.Text;
                cm.Parameters.AddWithValue("@USUARIO", Usuario);
                cm.Parameters.AddWithValue("@CONTRASEÑA", Contraseña);
                cm.Connection = cnConexion;
                dr = cm.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    DatosUsuario[0] = dr.GetString(0);
                    DatosUsuario[1] = dr.GetString(1);
                    DatosUsuario[2] = dr.GetString(2);
                    DatosUsuario[3] = dr.GetString(3) + " " + dr.GetString(4);

                    Cerrar();
                    return DatosUsuario;
                }
                else
                {
                    Cerrar();
                    return null;
                }
            }
            catch
            {
                Cerrar();
                return null;
            }


        }

        # endregion
    }
}
