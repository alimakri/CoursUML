using ConsoleApp5;

var v1 = new Voiture();
v1.Rouler();

Voiture v2;
var saisie = Console.ReadLine();
//if(saisie == "1")
//    v2 = new Voiture();
//else if (saisie == "2")
//    v2 = new CoupeSport();
//else 
//    v2 = new CoupeSportdeLuxe();
switch(saisie)
{
    case "1": v2 = new Voiture(); break;
    case "2": v2 = new CoupeSport(); break;
    default: v2 = new CoupeSportdeLuxe(); break;
}
v2.Rouler();