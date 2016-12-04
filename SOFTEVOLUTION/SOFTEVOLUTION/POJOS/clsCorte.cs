using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOFTEVOLUTION
{
    class clsCorte
    {
        private int pFolio;
        private string pUsuario;
        private string pProducto;
        private int pCAntidad;
        private double pVenta;
        private double pSubtotal;

        public int Folio
        {
            get
            {
                return pFolio;
            }
            set
            {
                pFolio = value;
            }
        }
        public string Usuario
        {
            get
            {
                return pUsuario;
            }
            set
            {
                pUsuario = value;
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
                return pCAntidad;
            }
            set
            {
                pCAntidad = value;
            }
        }
        public double Venta
        {
            get
            {
                return pVenta;
            }
            set
            {
                pVenta = value;
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
