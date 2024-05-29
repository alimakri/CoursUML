using ConsoleAppE;
using System.Text;

StringBuilder phrase = new StringBuilder( "8 threads plus de threads de processeur");
int nCar = phrase.Length;
int nMots = phrase.NombreMots();

//int nMots = Class1.NombreMots(phrase);


Console.WriteLine(nMots);
Console.ReadLine();