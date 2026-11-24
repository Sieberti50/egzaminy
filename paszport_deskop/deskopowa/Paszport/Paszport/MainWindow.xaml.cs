using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Paszport
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UstawObrazy("000");
        }

        private BitmapImage WczytajObraz(string nazwaPliku)
        {
            string sciezka = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, nazwaPliku);

            if (!File.Exists(sciezka))
            {
                return null;
            }

            BitmapImage obraz = new BitmapImage();
            obraz.BeginInit();
            obraz.CacheOption = BitmapCacheOption.OnLoad;
            obraz.UriSource = new Uri(sciezka);
            obraz.EndInit();
            return obraz;
        }

        private void UstawObrazy(string numer)
        {
            imgZdjecie.Source = WczytajObraz(numer + "-zdjecie.jpg");
            imgOdcisk.Source = WczytajObraz(numer + "-odcisk.jpg");
        }

        private string PobierzKolorOczu()
        {
            if (rbZielone.IsChecked == true)
            {
                return "zielone";
            }
            if (rbPiwne.IsChecked == true)
            {
                return "piwne";
            }
            return "niebieskie";
        }

        private void txtNumer_LostFocus(object sender, RoutedEventArgs e)
        {
            UstawObrazy(txtNumer.Text.Trim());
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            string numer = txtNumer.Text.Trim();
            string imie = txtImie.Text.Trim();
            string nazwisko = txtNazwisko.Text.Trim();

            if (numer == "" || imie == "" || nazwisko == "")
            {
                MessageBox.Show("Wprowadź dane");
                return;
            }

            string kolor = PobierzKolorOczu();
            MessageBox.Show(imie + " " + nazwisko + " kolor oczu " + kolor);
        }
    }
}