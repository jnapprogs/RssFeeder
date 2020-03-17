using AutoMapper;
using RssFeeder.Models;
using RssFeeder.Resources;

namespace RssFeeder.Profiles
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<NewRssLinkResource, RssLink>();
        }
    }
}
