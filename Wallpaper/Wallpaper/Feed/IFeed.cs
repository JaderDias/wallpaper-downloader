using System.Collections.Generic;

namespace Wallpaper
{
    public interface IFeed
    {
        IEnumerable<string> GetAddresses();
    }
}
