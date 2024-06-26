﻿// Instancier 3 objets Maison :
// une bleue avec 2 portes d'entrée code1 123 code2 456,
// une rouge avec 1 portes d'entrée code 789
// une verte avec 1 portes d'entrée code 000
// Définir une propriété indiquant le nombre de maisons instanciées

using ConsoleApp3_Exo1;

Maison maison1 = new Maison();
maison1.Couleur = "Bleu";
//maison1.Porte1 = new Porte();
//maison1.Porte2 = new Porte();
//maison1.Porte1.Code = "123";
//maison1.Porte2.Code = "456";

//maison1.Portes = new List<Porte>();
//Porte porte1 = new Porte();
//porte1.Code = "123";
//maison1.Portes.Add(porte1);
//Porte porte2 = new Porte();
//porte2.Code = "456";
//maison1.Portes.Add(porte2);

maison1.Portes = new List<Porte>
{
    new Porte { Code = "123" },
    new Porte { Code = "456" }
};
maison1.Couleur = "Bleu";
Maison.Nombre++;

//Maison maison2 = new Maison();
//maison2.Couleur = "Rouge";
//maison2.Porte1 = new Porte();
//maison2.Porte1.Code = "789";
//Maison.Nombre++;

Maison maison2 = new Maison
{
    Couleur = "Rouge",
    Portes = new List<Porte>
    {
    new Porte { Code = "789" },
    }
};
Maison.Nombre++;

//Maison maison3 = new Maison();
//maison3.Couleur = "Vert";
//maison3.Porte1 = new Porte();
//maison3.Porte1.Code = "000";
//Maison.Nombre++;
Maison maison3 = new Maison
{
    Couleur = "Vert",
    Portes = new List<Porte>
    {
    new Porte { Code = "000" },
    }
};
Maison.Nombre++;

Console.WriteLine("il y a {0} maison(s)", Maison.Nombre);
Console.WriteLine(maison1.Portes[1].Code);

