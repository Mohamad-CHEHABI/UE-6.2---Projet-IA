﻿class Program
{
    static async Task Main(string[] args)
    {
        await CameraImageRetriever.RetrieveCameraImages();
    }
}