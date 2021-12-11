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
 * Příklad 2.9: Statistické informace
 * 
 * Uživatel zadává posloupnost kladných čísel. Pokud uživatel zadá nekladné 
 * číslo, je posloupnost ukončena (a toto nekladné číslo není její součástí). 
 * Vypište:
 * a) počet čísel v posloupnosti. Pokud posloupnost obsahuje nejvýše jedno 
 *    číslo, nevypisujte další části úkolu. [1/2 bodu]
 * b) součet hodnot čísel [1/2 bodu]
 * c) hodnotu největšího čísla [1 bod]
 * d) hodnotu nejmenšího čísla [1 bod]
 * e) hodnotu druhého největšího číslo [1 bod]
 */
namespace priklad_2_9
{
    class Program
    {
        static void Main(string[] args)
        {
            int soucet = 0;
            int delka = 0;
            Console.WriteLine("Spocteme statisticke informace o zadanych kladnych cislech.");
            Console.Write("Zadejte cislo: ");
            int x = Convert.ToInt32(Console.ReadLine());
            int nejmensi = x;
            int nejvetsi = 0;
            int druheNejvetsi = 0;

            while (x > 0)
            {
                delka = delka + 1;
                soucet = soucet + x;


                if (x > nejvetsi)
                {
                    druheNejvetsi = nejvetsi;
                    nejvetsi = x;
                }
                else
                {
                    if (x > druheNejvetsi)
                        druheNejvetsi = x;

                    if (x < nejmensi)
                    {
                        nejmensi = x;
                    }
                }

                Console.Write("Zadejte cislo: ");
                x = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Delka posloupnosti je {0}.", delka);
            if (delka > 1)
            {
                Console.WriteLine("Soucet prvku posloupnosti je {0}.", soucet);
                Console.WriteLine("Nejvetsi prvek posloupnosti je {0}, druhy nejvetsi je {1}.", nejvetsi, druheNejvetsi);
                Console.WriteLine("Nejmensi prvek posloupnosti je {0}.", nejmensi);
            }

        }
    }
}
