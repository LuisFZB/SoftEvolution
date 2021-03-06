﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOFTEVOLUTION
{
    class clsProducto
    {
        private string pCodigo;
        private string pCodigo_Proveedor;
        private string pProducto;
        private string pMarca;
        private string pCategoria;
        private string pDetalles;
        private double pPrecio_Compra;
        private double pPrecio_Venta_Menudeo;
        private double pPrecio_Venta_Mayoreo;
        private double pPrecio_Venta_Instructor;
        private int pCantidad;


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
        public string Codigo_Proveedor
        {
            get
            {
                return pCodigo_Proveedor;
            }
            set
            {
                pCodigo_Proveedor = value;
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
        public double Precio_Compra
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
        public double Precio_Venta_Menudeo
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
        public double Precio_Venta_Mayoreo
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
        public double Precio_Venta_Instructor
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
        public int Cantidad
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
