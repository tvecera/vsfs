// Tento zdrojovy kod jsem vypracoval zcela samostatne bez cizi pomoci
// Neokopiroval jsem ani neopsal jsem cizi zdrojove kody
// Nikdo me pri vypracovani neradil
// Pokud nektery radek porusuje toto pravidlo, je oznacen komentarem
// NENI MOJE TVORBA
// Poruseni techto pravidel se povazuje za podvod, ktery lze potrestat VYLOUCENIM ZE STUDIA
// Tomas Vecera 11720

using System;

namespace priklad_3_2
{
    /// <summary>
    /// Vyctovy typ pro BMI. Protoze C# neumoznuje u enum typu definovat jejich hodnotu i jinak nez hodnotou INT, neni
    /// mozne rozsahy uvest pri definici samotneho vyctoveho typu, coz je skoda.
    /// 
    /// BMI		      výčtový typ
    /// [0; 16,5)	  těžká podvýživa
    /// [16,5; 18,5)  podváha
    /// [18,5; 25) 	  optimální váha
    /// [25; 30) 	  nadváha
    /// [30; 35) 	  obezita prvního stupně
    /// [35; 40) 	  obezita druhého stupně
    /// [40; oo)	  obezita třetího stupně
    /// </summary>
    public enum Bmi
    {
        TEZKA_PODVYZIVA,
        PODVAHA,
        OPTIMALNI_VAHA,
        NADVAHA,
        OBEZITA_PRVNIHO_STUPNE,
        OBEZITA_DRUHEHO_STUPNE,
        OBEZITA_TRETIHO_STUPNE,
        UNKNOWN
    }

    /// <summary>Zadani: BMI
    /// BMI (Body Mass Index) se počítá: váha v kilogramech vydělená druhou mocninou výšky v metrech.
    /// <list type="table">
    /// <item>a) Napište funkci, která pro zadanou hodnotu výšky a váhy spočte BMI. [1 bod]</item>
    /// <item>a) Napište funkci, která místo číselné hodnoty bude vracet výčtový typ. [1 bod]</item>
    /// </list>
    /// </summary>
    class Program
    {
        /// <summary>
        /// Funkce pro zadanou hodnotu vahy a vysky spocte BMI. Funkce kontroluje vstup, tzn. pro vysku vetsi nez 3m a
        /// vahu vetsi nez 600 Kg vypise chybovou hlasku a vraci BNI 0.0
        /// </summary>
        /// <param name="vyska">Vyska v metrech. Musi byt vetsi nez 0 a mensi nez 3m </param>
        /// <param name="vaha">Vaha v kilogramech. Musi byt vetsi nez 0 a mensi nez 600kg</param>
        /// <returns>Vypocitane BMI, v pripade chyneho vstupu vraci funkce 0</returns>
        static double SpoctiBmi1(double vyska, double vaha)
        {
            // Zkontrolujeme jestli vyska neni mimo definovany rozsah hodnot
            if (vyska < 0.0 || vyska == 0.0 || vyska > 3.0)
                Console.WriteLine("Neplatna vyska!!!");
            // Zkontrolujeme jestli vaha neni mimo definovany rozsah hodnot
            else if (vaha < 0.0 || vaha == 0.0 || vaha > 600)
                Console.WriteLine("Neplatna vaha!!!");
            else
            {
                // Spocteme BMI a zaokrohlime jej na 2 desetinna mista
                return Math.Round(vaha / Math.Pow(vyska, 2), 2);
            }

            // Vracime 0.0 v pripade, ze doslo k zadani nevalidni vstupu
            return 0.0;
        }

        /// <summary>
        /// Funkce spocita BMI a vraci vyctovy typ Bmi.
        /// </summary>
        /// <param name="vyska">Vyska v metrech. Musi byt vetsi nez 0 a mensi nez 3m </param>
        /// <param name="vaha">Vaha v kilogramech. Musi byt vetsi nez 0 a mensi nez 600kg</param>
        /// <returns>BMI v podobe vyctoveho typu. Pro nevalidni vstup vraci Bmi.UNKNOWN</returns>
        static Bmi SpoctiBmi2(double vyska, double vaha)
        {
            // Abycho nekopirovali kod, vyuzijeme volani funkce vytvorene v casti prikladu a)
            double bmi = SpoctiBmi1(vyska, vaha);
            
            // Vyhodnotime v jakem rozsahu se vypocitane BMI nachazi a vratime korespondujici vyctovy typ
            // Spoctene BMI musi byt vetsi nez 0, v opacnem pripade se jedna o chybu vstup
            if (bmi > 0.0)
            {
                Console.Write("BMI {0}: ", bmi);

                if (bmi >= 40.0)
                    return Bmi.OBEZITA_TRETIHO_STUPNE;
                else if (bmi >= 35)
                    return Bmi.OBEZITA_DRUHEHO_STUPNE;
                else if (bmi >= 30)
                    return Bmi.OBEZITA_PRVNIHO_STUPNE;
                else if (bmi >= 25)
                    return Bmi.NADVAHA;
                else if (bmi >= 18.5)
                    return Bmi.OPTIMALNI_VAHA;
                else if (bmi >= 16.5)
                    return Bmi.PODVAHA;
                else
                    return Bmi.TEZKA_PODVYZIVA;
            }

            // Chyba vstupu, vracime specificky vyctovy typ identifikujici chybu vypoctu
            return Bmi.UNKNOWN;
        }

        /// <summary>
        /// Vypise textovou reprezentaci vyctoveho typu.
        /// </summary>
        /// <param name="bmi">BMI vyctovy typ</param>
        static void VypisVysledek(Bmi bmi)
        {
            switch (bmi)
            {
                case Bmi.TEZKA_PODVYZIVA:
                    Console.WriteLine("Těžká podvýživa");
                    break;
                case Bmi.PODVAHA:
                    Console.WriteLine("Podváha");
                    break;
                case Bmi.OPTIMALNI_VAHA:
                    Console.WriteLine("Optimální váha");
                    break;
                case Bmi.NADVAHA:
                    Console.WriteLine("Nadváha");
                    break;
                case Bmi.OBEZITA_PRVNIHO_STUPNE:
                    Console.WriteLine("Obezita prvního stupně");
                    break;
                case Bmi.OBEZITA_DRUHEHO_STUPNE:
                    Console.WriteLine("Obezita druhého stupně");
                    break;
                case Bmi.OBEZITA_TRETIHO_STUPNE:
                    Console.WriteLine("Obezita třetího stupně");
                    break;
            }
        }

        static void Main(string[] args)
        {
            // Cast prikladu a). Vysledek se vypise pouze pro BMI > 0.0, v opacnem pripade se jedna o chybu vstupu
            double result = SpoctiBmi1(1.70, 61.5);
            if (result > 0.0)
                Console.WriteLine("BMI {0}", result);

            // Cast prikladu b). Vysledek se vypise pouze pro BMI != UNKNOWN, v opacnem pripade se jedna o chybu vstupu
            Bmi resultBmi = SpoctiBmi2(1.67, 80);
            if (resultBmi != Bmi.UNKNOWN)
                VypisVysledek(resultBmi);
        }
    }
}