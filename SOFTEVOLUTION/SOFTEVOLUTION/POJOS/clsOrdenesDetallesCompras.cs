using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOFTEVOLUTION
{
    class clsOrdenesDetallesCompras
    {
        private int pCCompra;
        private string pCProducto;
        private string pProducto;
        private int pCantidad;
        private double pCompra;
        private double pSubtotal;

        public int Cod_Compra
        {
            get
            {
                return pCCompra;
            }
            set
            {
                pCCompra = value;
            }
        }
        public string Cod_Producto
        {
            get
            {
                return pCProducto;
            }
            set
            {
                pCProducto = value;
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
