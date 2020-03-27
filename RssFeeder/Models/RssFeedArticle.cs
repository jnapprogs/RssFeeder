using System;

namespace RssFeeder.Models
{
    public class RssFeedArticle
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public Uri Image { get; set; }
        public DateTime PublishDate { get; set; }
        
    }
}
