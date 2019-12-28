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

namespace WpfApplication1
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
            double a, v, s;

            a = Convert.ToDouble(txtLength.Text);
            v = Math.Pow(a, 3);
            s = Math.Pow(a, 2) * 6;

            lblVolume.Content = Convert.ToString(v) + " m²";
            lblSurface.Content = Convert.ToString(s) + " m³";
        }
    }
}
