using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hrdina_a_drak
{
    public abstract class Postava : Object
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


        public virtual double Utok(Postava oponent)
        {
            return GenerovaniUtoku(PoskozeniMax, oponent);
        }

        protected double GenerovaniUtoku(double poskozMax, Postava oponent)
        {
            double hodnotaUtoku = 0;

            Kostka kostka = Kostka.Instance;
            hodnotaUtoku = kostka.NextDouble() * poskozMax;
            hodnotaUtoku -= oponent.Obrana();
            oponent.SnizZdravi(hodnotaUtoku);

            return hodnotaUtoku > 0 ? hodnotaUtoku : 0;
        }

        public virtual Postava VyberOponenta(Postava[] postavy)
        {
            for (int i = 0; i < postavy.Length; ++i)
            {
                if (postavy[i] != this && postavy[i].JeZivy() && TestVyberuSpecifickehoOponenta(postavy[i]))
                {
                    return postavy[i];
                }
            }

            return null;
        }

        public abstract bool TestVyberuSpecifickehoOponenta(Postava oponent);

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

    }
}
