using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppE
{
    public static class MethodesTexte : object
    {
        public static int NombreMots(this string s)
        {
            return s.Split(' ').Length;
        }
        public static int NombreMots(this StringBuilder s)
        {
            return s.ToString().NombreMots();
        }
    }
}
