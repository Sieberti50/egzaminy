using System;

namespace konsola
{
    class Program
    {
        /**********************************************
        nazwa funkcji: ObliczNwd
        opis funkcji: Oblicza największy wspólny dzielnik dwóch liczb algorytmem Euklidesa
        parametry: a – pierwsza liczba całkowita dodatnia
                   b – druga liczba całkowita dodatnia
        zwracany typ i opis: int – największy wspólny dzielnik liczb a i b
        autor: Filip Siebert
        ***********************************************/
        static int ObliczNwd(int a, int b)
        {
            while (a != b)
            {
                if (a > b)
                {
                    a = a - b;
                }
                else
                {
                    b = b - a;
                }
            }
            return a;
        }

        static int WczytajLiczbeDodatnia(string tekst)
        {
            int liczba;
            Console.Write(tekst);
            while (!int.TryParse(Console.ReadLine(), out liczba) || liczba <= 0)
            {
                Console.Write("Błędna wartość. Podaj liczbę całkowitą dodatnią: ");
            }
            return liczba;
        }

        static void Main(string[] args)
        {
            int a = WczytajLiczbeDodatnia("Podaj liczbę a: ");
            int b = WczytajLiczbeDodatnia("Podaj liczbę b: ");

            int nwd = ObliczNwd(a, b);

            Console.WriteLine("NWD(" + a + ", " + b + ") = " + nwd);
            Console.ReadKey();
        }
    }
}