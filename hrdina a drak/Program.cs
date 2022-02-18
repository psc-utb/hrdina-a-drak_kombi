using System;

namespace hrdina_a_drak
{
    class Program
    {
        static void Main(string[] args)
        {
            //Kostka kostka = ;
            Mec Mec = new Mec(10);
            Hrdina hrdina = new Hrdina("Geralt", 100, 100, 5, 0, Mec);
            Drak drak = new Drak("Alduin", 100, 100, 10, 0);
            //Vlk vlk = new Vlk("Wolfie", 100, 100, 5, 5);
            Postava[] postavy = new Postava[] { hrdina, drak/*, vlk*/ };

            Arena arena = new Arena(postavy);
            string prubehBoje = arena.Boj();

            Console.WriteLine(prubehBoje);
        }
    }
}
