using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Class_Rectangle
{
    class Rectangle
    {
        private double length;
        private double width;

        public Rectangle(double length, double width)
        {
            this.length = length;
            this.width = width;
        }

        public double Area
        {
            get {return this.length * this.width;}
        }

        public double Perimeter
        {
            get {return 2 * (this.length + this.width);}
        }

        public string FormatF2(double value)
        {
            return value.ToString("F2");
        }
    }
}
