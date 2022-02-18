using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hrdina_a_drak
{
    public class Vlk : Postava
    {
        public Vlk(string jmeno, double zdravi, double zdraviMax, double poskozeniMax, double zbrojMax)
               : base(jmeno, zdravi, zdraviMax, poskozeniMax, zbrojMax)
        {
        }

        public override bool TestVyberuSpecifickehoOponenta(Postava oponent)
        {
            return oponent is not Vlk;
        }
    }
}