using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

public class Conexion
{
    private MySqlConnection conexion = new MySqlConnection();

    public void conectar()
    {
        string cadena;
        cadena = "SERVER=" + "localhost" + ";PORT=3306" + ";DATABASE=EvolutionGYM" + "" + ";UID=" + "root" + ";PWD=1234";
        conexion.ConnectionString = cadena;
        conexion.Open();

    }
    public void cerrar()
    {
        conexion.Close();
    }

    public void insertar(clsProveedores objProveedor)
    {
        string sql;
        MySqlCommand cm;
        conectar();

        cm = new MySqlCommand();
        cm.Parameters.AddWithValue("@CODIGO", objProveedor.Codigo);
        cm.Parameters.AddWithValue("@NOMBRE", objProveedor.Empresa);
        cm.Parameters.AddWithValue("@PRECIO", objProduct.Precio);
        sql = "INSERT INTO PRODUCTOS(CODIGO,NOMBRE,PRECIO) VALUES (@CODIGO,@NOMBRE,@PRECIO)";
        cm.CommandText = sql;
        cm.CommandType = CommandType.Text;
        cm.Connection = conexion;
        cm.ExecuteNonQuery();
        cerrar();
    }
    public void eliminar(clsProductos objProduct)
    {
        string sql;
        MySqlCommand cm;
        conectar();
        cm = new MySqlCommand();
        sql = "DELETE FROM productos WHERE Codigo = '" + objProduct.Codigo + "'";
        cm.CommandText = sql;
        cm.CommandType = CommandType.Text; ;
        cm.Connection = conexion;
        cm.ExecuteNonQuery();
        cerrar();
    }
    public clsProductos getProductById(string Clave)
    {
        clsProductos objProduct = new clsProductos();
        string sql;
        MySqlCommand cm = new MySqlCommand();
        MySqlDataReader dr;
        conectar();
        sql = "SELECT * FROM productos WHERE CODIGO = @CODIGO";
        cm.CommandText = sql;
        cm.CommandType = CommandType.Text;
        cm.Parameters.AddWithValue("@CODIGO", Clave);
        cm.Connection = conexion;
        dr = cm.ExecuteReader();
        if (dr.HasRows)
        {
            dr.Read();
            objProduct.Codigo = dr.GetString("CODIGO");
            objProduct.Nombre = dr.GetString("NOMBRE");
            objProduct.Precio = dr.GetString("PRECIO");

            return objProduct;
        }
        else
        {
            return null;
        }
    }
    public List<clsProductos> getProducto()
    {
        List<clsProductos> lstProducto = new List<clsProductos>();
        string sql;
        MySqlCommand cm = new MySqlCommand();
        MySqlDataReader dr;
        conectar();
        sql = "SELECT * FROM PRODUCTOS";
        cm.CommandText = sql;
        cm.CommandType = CommandType.Text;
        cm.Connection = conexion;
        dr = cm.ExecuteReader();
        while (dr.Read())
        {
            clsProductos objProducto = new clsProductos();
            objProducto.Codigo = dr.GetString("CODIGO");
            objProducto.Nombre = dr.GetString("NOMBRE");
            objProducto.Precio = dr.GetString("PRECIO");



            lstProducto.Add(objProducto);
        }
        cerrar();
        return lstProducto;

    }
    public clsProductos modificar(ref clsProductos P)
    {
        conectar();
        string update = "UPDATE productos SET Codigo='" + P.Codigo + "',Nombre='" + P.Nombre + "',Precio='" + P.Precio + "' WHERE Codigo=" + P.Codigo;
        MySqlCommand miCom = new MySqlCommand(update, conexion);
        miCom.ExecuteNonQuery();
        miCom.Dispose();
        conexion.Close();
        return P;

    }
    public clsProductos buscarProduct(ref clsProductos cli)
    {
        conectar();
        string consulta = "SELECT * FROM Productos WHERE Codigo =" + cli.Codigo;
        MySqlCommand miCom = new MySqlCommand(consulta, conexion);
        MySqlDataReader midataReader = miCom.ExecuteReader();
        midataReader.Read();
        if (midataReader.HasRows)
        {
            cli.Codigo = midataReader["Codigo"].ToString();
            cli.Nombre = midataReader["Nombre"].ToString();
            cli.Precio = midataReader["Precio"].ToString();
        }
        else
        {
            return null;
        }
        midataReader.Close();
        miCom.Dispose();
        conexion.Close();
        return cli;



    }

    public Conexion()
	{
	}
}
