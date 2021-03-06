using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aprendiendo_Isa.Models
{
    public class Torre : Pieza, IMovimiento
    {
        public Torre(int id, TipoPieza tipo, string color, int posY, int posX) : base(id, tipo, color, posY, posX)
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
            //Logica movimiento torre

            var ultimoMovimientoPiezaMover = this.Movimientos.OrderByDescending(x => x.Tiempo).FirstOrDefault();
            var result = false;


            if (posY == ultimoMovimientoPiezaMover.PosY)
            {
                var casillerosAnalizar = Math.Abs(posX - ultimoMovimientoPiezaMover.PosX);
                if (posX > ultimoMovimientoPiezaMover.PosX)
                {
                    //Sumar Casilleros
                    for (int i = 1; i <= casillerosAnalizar; i++)
                    {
                        var piezaAComer = Tablero.HayPieza(posY, ultimoMovimientoPiezaMover.PosX + i, listadoPiezas);

                        if (piezaAComer != null)
                        {
                            if (piezaAComer.Id == this.Id)
                                continue;
                            if (piezaAComer.Color == this.Color)
                                return false;

                            if (i == casillerosAnalizar)
                            {
                                if (piezaAComer.Color != this.Color)
                                {
                                    Pieza.Comer(piezaAComer, listadoPiezas);
                                }
                            }
                        }
                    }
                    result = true;
                }
                else
                {
                    //Restar Casilleros
                    for (int i = 1; i <= casillerosAnalizar; i++)
                    {
                        var piezaAComer = Tablero.HayPieza(posY, ultimoMovimientoPiezaMover.PosX - i, listadoPiezas);

                        if (piezaAComer != null)
                        {
                            if (piezaAComer.Id == this.Id)
                                continue;
                            if (piezaAComer.Color == this.Color)
                                return false;

                            if (i == casillerosAnalizar)
                            {
                                if (piezaAComer.Color != this.Color)
                                {
                                    Pieza.Comer(piezaAComer, listadoPiezas);
                                }
                            }
                        }
                    }
                    result = true;
                }

            }
            if (posX == ultimoMovimientoPiezaMover.PosX)
            {
                var casillerosAnalizar = Math.Abs(posY - ultimoMovimientoPiezaMover.PosY);
                if (posY > ultimoMovimientoPiezaMover.PosY)
                {
                    //Sumar Casilleros
                    for (int i = 1; i <= casillerosAnalizar; i++)
                    {
                        var piezaAComer = Tablero.HayPieza(ultimoMovimientoPiezaMover.PosY + i, posX, listadoPiezas);

                        if (piezaAComer != null)
                        {
                            if (piezaAComer.Id == this.Id)
                                continue;
                            if (piezaAComer.Color == this.Color)
                                return false;

                            if (i == casillerosAnalizar)
                            {
                                if (piezaAComer.Color != this.Color)
                                {
                                    Pieza.Comer(piezaAComer, listadoPiezas);
                                }
                            }
                        }
                    }
                    result = true;
                }
                else
                {
                    //Restar Casilleros
                    for (int i = 1; i <= casillerosAnalizar; i++)
                    {
                        var piezaAComer = Tablero.HayPieza(ultimoMovimientoPiezaMover.PosY - i, posX, listadoPiezas);

                        if (piezaAComer != null)
                        {
                            if (piezaAComer.Id == this.Id)
                                continue;
                            if (piezaAComer.Color == this.Color)
                                return false;

                            if (i == casillerosAnalizar)
                            {
                                if (piezaAComer.Color != this.Color)
                                {
                                    Pieza.Comer(piezaAComer, listadoPiezas);
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