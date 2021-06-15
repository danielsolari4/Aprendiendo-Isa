using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aprendiendo_Isa.Models
{
    public class Torre : Pieza
    {
        public Torre(int id, TipoPieza tipo, string color, int posY, int posX) :base(id,tipo,color,posY,posX)
        {
            this.Id = id;
            this.TipoPieza = tipo;
            this.Color = color;

            List<Posicion> Posiciones = new List<Posicion>();
            Posiciones.Add(new Posicion(posY, posX, DateTime.Now));
            this.Movimientos = Posiciones;

        }
        public void Mover(Pieza piezaAMover, int posY, int posX, List<Pieza> listadoPiezas)
        {
            //Logica movimiento torre

            var ultimoMovimientoPiezaMover = piezaAMover.Movimientos.OrderByDescending(x => x.Tiempo).FirstOrDefault();
            var result = false;

            if (posY == ultimoMovimientoPiezaMover.PosY)
            {
                var casillerosAnalizar = Math.Abs(posX - ultimoMovimientoPiezaMover.PosX) + 1;

                for (int i = 1; i <= casillerosAnalizar; i++)
                {
                    var piezaAComer = hayPieza(posY, i, listadoPiezas);

                    if (piezaAComer != null)
                    {
                        if (piezaAComer.Id == piezaAMover.Id)
                        {
                            continue;
                        }
                        if (i == casillerosAnalizar)
                        {
                            if (piezaAComer.Color != piezaAMover.Color)
                            {
                                comerPieza(piezaAComer, listadoPiezas);
                            }
                        }
                        else
                            return false;
                    }
                }
                result = true;

            }
            else
            {
                if (posX == ultimoMovimientoPiezaMover.PosX)
                {
                    var casillerosAnalizar = Math.Abs(posY - ultimoMovimientoPiezaMover.PosY) + 1;

                    for (int i = 1; i <= casillerosAnalizar; i++)
                    {
                        var piezaAComer = hayPieza(i, posX, listadoPiezas);

                        if (piezaAComer != null)
                        {
                            if (piezaAComer.Id == piezaAMover.Id)
                            {
                                continue;
                            }
                            if (i == casillerosAnalizar)
                            {
                                if (piezaAComer.Color != piezaAMover.Color)
                                {
                                    comerPieza(piezaAComer, listadoPiezas);
                                }
                            }
                            else
                                return false;
                        }
                    }
                    result = true;
                }

            }


            return result;

        }

        public void Comer(Pieza pieza, List<Pieza> listPieza)
        {

        }
    }
}
