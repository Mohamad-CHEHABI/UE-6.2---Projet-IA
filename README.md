# Projet Intelligence Artificielle

Ce projet utilise l'Intelligence Artificielle dans un contexte de mobilité et de sécurité routière. Il se base sur les données de Grand Lyon pour analyser le trafic routier.



## Objectifs fonctionnels

- Régulation du trafic de Grand Lyon
- Comptage du nombre de différents types de véhicules et de piétons (voitures, camions, motos, bus, vélos, piétons...)



## Installation

Pour installer et exécuter ce projet, vous aurez besoin de Docker. Si Docker n'est pas installé sur votre machine, vous pouvez le télécharger et l'installer à partir de [ce lien](https://docs.docker.com/get-docker/).

Une fois Docker installé, vous pouvez construire et exécuter l'image Docker avec les commandes suivantes :

```bash
docker build -t reconnaissance_image .
docker run -it --rm reconnaissance_image  
```

## Utilisation

Pour récupérer les données de la caméra, utilisez la commande suivante :


Pour récupérer les données labellisées à partir d'un fichier exporté, utilisez la commande suivante :

