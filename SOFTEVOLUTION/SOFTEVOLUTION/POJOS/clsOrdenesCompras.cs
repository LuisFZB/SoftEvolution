using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOFTEVOLUTION
{
    class clsOrdenesCompras
    {
        private int pFolio;
        private string pUsuario;
        private DateTime pFecha;
        private int pCantidad;
        private double pTotal;

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
