using System.IO;
using Wallpaper.Properties;

namespace Wallpaper
{
    public static class FileExtensions
    {
        public static void DeleteAndPreventRedownload(string path)
        {
            using (var writer = new StreamWriter(Settings.Default.DontDownloadFileName, true))
            {
                writer.WriteLine(path);
            }
            File.Delete(path);
        }
    }
}
