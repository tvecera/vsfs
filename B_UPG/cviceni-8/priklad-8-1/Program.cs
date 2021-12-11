// Tento zdrojovy kod jsem vypracoval zcela samostatne bez cizi pomoci
// Neokopiroval jsem ani neopsal jsem cizi zdrojove kody
// Nikdo me pri vypracovani neradil
// Pokud nektery radek porusuje toto pravidlo, je oznacen komentarem
// NENI MOJE TVORBA
// Poruseni techto pravidel se povazuje za podvod, ktery lze potrestat VYLOUCENIM ZE STUDIA
// Tomas Vecera 11720

using System;
using System.IO;

namespace priklad_8_1
{
    /// <summary>Náhodný binární soubor
    /// Napište funkci, která vytvoří binární soubor obsahující zadaný počet náhodných kladných celých čísel. [2 body].
    /// </summary>
    class Program
    {
        /// <summary>
        /// Funkce na zaklade postu vstupnich cisel vygeneruje binarni soubor s nahodnymi kladnymi cislami. Pocet cisel
        /// neni nutne ukladat. Jsme jej schopni velmi jednoduse ziskat z velikosti souboru, jelikoz ukladany datovy
        /// typ int ma 4 byte. Tzn. velikost souboru bude pocet ulozenych cisel * 4.
        /// </summary>
        /// <param name="soubor">Nazev souboru, kam chceme cisla ulozit</param>
        /// <param name="pocet">Pocet cisel, ktere chceme do souboru ulozit</param>
        /// <returns>Velikost souboru v bajtech</returns>
        static long NahodnySoubor(string soubor, int pocet)
        {
            // Otevre soubor se zvolenym nazvem pro zapis, jestli soubor jiz existuje, dojde k jeho prepsani
            FileStream fs = new FileStream(soubor, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            Random random = new Random();

            for (int i = 0; i < pocet; i++)
                // Pro otestovani muzeme zvolit mensi rozsah hodnot pro random, napr. 10
                bw.Write(random.Next(0, int.MaxValue));

            // Pred uzavrenim souboru si jeste ulozime jeho velikost
            long result = fs.Length;
            // Uzavreme soubor
            bw.Close();

            return result;
        }

        static void Main(string[] args)
        {
            // Pozor, jsou pouzite relativni cesty, v ruznych IDE muzou byt cesty jinak
            // Vygenerovane soubory pouzivam v prikladu 8.2
            long fileLenght = NahodnySoubor("../../../../cisla-1000.dat", 1000);
            Console.WriteLine("Velikost souboru {0}: {1} bytu", "cisla-1000.dat", fileLenght);

            // Vygenerovani souboru s pocetem cisel % 10 != 0
            fileLenght = NahodnySoubor("../../../../cisla-1007.dat", 1007);
            Console.WriteLine("Velikost souboru {0}: {1} bytu", "cisla-1007.dat", fileLenght);
        }
    }
}