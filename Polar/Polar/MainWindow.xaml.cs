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

namespace Polar
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

        private double TxtToDouble(TextBox txtBox)
        {
            txtBox.Text = txtBox.Text.Replace(".", ",");
            try
            {
                return Convert.ToDouble(txtBox.Text);
            }
            catch (Exception)
            {
                throw new Exception("Eingabefehler in Feld " + txtBox.Name.Replace("txtInput", "") + ".");
            }
        }

        private void KorToPolar(double dx, double dy, out double phi, out double r)
        {
            r = Math.Sqrt((dx * dx) + (dy * dy));
            phi = Math.Atan2(dy, dx);

            if (phi < 0)
                phi += 2 * Math.PI;
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            double x1, y1, x2, y2, phi, r, wfaktor;

            try
            {
                x1 = TxtToDouble(txtInputX1);
                x2 = TxtToDouble(txtInputX2);
                y1 = TxtToDouble(txtInputY1);
                y2 = TxtToDouble(txtInputY2);

                KorToPolar(x2 - x1, y2 - y1, out phi, out r);
                
                if (radDEG.IsChecked == true)
                    wfaktor = 180.0 / Math.PI;
                else if (radRAD.IsChecked == true)
                    wfaktor = 1;
                else
                    wfaktor = 200.0 / Math.PI;

                txtAngle.Text = (phi * wfaktor).ToString("f4");
                txtLength.Text = r.ToString("f3");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
