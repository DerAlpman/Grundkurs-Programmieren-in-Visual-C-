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

namespace Aufgabe_5._3
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

        private double TxtDblPos(TextBox txtBox)
        {
            txtBox.Text = txtBox.Text.Replace(".", ",");
            double nr;
            try
            {
                nr = Convert.ToDouble(txtBox.Text);
                if (nr < 0)
                    throw new Exception("Eingabe in Feld " + txtBox.Name.Replace("txt", "") + "muss größer 0 sein.");
                return nr;                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private double Area(double r)
        {
            return Math.PI * r * r;
        }

        private double Area(double a, double b)
        {
            return a * b;
        }

        private double Area(double a, double b, double c)
        {
            if (Math.Abs(a - b) < c && c < a + b)
            {
                double s = (a + b + c) / 2;
                return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            }
            else
                throw new Exception("Dreieckskriterium ist nicht erfüllt!");
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double a, b, c, result;
                a = TxtDblPos(txtA);
                b = TxtDblPos(txtB);
                c = TxtDblPos(txtC);

                if (radCircle.IsChecked == true)
                    result = Area(a);
                else if (radRectangle.IsChecked == true)
                    result = Area(a, b);
                else if (radTriangle.IsChecked == true)
                    result = Area(a, b, c);
                else
                    throw new Exception("Bitte einen Körper auswählen.");

                txtResult.Text = result.ToString("f3");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler");
            }

        }

        private void radTriangle_Checked(object sender, RoutedEventArgs e)
        {
            txtA.IsEnabled = true;
            txtB.IsEnabled = true;
            txtC.IsEnabled = true;
        }

        private void radRectangle_Checked(object sender, RoutedEventArgs e)
        {
            txtA.IsEnabled = true;
            txtB.IsEnabled = true;
            txtC.IsEnabled = false;
            txtC.Text = "0,0";
        }

        private void radCircle_Checked(object sender, RoutedEventArgs e)
        {
            txtA.IsEnabled = true;
            txtB.IsEnabled = false;
            txtC.IsEnabled = false;
            txtB.Text = "0,0";
            txtC.Text = "0,0";
        }

        
    }
}
