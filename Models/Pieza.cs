using System;
using System.Collections.Generic;
using System.Text;

namespace Aprendiendo_Isa.Models
{
    class Pieza
    {
        public int Id{ get; set; }
        public List<Posicion> Movimientos { get; set; }
        public int tipo { get; set; }
        public int valor { get; set; }
    }

    class Posicion
    {
        public int posX { get; set; }
        public int posY { get; set; }

    }
}
