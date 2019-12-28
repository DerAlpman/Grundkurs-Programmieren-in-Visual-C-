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

namespace XYPolar
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

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            double x, y, phi, rad;

            txtX.Text = txtX.Text.Replace(".", ",");
            txtY.Text = txtY.Text.Replace(".", ",");

            if (double.TryParse(txtX.Text, out x) &&
                double.TryParse(txtY.Text, out y))
            {
                rad = Math.Sqrt(x * x + y * y);
                phi = Math.Atan(y / x);

                if (x < 0)
                    phi += Math.PI;
                else if (y < 0)
                    phi += 2 * Math.PI;
                phi = phi * (180 / Math.PI);

                txtPhi.Text = phi.ToString("F4");
                txtRad.Text = rad.ToString("F3");
            }
            else
            {
                txtPhi.Text = "";
                txtRad.Text = "";
            }

        }
    }
}
