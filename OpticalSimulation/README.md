# Optical Simulation - Unity Project

## Description

Ce projet consiste en le développement d’un logiciel de simulation optique réalisé avec Unity.
Il permet de modéliser un banc optique virtuel en 3D et de simuler le comportement des rayons lumineux à travers différents composants optiques.

L’objectif est de proposer un outil interactif permettant de :

* visualiser des systèmes optiques en trois dimensions
* tracer des rayons lumineux
* observer des phénomènes physiques tels que la réflexion et la réfraction
* reproduire des expériences optiques

---

## Fonctionnalités actuelles

* Création d’un banc optique 3D
* Ajout d’une source lumineuse
* Tracé de rayons lumineux
* Détection de collision avec des objets optiques (lentilles)
* Simulation de réflexion des rayons lumineux
* Simulation de réfraction (en cours de développement)

---

## Concepts physiques utilisés

Le projet repose sur les principes de l’optique géométrique :

* Propagation rectiligne de la lumière
* Réflexion des rayons lumineux
* Réfraction selon les lois de Snell-Descartes

---

## Technologies utilisées

* Unity (moteur de rendu 3D)
* C# (scripts de simulation)
* Modélisation mathématique (géométrie des rayons)
* Python (prévu pour validation et traitement des données)

---

## Structure du projet

```plaintext
Assets/
 ├── Scripts/        # Scripts C#
 ├── Materials/      # Matériaux (source lumineuse, objets)
 ├── Scenes/         # Scènes Unity
 ├── Prefabs/        # Objets réutilisables
```

---

## Lancer le projet

1. Ouvrir le projet avec Unity
2. Charger la scène principale (SampleScene)
3. Cliquer sur "Play"
4. Observer le comportement des rayons lumineux et leur interaction avec les objets optiques

---

## Objectifs du projet

* Implémenter une simulation réaliste des lentilles optiques
* Ajouter différents composants optiques
* Permettre une interaction utilisateur avancée
* Mettre en place un système d’export et d’import des configurations
* Améliorer la précision physique de la simulation

---

## Améliorations futures

* Simulation de lentilles convergentes et divergentes
* Gestion de faisceaux lumineux
* Système de sauvegarde (format JSON)
* Simulation de systèmes optiques complexes
* Développement d’une version pédagogique

---

## Auteur

Projet réalisé dans le cadre d’un travail académique en simulation optique.

---

## Licence

Projet à but éducatif.
