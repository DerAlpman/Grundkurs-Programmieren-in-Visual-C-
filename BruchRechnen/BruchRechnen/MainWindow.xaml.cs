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

namespace BruchRechnen
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
         
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            int z, n;
            Bruch b1, b2;
            Bruch bE = new Bruch();

            try
            {
                z = Convert.ToInt32(txtZ1.Text);
                n = Convert.ToInt32(txtN1.Text);
                b1 = new Bruch(z, n);

                z = Convert.ToInt32(txtZ2.Text);
                n = Convert.ToInt32(txtN2.Text);
                b2 = new Bruch(z, n);

                switch (txtOp.Text)
                {
                    case "+":
                        break;
                    default:
                        throw new Exception("Operator nicht zulässig.");
                }

                if (radV1.IsChecked == true)
                    bE = Bruch.Add(b1, b2);
                else if (radV2.IsChecked == true)
                    bE = b1.Add(b2);
                else
                    bE = b1 + b2;

                txtZ3.Text = bE.Zaehler.ToString();
                txtN3.Text = bE.Nenner.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehlerhinweis");
            }
        }
    }
}
