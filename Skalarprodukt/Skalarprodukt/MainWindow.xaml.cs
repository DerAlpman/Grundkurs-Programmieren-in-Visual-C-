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

namespace Skalarprodukt
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

        private int[] a, b;

        private void btnVecA_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            a = new int[3];

            lstVecA.Items.Clear();
            for (int i = 0; i < 3; i++)
            {
                a[i] = rnd.Next(-10, 11);
                lstVecA.Items.Add(a[i]);
            }
        }

        private void btnVecB_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            b = new int[3];

            lstVecB.Items.Clear();
            for (int i = 0; i < 3; i++)
            {
                b[i] = rnd.Next(-10, 11);
                lstVecB.Items.Add(b[i]);
            }
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            int scalarProduct = 0;

            try
            {
                if (lstVecA.Items.Count == 0 || lstVecB.Items.Count == 0)
                    throw new Exception("Vektoren müssen erst ermittelt werden!");

                for (int i = 0; i < 3; i++)
                    scalarProduct += a[i] * b[i];

                txtResult.Text = scalarProduct.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
