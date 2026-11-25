using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace SzyfrowanieOkno
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PrzyciskZaszyfruj_Click(object sender, RoutedEventArgs e)
        {
            int klucz;
            if (!int.TryParse(poleKlucza.Text, out klucz))
            {
                klucz = 0;
            }

            string tekstJawny = poleTekstu.Text;
            poleZaszyfrowane.Text = SzyfrCezara.Zaszyfruj(tekstJawny, klucz);
        }

        private void PrzyciskZapisz_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog oknoZapisu = new SaveFileDialog();
            oknoZapisu.Filter = "Pliki tekstowe (*.txt)|*.txt|Wszystkie pliki (*.*)|*.*";

            if (oknoZapisu.ShowDialog() == true)
            {
                File.WriteAllText(oknoZapisu.FileName, poleZaszyfrowane.Text);
            }
        }
    }
}