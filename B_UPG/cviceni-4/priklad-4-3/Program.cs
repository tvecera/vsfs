// Tento zdrojovy kod jsem vypracoval zcela samostatne bez cizi pomoci
// Neokopiroval jsem ani neopsal jsem cizi zdrojove kody
// Nikdo me pri vypracovani neradil
// Pokud nektery radek porusuje toto pravidlo, je oznacen komentarem
// NENI MOJE TVORBA
// Poruseni techto pravidel se povazuje za podvod, ktery lze potrestat VYLOUCENIM ZE STUDIA
// Tomas Vecera 11720

using System;

namespace priklad_4_3
{
    /// <summary> Zadani: Zaokrouhlení pole
    /// Napište funkci, která pro zadané pole reálných čísel vrátí pole celých čísel. Hodnoty prvků v novém poli
    /// vzniknou zaokrouhlením hodnot prvků z původního pole. [2 body] 
    /// </summary>
    class Program
    {
        /// <summary>
        /// Provede zaokrouhleni jednotlivych prvku pole. Pro zaokrouhleni vyuziva funkci Math.Round s poctem deset.
        /// mist 0. 
        /// </summary>
        /// <param name="array">Vstupni pole, jehoz prvky se maji zaokrouhlit</param>
        /// <returns>Zaokrouhlene pole</returns>
        static double[] ZaokrouhliPole(double[] array)
        {
            // Definujeme vysledne pole, fuknci by bylo mozne implementovat i tak, ze bychom vysledek operace ukladali
            // do vstupniho pole a tim bychom prisli o puvodni hodnoty pole
            double[] result = new double[array.Length];

            for (int i = 0; i < array.Length; i++)
                result[i] = Math.Round(array[i], 0);

            return result;
        }

        /// <summary>
        /// Pomocna funkce, ktera na standardni konzolovy vystyp vypise obsah vstupniho pole. 
        /// </summary>
        /// <param name="array">Vstupni pole ktere chceme vypsat do konzole (standardniho vystupu)</param>
        /// <param name="hideDigits">Urcije jestli ma pri vystupu vypisovat desetinnou cast cisla - pro zaokrouhlene
        /// pole nechceme zobrazovat</param>
        static void VypisPole(double[] array, bool hideDigits)
        {
            // Abychom mohli pouzit stejnou funkci pro vypis vstupniho a zaokrouhleneho pole, je jednim ze vstupu teto
            // fuknce vstupni parametr hideDigits. Pro zaokrouhlene pole nechceme vypisovat desetinnou cast (je vzdy 0).
            // Duvodem je, ze primitivni typy int, long atd. nemaji v C# spolecneho predka napr. Number. Pak by bylo
            // mozne zadefinovat jednu obecnou funkci jak pro pole int[], tak pro double[] 
            for (int i = 0; i < array.Length; i++)
                if (hideDigits)
                    Console.Write("{0:N0} ", array[i]);
                else
                    Console.Write("{0} ", array[i]);

            Console.WriteLine();
        }


        static void Main(string[] args)
        {
            double[] pole = {5.12, -3.5996, 156, 7.9};

            Console.Write("Vstupni pole: ");
            VypisPole(pole, false);
            Console.Write("Zaokrouhlene pole: ");
            VypisPole(ZaokrouhliPole(pole), true);
        }
    }
}