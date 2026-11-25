using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Wzornik
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private Color GetSelectedColor()
        {
            byte red = (byte)Math.Round(sliderRed.Value);
            byte green = (byte)Math.Round(sliderGreen.Value);
            byte blue = (byte)Math.Round(sliderBlue.Value);

            return Color.FromRgb(red, green, blue);
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!IsLoaded)
            {
                return;
            }

            labelRed.Text = Math.Round(sliderRed.Value).ToString();
            labelGreen.Text = Math.Round(sliderGreen.Value).ToString();
            labelBlue.Text = Math.Round(sliderBlue.Value).ToString();

            bigRectangle.Fill = new SolidColorBrush(GetSelectedColor());
        }

        private void buttonTake_Click(object sender, RoutedEventArgs e)
        {
            labelTaken.Background = new SolidColorBrush(GetSelectedColor());
            labelTaken.Content = labelRed.Text + ", " + labelGreen.Text + ", " + labelBlue.Text;
        }
    }
}