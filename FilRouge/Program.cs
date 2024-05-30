using FilRouge;

string saisie = "";
while (saisie != "0")
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("Choisissez le cas d'utilisation :");
    Console.WriteLine("0. Quitter");
    Console.WriteLine("1. Création d'établissement");
    Console.WriteLine("2. Liste des établissements");
    Console.WriteLine("3. Supprimer un établissement");

    Console.WriteLine("4. Création d'un admin");
    Console.WriteLine("5. Liste des admins");
    Console.WriteLine("6. Supprimer un admin");
    Console.WriteLine("7. Associer un etablissement avec un admin");
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

        default: 
            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine("Choix incorrect");
            Console.ForegroundColor = ConsoleColor.Gray;
            break;
    }
}
