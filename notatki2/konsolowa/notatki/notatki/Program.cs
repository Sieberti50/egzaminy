using notatki;
using System;

namespace notatki
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Notatka pierwszaNotatka = new Notatka("tenis", "Gra z Ewą w poniedziałek", true);

            Console.WriteLine("Podaj tytuł notatki:");
            string tytul = Console.ReadLine();
            Notatka drugaNotatka = new Notatka(tytul);

            pierwszaNotatka.Wypisz();
            drugaNotatka.Wypisz();

            Console.ReadKey();
        }
    }
}