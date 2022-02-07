using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hrdina_a_drak
{
    public class Arena
    {
        public Hrdina Hrdina { get; set; }
        public Drak Drak { get; set; }

        public Arena(Hrdina hrdina, Drak drak)
        {
            Hrdina = hrdina;
            Drak = drak;
        }

        public string Boj()
        {
            string prubehBoje = String.Empty;


            while (Hrdina.JeZivy() && Drak.JeZivy())
            {
                double utokHrdiny = Hrdina.Utok(Drak);
                prubehBoje += $"Hrdina zaútočil hodnotou: {utokHrdiny} - Drakovi zbývá {Drak.Zdravi} bodů zdraví" + Environment.NewLine;
                if (Drak.JeZivy())
                {
                    double utokDraka = Drak.Utok(Hrdina);
                    prubehBoje += $"Drak zaútočil hodnotou: {utokDraka} - Hrdinovi zbývá {Hrdina.Zdravi} bodů zdraví" + Environment.NewLine;
                }
                prubehBoje += Environment.NewLine;
            }


            return prubehBoje;
        }
    }
}
