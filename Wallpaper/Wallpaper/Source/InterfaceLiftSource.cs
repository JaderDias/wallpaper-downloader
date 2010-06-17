using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Text.RegularExpressions;

namespace Wallpaper
{
    public class InterfaceLiftSource : ISource
    {
        public string Resolution { get; set; }

        public string GetPage(int pageNumber)
        {
            var webClient = new WebClient();
            var pageUriFormat = "http://interfacelift.com/wallpaper_beta/downloads/date/any/index{0}.html?promo=disabled";
            var pageUri = String.Format(pageUriFormat, pageNumber.ToString());
            return WebClientExtensions.TryDownloadString(webClient, pageUri, 1);
        }

        #region ISource Members

        public int GetPageCount()
        {
            var firstPage = GetPage(1);
            var numberOfPagesGroup = new Regex(@"page \d* of (\d*)");
            var numberOfPagesMatch = numberOfPagesGroup.Match(firstPage);
            return int.Parse(numberOfPagesMatch.Groups[1].Value, CultureInfo.InvariantCulture);
        }

        public IEnumerable<string> GetResourceUris(int pageNumber)
        {
            var resourceUriFormat = "http://interfacelift.com/wallpaper_beta/dl/{0}_{1}_{2}.jpg";
            var nthPage = this.GetPage(pageNumber);
            var resourceUriGroups = new Regex(@"sndReqload\(this,'([^']*)','([^']*)'");
            var matches = resourceUriGroups.Matches(nthPage);
            foreach (Match match in matches)
            {
                yield return String.Format(resourceUriFormat, match.Groups[2].Value, match.Groups[1], this.Resolution);
            }
        }

        #endregion
    }
}
