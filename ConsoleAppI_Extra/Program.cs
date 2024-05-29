var tableau = new int[5] { 2, 35, 98, 40, 6 };

// Version 1
//List<int> pairs = new List<int>();
//foreach (int i in tableau)
//{
//    if(i%2==0) pairs.Add(i);
//}

// Version Linq
var paires = tableau.Where(x => x % 2 == 0);
var grandsPairs = paires.Where(x => x > 30);

foreach (int i in grandsPairs)
{
    Console.WriteLine(i);
}
Console.ReadLine();