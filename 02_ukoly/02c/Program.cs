namespace _02c
// Napište program, který umožní hádat číslo. Zeptá se, jaké číslo si myslím. Podle toho, jaké číslo se zadá, napíše, jestli je číslo větší nebo menší a umožní hádat tak dlouho, dokud se uživatel netrefí:
//        Např.
//        Hádej číslo: 10
//        Číslo je menší, hádej znovu: 5
//        Číslo je větší, hádej znovu: 7
//        To je správně!
{
    class Program
    {
        static void Main(string[] args)
        {
            static int GetAndValidateNumber()
            {
                bool isNumber = false;
                int Number = 0;
                while (!isNumber)
                {
                    isNumber = int.TryParse(Console.ReadLine(), out Number);
                    if (!isNumber)
                    {
                        Console.WriteLine("Toto není číslo!");
                    }
                    else if (Number < 0 || Number > 100)
                    {
                        Console.WriteLine("Mimo rozsah");
                    }
                }
                return Number;
            }

            Random random = new Random();
            int randomNumber = random.Next(0, 101);

            int guessedNumber = -1;
            Console.WriteLine("Hádej číslo mezi 0 a 100");


            while (randomNumber != guessedNumber)
            {
                guessedNumber = GetAndValidateNumber();
                if (guessedNumber == randomNumber)
                {
                    Console.WriteLine("To je správně!");
                }
                else if (guessedNumber > randomNumber)
                {
                    Console.WriteLine("Číslo je menší, hádej znovu.");
                }
                else
                {
                    Console.WriteLine("Číslo je větší, hádej znovu.");
                }
            }
        }
    }
}
