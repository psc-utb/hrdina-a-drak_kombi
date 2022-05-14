using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace hrdina_a_drak
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Kostka kostka = ;
            Mec Mec = new Mec(10);
            Hrdina hrdina = new Hrdina("Geralt", 100, 100, 5, 20, Mec);
            Hrdina hrdina2 = new Hrdina("Dovakhin", 200, 100, 5, 5, Mec);
            Hrdina hrdina3 = new Hrdina("Hero", 100, 100, 5, 10, Mec);
            Hrdina hrdina10 = new Hrdina("Hero10", 100, 100, 5, 10, Mec);
            Hrdina hrdina20 = new Hrdina("Hero20", 100, 100, 5, 10, Mec);
            Drak drak = new Drak("Alduin", 100, 100, 10, 10);
            Drak drak2 = new Drak("Šmak", 200, 100, 10, 10);
            Drak drak3 = new Drak("Drak", 100, 100, 10, 5);
            Drak drak10 = new Drak("Drak10", 100, 100, 10, 5);
            Drak drak20 = new Drak("Drak20", 100, 100, 10, 5);
            Vlk vlk = new Vlk("Wolfie", 100, 100, 5, 5);
            Vlk vlk2 = new Vlk("Vlk", 100, 100, 5, 5);
            Vlk vlk3 = new Vlk("Vlkodlak", 100, 100, 7, 5);
            Vlk vlk4 = new Vlk("Malý vlk", 70, 70, 7, 5);
            Vlk vlk10 = new Vlk("Malý vlk 10", 70, 70, 7, 5);
            Vlk vlk20 = new Vlk("Malý vlk 20", 70, 70, 7, 5);
            List<Postava> postavy = new List<Postava> { vlk, hrdina, vlk3, drak2, hrdina2, drak3, vlk2 };
            List<Postava> postavy2 = new List<Postava> { vlk10, hrdina10, drak10 };
            List<Postava> postavy3 = new List<Postava> { vlk20, hrdina20, drak20 };
            postavy.Add(drak);
            postavy.Add(hrdina3);
            postavy.Add(vlk4);

            /*
            //seřazení postav
            Array.Sort(postavy);
            //prohozeni prvku pole
            Array.Reverse(postavy);
            foreach (var postava in postavy)
            {
                Console.WriteLine(postava.ToString());
            }
            Console.WriteLine(String.Empty + Environment.NewLine);
            */

            Arena arena = new Arena(postavy);
            string statistiky = arena.StatistikyPostav();
            string prubehBoje = arena.Boj();
            Console.WriteLine(statistiky + Environment.NewLine + Environment.NewLine);
            Console.WriteLine(prubehBoje + Environment.NewLine);
            try
            {
                File.WriteAllText($"boj-{DateTime.Now.Date.Year}-{DateTime.Now.Date.Month}-{DateTime.Now.Date.Day} {DateTime.Now.Hour}_{DateTime.Now.Minute}_{DateTime.Now.Second}_{DateTime.Now.Millisecond}.txt", prubehBoje);
            }
            catch(Exception ex)
            {
                Console.WriteLine(Environment.NewLine + ex.Message + Environment.NewLine);
            }
            /*using (StreamWriter stream = new StreamWriter("boj.txt"))
            {
                stream.WriteLine(prubehBoje);
            }*/

            List<Postava> zivePostavy = arena.VratZivePostavy();
            foreach (var postava in zivePostavy)
            {
                Console.WriteLine(postava.ToString());
            }




            Arena arena2 = new Arena(postavy2);
            Arena arena3 = new Arena(postavy3);
            string prubehBoje2 = await arena2.BojAsync();
            Task<string> taskBoje = arena3.BojAsync();
            arena3.BojBylDokoncen += prubeh => Console.WriteLine(prubeh + Environment.NewLine);


            Console.ReadKey();
        }
    }
}
