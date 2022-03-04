using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hrdina_a_drak
{
    public class Bedna : IZasazitelne
    {
        public double Zdravi { get; set; }
        public double Odolnost { get; set; }

        public Bedna(double zdravi, double odolnost)
        {
            Zdravi = zdravi;
            Odolnost = odolnost;
        }

        public bool JeZivy()
        {
            if (Zdravi > 0)
                return true;
            else
                return false;
        }

        public double Obrana()
        {
            return Odolnost;
        }

        public void SnizZdravi(double hodnotaSnizeniZdravi)
        {
            if (hodnotaSnizeniZdravi > 0)
                Zdravi -= hodnotaSnizeniZdravi;
        }
    }
}
