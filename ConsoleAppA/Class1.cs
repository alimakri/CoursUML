using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppA
{
    public class A
    {
        public int p1 = 77;
        private int p2 = 88;
        protected int p3 = 88;
        internal int p4 = 99;
        internal protected int p5 = 66;
        public void AfficherP1()
        {
            Console.WriteLine(p1);
            Console.WriteLine(p2);
            Console.WriteLine(p3);
            Console.WriteLine(p4);
            Console.WriteLine(p5);
        }

    }
    public class B : A
    {
        public void AfficherP1() { Console.WriteLine(p1); }
        public void AfficherP3() { Console.WriteLine(p3); }
        public void AfficherP4() { Console.WriteLine(p4); }
        public void AfficherP5() { Console.WriteLine(p5); }
    }
    public class C
    {
        public void AfficherP1()
        {
            A a1 = new A();
            Console.WriteLine(a1.p1);
        }
        public void AfficherP4()
        {
            A a1 = new A();
            Console.WriteLine(a1.p4);
        }
        public void AfficherP5()
        {
            A a1 = new A();
            Console.WriteLine(a1.p5);
        }
    }
}
