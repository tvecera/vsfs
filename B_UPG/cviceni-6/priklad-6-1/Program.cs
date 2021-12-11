// Tento zdrojovy kod jsem vypracoval zcela samostatne bez cizi pomoci
// Neokopiroval jsem ani neopsal jsem cizi zdrojove kody
// Nikdo me pri vypracovani neradil
// Pokud nektery radek porusuje toto pravidlo, je oznacen komentarem
// NENI MOJE TVORBA
// Poruseni techto pravidel se povazuje za podvod, ktery lze potrestat VYLOUCENIM ZE STUDIA
// Tomas Vecera 11720

using System;

namespace priklad_6_1
{
    /// <summary> Zadani: Prace s textovymi retezci
    /// Slovo je retezec slozeny vyhradne z pismen, ktery je maximalni delky, nejde tedy prodlouzit o dalsi pismeno. Dve
    /// slova jsou od sebe oddelena jednim nebo vice znaky, ktere nejsou pismeny. Pokud se pred slovem ci za slovem
    /// nachazi znak, tak tento znak neni pismenem.Napiste nasledujici funkce pro praci s textovymi retezci bez pouziti
    /// funkci Split a Distinct. Puvodni retezec nesmite modifikovat, ani od nej vytvaret kopie:
    ///
    /// <list type="table">
    /// <item>a) Funkce vracejici pocet ruznych pismen anglicke abecedy, ktere zadany retezec obsahuje. Velikost pismen
    /// se nerozlisuje. [2 body]</item>
    /// <item>b) Funkce vracejici pocet slov v zadanem retezci. [2 body]</item>
    /// <item>c) Funkce vracejici slovo prvni vyskyt slova na zadane pozice v zadanem retezci. Pokud se na zadane pozici
    /// nachazi pismeno, je vraceno slovo, jehoz soucasti toto pismeno je.V tomto pripade bude nalezene slovo casto
    /// zacinat pred zadanou pozici.Pokud se na zadane pozici nenachazi pismeno, je vraceno prvni slovo nachazejici
    /// se napravo od zadane pozice v zadanem retezci.Pokud neni nalezeno zadne slovo, je vracen prazdny retezec.
    /// [2 body]</item>
    /// <item>d) Funkce vracejici nejdelsi slovo v zadanem retezci. Pokud jsou dve slova stejne dlouha, je vraceno slovo,
    /// ktere se v retezci vyskytuje jako prvni.Pokud neni nalezeno zadne slovo, je vracen prazdny retezec. [1 bod]
    /// </item>
    /// <item>e) Funkce vracejici lexikograficky (abecedne) nejvetsi slovo v zadanem retezci. Pokud neni nalezeno zadne
    /// slovo, je vracen prazdny retezec. [1 bod]</item>
    /// </list>
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Funkce vracejici pocet ruznych pismen anglicke abecedy, ktere zadany retezec obsahuje. Velikost pismen se
        /// nerozlisuje. [2 body]
        /// </summary>
        /// <param name="str">Vstupni retezec napr.: Alena ma 2 ruce.</param>
        /// <returns>Pocet ruznych pismenm napr.: 8 </returns>
        static int RuznychPismen(string str)
        {
            // Vytvorime si pole pro ulozeni poctu znaku
            int[] pismena = new int[255];
            int i, result = 0;

            // Projdeme vsechny znaky retezce a pro pismena anglicke abecedy spocteme 
            for (i = 0; i < str.Length; i++)
                if (char.IsLetter(str[i]))
                    // Ignorujeme velikost pismena
                    pismena[char.ToLower(str[i])]++;

            // Spocteme pismena u kterych je pocet vyskytu > 0
            for (i = 0; i < 255; i++)
                if (pismena[i] > 0)
                    result++;

            return result;
        }

        /// <summary>
        /// Funkce vracejici pocet slov v zadanem retezci. [2 body]
        /// </summary>
        /// <param name="str">Vstupni retezec napr.: Alena ma 2 ruce.</param>
        /// <returns>Pocet slov v zadanem retezci napr.: 3</returns>
        static int PocetSlov(string str)
        {
            int count = 0;
            string slovo = "";

            // Ukolem cyklu je projit vsechna pismena v zadanem retezci, rozdelit retezec na slova a pri objeveni slova
            // zvysit navratovou hodnotu count o 1
            for (int i = 0; i < str.Length; i++)
                if (char.IsLetter(str[i]))
                {
                    slovo += str[i];
                    // Resi situaci, kdy jsme na konci retezce a posledni znak neni carka, tecka mezera ...
                    // Jinak by nam ve vysledku chybelo zpracovani posledniho slova v retezci
                    if (i == str.Length - 1)
                        count++;
                }
                else
                {
                    if (slovo.Length > 0)
                        count++;
                    slovo = "";
                }

            return count;
        }

