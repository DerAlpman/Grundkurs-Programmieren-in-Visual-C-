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

namespace DXFKonverterAbstract
{
    public abstract class Entity
    {
        private string layerName = "0";
        public string newln = Environment.NewLine;
        public abstract string PrintDXF();

        public string LayerName
        {
            get { return this.layerName; }
            set
            {
                if (value == "")
                    this.layerName = "0";
                else
                    this.layerName = value;
            }
        }
    }

    public class Circle : Entity
    {
        private double x, y, z;
        private double radius;

        public Circle(double x, double y, double z, double radius)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.radius = radius;
        }

        public override string PrintDXF()
        {
            return "  0" + newln + "CIRCLE" + newln +
                "  8" + newln + LayerName + newln +
                " 10" + newln + this.x.ToString() + newln +
                " 20" + newln + this.y.ToString() + newln +
                " 30" + newln + this.z.ToString() + newln +
                " 40" + newln + this.radius.ToString() + newln;
        }
    }

    public class Arc : Entity
    {
        private double x, y, z, wa, wb;
        private double radius;

        public Arc(double x, double y, double z, double radius, double wa, double wb)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.radius = radius;
            this.wb = wb;
            this.wa = wa;
        }

        public override string PrintDXF()
        {
            return "  0" + newln + "ARC" + newln +
                "  8" + newln + LayerName + newln +
                " 10" + newln + this.x.ToString() + newln +
                " 20" + newln + this.y.ToString() + newln +
                " 30" + newln + this.z.ToString() + newln +
                " 40" + newln + this.radius.ToString() + newln +
                " 50" + newln + this.wa.ToString() + newln +
                " 51" + newln + this.wb.ToString() + newln;
        }
    }

    public class Point : Entity
    {
        private double x, y, z;

        public Point(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override string PrintDXF()
        {
            return "  0" + newln + "Point" + newln +
                "  8" + newln + LayerName + newln +
                " 10" + newln + this.x.ToString() + newln +
                " 20" + newln + this.y.ToString() + newln +
                " 30" + newln + this.z.ToString() + newln;
        }
    }

    public class Line : Entity
    {
        private double xs, ys, zs, xe, ye, ze;

        public Line(double xs, double ys, double zs, double xe, double ye, double ze)
        {
            this.xs = xs;
            this.ys = ys;
            this.zs = zs;
            this.xe = xe;
            this.ye = ye;
            this.ze = ze;
        }

        public override string PrintDXF()
        {
            return "  0" + newln + "LINE" + newln +
                "  8" + newln + LayerName + newln +
                " 10" + newln + this.xs.ToString() + newln +
                " 20" + newln + this.ys.ToString() + newln +
                " 30" + newln + this.zs.ToString() + newln +
                " 11" + newln + this.xs.ToString() + newln +    
                " 21" + newln + this.ys.ToString() + newln +
                " 31" + newln + this.zs.ToString() + newln;
        }
    }

    public class StartEntity : Entity
    {
        public override string PrintDXF()
        {
            return "  0" + newln + "SECTION" + newln +
                "  2" + newln + "ENTITIES" + newln;
        }
    }

    public class EndEntity : Entity
    {
        public override string PrintDXF()
        {
            return "  0" + newln + "ENDSEC" + newln +
                "  0" + newln + "EOF" + newln;
        }
    }

    public class Text : Entity
    {
        private double x, y, z;
        private double txtHeight;
        private string txtString;

        public Text(double x, double y, double z, double txtHeight, string txtString)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.txtHeight = txtHeight;
            this.txtString = txtString;
        }

        public override string PrintDXF()
        {
            return "  0" + newln + "TEXT" + newln +
                "  8" + newln + LayerName + newln +
                " 10" + newln + this.x.ToString() + newln +
                " 20" + newln + this.y.ToString() + newln +
                " 30" + newln + this.z.ToString() + newln +
                " 40" + newln + this.txtHeight.ToString() + newln +
                "  1" + newln + this.txtString + newln;
        }
    }

    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            char[] charSep = {' '};
            char[] charTrim = { ' ', (char)10, (char)13 };
            string[] line;
            string txtLine;
            string error = string.Empty;
            string dxf = string.Empty;
            string newln = Environment.NewLine;

            StartEntity entStart = new StartEntity();
            EndEntity entEnd = new EndEntity();
            Arc entArc;
            Circle entCircle;
            Point entPoint;
            Line entLine;
            Text entText;

            try
            {
                dxf = entStart.PrintDXF();
                txtEntities.Text = txtEntities.Text.Trim(charTrim);

                for (int i = 0; i < txtEntities.LineCount; i++)
                {
                    txtLine = txtEntities.GetLineText(i).Replace(".", ",");
                    line = txtLine.Split(charSep, StringSplitOptions.RemoveEmptyEntries);
                    line[0] = line[0].ToUpper();

                    switch (line[0])
                    {
                        case "ARC":
                            if (line.Length == 7)
                            {
                                entArc = new Arc(Convert.ToDouble(line[1]),
                                    Convert.ToDouble(line[2]),
                                    Convert.ToDouble(line[3]),
                                    Convert.ToDouble(line[4]),
                                    Convert.ToDouble(line[5]),
                                    Convert.ToDouble(line[6]));
                                dxf += entArc.PrintDXF();
                            }
                            else
                                error += "Zeile " + i + ": " + line[0] + newln;
                            break;
                        case "CIRCLE":
                            if (line.Length == 5)
                            {
                                entCircle = new Circle(Convert.ToDouble(line[1]),
                                    Convert.ToDouble(line[2]),
                                    Convert.ToDouble(line[3]),
                                    Convert.ToDouble(line[4]));
                                dxf += entCircle.PrintDXF();
                            }
                            else
                                error += "Zeile " + i + ": " + line[0] + newln;
                            break;
                        case "LINE":
                            if (line.Length == 7)
                            {
                                entLine = new Line(Convert.ToDouble(line[1]),
                                    Convert.ToDouble(line[2]),
                                    Convert.ToDouble(line[3]),
                                    Convert.ToDouble(line[4]),
                                    Convert.ToDouble(line[5]),
                                    Convert.ToDouble(line[6]));
                                dxf += entLine.PrintDXF();
                            }
                            else
                                error += "Zeile " + i + ": " + line[0] + newln;
                            break;
                        case "POINT":
                            if (line.Length == 4)
                            {
                                entPoint = new Point(Convert.ToDouble(line[1]),
                                    Convert.ToDouble(line[2]),
                                    Convert.ToDouble(line[3]));
                                dxf += entPoint.PrintDXF();
                            }
                            else
                                error += "Zeile " + i + ": " + line[0] + newln;
                            break;
                        case "TEXT":
                            if (line.Length == 6)
                            {
                                entText = new Text(Convert.ToDouble(line[1]),
                                    Convert.ToDouble(line[2]),
                                    Convert.ToDouble(line[3]),
                                    Convert.ToDouble(line[4]),
                                    line[5]);
                                dxf += entText.PrintDXF();
                            }
                            else
                                error += "Zeile " + i + ": " + line[0] + newln;
                            break;
                        default:
                            error += "Zeile " + i + ": " + line[0] + newln;
                            break;
                    }
                }

                dxf += entEnd.PrintDXF();

                txtDXF.Text = dxf.Replace(",", ".");
                txtErrors.Text = error;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehlerhinweis");
            }

        }
    }
}
