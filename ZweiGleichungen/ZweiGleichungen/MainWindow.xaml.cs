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

namespace ZweiGleichungen
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

        private void btnBeenden_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtA.Text = "";
            txtB.Text = "";
            txtC.Text = "";
            txtD.Text = "";
            txtE.Text = "";
            txtF.Text = "";
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            double a,b,c,d,e1,f,x,y,det;

            a = double.Parse(txtA.Text.Replace(".",","));
            b = double.Parse(txtB.Text.Replace(".",","));
            c = double.Parse(txtC.Text.Replace(".",","));
            d = double.Parse(txtD.Text.Replace(".",","));
            e1 = double.Parse(txtE.Text.Replace(".",","));
            f = double.Parse(txtF.Text.Replace(".",","));

            det = a * e1 - d * b;

            if (det == 0)
            {
                txtX.Text = "Keine Lösung";
                txtY.Text = "Keine Lösung";
            }
            else
            {
                x = (c * e1 - b * f)/det;
                y = (a * f - c * d)/det;

                txtX.Text = x.ToString("F4");
                txtY.Text = y.ToString("F4");
            }
        }

        private void btnExample1_Click(object sender, RoutedEventArgs e)
        {
            txtA.Text = "1,2";
            txtB.Text = "3,5";
            txtC.Text = "5,20";
            txtD.Text = "5,2";
            txtE.Text = "7,8";
            txtF.Text = "0,71";

            btnCalculate_Click(sender, e);
        }

        private void btnExample2_Click(object sender, RoutedEventArgs e)
        {
            txtA.Text = "1,2";
            txtB.Text = "3,5";
            txtC.Text = "5,20";
            txtD.Text = "2,4";
            txtE.Text = "7,0";
            txtF.Text = "0,71";

            btnCalculate_Click(sender, e);
        }
    }
}
