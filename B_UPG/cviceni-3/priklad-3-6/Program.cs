// Tento zdrojovy kod jsem vypracoval zcela samostatne bez cizi pomoci
// Neokopiroval jsem ani neopsal jsem cizi zdrojove kody
// Nikdo me pri vypracovani neradil
// Pokud nektery radek porusuje toto pravidlo, je oznacen komentarem
// NENI MOJE TVORBA
// Poruseni techto pravidel se povazuje za podvod, ktery lze potrestat VYLOUCENIM ZE STUDIA
// Tomas Vecera 11720

using System;

namespace priklad_3_6
{
    /// <summary>
    /// Definice vyctoveho typu Tah. Ve hre kamen - nuzky - papir, ma hrac jenom tri typy tahu, na rozdil napr. od hry
    /// Rock Paper Scissors Lizard Spock (ze serialu The Big Bang Theory). U enum typu nechavam implicitne nastavene
    /// hodnoty jednotlivych polozek - Kamen: 0, Nuzky: 1, Papir: 2. V pripade potreby je mozne pouzit jakekoliv jine
    /// int cisla. Bohuzel na rozdil od jinych jazyku neumi C# vyctove typy i s jinou, nez ciselnou hodnotou. 
    /// </summary>
    public enum Tah
    {
        Kamen,
        Nuzky,
        Papir
    }

    /// <summary>Zadani: Kámen, nůžky papír
    /// Napište program, který si s uživatelem zahraje hru kámen, nůžky, papír. Hraje se na dvě vítězná kola. Použijte
    /// výčtový typ. V každém kole si uživatel zvolí jeden z výše uvedených předmětů předmětů, počítač svůj předmět
    /// vylosuje náhodně. Kámen poráží nůžky, nůžky poráží papír, papír poráží kámen. Pokud si uživatel i počítač
    /// zvolili stejný předmět, dané kolo se opakuje do té doby, dokud nebudou zvoleny různé předměty. [5 bodů]
    /// </summary>
    class Program
    {
        /// <summary>
        /// Funkce vyhodnoti vysledek daneho tahu porovnani tahu hrace a pocitace. Funkce vraci tyto vysledky:
        /// <list type="table">
        /// <item>0. remiza</item>
        /// <item>1. vyhral hrac</item>
        /// <item>2. vyhral pocitac</item>
        /// </list> 
        /// </summary>
        /// <param name="hrac">Tah hrace</param>
        /// <param name="pocitac">Tak pocitace</param>
        /// <returns>0 pro remizu, 2 pro vyhru pocitace jinak 1</returns>
        static int KdoVyhral(Tah hrac, Tah pocitac)
        {
            // Remiza
            if (hrac == pocitac)
                return 0;

            // Tah vyhral pocitac
            if (hrac == Tah.Kamen && pocitac == Tah.Papir)
                return 2;

            // Tah vyhral pocitac
            if (hrac == Tah.Nuzky && pocitac == Tah.Kamen)
                return 2;

            // Tah vyhral pocitac
            if (hrac == Tah.Papir && pocitac == Tah.Nuzky)
                return 2;

            // Tah vyhral hrac, neni nutne znovu kontrolovat, vsechny ostatni varianty jsme jiz zkontrolovali vyse
            // Zbyvaji nam tedy jenom varianty, kdy vyhral tah hrac
            return 1;
        }

        static void Main(string[] args)
        {
            int vyhryHrac = 0;
            int vyhryPocitac = 0;
            Random random = new Random();

            Tah hrac, pocitac;
            Console.WriteLine("Vitejte ve hre kamen – nuzky – papir");
            Console.WriteLine("Hrajeme na dve vitezna kola");

            // Opakujeme tak dlouho, dokud alespon jeden z hracu nema 2 vytezne kola
            while (vyhryHrac < 2 && vyhryPocitac < 2)
            {
                Console.Write("Zadejte svuj tah: ");
                string x = Console.ReadLine();

                // Snazime se zkontrolovat vstup od hrace, jesli jeho tah odpovida jedne z polozek vyctoveho typu Tah
                if (Enum.TryParse(x, true, out hrac) && Enum.IsDefined(typeof(Tah), hrac))
                {
                    // Vygenerujeme nahodny tah pocitace
                    pocitac = (Tah) random.Next(0, 3);

                    Console.WriteLine("Hrac zahral {0}, pocitac zahral {1}", hrac, pocitac);
                    // Zavolame vyhodnoceni tahu hrace a pocitace a vypiseme vysledek a v pripade vyhry jedne ze stran
                    // zvusime pocet vyher u hrace nebo pocitace
                    switch (KdoVyhral(hrac, pocitac))
                    {
                        case 0:
                            Console.WriteLine("Toto kolo je nerozhodne");
                            break;
                        case 1:
                            Console.WriteLine("Toto kolo vyhral hrac");
                            vyhryHrac++;
                            break;
                        case 2:
                            Console.WriteLine("Toto kolo vyhral pocitac");
                            vyhryPocitac++;
                            break;
                    }

                    Console.WriteLine("Celkove skore: hrac {0} – pocitac {1}", vyhryHrac, vyhryPocitac);
                }
                else
                    Console.WriteLine("Tento tah je neplatny");
            }

            // Vyhodnotime, kdo v teto hre vyhral
            if (vyhryHrac == 2)
                Console.WriteLine("Celou hru vyhral hrac");
            else
                Console.WriteLine("Celou hru vyhral pocitac");
        }
    }
}