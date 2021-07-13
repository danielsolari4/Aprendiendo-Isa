using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aprendiendo_Isa.Models
{
    public class Alfil : Pieza, IMovimiento
    {
        public Alfil(int id, TipoPieza tipo, string color, int posY, int posX) : base(id, tipo, color, posY, posX)
        {
            this.Id = id;
            this.TipoPieza = tipo;
            this.Color = color;

            List<Posicion> Posiciones = new List<Posicion>();
            Posiciones.Add(new Posicion(posY, posX, DateTime.Now));
            this.Movimientos = Posiciones;

        }
        public override bool Mover(int posY, int posX, List<Pieza> listadoPiezas)
        {
            var ultimoMovimientoPiezaMover = this.Movimientos.OrderByDescending(x => x.Tiempo).FirstOrDefault();

            //Logica movimiento Alfil
            var result = false;
         
                
            //Posiciones validas ↓-→
            for (int j = 1; j < 8; j++)
            {
                var posNuevaY= ultimoMovimientoPiezaMover.PosY + j;
                var posNuevaX= ultimoMovimientoPiezaMover.PosX + j;

                if (posNuevaY == posY && posNuevaX == posX)
                {
                    //Movimiento Abajo - Derecha
                    var casillerosAnalizarX = Math.Abs(posNuevaX - ultimoMovimientoPiezaMover.PosX);
                    var casillerosAnalizarY = Math.Abs(posNuevaY - ultimoMovimientoPiezaMover.PosY);

                    for (int i = 1; i <= casillerosAnalizarX; i++)
                    {
                        var hayPieza = Tablero.HayPieza(ultimoMovimientoPiezaMover.PosY + i, ultimoMovimientoPiezaMover.PosX+ i, listadoPiezas);

                        if (hayPieza != null)
                        {
                            if (hayPieza.Id == this.Id)
                            {
                                continue;
                            }
                            if (hayPieza.Color == this.Color)
                            {
                                return false;
                            }
                            if (i == casillerosAnalizarX)
                            {
                                if (hayPieza.Color != this.Color)
                                {
                                    Pieza.Comer(hayPieza, listadoPiezas);
                                }
                            }
                            
                        }
                    }
                    result = true;
                }
            }
            //Posiciones validas ←-↑
            for (int j = 1; j < 8; j++)
            {
                var posNuevaY = ultimoMovimientoPiezaMover.PosY - j;
                var posNuevaX = ultimoMovimientoPiezaMover.PosX - j;

                if (posNuevaY == posY && posNuevaX == posX)
                {
                    //Movimiento Abajo - Derecha
                    var casillerosAnalizar = Math.Abs(posNuevaX - ultimoMovimientoPiezaMover.PosX);

                    for (int i = 1; i <= casillerosAnalizar; i++)
                    {
                        var hayPieza = Tablero.HayPieza(casillerosAnalizar + i, casillerosAnalizar + i, listadoPiezas);

                        if (hayPieza != null)
                        {
                            if (hayPieza.Id == this.Id)
                            {
                                continue;
                            }
                            if (hayPieza.Color == this.Color)
                            {
                                return false;
                            }
                            if (i == casillerosAnalizar)
                            {
                                if (hayPieza.Color != this.Color)
                                {
                                    Pieza.Comer(hayPieza, listadoPiezas);
                                }
                            }
                           
                        }
                    }
                    result = true;
                }
            }
            //Posiciones validas ↓-←
            for (int j = 1; j < 8; j++)
            {
                var posNuevaY = ultimoMovimientoPiezaMover.PosY + j;
                var posNuevaX = ultimoMovimientoPiezaMover.PosX - j;

                if (posNuevaY == posY && posNuevaX == posX)
                {
                    //Movimiento Abajo - Derecha
                    var casillerosAnalizar = Math.Abs(posNuevaX - ultimoMovimientoPiezaMover.PosX);

                    for (int i = 1; i <= casillerosAnalizar; i++)
                    {
                        var hayPieza = Tablero.HayPieza(casillerosAnalizar + i, casillerosAnalizar - i, listadoPiezas);

                        if (hayPieza != null)
                        {
                            if (hayPieza.Id == this.Id)
                            {
                                continue;
                            }
                            if (hayPieza.Color == this.Color)
                            {
                                return false;
                            }
                            if (i == casillerosAnalizar)
                            {
                                if (hayPieza.Color != this.Color)
                                {
                                    Pieza.Comer(hayPieza, listadoPiezas);
                                }
                            }
                            
                        }
                    }
                    result = true;
                }
            }
            //Posiciones validas ↑-→
            for (int j = 1; j < 8; j++)
            {
                var posNuevaY = ultimoMovimientoPiezaMover.PosY - j;
                var posNuevaX = ultimoMovimientoPiezaMover.PosX + j;

                if (posNuevaY == posY && posNuevaX == posX)
                {
                    //Movimiento Abajo - Derecha
                    var casillerosAnalizar = Math.Abs(posNuevaX - ultimoMovimientoPiezaMover.PosX);

                    for (int i = 1; i <= casillerosAnalizar; i++)
                    {
                        var hayPieza = Tablero.HayPieza(casillerosAnalizar - i, casillerosAnalizar + i, listadoPiezas);

                        if (hayPieza != null)
                        {
                            if (hayPieza.Id == this.Id)
                            {
                                continue;
                            }
                            if (hayPieza.Color == this.Color)
                            {
                                return false;
                            }
                            if (i == casillerosAnalizar)
                            {
                                if (hayPieza.Color != this.Color)
                                {
                                    Pieza.Comer(hayPieza, listadoPiezas);
                                }
                            }
                            
                        }
                    }
                    result = true;
                }
            }


            return result;





        }


            

        


    }
}
