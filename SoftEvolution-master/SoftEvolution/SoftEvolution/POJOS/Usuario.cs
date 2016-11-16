using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftEvolution
{
    class Usuarios
    {
        public string tipo { get; set; }
        public string usuario { get; set; }
        public string contraseña { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }

        public Usuarios() { }

        public Usuarios(string Utipo, string Uusuario, string Ucontraseña, string Unombres, string Uapellidos)

        {
            this.tipo = Utipo;
            this.usuario = Uusuario;
            this.contraseña = Ucontraseña;
            this.nombres = Unombres;
            this.apellidos = Uapellidos;
        }
    }
}
