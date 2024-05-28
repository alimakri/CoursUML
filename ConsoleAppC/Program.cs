
using ConsoleAppC;

var animaux = new List<Animal>
{
    new Chien{Nom="Beethoven"},
    new Chien{Nom="Clifford"},
    new Chat{Nom="Grosminet"},
    new Cheval{Nom="Spirit"},
    new Elephant{Nom="Dumbo"}
};

// delegate
var delegues = new List<AnimalDelegate>
{
    new AnimalDelegate(((Chien)animaux[0]).Parler),
    new AnimalDelegate(((Chien)animaux[1]).Parler),
    new AnimalDelegate(((Chat)animaux[2]).Parler),
    new AnimalDelegate(((Cheval)animaux[3]).Parler),
    new AnimalDelegate(((Elephant)animaux[4]).Parler),
};

foreach (var delegue in delegues)
{
    delegue(3);
}
//foreach (var animal in animaux)
//{
//    if (animal is Chien) ((Chien)animal).Parler();
//    else if (animal is Chat) ((Chat)animal).Parler();
//    else if (animal is Cheval) ((Cheval)animal).Parler();
//}