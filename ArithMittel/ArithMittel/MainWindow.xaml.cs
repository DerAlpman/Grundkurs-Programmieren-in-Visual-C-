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

namespace ArithMittel
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

        private double Mean(double[] numbers)
        {
            double sum = 0;

            foreach (double i in numbers)
                sum += i;

            return sum / numbers.Length;
        }

        private double GMean(double[] numbers)
        {
            double sum = 1;
            double n = numbers.Length;

            foreach (double i in numbers)
                sum *= i;

            return Math.Pow(sum, 1/n);
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            int n = lstNumbers.Items.Count;
            double[] numbers = new double[n];
            double mean, gmean;

            for (int i = 0; i < n; i++)
                numbers[i] = Convert.ToDouble(lstNumbers.Items[i]);

            mean = Mean(numbers);
            gmean = GMean(numbers);

            txtMean.Text = mean.ToString("f4");
            txtGMean.Text = gmean.ToString("f4");
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            lstNumbers.Items.Clear();
            txtMean.Text = "";
            txtInput.Text = "";
            txtInput.Focus();
        }

        private void btnAddNumber_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lstNumbers.Items.Add(Convert.ToDouble(txtInput.Text));

                txtInput.Text = "";
                txtInput.Focus();
            }
            catch (FormatException)
            {
                MessageBox.Show("Eingabefeld leer.");
            }
        }
    }
}
