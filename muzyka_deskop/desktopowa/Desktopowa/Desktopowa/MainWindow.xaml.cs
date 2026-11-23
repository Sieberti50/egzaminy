using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace Desktopowa
{
    public partial class MainWindow : Window
    {
        private List<Album> albums = new List<Album>();
        private int currentIndex = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private List<Album> LoadAlbums(string path)
        {
            List<Album> loadedAlbums = new List<Album>();
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
                loadedAlbums.Add(album);
            }

            return loadedAlbums;
        }

        private void ShowAlbum()
        {
            Album album = albums[currentIndex];
            ArtistLabel.Content = album.Artist;
            TitleLabel.Content = album.Title;
            SongsLabel.Content = album.SongsNumber + " utworów";
            YearLabel.Content = album.Year;
            DownloadsLabel.Content = album.DownloadNumber;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            albums = LoadAlbums("Data.txt");
            currentIndex = 0;
            ShowAlbum();
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = albums.Count - 1;
            }
            ShowAlbum();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            currentIndex++;
            if (currentIndex >= albums.Count)
            {
                currentIndex = 0;
            }
            ShowAlbum();
        }

        private void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            albums[currentIndex].DownloadNumber++;
            ShowAlbum();
        }
    }
}