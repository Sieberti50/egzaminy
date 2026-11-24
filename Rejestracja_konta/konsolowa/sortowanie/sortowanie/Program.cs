using System;

namespace Sortowanie
{
    class Program
    {
        static void Main(string[] args)
        {
            Sortownik sortownik = new Sortownik();
            sortownik.WczytajLiczby();
            sortownik.SortujMalejaco();
            sortownik.WypiszLiczby();
            Console.ReadKey();
        }
    }
}