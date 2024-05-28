using ConsoleAppA;

namespace ConsoleAppB
{
    public class D : A
    {
        public void AfficherP1() { Console.WriteLine(p1); }
        public void AfficherP3() { Console.WriteLine(p3); }
        public void AfficherP4()
        {
            A a1 = new A();
            Console.WriteLine(a1.p4);
        }
        public void AfficherP5() { Console.WriteLine(p5); }
    }
    public class E
    {
        public void AfficherP1()
        {
            A a1 = new A();
            Console.WriteLine(a1.p1);
        }
        public void AfficherP5()
        {
            A a1 = new A();
            Console.WriteLine(a1.p5);
        }
    }
}
