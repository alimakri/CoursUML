using ConsoleAppG;

var p1 = new Personne();
p1.Name = "Bob";
p1.DateNaissance = new DateTime(2000, 5, 29);
Console.WriteLine(p1.Age);
p1.DateNaissance = new DateTime(2012, 5, 29);
Console.WriteLine(p1.Age);

Console.ReadLine();
