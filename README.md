# Bankový systém

## Popis
Bankový systém kde budeme môcť vytvárať profil zákazníka a upravovať mu meno, IDčko, atd. Bude vedieť pridať a odobrať peniaze z účtu alebo ich poslať nejakému inému zákazníkovy podľa bankového účtu

## Štruktúra

> [!CAUTION]
> Prosím pre všetky funkcie používať Hungarian Notation systém nech v tom neni bordel

- Funkcia bankProfile
- Funkcia bankOperations
- Funkcia dataOperations

### bankProfile
Funkcia zameraná na práce s profilom

- createProfile - vytvorenie profilu pre zákazníka
- deleteProfile - vymazanie profilu pre zákazníka
- changeProfileInfo - Toto by mohla byť všeobecná funkcia, ktorá môže zmeniť všetky informácie o profile. Ak niečo nechcem zmeniť dám tam `NULL`
- changeProfileName - Toto je druhá možnosť že by bola pre každú premennú profilu jedna funkcia na jej zmenu
- ...

### bankOperations
Funkcia zameraná na prácu s peniazmi na profile

- addFunds - Pridať peniaze na účet
- payFunds - Zaplatiť peniazmi z účtu
- transferFunds - Preniesť peniaze z účtu na iný účet


### dataOperations
Toto je bonusová funkcia, ktorú môžme neskôr použíť pre implementáciu s databázou ako pridať hashe k heslám a údajom atd. atd.

## bankProfile

### Funkcia profileLogin()

Funkcia ktorá prihlási daný účet na základe meno a hesla. Vytvorený hash účtu použijeme ako cookies v databáze aby sme mohli vyberať informácia a ich upravovať. (Je to bezpečné? NIE! Funguje to? ÁNO!) 

### Funkcia profileLogout()

Funkcia ktorá odhlási daný účet. V tomto prípade iba ostráni premennú profileName.

### Funkcia createProfile()

Vytvorenie bankoveho profilu
každý bankový účet dostane hash na základe profileName, ktoré bude slúžiť na operácie s účetom.

### Funkcia changeProfileInfo()

Funkcia, ktorá zmení niektoré informácie o účte.

### Funkcia deleteProfile()

Funkcia, ktorá odstráni daný účet.

## BankOperations

### Funkcia sendPayment()

Funkcia, ktorá slúži na zaplatenie nejakého produktu. (Okamžitá platba)

### Funkcia sendTransaction()

Funkcia, ktorá slúži ako tranzakcia. (Štandardná platba na účet). Môže trvať dlhšie a zároveň môže sa tam používať 2FA a pod.

## Data ooperations

Tu sa bude riešiť pripojenie do databáze.
