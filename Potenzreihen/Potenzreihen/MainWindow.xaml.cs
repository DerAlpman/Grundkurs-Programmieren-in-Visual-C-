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

namespace Potenzreihen
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

        private void btnCalculateE_Click(object sender, RoutedEventArgs e)
        {
            int i;
            double glied, euler;
            
            try
            {
                lstE.Items.Clear();

                // get, clear and convert input.
                double x = Convert.ToDouble(txtEInput.Text.Replace(".",","));

                if (x > 10)
                    throw new Exception("x sollte nicht größer als 10 sein.");

                txtEOutput.Text = Math.Pow(Math.E, x).ToString("F12");

                lstE.Items.Add(" i          e^x            glied");
                lstE.Items.Add("-----------------------------------");

                // initialise variables.
                i = 1;
                glied = 1;
                euler = 1;
                do
                {
                    lstE.Items.Add(i.ToString("00") + "  " +
                        euler.ToString("F12") + "   " +
                        glied.ToString("F12"));
                    glied *= x / i ;
                    euler += glied;
                    i += 1;            
                }
                while (Math.Abs(glied) >= 1e-15 || i == 100);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hinweis");
            }
        }

        private void btnCalculateGauss_Click(object sender, RoutedEventArgs e)
        {
            int i;
            double glied, term, phi;

            try
            {
                lstGauss.Items.Clear();

                // get, clear and convert input.
                double x = Convert.ToDouble(txtGaussInput.Text.Replace(".", ","));

                if (x > 4)
                    throw new Exception("x sollte nicht größer als 4 sein.");

                lstGauss.Items.Add(" i          phi(x)            glied");
                lstGauss.Items.Add("-----------------------------------");
                
                // initialise variables.
                i = 1; 
                glied = x;
                phi = (2 / Math.Sqrt(Math.PI)) * glied;
                term = x;
                do
                {
                    lstGauss.Items.Add(i.ToString("00") + "  " +
                        phi.ToString("F12") + "   " +
                        glied.ToString("F12"));

                    term *= -(x * x) / i;
                    glied = (term) / ((2 * i) + 1);
                    phi += (2/Math.Sqrt(Math.PI)) * glied;
                    i += 1;
                }
                while (Math.Abs(glied) >= 1e-15 || i == 100);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hinweis");
            }
        }
    }
}
