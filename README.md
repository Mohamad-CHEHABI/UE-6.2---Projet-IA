# Projet Intelligence Artificielle

Ce projet utilise l'Intelligence Artificielle dans un contexte de mobilité et de sécurité routière. Il se base sur les données de Grand Lyon pour analyser le trafic routier.



## Objectifs fonctionnels

- Régulation du trafic de Grand Lyon
- Comptage du nombre de différents types de véhicules et de piétons (voitures, camions, motos, bus, vélos, piétons...)



## Installation

Pour installer et exécuter ce projet, vous aurez besoin de Docker. Si Docker n'est pas installé sur votre machine, vous pouvez le télécharger et l'installer à partir de [ce lien](https://docs.docker.com/get-docker/).

## Utilisation

#### Récupération des images depuis la caméra:

- Naviguez jusqu'à la racine du projet

```bash
cd UE-6.2---Projet-IA
```

- Construisez l'image Docker avec la commandes suivante :

```bash
docker build -t camera_image ./RetrieveCameraImages
```

- Lancez un conteneur Docker avec la commande suivante :

```bash
# Windows
docker run -d --rm -v .\images:/App/image --name camera_container camera_image 

# Unix
docker run -d --rm -v ./images:/App/image --name camera_container camera_image 
```

#### Récupération des images labellisées à partir d'un fichier exporté (Yolo) :

- Naviguez jusqu'à la racine du projet

- Placez le dossier exporté (unzippé) dans le dossier RetrieveYoloImages et renommez-le en `yolo`

- Construisez l'image Docker avec la commandes suivante :

```bash
docker build -t yolo_image ./RetrieveYoloImages
```

- Lancez un conteneur Docker avec la commande suivante :

```bash
# Windows
docker run -d --rm -v .\RetrieveYoloImages\yolo:/App/yolo --name yolo_container yolo_image

# Unix
docker run -d --rm -v ./RetrieveYoloImages/yolo:/App/yolo --name yolo_container yolo_image
```