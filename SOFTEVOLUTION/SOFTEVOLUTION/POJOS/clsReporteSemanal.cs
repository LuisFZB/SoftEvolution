using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOFTEVOLUTION
{
    class clsReporteSemanal
    {
        private string Pcodigo;
        private string Pproducto;
        private int Pcantidad;
        private double Pprecio_venta_menudeo;
        private double Ptotal;

        public string codigo
        {
            get
            {
                return Pcodigo;
            }
            set
            {
                Pcodigo = value;
            }
        }
        public string producto
        {
            get
            {
                return Pproducto;
            }
            set
            {
                Pproducto = value;
            }
        }
        public int cantidad
        {
            get
            {
                return Pcantidad;
            }
            set
            {
                Pcantidad = value;
            }
        }
        public double precio_venta_menudeo
        {
            get
            {
                return Pprecio_venta_menudeo;
            }
            set
            {
                Pprecio_venta_menudeo = value;
            }
        }
        public double total
        {
            get
            {
                return Ptotal;
            }
            set
            {
                Ptotal = value;
            }
        }
    }
}
