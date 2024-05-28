namespace ConsoleApp9
{
    public interface IVehicule
    {
        void Rouler();
    }
    public class Auto : IHabitation, IVehicule
    {
        public void Rouler() { Console.WriteLine("L'auto roule"); }
        public void Habiter() { Console.WriteLine("J'habite dans l'auto"); }
    }
    public class Moto : IVehicule
    {
        public void Rouler() { Console.WriteLine("La moto roule"); }
    }
    public interface IHabitation
    {
        void Habiter();
    }
}
