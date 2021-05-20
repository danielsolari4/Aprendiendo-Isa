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

            string[] filasLetras = new string[] { "A", "B", "C", "D", "E", "F", "G", "H" };
            int[] filas = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            int[] columnas = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            //Creacion de piezas
            Pieza TorreNegra1 = new Pieza(1,TipoPieza.Torre, "negra", 1, 1);
            Pieza CaballoNegro1 = new Pieza(2,TipoPieza.Caballo, "negra", 1, 2);


            //List<Posiciones> posiciones = new List<Posiciones>();

            List<Pieza> piezas = new List<Pieza>();
            piezas.Add(TorreNegra1);
            piezas.Add(CaballoNegro1);

            dibujarTablero(filasLetras, filas, columnas, null, piezas);

            while (true)
            {
                //Siempre le daba el valor nuevo al mismo objeto

                Console.WriteLine("Eleji la pieza que quieras mover:");

                listadoPiezas(piezas);

                var selectPieza = Console.ReadLine();
                var piezaMover = piezas.Find(x => x.Id == int.Parse(selectPieza));


                Console.WriteLine("Eleji tus coordenadas A-H:");
                var coLetras = Console.ReadLine();
                Console.WriteLine("Eleji tus coordenadas 1-8:");
                var coNumeros = Console.ReadLine();

                piezaMover.Movimientos.Add(new Posicion(letrasANumeros(coLetras), int.Parse(coNumeros), DateTime.Now));

                dibujarTablero(filasLetras, filas, columnas, piezaMover, piezas);

            }

        }

        public static void listadoPiezas(List<Pieza> piezas)
        {
            foreach (var item in piezas)
            {
                Console.WriteLine(item.Id + "-" + item.TipoPieza);
            }
        }


        public static void moverPieza(Pieza pieza, int posY, int posX)
        {
            pieza.Movimientos.Add(new Posicion(posX, posY, DateTime.Now));
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
        public static void dibujarTablero(string[] filasLetras, int[] filas, int[] columnas, Pieza pieza, List<Pieza> piezasList)
        {
            for (int i = 0; i < filas.Length; i++)
            {
                //Primera linea coordenadas letras
                Console.Write(filasLetras[i] + "-");
                for (int x = 0; x < columnas.Length; x++)
                {


                    if (coincide(piezasList, filas[i], columnas[x]))
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
                            Console.Write(pieza.TipoPieza.ToString()[0]+" ");
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
