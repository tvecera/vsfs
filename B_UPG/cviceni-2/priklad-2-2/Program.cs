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
 * Tři čísla vzestupn
 * 
 * Uživatel zadá tři čísla z klávesnice. Setřiďte tato číslo ve vnitřní paměti. 
 * Vypište tato čísla setříděná vzestupně dle jejich hodnot. [3 body]
 */
namespace priklad_2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int x, y, z, tmp;
            Console.Write("Zadejte prvni cislo: ");
            x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Zadejte druhe cislo: ");
            y = Convert.ToInt32(Console.ReadLine());
            Console.Write("Zadejte treti cislo: ");
            z = Convert.ToInt32(Console.ReadLine());

            if (x > y)
            {
                tmp = y;
                y = x;
                x = tmp;
            }

            if (y > z)
            {
                tmp = y;
                y = z;
                z = tmp;
            }

            if (x > y)
            {
                tmp = y;
                y = x;
                x = tmp;
            }

            Console.WriteLine("{0} {1} {2}", x, y, z);
        }
    }
}
