using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace _02a;
// Procvičení základů
// =====================

// 1. Napište program, který se zeptá na dvě čísla a zobrazí jejich součet.

class Program
{
    static void Main(string[] args)
    {
        static double ReadAndValidateDouble()
        {
            bool isNumber = false;
            double Number = 0;
            while(!isNumber)
            {
            Console.WriteLine("Zadej číslo:");
            isNumber= double.TryParse(Console.ReadLine(), out Number);
            if (!isNumber)
            {
                Console.WriteLine("Neplatný vstup.");
            }
            }
            return Number;
        }

        static double Add(double a, double b)
        {
            return a + b;
        }

        double prvniCislo = ReadAndValidateDouble();
        double druheCislo = ReadAndValidateDouble();
        Console.WriteLine(Add(prvniCislo, druheCislo));

        // 2. Napište program, který se zeptá na počet hvězdiček a potom je v cyklu zobrazí na konzoli.
        static int ReadAndValidateInt()
        {
            bool isNumber = false;
            int Number = 0;
            while(!isNumber)
            {
            Console.WriteLine("Zadej počet hvězdiček:");
            isNumber= int.TryParse(Console.ReadLine(), out Number);
            if (!isNumber)
            {
                Console.WriteLine("Neplatný vstup.");
            }
            }
            return Number;
        }

        int pocetHvezd = ReadAndValidateInt();
        for (int i = 0; i < pocetHvezd; i++)
        {
            Console.WriteLine("*");
        }
    }
}


