# Šifrový Překladač

## Autor: Miloš Tesař

### Úvod

Toto je základní přehled mé aplikace. Pro další informace o použití a instalaci si prosím přečtěte dokumentaci v souboru [MANUAL.md](MANUAL.md).

### Popis Aplikace

Šifrový Překladač je inovativní konzolová aplikace v jazyce C#, která umožňuje šifrování a dešifrování textu pomocí různých kryptografických metod. Vznikla jako odpověď na rostoucí poptávku po nástroji, který uživatelům poskytne snadný a bezplatný překlad textu do různých šifer a zpět v jedné aplikaci. Především byla vytvořena pro táborovou skupinu Paprsek, ale je přístupná pro všechny uživatele a navržena tak, aby byla intuitivní a snadno použitelná.

#### Kontext Vzniku:

Šifrový Překladač vznikl primárně pro členy LT Paprsek s vizí poskytnout jednoduchý nástroj pro šifrování a dešifrování textu v jediné aplikaci, bez potřeby hledání nebo luštění šifer v různých zdrojích.

#### Účel Aplikace:

Šifrový Překladač slouží k poskytování uživatelům snadného a efektivního prostředku pro šifrování a dešifrování textu. Jeho hlavní cíle zahrnují:

1. **Rozmanitost Šifer:**
   - Nabízí širokou škálu šifer (celkem 10), včetně Morseovy abecedy, Caesarovy šifry a dalších, umožňující uživatelům volbu dle svých preferencí.

2. **Jednoduché Použití:**
   - Poskytuje intuitivní uživatelské rozhraní a jednoduchý ovládací panel pro pohodlné používání bez ohledu na úroveň znalostí uživatele.

3. **Bezplatná Dostupnost:**
   - Je plně zdarma a dostupná pro všechny uživatele, což umožňuje širokou škálu lidí vychutnat si zážitek z šifrování.

### 2. Development/Platforma

1. **Vývojové Prostředí:**
   - Šifrový Překladač byl vyvinut pomocí vývojového prostředí Microsoft Visual Studio, poskytující robustní sadu nástrojů pro vývoj aplikací v jazyce C#.

2. **Programovací Jazyk:**
   - Aplikace byla napsána v programovacím jazyce C#, který je silně propojený s ekosystémem Microsoftu a poskytuje vývojářům široké možnosti pro tvorbu moderních a uživatelsky příjemných aplikací.

3. **Platforma:**
   - Šifrový Překladač je určen pro běh na operačním systému Windows.

### Funkce produktu (Použité šifry)

#### Morseova šifra

Morseova šifra je způsob kódování textu pomocí kombinace krátkých a dlouhých signálů, známých jako tečky a čára.

**Ukázka:**
"PŘÍKLAD" zašifrujeme jako ".--. .-. .. -.- .-.. .- -.."

#### Caesarova šifra

Caesarova šifra je substituční šifra, která funguje na principu posunu písmen v abecedě.

**Ukázka:**
"PŘÍKLAD" s klíčem 3 zašifrujeme jako "SŮNLODG"

#### Petronilka

Petronilka je šifra, která nahrazuje písmena podle jejich pořadí v klíčovém slově.

**Ukázka:**
"PŘÍKLAD" s klíčem "PETRONILKA" zašifrujeme jako "PŘŤĆMĚS"

#### Mezerová šifra

Mezerová šifra využívá abecedního pořadí písmen, kde každé písmeno má svého souseda před a po sobě. Každé písmeno je nahrazeno dvojicí písmen - jedním předchozím a jedním následujícím v abecedě.

**Ukázka:**
Pro každé písmeno v textu vezmi písmeno před ním a písmeno za ním, vytvářejíc tak dvojici. Např.: "AHOJ" se zašifruje jako "ZB GI NP IK"

#### Klávesnicová šifra

Klávesnicová šifra využívá stejný princip jako mezerová šifra, s tím rozdílem, že nepoužíváme abecedu, ale klávesnici. Pro zašifrování písmene použijeme písmena, které se nachází vlevo a vpravo od daného písmene. Pokud se písmeno nachází na kraji, využijeme písmeno z druhého konce řádku.

**Ukázka:**
"AHOJ" se zašifruje jako "LS GJ IP HK" 
Můžeme využít více klávesnic Např.: QWERTY a QWERTZ, poté bude možné šifrovat slova jinak.

#### Telefonní šifra

Telefonní šifra přiřazuje každému písmenu určité číslo na staré telefonní klávesnici. Každé písmeno je získáno pomocí počtu stisků daného čísla na klávesnici, a to od jednoho do čtyř stisků.

**Ukázka:**
"AHOJ" můžeme zašifrovat dvěma způsoby "2 44 666 5" nebo "12 24 36 15" 
(První způsob ukazuje jak přesně byste měl vyťukat číslo, druhá je zkrácená, kde první číslo značí počet stisků a druhé značí které číslo.)

#### Numerická šifra

Numerická šifra nahrazuje písmena za čísla, podle jejich pořadí v abecedě. Písmena se nahradí za čísla, podle toho kolikátá se vyskytují v abecedě.

**Ukázka:**
"AHOJ" může být "1 8 15 10" nebo "01 08 15 10" nebo "01 08 0F 0A" nebo "I VIII XV X" nebo "00001 01000 01111 01010"

#### Reverzní šifra

Reverzní šifra jednoduše obrátí text a je napsaný pozpátku.

**Ukázka:**
"AHOJ" je "JOHA"

#### Obrácená abeceda

Obrácená abeceda nahrazuje písmenka textu písmenkama abecedy, která jde pozpátku.

**Ukázka:**
"AHOJ" šifrujeme jako "ZSLQ"

#### Proházená šifra

První písmenko zůstává, druhé jde na poslední pozici, třetí na druhou pozici, čtvrté na předposlední, páté jde na třetí atd.

**Ukázka:**
"ABCDEF" zašifrujeme na "ACEFDB"

