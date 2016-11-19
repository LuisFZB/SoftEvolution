using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SoftEvolution
{
    class UsuariosDAL
    {
        //Creo la variable que permite establecer conexión 
        private MySqlConnection cnConexion = new MySqlConnection();
        //Metodo para ábrir la Conexión
        public void Conectar()
        {
            string strinCadeConexion;
            strinCadeConexion = "server=127.0.0.1; database=evolutiongym; Uid=root; pwd=root;";
            cnConexion.ConnectionString = strinCadeConexion;
            cnConexion.Open();
        }
        //Metodo para Cerrar la Conexión
        public void Cerrar()
        {
            cnConexion.Close();
        }
        //Metodo AgregarUsuario
        public int AgregarUsuario(Usuarios obj)
        {
            string sql;
            MySqlCommand cm;
            Conectar();
            cm = new MySqlCommand();
            cm.Parameters.AddWithValue("@tipo", obj.tipo);
            cm.Parameters.AddWithValue("@usuario", obj.usuario);
            cm.Parameters.AddWithValue("@contraseña", obj.contraseña);
            cm.Parameters.AddWithValue("@nombres", obj.nombres);
            cm.Parameters.AddWithValue("@apellidos", obj.apellidos);
            sql = "INSERT INTO usuarios (tipo,usuario,contraseña,nombres,apellidos) VALUES (@tipo,@usuario,SHA1(@contraseña),@nombres,@apellidos)";
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = cnConexion;

            int t = cm.ExecuteNonQuery();
            Cerrar();
            return t;
        }

        //Metodo CargarDatos
        public List<Usuarios> CargarDatos()
        {
            List<Usuarios> _lista = new List<Usuarios>();
            string sql;
            MySqlCommand cm = new MySqlCommand();
            MySqlDataReader _reader;
            Conectar();
            sql = "SELECT * FROM Usuarios";
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = cnConexion;
            _reader = cm.ExecuteReader();
            while (_reader.Read())
            {
                Usuarios pusuario = new Usuarios();
                pusuario.tipo = _reader.GetString(0);
                pusuario.usuario = _reader.GetString(1);
                pusuario.contraseña = _reader.GetString(2);
                pusuario.nombres = _reader.GetString(3);
                pusuario.apellidos = _reader.GetString(4);


                _lista.Add(pusuario);
            }

            return _lista;
        }

        //Metodo Buscar
        public List<Usuarios> BuscarUsuario(string usuario)
        {
            List<Usuarios> _lista = new List<Usuarios>();
            string sql;
            MySqlCommand cm = new MySqlCommand();
            MySqlDataReader _reader;
            Conectar();
            sql = "SELECT * FROM Usuarios WHERE usuario=@usuario";
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Parameters.AddWithValue("@usuario", usuario);
            cm.Connection = cnConexion;
            _reader = cm.ExecuteReader();
            while (_reader.Read())
            {
                Usuarios pusuario = new Usuarios();
                pusuario.tipo = _reader.GetString(0);
                pusuario.usuario = _reader.GetString(1);
                pusuario.contraseña = _reader.GetString(2);
                pusuario.nombres = _reader.GetString(3);
                pusuario.apellidos = _reader.GetString(4);


                _lista.Add(pusuario);
            }

            return _lista;
        }

        //Metodo Eliminar
        public List<Usuarios> EliminarUsuario(string usuario)
        {
            List<Usuarios> _lista = new List<Usuarios>();
            string sql;
            MySqlCommand cm = new MySqlCommand();
            MySqlDataReader _reader;
            Conectar();
            sql = "DELETE FROM Usuarios WHERE usuario=@usuario";
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Parameters.AddWithValue("@usuario", usuario);
            cm.Connection = cnConexion;
            _reader = cm.ExecuteReader();
            while (_reader.Read())
            {
                Usuarios pusuario = new Usuarios();
                pusuario.tipo = _reader.GetString(0);
                pusuario.usuario = _reader.GetString(1);
                pusuario.contraseña = _reader.GetString(2);
                pusuario.nombres = _reader.GetString(3);
                pusuario.apellidos = _reader.GetString(4);


                _lista.Add(pusuario);
            }

            return _lista;
        }

        //Metodo Modificar
        public int ModificarUsuario(Usuarios obj)
        {
            string sql;
            MySqlCommand cm;
            Conectar();
            cm = new MySqlCommand();
            cm.Parameters.AddWithValue("@tipo", obj.tipo);
            cm.Parameters.AddWithValue("@usuario", obj.usuario);
            cm.Parameters.AddWithValue("@contraseña", obj.contraseña);
            cm.Parameters.AddWithValue("@nombres", obj.nombres);
            cm.Parameters.AddWithValue("@apellidos", obj.apellidos);
            sql = "UPDATE usuarios SET tipo=@tipo, contraseña=@contraseña, nombres=@nombres, apellidos=@apellidos WHERE usuario=@usuario";
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = cnConexion;

            int t = cm.ExecuteNonQuery();
            Cerrar();
            return t;
        }

    }
    }
       