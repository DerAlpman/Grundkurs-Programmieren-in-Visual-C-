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

namespace Aufgabe_3._7
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
            double a, b, c, d;

            a = Convert.ToDouble(txtA.Text.Replace(".",","));
            b = Convert.ToDouble(txtB.Text.Replace(".",","));
            c = Convert.ToDouble(txtC.Text.Replace(".", ","));

            d = b * b - 4 * a * c;

            if (a != 0)
            {
                if (d == 0)
                {
                    txtX1.Text = (-b / 2 * a).ToString();
                    txtX2.Text = "";
                    lblResult.Content = "Nur eine Lösung.";
                }
                else if (d > 0)
                {
                    txtX1.Text = ((-b + Math.Sqrt(d)) / (2 * a)).ToString("F3");
                    txtX2.Text = ((b - Math.Sqrt(d)) / (2 * a)).ToString("F3");
                    lblResult.Content = "Zwei Lösungen.";
                }
                else
                {
                    txtX1.Text = "";
                    txtX2.Text = "";
                    lblResult.Content = "Keine reelle Lösung.";
                }
            }

        }

        private void btnExample1_Click(object sender, RoutedEventArgs e)
        {
            txtA.Text = "1";
            txtC.Text = "1";
            txtB.Text = "2";
            this.btnCalculate_Click(sender, e);
        }

        private void btnExample2_Click(object sender, RoutedEventArgs e)
        {
            txtA.Text = "2";
            txtC.Text = "1";
            txtB.Text = "2";
            this.btnCalculate_Click(sender, e);
        }

        private void btnExample3_Click(object sender, RoutedEventArgs e)
        {
            txtA.Text = "13";
            txtC.Text = "2";
            txtB.Text = "20";
            this.btnCalculate_Click(sender, e);
        }
    }
}
