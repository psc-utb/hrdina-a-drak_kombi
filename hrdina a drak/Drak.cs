using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hrdina_a_drak
{
    public class Drak
    {
        public string Jmeno { get; set; }
        public double Zdravi { get; set; }
        public double ZdraviMax { get; set; }
        public double PoskozeniMax { get; set; }
        public double ZbrojMax { get; set; }


        public Drak(string jmeno, double zdravi, double zdraviMax, double poskozeniMax, double zbrojMax)
        {
            Jmeno = jmeno;
            Zdravi = zdravi;
            ZdraviMax = zdraviMax;
            PoskozeniMax = poskozeniMax;
            ZbrojMax = zbrojMax;
        }


        public double Utok(Hrdina oponent)
        {
            double hodnotaUtoku = 0;

            Kostka kostka = Kostka.Instance;
            hodnotaUtoku = kostka.NextDouble() * PoskozeniMax;
            hodnotaUtoku -= oponent.Obrana();
            oponent.SnizZdravi(hodnotaUtoku);

            return hodnotaUtoku > 0 ? hodnotaUtoku : 0;
        }

        public double Obrana()
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
