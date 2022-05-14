using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hrdina_a_drak
{
    public abstract class Postava : Object, IComparable<Postava>, IZasazitelne
    {

        public string Jmeno { get; set; }
        public double Zdravi { get; set; }
        public double ZdraviMax { get; set; }
        public double PoskozeniMax { get; set; }
        public double ZbrojMax { get; set; }

        public Postava(string jmeno, double zdravi, double zdraviMax, double poskozeniMax, double zbrojMax)
        {
            Jmeno = jmeno;
            Zdravi = zdravi;
            ZdraviMax = zdraviMax;
            PoskozeniMax = poskozeniMax;
            ZbrojMax = zbrojMax;
        }


        public virtual double Utok(IZasazitelne oponent)
        {
            return GenerovaniUtoku(PoskozeniMax, oponent);
        }

        protected double GenerovaniUtoku(double poskozMax, IZasazitelne oponent)
        {
            double hodnotaUtoku = 0;

            Kostka kostka = Kostka.Instance;
            hodnotaUtoku = kostka.NextDouble() * poskozMax;
            hodnotaUtoku -= oponent.Obrana();
            oponent.SnizZdravi(hodnotaUtoku);

            return hodnotaUtoku > 0 ? hodnotaUtoku : 0;
        }

        public virtual Postava VyberOponenta(List<Postava> postavy)
        {
            for (int i = 0; i < postavy.Count; ++i)
            {
                if (postavy[i] != this && postavy[i].JeZivy() && TestVyberuSpecifickehoOponenta(postavy[i]))
                {
                    return postavy[i];
                }
            }

            return null;
        }

        public bool MaOponenta(List<Postava> postavy)
        {
            return VyberOponenta(postavy) != null ? true : false;
        }

        public abstract bool TestVyberuSpecifickehoOponenta(Postava oponent);

        public virtual Postava VyberOponenta(List<Postava> postavy, Predicate<Postava> podminkaSpecVyberu)
        {
            for (int i = 0; i < postavy.Count; ++i)
            {
                if (postavy[i] != this && postavy[i].JeZivy() && podminkaSpecVyberu(postavy[i]))
                {
                    return postavy[i];
                }
            }

            return null;
        }

        public virtual double Obrana()
        {
            double hodnotaObrany = 0;

            //dodělat

            return hodnotaObrany;
        }

        public void SnizZdravi(double hodnotaSnizeniZdravi)
        {
            if (hodnotaSnizeniZdravi > 0)
                Zdravi -= hodnotaSnizeniZdravi;
        }

        public bool JeZivy()
        {
            if (Zdravi > 0)
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            return base.ToString() + ": " + $"{Jmeno}, {Zdravi}/{ZdraviMax}, {PoskozeniMax}, {ZbrojMax}, {VypocitejSilu()}";
        }

        public int CompareTo(Postava other)
        {
            if (other == null)
            {
                return 1;
            }
            else
            {
                double silaTetoPostavy = this.VypocitejSilu();
                double silaDruhePostavy = other.VypocitejSilu();
                return silaTetoPostavy.CompareTo(silaDruhePostavy);
            }
        }

        public double VypocitejSilu()
        {
            return 0.3 * Zdravi + 0.4 * PoskozeniMax + 0.3 * ZbrojMax;
        }

    }
}
