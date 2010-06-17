using Microsoft.Win32;

namespace Wallpaper
{
    public sealed class WallpaperSlideshow
    {
        private static readonly WallpaperSlideshow instance = new WallpaperSlideshow();

        static WallpaperSlideshow()
        {
        }

        private WallpaperSlideshow()
        {
        }

        /// <summary>
        /// The public Instance property to use
        /// </summary>
        public static WallpaperSlideshow Instance
        {
            get { return instance; }
        }

        public string GetCurrentWallpaper()
        {
            object value;
            using (var windows7SubKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Internet Explorer\Desktop\General", false))
            {
                value = windows7SubKey.GetValue("WallpaperSource");
            }
            if(ReferenceEquals(null, value))
            using (var dysplayFusionSubKey = Registry.CurrentUser.OpenSubKey(@"Software\Binary Fortress Software\DisplayFusion\Wallpaper", false))
            {
                value = dysplayFusionSubKey.GetValue("Wallpaper_0_FileName");
            }
            if(ReferenceEquals(null, value))
            {
                return string.Empty;
            }
            return value.ToString();
        }
    }
}
