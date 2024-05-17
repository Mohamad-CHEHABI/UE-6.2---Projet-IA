class Program
{
    static async Task Main(string[] args)
    {
        await retrieveImages.RetrieveCameraImages();
        // Boucle infinie pour empêcher l'application de s'arrêter
        // while (true)
        // {
        //     // Vous pouvez ajouter un délai ici pour éviter une utilisation excessive du CPU
        //     System.Threading.Thread.Sleep(1000);
        // }
    
    }
}