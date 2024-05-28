namespace ConsoleAppC
{
    public class Animal
    {
        public event AnimalDelegate Tonnerre;
        public string Nom;
    }
    public class Chien : Animal
    {
        public void Parler(int n)
        {
            Console.WriteLine("{0} aboie {1} fois", Nom, n);
        }
    }
    public class Chat : Animal
    {
        public void Parler(int n)
        {
            Console.WriteLine("{0} miaule {1} fois", Nom, n);
        }
    }
    public class Cheval : Animal
    {
        public void Parler(int n)
        {
            Console.WriteLine("{0} hénit {1} fois", Nom, n);
        }
    }
    public class Elephant : Animal
    {
        public void Parler(int n)
        {
            Console.WriteLine("{0} barrit {1} fois", Nom, n);
        }
    }

    public delegate void AnimalDelegate(int n);
}
