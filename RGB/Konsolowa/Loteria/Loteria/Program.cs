using System;

namespace Loteria
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int drawCount = ReadDrawCount();
            int[,] draws = new int[drawCount, 6];
            Random random = new Random();

            FillDraws(draws, random);
            ShowDraws(draws);

            int[] occurrences = CountOccurrences(draws);
            ShowOccurrences(occurrences);

            Console.ReadKey();
        }

        static int ReadDrawCount()
        {
            int drawCount;

            Console.WriteLine("Ile wygenerować losowań?");
            while (!int.TryParse(Console.ReadLine(), out drawCount) || drawCount < 1)
            {
                Console.WriteLine("Podaj poprawną liczbę całkowitą większą od zera:");
            }

            return drawCount;
        }

        // **********************************************
        // nazwa funkcji:     FillDraws
        // opis funkcji:      wypełnia tablicę losowymi liczbami od 1 do 49, w jednym losowaniu liczby się nie powtarzają
        // parametry:         draws - dwuwymiarowa tablica na wyniki losowań (n wierszy, 6 kolumn)
        //                    random - obiekt do generowania liczb pseudolosowych
        // zwracany typ i opis: brak
        // autor:             Filip Siebert
        // **********************************************
        static void FillDraws(int[,] draws, Random random)
        {
            for (int row = 0; row < draws.GetLength(0); row++)
            {
                for (int column = 0; column < 6; column++)
                {
                    int number;
                    bool alreadyDrawn;

                    do
                    {
                        number = random.Next(1, 50);
                        alreadyDrawn = false;

                        for (int previous = 0; previous < column; previous++)
                        {
                            if (draws[row, previous] == number)
                            {
                                alreadyDrawn = true;
                            }
                        }
                    }
                    while (alreadyDrawn);

                    draws[row, column] = number;
                }
            }
        }

        static void ShowDraws(int[,] draws)
        {
            Console.WriteLine("Zestawy wylosowanych liczb:");

            for (int row = 0; row < draws.GetLength(0); row++)
            {
                Console.Write("Losowanie " + (row + 1) + ":");

                for (int column = 0; column < 6; column++)
                {
                    Console.Write(" " + draws[row, column]);
                }

                Console.WriteLine();
            }
        }

        static int[] CountOccurrences(int[,] draws)
        {
            int[] occurrences = new int[50];

            for (int row = 0; row < draws.GetLength(0); row++)
            {
                for (int column = 0; column < 6; column++)
                {
                    occurrences[draws[row, column]]++;
                }
            }

            return occurrences;
        }

        static void ShowOccurrences(int[] occurrences)
        {
            for (int number = 1; number <= 49; number++)
            {
                Console.WriteLine("Wystąpienia liczby " + number + ": " + occurrences[number]);
            }
        }
    }
}