using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOFTEVOLUTION
{
    class clsDetallesCompra
    {
        private int pCodigo_Compra;
        private string pCodigo_Producto;
        private string pProducto;
        private int pCantidad;
        private double pCompra;
        private double pSubtotal;

        public int Codigo_Compra
        {
            get
            {
                return pCodigo_Compra;
            }
            set
            {
                pCodigo_Compra = value;
            }
        }
        public string Codigo_Producto
        {
            get
            {
                return pCodigo_Producto;
            }
            set
            {
                pCodigo_Producto = value;
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
        public double Compra
        {
            get
            {
                return pCompra;
            }
            set
            {
                pCompra = value;
            }
        }
        public double Subtotal
        {
            get
            {
                return pSubtotal;
            }
            set
            {
                pSubtotal = value;
            }
        }
    }
}
