using ConsoleApp1.Niveau2;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine(Personne1.Nom);
            Console.WriteLine(Personne1.Prenom);
            Console.WriteLine(Personne1.Age);

            Console.WriteLine(Personne2.Nom);
            Console.WriteLine(Personne2.Prenom);
            Console.WriteLine(Personne2.Age);

        }
    }
    namespace Niveau2
    {
        public static class Personne1
        {
            public static string Nom = "Dupont";
            public static string Prenom = "Pierre";
            public static int Age = 25;

        }
        public static class Personne2
        {
            public static string Nom = "Durand";
            public static string Prenom = "Paul";
            public static int Age = 35;

        }
    }
    namespace Niveau3
    {
        namespace Niveau4
        {
            class Program
            {
                public static void Main2()
                {
                    Console.WriteLine("Hello 2");
                }
            }
        }
    }
}
