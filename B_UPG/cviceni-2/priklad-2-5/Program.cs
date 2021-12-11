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
 * Nejmenší společný násobek
 * 
 * Uživatel zadá dvě čísla z klávesnice. Vypište jejich nejmenší společný 
 * násobek. Nejmenší společný násobek čísel x a y je nejmenší číslo n takové, 
 * že x dělí n beze zbytku a zároveň y dělí n beze zbytku. Nápověda: využijte 
 * Euklidův algoritmus, který nalezne největšího společného dělitele. 
 * [3 body] 
 */
namespace priklad_2_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Spocteme nejmensi spolecny nasobek cisel");
            Console.Write("Zadejte prvni cislo: ");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Zadejte druhe cislo: ");
            int y = Convert.ToInt32(Console.ReadLine());
            int xa = x;
            int ya = y;

            while (y != 0)
            {
                int zbytek = x % y;
                x = y;
                y = zbytek;
            }

            int vysledek = (xa / x) * ya;

            Console.WriteLine("Nejvetsi spolecny delitel je {0}", x);
            Console.WriteLine("Nejmensi spolecny nasobek je {0}", vysledek);
        }
    }
}
