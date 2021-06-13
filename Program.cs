using Aprendiendo_Isa.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aprendiendo_Isa
{
    class Program
    {
        //TODO: Hacer una pieza objeto con pos y cion... la tengo que poder mover a veces.

        //Piezas







        static void Main(string[] args)
        {
            Console.WriteLine("Tablero de Ajedrez");
            Console.WriteLine("------------------");

            string[] filasLetras = new string[] { "A", "B", "C", "D", "E", "F", "G", "H" };
            int[] filas = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            int[] columnas = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            //Creacion de piezas
            Pieza TorreNegra1 = new Pieza(1, TipoPieza.Torre, "negra", 1, 1);
            Pieza CaballoNegro1 = new Pieza(2, TipoPieza.Caballo, "negra", 1, 2);
            Pieza AlfilNegro1 = new Pieza(3, TipoPieza.Alfil, "negra", 1, 3);
            Pieza ReinaNegra1 = new Pieza(4, TipoPieza.Reina, "negra", 1, 4);
            Pieza ReyNegro1 = new Pieza(5, TipoPieza.Rey, "negra", 1, 5);

            Pieza TorreBlanca1 = new Pieza(6, TipoPieza.Torre, "blanca", 8, 1);

            //List<Posiciones> posiciones = new List<Posiciones>();

            List<Pieza> piezas = new List<Pieza>();
            piezas.Add(TorreNegra1);

            piezas.Add(CaballoNegro1);
            piezas.Add(AlfilNegro1);
            piezas.Add(ReinaNegra1);
            piezas.Add(ReyNegro1);
            piezas.Add(TorreBlanca1);

            dibujarTablero(filasLetras, filas, columnas, null, piezas);

            while (true)
            {
                //Siempre le daba el valor nuevo al mismo objeto
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Eleji la pieza que quieras mover:");
                Console.WriteLine("---------------------------------");
                listadoPiezas(piezas);
                var selectPieza = Console.ReadLine();
                var piezaMover = piezas.Find(x => x.Id == int.Parse(selectPieza));


                Console.WriteLine("---------------------------------");
                Console.WriteLine("Eleji tus coordenadas A-H:");
                Console.WriteLine("---------------------------------");
                var coLetras = Console.ReadLine();
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Eleji tus coordenadas 1-8:");
                Console.WriteLine("---------------------------------");
                var coNumeros = Console.ReadLine();


                var nuevaPosicion = new Posicion(letrasANumeros(coLetras), int.Parse(coNumeros), DateTime.Now);




                if (caminoLibre(piezaMover, nuevaPosicion.PosY, nuevaPosicion.PosX, piezas))
                {
                    piezaMover.Movimientos.Add(nuevaPosicion);
                }


                else
                {

                    Console.Clear();
                    //ConsoleColor newForeColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No es posible moverse aqui");
                }


                //Console.ReadKey();
                //Console.Clear();
                dibujarTablero(filasLetras, filas, columnas, piezaMover, piezas);

            }

        }

        public static void listadoPiezas(List<Pieza> piezas)
        {
            foreach (var item in piezas)
            {
                Console.WriteLine(item.Id + "-" + item.TipoPieza);
            }
            Console.WriteLine("---------------------------------");
        }

        public static Pieza hayPieza(int posY, int posX, List<Pieza> listadoPiezas)
        {
            var hayPiezaEnCasillero = listadoPiezas.FirstOrDefault(x => x.Movimientos.Any(c => c.PosX == posX && c.PosY == posY));

            if (hayPiezaEnCasillero != null)
            {
                return hayPiezaEnCasillero;
            }
            return null;
        }

        public static void comerPieza(Pieza pieza, List<Pieza> listPieza)
        {
            listPieza.Remove(pieza);
        }

        public static int letrasANumeros(string coLetras)
        {
            switch (coLetras)
            {
                case "A":
                    return 1;
                case "B":
                    return 2;
                case "C":
                    return 3;
                case "D":
                    return 4;
                case "E":
                    return 5;
                case "F":
                    return 6;
                case "G":
                    return 7;
                case "H":
                    return 8;

                default:
                    return 99;
            }
        }

        public static bool caminoLibre(Pieza piezaAMover, int posY, int posX, List<Pieza> listadoPiezas)
        {
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
        public static void dibujarTablero(string[] filasLetras, int[] filas, int[] columnas, Pieza pieza, List<Pieza> piezasList)
        {
            //Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < filas.Length; i++)
            {
                //Primera linea coordenadas letras
                Console.Write(filasLetras[i] + "-");
                for (int x = 0; x < columnas.Length; x++)
                {


                    if (coincide(piezasList, columnas[x], filas[i]))
                    {

                        //Console.Write(piesita.TipoPieza);
                        //Console.Write("X ");
                    }
                    else
                    {
                        Console.Write("0 ");
                    }

                }
                //Ultima lineas coordenadas numeros
                if (i == 7)
                {
                    Console.WriteLine();
                    Console.Write("- ");
                    foreach (var item in columnas)
                    {
                        Console.Write(item + " ");
                    }
                }
                Console.WriteLine();
            }

        }
        public static bool coincide(List<Pieza> piezas, int fila, int columna)
        {
            if (piezas.Count > 0 && piezas != null)
            {

                foreach (var pieza in piezas)
                {

                    if (pieza.Movimientos != null && pieza.Movimientos.Count > 0)
                    {
                        var ultimoMovimiento = pieza.Movimientos.OrderByDescending(x => x.Tiempo).FirstOrDefault();


                        if (columna == ultimoMovimiento.PosY && fila == ultimoMovimiento.PosX)
                        {
                            Console.Write(pieza.TipoPieza.ToString()[0] + " ");
                            return true;
                        }
                        //else
                        //Console.Write("0 ");

                        //Console.Write("0 ");
                    }
                    //return false;
                }
            }
            return false;

        }
    }
}
