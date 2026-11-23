using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Konsola
{
    class Program
    {
        /**********************************************
        nazwa funkcji: LoadAlbums
        opis funkcji: wczytuje z pliku wszystkie albumy muzyczne (po 5 linii na album) i zapisuje je na liście
        parametry: path - tekst, ścieżka do pliku z danymi
        zwracany typ i opis: List<Album> - lista wszystkich wczytanych albumów
        autor: 
        ***********************************************/
        static List<Album> LoadAlbums(string path)
        {
            List<Album> albums = new List<Album>();
            List<string> lines = new List<string>();

            foreach (string line in File.ReadAllLines(path, Encoding.UTF8))
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    lines.Add(line);
                }
            }

            for (int i = 0; i + 4 < lines.Count; i += 5)
            {
                Album album = new Album();
                album.Artist = lines[i];
                album.Title = lines[i + 1];
                album.SongsNumber = int.Parse(lines[i + 2]);
                album.Year = int.Parse(lines[i + 3]);
                album.DownloadNumber = long.Parse(lines[i + 4]);
                albums.Add(album);
            }

            return albums;
        }

        static void ShowAlbums(List<Album> albums)
        {
            foreach (Album album in albums)
            {
                Console.WriteLine(album.Artist);
                Console.WriteLine(album.Title);
                Console.WriteLine(album.SongsNumber);
                Console.WriteLine(album.Year);
                Console.WriteLine(album.DownloadNumber);
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            List<Album> albums = LoadAlbums("Data.txt");
            ShowAlbums(albums);
            Console.ReadKey();
        }
    }
}