// Tento zdrojovy kod jsem vypracoval zcela samostatne bez cizi pomoci
// Neokopiroval jsem ani neopsal jsem cizi zdrojove kody
// Nikdo me pri vypracovani neradil
// Pokud nektery radek porusuje toto pravidlo, je oznacen komentarem
// NENI MOJE TVORBA
// Poruseni techto pravidel se povazuje za podvod, ktery lze potrestat VYLOUCENIM ZE STUDIA
// Tomas Vecera 11720

using System;

namespace priklad_5_2
{
    /// <summary>Zadani: Příprava na třídění
    /// Vytvořte dvě globální proměnné (prirazeni a porovnani), které budou sloužit pro měření počtu volání funkcí
    /// vytvořených v tomto příkladu. Napište následující funkce, které budou nahrazovat operátory:
    /// <list type="table">
    /// <item>funkce přiřazení (globální proměnná prirazeni ) [1 bod]</item>
    /// <item>funkce je menší (globální proměnná porovnani ) [1/2 bodu]</item>
    /// <item>funkce je větší (globální proměnná porovnani ) [1/2 bodu]</item>
    /// </list> 
    /// </summary>
    class Program
    {
        // Globalni promerna pro pocitani poctu prirazeni
        static int _prirazeni = 0;

        // Globalni promenna pro pocitani poctu porovnani
        static int _porovnani = 0;

        /// <summary>
        /// Pomocna funkce pro vyhodnoceni, jestli je x mensi nez y. Funkce krome vyhodnoceni vyrazu, zvetsi promennou
        /// _porovnani o 1. To nam umozni dale v kodu porovnat alg. slozitost jednotlivych sortovaci alg. 
        /// </summary>
        /// <param name="x">Vstupni hodnota X</param>
        /// <param name="y">Vstupni hodnota Y</param>
        /// <returns>TRUE - jestli plati ze x je mensi nez y, v opacnem pripade vraci funkce FALSE</returns>
        static bool JeMensi(int x, int y)
        {
            _porovnani++;
            return x < y;
        }

        /// <summary>
        /// Pomocna funkce pro vyhodnoceni, jestli je x vetsi nez y. Funkce krome vyhodnoceni vyrazu, zvetsi promennou
        /// _porovnani o 1. To nam umozni dale v kodu porovnat alg. slozitost jednotlivych sortovacich alg. 
        /// </summary>
        /// <param name="x">Vstupni hodnota X</param>
        /// <param name="y">Vstupni hodnota Y</param>
        /// <returns>TRUE - jestli plati ze x je vetsi nez y, v opacnem pripade vraci funkce FALSE</returns>
        static bool JeVetsi(int x, int y)
        {
            _porovnani++;
            return x > y;
        }

        /// <summary>
        /// Pomocna funkce pro prirazeni hodnoty ze vstupni promenne y do vstupni promenne x. Funkce krome prikazu
        /// prirazeni, zvetsi promennou _prirazeni o 1. To nam umozni dale v kodu porovnat alg. slozitost jednotlivych
        /// sortovacich alg. 
        /// </summary>
        /// <param name="x">Vstupni hodnota X - predavana nikoliv hodnotou ale referenci</param>
        /// <param name="y">Vstupni hodnota Y</param>
        static void Prirazeni(ref int x, int y)
        {
            _prirazeni++;
            x = y;
        }

        static void Main(string[] args)
        {
            int x = 5, y = 4, z = 3;
            Console.WriteLine("{0} < {1} = {2}", y, z, JeMensi(y, z));
            Console.WriteLine("{0} < {1} = {2}", x, z, JeMensi(x, z));
            Console.WriteLine("{0} > {1} = {2}", x, y, JeVetsi(x, y));

            Console.Write("Prirazeni x({0}) = y({1}), x = ", x, y);
            Prirazeni(ref x, y);
            Console.WriteLine(x);
            Console.Write("Prirazeni y({0}) = z({1}), y = ", y, z);
            Prirazeni(ref y, z);
            Console.WriteLine(y);
            Console.WriteLine("Prirazeni: {0}, Porovnani: {1}", _prirazeni, _porovnani);
        }
    }
}