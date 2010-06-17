using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;

namespace Wallpaper
{
    public class WpdbFeed : IFeed
    {
        public string Resolution { get; set; }

        private Regex ItemGroup = new Regex("<enclosure url=\"([^\"]*)\"", RegexOptions.Compiled);

        #region IFeed Members

        public IEnumerable<string> GetAddresses()
        {
            var feedContent = new WebClient().DownloadString(@"http://www.wpdb.de/rss/rss_newest.php");
            var items = ItemGroup.Matches(feedContent);
            foreach (Match item in items)
            {
                var address = item.Groups[1].Value.Replace("thumbnail", this.Resolution);
                yield return address;
            }
        }

        #endregion
    }
}
