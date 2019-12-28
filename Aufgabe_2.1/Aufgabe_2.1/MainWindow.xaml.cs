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

namespace Aufgabe_2._1
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

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            double p, q, a, b, c, h;

            p = Convert.ToDouble(txtP.Text.Replace(".",","));
            q = Convert.ToDouble(txtQ.Text.Replace(".", ","));

            c = p + q;

            a = Math.Sqrt(c * p);
            b = Math.Sqrt(c * q);

            h = Math.Sqrt(p * q);

            txtA.Text = a.ToString("F2");
            txtB.Text = b.ToString("F2");
            txtC.Text = c.ToString("F2");
            txtH.Text = h.ToString("F2");
        }
    }
}
