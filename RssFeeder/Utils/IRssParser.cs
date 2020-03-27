using System.Collections.Generic;
using System.Threading.Tasks;
using RssFeeder.Models;
using RssFeeder.Resources;
using RssFeeder.ViewModels;

namespace RssFeeder.Utils
{
    public interface IRssParser
    {
        Task<IReadOnlyCollection<RssLinkResource>> ParseFeedsAsync(IEnumerable<RssLink> rssLinks);
        Task<RssFeedViewModel> ParseArticlesAsync(string url, string sortType);
    }
}
