using System;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;

public class retrieveImages
{
    public static async Task RetrieveCameraImages()
    {
        string baseUrl = "https://download.data.grandlyon.com/files/rdata/pvo_patrimoine_voirie.pvocameracriter/CWL9018.JPG";
        int imageCount = 50; // Nombre d'images à télécharger
        string directoryPath = "image"; // Répertoire où enregistrer les images

        // Vérifie si le répertoire existe, sinon le crée
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        for (int i = 1; i <= imageCount; i++)
        {
            if (i > 1)
            {
                // Attendre 60 secondes avant de télécharger la prochaine image
                await Task.Delay(60000);
            }
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string filename = $"{timestamp}.jpg";
            string filePath = Path.Combine(directoryPath, filename);

            // Télécharge l'image et vérifie si elle est différente de la précédente
            await DownloadCameraImage(baseUrl, filePath);
            Console.WriteLine($"Image téléchargée depuis la caméra : {filename}");
        }
    }

    protected static async Task DownloadCameraImage(string url, string filePath)
    {
        // Variable pour stocker le hachage de l'image précédemment téléchargée
        string? previousImageHash = null;
        using (var httpClient = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    // Lit le contenu de la réponse dans un MemoryStream,
                    using (var ms = new MemoryStream()) // MemoryStream est utilisé pour stocker les données en mémoire
                    {
                        await response.Content.CopyToAsync(ms);
                        // Calcule le hachage de l'image téléchargée
                        var hash = GetImageHash(ms.ToArray());
                        // Vérifie si le hachage est différent de celui de l'image précédente
                        if (hash != previousImageHash)
                        {
                            // Si le hachage est différent, enregistre l'image et met à jour le hachage précédent
                            ms.Position = 0;
    