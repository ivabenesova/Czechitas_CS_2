namespace _02b;



// 3. Vytvořte třídu Lucistnik, ktera bude mit vlastnost PocetSipu a metodu Vystrel. PocetSipu muze byt nastaven treba na 10.
// Pokud bude mit dost sipu, napise metoda Vystrel na konzoli text: Vzdy se strefim primo do prostred!
// Metoda Vystrel uvnitr s kazdym vystrelem snizi pocet sipu.
// Pokud bude pocet 0, metoda Vystrel vypise "Nemam sipy".
// Napiste program, ktery vytvori lucistnika a vystreli vsechny sipy.
// 4. Napište program, který umožní hádat číslo. Zeptá se, jaké číslo si myslím. Podle toho, jaké číslo se zadá, napíše, jestli je číslo větší nebo menší a umožní hádat tak dlouho, dokud se uživatel netrefí:
//        Např.
//        Hádej číslo: 10
//        Číslo je menší, hádej znovu: 5
//        Číslo je větší, hádej znovu: 7
//        To je správně!

// Řešení odevzdejte pushnutím do svého repozitáře v GIT.

partial class Program
{
    static void Main(string[] args)
    {
        Lucistnik vilem = new Lucistnik(16);
        while(vilem.pocetSipu>=0)
        {
            vilem.Vystrel();
        }
    }
}
