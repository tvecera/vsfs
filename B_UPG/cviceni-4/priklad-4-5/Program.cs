// Tento zdrojovy kod jsem vypracoval zcela samostatne bez cizi pomoci
// Neokopiroval jsem ani neopsal jsem cizi zdrojove kody
// Nikdo me pri vypracovani neradil
// Pokud nektery radek porusuje toto pravidlo, je oznacen komentarem
// NENI MOJE TVORBA
// Poruseni techto pravidel se povazuje za podvod, ktery lze potrestat VYLOUCENIM ZE STUDIA
// Tomas Vecera 11720

using System;

namespace priklad_4_5
{
    /// <summary>Zadani: Maximum z pole
    /// Napište funkci, která v zadaném poli nezáporných čísel najde a pomocí parametrů funkce vrátí: 
    /// <list type="table">
    /// <item>a) hodnotu největšího prvku [1 bod]</item>
    /// <item>b) hodnotu druhého největšího prvku [1 bod]</item>
    /// <item>c) třetího největšího prvku [2 body]</item>
    /// </list>
    /// </summary>
    class Program
    {
        /// <summary>
        /// Funkce vrati posledni 3 nejvetsi prvky v poli. Z toho duvodu vstupni pole musi mit minimalne 3 prvky. 
        /// </summary>
        /// <param name="pole">Vstupni pole</param>
        /// <param name="max">Nejvetsi prvek pole. Vysledek je predavan referenci na vstupni promennou.</param>
        /// <param name="max2">Druhy nejvetsi prvek pole. Vysledek je predavan referenci na vstupni promennou.</param>
        /// <param name="max3">Treti nejvetsi prvek pole. Vysledek je predavan referenci na vstupni promennou.</param>
        /// <returns>TRUE v pripade, ze vstupni pole ma min. velikost 3., v opacnem pripade vraci funkce FALSE </returns>
        static bool MaxPole(int[] pole, ref int max, ref int max2, ref int max3)
        {
            if (pole.Length < 3)
            {
                Console.WriteLine("Pole musi mit alespon 3 prvky!!!");
                return false;
            }

            int temp;
            for (int j = 0; j <= pole.Length - 2; j++)
                for (int i = 0; i <= pole.Length - 2; i++)
                    if (pole[i] > pole[i + 1])
                    {
                        temp = pole[i + 1];
                        pole[i + 1] = pole[i];
                        pole[i] = temp;
                    }

            max = pole[pole.Length - 1];
            max2 = pole[pole.Length - 2];
            max3 = pole[pole.Length - 3];

            return true;
        }

        /// <summary>
        /// Pomocna funkce, ktera na standardni konzolovy vystyp vypise obsah vstupniho pole. 
        /// </summary>
        /// <param name="array">Vstupni pole ktere chceme vypsat do konzole (standardniho vystupu)</param>
        static void VypisPole(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                Console.Write("{0} ", array[i]);

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int[] pole = {2, 5, 7, 1, 4, 6, 9, 8, 2};
            int max = 0;
            int max2 = 0;
            int max3 = 0;

            Console.Write("Vstupni pole: ");
            VypisPole(pole);

            // Vysledek vypiseme pouze za predpokladu, ze funkce MaxPole vrati TRUE - tzn. byly splneny vstupni podminky
            if (MaxPole(pole, ref max, ref max2, ref max3))
            {
                Console.WriteLine("Hodnota nejvetsiho prvku: {0}", max);
                Console.WriteLine("Hodnota druheho nejvetsiho prvku: {0}", max2);
                Console.WriteLine("Hodnota tretiho nejvetsiho prvku: {0}", max3);
            }
        }
    }
}