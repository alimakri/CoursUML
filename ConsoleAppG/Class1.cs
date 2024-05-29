using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppG
{
    internal class Personne
    {
        public string Name;
        public DateTime DateNaissance;
        public double Age
        {
            get
            {
                return (DateTime.Now - DateNaissance).TotalDays / 365;
            }
        }

    }
}
