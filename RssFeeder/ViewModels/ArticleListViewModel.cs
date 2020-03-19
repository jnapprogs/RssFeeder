using System.Collections.Generic;
using RssFeeder.Models;

namespace RssFeeder.ViewModels
{
    public class ArticleListViewModel
    {
        public RssFeedSummary FeedSummary { get; set; }
        public IList<SortListItem> SortListItems { get; set; }
        public IEnumerable<RssFeedArticle> Articles { get; set; }
    }
}
