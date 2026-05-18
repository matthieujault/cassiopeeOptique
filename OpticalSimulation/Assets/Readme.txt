# Simulateur optique — Unity + Matrices ABCD

## Description
Logiciel de simulation optique géométrique développé sous Unity.
Il implémente le formalisme des matrices ABCD pour modéliser
la propagation de rayons lumineux à travers des éléments optiques.

## Formalisme ABCD
Un rayon est décrit par le vecteur [r, θ] où :
- r = position par rapport à l'axe optique
- θ = angle par rapport à l'axe optique

Un élément optique est une matrice 2×2 :
[ r' ]   [ A  B ] [ r ]
[ θ' ] = [ C  D ] [ θ ]

### Matrices implémentées

Propagation libre (distance d) :
[ 1  d ]
[ 0  1 ]

Lentille mince (focale f) :
[  1    0 ]
[ -1/f  1 ]

Le déterminant AD - BC = 1 (milieu homogène).

## Structure des scripts

| Script             | Rôle                                              |
|--------------------|---------------------------------------------------|
| RayData.cs         | Rayon lumineux [r, θ]                             |
| ABCDMatrix.cs      | Matrice 2×2 + application + composition           |
| Lens.cs            | Lentille mince, sa matrice, ses foyers F et F'    |
| FreeSpace.cs       | Propagation libre, sa matrice                     |
| OpticalSystem.cs   | Système complet = liste ordonnée d'éléments       |
| LightRay.cs        | Tracé visuel du rayon dans Unity                  |

## Configuration Unity

### Objets de la scène
- Dispositif (parent vide, Position Y=2)
  - Optical_bench
  - Lens        (Rotation Z=90, Scale X=0.5 Y=0.1 Z=0.5)
  - LightSource (Position X=-5 Y=0 Z=0 relatif au parent)
  - Sphere

### Lens — Inspector
- Focal Length : 3 (modifiable)

### LightSource — Inspector
- Max Distance : 100

## Repères visuels en jeu
- Rouge  → rayon incident
- Vert   → rayon réfracté (sortant)
- Cyan   → axe optique
- Jaune  → foyer image F'
- Orange → foyer objet F
- Jaune (petit trait) → position de A' sur l'axe
- Magenta (petit trait) → position de B' (image)

## Étapes suivantes prévues
- Ajout de plusieurs lentilles (composition de matrices)
- Propagation libre entre éléments (FreeSpace)
- Faisceaux gaussiens via paramètre complexe q
- Interface utilisateur pour paramétrer f en temps réel
- Export JSON du système optique
- Script Python de validation des matrices