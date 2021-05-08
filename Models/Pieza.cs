using System;
using System.Collections.Generic;
using System.Text;

namespace Aprendiendo_Isa.Models
{
    public class Pieza
    {
        public int Id{ get; set; }
        public List<Posicion> Movimientos { get; set; }
        public TipoPieza TipoPieza { get; set; }
        public int MyProperty { get; set; }
        public int Valor { get; set; }



        public Pieza(TipoPieza tipo)
        {
            this.TipoPieza = tipo;
            this.Movimientos =

                List<Posicion> Posiciones = new List<Posicion>() { }
        }
    }


    public enum TipoPieza
    {

    }
    
    public class Posicion
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public DateTime Tiempo { get; set; }

    }
}
