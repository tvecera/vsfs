// Tento zdrojovy kod jsem vypracoval zcela samostatne bez cizi pomoci
// Neokopiroval jsem ani neopsal jsem cizi zdrojove kody
// Nikdo me pri vypracovani neradil
// Pokud nektery radek porusuje toto pravidlo, je oznacen komentarem
// NENI MOJE TVORBA
// Poruseni techto pravidel se povazuje za podvod, ktery lze potrestat VYLOUCENIM ZE STUDIA
// Tomas Vecera 11720

using System;
using System.IO;

namespace priklad_8_3
{
    /// <summary>Součet čísel na řádku
    /// Napište funkci, která ze zadaného textového souboru obsahujícího celá čísla vytvoří nový textový soubor, který
    /// bude na každém řádku obsahovat součet čísel z odpovídajícího řádku původního souboru. Nápověda: na součet
    /// použijte datový typ long. [3 body]
    /// </summary>
    class Program
    {
        /// <summary>
        /// Funkce provede soucet cisel na kazdem radku textoveho souboru. Funkce secte vsechny cisla oddelena mezerou a
        /// vysledek pro kazdy radek vlozi do vystupneho souboru.
        /// </summary>
        /// <param name="soubor">Vstupni soubor</param>
        /// <param name="souborSoucet">Vystupni soubor se souctem radku</param>
        static void SoucetCisel(string soubor, string souborSoucet)
        {
            // Bohuzel jsme se jeste neucili odchytavat vyjimky programu a tak nemohu zpracovat chybu s neexistujicim,
            // zamcenym souborem atd.
            StreamReader sr = new StreamReader(soubor);
            StreamWriter sw = new StreamWriter(souborSoucet);
            string line;

            // Nacteme radek TXT souboru az po jeho konec
            while ((line = sr.ReadLine()) != null)
            {
                // Rozdelime nacteny radek na textove retezce s cisly
                string[] cisla = line.Split(' ');
                // Musime pouzit long typ, v opacnem pripade by se nam soucet cisel nemusel vejit a doslo by k preteceni
                long soucet = 0;
                // Provedeme konverzi a secteni cisel
                for (int i = 0; i < cisla.Length; i++)
                    soucet += int.Parse(cisla[i]);

                // Zapiseme do souboru radek se souctem, na konci souboru nechceme prazdny radek a tak kontrolujeme
                // jestli uz se nenachazime na poslednim radku, v takovem pripade vkladame zaznam bez odradkovani
                if (sr.EndOfStream)
                    sw.Write(soucet);
                else
                    sw.WriteLine(soucet);
            }

            // Uzavreme oba soubory
            sr.Close();
            sw.Close();
        }

        static void Main(string[] args)
        {
            // Pozor, jsou pouzite relativni cesty, v ruznych IDE muzou byt cesty jinak
            // Pro otestovani pouzivam vysledky z prikladu 8.2
            Console.WriteLine("Provadim soucty cisel v radku u souboru cisla-1000.txt");
            SoucetCisel("../../../../cisla-1000.txt", "../../../../cisla-soucty-1000.txt");

            // Soubor s radkem mensim nez 10 cisel
            Console.WriteLine("Provadim soucty cisel v radku u souboru cisla-1007.txt");
            SoucetCisel("../../../../cisla-1007.txt", "../../../../cisla-soucty-1007.txt");
        }
    }
}