using AutoMapper;
using RssFeeder.Models;
using RssFeeder.Resources;

namespace RssFeeder.Profiles
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<RssLink, RssLinkResource>();
        }
    }
}
