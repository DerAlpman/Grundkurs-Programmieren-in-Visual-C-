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

namespace Kosinussatz
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
            double a, b, c, gamma;

            a = Convert.ToDouble(txtA.Text.Replace(".", ","));
            b = Convert.ToDouble(txtB.Text.Replace(".", ","));
            gamma = Convert.ToDouble(txtAngle.Text.Replace(".", ","));
            gamma = gamma * Math.PI / 180.0;

            c = Math.Sqrt(a * a + b * b - 2 * a * b * Math.Cos(gamma));

            txtC.Text = c.ToString("F2");

        }
    }
}
