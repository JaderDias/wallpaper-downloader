using System.Collections.Generic;

namespace Wallpaper
{
    public interface ISource
    {
        int GetPageCount();
        IEnumerable<string> GetResourceUris(int pageNumber);
    }
}
