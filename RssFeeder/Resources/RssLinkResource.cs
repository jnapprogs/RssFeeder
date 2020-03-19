using System;

namespace RssFeeder.Resources
{
    public class RssLinkResource
    {
        public int Id { get; set; }
        public string FeedLink { get; set; }
        public string Name { get; set; }
        public Uri ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
