using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace ukol04
{
    internal class Program
    {
        public static bool DoesListContainValue(string value, List<string> listOfValues)
            {
                if (listOfValues.Contains(value))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        public static Dictionary<string, int[]> AddItemToShoppingList(Dictionary<string, int[]> d, string item)
            {
                if (d.ContainsKey(item))
                {
                    d[item][1] ++ ;
                    return d;
                }
                else
                {   bool testNumber = false;
                    while (!testNumber)
                    {
                    Console.WriteLine($"zadej cenu za jeden kus položky {item}:");
                    testNumber = int.TryParse(Console.ReadLine(), out int number);
                    d[item] = [number, 1];
                    }
                    return d;
                }
            }

        static void Main(string[] args)
        {
            // 1. Vypiš aktuální datum a čas, nemusíš řešit, v kterém je to časovém pásmu.

            DateTime now = DateTime.Now;
            Console.WriteLine(now);

            // 2. Vytvoř proměnnou typu DateTime a ulož do ní svoje datum narození. Potom vypiš, kolik dnů od té doby uteklo.

            DateTime myBirthday = new DateTime(1985, 11, 24);
            Console.WriteLine($"Dnů od mého narození: {(now - myBirthday).Days}");

            // 3. Vytvoř list stringů a vlož do něj 5 různých hodnot.

            List<string> fiveValues = new List<string>() { "ahoj", "hola", "hello", "ni-hao", "servus" };

            // 4. Smaž z tohoto listu libovolnou hodnotu.

            fiveValues.Remove("ahoj");

            // 5. Zjisti, jestli tento list obsahuje nějakou hodnotu pomocí list metody Contains

            bool containsHola = DoesListContainValue("hola", fiveValues);

            Console.WriteLine(containsHola);

            // 6. Vypiš do konzole, kolik je v tom listu prvků a připoj k tomu všechny ty hodnoty (např: "2: modra, zelena").

            Console.WriteLine($"{fiveValues.Count}: {String.Join(", ", fiveValues)}");

            // 7. Vytvoř slovník, kde klíčem bude položka nákupu (string) a hodnotou cena té položky, a vlož nějaké hodnoty (např: <"chleba", 20>).

            Dictionary<string, int[]> shopping = new Dictionary<string, int[]>()
                {
                    {"chleba", new int[]{30,1}},
                    {"rohlik", new int[]{3,10}},
                    {"jablka", new int[]{8,2}}
                };

            // 8. Zjisti, jestli slovník obsahuje nějakou konkrétní potravinu a pokud ano, vypiš její cenu, pokud ne, vypiš, že není.

            if (shopping.ContainsKey("rohlík"))
            {
                Console.WriteLine($"Cena za rohlík je: {shopping["rohlik"][0]}.");
            }
            else
            {
                Console.WriteLine("žádné rohlíky tady nejsou");
            }

            // 9. Řekněme, že už jsi do slovníku přidala např. chleba a zjistila, že máš v nákupní tašce ještě jeden -> uprav hodnotu k tomu klíči tak, aby obsahovala hromadnou cenu za všechny stejné položky.

            
            AddItemToShoppingList(shopping, "chleba");
            AddItemToShoppingList(shopping, "banán");

            Console.WriteLine("Částky za jednotlivé položky z nákupu");
            foreach ((string item, int[] priceAndPieces) in shopping)
            {
                Console.WriteLine($"{item}: {priceAndPieces[0]*priceAndPieces[1]} (počet kusů: {priceAndPieces[1]})");
            }
        }
    }
}