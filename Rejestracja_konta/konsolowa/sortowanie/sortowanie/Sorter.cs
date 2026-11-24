using System;

namespace Sortowanie
{
    class Sortownik
    {
        private int[] liczby = new int[10];

        public void WczytajLiczby()
        {
            Console.WriteLine("Podaj 10 liczb całkowitych:");
            for (int i = 0; i < liczby.Length; i++)
            {
                Console.Write("Liczba " + (i + 1) + ": ");
                liczby[i] = int.Parse(Console.ReadLine() ?? "0");
            }
        }

        /********************************************************
        * nazwa funkcji: SortujMalejaco
        * parametry wejściowe: brak
        * wartość zwracana: brak (funkcja sortuje tablicę liczby malejąco)
        * autor: 12345678901
        * ****************************************************/
        public void SortujMalejaco()
        {
            for (int i = 0; i < liczby.Length - 1; i++)
            {
                int indeksMaksimum = ZnajdzIndeksMaksimum(i);
                int pomocnicza = liczby[i];
                liczby[i] = liczby[indeksMaksimum];
                liczby[indeksMaksimum] = pomocnicza;
            }
        }

        /********************************************************
        * nazwa funkcji: ZnajdzIndeksMaksimum
        * parametry wejściowe: indeksStartowy - indeks, od którego zaczyna się szukanie
        * wartość zwracana: indeks największej wartości w tablicy od indeksStartowy do końca
        * autor: 12345678901
        * ****************************************************/
        private int ZnajdzIndeksMaksimum(int indeksStartowy)
        {
            int indeksMaksimum = indeksStartowy;
            for (int i = indeksStartowy + 1; i < liczby.Length; i++)
            {
                if (liczby[i] > liczby[indeksMaksimum])
                {
                    indeksMaksimum = i;
                }
            }
            return indeksMaksimum;
        }

        public void WypiszLiczby()
        {
            Console.WriteLine("Tablica posortowana malejąco:");
            for (int i = 0; i < liczby.Length; i++)
            {
                Console.Write(liczby[i] + " ");
            }
            Console.WriteLine();
        }
    }
}