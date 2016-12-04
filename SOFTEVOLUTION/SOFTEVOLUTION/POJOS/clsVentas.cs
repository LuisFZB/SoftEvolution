using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOFTEVOLUTION
{
    class clsVentas
    {
        private string Pcodigo;
        private string Pproducto;
        private double Pprecio_venta_menudeo;
        private int Pfolio;
        private string Pusuario;
        private string Pfecha;
        private int Pcantidad;
        private double Ptotal;
        private int Pexistencia;

        public int existencia
        {
            get
            {
                return Pexistencia;
            }
            set
            {
                Pexistencia = value;
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
        public string fecha
        {
            get
            {
                return Pfecha;
            }
            set
            {
                Pfecha = value;
            }
        }
        public string usuario
        {
            get
            {
                return Pusuario;
            }
            set
            {
                Pusuario = value;
            }
        }
        public int folio
        {
            get
            {
                return Pfolio;
            }
            set
            {
                Pfolio = value;
            }
        }
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
    }
}
