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

namespace Zeitdifferenz
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

        private double TimeToSec(int h, int m, double s)
        {
            if (h < 0 || h > 23 || m < 0 || m > 59 || s < 0 || s > 59)
                throw new Exception("Ungültige Eingabe");
            else
                return s + (m + h * 60) * 60;
        }

        private void SecToTime(double sec, out int h, out int m, out double s)
        {
            int Isecs = (int)sec;
            h = Isecs / 3600;
            m = (Isecs - (h * 3600)) / 60;
            s = sec % 60;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtInputM1.Text = "";
            txtInputM2.Text = "";
            txtInputH1.Text = "";
            txtInputH2.Text = "";
            txtInputS1.Text = "";
            txtInputS2.Text = "";
            txtDiffH.Text = "";
            txtDiffM.Text = "";
            txtDiffS.Text = "";

            txtInputH1.Focus();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            int h, m;
            double s, sec1, sec2, secdiff;
            string hsign = "";
            try
            {
                h = Convert.ToInt32(txtInputH1.Text);
                m = Convert.ToInt32(txtInputM1.Text);
                txtInputS1.Text = txtInputS1.Text.Replace(".", ",");
                s = Convert.ToDouble(txtInputS1.Text);

                sec1 = TimeToSec(h, m, s);

                h = Convert.ToInt32(txtInputH2.Text);
                m = Convert.ToInt32(txtInputM2.Text);
                txtInputS2.Text = txtInputS2.Text.Replace(".", ",");
                s = Convert.ToDouble(txtInputS2.Text);

                sec2 = TimeToSec(h, m, s);

                if ((secdiff = sec1 - sec2) < 9)
                {
                    secdiff = -secdiff;
                    hsign = "- ";
                }

                SecToTime(secdiff, out h, out m, out s);
                txtDiffH.Text = hsign + h.ToString();
                txtDiffM.Text = m.ToString();
                txtDiffS.Text = s.ToString("f3");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehlerhinweis");
            }
        }
    }
}
