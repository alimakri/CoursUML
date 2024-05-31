using FilRouge;

Data.Init();
//Commun.Init();
Scenari.Scenario0();

if (Commun.SuperAdmin.Autorise)
{
    string saisie = "";
    while (saisie != "0")
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("Choisissez le cas d'utilisation :");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("0. Quitter");
        Console.WriteLine("1. Création d'établissement");
        Console.WriteLine("2. Liste des établissements");
        Console.WriteLine("3. Supprimer un établissement");

        Console.WriteLine("4. Création d'un admin");
        Console.WriteLine("5. Liste des admins");
        Console.WriteLine("6. Supprimer un admin");
        Console.WriteLine("7. Associer un etablissement avec un admin");
        Console.WriteLine("8. Retirer un etablissement d'un admin");

        Console.WriteLine("9. Noter et commenter un élève pour un module");
        Console.WriteLine("10. Noter et commenter chaque élève par module attribué");
        Console.ForegroundColor = ConsoleColor.Gray;

        saisie = Console.ReadLine() ?? "";
        switch (saisie)
        {
            case "0": break;
            case "1": Scenari.Scenario1(); break;
            case "2": Scenari.Scenario2(); break;
            case "3": Scenari.Scenario3(); break;

            case "4": Scenari.Scenario4(); break;
            case "5": Scenari.Scenario5(); break;
            case "6": Scenari.Scenario6(); break;

            case "7": Scenari.Scenario7(); break;
            case "8": Scenari.Scenario8(); break;
            case "9": Scenari.Scenario9(); break;

            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Choix incorrect");
                Console.ForegroundColor = ConsoleColor.Gray;
                break;
        }
    }
}