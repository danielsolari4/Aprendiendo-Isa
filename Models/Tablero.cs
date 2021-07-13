using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aprendiendo_Isa.Models
{
    class Tablero
    {
        public int Id { get; set; }
        public int[] Columnas{ get; set; }
        public int[] Filas { get; set; }
        public List<Pieza> ListadoPiezas { get; set; }

        public Tablero(List<Pieza> _listadoPiezas)
        {
            this.Columnas = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }; ;
            this.Filas = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }; ;
            this.ListadoPiezas = _listadoPiezas;
        }

        public void DibujarTablero(int[] filas, int[] columnas, Pieza pieza, List<Pieza> piezasList)
        {
            //Console.Clear();

            string[] filasLetras = new string[] { "A","B", "C", "D", "E", "F", "G", "H"};

            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < filas.Length; i++)
            {
                //Primera linea coordenadas letras
                Console.Write(filasLetras[i] + "-");
                for (int x = 0; x < columnas.Length; x++)
                {


                    if (!Coincide(piezasList, columnas[x], filas[i]))
                        Console.Write("0 ");

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
        public bool Coincide(List<Pieza> piezas, int fila, int columna)
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
                    }
                }
            }
            return false;

        }
        public bool CaminoLibre(int posY,int posX)
        {
            //Logica busqueda pieza
            return true;
        }
        public static Pieza GetPiezaById(int id, List<Pieza> ListadoPiezas)
        {
            return ListadoPiezas.FirstOrDefault(x => x.Id == id);
        }
        public static Pieza HayPieza(int posY, int posX, List<Pieza> listadoPiezas)
        {
            var hayPiezaEnCasillero = listadoPiezas.FirstOrDefault(x => x.Movimientos.OrderByDescending(h => h.Tiempo).Any(c => c.PosX == posX && c.PosY == posY));

            if (hayPiezaEnCasillero != null)
            {
                return hayPiezaEnCasillero;
            }
            return null;
        }
        public int LetrasANumeros(string coLetras)
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
        public static void ListadoPiezasMenu(List<Pieza> piezas)
        {
            foreach (var item in piezas)
            {
                Console.WriteLine(item.Id + "-" + item.TipoPieza);
            }
            Console.WriteLine("---------------------------------");
        }
    }
}
