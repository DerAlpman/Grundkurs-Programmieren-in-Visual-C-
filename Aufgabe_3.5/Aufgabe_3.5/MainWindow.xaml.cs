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

namespace Aufgabe_3._5
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
            int a, b;

            if (int.TryParse(txtA.Text, out a) &&
                int.TryParse(txtB.Text, out b))
            {
                if (b == 0)
                    txtResult.Text = "Division durch Null";
                else if (a % b == 0)
                
                    txtResult.Text = (a / b).ToString();
                else                
                    txtResult.Text = "Division mit Rest";
            }
            else
            {
                txtResult.Text = "Falsche Eingaben.";
            }


        }
    }
}
