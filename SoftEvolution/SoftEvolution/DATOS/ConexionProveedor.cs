using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

public class ConexionProveedor
{
    private MySqlConnection conexion = new MySqlConnection();

    #region "Conexión"
    public void conectar() //Método de conexión
    {
        //variable para almacenar los datos de conexión de la base de datos
        string cadena;
        cadena = "SERVER=" + "localhost" + ";PORT=3306" + ";DATABASE=EvolutionGYM" + "" + ";UID=" + "root" + ";PWD=1234";
        conexion.ConnectionString = cadena; //pasa los datos de la cadena para realizar la conexion
        conexion.Open(); //abre la conexión

    }
    public void cerrar() //Metodo que cierra la coneción
    {
        conexion.Close(); //cierra la conexión
    }
    #endregion

    #region "Métodos de manipulación de datos"
    public void insertar(clsProveedores objProveedor) //Método que agrega un proveedor
    {
        //definición de variables y objetos a utilizar
        string sql;
        MySqlCommand cm;
        conectar(); //llamado al método conectar para hacer la conexión

        cm = new MySqlCommand(); //inicializacion del objeto
        //se le pasan los parametros de todos los campos al objeto de la base de datos
        cm.Parameters.AddWithValue("@CODIGO", objProveedor.Codigo);
        cm.Parameters.AddWithValue("@NOMBRE_EMPRESA", objProveedor.NombreEmpresa);
        cm.Parameters.AddWithValue("@TELEFONO_EMPRESA", objProveedor.TelefonoEmpresa);
        cm.Parameters.AddWithValue("@CORREO_EMPRESA", objProveedor.EmailEmpresa);
        cm.Parameters.AddWithValue("@NOMBRE_CONTACTO", objProveedor.NombreContacto);
        cm.Parameters.AddWithValue("@APELLIDOS_CONTACTO", objProveedor.ApellidoContacto);
        cm.Parameters.AddWithValue("@OBSERVACIONES", objProveedor.Observaciones);
        //ingresamos a la variable el escript de la base de datos
        sql = "INSERT INTO PROVEEDORES(CODIGO,NOMBRE_EMPRESA,TELEFONO_EMPRESA,CORREO_EMPRESA,NOMBRE_CONTACTO,APELLIDOS_CONTACTO,OBSERVACIONES) VALUES (@CODIGO,@NOMBRE_EMPRESA,@TELEFONO_EMPRESA,@CORREO_EMPRESA,@NOMBRE_CONTACTO,@APELLIDOS_CONTACTO,@OBSERVACIONES)";
        //pasamos el escript para realizar la consulta
        cm.CommandText = sql;
        cm.CommandType = CommandType.Text; 
        cm.Connection = conexion;
        cm.ExecuteNonQuery(); //ejecuta el escript
        cerrar(); //cierra la conexión
    }
    public void eliminar(clsProveedores objProveedor) //método que elimina un proveedor
    {
        string sql; //declaracion de la cadena que contendra la consulta
        MySqlCommand cm; //objeto para ejecutar la consulta
        conectar(); //abre la conexión
        cm = new MySqlCommand();//inicialización del objeto
        sql = "DELETE FROM proveedores WHERE Codigo = '" + objProveedor.Codigo + "'"; //script de la consulta
        cm.CommandText = sql; //pasamos la variable que contiene el script
        cm.CommandType = CommandType.Text; //asignamos el tipo de comando
        cm.Connection = conexion; //realiza la conexión
        cm.ExecuteNonQuery(); // ejecuta el script
        cerrar(); //cierra la conexión
    }
    /*public clsProveedores getProveedorById(string Clave)
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
    }*/
    public List<clsProveedores> getProveedor() //obtiene todos los datos de la base de datos y returna una lista con todos los datos
    {
        List<clsProveedores> lstProveedor = new List<clsProveedores>(); //lista que almacenara los datos
        string sql; //cadena que contendra el script
        MySqlCommand cm = new MySqlCommand(); //objeto de MySQL
        MySqlDataReader dr; //objeto para que lea los datos de la base de datos
        conectar(); //hace la conexión con la base de datos
        sql = "SELECT * FROM PROVEEDORES"; //script de la consulta
        cm.CommandText = sql; //se le pasa la cadena que contiene el script
        cm.CommandType = CommandType.Text; //asigna el tipo de comando
        cm.Connection = conexion; 
        dr = cm.ExecuteReader(); //ejecuta el script
        while (dr.Read()) //ciclo while que se repetira mientras se este leyendo la base de datos
        {
            clsProveedores objProveedor = new clsProveedores(); //objeto de los getters y setters
            //obtenemos los datos de la base de datos y los pasamos a los getters de cada campo
            objProveedor.Codigo = dr.GetInt32("CODIGO");
            objProveedor.NombreEmpresa = dr.GetString("NOMBRE_EMPRESA");
            objProveedor.TelefonoEmpresa = dr.GetString("TELEFONO_EMPRESA");
            objProveedor.EmailEmpresa = dr.GetString("CORREO_EMPRESA");
            objProveedor.NombreContacto = dr.GetString("NOMBRE_CONTACTO");
            objProveedor.ApellidoContacto = dr.GetString("APELLIDOS_CONTACTO");
            objProveedor.Observaciones = dr.GetString("OBSERVACIONES");

            lstProveedor.Add(objProveedor); //añade los datos a la lista
        }
        cerrar(); //cierra la conexión
        return lstProveedor; //retorna la lista

    }
    public clsProveedores modificar(ref clsProveedores P) //metodo para modificar los datos del proveedor
    {
        conectar(); //conecta con la base de datos
        //ingresamos el script de la base de datos
        string update = "UPDATE proveedores SET Nombre_empresa='" + P.NombreEmpresa + "',Telefono_empresa='" + P.TelefonoEmpresa + "',Correo_empresa='" + P.EmailEmpresa + "',Nombre_contacto='" + P.NombreContacto + "',Apellidos_contacto='" + P.ApellidoContacto + "',Observaciones='" + P.Observaciones + "' WHERE Codigo=" + P.Codigo;
        MySqlCommand miCom = new MySqlCommand(update, conexion); //objeto de MySQLCommand y se le pasa la cadena con la consulta y la conexion
        miCom.ExecuteNonQuery(); //ejecuta el script de la consulta
        miCom.Dispose();
        conexion.Close(); //cierra la conexión
        return P; //retorna la referencia de la clase

    }
    public clsProveedores buscarProveedor(ref clsProveedores cli) //método para buscar un dato en específico para modificarlo
    {
        conectar(); //conecta con la base de datos
        string consulta = "SELECT * FROM Proveedores WHERE Codigo =" + cli.Codigo; //script de la consulta
        MySqlCommand miCom = new MySqlCommand(consulta, conexion); //pasamos el script y la coexion al objeto
        MySqlDataReader midataReader = miCom.ExecuteReader(); //objeto para leer los datos de la base de datos
        midataReader.Read(); //lee la base de datos
        if (midataReader.HasRows) //codicion para obtener los datos en caso de que haya uno a buscar
        {
            //obtenemos los datos y los pasamos a la referencia de la clase que tiene los getters y setters
            cli.Codigo = Convert.ToInt32(midataReader["Codigo"]);
            cli.NombreEmpresa = midataReader["Nombre_empresa"].ToString();
            cli.TelefonoEmpresa = midataReader["Telefono_empresa"].ToString();
            cli.EmailEmpresa = midataReader["Correo_empresa"].ToString();
            cli.NombreContacto = midataReader["Nombre_contacto"].ToString();
            cli.ApellidoContacto = midataReader["Apellidos_contacto"].ToString();
            cli.Observaciones = midataReader["Observaciones"].ToString();

        }
        else //si no hay ningun dato a buscar
        {
            return null; //no retornamos nada ya que no hay dato a busucar
        }
        midataReader.Close(); //cerramos la lectura 
        miCom.Dispose(); //cerramos el command
        conexion.Close(); //cerramos la connexión
        return cli; //retornamos la referencia de la clase
    }