        /// <summary>
        /// Funkce vracejici slovo prvni vyskyt slova na zadane pozice v zadanem retezci. [2 body]
        /// </summary>
        /// <param name="str">Vstupni retezec napr.: Alena ma 2 ruce.</param>
        /// <param name="pozice">2</param>
        /// <returns>Slovo na zadane pozici napr. pro pozici 2 = Alena. V pripade ze na zadane pozici se nenachazi zadne
        /// slovo, vraci prazdny retezec</returns>
        static string PrvniSlovo(string str, int pozice)
        {
            string result = "";

            // V pripade, je vlozena pozice mimo oblast textoveho retezce, vraci funkce prazdny retezec
            if (pozice >= str.Length || pozice < 0)
                return result;

            int start = pozice;

            // Hledam start slova zleva
            while (start > 0 && char.IsLetter(str[start]))
                start--;
            // Hledam start slova z prava
            while (start < str.Length && !char.IsLetter(str[start]))
                start++;
            // Slozeni slova
            while (start < str.Length && char.IsLetter(str[start]))
            {
                result += str[start];
                start++;
            }

            // Slovo na zadane pozici nenalezeno, vracime prazdny retezec
            if (result.Length == 0)
                result = "";

            return result;
        }

        /// <summary>
        /// Funkce vracejici nejdelsi slovo v zadanem retezci. [1 bod]
        /// </summary>
        /// <param name="str">Vstupni retezec napr.: Alena ma 2 ruce.</param>
        /// <returns>Nejdelsi slovo napr. Alena. V pripade ze zadany retezec neobsahuje slov, vraci prazdny retezec
        /// </returns>
        static string NejdelsiSlovo(string str)
        {
            string slovo = "";
            string tmp = "";

            // Ukolem cyklu je projit vsechna pismena v zadanem retezci a rozdelit retezec na slova.
            // Pri nalezeni slova provadi porovnani jeho delky s ulozenym slovem v promenne slovo.
            // Pokud je nove objevene slovo delsi nez to ulozene, vlozi se do promenne slovo.
            for (int i = 0; i < str.Length; i++)
                if (char.IsLetter(str[i]))
                {
                    tmp += str[i];
                    // Resi situaci, kdy jsme na konci retezce a posledni znak neni carka, tecka mezera ...
                    // Jinak by nam ve vysledku chybelo zpracovani posledniho slova v retezci
                    if (i == str.Length - 1 && tmp.Length > slovo.Length)
                        slovo = tmp;
                }
                else
                {
                    if (tmp.Length > 0 && tmp.Length > slovo.Length)
                        slovo = tmp;
                    tmp = "";
                }

            return slovo;
        }

        /// <summary>
        /// Funkce vracejici lexikograficky (abecedne) nejvetsi slovo v zadanem retezci.
        /// </summary>
        /// <param name="str">Vstupni retezec napr.: Alena ma 2 ruce.</param>
        /// <returns>Lexikograficky (abecedne) nejvetsi slovo. Pokud vstupni retezec neobsahuje zadne slovo, vraci
        /// prazdny retezec</returns>
        static string NejvetsiSlovo(string str)
        {
            string slovo = "";
            string tmp = "";

            // Ukolem cyklu je projit vsechna pismena v zadanem retezci a rozdelit retezec na slova.
            // Pri nalezeni slova provadi porovnani jeho velikosti pomoci delky lexikografickeho porovnani za pomoci
            // funkce string.Compare.
            // Pokud je nove objevene slovo delsi nez to ulozene, vlozi se do promenne slovo.
            for (int i = 0; i < str.Length; i++)
                if (char.IsLetter(str[i]))
                {
                    tmp += str[i];
                    // Resi situaci, kdy jsme na konci retezce a posledni znak neni carka, tecka mezera ...
                    // Jinak by nam ve vysledku chybelo zpracovani posledniho slova v retezci
                    if (i == str.Length - 1 && string.Compare(slovo, tmp) == -1)
                        slovo = tmp;
                }
                else
                {
                    if (tmp.Length > 0 && string.Compare(slovo, tmp) == -1)
                        slovo = tmp;
                    tmp = "";
                }

            return slovo;
        }

        static void Main(string[] args)
        {
            string str = "Alena ma 2 ruce.";
            //string strLong = "Mama ma 2 ruce a v ruce hul";

            int ruznych = RuznychPismen(str);
            Console.WriteLine("Pocet ruznych pismen anglicke abecedy: {0}", ruznych);

            int pocet = PocetSlov(str);
            Console.WriteLine("Pocet slov: {0}", pocet);

            string prvniSlovo = PrvniSlovo(str, 0);
            Console.WriteLine("Slovo na pozici {0}: {1}", 2, prvniSlovo);

            string nejdelsiSlovo = NejdelsiSlovo(str);
            Console.WriteLine("Nejdelsi slovo: {0}", nejdelsiSlovo);

            string nejvetsiSlovo = NejvetsiSlovo(str);
            Console.WriteLine("Nejvetsi slovo: {0}", nejvetsiSlovo);
        }
    }
}