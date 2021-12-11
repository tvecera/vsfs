// Tento zdrojovy kod jsem vypracoval zcela samostatne bez cizi pomoci
// Neokopiroval jsem ani neopsal jsem cizi zdrojove kody
// Nikdo me pri vypracovani neradil
// Pokud nektery radek porusuje toto pravidlo, je oznacen komentarem
// NENI MOJE TVORBA
// Poruseni techto pravidel se povazuje za podvod, ktery lze potrestat VYLOUCENIM ZE STUDIA
// Tomas Vecera 11720

using System;

namespace priklad_5_3
{
    /// <summary> Zadani: Sestupné třídění
    /// Napište třídící funkce pro sestupné třídění. Body navíc lze získat za použití pomocných funkcí z příkladu 5.2
    /// pro porovnávání a přiřazování hodnot prvků. Pomocné funkce nepoužívejte pro práci s řídící proměnnou cyklu.
    /// Výjimkou je Count sort, u kterého pomocné funkce se používají pro řídící
    /// proměnnou cyklu v situacích, ve kterých je řídící proměnná cyklu brána jako
    /// prvek pole.
    /// <list type="table">
    ///<item>a) Selection sort [3+1 body]</item>
    ///<item>Insertion sort [3+1  body]</item>
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

        /// <summary>
        /// Setridi vstupni pole pomoci Insertion Sortu. Fuknce setridene pole vypise, a krome vypisu obsahu pole
        /// vypise pocet prirazeni a porovnani tohoto alg.
        /// </summary>
        /// <param name="pole">Vstupni nesetridene pole</param>
        static void InsertionSort(int[] pole)
        {
            int i, j, temp = 0;
            for (i = 1; i < pole.Length; i++)
            {
                Prirazeni(ref temp, pole[i]);
                for (j = i; (j > 0) && JeMensi(pole[j - 1], temp); j--)
                    Prirazeni(ref pole[j], pole[j - 1]);

                Prirazeni(ref pole[j], temp);
            }

            Console.Write("InsertionSort: ");
            VypisPole(pole);
            Console.Write(" - Prirazeni: {0}, Porovnani: {1}", _prirazeni, _porovnani);
            Console.WriteLine();
            _porovnani = 0;
            _prirazeni = 0;
        }

        /// <summary>
        /// Setridi vstupni pole pomoci Selection Sortu. Fuknce setridene pole vypise, a krome vypisu obsahu pole
        /// vypise pocet prirazeni a porovnani tohoto alg.
        /// </summary>
        /// <param name="pole">Vstupni nesetridene pole</param>
        static void SelectionSort(int[] pole)
        {
            int i, j, max, temp = 0;
            for (i = 0; i < pole.Length; i++)
            {
                max = i;
                for (j = i; j < pole.Length; j++)
                    if (JeVetsi(pole[j], pole[max]))
                        max = j;

                Prirazeni(ref temp, pole[max]);
                Prirazeni(ref pole[max], pole[i]);
                Prirazeni(ref pole[i], temp);
            }

            Console.Write("SelectionSort: ");
            VypisPole(pole);
            Console.Write(" - Prirazeni: {0}, Porovnani: {1}", _prirazeni, _porovnani);
            Console.WriteLine();
            _porovnani = 0;
            _prirazeni = 0;
        }

        /// <summary>
        /// Pomocna funkce ktera na standardni konzolovy vystyp vypise obsah vstupniho pole. 
        /// </summary>
        /// <param name="array">Vstupni pole ktere chceme vypsat do konzole (standardniho vystupu)</param>
        static void VypisPole(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                Console.Write("{0} ", array[i]);
        }

        static void Main(string[] args)
        {
            int[] pole = {5, 7, 1, 5, 6, 8, 9, 0, 1, 2};
            Console.Write("Vstupni pole: ");
            VypisPole(pole);
            Console.WriteLine();

            SelectionSort(pole);
            int[] pole2 = {5, 7, 1, 5, 6, 8, 9, 0, 1, 2};
            InsertionSort(pole2);
        }
    }
}