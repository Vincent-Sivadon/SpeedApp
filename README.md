# SpeedApp : Gestion de Planning
SpeedApp est une Application de gestion de planning pour tournois de Crossminton, développée en C# avec Winforms.  
![PlanningWindow](SpeedAppPlanning.PNG "Planning Window")
![BracketsWindow](SpeedAppBrackets.PNG "Brackets Window")

## Installation

## Utilisation
Il y a deux fenêtres liées à cette application. La première est la vue du `Planning`, la deuxième la vue `Brackets`.

### Planning
Pour réaliser un planning, l'application à besoin d'un fichier organisé comme :
```
Poule 0
Joueur1
Joueur2
Joueur3
Joueur4

Poule 1
Joueur5
Joueur6
Joueur7
Joueur8
```
Au lancement, si dans le répertoire "Documents" de l'ordinateur est présent un fichier nommé "poules.txt", un planning sera généré automatiquement.  
Sinon, il suffit de cliquer sur le bouton au dessus de "Planning" pour soi-même chercher un fichier à traiter.  
Pour l'instant le nombre de terrains n'impacte pas le planning, il est donc pris à 3 et n'a pas de raison d'être modifié.  
En cliquant sur un joueur, on met en valeur toutes les itérations de son nom et des noms des joueurs de sa poule.

### Brackets
La modification des noms des labels se fait en `double-cliquant`, puis en appuyant sur la touche `Entrer`.  
On peut aussi colorer les labels avec le `clic-droit`, indiquant le vainqueur.
