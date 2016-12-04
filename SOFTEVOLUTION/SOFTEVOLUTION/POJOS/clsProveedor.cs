using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOFTEVOLUTION
{
    class clsProveedor
    {
        private string PCodigo;
        private string PNomEmpresa;
        private string PTelEmpresa;
        private string PEmailEmpresa;
        private string PNomContacto;
        private string PApContacto;
        private string PObservaciones;


        public string Codigo
        {
            get
            {
                return PCodigo;
            }
            set
            {
                PCodigo = value;
            }
        }
        public string NombreEmpresa
        {
            get
            {
                return PNomEmpresa;
            }
            set
            {
                PNomEmpresa = value;
            }
        }
        public string TelefonoEmpresa
        {
            get
            {
                return PTelEmpresa;
            }
            set
            {
                PTelEmpresa = value;
            }
        }
        public string EmailEmpresa
        {
            get
            {
                return PEmailEmpresa;
            }
            set
            {
                PEmailEmpresa = value;
            }
        }
        public string NombreContacto
        {
            get
            {
                return PNomContacto;
            }
            set
            {
                PNomContacto = value;
            }
        }
        public string ApellidoContacto
        {
            get
            {
                return PApContacto;
            }
            set
            {
                PApContacto = value;
            }
        }
        public string Observaciones
        {
            get
            {
                return PObservaciones;
            }
            set
            {
                PObservaciones = value;
            }
        }
    }
}
