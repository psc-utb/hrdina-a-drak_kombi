using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hrdina_a_drak
{
    public class Arena
    {

        public Postava[] Postavy { get; set; }

        public Arena(Postava[] postavy)
        {
            Postavy = postavy;
        }

        public string Boj()
        {
            string prubehBoje = String.Empty;


            while (LzeBojovat())
            {
                for (int i = 0; i < Postavy.Length; ++i)
                {
                    Postava utocnik = Postavy[i];
                    if (utocnik.JeZivy())
                    {
                        Postava oponent = utocnik.VyberOponenta(Postavy);
                        if (oponent != null)
                        {
                            double utok = utocnik.Utok(oponent);
                            prubehBoje += utocnik.ToString() + Environment.NewLine;
                            prubehBoje += $"{utocnik.Jmeno} zaútočil hodnotou: {utok} - {oponent.Jmeno} zbývá {oponent.Zdravi} bodů zdraví" + Environment.NewLine;
                        }
                    }
                }
                prubehBoje += Environment.NewLine;
            }


            return prubehBoje;
        }

        public bool LzeBojovat()
        {
            int pocetZivych = 0;
            for (int i = 0; i < Postavy.Length; ++i)
            {
                if (Postavy[i].JeZivy())
                {
                    pocetZivych++;

                    if (pocetZivych >= 2)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
