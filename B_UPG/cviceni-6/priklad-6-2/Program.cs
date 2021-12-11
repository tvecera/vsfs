// Tento zdrojovy kod jsem vypracoval zcela samostatne bez cizi pomoci
// Neokopiroval jsem ani neopsal jsem cizi zdrojove kody
// Nikdo me pri vypracovani neradil
// Pokud nektery radek porusuje toto pravidlo, je oznacen komentarem
// NENI MOJE TVORBA
// Poruseni techto pravidel se povazuje za podvod, ktery lze potrestat VYLOUCENIM ZE STUDIA
// Tomas Vecera 11720

using System;

namespace priklad_6_2
{
    /// <summary>
    /// Cesarova sifra je jednou z nejstarsich metod pro prevod prenasene zpravy do zasifrovane podoby, ktera je
    /// necitelna pro neinformovaneho utocnika. Parametrem sifry je cele cislo nazvane posun. Kazde pismeno zpravy je
    /// zameneno za pismeno, ktere se v abecede nachazi za timto pismenem o pocet znaku urceny hodnotou parametru posun.
    /// Puvodni zpravu ziskame aplikaci tohoto postupu na zasifrovanou zpravu s modifikovanym parametrem posun. Hodnota
    /// parametru posun bude mit oproti puvodni hodnote tohoto parametru opacne znamenko.
    /// <list type="table">
    /// <item>a) Implementujte funkci pro zasifrovani textoveho retezce pomoci teto sifry. Pro jednoduchost nezkoumejte,
    /// co jsou pismena a posouvejte cely retezec. [1 bod].</item>
    /// <item>b) Slovne (pomoci komentare ve zdrojovem kodu) popiste postup, kterym byste v roli utocnika bez znalosti
    /// parametru posun ze zasifrovane zpravy ziskali puvodni zpravu. [2 body]</item>
    /// </list>
    /// </summary>
    class Program
    {
        /// <summary>
        /// Funkce pro zasifrovani vlozeneho znaku pomoci cesarovy sifry a posunu. Oproti zadani, funkce sifruje pouze
        /// znaky. Tak aby implementace vice odpovidala puvodni sifre. Zohlednuje taky velikost pismen, protoze v ASCII
        /// tabulce zacina mala i velka abeceda na jinem miste. 
        /// </summary>
        /// <param name="ch">Vstupni znak, ktery chceme zasifrovat</param>
        /// <param name="posun">Sifrovaci klic</param>
        /// <returns>Znak, posunuty o pocet znaku doprava</returns>
        static char ZasifrujZnak(char ch, int posun)
        {
            if (!char.IsLetter(ch))
                return ch;

            char start;
            // Jestli se jedna o znak velke abecedy, jako zacatek abecedy zvolime pozici znaku A, v opacnem pripade se
            // jedna o znak z male abecedy ktera zacina na pozici znaku a.
            if (char.IsUpper(ch))
                start = 'A';
            else
                start = 'a';

            // Nejdrive potrebujeme prevest znaky na cicla o 0 - 25
            // To provedeme jednoduse, odecteme ASCII kod pocatku pro abecedu pro male a velke pismena v ASCII (ch -d)
            int result = ch - start;
            
            // Pak pridame posun znaku smerem doprava
            result += posun;
            
            // Vysledek po pridani posunu musime prevest znovu na pismeno anglicke abecedy. Jelikoz mame 26 znaku
            // anglicke abecedy, vyslednou hodnotu ziskame jako zbytek po deleni 26.
            result %= 26;
            
            // Pak uz nam staci jenom znovu prevest znak do hodnoty ASCII tabulky
            result += start;

            return (char) result;
        }

        /// <summary>
        /// Pomocna funkce ktera projde vsechny znaky v zadanem vstupnim retezci a provola funkci pro posun znaku. Pro
        /// prazdny vstupni retezec vtaci prazdny vystup.
        /// </summary>
        /// <param name="text">Vstupni retezec, ktery chceme zasifrovat</param>
        /// <param name="heslo">Heslo, v podstate se jedna o pocet znaku o ktere chceme znaky posunout. Z povahy
        /// cesarove sifry ma heslo ma smysl poze v rozsahu 1 - 26. Protoze vetsi heslo se prevede do posunu v rozsahu
        /// 1 - 25. Proto napr. zadani hesla 100 dostaneme stejny vysledek jako pro heslo 22.</param>
        /// <returns>Textovy retezec posunuty o zvoleny pocet znaku</returns>
        static string CezarovaSifra(string text, int heslo)
        {
            string result = "";
            
            // Projde vsechny znaky vlozeneho textoveho retezce a posune je o zvoleny pocet znaku
            for (int i = 0; i < text.Length; i++)
                result += ZasifrujZnak(text[i], heslo);

            return result;
        }

