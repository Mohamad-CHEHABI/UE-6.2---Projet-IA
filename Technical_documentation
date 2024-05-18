# Documentation Technique

## Prérequis

- Docker installé sur votre machine
- Connaissance de base en C#
- Git installé sur votre machine

## Structure du Projet

Le projet est structuré comme suit :

- `.gitignore` : Ce fichier spécifie les fichiers et dossiers que Git doit ignorer.Ce fichier spécifie les fichiers et dossiers que Git doit ignorer.
- `README.md` : Ce fichier contient les instructions d'installation et d'utilisation du projet.
- `Technical_documentation.md`: Ce fichier contient la documentation technique du projet.
- `RetrieveCameraImages`: Ce dossier contient le code nécessaire pour récupérer les images depuis la caméra.
    - `CameraImagesRetriever.cs`: Ce fichier contient les méthodes pour récupérer les images de la caméra.
    - `Dockerfile`: Ce fichier contient les instructions pour construire l'image Docker pour le projet.
    - `Program.cs` : Le fichier principal qui appelle la méthode à exécuter lors de l'exécution de l'application.
- `RetrieveYoloImages` : Ce dossier contient le dossier exporté Yolo et le code nécessaire pour récupérer les images Yolo.
    - `YoloImagesRetriever.cs` : Ce fichier contient les méthodes pour récupérer les images Yolo.
    - `Dockerfile` : Ce fichier contient les instructions pour construire l'image Docker pour le projet.
    - `Program.cs` : Le fichier principal qui appelle la méthode à exécuter lors de l'exécution de l'application.



## Comment exécuter le projet

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

## Comment modifier le comportement du projet

Pour modifier le comportement du projet, vous pouvez effectuer les modifications suivantes dans le code :

1. **Changer le nombre d'images à télécharger** : Modifiez la valeur de `imageCount` dans la méthode `RetrieveCameraImages` de la classe `CameraImageRetriever`.
```c#
int imageCount = 50; // Changez cette valeur pour télécharger plus ou moins d'images
```

2. **Modifier l'intervalle entre les téléchargements d'images** : Modifiez la valeur de `Task.Delay` dans les méthodes `RetrieveCameraImages` et `RetrieveYoloImages`.
```c#
await Task.Delay(60000); // Dans RetrieveCameraImages, changez cette valeur pour modifier l'intervalle entre les téléchargements d'images de la caméra
await Task.Delay(5000); // Dans RetrieveYoloImages, changez cette valeur pour modifier l'intervalle entre les téléchargements d'images Yolo
```

3. **Changer l'URL de base pour télécharger les images** : Modifiez la valeur de `baseUrl` dans les méthodes `RetrieveCameraImages` et `RetrieveYoloImages`.
```c#
string baseUrl = "https://download.data.grandlyon.com/files/rdata/pvo_patrimoine_voirie.pvocameracriter/CWL9018.JPG"; // Dans RetrieveCameraImages
string baseUrl = "https://app.heartex.com/storage-data/uploaded/?filepath=upload/67163/"; // Dans RetrieveYoloImages
```

4. **Modifier le répertoire où les images sont enregistrées** : Modifiez la valeur de `directoryPath` dans `RetrieveCameraImages` et `imagesDirectory` dans `RetrieveYoloImages`.
```c#
string directoryPath = "image"; // Dans RetrieveCameraImages
string imagesDirectory = "yolo/images"; // Dans RetrieveYoloImages
```

5. **Modifier le jeton d'authentification pour les requêtes HTTP** : Modifiez la valeur de `AuthenticationHeaderValue` dans `RetrieveYoloImages`.
```c#
client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", "Your_Token");
```