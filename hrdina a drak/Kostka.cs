using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hrdina_a_drak
{
    public class Kostka
    {

        private Random random;

        private static Kostka instance;// = new Kostka();
        public static Kostka Instance
        {
            get
            {
                if (instance == null)
                    instance = new Kostka();

                return instance;
            }
        }

        private Kostka()
        {
            random = new Random();
        }

        public double NextDouble()
        {
            return random.NextDouble();
        }

    }
}
