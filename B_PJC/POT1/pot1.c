/************************************************************
 * Vypracovani ulohy c. 1 - POT1                            *
 *                                                          *
 * Popis:                                                   *
 *      Jednoducha kalkulacka. Aplikace neumi zatim         *
 *      vyhodnotit prioritu operatoru a vyraz 1+8+2/8*4     *
 *      se vyhodnoti z leva do prava bez ohledu na          *
 *      prioritu (v dalsich verzich muze byt priklad        *
 *      rozsiren napr. o implementaci shunting yard         *
 *      algoritmu). Oproti zadani pridana 2 mocnina.        *
 *                                                          *
 * Pouziti:                                                 *
 *      Program umoznuje pouziti vstupniho argumentu        *
 *      pro nastaveni vstupnich jednotek pro                *
 *      goniometricke funkce. Defaultne se pouzivaji        *
 *      radiany.                                            *
 *                                                          *
 *      -d pro stupne                                       *
 *      -h help                                             *
 *      -v verze                                            *
 *                                                          *
 *      Pro ukonceni programu stisknete 'Q' nebo 'q'.       *
 *                                                          *
 *      CMAKE:                                              *
 *                                                          *
 *      cmake_minimum_required(VERSION 3.8)                 *
 *      project(pot1)                                       *
 *                                                          *
 *      set(CMAKE_C_STANDARD 99)                            *
 *                                                          *
 *      set(SOURCE_FILES pot1.c)                            *
 *      add_executable(pot1 ${SOURCE_FILES})                *
 *                                                          *
 * Autor: Tomas Vecera (UCO 11720)                          *
 * Verze: 1.0 (20171126)                                    *
 *                                                          *
 ************************************************************/

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>

#define bool char
#define true 1
#define false 0
#define VERSION 1.0
#define PI 3.14159265358979323846
//#define DEBUG

bool deg = false;

/* Makro pro zobrazeni debug hlasek. Slouzi pro zapinani vypinani debug hlasek */
#ifdef DEBUG
    #define LOG_DEBUG printf
#else
    #define LOG_DEBUG
#endif

enum functionType {
    SQRT, SIN, COS, TAN, POW
};

enum operatorType {
    ADDITION, SUBTRACTION, MULTIPLICATION, DIVISION
};

/**
 * Struktura pro definici matematickych funkci
 * @param type typ funkce z ciselniku funkci
 * @param token ukazatel na retezec reprezentujici funkci
 */
struct function {
    enum functionType type;
    char *token;
};

static const struct function FUNCTIONS[] = {
        {SQRT, "sqrt"},
        {POW,  "pow"},
        {SIN,  "sin"},
        {COS,  "cos"},
        {TAN,  "tan"}
};

/**
 * Struktura pro definici matematickych operatoru
 * @param oper typ operatoru
 * @param token char reprezentace matematickeho operatoru
 */
struct operator {
    enum operatorType type;
    char token;
};

static const struct operator OPERATORS[] = {
        {ADDITION,       '+'},
        {SUBTRACTION,    '-'},
        {MULTIPLICATION, '*'},
        {DIVISION,       '/'}
};

/**
 * Pomocna funkce na prevod stupnu do radianu.
 * @param degrees - ukazatel na hodnotu pro prevod
 */
double toRadians(const double *degrees) {
    return *degrees * PI / 180.0;
}

/**
 * Aplikuje vlozenou funkci. Vstupne parametry jsou predany pomoci ukazatelu. Metoda vklada
 * vypoctenou hodnotu pres ukazatel na result.
 *
 * @param fnc funkce ktera ma byt aplikovana na vlozenou hodnotu
 * @param result ukazatel na hodnotu vysledku kalkulacky
 * @param value ukazatel na vlozene cislo
 * @return true / false pro pripadne vyhodnoceni uspesneho provedeni vypoctu (aktualne se
 * primo nevyuziva)
 */
bool applyFunction(const struct function *fnc, double *result, const double *value) {
    bool rtn = true;

    LOG_DEBUG("DEBUG applyFunction: result: %f, value: %f\n", *result, *value);

    switch (fnc->type) {
        case POW:
            *result = pow(*value, 2);
            break;
        case SQRT:
            *result = sqrt(*value);
            break;
        case SIN:
            *result = sin(deg == false ? *value : toRadians(value));
            break;
        case COS:
            *result = cos(deg == false ? *value : toRadians(value));
            break;
        case TAN:
            *result = tan(deg == false ? *value : toRadians(value));
            break;
    }

    LOG_DEBUG("DEBUG applyFunction: result: %f\n", *result);

    return rtn;
}

/**
 * Provede vypocet na zaklade vlozeneho operatoru. Vstupne parametry jsou
 * predany pomoci ukazatelu. Metoda vklada vypoctenou hodnotu pres ukazatel
 * na result.
 *
 * @param oper operace ktera ma byt aplikovana na vlozenou hodnotu a result
 * @param result ukazatel na hodnotu vysledku kalkulacky
 * @paran value ukazatel na vlozene cislo
 * @return true / false pro pripadne vyhodnoceni uspesneho provedeni vypoctu
 * (aktualne se vraci false pouze pri pokusu o deleni 0)
 */
