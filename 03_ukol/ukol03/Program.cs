using System;
using System.Security.Cryptography.X509Certificates;

namespace ukol03
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
          // Tento ukol se opravuje sam. Kazdy priklad obsahuje kontrolni vypisy, ktere overi, ze jsi dosla k spravnemu vysledku.
		// Vsechny priklady take obsahuji nejakou predpripravenou promennou, kam ulozis vysledek svoji prace.
		
		int padding = 45;
		string text = @"""Hurry up, boy!"" shouted Uncle Vernon from the kitchen. ""What are you
doing, checking for letter bombs?"" He chuckled at his own joke.

Harry went back to the kitchen, still staring at his letter. He handed
Uncle Vernon the bill and the postcard, sat down, and slowly began to
open the yellow envelope.

Uncle Vernon ripped open the bill, snorted in disgust, and flipped over
the postcard.

""Marge's ill,"" he informed Aunt Petunia. ""Ate a funny whelk. --.""

""Dad!"" said Dudley suddenly. ""Dad, Harry's got something!""

Harry was on the point of unfolding his letter, which was written on the
same heavy parchment as the envelope, when it was jerked sharply out of
his hand by Uncle Vernon.

""That's mine!"" said Harry, trying to snatch it back.

""Who'd be writing to you?"" sneered Uncle Vernon, shaking the letter open
with one hand and glancing at it. His face went from red to green faster
than a set of traffic lights. And it didn't stop there. Within seconds
it was the grayish white of old porridge.";
		
		// Nez zacnes volat nejake stringove funkce na nejake stringove promenne, nezapomen overit, ze obsahuje smysluplnou hodnotu. Vysledek uloz do promenne 'textMaSmysl'.
		bool textMaSmysl = !string.IsNullOrEmpty(text);
		Console.WriteLine("Text dava smysl - ".PadRight(padding) + (textMaSmysl == true));		
		
		// Do promenne 'delkaTextu' uloz celkovou delku uryvku z knizky.
		
		int delkaTextu = text.Replace("\n","").Length;
		Console.WriteLine("Delka text je spravna - ".PadRight(padding) + (delkaTextu == 1001));		
		
		// Do promenne 'oddelovac' vloz text, ktery se sklada pouze z pomlcek a jeho delka je presne 20. Pouzij k tomu konstruktor typu string.
		
		string oddelovac = new string('-', 20);
		Console.WriteLine("Oddelovac ma 20 pomlcek - ".PadRight(padding) + (oddelovac == "--------------------"));
		
		// Pozmen nasledujici porovnani textu tak, aby se do konzole vypisovalo True, aniz bys menila hodnoty promennych
		
		string jmeno1 = "Katka";
		string jmeno2 = "katka";
		bool jeStejne = string.Equals(jmeno1.ToLower(),jmeno2);
		Console.WriteLine("Obe promenne obsahuji stejne jmeno - ".PadRight(padding) + jeStejne);
		
		// Zjisti, jestli je v textu zminka o obtloustle "tete" Harryho. Jmenuje se Marge. Vysledek uloz do promenne 'piseSeOMarge';
		
		bool piseSeOMarge = text.Contains("Marge");
		Console.WriteLine("V textu se zminuje Harryho 'teticka' - ".PadRight(padding) + (piseSeOMarge == true));
		
		// Zjisti, jestli je text spravne ukonceny interpunkci. Vysledek uloz do promenne 'jeSpravneUkoncen'.
		
		bool jeSpravneUkoncen = char.IsPunctuation(text[text.Length-1]);
		Console.WriteLine("Text je spravne ukoncen interpunkci - ".PadRight(padding) + (jeSpravneUkoncen == true));
		
		// Pomoci abecedniho porovnavani zjisti, ktery z nasledujicich textu je podle abecedy prvni a jeho hodnotu prirad do promenne 'prvni'.
		
		string blabol1 = "abbc";
		string blabol2 = "acbc";
		string blabol3 = "abbb";
        
        string[] blabols = new string[]{blabol1, blabol2, blabol3};
        
        
        Array.Sort(blabols);
        
		string prvni = blabols[0];
				
		Console.WriteLine("Prvni v abecede je blabol3 - ".PadRight(padding) + (prvni == blabol3));		
				
		// Najdi prvni rozkazovaci vetu v textu a uloz ji do promenne 'veta' bez vykricniku a uvozovek.
        int lastChar = text.IndexOf("!");
        bool firstChar = false;
        int firstCharPos = lastChar - 1;
        while(!firstChar)
        {
            if (text[firstCharPos] == '!' || text[firstCharPos] == '?' || text[firstCharPos] =='.' || firstCharPos == 0 || text[firstCharPos] == '"')
            {
                firstChar = true;
                firstCharPos ++;
            }
            else
            {
                firstCharPos --;
            }
        }

        
		string veta = text.Substring(firstCharPos,lastChar-firstCharPos).Trim();
		Console.WriteLine("Prvni rozkazovaci veta je 'Hurry up, boy' - ".PadRight(padding) + (veta == "Hurry up, boy"));
		
		// Zjisti, kolikrat se v textu vyskytuje slovo "and" bez ohledu na velikosti prvniho pismenka a vysledek uloz do promenne 'pocetAnd'.
		// Abych vam to zjednodusil, muzete se spolehnout, ze tato anglicka spojka bude v textu vzdy obklopena mezerou na kazde strane.
		// Tim se snadno vylouci jakekoliv vyskyty "and" v ramci jinych slov.
		int andCount = 0;
        string[] words = text.ToLower().Split(' ');
        foreach (string word in words)
        {
            if (word == "and")
            {andCount++;}
        }
		int pocetAnd = andCount;
		Console.WriteLine("Text obsahuje slovo 'and' celkem 5x' - ".PadRight(padding) + (pocetAnd == 5));
        }
    }
}
