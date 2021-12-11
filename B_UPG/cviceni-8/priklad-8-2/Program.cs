// Tento zdrojovy kod jsem vypracoval zcela samostatne bez cizi pomoci
// Neokopiroval jsem ani neopsal jsem cizi zdrojove kody
// Nikdo me pri vypracovani neradil
// Pokud nektery radek porusuje toto pravidlo, je oznacen komentarem
// NENI MOJE TVORBA
// Poruseni techto pravidel se povazuje za podvod, ktery lze potrestat VYLOUCENIM ZE STUDIA
// Tomas Vecera 11720

using System;
using System.IO;

namespace priklad_8_2
{
    /// <summary>Převod binárního souboru na textový 
    /// Napište funkci, která ze zadaného binárního souboru obsahujícího kladné celá čísla vytvoří textový soubor, který
    /// bude na každém řádku obsahovat 10 čísel. Nápověda: počet čísel v souboru zjistíte z jeho délky. [3 body]
    /// </summary>
    class Program
    {
        /// <summary>
        /// Funkce prevede binarni soubor ze vstupu na textovy soubor s 10 cisly na radek a oddelenych mezerou. Je
        /// zohlednena situace kdy na konci souboru a konci radku nechceme mit prazdny radek nebo prazdnou mezeru.
        /// </summary>
        /// <param name="binarniSouvor">Soubor ktery chceme prevest na textovy</param>
        /// <param name="textovySoubor">Nazev, cesta souboru do ktereho chceme binarni soubor prevest</param>
        static void BinarniNaTextovy(string binarniSouvor, string textovySoubor)
        {
            // Bohuzel jsme se jeste neucili odchytavat vyjimky programu a tak nemohu zpracovat chybu s neexistujicim,
            // zamcenym souborem atd.
            FileStream bfs = new FileStream(binarniSouvor, FileMode.Open);
            BinaryReader br = new BinaryReader(bfs);
            // Otevreme soubor pro vystup, soubor se vzdy prepise
            StreamWriter sw = new StreamWriter(textovySoubor);

            long i = 0;
            // Spoceteme pocet cisel v souboru, muzeme vyuzit faktu, ze v sobouru jsou ulozeny int32 hodnoty, tzn. kazde
            // cislo je ulozeno ve 4 bajtech
            long cisel = bfs.Length / 4;

            // Opakujeme tak dlouho az dorazime na konec souboru - projdeme vsechny cisla
            while (i < cisel)
            {
                int value = br.ReadInt32();
                i++;
                sw.Write(value);

                // Jestli jsme nacetli a zapsali do TXT souboru 10 cisel, odradkujeme a ujistime se, ze se vse zapsalo
                // do souboru (operace Flush)
                if (i % 10 == 0 && i < cisel)
                {
                    sw.WriteLine();
                    sw.Flush();
                }
                // Jesli se nenachazime na konci souboru, nebo na konci radku, vlozime za cislo do TXT souboru mezeru
                else if (i < cisel)
                    sw.Write(" ");
            }

            // Uzavreme soubor
            br.Close();
            sw.Close();
        }

        static void Main(string[] args)
        {
            // Pozor, jsou pouzite relativni cesty, v ruznych IDE muzou byt cesty jinak
            // Pro otestovani pouzivam  vysledky z prikladu 8.1
            Console.WriteLine("Prevadim soubor cisla-1000.dat");
            BinarniNaTextovy("../../../../cisla-1000.dat", "../../../../cisla-1000.txt");

            // Situace kdy zbyvajici pocet cisel je mensi nez 10 (soubor by se nemel odradkovat a na konci cisla by
            // nemela zustat mezera)
            Console.WriteLine("Prevadim soubor cisla-1007.dat");
            BinarniNaTextovy("../../../../cisla-1007.dat", "../../../../cisla-1007.txt");
        }
    }
}