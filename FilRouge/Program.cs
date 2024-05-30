using FilRouge;

string saisie = "";
while (saisie != "0")
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("Choisissez le cas d'utilisation :");
    Console.WriteLine("0. Quitter");
    Console.WriteLine("1. Création d'établissement");
    Console.WriteLine("2. Liste des établissements");
    Console.ForegroundColor = ConsoleColor.Gray;

    saisie = Console.ReadLine() ?? "";
    switch (saisie)
    {
        case "0": break;
        case "1": Scenari.Scenario1(); break;
        case "2": Scenari.Scenario2(); break;
        default: 
            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine("Choix incorrect"); break;
            Console.ForegroundColor = ConsoleColor.Gray;
    }
}
