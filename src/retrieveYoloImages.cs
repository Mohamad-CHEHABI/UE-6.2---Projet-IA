using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

public class retrieveYoloImages
{
    public static async Task RetrieveYoloImages()
    {
        // Répertoire contenant le fichier d'annotations
        string labelsDirectory = "yolo/labels";

        // Répertoire où enregistrer les images       
        string imagesDirectory = "yolo/images";

        // URL de base pour télécharger les images
        string baseUrl = "https://app.heartex.com/storage-data/uploaded/?filepath=upload/67163/";
        
        // string baseUrl = "https://app.heartex.com/projects/67163/data?tab=87519/";

        // Vérifie si le répertoire existe, sinon le crée
        if (!Directory.Exists(imagesDirectory))
        {
            Directory.CreateDirectory(imagesDirectory);
        }

        // Utilise HttpClient pour envoyer des requêtes HTTP
        using (HttpClient client = new HttpClient())
        {

            // Ajoute le jeton d'authentification à l'en-tête de la requête
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", "138473fd03911954ed4b1b5718936a8432398b50");

            // Parcours les fichiers d'annotations pour télécharger les images correspondantes
            foreach (var labelFile in Directory.GetFiles(labelsDirectory, "*.txt"))
            {
                // Construit l'URL de l'image à partir du nom du fichier d'annotation
                string labelFileName = Path.GetFileNameWithoutExtension(labelFile);
                string imageUrl = $"{baseUrl}{labelFileName}.jpg";

                // Envoie une requête GET pour télécharger l'image
                var response = await client.GetAsync(imageUrl);

                // Vérifie si la requête a réussi
                if (response.IsSuccessStatusCode)
                {
                    // Enregistre l'image dans le répertoire images
                    var imageBytes = await response.Content.ReadAsByteArrayAsync();
                    await File.WriteAllBytesAsync(Path.Combine(imagesDirectory, $"{labelFileName}.jpg"), imageBytes);
                    Console.WriteLine($"Image téléchargée : {labelFileName}.jpg");
                }
                else
                {
                    Console.WriteLine($"Erreur lors du téléchargement de l'image : {labelFileName}.jpg");
                    Console.WriteLine($"Code d'état HTTP : {response.StatusCode}");
                    Console.WriteLine($"Contenu de la réponse : {await response.Content.ReadAsStringAsync()}");
                }
            }
        }
    }
}