namespace _02b
// 3. Vytvořte třídu Lucistnik, ktera bude mit vlastnost PocetSipu a metodu Vystrel. PocetSipu muze byt nastaven treba na 10.
// Pokud bude mit dost sipu, napise metoda Vystrel na konzoli text: Vzdy se strefim primo do prostred!
// Metoda Vystrel uvnitr s kazdym vystrelem snizi pocet sipu.
// Pokud bude pocet 0, metoda Vystrel vypise "Nemam sipy".
// Napiste program, ktery vytvori lucistnika a vystreli vsechny sipy.



{
    partial class Program
    {
        static void Main(string[] args)
        {
            Lucistnik vilem = new Lucistnik(-3);
            Console.WriteLine(vilem.pocetSipu);
            while (vilem.pocetSipu >= 0)
            {
                vilem.Vystrel();
            }
        }
    }
}