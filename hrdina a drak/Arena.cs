using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hrdina_a_drak
{
    public class Arena
    {

        public List<Postava> Postavy { get; set; }

        public Arena(List<Postava> postavy)
        {
            Postavy = postavy;
        }

        public string Boj()
        {
            string prubehBoje = String.Empty;

            //Bedna bedna = new Bedna(100, 2);
            while (LzeBojovat())
            {
                for (int i = 0; i < Postavy.Count; ++i)
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
                        
                        /*double utokNaBednu = utocnik.Utok(bedna);
                        prubehBoje += $"{utocnik.Jmeno} rozbíjí bednu {utokNaBednu} - Bedně zbývá {bedna.Zdravi} bodů zdraví" + Environment.NewLine;*/
                    }
                    /*else
                    {
                        Postavy.RemoveAt(i);
                        --i;
                    }*/
                }
                prubehBoje += Environment.NewLine;
            }


            return prubehBoje;
        }

        public List<Postava> VratZivePostavy()
        {
            List<Postava> seznamPostav = new List<Postava>();
            foreach (var postava in Postavy)
            {
                if (postava.JeZivy())
                {
                    seznamPostav.Add(postava);
                }
            }
            return seznamPostav;
        }

        public bool LzeBojovat()
        {
            for (int i = 0; i < Postavy.Count; ++i)
            {
                if (Postavy[i].JeZivy() && Postavy[i].MaOponenta(Postavy))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
