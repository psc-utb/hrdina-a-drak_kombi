using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hrdina_a_drak
{
    public class Drak : Postava
    {
        
        public Drak(string jmeno, double zdravi, double zdraviMax, double poskozeniMax, double zbrojMax)
            : base(jmeno, zdravi, zdraviMax, poskozeniMax, zbrojMax)
        {
        }

        public override bool TestVyberuSpecifickehoOponenta(Postava oponent)
        {
            return oponent is not Drak;
        }

        public override Postava VyberOponenta(List<Postava> postavy)
        {
            return this.VyberOponenta(postavy, postava => postava is not Drak);
        }
    }
}
