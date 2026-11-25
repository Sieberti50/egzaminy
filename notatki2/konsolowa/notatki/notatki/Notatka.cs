using System;

namespace notatki
{
    class Notatka
    {
        public string Tytul;
        public string Tresc;
        public bool Wazna;
        public DateTime DataDodania;

        public Notatka(string tytul, string tresc, bool wazna)
        {
            Tytul = tytul;
            Tresc = tresc;
            Wazna = wazna;
            DataDodania = DateTime.Now;
        }

        public Notatka(string tytul)
        {
            Tytul = tytul;
            Tresc = "";
            Wazna = false;
            DataDodania = DateTime.Now;
        }

        /*
        nazwa: Wypisz
        opis: Wypisuje notatke na ekranie: tytul (z napisem WAZNA, jesli notatka jest wazna), tresc i date dodania, miedzy dwiema liniami z podkreslnikow
        parametry: brak
        zwracany typ: brak
        autor: Filip Siebert
        */
        public void Wypisz()
        {
            Console.WriteLine("________________________");
            if (Wazna)
            {
                Console.WriteLine("Notatka WAŻNA! " + Tytul);
            }
            else
            {
                Console.WriteLine("Notatka " + Tytul);
            }
            Console.WriteLine(Tresc);
            Console.WriteLine(DataDodania.ToString("dd.MM.yyyy HH:mm:ss"));
            Console.WriteLine("________________________");
        }
    }
}