# USRS46_Miniville

Le jeu de Miniville (dans le cadre de l'UE USRS46) réalisé par Noa Hussenet, Théo Excille, Sullivan Michalon et Enki Bachelier (Groupe C).

City-builder tour par tour qui se joue avec des cartes et des dés (Conçu par Masao Suganuma).

# Comment lancer le projet Console ?

Dans le fichier "Miniville_GroupeC", lancer la solution (Miniville_GroupeC.sln) avec Visual Studio 2019. Puis "CTRL + F5" pour exécuter le jeu.

# Comment lancer le projet Unity ?

Dézipper le fichier "Miniville_Unity_GroupeC" puis lancer l'application Miniville (icône en pièce avec une tête).

# Comment démarrer le jeu Console ?

La première chose demandée est le nombre de maires/de joueurs (illimité). Ensuite, il vous est demandé de rentrer les noms de chaque maire.
Vous avez ensuite la possibilité de choisir entre quatre modes de parties (Rapide, Standard, Longue, Experte et Réele). Chaque mode diffère par ses conditions de victoire (10 pièces, 20 pièces, 30 pièces, 20 pièces et en possession de tous les types de cartes et enfin être en possession de tous les monuments). 
Tout les joueurs débutent la partie avec un champ de blé, une ferme et 3$.

# Comment démarrer le jeu Unity ?

Appuyer sur le bouton "Commencer". Ensuite, vous pouvez lancer le dé en cliquant (clic gauche) sur l'écran et acheter une carte en cliquant sur la carte. La partie se termine lorsqu'au moins un des joueurs possède 20 pièces.

# Comment se déroule un tour de jeu ?

Au début du tour d'un joueur, un dé est lancé et selon sa valeur, certaines cartes possédées par les joueurs vont activer leur effet (voir plus bas). Suite à cette vérification, le jeu demande au joueur s'il souhaite acheter une carte et laquelle (selon une pile avec 6 exemplaires de chaque type de carte). On passe ensuite au tour du prochain joueur. 
Si jamais l'un des joueur atteint la/les conditions de victoire, le jeu se termine et affiche le nom du gagnant.

# Quels sont les différents types de cartes ?

- Les champs de blé coûtent 1$ et vous rapporte 1$ si le dé tombe sur la valeur 1.
- La ferme coûte 2$ et vous rapporte 1$ si le dé tombe sur la valeur 1.
- La boulangerie coûte 1$ et vous rapporte 2$ si le dé tombe sur la valeur 2 ou 3.
- Le café coûte 2$ et vous rapporte 1$ du joueur qui a lancé le dé (tombé sur la valeur 3).
- La superette coûte 2$ et vous rapporte 3$ lorsque le dé affiche 4.
- La forêt coûte 3$ et vous rapporte 1$ lorsque le dé affiche 5.
- Le stade coûte 6$ et vous rapporte 4$ lorsque le dé affiche 6.
- La fromagerie coûte 5$ et vous rapporte 3$ lorsque le dé affiche 7.
- La fabrique de meubles coûte 3$ et vous rapporte 3$ lorsque le dé affiche 8.
- La mine coûte 6$ et vous rapporte 5$ lorsque le dé affiche 9.
- Le restaurant coûte 3$ et vous rapporte 2$ du joueur qui a lancé le dé (tombé sur la valeur 9 ou 10).
- Le verger coûte 3$ et vous rapporte 3$ lorsque le dé affiche 10.
- Le marché coûte 2$ et vous rapporte 2$ lorsque le dé affiche 11 ou 12.
- Le parc d'attractions (monument) coûte 16$ et, lorsqu'il est acheté, si votre jet de dés est un double, rejouez directement.
- La tour radio (monument) coûte 22$ et, lorsqu'elle est achetée, vous pouvez choisir de relancer vos dés une fois par tour.
- La gare (monument) coûte 4$ et, lorsqu'elle est achetée, vous pouvez choisir de lancer deux dés au lieu d'un.
- Le centre commercial (monument) coûte 10$ et, lorsqu'il est acheté, il booste les revenus (de 1$) des cafés, restaurants, supérettes et boulangeries que vous possèdez.

# Que peut-on trouver dans les dossiers du jeu ?

Vous pouvez retrouver l'énoncé du projet donné par l'ENJMIN, les différents codes (Card.cs, Game.cs, Player.cs, Dice.cs, Pile.cs, Program.cs) et les différentes versions du diagramme UML du projet.

# Quelles seront les futures améliorations ?

Un projet n'est jamais véritablement fini, il peut être amélioré en terme de visuel et d'optimisation. Nous pouvons également rajouter toutes les améliorations consoles sur la version Unity et améliorer l'IA. Nous pouvons également rajouter du son sur la version Unity

# Qui a travaillé sur quoi ?

Noa Hussenet a travaillé sur le système de dés (simple et double), sur l'intégration des monuments et du mode de jeu "réel" et sur les noms des IA.

Sullivan Michalon a travaillé sur l'intégralité de l'IA, une partie de la classe Player et le mode de jeu "Contre l'Ordinateur".

Théo Excille a travaillé sur la version Unity (amélioration interface graphique), la classe Mastercard et ses dérivées et une partie de la classe Player (Activation des cartes et Possibilité d'achat).

Enki Bachelier a coordonné le projet en travaillant sur l'intégration des différentes branches et le debug général. Il a également travaillé sur la classe Game, les modes de difficultés (sauf le réel) et réalisé les visuels des cartes.
