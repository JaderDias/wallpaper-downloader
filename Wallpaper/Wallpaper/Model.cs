using System;
using System.Collections.Generic;
using System.Text;
using Wallpaper.Properties;
using System.IO;
using Microsoft.Win32;

namespace Wallpaper
{
    public static class Model
    {
        public static string GetRegistryValue(string key)
        {
            var subkeyLocation = @"Software\HourlyApps";
            using (var subkey = Registry.LocalMachine.OpenSubKey(subkeyLocation))
            {
                return (string)subkey.GetValue(key);
            }
        }

        public static string GetDontDownloadFilePath()
        {
            var outputFolder = GetRegistryValue("WallpaperOutputFolder");
            return Path.Combine(outputFolder, Settings.Default.DontDownloadFileName);
        }
    }
}
