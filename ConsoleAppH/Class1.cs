using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppH
{
    internal class Factoriel
    {
        int i = default;
        public int Calcul(int n)
        {
            if (n == 0 || n == 1) return 1;
            return n * Calcul(n - 1);
        }
    }
}
