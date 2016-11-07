using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace SoftEvolution
{
    class clsProductos
    {
        private string pCodigo;
        private string pProducto;
        private string pMarca;
        private string pCategoria;
        private string pDetalles;
        private string pPrecio_Compra;
        private string pPrecio_Venta_Menudeo;
        private string pPrecio_Venta_Mayoreo;
        private string pPrecio_Venta_Instructor;
        private string pCantidad;

        public static MySqlConnection ObtenerConexion()
        {
            MySqlConnection conectar = new MySqlConnection("SERVER=" + "localhost" + ";PORT=3306" + ";DATABASE=" + "evolutiongym" + ";UID=" + "root" + ";PWD=" + "1234");

            conectar.Open();
            return conectar;
        }

        public string Codigo
        {
            get
            {
                return pCodigo;
            }
            set
            {
                pCodigo = value;
            }
        }
        public string Producto
        {
            get
            {
                return pProducto;
            }
            set
            {
                pProducto = value;
            }
        }
        public string Marca
        {
            get
            {
                return pMarca;
            }
            set
            {
                pMarca = value;
            }
        }

        public string Categoria
        {
            get
            {
                return pCategoria;
            }
            set
            {
                pCategoria = value;
            }
        }

        public string Detalles
        {
            get
            {
                return pDetalles;
            }
            set
            {
                pDetalles = value;
            }
        }
        public string Precio_Compra
        {
            get
            {
                return pPrecio_Compra;
            }
            set
            {
                pPrecio_Compra = value;
            }
        }

        public string Precio_Venta_Menudeo
        {
            get
            {
                return pPrecio_Venta_Menudeo;
            }
            set
            {
                pPrecio_Venta_Menudeo = value;
            }
        }

        public string Precio_Venta_Mayoreo
        {
            get
            {
                return pPrecio_Venta_Mayoreo;
            }
            set
            {
                pPrecio_Venta_Mayoreo = value;

            }
        }

        public string Precio_Venta_Instructor
        {
            get
            {
                return pPrecio_Venta_Instructor;
            }
            set
            {
                pPrecio_Venta_Instructor = value;
            }
        }

        public string Cantidad
        {
            get
            {
                return pCantidad;
            }
            set
            {
                pCantidad = value;
            }
        }
    }
}
