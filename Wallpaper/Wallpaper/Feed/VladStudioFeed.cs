using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;

namespace Wallpaper
{
    public class VladStudioFeed : IFeed
    {
        public string Address { get; set; }
        public string Resolution { get; set; }

        private Regex ItemGroup = new Regex("src=\"([^\"]*)\"&gt;</description>", RegexOptions.Compiled);

        #region IFeed Members

        public IEnumerable<string> GetAddresses()
        {
            var feedContent = new WebClient().DownloadString(this.Address);
            var items = ItemGroup.Matches(feedContent);
            foreach (Match item in items)
            {
                var address = item.Groups[1].Value
                    .Replace("http://rack1.vladstudio.com/jpg_low/300x225/", String.Format("http://rack2.vladstudio.com/jpg_high_free/{0}/", this.Resolution))
                    .Replace("_300x225.jpg", String.Format("_{0}.jpg", this.Resolution))
                    ;
                yield return address;
            }
        }

        #endregion
    }
}
