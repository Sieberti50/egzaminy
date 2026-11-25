using System;
using System.Text;

namespace SzyfrCezaraKonsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Szyfr Cezara");
            Console.WriteLine("Program szyfruje tekst składający się z małych liter i spacji.");
            Console.WriteLine();

            Console.Write("Podaj tekst do zaszyfrowania: ");
            string tekstJawny = Console.ReadLine();

            int klucz;
            Console.Write("Podaj klucz (liczba całkowita): ");
            while (!int.TryParse(Console.ReadLine(), out klucz))
            {
                Console.Write("To nie jest liczba całkowita. Podaj klucz ponownie: ");
            }

            string tekstZaszyfrowany = SzyfrCezara.Zaszyfruj(tekstJawny, klucz);

            Console.WriteLine();
            Console.WriteLine("Tekst zaszyfrowany: " + tekstZaszyfrowany);
            Console.WriteLine();
            Console.WriteLine("Naciśnij dowolny klawisz, aby zakończyć...");
            Console.ReadKey();
        }
    }
}