using System;
using System.IO;
using System.Windows.Forms;
using Wallpaper;

namespace WallpaperDeleteForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var path = WallpaperSlideshow.Instance.GetCurrentWallpaper();
            if (File.Exists(path))
            {
                var confirmationMessage = string.Format("When deleting the following image you want to prevent it being downloaded again:{0}{1}{0}?", Environment.NewLine, path);
                var dialogResult = MessageBox.Show(confirmationMessage, "Wallpaper deletion confirmation", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    FileExtensions.DeleteAndPreventRedownload(path);
                }
                else if(dialogResult == DialogResult.No)
                {
                    File.Delete(path);
                }
            }
            else
            {
                MessageBox.Show("File not found!", "Couldn't delete wallpaper");
            }
        }
    }
}
