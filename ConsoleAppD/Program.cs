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

List<CompteurDelegue> liste = new List<CompteurDelegue>();
liste.Add(c1.Compter);
liste.Add(c2.Compter);
foreach(var d in liste)
{
    d();
}

