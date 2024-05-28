using System.Threading;
using System;

namespace ConsoleAppD2
{
    internal class Compteur
    {
        public int Min = 1;
        public int Max = 10;
        public ConsoleColor Couleur = ConsoleColor.Green;
        public int Pause;
        public void Compter()
        {
            for (int i = Min; i <= Max; i++)
            {
                Console.ForegroundColor = Couleur;
                Console.WriteLine(i);
                Thread.Sleep(Pause);
            }
        }
    }
    public delegate void CompteurDelegue();
}
