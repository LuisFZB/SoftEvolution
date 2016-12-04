using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOFTEVOLUTION
{
    class clsCompras
    {
        private int pCodigo;
        private string pProveedor;
        private DateTime pFecha;
        private int pCantidad;
        private double pTotal;

        public int Codigo
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
        public string Proveedor
        {
            get
            {
                return pProveedor;
            }
            set
            {
                pProveedor = value;
            }
        }
        public DateTime Fecha
        {
            get
            {
                return pFecha;
            }
            set
            {
                pFecha = value;
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
        public double Total
        {
            get
            {
                return pTotal;
            }
            set
            {
                pTotal = value;
            }
        }
    }
}
