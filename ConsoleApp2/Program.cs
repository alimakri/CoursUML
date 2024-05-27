using ConsoleApp2;

Personne personne1 = null;
personne1 = new Personne();
Personne personne3;
personne3 = personne1;
personne3.Nom = "Duchemin";

Personne personne2 = new Personne();
{
    string maChaine;
    int i = 7;
    int j = 8;
    i = j;
    j = 10;
}
string s = maChaine;

personne2.Nom = "Durand";

Console.WriteLine(personne1.Nom);
Console.WriteLine(personne2.Nom);
Console.WriteLine(Personne.Nombre); // Correct
Console.WriteLine(i);
Console.WriteLine(j);

//Console.WriteLine(personne1.Nombre); // Incorrect
//Console.WriteLine(Personne.Nom); // Incorrect