bool applyOperator(const struct operator *oper, double *result, const double *value) {
    bool rtn = true;

    LOG_DEBUG("DEBUG applyOperator: result: %f, value: %f\n", *result, *value);

    switch (oper->type) {
        case ADDITION:
            *result += *value;
            break;
        case SUBTRACTION:
            *result -= *value;
            break;
        case MULTIPLICATION:
            *result *= *value;
            break;
        case DIVISION:
            if (*value == 0.0) {
                printf("Deleni nulou!!!\n");
                rtn = false;
            } else {
                *result /= *value;
            }
            break;
    }

    LOG_DEBUG("DEBUG applyOperator: result: %f\n", *result);

    return rtn;
}

/**
 * Metoda se snazi identifikovat funkci z pole znaku s. V pripade, ze
 * vlozene pole znaku neobsahuje zadnou podporovanou funkci, vraci
 * metoda NULL.
 *
 * @param s pole znaku ze vstupu
 * @return funkci, z pole FUNCTIONS[], v opacnem pripade NULL
 */
const struct function *isFunction(const char *s) {
    for (int i = 0; i < 5; i++) {
        if (strncmp(s, FUNCTIONS[i].token, strlen(FUNCTIONS[i].token)) == 0) {
            return &FUNCTIONS[i];
        }
    }
    return NULL;
}

/**
 * Metoda se snazi identifikovat pouzity operator z pole znaku s. V pripade, ze
 * vlozene pole znaku neobsahuje zadny podporovany operator, vraci
 * metoda NULL.
 *
 * @param s pole znaku ze vstupu
 * @return operator, z pole OPERATORS[], v opacnem pripade NULL
 */
const struct operator *isOperator(const char *s) {
    for (int i = 0; i < 4; i++) {
        if (OPERATORS[i].token == s[0]) {
            return &OPERATORS[i];
        }
    }
    return NULL;
}

/**
 * Metoda nacte cislo ze vstupu. Funkce strtod a format "%s" je pouzit
 * zamerne.
 *
 * @param buff radek s cislem ze vstupu
 * @param value vlozena hodnota
 * @return true - v pripade, ze metoda dobehla v poradku, jinak false.
 * Zatim nevyuzito.
 */
bool getNumber(char *buff, double *value) {
    char *ptr = NULL;
    char line[100];

    printf("Vlozte cislo: ");
    fgets(line, sizeof(line), stdin);
    sscanf(line, "%16s", buff);
    *value = strtod(buff, &ptr);
    if (buff == ptr) {
        printf("Neplatny vstup.\n");
        return false;
    }

    return true;
}

/**
 * Prevede vlozene pole znaku na male pismena.
 *
 * @param s ukazatel na pole znaku
 */
void toLowerCase(char *s) {
    int idx = 0;
    while (s[idx] != '\0') {
        if (s[idx] >= 'A' && s[idx] <= 'Z') {
            s[idx] = (char) (s[idx] + 32);
        }
        idx++;
    }
}

/**
 * Hlavni metoda programu, poustena po spusteni programu. V ramci nacitani hodnot
 * jsem se snazil vyresit pripadne preteceni zasobniku omezenim vstupu na max 16
 * znaku.
 *
 * @param argc pocet argumentu
 * @param argv argumenty
 * @return defaultni result z metody. 0 = OK
 */
int main(int argc, char *argv[]) {
    if (argc == 2) {
        switch (argv[1][1]) {
            case 'd':
                deg = true;
                break;
            case 'v':
                printf("VERZE %.1f", VERSION);
                return 0;
            case 'h':
            default:
                printf("Pouziti pot1 -[d|r,h,v] \n");
                printf("   -d  stupnu pro vstup do goniometrickych funkci \n");
                printf("   -h  zobrazeni helpu \n");
                printf("   -v  cislo verze \n");
                return 0;
        }
    }

    printf("== Pro ukonceni prace s kalkulackou vlozte Q, q ==\n");

    char line[100], buff[16];
    double result = 0.0, value = 0.0;
    const struct function *fnc;
    const struct operator *opr;

    while (buff[0] != 'q' && buff[0] != 'Q') {
        printf("Vlozte cislo/operaci: ");
        fgets(line, sizeof(line), stdin);
        sscanf(line, "%16s", buff);

        // Odstraneni case sensitivity u nazvu funkci
        toLowerCase(buff);

        if ((fnc = isFunction(buff)) != NULL) {
            applyFunction(fnc, &result, &result);
        } else if ((opr = isOperator(buff)) != NULL) {
            getNumber(buff, &value);
            applyOperator(opr, &result, &value);
        } else if (buff[0] != 'q' && buff[0] != 'Q') {
            char *ptr;
            value = strtod(buff, &ptr);
            if (buff != ptr) {
                result = value;
            } else {
                printf("Neplatny vstup.\n");
            }
        }
        printf("Vysledek: %.8f\n", result);
    }

    return 0;
}