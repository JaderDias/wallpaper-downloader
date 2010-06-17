using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;

namespace Wallpaper
{
    public class InterfaceLiftFeed : IFeed
    {
        public string Address { get; set; }
        public string Resolution { get; set; }

        private Regex ItemGroup = new Regex("src=\"([^\"]*)\"", RegexOptions.Compiled);

        #region IFeed Members

        public IEnumerable<string> GetAddresses()
        {
            var feedContent = new WebClient().DownloadString(@"http://interfacelift.com/wallpaper_beta/rss/");
            var items = ItemGroup.Matches(feedContent);
            foreach (Match item in items)
            {
                var address = item.Groups[1].Value
                    .Replace("/previews/", "/dl/")
                    .Replace(".jpg", String.Format("_{0}.jpg", this.Resolution))
                    ;
                yield return address;
            }
        }

        #endregion
    }
}
