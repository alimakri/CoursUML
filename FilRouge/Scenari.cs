using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge
{
    internal static class Scenari
    {
        public static void Scenario0()
        {
            Console.Write("Nom: ");
            var nom = Console.ReadLine();
            Console.Write("Mot de passe: ");
            var password = Console.ReadLine();
            Commun.SuperAdmin = new SuperAdmin(nom, password, RoleEnum.SuperAdmin);
        }

        #region Etablissement
        /// <summary>
        /// Cas d'utilisation création d'un établissement
        /// </summary>
        public static void Scenario1()
        {
            Console.Write("Nom établissement: ");
            var nomE = Console.ReadLine();
            var etablissement = new Etablissement
            {
                Id = Data.GetEtablissements().Count + 1,
                Libelle = nomE
            };
            Data.AddEtablissement(etablissement);
        }

        /// <summary>
        /// Cas d'utilisation Liste des établissements
        /// </summary>
        internal static void Scenario2()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;

            foreach (var etab in Commun.GetEtablissements())
            {
                Console.WriteLine("{0}. {1}", etab.Id, etab.Libelle);
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Cas d'utilisation Suppression d'un établissement
        /// </summary>
        internal static void Scenario3()
        {
            Console.WriteLine("Quel etablissement ?");
            var saisieStr = Console.ReadLine() ?? "0";
            int saisie = 0;
            int.TryParse(saisieStr, out saisie);
            if (saisie != 0) Commun.DeleteEtablissement(saisie);
        }
        #endregion

        #region Admin
        /// <summary>
        /// Cas d'utilisation création d'un admin
        /// </summary>
        public static void Scenario4()
        {
            Console.Write("Nom admin: ");
            var nomAdmin = Console.ReadLine();
            Console.Write("Role admin (1) SuperAdmin (2) Admin: ");
            var role = Console.ReadLine();
            var admin = new Admin
            {
                Id = Data.GetUtilisateurs(RoleEnum.None).Count + 1,
                Nom = nomAdmin,
                Role = role == "1" ? RoleEnum.SuperAdmin : RoleEnum.Admin
            };
            Data.AddUtilisateur(admin);
        }

        /// <summary>
        /// Cas d'utilisation Liste des admins
        /// </summary>
        internal static void Scenario5()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            var admins = Commun.GetAdmins();
            foreach (var admin in admins)
            {
                Console.WriteLine("{0}. {1}", admin.Id, admin.Nom);
                foreach (var etab in admin.LesEtablissements)
                {
                    Console.WriteLine("\t{0}. {1}", etab.Id, etab.Libelle);
                }
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Cas d'utilisation Suppression d'un admin
        /// </summary>
        internal static void Scenario6()
        {
            Console.WriteLine("Quel admin ?");
            var saisie = Console.ReadLine() ?? "0";
            Commun.DeleteAdmin(int.Parse(saisie));

        }

        /// <summary>
        /// Cas d'utilisation Associer un établissement avec un admin
        /// </summary>
        internal static void Scenario7()
        {
            Console.WriteLine("Quel etablissement ?");
            var etabId = Console.ReadLine() ?? "0";
            Console.WriteLine("Quel admin ?");
            var adminId = Console.ReadLine() ?? "0";
            var etab = Commun.GetEtablissement(int.Parse(etabId));
            var admin = Commun.GetAdmin(int.Parse(adminId));
            if (etab != null && admin != null)
            {
                admin.LesEtablissements.Add(etab);
                Commun.AssocierEtabAdmin(etab, admin);
            }
        }
        /// <summary>
        /// Cas d'utilisation Dissocier un établissement avec un admin
        /// </summary>
        internal static void Scenario8()
        {
            Console.WriteLine("Quel etablissement ?");
            var etabId = Console.ReadLine() ?? "0";
            Console.WriteLine("Quel admin ?");
            var adminId = Console.ReadLine() ?? "0";
            var etab = Commun.GetEtablissement(int.Parse(etabId));
            var admin = Commun.GetAdmin(int.Parse(adminId));
            if (etab != null && admin != null)
            {
                admin.LesEtablissements.Remove(etab);
                Commun.DissocierEtabAdmin(etab, admin);
            }
        }
        /// <summary>
        /// Cas d'utilisation noter un élève pour un module donné
        /// </summary>
        internal static void Scenario9()
        {
            Console.WriteLine("Quelle session ?");
            var sessionId = Console.ReadLine() ?? "0";
            Console.WriteLine("Quel module ?");
            var moduleId = Console.ReadLine() ?? "0";
            Console.WriteLine("Quel élève ?");
            var eleveId = Console.ReadLine() ?? "0";

            var module = Commun.GetModule(int.Parse(moduleId));
            var eleve = Commun.GetEleveByModule(int.Parse(sessionId), int.Parse(moduleId), int.Parse(eleveId));
            if (module != null && eleve != null)
            {
                Console.WriteLine("Quelle note ?");
                var note = Console.ReadLine();
                Console.WriteLine("Quel commentaire ?");
                var commentaire = Console.ReadLine();
                Commun.AffecterNote(module, eleve, note, commentaire);
            }
        }
        #endregion

    }

}