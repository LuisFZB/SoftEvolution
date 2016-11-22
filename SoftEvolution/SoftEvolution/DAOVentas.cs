using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace SoftEvolution
{
    class DAOVentas
    {
        private MySqlConnection conexion = new MySqlConnection();

        public void conectar()
        {
            string cadena;
            cadena = "SERVER=" + "localhost" + ";PORT=3306" + ";DATABASE=" + "evolutiongym1" + ";UID=" + "root" + ";PWD=EDW95";
            conexion.ConnectionString = cadena;
            conexion.Open();

        }
        public void cerrar()
        {
            conexion.Close();
        }

        public VentasPojos getProductById(string Codigo)
        {
            VentasPojos objProduct = new VentasPojos();
            string sql;
            MySqlCommand cm = new MySqlCommand();
            MySqlDataReader dr;
            conectar();
            cm.Parameters.AddWithValue("@CODIGO", Codigo);
            sql = "SELECT * FROM productos WHERE codigo = @CODIGO";
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = conexion;
            dr = cm.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                objProduct.codigo = dr.GetString("codigo");
                objProduct.producto = dr.GetString("producto");
                objProduct.precio_venta_menudeo = double.Parse(dr.GetString("precio_venta_menudeo").ToString());
                objProduct.existencia = Int32.Parse(dr.GetString("bodega"));
                cerrar();
                return objProduct;
            }
            else
            {
                cerrar();
                return null;
            }

        }
        public VentasPojos PrecioEntrenador(string Codigo)
        {
            VentasPojos objProduct = new VentasPojos();
            string sql;
            MySqlCommand cm = new MySqlCommand();
            MySqlDataReader dr;
            conectar();
            cm.Parameters.AddWithValue("@CODIGO", Codigo);
            sql = "SELECT * FROM productos WHERE codigo = @CODIGO";
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = conexion;
            dr = cm.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                objProduct.codigo = dr.GetString("codigo");
                objProduct.producto = dr.GetString("producto");
                objProduct.precio_venta_menudeo = double.Parse(dr.GetString("precio_venta_instructor").ToString());
                cerrar();
                return objProduct;
            }
            else
            {
                cerrar();
                return null;
            }

        }
        public VentasPojos PrecioMayoreo(string Codigo)
        {
            VentasPojos objProduct = new VentasPojos();
            string sql;
            MySqlCommand cm = new MySqlCommand();
            MySqlDataReader dr;
            conectar();
            cm.Parameters.AddWithValue("@CODIGO", Codigo);
            sql = "SELECT * FROM productos WHERE codigo = @CODIGO";
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = conexion;
            dr = cm.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                objProduct.codigo = dr.GetString("codigo");
                objProduct.producto = dr.GetString("producto");
                objProduct.precio_venta_menudeo = double.Parse(dr.GetString("precio_venta_mayoreo").ToString());
                cerrar();
                return objProduct;
            }
            else
            {
                cerrar();
                return null;
            }

        }

        public List<VentasPojos> List()
        {

            List<VentasPojos> lista = new List<VentasPojos>();
            String sql;
            MySqlCommand cm = new MySqlCommand();
            MySqlDataReader dr;
            conectar();
            sql = "SELECT max(folio) as folio from ventas";
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = conexion;
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                VentasPojos objCorte = new VentasPojos();
                objCorte.folio = dr.GetInt32("folio");

                lista.Add(objCorte);
            }
            cerrar();


            return lista;

        }

        public void insertar(VentasPojos objVentas)
        {
            string sql;
            MySqlCommand cm;
            conectar();

            cm = new MySqlCommand();
            cm.Parameters.AddWithValue("@FOLIO", objVentas.folio);
            cm.Parameters.AddWithValue("@USUARIO", objVentas.usuario);
            cm.Parameters.AddWithValue("@FECHA", objVentas.fecha);
            cm.Parameters.AddWithValue("@CANTIDAD", objVentas.cantidad);
            cm.Parameters.AddWithValue("@TOTAL", objVentas.total);

            sql = "INSERT INTO VENTAS(FOLIO,USUARIO,FECHA,CANTIDAD,TOTAL,UTILIDAD)VALUES (@FOLIO,@USUARIO,@FECHA,@CANTIDAD,@TOTAL,NULL)";
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = conexion;
            cm.ExecuteNonQuery();
            cerrar();
        }

        public void insertarDetalle(VentasPojos objVentas)
        {
            string sql;
            MySqlCommand cm;
            conectar();

            cm = new MySqlCommand();
            cm.Parameters.AddWithValue("@CODIGO_VENTA", objVentas.folio);
            cm.Parameters.AddWithValue("@CODIGO_PRODUCTO", objVentas.codigo);
            cm.Parameters.AddWithValue("@PRODUCTO", objVentas.producto);
            cm.Parameters.AddWithValue("@CANTIDAD", objVentas.cantidad);
            cm.Parameters.AddWithValue("@PRECIO_VENTA", objVentas.precio_venta_menudeo);
            cm.Parameters.AddWithValue("@SUBTOTAL", objVentas.total);

            sql = "INSERT INTO DETALLE_VENTAS(CODIGO_VENTA,CODIGO_PRODUCTO,PRODUCTO,CANTIDAD,PRECIO_VENTA,SUBTOTAL)VALUES (@CODIGO_VENTA,@CODIGO_PRODUCTO,@PRODUCTO,@CANTIDAD,@PRECIO_VENTA,@SUBTOTAL)";
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = conexion;
            cm.ExecuteNonQuery();
            cerrar();
        }
        public VentasPojos modificar(ref VentasPojos P)
        {

            string update = "UPDATE detalle_ventas SET cantidad= cantidad + '" + P.cantidad + "',subtotal=subtotal+'" + P.total + "' WHERE Codigo_producto='" + P.codigo + "'AND codigo_venta=" + P.folio;
            MySqlCommand miCom = new MySqlCommand(update, conexion);
            miCom.ExecuteNonQuery();
            miCom.Dispose();
            cerrar();
            return P;

        }

        public VentasPojos modificarProducto(ref VentasPojos P)
        {
            conectar();
            string update = "UPDATE productos SET bodega= bodega - '" + P.cantidad + "' WHERE Codigo='" + P.codigo + "'";
            MySqlCommand miCom = new MySqlCommand(update, conexion);
            miCom.ExecuteNonQuery();
            miCom.Dispose();
            cerrar();
            return P;

        }
       
    }
}
