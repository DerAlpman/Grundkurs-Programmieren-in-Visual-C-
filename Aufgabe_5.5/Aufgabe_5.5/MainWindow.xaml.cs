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

namespace Aufgabe_5._5
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

        private int ggT(int a, int b)
        {
            if (b == 0)
                return a;
            else
                return ggT(b, a % b);
        }

        private int kgV(int a, int b)
        {
            return a / ggT(a, b) * b;
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            int a, b;
            try
            {
                a = Convert.ToInt32(txtA.Text);
                b = Convert.ToInt32(txtB.Text);
                txtGGT.Text = ggT(a, b).ToString();
                txtKGV.Text = kgV(a, b).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
