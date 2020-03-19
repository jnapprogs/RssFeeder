using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using RssFeeder.Models;
using RssFeeder.Resources;
using RssFeeder.ViewModels;

namespace RssFeeder.Utils
{
    public class RssFeedParser : IRssParser
    {
        public async Task<IReadOnlyCollection<RssLinkResource>> ParseFeedsAsync(IEnumerable<RssLink> input)
        {
            var rssFeeds = new List<RssLinkResource>();
            foreach (RssLink feed in input)
            {
                RssLinkResource resource = await ParseFeedAsync(feed);
                rssFeeds.Add(resource);
            }

            return rssFeeds;
        }

        public async Task<RssFeedViewModel> ParseArticlesAsync(string url, string sortType)
        {
            SyndicationFeed feed = await CreateSyndicationFeedAsync(url);
            var articles = new List<RssFeedArticle>();

            foreach (SyndicationItem item in feed.Items)
            {
                var article = new RssFeedArticle
                {
                    Title = item.Title.Text,
                    Url = item.Id,
                    Description = item.Summary?.Text != null ? HttpUtility.HtmlDecode(item.Summary.Text) : "No summary available",
                    PublishDate = item.PublishDate.DateTime
                };

                articles.Add(article);
            }

            articles = Sort(articles, sortType);

            var feedSummary = new RssFeedSummary
            {
                NumberOfArticles = articles.Count,
                EarliestPublishDate = articles.Min(article => article.PublishDate),
                LatestPublishDate = articles.Max(article => article.PublishDate),
                ArticlesWithImage = 0
            };

            return new RssFeedViewModel
            {
                SortType = sortType,
                FeedUrl = url,
                Summary = feedSummary,
                Articles = articles
            };
        }

        private List<RssFeedArticle> Sort(List<RssFeedArticle> articles, string sortType)
        {
            switch (sortType)
            {
                case SortTypes.None:
                    return articles;
                case SortTypes.TitleAscending:
                    return articles.OrderBy(article => article.Title).ToList();
                case SortTypes.TitleDescending:
                    return articles.OrderByDescending(article => article.Title).ToList();
                case SortTypes.PublishDateAscending:
                    return articles.OrderBy(article => article.PublishDate).ToList();
                case SortTypes.PublishDateDescending:
                    return articles.OrderByDescending(article => article.PublishDate).ToList();
                case SortTypes.DescriptionAscending:
                    return articles.OrderBy(article => article.Description).ToList();
                case SortTypes.DescriptionDescending:
                    return articles.OrderByDescending(article => article.Description).ToList();
                default:
                    return articles;
            }
        }

        private async Task<RssLinkResource> ParseFeedAsync(RssLink rssFeed)
        {
            SyndicationFeed feed = await CreateSyndicationFeedAsync(rssFeed.Url);
            string description = rssFeed.Description ?? feed.Description?.Text;
            RssLinkResource resource = new RssLinkResource
            {
                Id = rssFeed.Id,
                FeedLink = rssFeed.Url,
                Name = feed.Title.Text,
                Description = description ?? "No description provided",
                ImageUrl = feed.ImageUrl ?? null
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
