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

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            double a = Convert.ToDouble(txtA.Text);
            double b = Convert.ToDouble(txtB.Text);

            txtResult.Text = (a + b).ToString();
        }

        private void btnSubstract_Click(object sender, RoutedEventArgs e)
        {
            double a = Convert.ToDouble(txtA.Text);
            double b = Convert.ToDouble(txtB.Text);

            txtResult.Text = (a - b).ToString();
        }

        private void btnMultiply_Click(object sender, RoutedEventArgs e)
        {
            double a = Convert.ToDouble(txtA.Text);
            double b = Convert.ToDouble(txtB.Text);

            txtResult.Text = (a * b).ToString();
        }

        private void btnDivide_Click(object sender, RoutedEventArgs e)
        {
            double a = Convert.ToDouble(txtA.Text);
            double b = Convert.ToDouble(txtB.Text);

            txtResult.Text = (a / b).ToString();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtA.Text = "";
            txtB.Text= "";
            txtResult.Text = "";
        }

    }
}
