using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace SOFTEVOLUTION
{
    class CONSULTAS : CONEXION
    {




        #region "VARIABLES"

        frmPrincipal principal;

        string[] lstProducto;

        #endregion





        # region "METODOS DE JHONATAN"

        public int UsuariosRegistrados()
        {
            try
            {
                int Cantidad;

                string comandoSql;
                MySqlCommand comando = new MySqlCommand();
                MySqlDataReader dr;
                Conectar();


                comandoSql = "select count(usuario) from usuarios;";
                comando.CommandText = comandoSql;
                comando.CommandType = CommandType.Text;
                comando.Connection = cnConexion;
                dr = comando.ExecuteReader();

                dr.Read();

                Cantidad = dr.GetInt32(0);

                Cerrar();
                return Cantidad;
            }
            catch
            {
                Cerrar();
                principal = new frmPrincipal();
                principal.MensajeError("Error ocurrido en Verificacion de Usuarios");
                return 0;
            }
        }

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
                principal = new frmPrincipal();
                principal.MensajeError("Error ocurrido en el Login del Usuario");
                return null;
            }
        }

        # endregion





        # region "METODOS DE ALLAN"

        public bool RegistrarUsuario(clsUsuario objUsuario)
        {
            try
            {
                string sql;
                MySqlCommand cm;
                Conectar();

                cm = new MySqlCommand();
                cm.Parameters.AddWithValue("@TIPO", objUsuario.Tipo);
                cm.Parameters.AddWithValue("@USUARIO", objUsuario.Usuario);
                cm.Parameters.AddWithValue("@CONSTRASEÑA", objUsuario.Contraseña);
                cm.Parameters.AddWithValue("@NOMBRES", objUsuario.Nombres);
                cm.Parameters.AddWithValue("@APELLIDOS", objUsuario.Apellidos);

                sql = "INSERT INTO usuarios (tipo, usuario, contraseña, nombres, apellidos)"
                    + "VALUES (@TIPO, @USUARIO, sha1(@CONSTRASEÑA), @NOMBRES, @APELLIDOS)";

                cm.CommandText = sql;
                cm.CommandType = CommandType.Text;
                cm.Connection = cnConexion;
                cm.ExecuteNonQuery();
                Cerrar();

                return true;
            }
            catch
            {
                Cerrar();
                principal = new frmPrincipal();
                principal.MensajeError("Error ocurrido en el Registro del Usuario");
                return false;
            }
        }

        public void ActualizarUsuario(clsUsuario objUsuario)
        {
            try
            {
                string sql;
                MySqlCommand cm;
                Conectar();

                cm = new MySqlCommand();
                cm.Parameters.AddWithValue("@TIPO", objUsuario.Tipo);
                cm.Parameters.AddWithValue("@USUARIO", objUsuario.Usuario);
                cm.Parameters.AddWithValue("@CONSTRASEÑA", objUsuario.Contraseña);
                cm.Parameters.AddWithValue("@NOMBRES", objUsuario.Nombres);
                cm.Parameters.AddWithValue("@APELLIDOS", objUsuario.Apellidos);

                sql = "UPDATE usuarios "
                    + "SET tipo = @TIPO, contraseña = @CONSTRASEÑA, nombres = @NOMBRES, apellidos = @APELLIDOS "
                    + "where usuario = @USUARIO";

                cm.CommandText = sql;
                cm.CommandType = CommandType.Text;
                cm.Connection = cnConexion;
                cm.ExecuteNonQuery();
                Cerrar();
            }
            catch
            {
                Cerrar();
                principal = new frmPrincipal();
                principal.MensajeError("Error ocurrido en la Modificacion del Usuario");
            }        
        }

        public void EliminarUsuario(string Usuario)
        {
            try
            {
                string sql;
                MySqlCommand cm;
                Conectar();

                cm = new MySqlCommand();
                cm.Parameters.AddWithValue("@USUARIO", Usuario);

                sql = "DELETE FROM usuarios WHERE usuario = @USUARIO;";

                cm.CommandText = sql;
                cm.CommandType = CommandType.Text;
                cm.Connection = cnConexion;
                cm.ExecuteNonQuery();
                Cerrar();
            }
            catch
            {
                Cerrar();
                principal = new frmPrincipal();
                principal.MensajeError("Error ocurrido en la Eliminacio del Usuario");
            }
        }

        public string[] BuscarUsuario(string Usuario)
        {
            try
            {
                lstProducto = new string[5];

                string comandoSql;
                MySqlCommand comando = new MySqlCommand();
                MySqlDataReader dr;
                Conectar();

                comandoSql = "select * from usuarios where usuario = @USUARIO;";
                comando.Parameters.AddWithValue("@USUARIO", Usuario);
                comando.CommandText = comandoSql;
                comando.CommandType = CommandType.Text;
                comando.Connection = cnConexion;
                dr = comando.ExecuteReader();

                if (dr.Read())
                {
                    lstProducto[0] = dr.GetString(0);
                    lstProducto[1] = dr.GetString(1);
                    lstProducto[2] = dr.GetString(2);
                    lstProducto[3] = dr.GetString(3);
                    lstProducto[4] = dr.GetString(4);

                    Cerrar();
                    return lstProducto;
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
                principal = new frmPrincipal();
                principal.MensajeError("Error ocurrido en la Busqueda del Usuario");
                return null;
            }
        }

        public List<clsUsuario> getUsuarios()
        {
            try
            {
                List<clsUsuario> lstUsuarios = new List<clsUsuario>();

                string comandoSql;
                MySqlCommand comando = new MySqlCommand();
                MySqlDataReader dr;
                Conectar();

                comandoSql = "select * from usuarios;";
                comando.CommandText = comandoSql;
                comando.CommandType = CommandType.Text;
                comando.Connection = cnConexion;
                dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    clsUsuario objUsuario = new clsUsuario();

                    objUsuario.Tipo = dr.GetString(0);
                    objUsuario.Usuario = dr.GetString(1);
                    objUsuario.Contraseña = dr.GetString(2);
                    objUsuario.Nombres = dr.GetString(3);
                    objUsuario.Apellidos = dr.GetString(4);
                    

                    lstUsuarios.Add(objUsuario);
                }
                Cerrar();
                return lstUsuarios;
            }
            catch
            {
                Cerrar();
                return null;
            }
        }

        # endregion




        # region "METODOS DE ANDRES"

        public bool RegistrarProducto(clsProducto objProducto)
        {
            try
            {
                string sql;
                MySqlCommand cm;
                Conectar();

                cm = new MySqlCommand();
                cm.Parameters.AddWithValue("@CODIGO", objProducto.Codigo);
                cm.Parameters.AddWithValue("@PROVEEDOR", objProducto.Codigo_Proveedor);
                cm.Parameters.AddWithValue("@PRODUCTO", objProducto.Producto);
                cm.Parameters.AddWithValue("@MARCA", objProducto.Marca);
                cm.Parameters.AddWithValue("@CATEGORIA", objProducto.Categoria);
                cm.Parameters.AddWithValue("@DETALLES", objProducto.Detalles);
                cm.Parameters.AddWithValue("@COMPRA", objProducto.Precio_Compra);
                cm.Parameters.AddWithValue("@VENTA", objProducto.Precio_Venta_Menudeo);
                cm.Parameters.AddWithValue("@MAYOREO", objProducto.Precio_Venta_Mayoreo);
                cm.Parameters.AddWithValue("@INSTRUCTOR", objProducto.Precio_Venta_Instructor);
                cm.Parameters.AddWithValue("@BODEGA", objProducto.Cantidad);

                sql = "INSERT INTO productos "
                    + "(codigo, codigo_proveedor, producto, marca, categoria, detalles, precio_compra, precio_venta_menudeo, "
                                                                    + "precio_venta_mayoreo, precio_venta_instructor, bodega)"
                    + "VALUES (@CODIGO, @PROVEEDOR, @PRODUCTO, @MARCA, @CATEGORIA, "
                            + "@DETALLES, @COMPRA, @VENTA, @MAYOREO, @INSTRUCTOR, "
                            + "@BODEGA)";

                cm.CommandText = sql;
                cm.CommandType = CommandType.Text;
                cm.Connection = cnConexion;
                cm.ExecuteNonQuery();
                Cerrar();

                return true;
            }
            catch
            {
                Cerrar();
                principal = new frmPrincipal();
                principal.MensajeError("Error ocurrido en el Registro del Producto");
                return false;
            }
        }

        public void ActualizarProducto(clsProducto objProducto)
        {
            try
            {
                string sql;
                MySqlCommand cm;
                Conectar();

                cm = new MySqlCommand();
                cm.Parameters.AddWithValue("@CODIGO", objProducto.Codigo);
                cm.Parameters.AddWithValue("@PROVEEDOR", objProducto.Codigo_Proveedor);
                cm.Parameters.AddWithValue("@PRODUCTO", objProducto.Producto);
                cm.Parameters.AddWithValue("@MARCA", objProducto.Marca);
                cm.Parameters.AddWithValue("@CATEGORIA", objProducto.Categoria);
                cm.Parameters.AddWithValue("@DETALLES", objProducto.Detalles);
                cm.Parameters.AddWithValue("@COMPRA", objProducto.Precio_Compra);
                cm.Parameters.AddWithValue("@VENTA", objProducto.Precio_Venta_Menudeo);
                cm.Parameters.AddWithValue("@MAYOREO", objProducto.Precio_Venta_Menudeo);
                cm.Parameters.AddWithValue("@INSTRUCTOR", objProducto.Precio_Venta_Mayoreo);
                cm.Parameters.AddWithValue("@BODEGA", objProducto.Cantidad);

                sql = "UPDATE productos SET "
                    + "codigo_proveedor=@PROVEEDOR, producto=@PRODUCTO, marca=@MARCA, categoria=@CATEGORIA, detalles=@DETALLES, "
                    + "precio_compra=@COMPRA, precio_venta_menudeo=@VENTA, precio_venta_mayoreo=@MAYOREO, precio_venta_instructor=@INSTRUCTOR, "
                    + "bodega=@BODEGA "
                    + "where codigo = @CODIGO";

                cm.CommandText = sql;
                cm.CommandType = CommandType.Text;
                cm.Connection = cnConexion;
                cm.ExecuteNonQuery();
                Cerrar();
            }
            catch
            {
                Cerrar();
                principal = new frmPrincipal();
                principal.MensajeError("Error ocurrido en la Modificacion del Producto");
            }
        }

        public void EliminarProducto(string Codigo)
        {
            try
            {
                string sql;
                MySqlCommand cm;
                Conectar();

                cm = new MySqlCommand();
                cm.Parameters.AddWithValue("@CODIGO", Codigo);

                sql = "DELETE FROM productos WHERE codigo = @CODIGO;";

                cm.CommandText = sql;
                cm.CommandType = CommandType.Text;
                cm.Connection = cnConexion;
                cm.ExecuteNonQuery();
                Cerrar();
            }
            catch
            {
                Cerrar();
                principal = new frmPrincipal();
                principal.MensajeError("Error ocurrido en la Eliminacion del Producto");
            }
        }

        public string[] BuscarProducto(string Codigo)
        {
            try
            {
                lstProducto = new string[11];

                string comandoSql;
                MySqlCommand comando = new MySqlCommand();
                MySqlDataReader dr;
                Conectar();

                comandoSql = "select * from productos where codigo = @CODIGO;";
                comando.Parameters.AddWithValue("@CODIGO", Codigo);
                comando.CommandText = comandoSql;
                comando.CommandType = CommandType.Text;
                comando.Connection = cnConexion;
                dr = comando.ExecuteReader();

                if (dr.Read())
                {
                    lstProducto[0] = dr.GetString(0);
                    lstProducto[1] = dr.GetString(1);
                    lstProducto[2] = dr.GetString(2);
                    lstProducto[3] = dr.GetString(3);
                    lstProducto[4] = dr.GetString(4);
                    lstProducto[5] = dr.GetString(5);
                    lstProducto[6] = dr.GetDouble(6).ToString();
                    lstProducto[7] = dr.GetDouble(7).ToString();
                    lstProducto[8] = dr.GetDouble(8).ToString();
                    lstProducto[9] = dr.GetDouble(9).ToString();
                    lstProducto[10] = dr.GetInt32(10).ToString();
                    Cerrar();
                    return lstProducto;
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
                principal = new frmPrincipal();
                principal.MensajeError("Error ocurrido en la Busqueda del Usuario");
                return null;
            }
        }

        public List<clsProducto> getProducto()
        {
            try
            {
                List<clsProducto> lstProductos = new List<clsProducto>();

                string comandoSql;
                MySqlCommand comando = new MySqlCommand();
                MySqlDataReader dr;
                Conectar();

                comandoSql = "select * from productos;";
                comando.CommandText = comandoSql;
                comando.CommandType = CommandType.Text;
                comando.Connection = cnConexion;
                dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    clsProducto objProductos = new clsProducto();

                    objProductos.Codigo = dr.GetString(0);
                    objProductos.Codigo_Proveedor = dr.GetString(1);
                    objProductos.Producto = dr.GetString(2);
                    objProductos.Marca = dr.GetString(3);
                    objProductos.Categoria = dr.GetString(4);
                    objProductos.Detalles = dr.GetString(5);
                    objProductos.Precio_Compra = dr.GetDouble(6);
                    objProductos.Precio_Venta_Menudeo = dr.GetDouble(7);
                    objProductos.Precio_Venta_Mayoreo = dr.GetDouble(8);
                    objProductos.Precio_Venta_Instructor = dr.GetDouble(9);
                    objProductos.Cantidad = dr.GetInt32(10);


                    lstProductos.Add(objProductos);
                }
                Cerrar();
                return lstProductos;
            }
            catch
            {
                Cerrar();
                return null;
            }
        }

        # endregion




        # region "METODOS DE LUIS"

        public bool RegistrarProveedor(clsProveedor objProveedor)
        {
            try
            {
                string sql;
                MySqlCommand cm;
                Conectar();

                cm = new MySqlCommand();
                cm.Parameters.AddWithValue("@CODIGO", objProveedor.Codigo);
                cm.Parameters.AddWithValue("@EMPRESA", objProveedor.NombreEmpresa);
                cm.Parameters.AddWithValue("@TELEFONO", objProveedor.TelefonoEmpresa);
                cm.Parameters.AddWithValue("@EMAIL", objProveedor.EmailEmpresa);
                cm.Parameters.AddWithValue("@NOMBRE", objProveedor.NombreContacto);
                cm.Parameters.AddWithValue("@APELLIDOS", objProveedor.ApellidoContacto);
                cm.Parameters.AddWithValue("@OBSERVACIONES", objProveedor.Observaciones);

                sql = "INSERT INTO proveedores "
                    + "(codigo, nombre_empresa, telefono_empresa, correo_empresa, nombre_contacto, apellidos_contacto, observaciones)"
                    + "VALUES (@CODIGO, @EMPRESA, @TELEFONO, @EMAIL, @NOMBRE, @APELLIDOS, @OBSERVACIONES)";

                cm.CommandText = sql;
                cm.CommandType = CommandType.Text;
                cm.Connection = cnConexion;
                cm.ExecuteNonQuery();
                Cerrar();

                return true;
            }
            catch
            {
                Cerrar();
                principal = new frmPrincipal();
                principal.MensajeError("Error ocurrido en el Registro del Producto");
                return false;
            }
        }

        public void ActualizarProveedor(clsProveedor objProveedor)
        {
            try
            {
                string sql;
                MySqlCommand cm;
                Conectar();

                cm = new MySqlCommand();
                cm.Parameters.AddWithValue("@CODIGO", objProveedor.Codigo);
                cm.Parameters.AddWithValue("@EMPRESA", objProveedor.NombreEmpresa);
                cm.Parameters.AddWithValue("@TELEFONO", objProveedor.TelefonoEmpresa);
                cm.Parameters.AddWithValue("@EMAIL", objProveedor.EmailEmpresa);
                cm.Parameters.AddWithValue("@NOMBRE", objProveedor.NombreContacto);
                cm.Parameters.AddWithValue("@APELLIDOS", objProveedor.ApellidoContacto);
                cm.Parameters.AddWithValue("@OBSERVACIONES", objProveedor.Observaciones);

                sql = "UPDATE proveedores SET "
                    + "nombre_empresa=@EMPRESA, telefono_empresa=@TELEFONO, correo_empresa=@EMAIL, nombre_contacto=@NOMBRE, "
                    + "apellidos_contacto=@APELLIDOS, observaciones=@OBSERVACIONES "
                    + "where codigo = @CODIGO";

                cm.CommandText = sql;
                cm.CommandType = CommandType.Text;
                cm.Connection = cnConexion;
                cm.ExecuteNonQuery();
                Cerrar();
            }
            catch
            {
                Cerrar();
                principal = new frmPrincipal();
                principal.MensajeError("Error ocurrido en la Modificacion del Proveedor");
            }
        }

        public void EliminarProveedor(string Codigo)
        {
            try
            {
                string sql;
                MySqlCommand cm;
                Conectar();

                cm = new MySqlCommand();
                cm.Parameters.AddWithValue("@CODIGO", Codigo);

                sql = "DELETE FROM proveedores WHERE codigo = @CODIGO;";

                cm.CommandText = sql;
                cm.CommandType = CommandType.Text;
                cm.Connection = cnConexion;
                cm.ExecuteNonQuery();
                Cerrar();
            }
            catch
            {
                Cerrar();
                principal = new frmPrincipal();
                principal.MensajeError("Error ocurrido en la Eliminacion del Proveedor");
            }
        }

        public string[] BuscarProveedor(string Codigo)
        {
            try
            {
                lstProducto = new string[7];

                string comandoSql;
                MySqlCommand comando = new MySqlCommand();
                MySqlDataReader dr;
                Conectar();

                comandoSql = "select * from proveedores where codigo = @CODIGO;";
                comando.Parameters.AddWithValue("@CODIGO", Codigo);
                comando.CommandText = comandoSql;
                comando.CommandType = CommandType.Text;
                comando.Connection = cnConexion;
                dr = comando.ExecuteReader();

                if (dr.Read())
                {
                    lstProducto[0] = dr.GetString(0);
                    lstProducto[1] = dr.GetString(1);
                    lstProducto[2] = dr.GetString(2);
                    lstProducto[3] = dr.GetString(3);
                    lstProducto[4] = dr.GetString(4);
                    lstProducto[5] = dr.GetString(5);
                    lstProducto[6] = dr.GetString(6);

                    Cerrar();
                    return lstProducto;
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
                principal = new frmPrincipal();
                principal.MensajeError("Error ocurrido en la Busqueda del Proveedor");
                return null;
            }
        }

        public List<clsProveedor> getProveedor()
        {
            try
            {
                List<clsProveedor> lstProveedor = new List<clsProveedor>();

                string comandoSql;
                MySqlCommand comando = new MySqlCommand();
                MySqlDataReader dr;
                Conectar();

                comandoSql = "select * from proveedores;";
                comando.CommandText = comandoSql;
                comando.CommandType = CommandType.Text;
                comando.Connection = cnConexion;
                dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    clsProveedor objProveedor = new clsProveedor();

                    objProveedor.Codigo = dr.GetString(0);
                    objProveedor.NombreEmpresa = dr.GetString(1);
                    objProveedor.TelefonoEmpresa = dr.GetString(2);
                    objProveedor.EmailEmpresa = dr.GetString(3);
                    objProveedor.NombreContacto = dr.GetString(4);
                    objProveedor.ApellidoContacto = dr.GetString(5);
                    objProveedor.Observaciones = dr.GetString(6);


                    lstProveedor.Add(objProveedor);
                }
                Cerrar();
                return lstProveedor;
            }
            catch
            {
                Cerrar();
                return null;
            }
        }

        # endregion





        # region "METODOS GABRIEL"

        
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

        public int UltimoFolio()
        {
            int Folio;

            string comandoSql;
            MySqlCommand comando = new MySqlCommand();
            MySqlDataReader dr;
            Conectar();


            comandoSql = "select folio from compras order by folio desc limit 1;";
            comando.CommandText = comandoSql;
            comando.CommandType = CommandType.Text;
            comando.Connection = cnConexion;
            dr = comando.ExecuteReader();

            if (dr.Read())
            {
                Folio = dr.GetInt32(0);

                Cerrar();
                return Folio;
            }
            else
            {
                Cerrar();
                return -1;
            }
        }

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

        public void RegistrarCompra(clsCompras objProducto)
        {
            //definición de variables y objetos a utilizar
            string sql;
            MySqlCommand cm;
            Conectar(); //llamado al método conectar para hacer la conexión

            cm = new MySqlCommand();//inicializacion del objeto
            //se le pasan los parametros de todos los campos al objeto de la base de datos
            cm.Parameters.AddWithValue("@codigo", objProducto.Codigo);
            cm.Parameters.AddWithValue("@usuario", objProducto.Proveedor);
            cm.Parameters.AddWithValue("@fecha", objProducto.Fecha);
            cm.Parameters.AddWithValue("@cantidad", objProducto.Cantidad);
            cm.Parameters.AddWithValue("@total", objProducto.Total);
            //ingresamos a la variable el escript de la base de datos
            sql = "INSERT INTO compras (folio, usuario, fecha, cantidad, total) VALUES (@codigo, @usuario, @fecha, @cantidad, @total)";
            //pasamos el escript para realizar la consulta
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = cnConexion;
            cm.ExecuteNonQuery();//ejecuta el escript
            Cerrar(); //cierra la conexión
        }

        public void RegistrarDetallesCompra(clsDetallesCompra objProducto)
        {
            //definición de variables y objetos a utilizar
            string sql;
            MySqlCommand cm;
            Conectar(); //llamado al método conectar para hacer la conexión

            cm = new MySqlCommand();//inicializacion del objeto
            //se le pasan los parametros de todos los campos al objeto de la base de datos
            cm.Parameters.AddWithValue("@codigoCompra", objProducto.Codigo_Compra);
            cm.Parameters.AddWithValue("@codigoProducto", objProducto.Codigo_Producto);
            cm.Parameters.AddWithValue("@producto", objProducto.Producto);
            cm.Parameters.AddWithValue("@cantidad", objProducto.Cantidad);
            cm.Parameters.AddWithValue("@compra", objProducto.Compra);
            cm.Parameters.AddWithValue("@subtotal", objProducto.Subtotal);

            //ingresamos a la variable el escript de la base de datos
            sql = "INSERT INTO detalle_compra (codigo_compra, codigo_producto, producto, cantidad, precio_compra, subtotal) VALUES (@codigoCompra, @codigoProducto, @producto, @cantidad, @compra, @subtotal)";
            //pasamos el escript para realizar la consulta
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = cnConexion;
            cm.ExecuteNonQuery();//ejecuta el escript
            Cerrar(); //cierra la conexión
        }

        public void ActualizarBodega(string codigo, int cantidad)
        {
            string sql;
            MySqlCommand cm;
            Conectar(); //llamado al método conectar para hacer la conexión

            cm = new MySqlCommand();//inicializacion del objeto
            //se le pasan los parametros de todos los campos al objeto de la base de datos
            cm.Parameters.AddWithValue("@codigo", codigo);
            cm.Parameters.AddWithValue("@cantidad", cantidad);

            //ingresamos a la variable el escript de la base de datos
            sql = "UPDATE productos SET bodega=bodega + @cantidad WHERE codigo = @codigo;";
            //pasamos el escript para realizar la consulta
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = cnConexion;
            cm.ExecuteNonQuery();//ejecuta el escript
            Cerrar(); //cierra la conexión
        }

        # endregion





        #region "METODOS EDUARDO"

        public int UltimoFolio2()
        {
            int Folio;

            string comandoSql;
            MySqlCommand comando = new MySqlCommand();
            MySqlDataReader dr;
            Conectar();


            comandoSql = "select folio from ventas order by folio desc limit 1;";
            comando.CommandText = comandoSql;
            comando.CommandType = CommandType.Text;
            comando.Connection = cnConexion;
            dr = comando.ExecuteReader();

            if (dr.Read())
            {
                Folio = dr.GetInt32(0);

                Cerrar();
                return Folio;
            }
            else
            {
                Cerrar();
                return -1;
            }
        }

        public clsVentas getProductById(string Codigo)
        {
            clsVentas objProduct = new clsVentas();
            string sql;
            MySqlCommand cm = new MySqlCommand();
            MySqlDataReader dr;
            Conectar();
            cm.Parameters.AddWithValue("@CODIGO", Codigo);
            sql = "SELECT * FROM productos WHERE codigo = @CODIGO";
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = cnConexion;
            dr = cm.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                objProduct.codigo = dr.GetString("codigo");
                objProduct.producto = dr.GetString("producto");
                objProduct.precio_venta_menudeo = double.Parse(dr.GetString("precio_venta_menudeo").ToString());
                objProduct.existencia = Int32.Parse(dr.GetString("bodega"));
                Cerrar();
                return objProduct;
            }
            else
            {
                Cerrar();
                return null;
            }

        }

        public clsVentas PrecioEntrenador(string Codigo)
        {
            clsVentas objProduct = new clsVentas();
            string sql;
            MySqlCommand cm = new MySqlCommand();
            MySqlDataReader dr;
            Conectar();
            cm.Parameters.AddWithValue("@CODIGO", Codigo);
            sql = "SELECT * FROM productos WHERE codigo = @CODIGO";
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = cnConexion;
            dr = cm.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                objProduct.codigo = dr.GetString("codigo");
                objProduct.producto = dr.GetString("producto");
                objProduct.precio_venta_menudeo = double.Parse(dr.GetString("precio_venta_instructor").ToString());
                Cerrar();
                return objProduct;
            }
            else
            {
                Cerrar();
                return null;
            }

        }

        public clsVentas PrecioMayoreo(string Codigo)
        {
            clsVentas objProduct = new clsVentas();
            string sql;
            MySqlCommand cm = new MySqlCommand();
            MySqlDataReader dr;
            Conectar();
            cm.Parameters.AddWithValue("@CODIGO", Codigo);
            sql = "SELECT * FROM productos WHERE codigo = @CODIGO";
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = cnConexion;
            dr = cm.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                objProduct.codigo = dr.GetString("codigo");
                objProduct.producto = dr.GetString("producto");
                objProduct.precio_venta_menudeo = double.Parse(dr.GetString("precio_venta_mayoreo").ToString());
                Cerrar();
                return objProduct;
            }
            else
            {
                Cerrar();
                return null;
            }

        }

        public List<clsVentas> List()
        {

            List<clsVentas> lista = new List<clsVentas>();
            String sql;
            MySqlCommand cm = new MySqlCommand();
            MySqlDataReader dr;
            Conectar();
            sql = "SELECT max(folio) as folio from ventas";
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = cnConexion;
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                clsVentas objCorte = new clsVentas();
                if (objCorte.folio == 0)
                {
                    objCorte.folio = 0;
                }
                else
                {
                    objCorte.folio = dr.GetInt32("folio");
                }



                lista.Add(objCorte);
            }
            Cerrar();


            return lista;

        }

        public void insertar(clsVentas objVentas)
        {
            string sql;
            MySqlCommand cm;
            Conectar();

            cm = new MySqlCommand();
            cm.Parameters.AddWithValue("@FOLIO", objVentas.folio);
            cm.Parameters.AddWithValue("@USUARIO", objVentas.usuario);
            cm.Parameters.AddWithValue("@FECHA", objVentas.fecha);
            cm.Parameters.AddWithValue("@CANTIDAD", objVentas.cantidad);
            cm.Parameters.AddWithValue("@TOTAL", objVentas.total);

            sql = "INSERT INTO VENTAS(FOLIO,USUARIO,FECHA,CANTIDAD,TOTAL,UTILIDAD)VALUES (@FOLIO,@USUARIO,@FECHA,@CANTIDAD,@TOTAL,0)";
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = cnConexion;
            cm.ExecuteNonQuery();
            Cerrar();
        }

        public void insertarDetalle(clsVentas objVentas)
        {
            string sql;
            MySqlCommand cm;
            Conectar();

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
            cm.Connection = cnConexion;
            cm.ExecuteNonQuery();
            Cerrar();
        }

        public clsVentas modificar(ref clsVentas P)
        {
            try
            {
                string sql;
                MySqlCommand cm;
                Conectar();

                cm = new MySqlCommand();
                cm.Parameters.AddWithValue("@CANTIDAD", P.cantidad);
            cm.Parameters.AddWithValue("@TOTAL", P.total);
            cm.Parameters.AddWithValue("@CODIGO", P.codigo);
            cm.Parameters.AddWithValue("@FOLIO", P.folio);
            sql = "UPDATE detalle_ventas SET cantidad = cantidad + @CANTIDAD, subtotal = subtotal + @TOTAL WHERE codigo_producto = @CODIGO AND codigo_venta = @FOLIO;";

                cm.CommandText = sql;
                cm.CommandType = CommandType.Text;
                cm.Connection = cnConexion;
                cm.ExecuteNonQuery();
                Cerrar();
                return P;
            }
            catch
            {
                Cerrar();
                principal = new frmPrincipal();
                principal.MensajeError("Error ocurrido en la Venta");
                return P;
            }
            
        }

        public clsVentas modificarProducto(ref clsVentas P)
        {
            Conectar();
            string update = "UPDATE productos SET bodega= bodega - '" + P.cantidad + "' WHERE Codigo='" + P.codigo + "'";
            MySqlCommand miCom = new MySqlCommand(update, cnConexion);
            miCom.ExecuteNonQuery();
            miCom.Dispose();
            Cerrar();
            return P;

        }

        public int RevisarExistencias(string Codigo)
        {
            try
            {
                int existencias;
                string comandoSql;
                MySqlCommand comando = new MySqlCommand();
                MySqlDataReader dr;
                Conectar();


                comandoSql = "select bodega from productos where codigo = @CODIGO;";
                comando.Parameters.AddWithValue("@CODIGO", Codigo);
                comando.CommandText = comandoSql;
                comando.CommandType = CommandType.Text;
                comando.Connection = cnConexion;
                dr = comando.ExecuteReader();


                if (dr.Read())
                {
                    existencias = dr.GetInt32(0);
                    Cerrar();
                    return existencias;
                }
                else
                {
                    Cerrar();
                    return 0;
                }
            }
            catch
            {
                Cerrar();
                return 0;
            }
        }

        public List<clsCorte> Corte(int dia)
        {
            try
            {
                List<clsCorte> lstCorte = new List<clsCorte>();

                string comandoSql;
                MySqlCommand comando = new MySqlCommand();
                MySqlDataReader dr;
                Conectar();

                comando.Parameters.AddWithValue("@DIA", dia);
                comandoSql = "select folio, usuario, producto, d.cantidad, precio_venta, subtotal "
                    + "from detalle_ventas d join ventas v "
                    + "on codigo_venta = folio and "
                    + "day(fecha) = @DIA;";
                comando.CommandText = comandoSql;
                comando.CommandType = CommandType.Text;
                comando.Connection = cnConexion;
                dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    clsCorte objCorte = new clsCorte();

                    objCorte.Folio = dr.GetInt32(0);
                    objCorte.Usuario = dr.GetString(1);
                    objCorte.Producto = dr.GetString(2);
                    objCorte.Cantidad = dr.GetInt32(3);
                    objCorte.Venta = dr.GetDouble(4);
                    objCorte.Subtotal = dr.GetDouble(5);

                    lstCorte.Add(objCorte);

                }
                Cerrar();
                return lstCorte;
            }
            catch
            {
                Cerrar();
                return null;
            }
        }

        public int CorteVentasRealizadas(int dia)
        {
            int Articulos;

            string comandoSql;
            MySqlCommand comando = new MySqlCommand();
            MySqlDataReader dr;
            Conectar();

            comando.Parameters.AddWithValue("@DIA", dia);

            comandoSql = "select count(folio) "
                    + "from detalle_ventas d join ventas v "
                    + "on codigo_venta = folio and "
                    + "day(fecha) = @DIA;";
            comando.CommandText = comandoSql;
            comando.CommandType = CommandType.Text;
            comando.Connection = cnConexion;
            dr = comando.ExecuteReader();

            if (dr.Read())
            {
                Articulos = dr.GetInt32(0);

                Cerrar();
                return Articulos;
            }
            else
            {
                Cerrar();
                return -1;
            }
        }

        public int CorteArticulos(int dia)
        {
            int Articulos = 0;

            string comandoSql;
            MySqlCommand comando = new MySqlCommand();
            MySqlDataReader dr;
            Conectar();

            comando.Parameters.AddWithValue("@DIA", dia);

            comandoSql = "select sum(d.cantidad) "
                    + "from detalle_ventas d join ventas v "
                    + "on codigo_venta = folio and "
                    + "day(fecha) = @DIA;";
            comando.CommandText = comandoSql;
            comando.CommandType = CommandType.Text;
            comando.Connection = cnConexion;
            dr = comando.ExecuteReader();

            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                Articulos = dr.GetInt32(0);

                Cerrar();
                return Articulos;
            }
            else
            {
                Cerrar();
                return -1;
            }
        }

        public double CorteTotal(int dia)
        {
            double total = 0;

            string comandoSql;
            MySqlCommand comando = new MySqlCommand();
            MySqlDataReader dr;
            Conectar();

            comando.Parameters.AddWithValue("@DIA", dia);

            comandoSql = "select sum(subtotal) "
                    + "from detalle_ventas d join ventas v "
                    + "on codigo_venta = folio and "
                    + "day(fecha) = @DIA;";
            comando.CommandText = comandoSql;
            comando.CommandType = CommandType.Text;
            comando.Connection = cnConexion;
            dr = comando.ExecuteReader();

            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                total = dr.GetDouble(0);

                Cerrar();
                return total;
            }
            else
            {
                Cerrar();
                return -1;
            }
        }

        #endregion





        # region "METODOS ALEJANDRO"

        public List<clsReporteSemanal> ReporteSemanal(int Año, int Mes, int Semana, string Hoy)
        {
            try
            {
                List<clsReporteSemanal> lstReporte = new List<clsReporteSemanal>();

                string comandoSql;
                MySqlCommand comando = new MySqlCommand();
                MySqlDataReader dr;
                Conectar();

                comando.Parameters.AddWithValue("@AÑO", Año);
                comando.Parameters.AddWithValue("@MES", Mes);
                comando.Parameters.AddWithValue("@SEMANA", Semana);
                comando.Parameters.AddWithValue("@HOY", Hoy);
                comandoSql = "select codigo_producto, producto, d.cantidad, precio_venta, subtotal "
                    + "from detalle_ventas d join ventas v "
                    + "on codigo_venta = folio and "
                    + "year(fecha) = @AÑO and month(fecha) = @MES and week(@HOY) = @SEMANA;";
                comando.CommandText = comandoSql;
                comando.CommandType = CommandType.Text;
                comando.Connection = cnConexion;
                dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    clsReporteSemanal objReporte = new clsReporteSemanal();

                    objReporte.codigo = dr.GetString(0);
                    objReporte.producto = dr.GetString(1);
                    objReporte.cantidad = dr.GetInt32(2);
                    objReporte.precio_venta_menudeo = dr.GetDouble(3);
                    objReporte.total = dr.GetDouble(4);

                    lstReporte.Add(objReporte);

                }
                    Cerrar();
                    return lstReporte;
            }
            catch
            {
                Cerrar();
                return null;
            }
        }

        public int ReporteArticulos(int Año, int Mes, int Semana, string Hoy)
        {
            int Articulos;

            string comandoSql;
            MySqlCommand comando = new MySqlCommand();
            MySqlDataReader dr;
            Conectar();

            comando.Parameters.AddWithValue("@AÑO", Año);
            comando.Parameters.AddWithValue("@MES", Mes);
            comando.Parameters.AddWithValue("@SEMANA", Semana);
            comando.Parameters.AddWithValue("@HOY", Hoy);

            comandoSql = "select sum(d.cantidad) from detalle_ventas d join ventas v "
                        + "on codigo_venta = folio and "
                        + "year(fecha) = @AÑO and month(fecha) = @MES and week(@HOY) = @SEMANA;";
            comando.CommandText = comandoSql;
            comando.CommandType = CommandType.Text;
            comando.Connection = cnConexion;
            dr = comando.ExecuteReader();

            if (dr.Read())
            {
                Articulos = dr.GetInt32(0);

                Cerrar();
                return Articulos;
            }
            else
            {
                Cerrar();
                return -1;
            }
        }

        public double ReporteTotal(int Año, int Mes, int Semana, string Hoy)
        {
            double total;

            string comandoSql;
            MySqlCommand comando = new MySqlCommand();
            MySqlDataReader dr;
            Conectar();

            comando.Parameters.AddWithValue("@AÑO", Año);
            comando.Parameters.AddWithValue("@MES", Mes);
            comando.Parameters.AddWithValue("@SEMANA", Semana);
            comando.Parameters.AddWithValue("@HOY", Hoy);

            comandoSql = "select sum(total) from detalle_ventas d join ventas v "
                        + "on codigo_venta = folio and "
                        + "year(fecha) = @AÑO and month(fecha) = @MES and week(@HOY) = @SEMANA;";
            comando.CommandText = comandoSql;
            comando.CommandType = CommandType.Text;
            comando.Connection = cnConexion;
            dr = comando.ExecuteReader();

            if (dr.Read())
            {
                total = dr.GetDouble(0);

                Cerrar();
                return total;
            }
            else
            {
                Cerrar();
                return -1;
            }
        }

        # endregion








        #region "METODOS ANGEL"

        public List<clsOrdenesCompras> OrdenesCompras()
        {
            try
            {
                List<clsOrdenesCompras> lstCompras = new List<clsOrdenesCompras>();

                string comandoSql;
                MySqlCommand comando = new MySqlCommand();
                MySqlDataReader dr;
                Conectar();

                comandoSql = "select * from compras;";
                comando.CommandText = comandoSql;
                comando.CommandType = CommandType.Text;
                comando.Connection = cnConexion;
                dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    clsOrdenesCompras objOrdenes = new clsOrdenesCompras();

                    objOrdenes.Folio = dr.GetInt32(0);
                    objOrdenes.Usuario = dr.GetString(1);
                    objOrdenes.Fecha = dr.GetDateTime(2);
                    objOrdenes.Cantidad = dr.GetInt32(3);
                    objOrdenes.Total = dr.GetDouble(4);

                    lstCompras.Add(objOrdenes);

                }
                Cerrar();
                return lstCompras;
            }
            catch
            {
                Cerrar();
                return null;
            }
        }

        public List<clsOrdenesDetallesCompras> OrdenesDetallesCompras(int folio)
        {
            try
            {
                List<clsOrdenesDetallesCompras> lstDetallesCompras = new List<clsOrdenesDetallesCompras>();

                string comandoSql;
                MySqlCommand comando = new MySqlCommand();
                MySqlDataReader dr;
                Conectar();

                comando.Parameters.AddWithValue("@FOLIO", folio);
                comandoSql = "select * from detalle_compra where codigo_compra = @FOLIO;";
                comando.CommandText = comandoSql;
                comando.CommandType = CommandType.Text;
                comando.Connection = cnConexion;
                dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    clsOrdenesDetallesCompras objOrdenesDetallesCompra = new clsOrdenesDetallesCompras();

                    objOrdenesDetallesCompra.Cod_Compra = dr.GetInt32(0);
                    objOrdenesDetallesCompra.Cod_Producto = dr.GetString(1);
                    objOrdenesDetallesCompra.Producto = dr.GetString(2);
                    objOrdenesDetallesCompra.Cantidad = dr.GetInt32(3);
                    objOrdenesDetallesCompra.Compra = dr.GetDouble(4);
                    objOrdenesDetallesCompra.Subtotal = dr.GetDouble(5);

                    lstDetallesCompras.Add(objOrdenesDetallesCompra);

                }
                Cerrar();
                return lstDetallesCompras;
            }
            catch
            {
                Cerrar();
                return null;
            }
        }

        #endregion
    }
}
