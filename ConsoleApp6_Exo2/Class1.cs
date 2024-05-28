using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6_Exo2
{
    public class Entreprise
    {
        private List<Employe> list = new List<Employe>();
        public void Add(Employe e)
        {
            list.Add(e);
        }
        public void AfficherTousLesSalaires()
        {
            foreach (Employe e in list)
            {
                Console.WriteLine("{0} a un salaire de {1}", e.Nom, e.Salaire);
                //if (e is Patron)
                //{
                //    Console.WriteLine("{0} a un salaire de {1}", e.Nom, e.Salaire * 1.4M);
                //}
                //else if (e is Directeur)
                //{
                //    Console.WriteLine("{0} a un salaire de {1}", e.Nom, e.Salaire + 1000);
                //}
                //else if (e is Employe)
                //{
                //    Console.WriteLine("{0} a un salaire de {1}", e.Nom, e.Salaire);
                //}
            }
        }
    }
    public class Employe
    {
        public string Nom = "Inconnu";
        public decimal Salaire = 0;
        public Employe(string nom, decimal salaire)
        {
            Nom = nom;
            Salaire = salaire;
        }
        public Employe()
        {
            
        }
    }
    public class Directeur : Employe
    {
        public Directeur(string nom, decimal salaire) : base(nom, salaire)
        {            
            Salaire += 1000;
        }
    }
    public class Patron : Employe
    {
        public Patron(string nom, decimal salaire) : base(nom, salaire)
        {
            Salaire *= 1.4M;
        }
    }
}
