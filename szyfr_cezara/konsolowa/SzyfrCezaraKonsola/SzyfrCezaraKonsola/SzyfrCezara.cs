using System.Text;

namespace SzyfrCezaraKonsola
{
    public class SzyfrCezara
    {
        private const int DlugoscAlfabetu = 26;

        public static string Zaszyfruj(string tekstJawny, int klucz)
        {
            int przesuniecie = ((klucz % DlugoscAlfabetu) + DlugoscAlfabetu) % DlugoscAlfabetu;
            StringBuilder wynik = new StringBuilder();

            foreach (char znak in tekstJawny)
            {
                if (znak >= 'a' && znak <= 'z')
                {
                    int pozycja = znak - 'a';
                    int nowaPozycja = (pozycja + przesuniecie) % DlugoscAlfabetu;
                    wynik.Append((char)('a' + nowaPozycja));
                }
                else
                {
                    wynik.Append(znak);
                }
            }

            return wynik.ToString();
        }
    }
}