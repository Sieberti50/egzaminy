using System;
using System.Text;

namespace SprawdzaniePesel
{
    class Program
    {
        /**********************************************
        nazwa funkcji: SprawdzPlec
        opis funkcji: sprawdza plec na podstawie 10. cyfry numeru PESEL
        parametry: pesel - numer PESEL zapisany jako tekst
        zwracany typ i opis: char - 'K' dla kobiety, 'M' dla mezczyzny
        autor: Filip Siebert
        ***********************************************/
        static char SprawdzPlec(string pesel)
        {
            int cyfraPlci = pesel[9] - '0';

            if (cyfraPlci % 2 == 0)
            {
                return 'K';
            }
            return 'M';
        }

        /**********************************************
        nazwa funkcji: SprawdzSumeKontrolna
        opis funkcji: oblicza sume kontrolna numeru PESEL i porownuje ja z 11. cyfra
        parametry: pesel - numer PESEL zapisany jako tekst
        zwracany typ i opis: bool - true gdy suma jest zgodna, false gdy niezgodna
        autor: Filip Siebert
        ***********************************************/
        static bool SprawdzSumeKontrolna(string pesel)
        {
            int[] wagi = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            int S = 0;

            for (int i = 0; i < 10; i++)
            {
                int cyfra = pesel[i] - '0';
                S = S + cyfra * wagi[i];
            }

            int M = S % 10;
            int R;

            if (M == 0)
            {
                R = 0;
            }
            else
            {
                R = 10 - M;
            }

            int jedenastaCyfra = pesel[10] - '0';
            return R == jedenastaCyfra;
        }

        static bool CzyPoprawnyFormat(string pesel)
        {
            if (pesel.Length != 11)
            {
                return false;
            }

            foreach (char znak in pesel)
            {
                if (znak < '0' || znak > '9')
                {
                    return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string pesel = "55030101193";

            Console.Write("Podaj numer PESEL: ");
            pesel = Console.ReadLine().Trim();

            if (!CzyPoprawnyFormat(pesel))
            {
                Console.WriteLine("Numer PESEL musi składać się z 11 cyfr.");
                return;
            }

            char plec = SprawdzPlec(pesel);
            if (plec == 'K')
            {
                Console.WriteLine("Płeć: Kobieta");
            }
            else
            {
                Console.WriteLine("Płeć: Mężczyzna");
            }

            if (SprawdzSumeKontrolna(pesel))
            {
                Console.WriteLine("Suma kontrolna jest zgodna.");
            }
            else
            {
                Console.WriteLine("Suma kontrolna jest niezgodna.");
            }
        }
    }
}