    public List<clsProveedores> buscar(string codigo) //método para buscar datos en la base de datos que retorna la lista con los datos
    {
        List<clsProveedores> lista = new List<clsProveedores>(); //lista de tipo clsProveedores
        string sql; //cadena que contendra el script de la base de datos
        MySqlCommand cm = new MySqlCommand(); //objeto del command
        MySqlDataReader dr; //objeto para leer la base de datos
        conectar(); //conecta con la base de datos
        sql = "SELECT * FROM PROVEEDORES where Codigo =" + codigo; // script de la base de datos
        cm.CommandText = sql; // pasamos el script de la consulta
        cm.CommandType = CommandType.Text; //asignamos el tipo de command
        cm.Connection = conexion; 
        dr = cm.ExecuteReader(); //ejecutamos el script

        if (dr.Read()) //si se esta leyendo la base de datos entrara al if
        {
            clsProveedores proveedor = new clsProveedores(); //objeto de la clase co getters y setters
            //se obtienen los datos de la base de datos y los agrega a la clase
            proveedor.Codigo = dr.GetInt32(0);
            proveedor.NombreEmpresa = dr.GetString(1);
            proveedor.TelefonoEmpresa = dr.GetString(2);
            proveedor.EmailEmpresa = dr.GetString(3);
            proveedor.NombreContacto = dr.GetString(4);
            proveedor.ApellidoContacto = dr.GetString(5);
            proveedor.Observaciones = dr.GetString(6);

            lista.Add(proveedor); //los datos los agrega a la lista
            cerrar(); //cierra la conexion
            return lista; //retornamos la lista
        }
        else //si no se esta buscando nada entra
        {
            cerrar(); //cerramos la conexion 
            return null; //no retornamos nada
        }

        
    }
    #endregion
    public ConexionProveedor()
	{
	}
}
