using System;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;

public class retrieveImages
{
    // Variable pour stocker le hachage de l'image précédemment téléchargée
    static string? previousImageHash = null;

    public static async Task RetrieveImages()
    {
        string baseUrl = "https://download.data.grandlyon.com/files/rdata/pvo_patrimoine_voirie.pvocameracriter/CWL9018.JPG";
        int imageCount = 50; // Nombre d'images à télécharger
        string directoryPath = "images"; // Répertoire où enregistrer les images

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
            string filename = $"image_{timestamp}.jpg";
            string filePath = Path.Combine(directoryPath, filename);

            // Télécharge l'image et vérifie si elle est différente de la précédente
            await DownloadImage(baseUrl, filePath);
            Console.WriteLine($"Image téléchargée : {filename}");
        }
    }

    static async Task DownloadImage(string url, string filePath)
    {
        using (var httpClient = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    using (var ms = new MemoryStream())
                    {
                        await response.Content.CopyToAsync(ms);
                        // Calcule le hachage de l'image téléchargée
                        var hash = GetHash(ms.ToArray());
                        // Vérifie si le hachage est différent de celui de l'image précédente
                        if (hash != previousImageHash)
                        {
                            // Si le hachage est différent, enregistre l'image et met à jour le hachage précédent
                            ms.Position = 0;
                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                await ms.CopyToAsync(fileStream);
                            }
                            previousImageHash = hash;
                        }
                        else
                        {
                            // Si le hachage est le même, n'enregistre pas l'image
                            Console.WriteLine("L'image est identique à la précédente, elle n'a pas été téléchargée");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Échec du téléchargement de l'image");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors du téléchargement de l'image : {ex.Message}");
            }
        }
    }

    // Méthode pour calculer le hachage SHA256 d'un tableau de bytes
    static string GetHash(byte[] data)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hash = sha256.ComputeHash(data);
            return BitConverter.ToString(hash).Replace("-", String.Empty);
        }
    }
}