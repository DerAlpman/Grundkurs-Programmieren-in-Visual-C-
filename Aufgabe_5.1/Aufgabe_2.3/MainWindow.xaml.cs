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

namespace Aufgabe_5._1
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

        private double SphereVolume(double radius)
        {
            return Math.Pow(radius, 3) * Math.PI * 4.0 / 3.0;
        }
        
        private double SpherePlane(double radius)
        {
            return 4 * Math.PI * radius * radius;
        }

        private void Sphere(double radius, out double volume, out double surfaceArea)
        {
            volume = SphereVolume(radius);
            surfaceArea = SpherePlane(radius);
        }

        private void btnCalculateV_Click(object sender, RoutedEventArgs e)
        {
            double r = Convert.ToDouble(txtR.Text.Replace(".",","));
            txtV.Text = SphereVolume(r).ToString("f2");
        }

        private void btnCalculateO_Click(object sender, RoutedEventArgs e)
        {
            double r = Convert.ToDouble(txtR.Text.Replace(".", ","));
            txtO.Text = SpherePlane(r).ToString("f2");
        }

        private void btnCalculateVO_Click(object sender, RoutedEventArgs e)
        {
            double r = Convert.ToDouble(txtR.Text.Replace(".", ","));
            double volume, surfaceArea;

            Sphere(r, out volume, out surfaceArea);

            txtV.Text = volume.ToString("f2");
            txtO.Text = surfaceArea.ToString("f2");
        }
    }
}
