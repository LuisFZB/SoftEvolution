using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOFTEVOLUTION
{
    class clsUsuario
    {
        private string pTipo;
        private string pUsuario;
        private string pContraseña;
        private string pNombres;
        private string pApellidos;

        public string Tipo
        {
            get
            {
                return pTipo;
            }
            set
            {
                pTipo = value;
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
        public string Contraseña
        {
            get
            {
                return pContraseña;
            }
            set
            {
                pContraseña = value;
            }
        }
        public string Nombres
        {
            get
            {
                return pNombres;
            }
            set
            {
                pNombres = value;
            }
        }
        public string Apellidos
        {
            get
            {
                return pApellidos;
            }
            set
            {
                pApellidos = value;
            }
        }
    }
}
