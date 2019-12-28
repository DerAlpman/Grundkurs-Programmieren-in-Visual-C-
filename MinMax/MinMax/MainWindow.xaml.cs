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

namespace MinMax
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

        short n;
        int[] numbers;

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lstNumbers.Items.Clear();
                n = Convert.ToInt16(txtNumbers.Text);
                numbers = new int[n];
                Random rnd = new Random();

                for (int i = 0; i < n; i++)
                {
                    numbers[i] = rnd.Next(1, 1001);
                    lstNumbers.Items.Add(numbers[i].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (numbers == null || numbers.Count() == 0)
                    throw new Exception("Keine Zahlenwerte angegeben.");

                int max = numbers.Max();
                int min = numbers.Min();
                int idxMax = Array.IndexOf(numbers, max) + 1;
                int idxMin = Array.IndexOf(numbers, min) + 1;

                txtMax.Text = max.ToString();
                txtMin.Text = min.ToString();
                txtIdxMax.Text = idxMax.ToString();
                txtIdxMin.Text = idxMin.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}
