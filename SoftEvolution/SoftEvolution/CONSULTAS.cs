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

        # region "METODOS GABRIEL"

        /// <summary>
        /// METODO QUE RECOLECTA LOS DATOS DEL ARTICULO QUE SE DESEA COMPRAR.
        /// </summary>
        /// <param name="Codigo"></param> // PARAMETRO QUE CONTIENE EL CODIGO DEL PRODUCTO QUE SE DESEA COMPRAR.
        /// <returns>
        /// RETORNA UN ARREGLO DE STRINGS QUE CONTIENE LA INFORMACION NECESARIA DEL PRODUCTO QUE SE DESEA COMPRAR.
        /// </returns>
        public string[] Articulo(string Codigo)
        {
            try
            {
                string[] DatosProducto = new string[3];

                string comandoSql;
                MySqlCommand comando = new MySqlCommand();
                MySqlDataReader dr;
                Conectar();


                comandoSql = "select codigo, producto, precio_compra from productos where codigo = @CODIGO;";
                comando.Parameters.AddWithValue("@CODIGO", Codigo);
                comando.CommandText = comandoSql;
                comando.CommandType = CommandType.Text;
                comando.Connection = cnConexion;
                dr = comando.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();

                    DatosProducto[0] = dr.GetString(0);
                    DatosProducto[1] = dr.GetString(1);
                    DatosProducto[2] = Convert.ToString(dr.GetDouble(2));

                    Cerrar();
                    return DatosProducto;
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

        /// <summary>
        /// METODO QUE VERIFICA SI EL PRODUCTO QUE SE DESEA COMPRAR YA ESTA REGISTRADO EL EL SISTEMA.
        /// </summary>
        /// <param name="Codigo"></param> // PARAMETRO QUE CONTIENE EL CODIGO DEL PRODUCTO A VERIFICAR.
        /// <returns>
        /// RETORNA UN VERDADERO SI EL PRODUCTO ESTA REGISTRADO Y UN VALOR NULL EN CASO CONTRARIO.
        /// </returns>
        public bool ProductoRegistrado(string Codigo)
        {
            try
            {
                string comandoSql;
                MySqlCommand comando = new MySqlCommand();
                MySqlDataReader dr;
                Conectar();


                comandoSql = "select count(codigo) from productos where codigo = @CODIGO;";
                comando.Parameters.AddWithValue("@CODIGO", Codigo);
                comando.CommandText = comandoSql;
                comando.CommandType = CommandType.Text;
                comando.Connection = cnConexion;
                dr = comando.ExecuteReader();

                dr.Read();

                if (dr.GetInt32(0) == 1)
                {
                    Cerrar();
                    return true;
                }
                else
                {
                    Cerrar();
                    return false;
                }
            }
            catch
            {
                Cerrar();
                return false;
            }
        }

        /// <summary>
        /// METODO QUE EXTRAE EL ULTIMO FOLIO REGISTRADO DE LA COMPRA.
        /// </summary>
        /// <returns>
        /// RETORNA EL ULTIMO FOLIO REGISTRADO.
        /// </returns>
        public int UltimoFolio()
        {
            int Folio;

            string comandoSql;
            MySqlCommand comando = new MySqlCommand();
            MySqlDataReader dr;
            Conectar();


            comandoSql = "select codigo from compras order by codigo desc limit 1;";
            comando.CommandText = comandoSql;
            comando.CommandType = CommandType.Text;
            comando.Connection = cnConexion;
            dr = comando.ExecuteReader();

            dr.Read();

            Folio = dr.GetInt32(0);

            Cerrar();
            return Folio;
        }

        /// <summary>
        /// METODO PARA OBTENER LOS DATOS DEL USUARIO LOGEADO
        /// </summary>
        /// <param name="Usuario"></param> PARAMETRO QUE CONTIENE EL NOMBRE DEL USUARIO QUE ESTA LOGEADO
        /// <returns>
        /// RETORNA UN ARREGLO DE STRINGS QUE CONTIENE TODOS LOS DATOS DEL USUARIO.
        /// </returns>
        public string[] DatosUsuario(string Usuario)
        {
            try
            {
                string[] DatosUsuario = new string[3];

                string sql;
                MySqlCommand cm = new MySqlCommand();
                MySqlDataReader dr;

                Conectar();

                sql = "select tipo, nombres, apellidos from usuarios where usuario = @USUARIO;";

                cm.CommandText = sql;
                cm.CommandType = CommandType.Text;
                cm.Parameters.AddWithValue("@USUARIO", Usuario);
                cm.Connection = cnConexion;
                dr = cm.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    DatosUsuario[0] = dr.GetString(0);
                    DatosUsuario[1] = dr.GetString(1);
                    DatosUsuario[2] = dr.GetString(2);

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
