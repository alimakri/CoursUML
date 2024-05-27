using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3_Exo1
{
    public class Maison
    {
        public string Couleur = "Blanc";
        public Porte Porte1 = null;
        public Porte Porte2;
        public static int Nombre = 0;
    }
    public class Porte
    {
        public string Code = "000";
    }
}
