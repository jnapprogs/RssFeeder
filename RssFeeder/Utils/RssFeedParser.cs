using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml;
using RssFeeder.Models;
using RssFeeder.Resources;

namespace RssFeeder.Utils
{
    public class RssFeedParser : IRssParser
    {
        public async Task<IReadOnlyCollection<RssLinkResource>> ParseAsync(IEnumerable<RssLink> input)
        {
            var rssFeeds = new List<RssLinkResource>();
            foreach (RssLink feed in input)
            {
                RssLinkResource resource = await ParseFeedAsync(feed);
                rssFeeds.Add(resource);
            }

            return rssFeeds;
        }

        private async Task<RssLinkResource> ParseFeedAsync(RssLink rssFeed)
        {
            SyndicationFeed feed = await CreateSyndicationFeedAsync(rssFeed.Url);
            RssLinkResource resource = new RssLinkResource
            {
                Id = rssFeed.Id,
                Name = feed.Title.Text,
                Description = feed.Description.Text,
                ImageUrl = feed.ImageUrl
            };

            return resource;
        }

        private async Task<SyndicationFeed> CreateSyndicationFeedAsync(string url)
        {
            SyndicationFeed feed = await Task.Run(() =>
            {
                var xmlReader = XmlReader.Create(url);
                SyndicationFeed syndicationFeed = SyndicationFeed.Load(xmlReader);
                xmlReader.Close();
                ;

                return syndicationFeed;
            });

            return feed;
        }
    }
}
