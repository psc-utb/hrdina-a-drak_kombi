using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hrdina_a_drak
{
    public class Kostka : Random
    {

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
        }


    }
}
