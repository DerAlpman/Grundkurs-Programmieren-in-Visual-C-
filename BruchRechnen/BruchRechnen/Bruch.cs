using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BruchRechnen
{
    public class Bruch
    {
        private int zaehler;
        private int nenner;

        public int Zaehler
        {
            get { return this.zaehler; }
            set { this.zaehler = value; }
        }

        public int Nenner
        {
            get { return this.nenner; }
            set
            {
                if (value == 0)
                    throw new Exception("Der Nenner darf nicht 0 sein!");
                else
                    this.nenner = value;
            }
        }

        public Bruch() : this(0, 1) { }

        public Bruch(int zaehler, int nenner)
        {
            this.Zaehler = zaehler;
            this.Nenner = nenner;
        }

        private int ggT(int a, int b)
        {
            if (b == 0)
                return a;
            else
                return ggT(b, a % b);
        }

        public static Bruch Add(Bruch b1, Bruch b2)
        {
            int z, n;
            Bruch bruchE = new Bruch();
            z = b1.Zaehler * b2.Nenner + b1.Nenner * b2.Zaehler;
            n = b1.Nenner * b2.Nenner;

            return bruchE.Kuerze(z, n);
        }

        public Bruch Add(Bruch b)
        {
            int z, n;
            Bruch bruchE = new Bruch();
            z = this.Zaehler *b.Nenner + this.Nenner * b.Zaehler;
            n = this.nenner * b.Nenner;

            return bruchE.Kuerze(z, n);
        }

        public Bruch Kuerze(int zaehler, int nenner)
        {
            int ggTwert;

            ggTwert = ggT(zaehler, nenner);

            zaehler /= ggTwert;
            nenner /= ggTwert;

            return new Bruch(zaehler, nenner);

        }

        public static Bruch operator +(Bruch b1, Bruch b2)
        {
            return Add(b1, b2);
        }

    }
}
