# USRS46_Miniville

Le jeu de Miniville (dans le cadre de l'UE USRS46) réalisé par Noa Hussenet, Théo Excille, Sulivan Michalon et Enki Bachelier (Groupe C).

City-builder tour par tour qui se joue avec des cartes et des dés (Conçu par Masao Suganuma).

# Comment lancer le projet Console ?

Dans le fichier "Version Console", lancer la solution (.sln) avec Visual Studio 2019. Puis "CTRL + F5" pour exécuter le jeu.

# Comment démarrer le jeu ?

La première chose demandée est le nombre de maires/de joueurs (illimité). Ensuite, il vous est demandé de rentrer les noms de chaque maire.
Vous avez ensuite la possibilité de choisir entre quatre modes de parties (Rapide, Standard, Longue et Experte). Chaque mode diffère par ses conditions de victoire (10 pièces, 20 pièces, 30 pièces, 20 pièces et en possession de tous les types de cartes). 
Tout les joueurs débutent la partie avec un champ de blé, une ferme et 3$.

# Comment se déroule un tour de jeu ?

Au début du tour d'un joueur, un dé est lancé et selon sa valeur, certaines cartes possédées par les joueurs vont activer leur effet (voir plus bas). Suite à cette vérification, le jeu demande au joueur s'il souhaite acheter une carte et laquelle (selon une pile avec 6 exemplaires de chaque type de carte). On passe ensuite au tour du prochain joueur. 
Si jamais l'un des joueur atteint la/les conditions de victoire, le jeu se termine et affiche le nom du gagnant.

# Quels sont les différents types de cartes ?

- Les champs de blé coûtent 1$ et vous rapporte 1$ si le dé tombe sur la valeur 1
- La ferme coûte 2$ et vous rapporte 1$ si le dé tombe sur la valeur 1
- La boulangerie coûte 1$ et vous rapporte 2$ si le dé tombe sur la valeur 2
- Le café coûte 2$ et vous rapporte 1$ du joueur qui a lancé le dé (tombé sur la valeur 3)
- La superette coûte 2$ et vous rapporte 3$ lorsque le dé affiche 5
- Le restaurant coûte 4$ et vous rapporte 2$ du joueur qui a lancé le dé (tombé sur la valeur 5)
- Le stade coûte 6$ et vous rapporte 4$ lorsque le dé affiche 6

# Que peut-on trouver dans les dossiers du jeu ?

Vous pouvez retrouver l'énoncé du projet donné par l'ENJMIN, les différents codes (Card.cs, Game.cs, Player.cs, Dice.cs, Pile.cs, Program.cs) et les différentes versions du diagramme UML du projet.

# Quelles seront les futures améliorations ?

Un projet n'est jamais véritablement fini, il peut être amélioré en terme de visuel et d'optimisation.
