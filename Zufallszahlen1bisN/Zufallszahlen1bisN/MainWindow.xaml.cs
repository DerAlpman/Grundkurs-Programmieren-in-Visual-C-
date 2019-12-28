using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Zufallszahlen1bisN
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            int n;
            double max, min, sum, number;
            Random rnd = new Random();

            try
            {
                n = int.Parse(txtInput.Text);
                if (n < 1)
                {
                    throw new Exception("Eingabe muss größer 0 sein!");
                }
                min = n;
                max = 0;
                sum = 0;

                for (int i = 1; i < n; i++)
                {
                    number = rnd.NextDouble() * (n-1)+1.0;
                    sum += number;
                    if (number > max)
                    {
                        max = number;
                    }
                    if (number < min)
                    {
                        min = number;
                    }
                }

                txtMax.Text = max.ToString();
                txtMin.Text = min.ToString();
                txtMean.Text = (sum / n).ToString("F2");
            }
            catch (FormatException)
            {
                MessageBox.Show("Falsche Eingabe!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                txtMax.Text = "";
                txtMin.Text = "";
                txtMean.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                txtMax.Text = "";
                txtMin.Text = "";
                txtMean.Text = "";
            }
        }
    }
}
