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

        public event Action<string> BojBylDokoncen;

        public Arena(List<Postava> postavy)
        {
            Postavy = postavy;
            Postavy.ForEach(postava => postava.VybranNovyOponent += ReakceNaUdalostVybranNovyOponent);
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

            BojBylDokoncen?.Invoke(prubehBoje);
            return prubehBoje;
        }

        public Task<string> BojAsync()
        {
            return Task.Run(Boj);
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

        public string StatistikyPostav()
        {
            string statistiky = String.Empty;

            double prumernaSilaPostav = Postavy.Average(postava => postava.VypocitejSilu());
            statistiky += $"Průměrná síla postav je: {prumernaSilaPostav}" + Environment.NewLine;

            double minimalniSila = Postavy.Min(postava => postava.VypocitejSilu());
            Postava nejslabsiPostava = Postavy.Find(postava => postava.VypocitejSilu() == minimalniSila);
            statistiky += $"Nejslabší postava je: {nejslabsiPostava.ToString()}" + Environment.NewLine;

            List<Postava> draci = Postavy.FindAll(pos => pos is Drak);
            draci.ForEach(postava => statistiky += $"Drak: {postava.ToString()}" + Environment.NewLine);

            return statistiky;
        }

        protected void ReakceNaUdalostVybranNovyOponent(Postava utocnik, Postava oponent)
        {
            Console.WriteLine($"Postava: {utocnik.Jmeno} si vybrala nového oponenta: {oponent.Jmeno}");
        }
    }
}
