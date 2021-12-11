// Tento zdrojovy kod jsem vypracoval zcela samostatne bez cizi pomoci
// Neokopiroval jsem ani neopsal jsem cizi zdrojove kody
// Nikdo me pri vypracovani neradil
// Pokud nektery radek porusuje toto pravidlo, je oznacen komentarem
// NENI MOJE TVORBA
// Poruseni techto pravidel se povazuje za podvod, ktery lze potrestat VYLOUCENIM ZE STUDIA
// Tomas Vecera 11720

using System;

namespace priklad_4_4
{
    /// <summary>Zadani: Obrácení pole
    /// Napište funkci, která v zadaném poli obrátí pořadí prvků. První prvek bude posledním, druhý prvek předposledním,
    /// atd. Je zakázáno použít pomocné pole. [3 body] 
    /// </summary>
    class Program
    {
        /// <summary>
        /// Funkce obrati vstupni pole.
        /// </summary>
        /// <param name="array">Vstupni pole</param>
        /// <returns>Pole s obracenym poradim prvku</returns>
        static int[] ObratPole(int[] array)
        {
            int[] result = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                // Vlozi polozky pole od zadu, je mozne resit i sestupnim cyklem, kdy ridici promenna pole zacina na
                // poslednim prvku a pokracujeme postupne k zacatku pole
                int idx = array.Length - i - 1;
                result[i] = array[idx];
            }

            return result;
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
            int[] pole = {5, 7, 2, 1, 0, 6};

            Console.Write("Vstupni pole: ");
            VypisPole(pole);
            Console.Write("Obracene pole: ");
            VypisPole(ObratPole(pole));
        }
    }
}