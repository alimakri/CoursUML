using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppD2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Compteur c1 = new Compteur
            {
                Min = 1,
                Max = 10,
                Couleur = ConsoleColor.Cyan,
                Pause = 3000
            };

            Compteur c2 = new Compteur
            {
                Min = 1,
                Max = 20,
                Couleur = ConsoleColor.Yellow,
                Pause = 2000
            };

            var d1 = new CompteurDelegue(c1.Compter);
            var d2 = new CompteurDelegue(c2.Compter);

            d1.BeginInvoke(null, null);
            d2.BeginInvoke(null, null);

            Console.ReadLine();
        }
    }
}
