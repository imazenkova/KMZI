using System;

namespace Cripta_Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            NOD Nod = new NOD();
            PrimeNumber Prime = new PrimeNumber();

            Console.WriteLine("НОД(632,663) = " + Nod.Nod2(632, 663));
            Console.WriteLine("НОД(52,26,13) = " + Nod.Nod3(52, 26, 13));
            //Console.WriteLine(Nod.Nod3(1352, 12610, 169));

            Console.WriteLine("-------------------------------");
            
            Prime.printInterval(0, 663);
            Prime.printLog(433);

            Console.WriteLine("-------------------------------");

            Prime.printInterval(632, 663);

            Console.WriteLine("-------------------------------");

            Prime.printPrime(632663);
        }
    }
}
