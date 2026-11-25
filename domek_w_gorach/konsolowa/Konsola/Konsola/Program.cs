using System;

namespace Konsola
{
    class Program
    {
        const int RozmiarTablicy = 50;

        static void WypelnijTablice(int[] tablica, int rozmiar)
        {
            Random generator = new Random();
            for (int i = 0; i < rozmiar; i++)
            {
                tablica[i] = generator.Next(1, 101);
            }
        }

        /******************************************************
         nazwa funkcji: WyszukajZWartownikiem
         argumenty: tablica - tablica liczb całkowitych, w której szukamy (ma jedno wolne miejsce na końcu na wartownika)
                    rozmiar - ile liczb zawiera tablica (bez miejsca na wartownika)
                    szukanaWartosc - liczba, której szukamy
         typ zwracany: int, indeks pierwszego znalezionego elementu lub -1, gdy elementu nie ma w tablicy
         informacje: funkcja realizuje algorytm przeszukiwania tablicy z wartownikiem
         autor: Filip Siebert
        *****************************************************/
        static int WyszukajZWartownikiem(int[] tablica, int rozmiar, int szukanaWartosc)
        {
            tablica[rozmiar] = szukanaWartosc;

            int indeks = 0;
            while (tablica[indeks] != szukanaWartosc)
            {
                indeks++;
            }

            if (indeks == rozmiar)
            {
                return -1;
            }
            return indeks;
        }

        static void WyswietlTablice(int[] tablica, int rozmiar)
        {
            Console.WriteLine("Zawartość tablicy:");
            for (int i = 0; i < rozmiar; i++)
            {
                Console.Write(tablica[i]);
                if (i < rozmiar - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine();
        }

        static int PobierzLiczbeOdUzytkownika()
        {
            int liczba;
            Console.Write("Podaj liczbę do wyszukania (od 1 do 100): ");
            while (!int.TryParse(Console.ReadLine(), out liczba))
            {
                Console.Write("To nie jest liczba całkowita. Spróbuj jeszcze raz: ");
            }
            return liczba;
        }

        static void TestAplikacji()
        {
            int[] tablicaTestowa = new int[6] { 4, 9, 7, 9, 2, 0 };
            int rozmiarTestowy = 5;

            int wynikPierwszy = WyszukajZWartownikiem(tablicaTestowa, rozmiarTestowy, 9);
            int wynikBrak = WyszukajZWartownikiem(tablicaTestowa, rozmiarTestowy, 50);
            int wynikPoczatek = WyszukajZWartownikiem(tablicaTestowa, rozmiarTestowy, 4);
            int wynikKoniec = WyszukajZWartownikiem(tablicaTestowa, rozmiarTestowy, 2);

            Console.WriteLine("--- Test działania aplikacji ---");
            Console.WriteLine("Tablica testowa: 4, 9, 7, 9, 2");
            Console.WriteLine("Szukam 9 (pierwsze wystąpienie), oczekiwany indeks 1, otrzymano: " + wynikPierwszy);
            Console.WriteLine("Szukam 50 (brak w tablicy), oczekiwano -1, otrzymano: " + wynikBrak);
            Console.WriteLine("Szukam 4 (pierwszy element), oczekiwany indeks 0, otrzymano: " + wynikPoczatek);
            Console.WriteLine("Szukam 2 (ostatni element), oczekiwany indeks 4, otrzymano: " + wynikKoniec);

            if (wynikPierwszy == 1 && wynikBrak == -1 && wynikPoczatek == 0 && wynikKoniec == 4)
            {
                Console.WriteLine("Test zakończony powodzeniem.");
            }
            else
            {
                Console.WriteLine("Test zakończony niepowodzeniem.");
            }
            Console.WriteLine("--------------------------------");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            TestAplikacji();

            int[] tablica = new int[RozmiarTablicy + 1];
            WypelnijTablice(tablica, RozmiarTablicy);

            int szukanaWartosc = PobierzLiczbeOdUzytkownika();
            int indeks = WyszukajZWartownikiem(tablica, RozmiarTablicy, szukanaWartosc);

            WyswietlTablice(tablica, RozmiarTablicy);

            if (indeks == -1)
            {
                Console.WriteLine("Liczby " + szukanaWartosc + " nie ma w tablicy.");
            }
            else
            {
                Console.WriteLine("Liczba " + szukanaWartosc + " została znaleziona pod indeksem: " + indeks + " (numeracja od 0).");
            }

            Console.WriteLine("Naciśnij dowolny klawisz, aby zakończyć.");
            Console.ReadKey();
        }
    }
}