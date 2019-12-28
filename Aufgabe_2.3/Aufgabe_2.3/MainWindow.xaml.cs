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

namespace Aufgabe_2._3
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
            double r, v, o;

            r = Convert.ToDouble(txtR.Text.Replace(".",","));

            v = Math.Pow(r, 3) * Math.PI * 4 / 3;
            o = 4 * Math.PI * r * r;

            txtV.Text = v.ToString("F2");
            txtO.Text = o.ToString("F2");
        }
    }
}
