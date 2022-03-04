using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hrdina_a_drak
{
    public class Hrdina : Postava
    {
        public Mec Mec { get; set; }

        public Hrdina(string jmeno, double zdravi, double zdraviMax, double poskozeniMax, double zbrojMax, Mec mec)
            : base(jmeno, zdravi, zdraviMax, poskozeniMax, zbrojMax)
        {
            Mec = mec;
        }

        public override double Utok(IZasazitelne oponent)
        {
            if (Mec != null)
            {
                return GenerovaniUtoku(Mec.PoskozeniMax, oponent);
            }
            else
            {
                return base.Utok(oponent);
                //return GenerovaniUtoku(PoskozeniMax, oponent);
            }
        }

        public override string ToString()
        {
            return typeof(Hrdina).ToString() + ": " + $"{Jmeno}, {Zdravi}/{ZdraviMax}, {PoskozeniMax}-{Mec.PoskozeniMax}, {ZbrojMax}, {VypocitejSilu()}";
        }

        public override bool TestVyberuSpecifickehoOponenta(Postava oponent)
        {
            return true;
        }
    }
}
