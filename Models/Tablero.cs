using System;
using System.Collections.Generic;
using System.Text;

namespace Aprendiendo_Isa.Models
{
    class Tablero
    {
        public int Id { get; set; }
        public int Columnas{ get; set; }
        public int Filas { get; set; }
        private List<Pieza> listadoPiezas { get; set; }
    }
}
