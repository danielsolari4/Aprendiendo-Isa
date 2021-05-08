using Aprendiendo_Isa.Models;
using System;
using System.Collections.Generic;

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


            var Torre = new Pieza(3);
            Torre.tipo = 0;

            List<Posiciones> posiciones = new List<Posiciones>();

            dibujarTablero(filasLetras, filas, columnas, null);

            while (true)
            {
                //Siempre le daba el valor nuevo al mismo objeto
                Posiciones pos = new Posiciones();
                Console.WriteLine("Eleji tus coordenadas A-H:");
                var coLetras = Console.ReadLine();
                Console.WriteLine("Eleji tus coordenadas 1-8:");
                var coNumeros = Console.ReadLine();

                pos.posFila = letrasANumeros(coLetras);
                pos.posColumna = int.Parse(coNumeros);
                posiciones.Add(pos);

                dibujarTablero(filasLetras, filas, columnas, posiciones);
            }

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
        public static void dibujarTablero(string[] filasLetras, int[] filas, int[] columnas, List<Posiciones> posiciones)
        {
            for (int i = 0; i < filas.Length; i++)
            {
                //Primera linea coordenadas letras
                Console.Write(filasLetras[i] + "-");
                for (int x = 0; x < columnas.Length; x++)
                {
                    if (coincide(posiciones, filas[i], columnas[x]))
                    {
                        Console.Write("X ");
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
        public static bool coincide(List<Posiciones> posiciones, int fila, int columna)
        {

            if (posiciones != null && posiciones.Count > 0)
            {
                foreach (var item in posiciones)
                {
                    if (columna == item.posColumna && fila == item.posFila)
                    {
                        return true;
                    }
                    //else
                    //Console.Write("0 ");
                }
                //Console.Write("0 ");
            }
            return false;
        }
    }
}
