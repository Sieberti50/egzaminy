using System;

internal class TestSortowania
{
    public static void Uruchom()
    {
        Random generator = new Random();
        int[] liczbyDoTestu = new int[100];

        for (int i = 0; i < liczbyDoTestu.Length; i++)
        {
            liczbyDoTestu[i] = generator.Next(0, 1001);
        }

        Console.WriteLine("TEST: tablica przed sortowaniem:");
        for (int i = 0; i < liczbyDoTestu.Length; i++)
        {
            Console.Write(liczbyDoTestu[i] + "; ");
        }
        Console.WriteLine();
        Console.WriteLine();

        Program.SortujBabelkowo(liczbyDoTestu);

        Console.WriteLine("TEST: tablica po sortowaniu:");
        for (int i = 0; i < liczbyDoTestu.Length; i++)
        {
            Console.Write(liczbyDoTestu[i] + "; ");
        }
        Console.WriteLine();
        Console.WriteLine();

        bool tablicaPosortowana = true;
        for (int i = 0; i < liczbyDoTestu.Length - 1; i++)
        {
            if (liczbyDoTestu[i] > liczbyDoTestu[i + 1])
            {
                tablicaPosortowana = false;
            }
        }

        if (tablicaPosortowana)
        {
            Console.WriteLine("WYNIK TESTU: pozytywny, tablica jest posortowana rosnaco.");
        }
        else
        {
            Console.WriteLine("WYNIK TESTU: negatywny, tablica nie jest posortowana.");
        }
    }
}