namespace _02b
{
    partial class Program
    {
        class Lucistnik
        {
            public int pocetSipu;

            public Lucistnik(int PocetSipu = 10)
            {
                if (PocetSipu > 0)
                {
                    pocetSipu = PocetSipu;
                }
                else
                {
                    pocetSipu = 1;
                    Console.WriteLine("Není možné vytvořit lučištníka se záporným počtem šípů, dostane jeden.");
                }

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
                pocetSipu--;
            }
        }
    }
}
