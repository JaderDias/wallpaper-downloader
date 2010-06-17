using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DownloaderService;
using System.IO;
using Wallpaper;

namespace MigrationTool
{
    class Program
    {
        static void Main(string[] args)
        {
            var outputFolder = WallpaperDownloaderService.GetRegistryValue("WallpaperOutputFolder");
            var files = Directory.EnumerateFiles(outputFolder, "*.del");
            var dontDownloadFile = Model.GetDontDownloadFilePath();
            using (var writer = new StreamWriter(dontDownloadFile, true))
                foreach (var file in files)
                {
                    var fileName = Path.GetFileNameWithoutExtension(file);
                    writer.WriteLine(fileName);
                    File.Delete(file);
                }
        }
    }
}
