# HearthstoneCollections

### CONG Jinyu (INALCO R&D 22304478)

congtaotao2001@gmail.com

(projet pour le cours "Programmation objet 1")

---

HearthstoneCollections est une application console qui permet de stocker des informations sur les cartes de Hearthstone. Elle inclut 11 commandes ainsi qu'un paramètre pour changer la langue, les langues prises en charge étant le chinois et le français.

Les commandes disponibles sont les suivantes :

- Ajouter une carte,
- Découvrir une carte,
- Rechercher une carte,
- Calculer le nombre de cartes,
- Lire les informations des cartes à partir d'un fichier CSV ou TXT,
- Lire les informations des cartes à partir d'un fichier XML,
- Sauvegarder les informations des cartes dans un fichier CSV ou TXT,
- Sauvegarder les informations des cartes dans un fichier XML,
- Changer la langue,
- Afficher l'aide,
- Quitter l'application.

## Introduction du programme et prétraitement des données

Ce programme comprend les 11 commandes mentionnées ci-dessus, chacune ayant sa propre fonctionnalité.

[Le fichier XML utilisé](./HearthstoneCollections/data/CardData.xml) pour saisir les informations des cartes peut être trouvé via le lien suivant :
https://github.com/HearthSim/hsdata

Les informations des cartes incluent 13 types de données, comme l’identifiant de la carte, le nom, la rareté, etc. Parmi celles-ci, j’ai extrait 10 types d’informations pour créer les données des cartes dans ma collection :

`id` : l’identifiant de la carte,

`name` : le nom de la carte,

`rarity` : la rareté de la carte,

`type` : le type de carte,

`attack` : l’attaque,

`health` : les points de vie,

`cost` : le coût,

`class` : la classe de la carte,

`text` : le texte de la carte.

Dans le fichier original, de nombreuses informations sur les cartes sont incomplètes. Par exemple, certaines cartes n’ont pas de classe spécifiée. J’ai remarqué que ces cartes sans classe appartiennent toutes à la catégorie des cartes neutres (neutral). Ainsi, dans mon programme, j’ai par défaut attribué les cartes sans classe à la catégorie des cartes neutres.

De plus, certaines cartes contiennent du texte réparti sur plusieurs lignes, ce qui provoque des défauts lors de l’affichage des informations. Par conséquent, j’ai modifié le texte de ces cartes pour qu’il soit affiché sur une seule ligne dans mon programme.

## Commandes utilisables

### `add` ou `ajouter`

Ajoute une carte à la collection.

(réalisée par [AddCommand.cs](./HearthstoneCollections/Commands/AddCommand.cs))

`add <nom> <rareté> <type> <texte> <attaque> <vie> <coût> <classe> <découvert>`

exemple: `add "Ragnaros the firelord" legendary minion "Can't attack. At the end of your turn, deal 8 damage to a random enemy." 8 8 8 Neutral true`

> Attention: le texte doit être entre guillemets

---

### `search` ou `rechercher`

Rechercher une carte par son nom ou afficher toutes les cartes d'une classe spécifique.

(réalisée par [SearchCommand.cs](./HearthstoneCollections/Commands/SearchCommand.cs))

`search <nom de carte>` pour spécifier un nom de carte et afficher ses informations.

ou `search <classe>` pour afficher toutes les cartes de la classe spécifiée.

exemple: 

`search mage` affichera toutes les cartes de la classe mage.

`search "ice block"` affichera les informations de la carte 'ice block'.

---

### `discover` ou `découvrir`

Marque une ou plusieurs cartes comme "découvertes".

(réalisée par [DiscoverCommand.cs](./HearthstoneCollections/Commands/DiscoverCommand.cs))

`discover <nom de carte>*` pour définir les cartes spécifiées comme découvertes.

exemple: 

`discover ragnaros "ice block"`

> Cette commande permet de découvrir plusieurs cartes en même temps.

---

### `load` ou `charger`

Charge les informations des cartes à partir d'un fichier spécifié.

