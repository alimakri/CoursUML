using ConsoleApp7;
using System.Drawing;

// Type Valeur : int, bool, decimal...
int i = 1;
int j = 2;
i = j;
Console.WriteLine(i);
Console.WriteLine(j);

// Type référence
Personne p1 = new Personne { Nom = "Pierre" };
Personne p2;
p2 = p1;
p2.Nom = "Paul";
Console.WriteLine(p1.Nom);

// Type valeur : enum, struct
Couleur c1 = Couleur.Rouge;
Couleur c2 = (Couleur)20;
Couleur jaune = Couleur.Rouge | Couleur.Bleu;
Console.BackgroundColor = (ConsoleColor)jaune;
Employe e1;
e1.Nom = "Yannick";
