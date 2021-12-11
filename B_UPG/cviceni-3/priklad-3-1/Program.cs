// Tento zdrojovy kod jsem vypracoval zcela samostatne bez cizi pomoci
// Neokopiroval jsem ani neopsal jsem cizi zdrojove kody
// Nikdo me pri vypracovani neradil
// Pokud nektery radek porusuje toto pravidlo, je oznacen komentarem
// NENI MOJE TVORBA
// Poruseni techto pravidel se povazuje za podvod, ktery lze potrestat VYLOUCENIM ZE STUDIA
// Tomas Vecera 11720

using System;

namespace priklad_3_1
{
    /// <summary>
    /// Vyctovy typ pro definovani sazeb DPH
    /// </summary>
    public enum Dph
    {
        BEZ_DPH = 0,
        ZAKLADNI = 21,
        PRVNI_SNIZENA = 15,
        DRUHA_SNIZENA = 10
    }

    /// <summary>Zadani: DPH
    /// <list type="table">
    /// <item>a) Napiste funkci, ktera pro zadanou cenu zbozi a ciselne zadanou sazbu DPH spocte cenu zbozi s DPH.
    /// [1 bod]</item>
    /// <item>b) Napiste funkci, ktera pro sazbu DPH pouzije vyctovy typ. Existuji tri sazby DPH: zakladni 21%,
    /// prvni snizena 15% a druha snizena 10% [1 bod]</item>
    /// </list>
    /// </summary>
    class Program
    {
        /// <summary>
        /// Spocte DPH pomoci vlozene sazby v podobe vyctoveho typu DPH.
        /// </summary>
        /// <param name="castka">Nezaporna castka pro kterou chceme spocitat DPH</param>
        /// <param name="sazba">Sazba DPH predana pomoci vyctoveho typu</param>
        /// <returns>Spoctena castka DPH, pro nevalidni vstup vraci 0.0</returns>
        static double SpoctiDph2(double castka, Dph sazba)
        {
            // Abychom nekopirovali stejnu kod, provolame funkci vytvorenou v bode a)
            return SpoctiDph1(castka, (int) sazba);
        }

        /// <summary>
        /// Spocte DPH pomoci vlozene sazby. Funkce kontroluje jestli vlozena saba je jednou ze zavedenych sazeb DPH.
        /// Funkce rovnez kontroluje vstupni castku, je mozne vkladat pouze nezaporne realne cisla. 
        /// </summary>
        /// <param name="castka">Nezaporna castka pro kterou chceme spocitat DPH</param>
        /// <param name="sazba">Sazba v %</param>
        /// <returns>Spoctena castka DPH, pro nevalidni vstup vraci 0.0</returns>
        static double SpoctiDph1(double castka, int sazba)
        {
            // Vstupni castka musi byt kladne realne cislo vetsi nez 0
            if (castka <= 0.0)
                Console.WriteLine("Neplatna castka!!!");

            // Zkontrolujeme jestli vlozena sazba odpovida nektere v CR platne sazbe
            if (Enum.IsDefined(typeof(Dph), sazba))
            {
                // Sazbu musime nejdrive prevest z procent a na typ double
                double sazbaDph = 1.0 + (sazba / 100.0);
                return castka * sazbaDph;
            }

            Console.WriteLine("Neplatna sazba DPH (21%, 15%, 5%)!!!");

            // Vracime 0.0 v pripade, ze funkce byla zavolana s neplatnout hodnotou sazby nebo DPH
            return 0.0;
        }

        static void Main(string[] args)
        {
            // Cast prikladu a). V pripade ze je vysledek 0.0, jedna se o chybu vstupu a vysledek nevypisujeme
            int sazba = 21;
            double result = SpoctiDph1(56.20, sazba);
            if (result > 0.0)
                Console.WriteLine("Castka s {0}% DPH je {1}", sazba, result);

            // Cast prikladu b). V pripade ze je vysledek 0.0, jedna se o chybu vstupu a vysledek nevypisujeme
            Dph sazbaDph = Dph.PRVNI_SNIZENA;
            result = SpoctiDph2(115, sazbaDph);
            if (result > 0.0)
                Console.WriteLine("Castka s {0}% DPH je {1}", (int) sazbaDph, result);
        }
    }
}