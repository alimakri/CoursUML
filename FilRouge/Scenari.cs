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
                    Id = Commun.Etablissements.Count + 1,
                    Libelle = nomE
                };
                Commun.Etablissements.Add(etablissement);
            }
        }

        // Liste d'etab
        internal static void Scenario2()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var etab in Commun.Etablissements)
            {
                Console.WriteLine("{0}. {1}", etab.Id, etab.Libelle);
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        internal static void Scenario3()
        {
            Console.WriteLine("Quel etablissement ?");
            var saisie = Console.ReadLine() ?? "0";
            var etabSup = Commun.Etablissements.FirstOrDefault(x => x.Id == int.Parse(saisie));
            if (etabSup != null)
            {
                Commun.Etablissements.Remove(etabSup);
            }
        }


        public static void Scenario4()
        {
            Console.Write("Nom admin: ");
            var nomAdmin = Console.ReadLine();
            var role = Console.ReadLine();
            var admin = new Admin
            {
                Id = Commun.Utilisateurs.Count + 1,
                Nom = nomAdmin,
                Role = role == "1" ? RoleEnum.SuperAdmin : RoleEnum.Admin
            };
            Commun.Utilisateurs.Add(admin);
        }

        // Liste d'admin
        internal static void Scenario5()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            var admins = Commun.Utilisateurs.Where(x => x.Role == RoleEnum.Admin);
            foreach (var admin in admins)
            {
                Console.WriteLine("{0}. {1}", admin.Id, admin.Nom);
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        internal static void Scenario6()
        {
            Console.WriteLine("Quel admin ?");
            var saisie = Console.ReadLine() ?? "0";
            var adminSup = Commun.Utilisateurs
                .FirstOrDefault(x => x.Role == RoleEnum.Admin && x.Id == int.Parse(saisie));
            if (adminSup != null)
            {
                Commun.Utilisateurs.Remove(adminSup);
            }
        }
        internal static void Scenario6()
        {
        }
    }

}