using System;
using System.Windows;

namespace DodajPracownika
{
    public partial class MainWindow : Window
    {
        private string malelitery = "abcdefghijklmnopqrstuvwxyz";
        private string wielkieLitery = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private string cyfry = "0123456789";
        private string znakiSpecjalne = "!@#$%^&*()_+-=";
        private string haslo = "";
        private Random losowanie = new Random();

        public MainWindow()
        {
            InitializeComponent();
            StanowiskoComboBox.Items.Add("Kierownik");
            StanowiskoComboBox.Items.Add("Starszy programista");
            StanowiskoComboBox.Items.Add("Młodszy programista");
            StanowiskoComboBox.Items.Add("Tester");
        }

        private void GenerujHasloButton_Click(object sender, RoutedEventArgs e)
        {
            int liczbaZnakow = int.Parse(IleZnakowTextBox.Text);
            char[] znaki = new char[liczbaZnakow];

            for (int i = 0; i < liczbaZnakow; i++)
            {
                znaki[i] = malelitery[losowanie.Next(malelitery.Length)];
            }

            if (LiteryCheckBox.IsChecked == true)
            {
                znaki[0] = wielkieLitery[losowanie.Next(wielkieLitery.Length)];
            }

            if (CyfryCheckBox.IsChecked == true)
            {
                znaki[1] = cyfry[losowanie.Next(cyfry.Length)];
            }

            if (ZnakiSpecjalneCheckBox.IsChecked == true)
            {
                znaki[2] = znakiSpecjalne[losowanie.Next(znakiSpecjalne.Length)];
            }

            haslo = new string(znaki);
            MessageBox.Show(haslo);
        }

        private void ZatwierdzButton_Click(object sender, RoutedEventArgs e)
        {
            string imie = ImieTextBox.Text;
            string nazwisko = NazwiskoTextBox.Text;
            string stanowisko = StanowiskoComboBox.Text;

            MessageBox.Show("Dane pracownika: " + imie + " " + nazwisko + " " + stanowisko + " Hasło: " + haslo);
        }
    }
}