(réalisée par [LoadTextCommand.cs](./HearthstoneCollections/Commands/LoadTextCommand.cs))

`load <chemin du fichier>`

exemple:

`load data/test.csv` pour charger les informations des cartes à partir de data/test.csv

>Attention : le contenu du fichier doit être séparé par des tabulations.

---

### `loadxml` ou `chargerxml`

Charge les informations des cartes depuis un fichier XML.

(réalisée par [LoadXmlCommand.cs](./HearthstoneCollections/Commands/LoadXmlCommand.cs))

`loadxml <chemin du fichier>`

exemple:

`loadxml data/CardData.xml` pour charger toutes les informations des cartes dans CardData.xml dans la collection

---

### `save` ou `enregistrer`

Enregistre les cartes découvertes dans un fichier spécifié.

(réalisée par [SaveTextCommand.cs](./HearthstoneCollections/Commands/SaveTextCommand.cs))

`save <nom du fichier>`

exemple:

`save <nom du fichier>.txt` ou `save <nom du fichier>.csv` pour enregistrer les cartes découvertes dans un fichier .txt ou .csv.

---

### `savexml` ou `enregistrerxml`

Enregistre les informations des cartes de la collection dans un fichier XML.

(réalisée par [SaveXmlCommand.cs](./HearthstoneCollections/Commands/SaveXmlCommand.cs))

`savexml <chemin de sauvegarde>`

exemple:

`savexml test.xml` ou `save test`

---

### `switch` ou `changer`

Change la langue du programme (ex. : français ou chinois).

(réalisée par [SwitchLanguageCommand.cs](./HearthstoneCollections/Commands/SwitchLanguageCommand.cs))

`switch fr` ou `switch zh` pour changer la langue en français ou en chinois.

---

### `count` ou `compter`

Compter le nombre de cartes de toutes les classes ou d'une classe spécifiée.

(réalisée par [CountCommand.cs](./HearthstoneCollections/Commands/CountCommand.cs))

exemple:

`count all` comptera le nombre total de cartes dans la collection.

`count mage` comptera le nombre de cartes de la classe mage.

---
### `battle ou battre`

pour déterminer le gagnant entre deux serviteurs. Si un serviteur meurt, l'autre est déclaré vainqueur, et si les deux serviteurs meurent ou survivent, il n'y a pas de gagnant.

(réalisée par [BattleCommand.cs](./HearthstoneCollections/Commands/BattleCommand.cs))

exemple:

`battle "Goldshire Footman" "River Crocolisk"`

---

### `exit` ou `quitter`

Quitte le programme.

(réalisée par [ExitCommand.cs](./HearthstoneCollections/Commands/ExitCommand.cs))

`exit` pour quitter le programme.

---

### `help` ou `aide`

Affiche les informations d'aide pour les commandes.

(réalisée par [HelpCommand.cs](./HearthstoneCollections/Commands/HelpCommand.cs))

`help` pour afficher les aides.

> ### Les commandes en anglais et en français permettent tous l'execution de la programme. 

> ### Utiliser `<commande> --help` pour afficher l'utilisation d'une commande plus précise.
> ### Comme `search --help`


> ### Attention : Au début, il n'y a pas d'informations sur les cartes dans la base de données. Vous devez exécuter manuellement `loadxml data/CardData.xml` pour ajouter les informations sur les cartes avant de pouvoir utiliser des commandes comme la recherche.

## Propriété de calcul

Ce projet permet de calculer le nombre de cartes dans la collection, ainsi que de déterminer quel serviteur remportera une bataille lorsque deux serviteurs s'affrontent.
Par exemple, le serviteur "Goldshire Footman" a une attaque et des points de vie de (1;2), et le serviteur "River Crocolisk" a une attaque et des points de vie de (2;3). Au final, River Crocolisk l'emportera. Le résultat sera affiché comme suit :

```
$ loadxml data/CardData.xml
卡牌录入成功，现有卡牌数：1619

$ battle "Goldshire Footman" "River Crocolisk"
胜出者：River Crocolisk
```