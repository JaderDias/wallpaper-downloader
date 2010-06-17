using System.IO;

namespace Wallpaper
{
    public static class FileExtensions
    {
        public static void DeleteAndLeavePlaceHolder(string path)
        {
            var placeholderPath = path + ".del";
            using (var placeholder = File.Create(placeholderPath))
            {
            }
            File.Delete(path);
        }
    }
}
