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
        cadena = "SERVER=" + "localhost" + ";PORT=3306" + ";DATABASE=evolutiongym" + "" + ";UID=" + "root" + ";PWD=EDW95";
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
        cm.Parameters.AddWithValue("@NOMBRE_EMPRESA", objProveedor.NombreEmpresa);
        cm.Parameters.AddWithValue("@TELEFONO_EMPRESA", objProveedor.TelefonoEmpresa);
        cm.Parameters.AddWithValue("@CORREO_EMPRESA", objProveedor.EmailEmpresa);
        cm.Parameters.AddWithValue("@NOMBRE_CONTACTO", objProveedor.NombreContacto);
        cm.Parameters.AddWithValue("@APELLIDOS_CONTACTO", objProveedor.ApellidoContacto);
        cm.Parameters.AddWithValue("@OBSERVACIONES", objProveedor.Observaciones);
        sql = "INSERT INTO PROVEEDORES(CODIGO,NOMBRE_EMPRESA,TELEFONO_EMPRESA,CORREO_EMPRESA,NOMBRE_CONTACTO,APELLIDOS_CONTACTO,OBSERVACIONES) VALUES (@CODIGO,@NOMBRE_EMPRESA,@TELEFONO_EMPRESA,@CORREO_EMPRESA,@NOMBRE_CONTACTO,@APELLIDOS_CONTACTO,@OBSERVACIONES)";
        cm.CommandText = sql;
        cm.CommandType = CommandType.Text;
        cm.Connection = conexion;
        cm.ExecuteNonQuery();
        cerrar();
    }
    public void eliminar(clsProveedores objProveedor)
    {
        string sql;
        MySqlCommand cm;
        conectar();
        cm = new MySqlCommand();
        sql = "DELETE FROM proveedores WHERE Codigo = '" + objProveedor.Codigo + "'";
        cm.CommandText = sql;
        cm.CommandType = CommandType.Text; ;
        cm.Connection = conexion;
        cm.ExecuteNonQuery();
        cerrar();
    }
    public clsProveedores getProveedorById(string Clave)
    {
        clsProveedores objProveedor = new clsProveedores();
        string sql;
        MySqlCommand cm = new MySqlCommand();
        MySqlDataReader dr;
        conectar();
        sql = "SELECT * FROM proveedores WHERE CODIGO = @CODIGO";
        cm.CommandText = sql;
        cm.CommandType = CommandType.Text;
        cm.Parameters.AddWithValue("@CODIGO", Clave);
        cm.Connection = conexion;
        dr = cm.ExecuteReader();
        if (dr.HasRows)
        {
            dr.Read();
            objProveedor.Codigo = dr.GetInt32("CODIGO");
            objProveedor.NombreEmpresa = dr.GetString("NOMBRE_EMPRESA");
            objProveedor.TelefonoEmpresa = dr.GetString("TELEFONO_EMPRESA");
            objProveedor.EmailEmpresa = dr.GetString("CORREO_EMPRESA");
            objProveedor.NombreEmpresa = dr.GetString("NOMBRE_CONTACTO");
            objProveedor.ApellidoContacto = dr.GetString("APELLIDOS_CONTACTO");
            objProveedor.Observaciones = dr.GetString("OBSERVACIONES");

            return objProveedor;
        }
        else
        {
            return null;
        }
    }
    public List<clsProveedores> getProveedor()
    {
        List<clsProveedores> lstProveedor = new List<clsProveedores>();
        string sql;
        MySqlCommand cm = new MySqlCommand();
        MySqlDataReader dr;
        conectar();
        sql = "SELECT * FROM PROVEEDORES";
        cm.CommandText = sql;
        cm.CommandType = CommandType.Text;
        cm.Connection = conexion;
        dr = cm.ExecuteReader();
        while (dr.Read())
        {
            clsProveedores objProveedor = new clsProveedores();
            objProveedor.Codigo = dr.GetInt32("CODIGO");
            objProveedor.NombreEmpresa = dr.GetString("NOMBRE_EMPRESA");
            objProveedor.TelefonoEmpresa = dr.GetString("TELEFONO_EMPRESA");
            objProveedor.EmailEmpresa = dr.GetString("CORREO_EMPRESA");
            objProveedor.NombreContacto = dr.GetString("NOMBRE_CONTACTO");
            objProveedor.ApellidoContacto = dr.GetString("APELLIDOS_CONTACTO");
            objProveedor.Observaciones = dr.GetString("OBSERVACIONES");

            lstProveedor.Add(objProveedor);
        }
        cerrar();
        return lstProveedor;

    }
    public clsProveedores modificar(ref clsProveedores P)
    {
        conectar();
        string update = "UPDATE proveedores SET Nombre_empresa='" + P.NombreEmpresa + "',Telefono_empresa='" + P.TelefonoEmpresa + "',Correo_empresa='" + P.EmailEmpresa + "',Nombre_contacto='" + P.NombreContacto + "',Apellidos_contacto='" + P.ApellidoContacto + "',Observaciones='" + P.Observaciones + "' WHERE Codigo=" + P.Codigo;
        MySqlCommand miCom = new MySqlCommand(update, conexion);
        miCom.ExecuteNonQuery();
        miCom.Dispose();
        conexion.Close();
        return P;

    }
    public clsProveedores buscarProveedor(ref clsProveedores cli)
    {
        conectar();
        string consulta = "SELECT * FROM Proveedores WHERE Codigo =" + cli.Codigo;
        MySqlCommand miCom = new MySqlCommand(consulta, conexion);
        MySqlDataReader midataReader = miCom.ExecuteReader();
        midataReader.Read();
        if (midataReader.HasRows)
        {
            cli.Codigo = Convert.ToInt32(midataReader["Codigo"]);
            cli.NombreEmpresa = midataReader["Nombre_empresa"].ToString();
            cli.TelefonoEmpresa = midataReader["Telefono_empresa"].ToString();
            cli.EmailEmpresa = midataReader["Correo_empresa"].ToString();
            cli.NombreContacto = midataReader["Nombre_contacto"].ToString();
            cli.ApellidoContacto = midataReader["Apellidos_contacto"].ToString();
            cli.Observaciones = midataReader["Observaciones"].ToString();

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

    public List<clsProveedores> buscar(string codigo)
    {
        List<clsProveedores> lista = new List<clsProveedores>();
        string sql;
        MySqlCommand cm = new MySqlCommand();
        MySqlDataReader dr;
        conectar();
        sql = "SELECT * FROM PROVEEDORES where Codigo =" + codigo;
        cm.CommandText = sql;
        cm.CommandType = CommandType.Text;
        cm.Connection = conexion;
        dr = cm.ExecuteReader();

        while (dr.Read())
        {
            clsProveedores proveedor = new clsProveedores();
            proveedor.Codigo = dr.GetInt32(0);
            proveedor.NombreEmpresa = dr.GetString(1);
            proveedor.TelefonoEmpresa = dr.GetString(2);
            proveedor.EmailEmpresa = dr.GetString(3);
            proveedor.NombreContacto = dr.GetString(4);
            proveedor.ApellidoContacto = dr.GetString(5);
            proveedor.Observaciones = dr.GetString(6);

            lista.Add(proveedor);
        }

        return lista;
    }

    public Conexion()
	{
	}
}
