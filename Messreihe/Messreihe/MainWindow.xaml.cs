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

namespace Messreihe
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

        private double[] l;
        private double[] v;
        private double mean;
        private double stdev;
        private int n;

        private void btnAddData_Click(object sender, RoutedEventArgs e)
        {
            string input;
            try
            {
                // Get input and write it to list.
                input = txtDataInput.Text.Replace(".",",");
                txtDataList.Text += input;
                txtDataList.Text += Environment.NewLine;

                txtDataInput.Text = "";
                txtDataInput.Focus();

                // Recalculate size of input array l and resize it.
                n += 1;
                Array.Resize(ref l, n);

                // Convert input and put in array l.
                l[n-1] = Convert.ToDouble(input);
            }
            catch (FormatException)
            {
                MessageBox.Show("Eingabefeld enthält einen unzulässigen Wert.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtDataInput.Clear();
            txtDataList.Clear();
            txtVi.Clear();
            txtMean.Clear();
            txtStdDev.Clear();

            l = null;
            v = null;
            mean = 0.0;
            stdev = 0.0;
            n = 0;
        }

        private double AMean(double[] data)
        {
            if (data != null)
            {
                double sum = 0.0;
                double n = data.Length;

                foreach (double i in data)
                    sum += i;
                
                return sum / n;
            }
            else
                throw new Exception("Berechnung des Mittelwertes nicht möglich, da keine Daten vorhanden.");
        }

        private double[] Residuals(double[] data, double m)
        {
            if (data != null)
            {
                double[] v = new double[data.Length];

                for (int i = 0; i < data.Length; i++)
                    v[i] = m - data[i];

                return v;
            }
            else
                throw new Exception("Berechnung der Verbesserungen nicht möglich, da keine Daten vorhanden.");
        }
        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double vv = 0.0;

                // Calculate arithmetical mean.
                mean = AMean(l);
                txtMean.Text = mean.ToString("f3");

                // Calculate residuals(?).
                v = Residuals(l, mean);

                // Write residuals(?) to list.
                txtVi.Clear();
                foreach (double i in v)
                {
                    txtVi.Text += i.ToString("f6") + Environment.NewLine;

                    vv += i * i;
                }

                // Calculate standard deviation.
                stdev = Math.Sqrt(vv/(n*(n-1)));

                txtStdDev.Text = stdev.ToString("f3");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
