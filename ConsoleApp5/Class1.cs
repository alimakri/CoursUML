// Polymorphisme
namespace ConsoleApp5
{
    public class Voiture
    {
        public virtual void Rouler()
        {
            Console.WriteLine("La voiture roule");
        }
    }
    public class CoupeSport : Voiture
    {
        public override void Rouler()
        {
            Console.WriteLine("Le CoupeSport roule");
        }
        public bool Cabriolet = false;
    }
    public class CoupeSportdeLuxe : CoupeSport
    {
        public override void Rouler()
        {
            Console.WriteLine("Le CoupeSportdeLuxe roule");
        }
        public string Cout = "élevé";
    }
}
