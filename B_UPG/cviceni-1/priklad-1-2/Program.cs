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
 * Příklad 1.2: Zbytek po celočíselném dělení bez operátoru % 
 * 
 * Ve funkci Main deklarujte dvě celočíselné proměnné (pojmenujte je libovolně) 
 * a tyto proměnné inicializujte hodnotami (ideálně různými). Napište program, 
 * který spočte zbytek po celočíselném dělení první zadané proměnné druhou 
 * zadanou proměnnou. Program nesmí použít operátor zbytku po celočíselném 
 * dělení %. Cíl výpočtu a jeho výsledek vypište vhodným způsobem na obrazovku. 
 * [3 body]
 */
namespace priklad_1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 1;
            int y = 3;
            // Staci nam jenom deklarovat, inicializujeme pozdeji
            int vysledek;

            // Pouze vypiseme, bez pouziti vnoreneho bloku muzeme jeste
            // ukoncit beh programu bez hlasky
            if (y == 0) Console.WriteLine("Deleni 0 neni pripustne!!!");

            // Vysledek po deleni se uklada do promenne typu int, vlozi se
            // tedy vysledek pouze celociselna cast po deleni
            // Jestli je hodnota promenne B vetsi nez hodnota A, vysledek
            // vysledek deleni je 0 a zbytek po deleni se rovna promenne A
            int cd = x / y;
            vysledek = cd * y;
            vysledek = x - vysledek;

            Console.Write("Zbytek po celociselnem deleni cisla ");
            Console.WriteLine("{0} cislem {1} je {2}", x, y, vysledek);
        }
    }
}
