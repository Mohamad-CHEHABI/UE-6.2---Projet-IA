# Projet Intelligence Artificielle

Ce projet utilise l'Intelligence Artificielle dans un contexte de mobilité et de sécurité routière. Il se base sur les données de Grand Lyon pour analyser le trafic routier.



## Objectifs fonctionnels

- Régulation du trafic de Grand Lyon
- Comptage du nombre de différents types de véhicules et de piétons (voitures, camions, motos, bus, vélos, piétons...)



## Installation

Pour installer et exécuter ce projet, vous aurez besoin de Docker. Si Docker n'est pas installé sur votre machine, vous pouvez le télécharger et l'installer à partir de [ce lien](https://docs.docker.com/get-docker/).

En utiliser Visual Studio Code, il faut installer les extensions Docker et C# Dev Kit.

## Utilisation

#### Récupération des images depuis la caméra:

- Naviguez jusqu'au dossier RetrieveCameraImages

```bash
cd/RetrieveCameraImages
```

- Construisez et exécuter l'image Docker avec les commandes suivantes :

```bash
docker build -t camera_image .
docker run -it  camera_image  
```

#### Récupération des images labellisées à partir d'un fichier exporté (Yolo) :

- Naviguez jusqu'au dossier RetrieveYoloImages

```bash
cd/RetrieveYoloImages
```
- Construisez et exécuter l'image Docker avec les commandes suivantes :

```bash
docker build -t yolo_image .
docker run -it yolo_image  
```