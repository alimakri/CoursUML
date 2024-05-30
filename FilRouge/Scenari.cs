using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge
{
    internal static class Scenari
    {
        /// <summary>
        /// Cas d'utilisation création et affichage des établissements
        /// </summary>
        public static void Scenario1()
        {
            Console.Write("Nom: ");
            var nom = Console.ReadLine();
            Console.Write("Mot de passe: ");
            var password = Console.ReadLine();
            var superAdmin = new SuperAdmin(nom, password, RoleEnum.SuperAdmin);
            if (!superAdmin.Autorise)
            {
                Console.WriteLine("Erreur d'identification");
            }
            else
            {
                Console.Write("Nom établissement: ");
                var nomE = Console.ReadLine();
                var etablissement = new Etablissement
                {
                    Libelle = nomE
                };
                Commun.Etablissements.Add(etablissement);
            }
        }

        internal static void Scenario2()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            foreach(var etab in Commun.Etablissements)
            {
                Console.WriteLine(etab.Libelle);
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }

}