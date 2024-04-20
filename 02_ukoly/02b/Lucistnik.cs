namespace _02b;

partial class Program
{
    class Lucistnik
    {
        public int pocetSipu;

        public Lucistnik(int PocetSipu = 10)
        {
            pocetSipu = PocetSipu;
        }
        public void Vystrel()
        {
            if (pocetSipu > 0)
            {
            Console.WriteLine("Vždy se strefím přesně doporostřed!");
            }
            else
            {
                Console.WriteLine("Nemám šipy!");
            }
            pocetSipu --;
        }
    }
}
