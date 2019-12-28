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

namespace Polynom3Grad
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

        private double a1, a2, a3, a0;
        private double eps = 1E-8;

        private double Fx(double x)
        {
            return ((a3 * x + a2) *x + a1) * x + a0;
        }

        private void ListRoot(double root)
        {
            lstRoots.Items.Add(root.ToString("f7"));
        }

        private void StartXA(double xa, double dx,
            out double xl, out double yl,
            out double xr, out double yr)
        {
            xl = xa; yl = Fx(xl);
            xr = xl + dx; yr = Fx(xr);

            if (Math.Abs(yl) < eps)
                ListRoot(xl);
        }

        private void StepDX(double dx,
            ref double xl, ref double yl,
            ref double xr, ref double yr)
        {
            xl = xr; yl = yr;
            xr = xl + dx; yr = Fx(xr);
        }

        private void SearchRoots(double xl, double yl, double xr, double yr)
        {
            double xm, ym;
            if (Math.Abs(yr) < eps)
            {
                ListRoot(xr);
            }
            else if (yl * yr < 0)
            {
                do
                {
                    xm = (xl + xr) / 2;
                    ym = Fx(xr);

                    if (yl * yr > 0)
                    {
                        xl = xm;
                        yl = ym;
                    }
                    else
                    {
                        xr = xm;
                        yr = ym;
                    }
                }
                while (Math.Abs(ym) >= eps);
                ListRoot(xm);
            }

        }
        private void AllRoots(double xS, double xE, double dx)
        {
            double xL, yL, xR, yR;
            StartXA(xS, dx, out xL, out yL, out xR, out yR);

            while (xL < xE)
            {
                if (yL * yR == 0)
                    SearchRoots(xL, yL, xR, yR);
                StepDX(dx, ref xL, ref yL, ref xR, ref yR);
            }
        }
        
        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            double xS, xE, dx;

            try
            {
                a3 = Convert.ToDouble(txtA3.Text.Replace(".",","));
                a2 = Convert.ToDouble(txtA2.Text.Replace(".",","));
                a1 = Convert.ToDouble(txtA1.Text.Replace(".",","));
                a0 = Convert.ToDouble(txtA0.Text.Replace(".",","));

                xS = Convert.ToDouble(txtFrom.Text.Replace(".",","));
                xE = Convert.ToDouble(txtTo.Text.Replace(".", ","));
                dx = Convert.ToDouble(txtInterval.Text.Replace(".",","));

                AllRoots(xS, xE, dx);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtA3.Text = "1";
            txtA2.Text = "-8";
            txtA1.Text = "17";
            txtA0.Text = "-10";

            txtFrom.Text = "-10";
            txtTo.Text = "10";
            txtInterval.Text = "0,1";
        }
    }
}
