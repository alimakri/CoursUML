namespace ConsoleApp8
{
    public abstract class Vehicule
    {
        public abstract void Rouler();
        public void Arreter() { }
    }
    public class Auto : Vehicule, Habitation
    {
        public override void Rouler() { Console.WriteLine("L'auto roule"); }
    }
    public class Moto : Vehicule
    {
        public override void Rouler() { Console.WriteLine("La moto roule"); }
    }
    public class Habitation
    {

    }
}