        /// <summary>
        /// Provede zasifrovani vlozeneho textoveho retezce.
        /// </summary>
        /// <param name="text">Textovy retezec ktery chceme zasifrovat</param>
        /// <param name="heslo">Heslo, pocet znaku o ktere se ma abeceda posunout</param>
        /// <returns>Zasifrovany text</returns>
        static string CezarovaSifraZasifruj(string text, int heslo)
        {
            return CezarovaSifra(text, heslo);
        }

        /// <summary>
        /// Provede desifrovani vlozeneho textoveho retezce.
        /// </summary>
        /// <param name="text">Textovy retezec ktery chceme desifrovat</param>
        /// <param name="heslo">Heslo, pocet znaku o ktere se ma abeceda posunout</param>
        /// <returns>Desifrovany text</returns>
        static string CezarovaSifraDesifruj(string text, int heslo)
        {
            // Potrebujeme ziskat posun abecedy zpet
            // Nejdrive provedeme hesla vetsi nez 26 na hodnotu (0 : 26) - heslo % 26
            return CezarovaSifra(text, 26 - (heslo % 26));
        }

        /// <summary>
        /// Oproti zadani jsem zavedl samostatnou fuknci pro sifrovani a desifrovani textu.
        /// 
        /// Slovne (pomoci komentare ve zdrojovem kodu) popiste postup, kterym byste v roli utocnika bez znalosti
        /// parametru posun ze zasifrovane zpravy ziskali puvodni zpravu:
        ///
        /// Desifrovani Cesarovy sifry je velmi jednoduche protoze:
        /// 1. Sifrovaci a desifrovaci algoritmus je znam.
        /// 2. K dispozici je pouze 25 klicu.
        /// 3. Kazde pismeno se posune vzdy o stejny pocet znaku, to je obecny problem u jednoduchych substitucnych
        ///    sifer. Proto jednim z hlavnich vylepseni v pripade sifrovaciho stroje Enigma, byl posun vzdy o jiny
        ///    pocet znaku a tento posun se provadel nekolikrat a spolecne s propojovaci deskou zvedl pocet kombinaci
        ///    k teoretickym 158,962,555,217,826,360,000 kombinaci.
        ///
        /// Existuje nekolik moznosti jak najit klic k sifre:
        /// 1. S ohledem na konecny a maly pocet klicu je nejjednodussi variantou utok tzv. hrubou silou. Proste
        ///    vyzkouset vsechny kombinace.
        /// 2. U slozitejsich substitucnich sifer se vyuziva tzv. frekvencni analyza - v kazdem jazyku jsou v beznem
        ///    textu zastoupena jednotliva pismena urcitym procentem. Takze kdyz vime, ze v beznem textu se nejcasteji
        ///    nachazi pismeno O a to se v textu nachazi v 8.6664% pripadu, hledame v zasifrovanem textu takove pismeno,
        ///    ktere ma obdobne zastoupeni jako v beznem textu. Z toho muzeme usuzovat ze pismno napr. O je v
        ///    zasifrovanem textu pismenem C atd.
        ///
        /// Casto se neutoci primo na podstatu sifry jako takove, ale na zpusob implementace, pouziti. Nekdy je
        /// jednoduche zjistit co bylo v casti zasifrovane zpravy napsano a to vyuzit pro ziskani sifrovaciho klice.
        /// Napr. v pripade desifrovani Enigmy se vyuzivalo faktu, ze Nemecka armada posilala kazdy den zpravy o pocasi,
        /// ktere mely vzdy stejnou podobu, stacilo tedy zjistit pocasi v danem miste, odkud byla zprava odvisilana a
        /// meli jste hned puvodni a zasifrovany text, coz usnadnovalo nalezeni klice. Dalsim prikladem bylo zasilani
        /// prikazu, ktere vzdy konci stejnou vetou atd. 
        /// </summary>
        static void Main(string[] args)
        {
            string text = "Toto je tajny text: 1726";
            
            string zasifrovane = CezarovaSifraZasifruj(text, 26);
            Console.WriteLine("Zasifrovany text: {0}", zasifrovane);
            
            string desifrovane = CezarovaSifraDesifruj(zasifrovane, 26);
            Console.WriteLine("Desifrovany text: {0}", desifrovane);
        }
    }
}