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

namespace ZinsAct360
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

        private int InterestDays(DateTime start, DateTime end)
        {
            return (end - start).Days;
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            DateTime start, end;
            int iDays;
            double k, z, p;
            try
            {
                k = Convert.ToDouble(txtCapital.Text.Replace(".",","));
                p = Convert.ToDouble(txtInterestRate.Text.Replace(".",","));                
                start = Convert.ToDateTime(dtpStart.Text);
                end = Convert.ToDateTime(dtpEnd.Text);
                if (start > end)
                    throw new Exception("Einzahlungsdatum muss vor Auszahlungsdatum liegen.");
                
                iDays = (end - start).Days;

                z = k * (p / 100.0) * (iDays / 360.0);

                txtIDays.Text = iDays.ToString();
                txtInterest.Text = z.ToString("f2");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hinweis");
            }
        }

        
    }
}
