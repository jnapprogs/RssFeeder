using System.Collections.Generic;
using RssFeeder.Models;
using RssFeeder.Utils;

namespace RssFeeder.ViewModels
{
    public class RssFeedViewModel
    {
        public string SortType { get; set; }
        public string FeedUrl { get; set; }
        public IList<SortListItem> SortListItems { get; set; } = new List<SortListItem>
        {
            new SortListItem("Title Ascending", SortTypes.TitleAscending),
            new SortListItem("Title Descending", SortTypes.TitleDescending),
            new SortListItem("Publish Date Ascending", SortTypes.PublishDateAscending),
            new SortListItem("Publish Date Descending", SortTypes.PublishDateDescending),
            new SortListItem("Description Ascending", SortTypes.DescriptionAscending),
            new SortListItem("Description Descending", SortTypes.DescriptionDescending)
        };
        public RssFeedSummary Summary { get; set; }
        public IEnumerable<RssFeedArticle> Articles { get; set; }
    }
}
