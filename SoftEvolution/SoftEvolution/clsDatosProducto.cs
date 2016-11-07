using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
namespace SoftEvolution
{
    class clsDatosProducto
    {
        public int h;
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

        public List<clsProductos> getProducto()
        {
            List<clsProductos> lstProduc = new List<clsProductos>();
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
                clsProductos objProducto = new clsProductos();
                objProducto.Codigo = dr.GetString("codigo");
                objProducto.Producto = dr.GetString("producto");
                objProducto.Marca = dr.GetString("marca");
                objProducto.Categoria = dr.GetString("categoria");
                objProducto.Detalles = dr.GetString("detalles");
                objProducto.Precio_Compra = dr.GetString("precio_compra");
                objProducto.Precio_Venta_Menudeo = dr.GetString("precio_venta_menudeo");
                objProducto.Precio_Venta_Mayoreo = dr.GetString("precio_venta_mayoreo");
                objProducto.Precio_Venta_Instructor = dr.GetString("precio_venta_instructor");
                objProducto.Cantidad = dr.GetString("cantidad");

                lstProduc.Add(objProducto);
            }
            Cerrar();
            return lstProduc;
        }

        public clsProductos getProductosById(string IDcodigo)
        {
            clsProductos objProducto = new clsProductos();
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
                objProducto.Codigo = dr.GetString("codigo");
                objProducto.Producto = dr.GetString("producto");
                objProducto.Marca = dr.GetString("marca");
                objProducto.Categoria = dr.GetString("categoria");
                objProducto.Detalles = dr.GetString("detalles");
                objProducto.Precio_Compra = dr.GetString("precio_compra");
                objProducto.Precio_Venta_Menudeo = dr.GetString("precio_venta_menudeo");
                objProducto.Precio_Venta_Mayoreo = dr.GetString("precio_venta_mayoreo");
                objProducto.Precio_Venta_Instructor = dr.GetString("precio_venta_instructor");
                objProducto.Cantidad = dr.GetString("cantidad");
                Cerrar();
                return objProducto;
            }
            else
            {
                Cerrar();
                return null;
            }
        }
        public void AgregarProducto(clsProductos objProducto)
        {
            string sql;
            MySqlCommand cm;
            Conectar();

            cm = new MySqlCommand();
            cm.Parameters.AddWithValue("@codigo", objProducto.Codigo);
            cm.Parameters.AddWithValue("@producto", objProducto.Producto);
            cm.Parameters.AddWithValue("@marca", objProducto.Marca);
            cm.Parameters.AddWithValue("@categoria", objProducto.Categoria);
            cm.Parameters.AddWithValue("@detalles", objProducto.Detalles);
            cm.Parameters.AddWithValue("@precio_compra", objProducto.Precio_Compra);
            cm.Parameters.AddWithValue("@precio_venta_menudeo", objProducto.Precio_Venta_Menudeo);
            cm.Parameters.AddWithValue("@precio_venta_mayoreo", objProducto.Precio_Venta_Mayoreo);
            cm.Parameters.AddWithValue("@precio_venta_instructor", objProducto.Precio_Venta_Instructor);
            cm.Parameters.AddWithValue("@cantidad", objProducto.Cantidad);

            sql = "INSERT INTO productos (codigo, producto, marca, categoria, detalles, precio_compra, precio_venta_menudeo, precio_venta_mayoreo, precio_venta_instructor, cantidad ) VALUES (@codigo, @producto, @marca, @categoria, @detalles, @precio_compra, @precio_venta_menudeo, @precio_venta_mayoreo, @precio_venta_instructor, @cantidad)";
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = cnConexion;
            cm.ExecuteNonQuery();
            Cerrar();
        }

        public void ModificarProducto(clsProductos objProducto)
        {
            string sql;
            MySqlCommand cm;
            Conectar();

            cm = new MySqlCommand();
            cm.Parameters.AddWithValue("@codigo", objProducto.Codigo);
            cm.Parameters.AddWithValue("@producto", objProducto.Producto);
            cm.Parameters.AddWithValue("@marca", objProducto.Marca);
            cm.Parameters.AddWithValue("@categoria", objProducto.Categoria);
            cm.Parameters.AddWithValue("@detalles", objProducto.Detalles);
            cm.Parameters.AddWithValue("@precio_compra", objProducto.Precio_Compra);
            cm.Parameters.AddWithValue("@precio_venta_menudeo", objProducto.Precio_Venta_Menudeo);
            cm.Parameters.AddWithValue("@precio_venta_mayoreo", objProducto.Precio_Venta_Mayoreo);
            cm.Parameters.AddWithValue("@precio_venta_instructor", objProducto.Precio_Venta_Instructor);
            cm.Parameters.AddWithValue("@cantidad", objProducto.Cantidad);

            sql = "UPDATE productos SET codigo = @codigo, producto = @producto, marca = @marca, categoria = @categoria," +
            "detalles = @detalles, precio_compra = @precio_compra, precio_venta_menudeo = @precio_venta_menudeo," +
            "precio_venta_mayoreo = @precio_venta_mayoreo, precio_venta_instructor = @precio_venta_instructor, cantidad = @cantidad WHERE codigo = @codigo";
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = cnConexion;
            cm.ExecuteNonQuery();
            Cerrar();
        }

        public void EliminarProducto(clsProductos objProducto)
        {
            string sql;
            MySqlCommand cm;
            Conectar();

            try
            {
                cm = new MySqlCommand();
                sql = "DELETE FROM productos WHERE codigo = '" + objProducto.Codigo + "'";
                cm.CommandText = sql;
                cm.CommandType = CommandType.Text; ;
                cm.Connection = cnConexion;
                cm.ExecuteNonQuery();
                Cerrar();
                h = 1;
            }
            catch (MySqlException)
            {
                h = 0;
            }

        }


        public static List<clsProductos> Buscar(string codig)
        {
            List<clsProductos> _lista = new List<clsProductos>();

            MySqlCommand _comando = new MySqlCommand(String.Format(
           "SELECT codigo, producto, marca, categoria, detalles, precio_compra, precio_venta_menudeo, precio_venta_mayoreo, precio_venta_instructor, cantidad FROM productos  where codigo ='{0}'", codig), clsProductos.ObtenerConexion());
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                clsProductos pProducto = new clsProductos();
                pProducto.Codigo = _reader.GetString(0);
                pProducto.Producto = _reader.GetString(1);
                pProducto.Marca = _reader.GetString(2);
                pProducto.Categoria = _reader.GetString(3);
                pProducto.Detalles = _reader.GetString(4);
                pProducto.Precio_Compra = _reader.GetString(5);
                pProducto.Precio_Venta_Menudeo = _reader.GetString(6);
                pProducto.Precio_Venta_Mayoreo = _reader.GetString(7);
                pProducto.Precio_Venta_Instructor = _reader.GetString(8);
                pProducto.Cantidad = _reader.GetString(9);

                _lista.Add(pProducto);
            }

            return _lista;
        }
    }
}
