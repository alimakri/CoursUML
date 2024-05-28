// Thread.Sleep(3000);

using ConsoleAppD;

Compteur c1 = new Compteur 
{
    Min = 1,
    Max = 10,
    Couleur = ConsoleColor.Cyan,
    Pause = 500
};

Compteur c2 = new Compteur
{
    Min = 1,
    Max = 20,
    Couleur = ConsoleColor.Yellow,
    Pause = 300
};

var d1 = new CompteurDelegue(c1.Compter);
var d2 = new CompteurDelegue(c2.Compter);

d1.BeginInvoke(null, null);
d2.Invoke();


