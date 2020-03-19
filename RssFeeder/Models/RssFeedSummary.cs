using System;

namespace RssFeeder.Models
{
    public class RssFeedSummary
    {
        public int NumberOfArticles { get; set; }
        public int ArticlesWithImage { get; set; }
        public DateTime? EarliestPublishDate { get; set; }
        public DateTime? LatestPublishDate { get; set; }

        public bool IsNewSummary() => EarliestPublishDate == null;
    }
}
