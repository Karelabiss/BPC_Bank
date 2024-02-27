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
