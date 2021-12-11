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
 * Příklad 1.7: Lichá vs sudá čísla
 * 
 * Ve funkci Main deklarujte tři celočíselné proměnné (pojmenujte je libovolně) 
 * a tyto proměnné inicializujte hodnotami. Napište program, který určí, zda 
 * součet lichých hodnot z těchto tří čísel je vyšší nebo nižší než součet 
 * sudých hodnot z těchto tří čísel, případně zda si jsou součty rovny. 
 * Cíl příkladu a jeho výsledek vypište vhodným způsobem na obrazovku. [4 body]
 */
namespace priklad_1_7
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 9;
            int y = 2;
            int z = 6;
            int sude = 0;
            int liche = 0;
            string vysledek = "vyšší";

            // Zamerne nepouzito zjednoduseni v podobe
            // liche = promennaA + promennaB + promennaC - sude
            if (x % 2 == 0) sude = sude + x;
            else liche = liche + x;

            if (y % 2 == 0) sude = sude + y;
            else liche = liche + y;

            if (z % 2 == 0) sude = sude + z;
            else liche = liche + y;

            if (liche < sude) vysledek = "nižší";

            Console.Write("Zadaná čísla {0}, {1} a {2} mají součet ", x, y, z);
            Console.Write("lichých hodnot {0} {1} ", liche, vysledek);
            Console.WriteLine("než součet sudých hodnot {0}. ", sude);
        }
    }
}
