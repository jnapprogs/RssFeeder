using System.Collections.Generic;
using System.Threading.Tasks;
using RssFeeder.Models;
using RssFeeder.Resources;

namespace RssFeeder.Utils
{
    public interface IRssParser
    {
        Task<IReadOnlyCollection<RssLinkResource>> ParseAsync(IEnumerable<RssLink> rssLinks);
    }
}
