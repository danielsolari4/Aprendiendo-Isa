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

            //Creacion de tablero

            //Creacion de piezas
            Pieza TorreNegra1 = new Torre(1, TipoPieza.Torre, "negra", 1, 1);
            //Pieza CaballoNegro1 = new Caballo(2, TipoPieza.Caballo, "negra", 1, 2);
            Pieza AlfilNegro1 = new Alfil(3, TipoPieza.Alfil, "negra", 1, 3);
            //Pieza ReinaNegra1 = new Pieza(4, TipoPieza.Reina, "negra", 1, 4);
            //Pieza ReyNegro1 = new Pieza(5, TipoPieza.Rey, "negra", 1, 5);
            Pieza TorreBlanca1 = new Torre(6, TipoPieza.Torre, "blanca", 8, 1);

            //List<Posiciones> posiciones = new List<Posiciones>(); 

            List<Pieza> piezas = new List<Pieza>();
            piezas.Add(TorreNegra1);

            //piezas.Add(CaballoNegro1);
            piezas.Add(AlfilNegro1);
            //piezas.Add(ReinaNegra1);
            //piezas.Add(ReyNegro1);
            piezas.Add(TorreBlanca1);


            Tablero tablero = new Tablero(piezas);

            Console.WriteLine("Tablero de Ajedrez");
            Console.WriteLine("------------------");

            tablero.DibujarTablero(tablero.Filas, tablero.Columnas, null, piezas);

            while (true)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Eleji la pieza que quieras mover:");
                Console.WriteLine("---------------------------------");
                Tablero.ListadoPiezasMenu(piezas);

                var selectPieza = Console.ReadLine();
                var piezaMover = Tablero.GetPiezaById(int.Parse(selectPieza), piezas);


                Console.WriteLine("---------------------------------");
                Console.WriteLine("Eleji tus coordenadas A-H:");
                Console.WriteLine("---------------------------------");
                var coLetras = Console.ReadLine();
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Eleji tus coordenadas 1-8:");
                Console.WriteLine("---------------------------------");
                var coNumeros = Console.ReadLine();


                var nuevaPosicion = new Posicion(tablero.LetrasANumeros(coLetras), int.Parse(coNumeros), DateTime.Now);


                if (piezaMover.Mover(nuevaPosicion.PosY, nuevaPosicion.PosX, piezas))
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

                tablero.DibujarTablero(tablero.Filas, tablero.Columnas, piezaMover, piezas);

            }

        }







    }
}
