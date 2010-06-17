using System;
using System.Net;

namespace Wallpaper
{
    public static class WebClientExtensions
    {
        public static bool TryDownloadFile(WebClient webClient, string address, string fileName, int times)
        {
            for (var i = 0; i < times; i++)
            {
                try
                {
                    webClient.DownloadFile(address, fileName);
                    return true;
                }
                catch (WebException)
                {
                }
            }
            return false;
        }

        public static string TryDownloadString(WebClient webClient, string address, int times)
        {
            for (var i = 0; i < times; i++)
            {
                try
                {
                    return webClient.DownloadString(address);
                }
                catch (WebException)
                {
                }
            }
            return String.Empty;
        }
    }
}
