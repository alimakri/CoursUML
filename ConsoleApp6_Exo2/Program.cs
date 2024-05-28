// L'entreprise M2i a des salariés organisés sur 3 échelons
// les employés
// les directeurs
// le patron
// Ils ont tous un salaire de base mais les directeurs ont une prime de 
// 1000€ et le patron une prime de 40%  de son salaire de base.
// Ecrire le code affichant les salaires de chacun.
using ConsoleApp6_Exo2;

var m2i = new Entreprise();
var jeremy = new Employe("Jeremy", 2000);
var sophie = new Directeur("Sophie", 3000);
var claire = new Patron("Claire", 4000);

var henri = new Employe();
henri.Nom = "Henri";
henri.Salaire = 1500;

m2i.Add(jeremy);
m2i.Add(sophie);
m2i.Add(claire);
m2i.AfficherTousLesSalaires();

// Jeremy a un salaire de 2000
// Sophie a un salaire de 4000
// Claire a un salaire de 5600
