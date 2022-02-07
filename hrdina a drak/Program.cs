using System;

namespace hrdina_a_drak
{
    class Program
    {
        static void Main(string[] args)
        {
            //Kostka kostka = ;
            Hrdina hrdina = new Hrdina("Geralt", 100, 100, 10, 0);
            Drak drak = new Drak("Alduin", 100, 100, 11, 0);

            Arena arena = new Arena(hrdina, drak);
            string prubehBoje = arena.Boj();

            Console.WriteLine(prubehBoje);
        }
    }
}
