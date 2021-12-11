// Tento zdrojovy kod jsem vypracoval zcela samostatne bez cizi pomoci
// Neokopiroval jsem ani neopsal jsem cizi zdrojove kody
// Nikdo me pri vypracovani neradil
// Pokud nektery radek porusuje toto pravidlo, je oznacen komentarem
// NENI MOJE TVORBA
// Poruseni techto pravidel se povazuje za podvod, ktery lze potrestat VYLOUCENIM ZE STUDIA
// Tomas Vecera 11720
using System;

/**
 * Zadani: 
 * Příklad 1.1: Specifický aritmetický výraz
 * 
 * Ve funkci Main deklarujte tři celočíselné proměnné (pojmenujte je libovolně) 
 * a tyto proměnné inicializujte hodnotami (ideálně různými). Napište program, 
 * který spočte následující aritmetický výraz: Hodnoty posledních dvou 
 * proměnných vynásobte a od získaného výsledku odečtěte hodnotu první proměnné. 
 * Aritmetický výraz a jeho výsledek vypište vhodným způsobem na obrazovku.
 * [1 body]
 */
namespace priklad_1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 12;
            int y = 5;
            int z = 9;

            int vysledek = y * z;
            vysledek  = vysledek - x;

            Console.Write("Vysledek vyrazu {1} * {2} - {0} ", x, y, z);
            Console.WriteLine("je {0}", vysledek);
        }
    }
}
