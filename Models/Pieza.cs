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
        public string Color { get; set; }
        public int Valor { get; set; }



        public Pieza(int id,TipoPieza tipo,string color,int posY, int posX)
        {
            this.Id = id;
            this.TipoPieza = tipo; 
            this.Color = color;

            List<Posicion> Posiciones = new List<Posicion>();
            Posiciones.Add(new Posicion(posY, posX, DateTime.Now));
            this.Movimientos = Posiciones;

        }
    }


    public enum TipoPieza
    {
        Torre,
        Caballo,
        Alfil,
        Rey,
        Reina,
        Peon
    }
    
    public class Posicion
    {
        public int PosY { get; set; }
        public int PosX { get; set; }
        public DateTime Tiempo { get; set; }

        public Posicion(int PosY, int PosX ,DateTime Tiempo)
        {
            this.PosY = PosY;
            this.PosX = PosX;
            this.Tiempo = Tiempo;
        }

    }
}
