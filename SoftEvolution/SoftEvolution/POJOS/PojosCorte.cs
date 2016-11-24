﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftEvolution
{
    class PojosCorte
    {
        //variables para los campos de la base de datos
        private int Pfolio;
        private string Pusuario;
        private string Pproducto;
        private int Pcantidad;
        private double PPunidad;
        private double Ptotal;

        //getters & setters para cada valor
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
        public double precio
        {
            get
            {
                return PPunidad;
            }
            set
            {
                PPunidad = value;
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
