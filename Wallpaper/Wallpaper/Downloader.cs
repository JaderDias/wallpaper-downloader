using System.Linq;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using log4net;
using log4net.Config;

namespace Wallpaper
{
    public sealed class Downloader
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Downloader));

        private static readonly Downloader instance = new Downloader();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Downloader()
        {
            BasicConfigurator.Configure();
        }

        private Downloader()
        {
        }

        /// <summary>
        /// The public Instance property to use
        /// </summary>
        public static Downloader Instance
        {
            get { return instance; }
        }

        private Regex FilenameGroup = new Regex("/([^/]*)$", RegexOptions.Compiled);

        public void Download(IFeed feed, string folder)
        {
            var addresses = feed.GetAddresses();
            foreach (var address in addresses)
            {
                var fileName = FilenameGroup.Match(address).Groups[1].Value;
                fileName = Path.Combine(folder, fileName);
                if (ShouldDownload(fileName))
                {
                    return;
                }
                try
                {
                    new WebClient().DownloadFile(address, fileName);
                }
                catch (WebException)
                {
                }
            }
        }

        public void DownloadFeeds(string resolution, string outputFolder)
        {
            var feeds = new IFeed[]
            {
                new WpdbFeed()
                {
                    Resolution = resolution
                },
                new InterfaceLiftFeed()
                {
                    Resolution = resolution
                }
            };
            foreach (var feed in feeds)
            {
                Downloader.Instance.Download(feed, outputFolder);
            }
        }

        private bool ShouldDownload(string path)
        {
            var fileName = Path.GetFileName(path);
            var dontDownloadFile = Model.GetDontDownloadFilePath();
            return FileExists(path)
                && File.ReadAllLines(dontDownloadFile).Any(a => a == fileName);
        }

        private bool FileExists(string path)
        {
            for (var i = 0; i <= 4; i++)
            {
                if (File.Exists(path))
                {
                    return true;
                }
                path = "0" + path;
            }
            return false;
        }

        public void DownloadAPage(string resolution, string outputFolder, int page)
        {
            var webClient = new WebClient();
            var filenameGroup = new Regex("/([^/]*)$", RegexOptions.Compiled);
            var source = new InterfaceLiftSource()
            {
                Resolution = resolution
            };
            var pageCount = source.GetPageCount();
            if (page <= pageCount)
            {
                var resourceUris = source.GetResourceUris(page);
                foreach (var resourceUri in resourceUris)
                {
                    var fileName = filenameGroup.Match(resourceUri).Groups[1].Value;
                    var path = Path.Combine(outputFolder, fileName);
                    if (!ShouldDownload(path))
                    {
                        if (!WebClientExtensions.TryDownloadFile(webClient, resourceUri, path, 2))
                        {
                            log.Error("Error when downloading " + resourceUri);
                        }
                    }
                }
            }
        }
    }
}
