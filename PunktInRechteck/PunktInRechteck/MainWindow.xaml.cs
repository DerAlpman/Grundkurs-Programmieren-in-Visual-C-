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

namespace PunktInRechteck
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double xmin = -100;
        private double xmax = 200;
        private double ymin = -30;
        private double ymax = 50;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            double x, y;

            txtX.Text = txtX.Text.Replace(".", ",");
            txtY.Text = txtY.Text.Replace(".", ",");

            if (txtX.Text == "")
                txtX.Text = "0,00";

            if (txtY.Text == "")
                txtY.Text = "0,00";

            x = Convert.ToDouble(txtX.Text);
            y = Convert.ToDouble(txtY.Text);
            if (xmin < x && x < xmax && ymin < y && y < ymax)
            {
                lblResult.Content = "Drinnen";
            }
            else
            {
                lblResult.Content = "Draußen";
            }
        }
    }
}
